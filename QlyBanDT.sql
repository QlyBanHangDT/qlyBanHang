USE master
GO
IF EXISTS(SELECT * FROM sys.databases WHERE name='QLDT_LK')
BEGIN
        DROP DATABASE QLDT_LK
END
CREATE DATABASE QLDT_LK
GO
USE QLDT_LK
GO

-- tạo bảng
-- GR ADMIN(00): CONTROL ALL
-- GR NHÂN VIÊN(01): HỖ TRỢ KHÁCH HÀNG XỬ LÝ ĐƠN HÀNG
-- GR KHÁCH HÀNG(02): NGƯỜI DÙNG
CREATE TABLE GRTK (
    ID INT IDENTITY NOT NULL,
    TEN NVARCHAR(50), -- TÊN GR
    CODEGR CHAR(2),
    CONSTRAINT PK_GR PRIMARY KEY (ID) 
)
CREATE TABLE TAIKHOAN (
    ID VARCHAR(15) NOT NULL, -- CREATE AUTO
    USERNAME VARCHAR(50), -- CHECK USERNAME THEO GROUP
    PW VARBINARY(50), -- MÃ HÓA + salt
	HOATDONG BIT,
    CONSTRAINT PK_TK PRIMARY KEY (ID)
)
CREATE TABLE NHOMNGUOIDUNG (
	ID_GR INT REFERENCES GRTK(ID),
	ID_TK VARCHAR(15) REFERENCES TAIKHOAN(ID),
	CONSTRAINT PK_NND PRIMARY KEY (ID_GR, ID_TK)
)
CREATE TABLE THONGTINTAIKHOAN (
    ID VARCHAR(20) NOT NULL, -- CREATE AUTO
    HOTEN NVARCHAR(50), -- HỌ TÊN
    NGSINH DATE, -- NGÀY SINH
    GTINH BIT, -- 1: NAM, 0: NỮ, NULL: CHƯA BIẾT(QUY VỀ 0)
    NGTAO DATE, -- NGÀY TẠO
    EMAIL VARCHAR(50), -- ĐỊA CHỈ EMAIL
    SDT VARCHAR(11), -- SDT
    DCHI NVARCHAR(50), -- ĐỊA CHỈ NHÀ / ĐỊA CHỈ GIAO
    ID_TAIKHOAN VARCHAR(15) REFERENCES TAIKHOAN(ID) ON DELETE CASCADE,
    CONSTRAINT PK_TTTK PRIMARY KEY (ID)
)
CREATE TABLE MANHINH (
	ID VARCHAR(15) NOT NULL,
	TENMH NVARCHAR(50),
	CONSTRAINT PK_MH PRIMARY KEY (ID)
)
CREATE TABLE QL_PHANQUYEN (
	ID_GRTK INT REFERENCES GRTK(ID) NOT NULL,
	ID_MH VARCHAR(15) REFERENCES MANHINH(ID) NOT NULL,
	COQUYEN BIT NOT NULL,
	CONSTRAINT PK_PQ PRIMARY KEY (ID_GRTK, ID_MH)
)
CREATE TABLE KHACHHANG (
    ID VARCHAR(10) NOT NULL, -- CREATE AUTO
    ID_TK VARCHAR(15),
    DIEMTICHLUY INT,
    CONSTRAINT PK_KH PRIMARY KEY (ID),
    CONSTRAINT FK_KH_TK FOREIGN KEY (ID_TK) REFERENCES TAIKHOAN(ID)
)
CREATE TABLE NHANVIEN (
    ID VARCHAR(10) NOT NULL, -- CREATE AUTO
    ID_TK VARCHAR(15),
	TINHTRANG NVARCHAR(50),
    CONSTRAINT PK_NV PRIMARY KEY (ID),
    CONSTRAINT FK_NV_TK FOREIGN KEY (ID_TK) REFERENCES TAIKHOAN(ID) ON DELETE CASCADE
)
CREATE TABLE DANHMUC ( -- điện thoại & phụ kiện
    ID INT IDENTITY NOT NULL,
    TENDANHMUC NVARCHAR(50),
    CONSTRAINT PK_DMUC PRIMARY KEY (ID)
)
CREATE TABLE LOAISP ( 
    ID VARCHAR(6) NOT NULL,
    TENLOAI NVARCHAR(50), -- android, iphone, điện thoại phổ thông
	IDDM INT REFERENCES DANHMUC(ID), -- LOẠI SP ĐÓ THUỘC DANH MỤC NÀO
    CONSTRAINT PK_LSP PRIMARY KEY (ID)
)
CREATE TABLE HANG ( -- hãng sp
    ID INT IDENTITY NOT NULL,
    TENHANG NVARCHAR(20),
    CONSTRAINT PK_HANG PRIMARY KEY(ID)
)
CREATE TABLE SANPHAM ( -- _________________________________
    ID VARCHAR(5) NOT NULL, -- CREATE AUTO
    TENSP NVARCHAR(MAX), -- TÊN SẢN PHẨM
    -- SOLUONG INT, -- SỐ LƯỢNG TỒN KHO
    NSX NVARCHAR(30), -- NHÀ SẢN XUẤT
    HINHANH VARCHAR(50),
    ID_LOAI VARCHAR(6) REFERENCES LOAISP(ID),
    ID_HANG INT REFERENCES HANG(ID), -- HÃNG SP
    CONSTRAINT PK_SP PRIMARY KEY (ID)
)
CREATE TABLE IMEICODE ( -- số imei của thiết bị
	ID INT IDENTITY NOT NULL,
	MA VARCHAR(16),
	TRANGTHAI BIT, -- true: còn hoạt động
	ID_SP VARCHAR(5) REFERENCES SANPHAM(ID),
	CONSTRAINT PK_IMEICODE PRIMARY KEY (ID)
)
CREATE TABLE CAUHINH (
    ID INT IDENTITY NOT NULL,
    ID_SP VARCHAR(5) REFERENCES SANPHAM(ID),
    TENCAUHINH NVARCHAR(30),
    NOIDUNGCAUHINH NVARCHAR(100),
    CONSTRAINT PK_CH PRIMARY KEY (ID)
)
CREATE TABLE DONGIA ( -- đơn giá
    ID INT IDENTITY NOT NULL,
    ID_SP VARCHAR(5) REFERENCES SANPHAM(ID),
    GIA FLOAT, -- GIÁ
    NGCAPNHAT DATETIME, -- NGÀY CẬP NHẬT - LẤY NGÀY MỚI NHẤT
    CONSTRAINT PK_DG PRIMARY KEY (ID, ID_SP)
)
CREATE TABLE HOADON (
    ID VARCHAR(10) NOT NULL, -- CREATE AUTO
    NGTAO DATE, -- NGÀY TẠO HÓA ĐƠN
    DONGIA FLOAT, -- TỔNG (SỐ LƯỢNG * ĐƠN GIÁ) - khuyến mãi nếu có
    ID_KH VARCHAR(10) REFERENCES KHACHHANG(ID),
    ID_NV VARCHAR(10) REFERENCES NHANVIEN(ID),
    CONSTRAINT PK_HD PRIMARY KEY (ID)
)
CREATE TABLE CHITIETHD (
    ID INT IDENTITY NOT NULL,
    ID_HD VARCHAR(10) REFERENCES HOADON(ID),
	ID_IMEI INT REFERENCES IMEICODE(ID),
	DONGIA FLOAT, -- ĐƠN GIÁ CỦA 1 SP TẠI THỜI ĐIỂM MUA
    CONSTRAINT PK_CTHD PRIMARY KEY (ID, ID_HD) 
)
CREATE TABLE NCC (
	ID INT IDENTITY NOT NULL,
	TENNCC NVARCHAR(60),
	CONSTRAINT PK_NCC PRIMARY KEY (ID)
)
CREATE TABLE PHIEUNHAP (
    ID VARCHAR(10) NOT NULL, -- CREATE AUTO
    NGTAO DATE, -- NGÀY TẠO PHIẾU NHẬP
    DONGIA FLOAT, -- TỔNG (SỐ LƯỢNG * ĐƠN GIÁ)
    ID_NV VARCHAR(10) REFERENCES NHANVIEN(ID),
	ID_NCC INT REFERENCES NCC(ID),
    CONSTRAINT PK_PN PRIMARY KEY (ID)
)
CREATE TABLE CHITIETPN (
    ID INT IDENTITY NOT NULL,
    ID_PN VARCHAR(10) REFERENCES PHIEUNHAP(ID),
    ID_IMEI INT REFERENCES IMEICODE(ID),
	DONGIA FLOAT, -- ĐƠN GIÁ CỦA 1 SP TẠI THỜI ĐIỂM NHẬP HÀNG
    CONSTRAINT PK_CTPN PRIMARY KEY (ID, ID_PN) 
)
CREATE TABLE THONGKECMT (
    ID INT IDENTITY NOT NULL,
	NOIDUNG NVARCHAR(MAX), -- NỘI DUNG BÌNH LUẬN CỦA KHÁCH HÀNG
	ID_SP VARCHAR(5) REFERENCES SANPHAM(ID),
	NGGHI DATETIME, -- NGÀY GHI NHẬN 
	CONSTRAINT PK_THONKE_CMT PRIMARY KEY (ID) 
)
CREATE TABLE PHIEUKIEMKHO (
    ID VARCHAR(10) NOT NULL,
	ID_NV VARCHAR(10) REFERENCES NHANVIEN(ID),
    NGLAP DATE, -- NGÀY LẬP PHIẾU KIỂM
	NGHOANTHANH DATE, -- NGÀY HOÀN THÀNH PHIẾU
	THOIGIANLAP TIME, -- THỜI GIAN LẬP PHIẾU KIỂM
    TONGSLLECH INT, -- TỔNG SỐ LƯỢNG LỆCH
	TRANGTHAI BIT,
    CONSTRAINT PK_PKK PRIMARY KEY (ID)
)

CREATE TABLE CT_PHIEUKIEMKHO (
    ID_SP VARCHAR(5) REFERENCES SANPHAM(ID),
	ID_PKK VARCHAR(10) REFERENCES PHIEUKIEMKHO(ID),
	SL_TONKHO INT, -- SỐ LƯỢNG TỒN KHO TRONG HỆ THỐNG
	SL_THUCTE INT, -- SỐ LƯỢNG THỰC TẾ
	SL_LECH INT,
	GIATRILECH FLOAT,
    CONSTRAINT PK_CT_PKK PRIMARY KEY (ID_SP,ID_PKK)
)

GO

-- CREATE TABLE VIEW 
CREATE VIEW rndVIEW
AS
SELECT RAND() rndResult
GO

----------------------------------------------------------
--  ___   Proc                     _   ___   Func       --
-- | _ \_ _ ___  __   __ _ _ _  __| | | __|  _ _ _  __  --
-- |  _/ '_/ _ \/ _| / _` | ' \/ _` | | _| || | ' \/ _| --
-- |_| |_| \___/\__| \__,_|_||_\__,_| |_| \_,_|_||_\__| --
----------------------------------------------------------

-- function

CREATE FUNCTION fn_giaSP(@maSP VARCHAR(5))
RETURNS FLOAT
AS
	BEGIN
		DECLARE @donGia FLOAT -- đơn giá của sản phẩm x

		SELECT TOP 1 @donGia = GIA
		FROM DONGIA
		WHERE ID_SP = @maSP
		ORDER BY NGCAPNHAT DESC

		RETURN @donGia
	END
GO

CREATE FUNCTION fn_PhanQuyen(@idGR INT)
RETURNS TABLE
AS
	RETURN SELECT ID, TENMH, COQUYEN
	FROM MANHINH MH LEFT JOIN QL_PHANQUYEN PQ
		ON MH.ID = PQ.ID_MH AND ID_GRTK = @idGR
GO

CREATE FUNCTION fn_hash(@text VARCHAR(50))
RETURNS VARBINARY(MAX)
AS
BEGIN
	RETURN HASHBYTES('SHA2_256', @text);
END
GO

CREATE FUNCTION fn_getRandom ( -- TRẢ VỀ 1 SỐ NGẪU NHIÊN
	@min int, 
	@max int
)
RETURNS INT
AS
BEGIN
    RETURN FLOOR((SELECT rndResult FROM rndVIEW) * (@max - @min + 1) + @min);
END
GO

CREATE FUNCTION fn_getCodeGr(@tenGr VARCHAR(50)) -- TRẢ VỀ CODE GR
RETURNS CHAR(2)
AS
BEGIN
    DECLARE @CODEGR CHAR(2)
    SELECT @CODEGR = CODEGR FROM GRTK WHERE TEN = @tenGr

    RETURN @CODEGR
END
GO

--------------------------------------------------------------------------------------

CREATE  FUNCTION fn_ConvertFirstLetterinCapital(@Text NVARCHAR(MAX)) 
RETURNS NVARCHAR(MAX) 
AS 
	BEGIN
		DECLARE @Index INT;
		DECLARE @FirstChar NCHAR(1);
		DECLARE @LastChar NCHAR(1);
		DECLARE @String NVARCHAR(MAX);

		SET @String = LOWER(@Text);
		SET @Index = 1;
		WHILE @Index <= LEN(@Text)
			BEGIN
				SET @FirstChar = SUBSTRING(@Text, @Index, 1);
				SET @LastChar = CASE
									WHEN @Index = 1
									THEN ' '
									ELSE SUBSTRING(@Text, @Index - 1, 1)
								END;
				IF @LastChar IN(' ', ';', ':', '!', '?', ',', '.', '_', '-', '/', '&', '''', '(', '#', '*', '$', '@')
					BEGIN
						IF @FirstChar != ''''
							OR UPPER(@FirstChar) != 'S'
							SET @String = STUFF(@String, @Index, 1, UPPER(@FirstChar));
				END;
				SET @Index = @Index + 1;
			END;
				RETURN @String;
	END;
GO



---------------------------------------------------------------------------------------

CREATE FUNCTION fn_Ten(@idTK VARCHAR(15))
RETURNS NVARCHAR(50)
AS
BEGIN
    DECLARE @TEN NVARCHAR(50)
    SELECT @TEN = HOTEN FROM THONGTINTAIKHOAN WHERE ID_TAIKHOAN = @idTK

    RETURN DBO.fn_ConvertFirstLetterinCapital(@TEN)
END
GO

CREATE FUNCTION fn_getIDTK(@username VARCHAR(50))
RETURNS VARCHAR(15)
AS
BEGIN
    DECLARE @id VARCHAR(15)
    SELECT @id = ID FROM TAIKHOAN WHERE USERNAME = @username

    RETURN @id
END
GO

CREATE FUNCTION fn_autoIDTK(
@ma char(2)
) -- id TÀI KHOẢN
RETURNS VARCHAR(15)
AS
BEGIN
	DECLARE @ID VARCHAR(15)

	IF (SELECT COUNT(ID) FROM TAIKHOAN) = 0
		SET @ID = '0'
	ELSE
		SELECT @ID = MAX(RIGHT(ID, 3)) FROM TAIKHOAN 

    DECLARE @ngayTao VARCHAR(8) = convert(VARCHAR, getdate(), 112) -- format yyyymmdd
    DECLARE @stt VARCHAR(5) = CONVERT(VARCHAR, CONVERT(INT, @ID) + 1)

	SELECT @ID = CASE
		WHEN @ID >= 99 THEN @ngayTao + @ma + @stt
		WHEN @ID >=  9 THEN @ngayTao + @ma + '0' + @stt
		WHEN @ID >=  0 and @ID < 9 THEN @ngayTao + @ma + '00' + @stt
	END

	RETURN @ID
END
GO

CREATE FUNCTION fn_autoIDKH() -- id KHÁCH HÀNG
RETURNS VARCHAR(10)
AS
BEGIN
	DECLARE @ID VARCHAR(10)

	IF (SELECT COUNT(ID) FROM KHACHHANG) = 0
		SET @ID = '0'
	ELSE
		SELECT @ID = MAX(RIGHT(ID, 3)) FROM KHACHHANG

    DECLARE @stt VARCHAR(5) = CONVERT(VARCHAR, CONVERT(INT, @ID) + 1)
    DECLARE @maCode CHAR(2) = 'KH'

	SELECT @ID = CASE
		WHEN @ID >= 99 THEN @maCode + @stt
		WHEN @ID >=  9 THEN @maCode + '0' + @stt
		WHEN @ID >=  0 and @ID < 9 THEN @maCode + '00' + @stt
	END

	RETURN @ID
END
GO

CREATE FUNCTION fn_autoIDNV() -- id NHÂN VIÊN
RETURNS VARCHAR(10)
AS
BEGIN
	DECLARE @ID VARCHAR(10)

	IF (SELECT COUNT(ID) FROM NHANVIEN) = 0
		SET @ID = '0'
	ELSE
		SELECT @ID = MAX(RIGHT(ID, 3)) FROM NHANVIEN

    DECLARE @stt VARCHAR(5) = CONVERT(VARCHAR, CONVERT(INT, @ID) + 1)
    DECLARE @maCode CHAR(2) = 'NV'

	SELECT @ID = CASE
		WHEN @ID >= 99 THEN @maCode + @stt
		WHEN @ID >=  9 THEN @maCode + '0' + @stt
		WHEN @ID >=  0 and @ID < 9 THEN @maCode + '00' + @stt
	END

	RETURN @ID
END
GO

CREATE FUNCTION fn_autoIDHD() -- id HÓA ĐƠN
RETURNS VARCHAR(10)
AS
BEGIN
	DECLARE @ID VARCHAR(10)

	IF (SELECT COUNT(ID) FROM HOADON) = 0
		SET @ID = '0'
	ELSE
		SELECT @ID = MAX(RIGHT(ID, 3)) FROM HOADON

    DECLARE @stt VARCHAR(5) = CONVERT(VARCHAR, CONVERT(INT, @ID) + 1)
    DECLARE @maCode CHAR(2) = 'HD'

	SELECT @ID = CASE
		WHEN @ID >= 99 THEN @maCode + @stt
		WHEN @ID >=  9 THEN @maCode + '0' + @stt
		WHEN @ID >=  0 and @ID < 9 THEN @maCode + '00' + @stt
	END

	RETURN @ID
END
GO
CREATE FUNCTION fn_autoIDPN() -- id Phiếu nhập
RETURNS VARCHAR(10)
AS
BEGIN
	DECLARE @ID VARCHAR(10)

	IF (SELECT COUNT(ID) FROM PHIEUNHAP) = 0
		SET @ID = '0'
	ELSE
		SELECT @ID = MAX(RIGHT(ID, 3)) FROM PHIEUNHAP

    DECLARE @stt VARCHAR(5) = CONVERT(VARCHAR, CONVERT(INT, @ID) + 1)
    DECLARE @maCode CHAR(2) = 'PN'

	SELECT @ID = CASE
		WHEN @ID >= 99 THEN @maCode + @stt
		WHEN @ID >=  9 THEN @maCode + '0' + @stt
		WHEN @ID >=  0 and @ID < 9 THEN @maCode + '00' + @stt
	END

	RETURN @ID
END
GO
CREATE FUNCTION fn_autoIDLSP() -- id LOẠI SP 
RETURNS VARCHAR(6)
AS
BEGIN
	DECLARE @ID VARCHAR(6)

	IF (SELECT COUNT(ID) FROM LOAISP) = 0
		SET @ID = '0'
	ELSE
		SELECT @ID = MAX(RIGHT(ID, 3)) FROM LOAISP

    DECLARE @stt VARCHAR(3) = CONVERT(VARCHAR, CONVERT(INT, @ID) + 1)
    DECLARE @maCode CHAR(3) = 'LSP'

	SELECT @ID = CASE
		WHEN @ID >= 99 THEN @maCode + @stt
		WHEN @ID >=  9 THEN @maCode + '0' + @stt
		WHEN @ID >=  0 and @ID < 9 THEN @maCode + '00' + @stt
	END

	RETURN @ID
END
GO

CREATE FUNCTION fn_autoIDSP() -- id SP
RETURNS VARCHAR(5)
AS
BEGIN
	DECLARE @ID VARCHAR(5)

	IF (SELECT COUNT(ID) FROM SANPHAM) = 0
		SET @ID = '0'
	ELSE
		SELECT @ID = MAX(RIGHT(ID, 3)) FROM SANPHAM

    DECLARE @stt VARCHAR(3) = CONVERT(VARCHAR, CONVERT(INT, @ID) + 1)
	
    DECLARE @maCode CHAR(2) = 'SP'
	
	SELECT @ID = CASE
		WHEN @ID >= 99 THEN @maCode + @stt
		WHEN @ID >=  9 THEN @maCode + '0' + @stt
		WHEN @ID >=  0 and @ID < 9 THEN @maCode + '00' + @stt
	END
	RETURN @ID
END
GO

CREATE FUNCTION fn_autoIDTTND(
    @idLogin VARCHAR(15)
) -- id CỦA THÔNG TIN NGƯỜI DÙNG: IDLOGIN + mã rand
RETURNS VARCHAR(20)
AS
BEGIN
    DECLARE @randNumber INT = DBO.fn_getRandom(100, 999)
    
    DECLARE @ID VARCHAR(20) = @idLogin + convert(CHAR, @randNumber)

	RETURN @ID
END
GO

-- proc 
CREATE PROC sp_getIDGR -- TRẢ VỀ ID GR
@tenGr NVARCHAR(50)
AS
    DECLARE @IDGR INT
    SELECT @IDGR = ID FROM GRTK WHERE TEN = @tenGr

    RETURN @IDGR 
GO

CREATE PROC sp_GetErrorInfo  
AS  
SELECT  
    ERROR_NUMBER() AS ErrorNumber  
    ,ERROR_SEVERITY() AS ErrorSeverity  
    ,ERROR_STATE() AS ErrorState  
    ,ERROR_PROCEDURE() AS ErrorProcedure  
    ,ERROR_LINE() AS ErrorLine  
    ,ERROR_MESSAGE() AS 'Message';
GO 

--ID INT IDENTITY NOT NULL,
--ID_SP VARCHAR(5) REFERENCES SANPHAM(ID),
--GIA FLOAT, -- GIÁ
--NGCAPNHAT DATETIME, -- NGÀY CẬP NHẬT - LẤY NGÀY MỚI NHẤT
CREATE PROC sp_SetDG -- SET ĐƠN GIÁ
@tenSP NVARCHAR(50),
@gia FLOAT
AS
	BEGIN
		DECLARE @maSP VARCHAR(10)
		SELECT @maSP = ID FROM SANPHAM WHERE TENSP = @tenSP

		INSERT DONGIA(ID_SP, GIA)
		VALUES (@maSP, @gia)
	END
GO
CREATE PROC sp_GetMaHD
@maHD VARCHAR(10) OUTPUT
AS
	SELECT @maHD = DBO.fn_autoIDHD()
GO
CREATE PROC sp_GetMaPN
@maPN VARCHAR(10) OUTPUT
AS
	SELECT @maPN = DBO.fn_autoIDPN()
GO
--ID VARCHAR(10) NOT NULL, -- CREATE AUTO
--NGTAO DATE, -- NGÀY TẠO HÓA ĐƠN
--DONGIA FLOAT, -- TỔNG (SỐ LƯỢNG * ĐƠN GIÁ)
--ID_KH VARCHAR(10) REFERENCES KHACHHANG(ID),
--ID_NV VARCHAR(10) REFERENCES NHANVIEN(ID)

--ID INT IDENTITY NOT NULL,
--ID_HD VARCHAR(10) REFERENCES HOADON(ID),
--ID_SP VARCHAR(5) REFERENCES SANPHAM(ID),
--SOLUONG INT, -- SỐ LƯỢNG > 0, số lượng bán
CREATE PROC sp_AddHD
@maHD VARCHAR(10),
@tenKH NVARCHAR(50),
@tenNV NVARCHAR(50),
@soIMEI VARCHAR(16)
AS
	BEGIN TRY
		DECLARE @maNV VARCHAR(10), @maKH VARCHAR(10), @maSP VARCHAR(5), @idIMEI INT

		IF NOT EXISTS (SELECT * FROM HOADON WHERE ID = @maHD)
		BEGIN
			INSERT HOADON(ID) SELECT @maHD

			-- LẤY MÃ NHÂN VIÊN
			SELECT @maNV = NHANVIEN.ID FROM NHANVIEN JOIN THONGTINTAIKHOAN on THONGTINTAIKHOAN.ID_TAIKHOAN = NHANVIEN.ID_TK WHERE HOTEN = @tenNV
			-- LẤY MÃ KHÁCH HÀNG
			SELECT @maKH = KHACHHANG.ID FROM KHACHHANG JOIN THONGTINTAIKHOAN on THONGTINTAIKHOAN.ID_TAIKHOAN = KHACHHANG.ID_TK WHERE HOTEN = @tenKH

			-- ADD MÃ KHÁCH HÀNG VÀ NHÂN VIÊN VÀO HÓA ĐƠN
			UPDATE HOADON SET ID_KH = @maKH, ID_NV = @maNV WHERE ID = @maHD
		END

		-- LẤY ID IMEI & và mã sản phẩm
		SELECT @idIMEI = ID, @maSP = ID_SP FROM IMEICODE WHERE MA = @soIMEI

		-- CẬP NHẬT ĐƠN GIÁ ---------------------- kiểm tra ngày mới nhất trong đơn giá
		DECLARE @donGia FLOAT -- đơn giá của sản phẩm x

		SELECT TOP 1 @donGia = GIA
		FROM DONGIA
		WHERE ID_SP = @maSP
		ORDER BY NGCAPNHAT DESC

		-- THÊM THÔNG TIN CHO HÓA ĐƠN
		INSERT CHITIETHD(ID_HD, ID_IMEI, DONGIA) SELECT @maHD, @idIMEI, @donGia

		-- cập nhật hóa đơn		
		UPDATE HOADON SET DONGIA = DONGIA + @donGia WHERE ID = @maHD

		-- cập nhật trạng thái số imei
		UPDATE IMEICODE SET TRANGTHAI = 0 WHERE MA = @soIMEI -- SẢN PHẨM ĐÃ BÁN

		SELECT @soIMEI 'Message'
	END TRY
	BEGIN CATCH
		EXEC sp_GetErrorInfo;
	END CATCH
GO
CREATE PROC sp_AddPN
@maPN VARCHAR(10),
@tenNCC NVARCHAR(60),
@tenNV NVARCHAR(50),
@soIMEI VARCHAR(16)
AS
	BEGIN TRY
		DECLARE @maSP VARCHAR(5), @idIMEI INT, @maNV varchar(10), @maNCC int

		IF NOT EXISTS (SELECT * FROM PHIEUNHAP WHERE ID = @maPN)
		BEGIN
			INSERT PHIEUNHAP(ID) SELECT @maPN

			-- LẤY MÃ NHÂN VIÊN
			SELECT @maNV = NHANVIEN.ID FROM NHANVIEN JOIN THONGTINTAIKHOAN on THONGTINTAIKHOAN.ID_TAIKHOAN = NHANVIEN.ID_TK WHERE HOTEN = @tenNV
			-- LẤY MÃ KHÁCH HÀNG
			SELECT @maNCC = NCC.ID FROM NCC WHERE TENNCC = @tenNCC

			-- ADD MÃ KHÁCH HÀNG VÀ NHÂN VIÊN VÀO HÓA ĐƠN
			UPDATE PHIEUNHAP SET ID_NCC = @maNCC, ID_NV = @maNV WHERE ID = @maPN
		END

		-- LẤY ID IMEI & và mã sản phẩm
		SELECT @idIMEI = ID, @maSP = ID_SP FROM IMEICODE WHERE MA = @soIMEI

		-- CẬP NHẬT ĐƠN GIÁ ---------------------- kiểm tra ngày mới nhất trong đơn giá
		DECLARE @donGia FLOAT -- đơn giá của sản phẩm x

		SELECT TOP 1 @donGia = GIA
		FROM DONGIA
		WHERE ID_SP = @maSP
		ORDER BY NGCAPNHAT DESC

		-- THÊM THÔNG TIN CHO phiêu nhập
		INSERT CHITIETPN(ID_PN, ID_IMEI, DONGIA) SELECT @maPN, @idIMEI, @donGia

		-- cập nhật phiếu nhập	
		UPDATE PHIEUNHAP SET DONGIA = DONGIA + @donGia WHERE ID = @maPN

		SELECT @soIMEI 'Message'
	END TRY
	BEGIN CATCH
		EXEC sp_GetErrorInfo;
	END CATCH
GO

CREATE PROC sp_AddLSP -- THÊM LOẠI SP
@tenLSP NVARCHAR(50),
@tenDanhMuc NVARCHAR(50)
AS 
    BEGIN TRY
        IF EXISTS(SELECT * FROM LOAISP WHERE ID = (SELECT ID FROM LOAISP WHERE TENLOAI = @tenLSP))
			THROW 51000, N'Loại sản phẩm đã tồn tại.', 1;

		DECLARE @idDanhMuc INT
        SELECT @idDanhMuc = ID FROM DANHMUC WHERE TENDANHMUC = @tenDanhMuc
		
		INSERT LOAISP(TENLOAI, IDDM)
		SELECT @tenLSP, @idDanhMuc

	END TRY
	BEGIN CATCH
		EXEC sp_GetErrorInfo;
	END CATCH
GO
--================================================================================
--ID VARCHAR(5) NOT NULL, -- CREATE AUTO
--TENSP NVARCHAR(50), -- TÊN SẢN PHẨM
--MOTA NVARCHAR(MAX), -- MÔ TẢ
--SOLUONG INT, -- SỐ LƯỢNG TỒN KHO
---- DONGIA FLOAT, -- ĐƠN GIÁ
--NSX NVARCHAR(30), -- NHÀ SẢN XUẤT
--HINHANH VARCHAR(50),
--ID_LOAI VARCHAR(6) REFERENCES LOAISP(ID),
-- HÃNG SP
CREATE PROC sp_AddSP
@tenSP NVARCHAR(MAX),
@tenHang NVARCHAR(20), -- tên hãng sản phẩm
@gia FLOAT,
@nxs NVARCHAR(30),
@urlImage VARCHAR(50),
@tenLSP NVARCHAR(50)
AS
	BEGIN TRY
		DECLARE @IDSP VARCHAR(15) = DBO.fn_autoIDSP() -- id SP
		-- select DBO.fn_autoIDSP() select * from sanpham
		IF EXISTS(SELECT * FROM SANPHAM WHERE TENSP = @tenSP)
			THROW 51000, N'Sản phẩm đã tồn tại.', 1;

		DECLARE @IDLSP VARCHAR(6)
		SELECT @IDLSP = ID FROM LOAISP WHERE TENLOAI = @tenLSP
		
        DECLARE @IDHANG INT -- lấy id hãng sản phẩm
        SELECT @IDHANG = ID FROM HANG WHERE TENHANG = @tenHang

		INSERT SANPHAM(ID, TENSP, NSX, HINHANH, ID_LOAI, ID_HANG)
		VALUES (@IDSP, @tenSP, @nxs, @urlImage, @IDLSP, @IDHANG)

		INSERT DONGIA(ID_SP, GIA)
		VALUES (@IDSP, @gia)

		SELECT N'SUCCESS' 'Message'
	END TRY
	BEGIN CATCH
		EXEC sp_GetErrorInfo;
	END CATCH
GO

CREATE PROC sp_AddCauHinh
@tenSP NVARCHAR(Max),
@tenCH NVARCHAR(30),
@noiDungCH NVARCHAR(100)
AS
BEGIN TRY
		DECLARE @idSP VARCHAR(5)
        SELECT @idSP = ID FROM SANPHAM WHERE TENSP = @tenSP

        INSERT CAUHINH SELECT @idSP, @tenCH, @noiDungCH
	END TRY
	BEGIN CATCH
		EXEC sp_GetErrorInfo;
	END CATCH
GO

-- ID VARCHAR(20)
-- HOTEN NVARCHAR(50), -- HỌ TÊN
-- NGSINH DATE, -- NGÀY SINH
-- GTINH BIT, -- 1: NAM, 0: NỮ, NULL: CHƯA BIẾT(QUY VỀ 0)
-- NGTAO DATE, -- NGÀY TẠO
-- EMAIL VARCHAR(50), -- ĐỊA CHỈ EMAIL
-- SDT VARCHAR(11), -- SDT
-- DCHI NVARCHAR(50)
CREATE PROC sp_AddAcc
@userName VARCHAR(50), -- THÔNG TIN TÀI KHOẢN
@pw VARCHAR(50),
@hoTen NVARCHAR(50),
@ngSinh DATE,
@gioiTinh NVARCHAR(5),
@email VARCHAR(50),
@sdt VARCHAR(11),
@dChi NVARCHAR(50),
@cdGr CHAR(2)
AS
	BEGIN TRY
		DECLARE @ID VARCHAR(15) = DBO.fn_autoIDTK('01') -- id login

		DECLARE	@createPW VARBINARY(MAX) = SubString(DBO.fn_hash(@ID), 1, len(DBO.fn_hash(@ID))/2) + DBO.fn_hash(@pw + @ID)

		IF EXISTS(SELECT * FROM TAIKHOAN WHERE USERNAME = @userName)
			THROW 51000, N'Username đã tồn tại.', 1;

		-- tạo tài khoản
		INSERT TAIKHOAN(ID, USERNAME, PW)
		SELECT @ID, @userName, @createPW; 

        DECLARE @GTINH BIT = 0
        IF (UPPER(@gioiTinh) = N'NAM')
            SET @GTINH = 1;

        -- tạo thông tin người dùng
        INSERT THONGTINTAIKHOAN(ID, HOTEN, NGSINH, GTINH, EMAIL, SDT, DCHI, ID_TAIKHOAN)
        VALUES(DBO.fn_autoIDTTND(@ID), UPPER(@hoTen), @ngSinh, @GTINH, @email, @sdt, @dChi, @ID)

		if (@cdGr = 'NV')
		begin
			INSERT NHANVIEN (ID_TK) select @ID

			INSERT NHOMNGUOIDUNG SELECT 2, @ID -- thêm tài khoản vào group user
		end

		SELECT N'SUCCESS' 'Message'
	END TRY
	BEGIN CATCH
		EXEC sp_GetErrorInfo;
	END CATCH
GO

CREATE PROC sp_AddAcc_KH
@hoTen NVARCHAR(50),
@ngSinh DATE,
@gioiTinh NVARCHAR(5),
@email VARCHAR(50),
@sdt VARCHAR(11),
@dChi NVARCHAR(50)
AS
	BEGIN TRY
		DECLARE @ID VARCHAR(15) = DBO.fn_autoIDTK('02') -- id login

		-- tạo tài khoản
		INSERT TAIKHOAN(ID)
		SELECT @ID; 

        DECLARE @GTINH BIT = 0
        IF (UPPER(@gioiTinh) = N'NAM')
            SET @GTINH = 1;

        -- tạo thông tin người dùng
        INSERT THONGTINTAIKHOAN(ID, HOTEN, NGSINH, GTINH, EMAIL, SDT, DCHI, ID_TAIKHOAN)
        VALUES(DBO.fn_autoIDTTND(@ID), UPPER(@hoTen), @ngSinh, @GTINH, @email, @sdt, @dChi, @ID)

		INSERT KHACHHANG (ID_TK) SELECT @ID

		SELECT N'SUCCESS' 'Message'
	END TRY
	BEGIN CATCH
		EXEC sp_GetErrorInfo;
	END CATCH
GO

-- thay đổi mật khẩu người dùng
CREATE PROC sp_ChangeAcc
@userName VARCHAR(50), -- THÔNG TIN TÀI KHOẢN
@pw VARCHAR(50)
AS
	BEGIN TRY
		DECLARE @IDTK VARCHAR(15);
		SELECT @IDTK = ID FROM TAIKHOAN WHERE USERNAME = @userName

		DECLARE	@createPW VARBINARY(MAX) = SubString(DBO.fn_hash(@IDTK), 1, len(DBO.fn_hash(@IDTK))/2) + DBO.fn_hash(@pw + @IDTK)

		UPDATE TAIKHOAN SET PW = @createPW WHERE ID = @IDTK

		SELECT N'SUCCESS' 'Message'
	END TRY
	BEGIN CATCH
		EXEC sp_GetErrorInfo;
	END CATCH
GO

CREATE PROC sp_DelAcc
@userName VARCHAR(50), -- THÔNG TIN TÀI KHOẢN
@pw VARCHAR(50),
@GRNAME NVARCHAR(50)
AS
	BEGIN TRY
		DECLARE @IDGR INT
		EXEC @IDGR = sp_getIDGR @GRNAME -- id gr

		DECLARE @IDTK VARCHAR(15);
		SELECT @IDTK = ID FROM TAIKHOAN WHERE USERNAME = @userName

		UPDATE TAIKHOAN SET PW = NULL, USERNAME = NULL WHERE ID = @IDTK

		UPDATE NHANVIEN SET TINHTRANG = N'Đã nghỉ' WHERE ID_TK = @IDTK

		SELECT N'SUCCESS' 'Message'
	END TRY
	BEGIN CATCH
		EXEC sp_GetErrorInfo;
	END CATCH
GO

CREATE PROC sp_CKUsername
@userName VARCHAR(50),
@GRNAME NVARCHAR(50)
AS
	BEGIN TRY
		DECLARE @IDGR INT
		EXEC @IDGR = sp_getIDGR @GRNAME -- id gr

		DECLARE @IDTK VARCHAR(15);
		SELECT @IDTK = ID FROM TAIKHOAN WHERE USERNAME = @userName

		IF EXISTS(SELECT * FROM TAIKHOAN WHERE USERNAME = @userName)
			THROW 51000, N'Username đã tồn tại.', 1;

		SELECT N'ok' 'Message'
	END TRY
	BEGIN CATCH
		EXEC sp_GetErrorInfo;
	END CATCH
GO

CREATE PROC sp_UpTTTK
@maTK VARCHAR(15),
@hoTen NVARCHAR(50),
@ngSinh DATE,
@gioiTinh NVARCHAR(5),
@email VARCHAR(50),
@sdt VARCHAR(11),
@dChi NVARCHAR(50)
AS
	BEGIN TRY
		DECLARE @GTINH BIT = 0
        IF (UPPER(@gioiTinh) = N'NAM')
            SET @GTINH = 1;

        -- tạo thông tin người dùng
		UPDATE THONGTINTAIKHOAN SET HOTEN = @hoTen, 
									NGSINH=@ngSinh, 
									GTINH=@GTINH, 
									EMAIL=@email,
									SDT=@sdt,
									DCHI=@dChi
				WHERE ID_TAIKHOAN=@maTK

		SELECT N'SUCCESS' 'Message'
	END TRY
	BEGIN CATCH
		EXEC sp_GetErrorInfo;
	END CATCH
GO

CREATE PROC sp_CKAcc
@userName VARCHAR(50), -- THÔNG TIN TÀI KHOẢN
@pw VARCHAR(50)
AS
	BEGIN TRY
		DECLARE @IDTK VARCHAR(15);
		SELECT @IDTK = ID FROM TAIKHOAN WHERE USERNAME = @userName

		DECLARE	@createPW VARBINARY(MAX) = SubString(DBO.fn_hash(@IDTK), 1, len(DBO.fn_hash(@IDTK))/2) + DBO.fn_hash(@pw + @IDTK)

		IF NOT EXISTS(SELECT * FROM TAIKHOAN WHERE USERNAME = @userName AND PW = @createPW)
			THROW 51000, N'0', 1;

		DECLARE @TT BIT 
		SELECT @TT = HOATDONG FROM TAIKHOAN WHERE USERNAME = @userName AND PW = @createPW
		
		IF (@TT <> 1)
			SELECT N'2' 'Message'

		SELECT N'1' 'Message'
	END TRY
	BEGIN CATCH
		EXEC sp_GetErrorInfo;
	END CATCH
GO

CREATE PROC sp_ReportHD
@nam int
AS
	SELECT HOADON.ID, CONVERT(varchar,NGTAO,103) NGTAO, DONGIA, DBO.fn_Ten(NHANVIEN.ID_TK) TENNV, DBO.fn_Ten(KHACHHANG.ID_TK) TENKH FROM HOADON JOIN NHANVIEN 
		ON HOADON.ID_NV=NHANVIEN.ID JOIN KHACHHANG
		ON KHACHHANG.ID=HOADON.ID_KH
		WHERE YEAR(NGTAO) = @nam
GO

CREATE PROC sp_ReportBill
@idHD VARCHAR(10)
AS
	SELECT DBO.fn_Ten(KH.ID_TK) KHACHHANG, DBO.fn_Ten(NV.ID_TK) NHANVIEN, SP.TENSP, COUNT(IMEICODE.ID) SOLUONG, (CTHD.DONGIA * COUNT(IMEICODE.ID)) DONGIA
	FROM CHITIETHD CTHD JOIN HOADON HD
		ON CTHD.ID_HD = HD.ID JOIN NHANVIEN NV
		ON NV.ID = HD.ID_NV JOIN KHACHHANG KH
		ON KH.ID = HD.ID_KH JOIN IMEICODE
		ON IMEICODE.ID = CTHD.ID_IMEI JOIN SANPHAM SP
		ON SP.ID = IMEICODE.ID_SP
	WHERE HD.ID = @idHD
	GROUP BY HD.DONGIA, KH.ID_TK, NV.ID_TK, SP.TENSP, CTHD.DONGIA
GO

CREATE PROC sp_ChiTietDonHang_kh
@idKH varchar(10)
as
	select id_hd ID, TenSP, count(id_imei) SoLuong, cthd.DonGia Gia, hd.NGTAO, DBO.fn_ConvertFirstLetterinCapital(tttk.HoTen) NhanVien
	from chitiethd cthd join hoadon hd 
		on cthd.id_HD=hd.id join sanpham sp 
		on sp.id=(select id_sp from IMEICODE where id=cthd.ID_IMEI) join thongtintaikhoan tttk
		on tttk.id_taiKhoan = (select id_tk from nhanVien where id = hd.id_nv)
	where id_Kh=@idKH
	Group by id_hd, TenSP, cthd.DonGia, hd.NGTAO, tttk.HoTen
go

CREATE PROC sp_ChartSanPham
@nam int
AS
	SELECT TENSP, COUNT(MA) SOLUONGBANRA
	FROM HOADON HD JOIN CHITIETHD CTHD 
		ON HD.ID = CTHD.ID_HD JOIN IMEICODE IM
		ON IM.ID = CTHD.ID_IMEI JOIN SANPHAM SP 
		ON SP.ID = IM.ID_SP
	WHERE YEAR(NGTAO) = @nam
	GROUP BY TENSP
	ORDER BY SOLUONGBANRA DESC
GO

CREATE PROC sp_ChartNhanVien
@nam int
AS
	SELECT HOTEN, SUM(DONGIA) DOANHTHU
	FROM HOADON HD JOIN NHANVIEN NV
		ON NV.ID = HD.ID_NV JOIN THONGTINTAIKHOAN TTTK
		ON TTTK.ID_TAIKHOAN = NV.ID_TK
	WHERE YEAR(HD.NGTAO) = @nam
	GROUP BY HOTEN
	ORDER BY DOANHTHU DESC
GO

CREATE PROC sp_ChartDoanhThu
@nam int
AS
	DECLARE @tbDoanhThu TABLE (THANG INT, DOANHTHU FLOAT)
	INSERT @tbDoanhThu
		SELECT m, SUM(DONGIA) DOANHTHU
		FROM (SELECT * FROM HOADON WHERE YEAR(NGTAO) = @nam) dtn RIGHT JOIN (
			SELECT m
			FROM (VALUES (1), (2), (3), (4), (5), (6), (7), (8), (9), (10), (11), (12))
			[1 to 12](m)
		) listMonth
			ON MONTH(NGTAO)=listMonth.m
		GROUP BY m
		ORDER BY m
	
	UPDATE @tbDoanhThu SET DOANHTHU = 0 WHERE DOANHTHU IS NULL
	SELECT * FROM @tbDoanhThu
GO

CREATE PROC sp_GetKhachHang
AS
	DECLARE @tbKH TABLE(ID VARCHAR(6), HOTEN NVARCHAR(50), SDT VARCHAR(11), EMAIL VARCHAR(40), TONGGIAODICH FLOAT)

	INSERT @tbKH SELECT KH.ID, DBO.fn_Ten(KH.ID_TK) HOTEN, SDT, EMAIL, SUM(DONGIA) TONGGIAODICH
	FROM KHACHHANG KH JOIN THONGTINTAIKHOAN TTTK
		ON KH.ID_TK = TTTK.ID_TAIKHOAN LEFT JOIN HOADON HD
		ON HD.ID_KH = KH.ID
	GROUP BY KH.ID, KH.ID_TK, SDT, EMAIL

	UPDATE @tbKH SET TONGGIAODICH = 0 WHERE TONGGIAODICH IS NULL

	SELECT * FROM @tbKH
GO

-- TẠO RÀNG BUỘC
ALTER TABLE THONGTINTAIKHOAN
ADD CONSTRAINT DF_NGTAO_TTTK DEFAULT GETDATE() FOR NGTAO

ALTER TABLE LOAISP
ADD CONSTRAINT DF_LSP_ID DEFAULT DBO.fn_autoIDLSP() FOR ID

ALTER TABLE TAIKHOAN
ADD CONSTRAINT DF_HOATDONG DEFAULT 1 FOR HOATDONG

ALTER TABLE DONGIA
ADD CONSTRAINT DF_NGCAPNHAT_DG DEFAULT GETDATE() FOR NGCAPNHAT

ALTER TABLE KHACHHANG
ADD CONSTRAINT DF_ID_KH DEFAULT DBO.fn_autoIDKH() FOR ID,
    CONSTRAINT DF_DIEMTICHLUY DEFAULT 0 FOR DIEMTICHLUY

ALTER TABLE NHANVIEN 
ADD CONSTRAINT DF_ID_NV DEFAULT DBO.fn_autoIDNV() FOR ID,
    CONSTRAINT DF_TT_NV DEFAULT N'Còn làm' FOR TINHTRANG

ALTER TABLE HOADON 
ADD CONSTRAINT DF_NGTAO_HD DEFAULT GETDATE() FOR NGTAO,
    CONSTRAINT DF_ID DEFAULT DBO.fn_autoIDHD() FOR ID,
	CONSTRAINT DF_DONGIA DEFAULT 0 FOR DONGIA

ALTER TABLE PHIEUNHAP 
ADD CONSTRAINT DF_NGTAO_PN DEFAULT GETDATE() FOR NGTAO,
	CONSTRAINT DF_DONGIA_PN DEFAULT 0 FOR DONGIA

ALTER TABLE IMEICODE
ADD CONSTRAINT DF_TRANGTHAI DEFAULT 1 FOR TRANGTHAI

ALTER TABLE QL_PHANQUYEN
ADD CONSTRAINT DF_CQ DEFAULT 0 FOR COQUYEN

ALTER TABLE THONGKECMT
ADD CONSTRAINT DF_NGGHI DEFAULT GETDATE() FOR NGGHI

GO

--------------------------------
--  ___           _   data    --
-- |   \   __ _  | |_   __ _  --
-- | |) | / _` | |  _| / _` | --
-- |___/  \__,_|  \__| \__,_| --
--------------------------------

-- bảng ncc
insert NCC select N'Nhà cung cấp A'
insert NCC select N'Nhà cung cấp B'

-- Bảng MANHINH
INSERT MANHINH VALUES('M1', N'Quản lý khách hàng')
INSERT MANHINH VALUES('M2', N'Quản lý sản phẩm')
INSERT MANHINH VALUES('M3', N'Quản lý tài khoản')
INSERT MANHINH VALUES('M5', N'Nhập hàng')
INSERT MANHINH VALUES('M6', N'Bán hàng')
INSERT MANHINH VALUES('M7', N'Xem thông tin cá nhân')
INSERT MANHINH VALUES('M8', N'Kiểm tra tồn kho')
INSERT MANHINH VALUES('M9', N'Phân quyền') 
INSERT MANHINH VALUES('M10', N'Quản lý nhóm người dùng') 
INSERT MANHINH VALUES('M11', N'Thêm người dùng vào nhóm')
INSERT MANHINH VALUES('MMH', N'Quản lý màn hình')
INSERT MANHINH VALUES('MML', N'Phân tích bình luận khách hàng')

-- BẢNG TB_GRTK
INSERT GRTK VALUES(N'ADMIN', '00')
INSERT GRTK VALUES(N'USER', '01')

-- bảng phân quyền
-- phân quyền cho admin
INSERT QL_PHANQUYEN VALUES 
(1, 'M1', 1),
(1, 'M2', 1),
(1, 'M3', 1),
(1, 'M11', 1),
(1, 'M5', 1),
(1, 'M6', 1),
(1, 'M7', 1),
(1, 'M8', 1),
(1, 'M9', 1),
(1, 'M10', 1),
(1, 'MMH', 1),
(1, 'MML', 1)

-- phân quyền cho user (mặc định)
INSERT QL_PHANQUYEN VALUES 
(2, 'M1', 0),
(2, 'M2', 0),
(2, 'M3', 0),
(2, 'M5', 0),
(2, 'M6', 0),
(2, 'M7', 1),
(2, 'M8', 0),
(2, 'M9', 0),
(2, 'M11', 0),
(2, 'M10', 0),
(2, 'MMH', 0),
(2, 'MML', 0)

-- BẢNG TAIKHOAN
EXEC sp_AddAcc 'admin', 'admin@123456789', N'Admin', '2-5-2001', N'nam', 'admin@gmail.com', '000000000', '',''
--nhân viên
EXEC sp_AddAcc 'tuhueson', 'tuhueson@123456789', N'Từ Huệ Sơn', '2001/05/02', N'nam', 'tuhueson@gmail.com', '000000000', '','NV'
EXEC sp_AddAcc 'leductai', 'leductai@123456789', N'Lê Đức Tài', '2001/12/04', N'nam', 'leductai@gmail.com', '000000000', '','NV'
EXEC sp_AddAcc 'nguyenvanteo', 'nguyenvanteo@123456789', N'Nguyễn văn Tèo', '2001/12/05', N'nam', 'nguyenvanteo@gmail.com', '000000000', '','NV'
EXEC sp_AddAcc 'trannhattrung', 'trannhattrung@123456789', N'Trần Nhật Trung', '2001/05/10', N'nam', 'trannhattrung@gmail.com', '000000000', '','NV'
EXEC sp_AddAcc 'dogianguyen', 'dogianguyen@123456789', N'Đỗ Gia Nguyên', '2001/04/10', N'nữ', 'dogianguyen@gmail.com', '000000000', '','NV'
EXEC sp_AddAcc 'lytuong', 'lytuong@123456789', N'Lý Tường', '2001/05/12', N'nữ', 'lytuong@gmail.com', '000000000', '','NV'
EXEC sp_AddAcc 'tranvu', 'tranvu@123456789', N'Trần Vũ', '2001/11/12', N'nam', 'tranvu@gmail.com', '000000000', '','NV'
EXEC sp_AddAcc 'doquyen', 'doquyen@123456789', N'Đỗ Quyên', '2002/05/10', N'nữ', 'doquyen@gmail.com', '000000000', '','NV'
EXEC sp_AddAcc 'daokimhue', 'daokimhue@123456789', N'Đào kim huệ', '2001/11/10', N'nữ', 'daokimhue@gmail.com', '000000000', '','NV'
EXEC sp_AddAcc 'hogiacat', 'hogiacat@123456789', N'hồ gia cát', '2001/11/21', N'nam', 'hogiacat@gmail.com', '000000000', '','NV'
EXEC sp_AddAcc 'vuthanhlong', 'vuthanhlong@123456789', N'vũ thanh long', '2001/05/11', N'nam', 'vuthanhlong@gmail.com', '000000000', '','NV'
-- khách hàng
EXEC sp_AddAcc_KH N'Lê Thị Linh', '2001/12/10', N'nữ', 'lethilinh@gmail.com', '0938252524', ''
EXEC sp_AddAcc_KH N'Hồ Minh Ngọc', '2001/05/10', N'nam', 'hominhngoc@gmail.com', '0935252528', ''
EXEC sp_AddAcc_KH N'Lý Gia Huy', '2001/05/21', N'nam', 'lygiahuy@gmail.com', '0937151518', ''
EXEC sp_AddAcc_KH N'Nguyễn Thị Thương', '2001/04/11', N'Nữ', 'thuongnguyen@gmail.com', '0935262628', ''
EXEC sp_AddAcc_KH N'Trần Ngọc Sang', '2001/02/11', N'nam', 'sangtran@gmail.com', '0915236268', ''
EXEC sp_AddAcc_KH N'Huỳnh Ái Linh', '2001/03/14', N'Nữ', 'linh247@gmail.com', '0926352528', ''
EXEC sp_AddAcc_KH N'Đỗ Ái Vy', '2001/04/12', N'nữ', 'vydo@gmail.com', '0925362624', ''
EXEC sp_AddAcc_KH N'Cao Gia Vinh', '2002/05/14', N'nữ', 'vinh123@gmail.com', '0932562315', ''
EXEC sp_AddAcc_KH N'Lê Hồng Đào', '2002/11/21', N'Nữ', 'daole132@gmail.com', '0925216358', ''
EXEC sp_AddAcc_KH N'Nguyễn Văn Cao', '2002/05/14', N'nam', 'caonguyen134@gmail.com', '0935626248', ''
EXEC sp_AddAcc_KH N'Từ Huệ Sơn', '2001/05/23', N'nam', 'tuhueson@gmail.com', '0938252793', ''

-- bảng nhóm người dùng
INSERT NHOMNGUOIDUNG SELECT 1, DBO.fn_getIDTK('admin')

-- BẢNG DANH MỤC
INSERT DANHMUC SELECT N'Điện Thoại'
INSERT DANHMUC SELECT N'Phụ kiện'

-- BẢNG LOẠI SẢN PHẨM
EXEC sp_AddLSP N'Android', N'Điện Thoại'
EXEC sp_AddLSP N'iPhone(iOS)', N'Điện Thoại'
EXEC sp_AddLSP N'Điện thoại phổ thông', N'Điện Thoại'
-- phụ kiện
EXEC sp_AddLSP N'Pin sạc dự phòng', N'Phụ kiện'
EXEC sp_AddLSP N'Sạc, cáp', N'Phụ kiện'
EXEC sp_AddLSP N'Miếng dán màn hình', N'Phụ kiện'
EXEC sp_AddLSP N'Ốp lưng điện thoại', N'Phụ kiện'
EXEC sp_AddLSP N'Gậy tự sướng', N'Phụ kiện'
EXEC sp_AddLSP N'Đế móc điện thoại', N'Phụ kiện'
EXEC sp_AddLSP N'Túi chống nước', N'Phụ kiện'

-- BẢNG HÃNG SP
INSERT HANG (TENHANG) SELECT N'iPhone'
INSERT HANG (TENHANG) SELECT N'SAMSUNG'
INSERT HANG (TENHANG) SELECT N'OPPO'
INSERT HANG (TENHANG) SELECT N'VIVO'
INSERT HANG (TENHANG) SELECT N'XIAOMI'
INSERT HANG (TENHANG) SELECT N'REALME'
INSERT HANG (TENHANG) SELECT N'NOKIA'
INSERT HANG (TENHANG) SELECT N'MOBELL'
INSERT HANG (TENHANG) SELECT N'INTEL'
INSERT HANG (TENHANG) SELECT N'MASSTEL'
INSERT HANG (TENHANG) SELECT N'Energizer'

-- BẢNG SẢN PHẨM
EXEC sp_AddSP N'iPhone 12 64GB', N'iPhone', 20490000, null, 'iPhone12_64.jpg', N'iPhone(iOS)' --
EXEC sp_AddSP N'iPhone 13 Pro Max 1TB', N'iPhone', 49990000, null, 'iPhone13ProMax_1.jpg', N'iPhone(iOS)' --
EXEC sp_AddSP N'iPhone 13 Pro 1TB', N'iPhone', 46990000, null, 'iPhone13Pro_1.jpg', N'iPhone(iOS)' --
EXEC sp_AddSP N'iPhone 13 Pro Max 512GB', N'iPhone', 43990000, null, 'iPhone13ProMax_512.jpg', N'iPhone(iOS)' --
EXEC sp_AddSP N'iPhone 13 Pro 512GB', N'iPhone', 40990000, null, 'iPhone13Pro_512.jpg', N'iPhone(iOS)' --
EXEC sp_AddSP N'iPhone 12 Pro Max 512GB', N'iPhone', 39990000, null, 'iPhone12Pro_512.jpg', N'iPhone(iOS)' --
EXEC sp_AddSP N'iPhone 13 mini 256GB', N'iPhone', 24990000, null, 'iPhone13Mini_256.jpg', N'iPhone(iOS)' --
EXEC sp_AddSP N'iPhone 11 128GB', N'iPhone', 18990000, null, 'iPhone11_128.jpg', N'iPhone(iOS)' --
EXEC sp_AddSP N'iPhone XR 128GB', N'iPhone', 16490000, null, 'iPhoneXR_128.jpg', N'iPhone(iOS)' --
EXEC sp_AddSP N'Samsung Galaxy Z Fold3 5G 512GB', N'SAMSUNG', 43990000, null, 'samsungGalaxyZFold3_512.jpg', N'Android'
EXEC sp_AddSP N'Samsung Galaxy A03s', N'SAMSUNG', 3690000, null, 'samsungGalaxyA03s.jpg', N'Android'
EXEC sp_AddSP N'Samsung Galaxy M51', N'SAMSUNG', 9490000, null, 'samsungGalaxyM51.jpg', N'Android'
EXEC sp_AddSP N'Samsung Galaxy Z Flip3 5G 256GB', N'SAMSUNG', 25990000, null, 'samsungGalaxyZFlip3_256.jpg', N'Android'
EXEC sp_AddSP N'OPPO Reno6 Z 5G', N'OPPO', 9490000, null, 'oppoReno6Z.jpg', N'Android'
EXEC sp_AddSP N'OPPO A74', N'OPPO', 6690000, null, 'oppoA74.jpg', N'Android'
EXEC sp_AddSP N'OPPO A55', N'OPPO', 4990000, null, 'oppoA55.jpg', N'Android'
EXEC sp_AddSP N'OPPO Reno5 Marvel', N'OPPO', 9190000, null, 'oppoReno5Marvel.jpg', N'Android'
EXEC sp_AddSP N'Vivo Y21', N'VIVO', 4290000, null, 'vivoY21.jpg', N'Android'
EXEC sp_AddSP N'Vivo X70 Pro 5G', N'VIVO', 18990000, null, 'vivoX70Pro.jpg', N'Android'
EXEC sp_AddSP N'Vivo Y72 5G', N'VIVO', 7590000, null, 'vivoY72.jpg', N'Android'
EXEC sp_AddSP N'Vivo V20 SE', N'VIVO', 6490000, null, 'vivoV20SE.jpg', N'Android'
EXEC sp_AddSP N'Xiaomi 11T 5G 256GB', N'XIAOMI', 11990000, null, 'xiaomi11T_256.jpg', N'Android'
EXEC sp_AddSP N'Xiaomi 11 Lite 5G NE', N'XIAOMI', 9490000, null, 'xiaomi11Lite.jpg', N'Android'
EXEC sp_AddSP N'Xiaomi Redmi Note 10S', N'XIAOMI', 6490000, null, 'xiaomiRedmiNote10s.jpg', N'Android'
EXEC sp_AddSP N'Xiaomi Redmi Note 9', N'XIAOMI', 4490000, null, 'xiaomiRedmiNote9.jpg', N'Android'
EXEC sp_AddSP N'Realme C21Y 4GB', N'REALME', 3990000, null, 'realmeC21Y.jpg', N'Android'
EXEC sp_AddSP N'Realme 7 Pro', N'REALME', 8540000, null, 'realme7Pro.jpg', N'Android'
EXEC sp_AddSP N'Realme 8 Pro Vàng Rực Rỡ', N'REALME', 8240000, null, 'realme8ProVang.jpg', N'Android'
EXEC sp_AddSP N'Realme 6 Pro', N'REALME', 6990000, null, 'realme6Pro.jpg', N'Android'
EXEC sp_AddSP N'Nokia 3.4', N'NOKIA', 3290000, null, 'nokia34Android.jpg', N'Android'
EXEC sp_AddSP N'Nokia C30', N'NOKIA', 2790000, null, 'nokiaC30.jpg', N'Android'
EXEC sp_AddSP N'Nokia 210', N'NOKIA', 790000, null, 'nokia210.jpg', N'Điện thoại phổ thông'
EXEC sp_AddSP N'Nokia 6300 4G', N'NOKIA', 1090000, null, 'nokia6300.jpg', N'Điện thoại phổ thông'
EXEC sp_AddSP N'Mobell P41', N'MOBELL', 990000, null, 'mobellP41.jpg', N'Android'
EXEC sp_AddSP N'Mobell Rock 3', N'MOBELL', 590000, null, 'mobellRock3.jpg', N'Điện thoại phổ thông'
EXEC sp_AddSP N'Mobell C310', N'MOBELL', 230000, null, 'mobellC310.jpg', N'Điện thoại phổ thông'
EXEC sp_AddSP N'Mobell M729', N'MOBELL', 450000, null, 'mobellM729.jpg', N'Điện thoại phổ thông'
EXEC sp_AddSP N'Itel L6006', N'INTEL', 2190000, null, 'itelL6006.jpg', N'Android'
EXEC sp_AddSP N'Itel it9200 4G', N'INTEL', 700000, null, 'itelIt9200.jpg', N'Điện thoại phổ thông'
EXEC sp_AddSP N'Itel it2590', N'INTEL', 450000, null, 'itelIt2590.jpg', N'Điện thoại phổ thông'
EXEC sp_AddSP N'Itel it5071', N'INTEL', 330000, null, 'itelIt5071.jpg', N'Điện thoại phổ thông'
EXEC sp_AddSP N'Masstel Fami P20', N'MASSTEL', 550000, null, 'masstelFamiP20.jpg', N'Điện thoại phổ thông'
EXEC sp_AddSP N'Masstel Play 50', N'MASSTEL', 500000, null, 'masstelPlay50.jpg', N'Điện thoại phổ thông'
EXEC sp_AddSP N'Masstel IZI 300', N'MASSTEL', 450000, null, 'masstelIzi300.jpg', N'Điện thoại phổ thông'
EXEC sp_AddSP N'Masstel IZI 230', N'MASSTEL', 380000, null, 'masstelIzi230.jpg', N'Điện thoại phổ thông'
EXEC sp_AddSP N'Energizer E241S', N'Energizer', 890000, null, 'energizerE241s.jpg', N'Điện thoại phổ thông'
EXEC sp_AddSP N'Energizer E20', N'Energizer', 650000, null, 'energizerE20.jpg', N'Điện thoại phổ thông'
EXEC sp_AddSP N'Energizer P20', N'Energizer', 590000, null, 'energizerP20.jpg', N'Điện thoại phổ thông'
EXEC sp_AddSP N'Energizer E100', N'Energizer', 490000, null, 'energizerE100.jpg', N'Điện thoại phổ thông'

--SẠC DỰ PHÒNG
EXEC sp_AddSP N'Pin sạc dự phòng Polymer 10.000 mAh Type C Xiaomi Power Bank 3 Ultra Compact', N'XIAOMI', 474000, N'Trung Quốc', 'polymerXiaomiUltraCompact.jpg', N'Pin sạc dự phòng'
EXEC sp_AddSP N'Pin sạc dự phòng Polymer 10.000mAh Type C Fast Charge Xiaomi Mi Power Bank 3', N'XIAOMI', 374000, N'Trung Quốc', 'pinsacduphongpolymer.jpg', N'Pin sạc dự phòng'
EXEC sp_AddSP N'Pin sạc dự phòng Polymer 10.000 mAh Type C PD Samsung EB-P3300', N'SAMSUNG', 693000, N'Trung Quốc', 'polymersamsungebP3300.jpg', N'Pin sạc dự phòng'
EXEC sp_AddSP N'Pin sạc dự phòng Polymer 20.000 mAh Type C PD Energizer UE20011PQ', N'Energizer', 770000, N'Trung Quốc', 'energizerfix2.jpg', N'Pin sạc dự phòng'

--Sạc, cáp
EXEC sp_AddSP N'Adapter Sạc Type C PD 25W Samsung EP-TA800N', N'SAMSUNG', 490000, N'Việt Nam', 'type-c-pdsamsungTa800n.jpg', N'Sạc, cáp'
EXEC sp_AddSP N'Cáp chuyển đổi Type C sang 3.5mm Samsung EE-UC10JUW Trắng', N'SAMSUNG', 220000, N'Việt Nam', 'capChuyenDoisamsungeeUc10juw.jpg', N'Sạc, cáp'
EXEC sp_AddSP N'Cáp Type-C 1.2 m Energizer C41C2AGBKT Đen', N'Energizer', 175000, N'Trung Quốc', 'captypecEnergizec41c2agbkt.jpg', N'Sạc, cáp'
EXEC sp_AddSP N'Sạc không dây xe hơi 20W Xiaomi GDS4127GL Đen', N'XIAOMI', 774000, N'Trung Quốc', 'sacKhongDayXiaomiGds4127gl.jpg', N'Sạc, cáp'

--Miếng dán màn hình
EXEC sp_AddSP N'Miếng dán màn hình iPhone 13 Pro Max', N'iPhone', 50000, null, '.jpg', N'Miếng dán màn hình'
EXEC sp_AddSP N'Miếng dán kính iPhone 13 Pro Max JCPAL', N'iPhone', 390000, null, '.jpg', N'Miếng dán màn hình'
EXEC sp_AddSP N'Miếng dán full màn hình TA SHT31 Galaxy S21 Ultra', N'SAMSUNG', 100000, null, '.jpg', N'Miếng dán màn hình'
EXEC sp_AddSP N'Miếng dán màn hình Galaxy S21', N'SAMSUNG', 50000, null, '.jpg', N'Miếng dán màn hình'

--Ốp lưng điện thoại
EXEC sp_AddSP N'Ốp lưng iPhone 13 Silicon OSMIA Cam', null, 70000, null, 'oplungiphone13cam.jpg', N'Ốp lưng điện thoại'
EXEC sp_AddSP N'Ốp lưng iPhone 13 Pro Max Nhựa cứng viền dẻo Magnets KingxBar Trắng', null, 245000, null, 'iphone13proMaxNhuaCung.jpg', N'Ốp lưng điện thoại'
EXEC sp_AddSP N'Ốp lưng Galaxy A71 nhựa dẻo Woven OSMIA Xanh Đậm', null, 49000, null, 'oplunggalaxya71XanhDam.jpg', N'Ốp lưng điện thoại'
EXEC sp_AddSP N'Ốp lưng Galaxy A71 nhựa dẻo TPU Electroplating Triple COSANO Bạc', null, 70000, null, 'oplunggalaxy-a71nhuadeo.jpg', N'Ốp lưng điện thoại'

--Gậy tự sướng
EXEC sp_AddSP N'Gậy chụp ảnh Bluetooth Tripod Xmobile K06 Đen', null, 240000, null, 'gayChupAnhxmobileK06.jpg', N'Gậy tự sướng'
EXEC sp_AddSP N'Gậy Chụp Ảnh Bluetooth Cosano HD-P7', null, 120000, null, 'gayChupAnhCosanoP7.jpg', N'Gậy tự sướng'
EXEC sp_AddSP N'Gậy Chụp Ảnh Xmobile Hình Cô gái CSA005', null, 72000, null, 'gayChupAnhCoGaiHong.jpg', N'Gậy tự sướng'
EXEC sp_AddSP N'Gậy Chụp Ảnh Osmia OW5', null, 70000, null, 'gayChupAnhOw5.jpg', N'Gậy tự sướng'

--Đế móc điện thoại
EXEC sp_AddSP N'Dây đeo điện thoại OSMIA silicon CRS', null, 24000, null, '.jpg', N'Đế móc điện thoại'
EXEC sp_AddSP N'Bộ 2 móc điện thoại OSMIA CK-CRS10 Mèo cá heo xanh', null, 48000, null, '.jpg', N'Đế móc điện thoại'
EXEC sp_AddSP N'Bộ 2 móc điện thoại OSMIA CK-CRS11 Hươu cánh cụt vàng', null, 48000, null, '.jpg', N'Đế móc điện thoại'
EXEC sp_AddSP N'Bộ 2 móc điện thoại nhựa dẻo OSMIA CK-CRS3 Nai Mèo Đen', null, 32000, null, '.jpg', N'Đế móc điện thoại'

--Túi chống nước
EXEC sp_AddSP N'Túi chống nước Cosano JMG-C-20 Xanh lá', null, 40000, null, '.jpg', N'Túi chống nước'
EXEC sp_AddSP N'Túi chống nước Cosano JMG-C-21 Xanh biển', null, 40000, null, '.jpg', N'Túi chống nước'
EXEC sp_AddSP N'Túi chống nước Cosano 5 inch Vàng Chanh', null, 40000, null, '.jpg', N'Túi chống nước'
EXEC sp_AddSP N'Túi chống nước 5 inch Cosano Hình Chú mèo', null, 40000, null, '.jpg', N'Túi chống nước'

-- Bảng cấu hình(thông tin sản phẩm)
EXEC sp_AddCauHinh N'Energizer E100', N'Màn hình', N'TFT LCD, 2.4", 65.536 màu'
EXEC sp_AddCauHinh N'Energizer E100', N'Camera sau', N'0.3 MP'
EXEC sp_AddCauHinh N'Energizer E100', N'SIM', N'2 SIM thường, Hỗ trợ 4G'
EXEC sp_AddCauHinh N'Energizer E100', N'Pin', N'1500 mAh'
EXEC sp_AddCauHinh N'Energizer E100', N'Danh bạ', N'300 số'
EXEC sp_AddCauHinh N'Energizer E100', N'Thẻ nhớ', N'MicroSD, hỗ trợ tối đa 16 GB'
EXEC sp_AddCauHinh N'Energizer E100', N'Radio FM', N'Có'
EXEC sp_AddCauHinh N'Energizer E100', N'Jack cắm tai nghe', N'3.5 mm'

EXEC sp_AddCauHinh N'Energizer E20', N'Màn hình', N'TFT LCD, 2.8", 262.144 màu'
EXEC sp_AddCauHinh N'Energizer E20', N'Camera sau', N'0.3 MP'
EXEC sp_AddCauHinh N'Energizer E20', N'SIM', N'2 SIM thường, Hỗ trợ 4G'
EXEC sp_AddCauHinh N'Energizer E20', N'Pin', N'1000 mAh'
EXEC sp_AddCauHinh N'Energizer E20', N'Danh bạ', N'300 số'
EXEC sp_AddCauHinh N'Energizer E20', N'Thẻ nhớ', N'MicroSD, hỗ trợ tối đa 16 GB'
EXEC sp_AddCauHinh N'Energizer E20', N'Radio FM', N'Có'
EXEC sp_AddCauHinh N'Energizer E20', N'Jack cắm tai nghe', N'3.5 mm'

EXEC sp_AddCauHinh N'Energizer P20', N'Màn hình', N'TFT LCD, 2.8", 262.144 màu'
EXEC sp_AddCauHinh N'Energizer P20', N'Camera sau', N'0.3 MP'
EXEC sp_AddCauHinh N'Energizer P20', N'SIM', N'2 SIM thường, Hỗ trợ 4G'
EXEC sp_AddCauHinh N'Energizer P20', N'Pin', N'4000 mAh'
EXEC sp_AddCauHinh N'Energizer P20', N'Danh bạ', N'300 số'
EXEC sp_AddCauHinh N'Energizer P20', N'Thẻ nhớ', N'MicroSD, hỗ trợ tối đa 16 GB'
EXEC sp_AddCauHinh N'Energizer P20', N'Radio FM', N'Có'
EXEC sp_AddCauHinh N'Energizer P20', N'Jack cắm tai nghe', N'3.5 mm'

EXEC sp_AddCauHinh N'Energizer E241S', N'Màn hình', N'TFT LCD, 2.4", 16 triệu màu'
EXEC sp_AddCauHinh N'Energizer E241S', N'Camera sau', N'QVGA (320 x 240 pixels)'
EXEC sp_AddCauHinh N'Energizer E241S', N'Camera trước', N'VGA (0.3 MP)'
EXEC sp_AddCauHinh N'Energizer E241S', N'SIM', N'2 Micro SIM, Hỗ trợ 4G'
EXEC sp_AddCauHinh N'Energizer E241S', N'Pin', N'1900 mAh'
EXEC sp_AddCauHinh N'Energizer E241S', N'Danh bạ', N'300 số'
EXEC sp_AddCauHinh N'Energizer E241S', N'Thẻ nhớ', N'MicroSD, hỗ trợ tối đa 32 GB'
EXEC sp_AddCauHinh N'Energizer E241S', N'Radio FM', N'Có'
EXEC sp_AddCauHinh N'Energizer E241S', N'Jack cắm tai nghe', N'3.5 mm'

EXEC sp_AddCauHinh N'Masstel IZI 230', N'Màn hình', N'TFT LCD, 2.4", 262.144 màu'
EXEC sp_AddCauHinh N'Masstel IZI 230', N'Camera sau', N'0.08 MP'
EXEC sp_AddCauHinh N'Masstel IZI 230', N'SIM', N'2 SIM thường, Hỗ trợ 2G'
EXEC sp_AddCauHinh N'Masstel IZI 230', N'Pin', N'1700 mAh'
EXEC sp_AddCauHinh N'Masstel IZI 230', N'Danh bạ', N'300 số'
EXEC sp_AddCauHinh N'Masstel IZI 230', N'Thẻ nhớ', N'MicroSD, hỗ trợ tối đa 16 GB'
EXEC sp_AddCauHinh N'Masstel IZI 230', N'Radio FM', N'FM không cần tai nghe'
EXEC sp_AddCauHinh N'Masstel IZI 230', N'Jack cắm tai nghe', N'3.5 mm'

EXEC sp_AddCauHinh N'Masstel IZI 300', N'Màn hình', N'TFT LCD, 2.4", 65.536 màu'
EXEC sp_AddCauHinh N'Masstel IZI 300', N'Camera sau', N'0.08 MP'
EXEC sp_AddCauHinh N'Masstel IZI 300', N'SIM', N'1 Micro SIM & 1 SIM thường, Hỗ trợ 2G'
EXEC sp_AddCauHinh N'Masstel IZI 300', N'Pin', N'2500 mAh'
EXEC sp_AddCauHinh N'Masstel IZI 300', N'Danh bạ', N'300 số'
EXEC sp_AddCauHinh N'Masstel IZI 300', N'Thẻ nhớ', N'MicroSD, hỗ trợ tối đa 16 GB'
EXEC sp_AddCauHinh N'Masstel IZI 300', N'Radio FM', N'Có'
EXEC sp_AddCauHinh N'Masstel IZI 300', N'Jack cắm tai nghe', N'3.5 mm'

EXEC sp_AddCauHinh N'Masstel Play 50', N'Màn hình', N'TFT LCD, 2.4", 256.000 màu'
EXEC sp_AddCauHinh N'Masstel Play 50', N'Camera sau', N'0.08 MP'
EXEC sp_AddCauHinh N'Masstel Play 50', N'SIM', N'2 SIM thường, Hỗ trợ 2G'
EXEC sp_AddCauHinh N'Masstel Play 50', N'Pin', N'3000 mAh'
EXEC sp_AddCauHinh N'Masstel Play 50', N'Danh bạ', N'1000 số'
EXEC sp_AddCauHinh N'Masstel Play 50', N'Thẻ nhớ', N'MicroSD, hỗ trợ tối đa 32 GB'
EXEC sp_AddCauHinh N'Masstel Play 50', N'Radio FM', N'FM không cần tai nghe'
EXEC sp_AddCauHinh N'Masstel Play 50', N'Jack cắm tai nghe', N'3.5 mm'

EXEC sp_AddCauHinh N'Masstel Fami P20', N'Màn hình', N'TFT LCD, 2.2", 262.144 màu'
EXEC sp_AddCauHinh N'Masstel Fami P20', N'Camera sau', N'0.08 MP'
EXEC sp_AddCauHinh N'Masstel Fami P20', N'SIM', N'2 SIM thường, Hỗ trợ 2G'
EXEC sp_AddCauHinh N'Masstel Fami P20', N'Pin', N'1400 mAh'
EXEC sp_AddCauHinh N'Masstel Fami P20', N'Danh bạ', N'300 số'
EXEC sp_AddCauHinh N'Masstel Fami P20', N'Thẻ nhớ', N'MicroSD, hỗ trợ tối đa 16 GB'
EXEC sp_AddCauHinh N'Masstel Fami P20', N'Radio FM', N'Có'
EXEC sp_AddCauHinh N'Masstel Fami P20', N'Jack cắm tai nghe', N'3.5 mm'

EXEC sp_AddCauHinh N'Itel it5071', N'Màn hình', N'TFT LCD, 2.4", 65.536 màu'
EXEC sp_AddCauHinh N'Itel it5071', N'Camera sau', N'0.08 MP'
EXEC sp_AddCauHinh N'Itel it5071', N'SIM', N'2 SIM thường, Hỗ trợ 2G'
EXEC sp_AddCauHinh N'Itel it5071', N'Pin', N'1900 mAh'
EXEC sp_AddCauHinh N'Itel it5071', N'Danh bạ', N'500 số'
EXEC sp_AddCauHinh N'Itel it5071', N'Thẻ nhớ', N'MicroSD, hỗ trợ tối đa 16 GB'
EXEC sp_AddCauHinh N'Itel it5071', N'Radio FM', N'FM không cần tai nghe'
EXEC sp_AddCauHinh N'Itel it5071', N'Jack cắm tai nghe', N'3.5 mm'

EXEC sp_AddCauHinh N'Itel it2590', N'Màn hình', N'TFT LCD, 2.2", 65.536 màu'
EXEC sp_AddCauHinh N'Itel it2590', N'Camera sau', N'0.3 MP'
EXEC sp_AddCauHinh N'Itel it2590', N'SIM', N'2 Micro SIM, Hỗ trợ 2G'
EXEC sp_AddCauHinh N'Itel it2590', N'Pin', N'1900 mAh'
EXEC sp_AddCauHinh N'Itel it2590', N'Danh bạ', N'500 số'
EXEC sp_AddCauHinh N'Itel it2590', N'Thẻ nhớ', N'MicroSD, hỗ trợ tối đa 32 GB'
EXEC sp_AddCauHinh N'Itel it2590', N'Radio FM', N'Có'
EXEC sp_AddCauHinh N'Itel it2590', N'Jack cắm tai nghe', N'3.5 mm'

EXEC sp_AddCauHinh N'Itel it9200 4G', N'Màn hình', N'TFT LCD, 2.4", 262.000 màu'
EXEC sp_AddCauHinh N'Itel it9200 4G', N'Camera sau', N'0.3 MP'
EXEC sp_AddCauHinh N'Itel it9200 4G', N'Camera trước', N'VGA (0.3 MP)'
EXEC sp_AddCauHinh N'Itel it9200 4G', N'SIM', N'2 Micro SIM, Hỗ trợ 4G'
EXEC sp_AddCauHinh N'Itel it9200 4G', N'Pin', N'1900 mAh'
EXEC sp_AddCauHinh N'Itel it9200 4G', N'Danh bạ', N'Không giới hạn'
EXEC sp_AddCauHinh N'Itel it9200 4G', N'Thẻ nhớ', N'MicroSD, hỗ trợ tối đa 128 GB'
EXEC sp_AddCauHinh N'Itel it9200 4G', N'Radio FM', N'Có'
EXEC sp_AddCauHinh N'Itel it9200 4G', N'Jack cắm tai nghe', N'3.5 mm'

EXEC sp_AddCauHinh N'Itel L6006', N'Màn hình', N'IPS LCD, 6.1", HD+'
EXEC sp_AddCauHinh N'Itel L6006', N'Hệ điều hành', N'Android 10 (Go Edition)'
EXEC sp_AddCauHinh N'Itel L6006', N'Camera sau', N'Chính 5 MP & Phụ VGA'
EXEC sp_AddCauHinh N'Itel L6006', N'Camera trước', N'5 MP'
EXEC sp_AddCauHinh N'Itel L6006', N'Chip', N'Spreadtrum SC9832E'
EXEC sp_AddCauHinh N'Itel L6006', N'RAM', N'2 GB'
EXEC sp_AddCauHinh N'Itel L6006', N'Bộ nhớ trong', N'32 GB'
EXEC sp_AddCauHinh N'Itel L6006', N'SIM', N'2 Micro SIM, Hỗ trợ 4G'
EXEC sp_AddCauHinh N'Itel L6006', N'Pin, Sạc', N'3000 mAh, 5 W'

EXEC sp_AddCauHinh N'Mobell M729', N'Màn hình', N'TFT LCD, 2.4", 65.536 màu'
EXEC sp_AddCauHinh N'Mobell M729', N'Camera sau', N'0.3 MP'
EXEC sp_AddCauHinh N'Mobell M729', N'SIM', N'2 SIM thường, Hỗ trợ 2G'
EXEC sp_AddCauHinh N'Mobell M729', N'Pin', N'1000 mAh'
EXEC sp_AddCauHinh N'Mobell M729', N'Danh bạ', N'300 số'
EXEC sp_AddCauHinh N'Mobell M729', N'Thẻ nhớ', N'MicroSD, hỗ trợ tối đa 16 GB'
EXEC sp_AddCauHinh N'Mobell M729', N'Radio FM', N'Có'
EXEC sp_AddCauHinh N'Mobell M729', N'Jack cắm tai nghe', N'Micro USB'

EXEC sp_AddCauHinh N'Mobell C310', N'Màn hình', N'TFT LCD, 1.77", 262.000 màu'
EXEC sp_AddCauHinh N'Mobell C310', N'Camera sau', N'0.8 MP'
EXEC sp_AddCauHinh N'Mobell C310', N'SIM', N'2 SIM thường, Hỗ trợ 2G'
EXEC sp_AddCauHinh N'Mobell C310', N'Pin', N'800 mAh'
EXEC sp_AddCauHinh N'Mobell C310', N'Danh bạ', N'500 số'
EXEC sp_AddCauHinh N'Mobell C310', N'Thẻ nhớ', N'MicroSD, hỗ trợ tối đa 32 GB'
EXEC sp_AddCauHinh N'Mobell C310', N'Radio FM', N'Có'
EXEC sp_AddCauHinh N'Mobell C310', N'Jack cắm tai nghe', N'3.5 mm'

EXEC sp_AddCauHinh N'Mobell Rock 3', N'Màn hình', N'TFT LCD, 2.4", 65.536 màu'
EXEC sp_AddCauHinh N'Mobell Rock 3', N'Camera sau', N'0.08 MP'
EXEC sp_AddCauHinh N'Mobell Rock 3', N'SIM', N'1 Micro SIM & 1 SIM thường, Hỗ trợ 2G'
EXEC sp_AddCauHinh N'Mobell Rock 3', N'Pin', N'5000 mAh'
EXEC sp_AddCauHinh N'Mobell Rock 3', N'Danh bạ', N'200 số'
EXEC sp_AddCauHinh N'Mobell Rock 3', N'Thẻ nhớ', N'MicroSD, hỗ trợ tối đa 8 GB'
EXEC sp_AddCauHinh N'Mobell Rock 3', N'Radio FM', N'Có'
EXEC sp_AddCauHinh N'Mobell Rock 3', N'Jack cắm tai nghe', N'Micro USB'

EXEC sp_AddCauHinh N'Mobell P41', N'Màn hình', N'IPS LCD, 5.5", FWVGA+'
EXEC sp_AddCauHinh N'Mobell P41', N'Hệ điều hành', N'Android 8 (Oreo)'
EXEC sp_AddCauHinh N'Mobell P41', N'Camera sau', N'5 MP'
EXEC sp_AddCauHinh N'Mobell P41', N'Camera trước', N'2 MP'
EXEC sp_AddCauHinh N'Mobell P41', N'Chip', N'MediaTek MT6580A'
EXEC sp_AddCauHinh N'Mobell P41', N'RAM', N'1 GB'
EXEC sp_AddCauHinh N'Mobell P41', N'Bộ nhớ trong', N'8 GB'
EXEC sp_AddCauHinh N'Mobell P41', N'SIM', N'2 Nano SIM, Hỗ trợ 3G'
EXEC sp_AddCauHinh N'Mobell P41', N'Pin, Sạc', N'3500 mAh, 5 W'

EXEC sp_AddCauHinh N'Nokia 6300 4G', N'Màn hình', N'TFT LCD, 2.4", 16 triệu màu'
EXEC sp_AddCauHinh N'Nokia 6300 4G', N'Camera sau', N'VGA (480 x 640 pixels)'
EXEC sp_AddCauHinh N'Nokia 6300 4G', N'SIM', N'2 Nano SIM, Hỗ trợ 4G'
EXEC sp_AddCauHinh N'Nokia 6300 4G', N'Pin', N'1500 mAh'
EXEC sp_AddCauHinh N'Nokia 6300 4G', N'Danh bạ', N'1500 số'
EXEC sp_AddCauHinh N'Nokia 6300 4G', N'Thẻ nhớ', N'MicroSD, hỗ trợ tối đa 32 GB'
EXEC sp_AddCauHinh N'Nokia 6300 4G', N'Radio FM', N'Có'
EXEC sp_AddCauHinh N'Nokia 6300 4G', N'Jack cắm tai nghe', N'3.5 mm'

EXEC sp_AddCauHinh N'Nokia 210', N'Màn hình', N'TFT LCD, 2.4", 65.536 màu'
EXEC sp_AddCauHinh N'Nokia 210', N'Camera sau', N'0.3 MP'
EXEC sp_AddCauHinh N'Nokia 210', N'SIM', N'2 SIM thường, Hỗ trợ 2G'
EXEC sp_AddCauHinh N'Nokia 210', N'Pin', N'1020 mAh'
EXEC sp_AddCauHinh N'Nokia 210', N'Danh bạ', N'500 số'
EXEC sp_AddCauHinh N'Nokia 210', N'Thẻ nhớ', N'MicroSD, hỗ trợ tối đa 32 GB'
EXEC sp_AddCauHinh N'Nokia 210', N'Radio FM', N'Có'
EXEC sp_AddCauHinh N'Nokia 210', N'Jack cắm tai nghe', N'3.5 mm'

EXEC sp_AddCauHinh N'Nokia C30', N'Màn hình', N'IPS LCD, 6.82", HD+'
EXEC sp_AddCauHinh N'Nokia C30', N'Hệ điều hành', N'Android 11 (Go Edition)'
EXEC sp_AddCauHinh N'Nokia C30', N'Camera sau', N'Chính 13 MP & Phụ 2 MP'
EXEC sp_AddCauHinh N'Nokia C30', N'Camera trước', N'5 MP'
EXEC sp_AddCauHinh N'Nokia C30', N'Chip', N'Spreadtrum SC9863A'
EXEC sp_AddCauHinh N'Nokia C30', N'RAM', N'3 GB'
EXEC sp_AddCauHinh N'Nokia C30', N'Bộ nhớ trong', N'32 GB'
EXEC sp_AddCauHinh N'Nokia C30', N'SIM', N'2 Nano SIM, Hỗ trợ 4G'
EXEC sp_AddCauHinh N'Nokia C30', N'Pin, Sạc', N'6000 mAh, 10 W'

EXEC sp_AddCauHinh N'Nokia 3.4', N'Màn hình', N'IPS LCD, 6.39", HD+'
EXEC sp_AddCauHinh N'Nokia 3.4', N'Hệ điều hành', N'Android 10 (Android One)'
EXEC sp_AddCauHinh N'Nokia 3.4', N'Camera sau', N'Chính 13 MP & Phụ 5 MP, 2 MP'
EXEC sp_AddCauHinh N'Nokia 3.4', N'Camera trước', N'8 MP'
EXEC sp_AddCauHinh N'Nokia 3.4', N'Chip', N'Snapdragon 460'
EXEC sp_AddCauHinh N'Nokia 3.4', N'RAM', N'4 GB'
EXEC sp_AddCauHinh N'Nokia 3.4', N'Bộ nhớ trong', N'64 GB'
EXEC sp_AddCauHinh N'Nokia 3.4', N'SIM', N'2 Nano SIM, Hỗ trợ 4G'
EXEC sp_AddCauHinh N'Nokia 3.4', N'Pin, Sạc', N'4000 mAh, 10 W'

EXEC sp_AddCauHinh N'Realme 6 Pro', N'Màn hình', N'IPS LCD, 6.6", Full HD+'
EXEC sp_AddCauHinh N'Realme 6 Pro', N'Hệ điều hành', N'Android 10'
EXEC sp_AddCauHinh N'Realme 6 Pro', N'Camera sau', N'Chính 64 MP & Phụ 12 MP, 8 MP, 2 MP'
EXEC sp_AddCauHinh N'Realme 6 Pro', N'Camera trước', N'Chính 16 MP & Phụ 8 MP'
EXEC sp_AddCauHinh N'Realme 6 Pro', N'Chip', N'Snapdragon 720G'
EXEC sp_AddCauHinh N'Realme 6 Pro', N'RAM', N'8 GB'
EXEC sp_AddCauHinh N'Realme 6 Pro', N'Bộ nhớ trong', N'128 GB'
EXEC sp_AddCauHinh N'Realme 6 Pro', N'SIM', N'2 Nano SIM, Hỗ trợ 4G'
EXEC sp_AddCauHinh N'Realme 6 Pro', N'Pin, Sạc', N'4300 mAh, 30 W'

EXEC sp_AddCauHinh N'Realme 8 Pro Vàng Rực Rỡ', N'Màn hình', N'Super AMOLED, 6.4", Full HD+'
EXEC sp_AddCauHinh N'Realme 8 Pro Vàng Rực Rỡ', N'Hệ điều hành', N'Android 11'
EXEC sp_AddCauHinh N'Realme 8 Pro Vàng Rực Rỡ', N'Camera sau', N'Chính 108 MP & Phụ 8 MP, 2 MP, 2 MP'
EXEC sp_AddCauHinh N'Realme 8 Pro Vàng Rực Rỡ', N'Camera trước', N'16 MP'
EXEC sp_AddCauHinh N'Realme 8 Pro Vàng Rực Rỡ', N'Chip', N'Snapdragon 720G'
EXEC sp_AddCauHinh N'Realme 8 Pro Vàng Rực Rỡ', N'RAM', N'8 GB'
EXEC sp_AddCauHinh N'Realme 8 Pro Vàng Rực Rỡ', N'Bộ nhớ trong', N'128 GB'
EXEC sp_AddCauHinh N'Realme 8 Pro Vàng Rực Rỡ', N'SIM', N'2 Nano SIM, Hỗ trợ 4G'
EXEC sp_AddCauHinh N'Realme 8 Pro Vàng Rực Rỡ', N'Pin, Sạc', N'4500 mAh, 50 W'

EXEC sp_AddCauHinh N'Realme 7 Pro', N'Màn hình', N'Super AMOLED, 6.4", Full HD+'
EXEC sp_AddCauHinh N'Realme 7 Pro', N'Hệ điều hành', N'Android 10'
EXEC sp_AddCauHinh N'Realme 7 Pro', N'Camera sau', N'Chính 64 MP & Phụ 8 MP, 2 MP, 2 MP'
EXEC sp_AddCauHinh N'Realme 7 Pro', N'Camera trước', N'32 MP'
EXEC sp_AddCauHinh N'Realme 7 Pro', N'Chip', N'Snapdragon 720G'
EXEC sp_AddCauHinh N'Realme 7 Pro', N'RAM', N'8 GB'
EXEC sp_AddCauHinh N'Realme 7 Pro', N'Bộ nhớ trong', N'128 GB'
EXEC sp_AddCauHinh N'Realme 7 Pro', N'SIM', N'2 Nano SIM, Hỗ trợ 4G'
EXEC sp_AddCauHinh N'Realme 7 Pro', N'Pin, Sạc', N'4500 mAh, 65 W'

EXEC sp_AddCauHinh N'Realme C21Y 4GB', N'Màn hình', N'IPS LCD, 6.5", HD+'
EXEC sp_AddCauHinh N'Realme C21Y 4GB', N'Hệ điều hành', N'Android 11'
EXEC sp_AddCauHinh N'Realme C21Y 4GB', N'Camera sau', N'Chính 13 MP & Phụ 2 MP, 2 MP'
EXEC sp_AddCauHinh N'Realme C21Y 4GB', N'Camera trước', N'5 MP'
EXEC sp_AddCauHinh N'Realme C21Y 4GB', N'Chip', N'Spreadtrum T610 8 nhân'
EXEC sp_AddCauHinh N'Realme C21Y 4GB', N'RAM', N'4 GB'
EXEC sp_AddCauHinh N'Realme C21Y 4GB', N'Bộ nhớ trong', N'64 GB'
EXEC sp_AddCauHinh N'Realme C21Y 4GB', N'SIM', N'2 Nano SIM, Hỗ trợ 4G'
EXEC sp_AddCauHinh N'Realme C21Y 4GB', N'Pin, Sạc', N'5000 mAh, 10 W'

EXEC sp_AddCauHinh N'iPhone 12 64GB', N'Màn hình', N'OLED, 6.1", Super Retina XDR'
EXEC sp_AddCauHinh N'iPhone 12 64GB', N'Hệ điều hành', N'iOS 14'
EXEC sp_AddCauHinh N'iPhone 12 64GB', N'Camera sau', N'2 camera 12 MP'
EXEC sp_AddCauHinh N'iPhone 12 64GB', N'Camera trước', N'12 MP'
EXEC sp_AddCauHinh N'iPhone 12 64GB', N'Chip', N'Apple A14 Bionic'
EXEC sp_AddCauHinh N'iPhone 12 64GB', N'RAM', N'4 GB'
EXEC sp_AddCauHinh N'iPhone 12 64GB', N'Bộ nhớ trong', N'64 GB'
EXEC sp_AddCauHinh N'iPhone 12 64GB', N'SIM', N'1 Nano SIM & 1 eSIM, Hỗ trợ 5G'
EXEC sp_AddCauHinh N'iPhone 12 64GB', N'Pin, Sạc', N'2815 mAh, 20 W'

EXEC sp_AddCauHinh N'iPhone 13 Pro Max 1TB', N'Màn hình', N'OLED, 6.7", Super Retina XDR'
EXEC sp_AddCauHinh N'iPhone 13 Pro Max 1TB', N'Hệ điều hành', N'iOS 15'
EXEC sp_AddCauHinh N'iPhone 13 Pro Max 1TB', N'Camera sau', N'3 camera 12 MP'
EXEC sp_AddCauHinh N'iPhone 13 Pro Max 1TB', N'Camera trước', N'12 MP'
EXEC sp_AddCauHinh N'iPhone 13 Pro Max 1TB', N'Chip', N'Apple A15 Bionic'
EXEC sp_AddCauHinh N'iPhone 13 Pro Max 1TB', N'RAM', N'6 GB'
EXEC sp_AddCauHinh N'iPhone 13 Pro Max 1TB', N'Bộ nhớ trong', N'1 TB'
EXEC sp_AddCauHinh N'iPhone 13 Pro Max 1TB', N'SIM', N'1 Nano SIM & 1 eSIM, Hỗ trợ 5G'
EXEC sp_AddCauHinh N'iPhone 13 Pro Max 1TB', N'Pin, Sạc', N'20 W'

EXEC sp_AddCauHinh N'iPhone 13 Pro 1TB', N'Màn hình', N'OLED, 6.1", Super Retina XDR'
EXEC sp_AddCauHinh N'iPhone 13 Pro 1TB', N'Hệ điều hành', N'iOS 15'
EXEC sp_AddCauHinh N'iPhone 13 Pro 1TB', N'Camera sau', N'3 camera 12 MP'
EXEC sp_AddCauHinh N'iPhone 13 Pro 1TB', N'Camera trước', N'12 MP'
EXEC sp_AddCauHinh N'iPhone 13 Pro 1TB', N'Chip', N'Apple A15 Bionic'
EXEC sp_AddCauHinh N'iPhone 13 Pro 1TB', N'RAM', N'6 GB'
EXEC sp_AddCauHinh N'iPhone 13 Pro 1TB', N'Bộ nhớ trong', N'1 TB'
EXEC sp_AddCauHinh N'iPhone 13 Pro 1TB', N'SIM', N'1 Nano SIM & 1 eSIM, Hỗ trợ 5G'
EXEC sp_AddCauHinh N'iPhone 13 Pro 1TB', N'Pin, Sạc', N'20 W'

EXEC sp_AddCauHinh N'iPhone 13 Pro Max 512GB', N'Màn hình', N'OLED, 6.7", Super Retina XDR'
EXEC sp_AddCauHinh N'iPhone 13 Pro Max 512GB', N'Hệ điều hành', N'iOS 15'
EXEC sp_AddCauHinh N'iPhone 13 Pro Max 512GB', N'Camera sau', N'3 camera 12 MP'
EXEC sp_AddCauHinh N'iPhone 13 Pro Max 512GB', N'Camera trước', N'12 MP'
EXEC sp_AddCauHinh N'iPhone 13 Pro Max 512GB', N'Chip', N'Apple A15 Bionic'
EXEC sp_AddCauHinh N'iPhone 13 Pro Max 512GB', N'RAM', N'6 GB'
EXEC sp_AddCauHinh N'iPhone 13 Pro Max 512GB', N'Bộ nhớ trong', N'512 GB'
EXEC sp_AddCauHinh N'iPhone 13 Pro Max 512GB', N'SIM', N'1 Nano SIM & 1 eSIM, Hỗ trợ 5G'
EXEC sp_AddCauHinh N'iPhone 13 Pro Max 512GB', N'Pin, Sạc', N'20 W'

EXEC sp_AddCauHinh N'iPhone 13 Pro 512GB', N'Màn hình', N'OLED, 6.1", Super Retina XDR'
EXEC sp_AddCauHinh N'iPhone 13 Pro 512GB', N'Hệ điều hành', N'iOS 15'
EXEC sp_AddCauHinh N'iPhone 13 Pro 512GB', N'Camera sau', N'3 camera 12 MP'
EXEC sp_AddCauHinh N'iPhone 13 Pro 512GB', N'Camera trước', N'12 MP'
EXEC sp_AddCauHinh N'iPhone 13 Pro 512GB', N'Chip', N'Apple A15 Bionic'
EXEC sp_AddCauHinh N'iPhone 13 Pro 512GB', N'RAM', N'6 GB'
EXEC sp_AddCauHinh N'iPhone 13 Pro 512GB', N'Bộ nhớ trong', N'512 GB'
EXEC sp_AddCauHinh N'iPhone 13 Pro 512GB', N'SIM', N'1 Nano SIM & 1 eSIM, Hỗ trợ 5G'
EXEC sp_AddCauHinh N'iPhone 13 Pro 512GB', N'Pin, Sạc', N'20 W'

EXEC sp_AddCauHinh N'iPhone 12 Pro Max 512GB', N'Màn hình', N'OLED, 6.7", Super Retina XDR'
EXEC sp_AddCauHinh N'iPhone 12 Pro Max 512GB', N'Hệ điều hành', N'iOS 14'
EXEC sp_AddCauHinh N'iPhone 12 Pro Max 512GB', N'Camera sau', N'3 camera 12 MP'
EXEC sp_AddCauHinh N'iPhone 12 Pro Max 512GB', N'Camera trước', N'12 MP'
EXEC sp_AddCauHinh N'iPhone 12 Pro Max 512GB', N'Chip', N'Apple A14 Bionic'
EXEC sp_AddCauHinh N'iPhone 12 Pro Max 512GB', N'RAM', N'6 GB'
EXEC sp_AddCauHinh N'iPhone 12 Pro Max 512GB', N'Bộ nhớ trong', N'512 GB'
EXEC sp_AddCauHinh N'iPhone 12 Pro Max 512GB', N'SIM', N'1 Nano SIM & 1 eSIM, Hỗ trợ 5G'
EXEC sp_AddCauHinh N'iPhone 12 Pro Max 512GB', N'Pin, Sạc', N'3687 mAh, 20 W'

EXEC sp_AddCauHinh N'iPhone 13 mini 256GB', N'Màn hình', N'OLED, 5.4", Super Retina XDR'
EXEC sp_AddCauHinh N'iPhone 13 mini 256GB', N'Hệ điều hành', N'iOS 15'
EXEC sp_AddCauHinh N'iPhone 13 mini 256GB', N'Camera sau', N'2 camera 12 MP'
EXEC sp_AddCauHinh N'iPhone 13 mini 256GB', N'Camera trước', N'12 MP'
EXEC sp_AddCauHinh N'iPhone 13 mini 256GB', N'Chip', N'Apple A15 Bionic'
EXEC sp_AddCauHinh N'iPhone 13 mini 256GB', N'RAM', N'4 GB'
EXEC sp_AddCauHinh N'iPhone 13 mini 256GB', N'Bộ nhớ trong', N'256 GB'
EXEC sp_AddCauHinh N'iPhone 13 mini 256GB', N'SIM', N'1 Nano SIM & 1 eSIM, Hỗ trợ 5G'
EXEC sp_AddCauHinh N'iPhone 13 mini 256GB', N'Pin, Sạc', N'2438 mAh, 20 W'

EXEC sp_AddCauHinh N'iPhone 11 128GB', N'Màn hình', N'IPS LCD, 6.1", Liquid Retina'
EXEC sp_AddCauHinh N'iPhone 11 128GB', N'Hệ điều hành', N'iOS 14'
EXEC sp_AddCauHinh N'iPhone 11 128GB', N'Camera sau', N'2 camera 12 MP'
EXEC sp_AddCauHinh N'iPhone 11 128GB', N'Camera trước', N'12 MP'
EXEC sp_AddCauHinh N'iPhone 11 128GB', N'Chip', N'Apple A13 Bionic'
EXEC sp_AddCauHinh N'iPhone 11 128GB', N'RAM', N'4 GB'
EXEC sp_AddCauHinh N'iPhone 11 128GB', N'Bộ nhớ trong', N'128 GB'
EXEC sp_AddCauHinh N'iPhone 11 128GB', N'SIM', N'1 Nano SIM & 1 eSIM, Hỗ trợ 4G'
EXEC sp_AddCauHinh N'iPhone 11 128GB', N'Pin, Sạc', N'3110 mAh, 18 W'

EXEC sp_AddCauHinh N'iPhone XR 128GB', N'Màn hình', N'IPS LCD, 6.1", Liquid Retina'
EXEC sp_AddCauHinh N'iPhone XR 128GB', N'Hệ điều hành', N'iOS 14'
EXEC sp_AddCauHinh N'iPhone XR 128GB', N'Camera sau', N'12 MP'
EXEC sp_AddCauHinh N'iPhone XR 128GB', N'Camera trước', N'7 MP'
EXEC sp_AddCauHinh N'iPhone XR 128GB', N'Chip', N'Apple A12 Bionic'
EXEC sp_AddCauHinh N'iPhone XR 128GB', N'RAM', N'3 GB'
EXEC sp_AddCauHinh N'iPhone XR 128GB', N'Bộ nhớ trong', N'128 GB'
EXEC sp_AddCauHinh N'iPhone XR 128GB', N'SIM', N'1 Nano SIM & 1 eSIM, Hỗ trợ 4G'
EXEC sp_AddCauHinh N'iPhone XR 128GB', N'Pin, Sạc', N'2942 mAh, 15 W'

EXEC sp_AddCauHinh N'Samsung Galaxy Z Fold3 5G 512GB', N'Màn hình', N'Dynamic AMOLED 2X, Chính 7.6" & Phụ 6.2", Full HD+'
EXEC sp_AddCauHinh N'Samsung Galaxy Z Fold3 5G 512GB', N'Hệ điều hành', N'Android 11'
EXEC sp_AddCauHinh N'Samsung Galaxy Z Fold3 5G 512GB', N'Camera sau', N'3 camera 12 MP'
EXEC sp_AddCauHinh N'Samsung Galaxy Z Fold3 5G 512GB', N'Camera trước', N'10 MP & 4 MP'
EXEC sp_AddCauHinh N'Samsung Galaxy Z Fold3 5G 512GB', N'Chip', N'Snapdragon 888'
EXEC sp_AddCauHinh N'Samsung Galaxy Z Fold3 5G 512GB', N'RAM', N'12 GB'
EXEC sp_AddCauHinh N'Samsung Galaxy Z Fold3 5G 512GB', N'Bộ nhớ trong', N'512 GB'
EXEC sp_AddCauHinh N'Samsung Galaxy Z Fold3 5G 512GB', N'SIM', N'2 Nano SIM, Hỗ trợ 5G'
EXEC sp_AddCauHinh N'Samsung Galaxy Z Fold3 5G 512GB', N'Pin, Sạc', N'4400 mAh, 25 W'

EXEC sp_AddCauHinh N'Samsung Galaxy A03s', N'Màn hình', N'PLS LCD, 6.5", HD+'
EXEC sp_AddCauHinh N'Samsung Galaxy A03s', N'Hệ điều hành', N'Android 11'
EXEC sp_AddCauHinh N'Samsung Galaxy A03s', N'Camera sau', N'Chính 13 MP & Phụ 2 MP, 2 MP'
EXEC sp_AddCauHinh N'Samsung Galaxy A03s', N'Camera trước', N'5 MP'
EXEC sp_AddCauHinh N'Samsung Galaxy A03s', N'Chip', N'MediaTek MT6765'
EXEC sp_AddCauHinh N'Samsung Galaxy A03s', N'RAM', N'4 GB'
EXEC sp_AddCauHinh N'Samsung Galaxy A03s', N'Bộ nhớ trong', N'64 GB'
EXEC sp_AddCauHinh N'Samsung Galaxy A03s', N'SIM', N'2 Nano SIM, Hỗ trợ 4G'
EXEC sp_AddCauHinh N'Samsung Galaxy A03s', N'Pin, Sạc', N'5000 mAh, 7.75 W'

EXEC sp_AddCauHinh N'Samsung Galaxy M51', N'Màn hình', N'Super AMOLED Plus, 6.7", Full HD+'
EXEC sp_AddCauHinh N'Samsung Galaxy M51', N'Hệ điều hành', N'Android 10'
EXEC sp_AddCauHinh N'Samsung Galaxy M51', N'Camera sau', N'Chính 64 MP & Phụ 12 MP, 5 MP, 5 MP'
EXEC sp_AddCauHinh N'Samsung Galaxy M51', N'Camera trước', N'32 MP'
EXEC sp_AddCauHinh N'Samsung Galaxy M51', N'Chip', N'Snapdragon 730'
EXEC sp_AddCauHinh N'Samsung Galaxy M51', N'RAM', N'8 GB'
EXEC sp_AddCauHinh N'Samsung Galaxy M51', N'Bộ nhớ trong', N'128 GB'
EXEC sp_AddCauHinh N'Samsung Galaxy M51', N'SIM', N'2 Nano SIM, Hỗ trợ 4G'
EXEC sp_AddCauHinh N'Samsung Galaxy M51', N'Pin, Sạc', N'7000 mAh, 25 W'

EXEC sp_AddCauHinh N'Samsung Galaxy Z Flip3 5G 256GB', N'Màn hình', N'Dynamic AMOLED 2X, Chính 6.7" & Phụ 1.9", Full HD+'
EXEC sp_AddCauHinh N'Samsung Galaxy Z Flip3 5G 256GB', N'Hệ điều hành', N'Android 11'
EXEC sp_AddCauHinh N'Samsung Galaxy Z Flip3 5G 256GB', N'Camera sau', N'2 camera 12 MP'
EXEC sp_AddCauHinh N'Samsung Galaxy Z Flip3 5G 256GB', N'Camera trước', N'10 MP'
EXEC sp_AddCauHinh N'Samsung Galaxy Z Flip3 5G 256GB', N'Chip', N'Snapdragon 888'
EXEC sp_AddCauHinh N'Samsung Galaxy Z Flip3 5G 256GB', N'RAM', N'8 GB'
EXEC sp_AddCauHinh N'Samsung Galaxy Z Flip3 5G 256GB', N'Bộ nhớ trong', N'256 GB'
EXEC sp_AddCauHinh N'Samsung Galaxy Z Flip3 5G 256GB', N'SIM', N'1 Nano SIM & 1 eSIM, Hỗ trợ 5G'
EXEC sp_AddCauHinh N'Samsung Galaxy Z Flip3 5G 256GB', N'Pin, Sạc', N'3300 mAh, 15 W'

EXEC sp_AddCauHinh N'OPPO Reno6 Z 5G', N'Màn hình', N'AMOLED, 6.43", Full HD+'
EXEC sp_AddCauHinh N'OPPO Reno6 Z 5G', N'Hệ điều hành', N'Android 11'
EXEC sp_AddCauHinh N'OPPO Reno6 Z 5G', N'Camera sau', N'Chính 64 MP & Phụ 8 MP, 2 MP'
EXEC sp_AddCauHinh N'OPPO Reno6 Z 5G', N'Camera trước', N'32 MP'
EXEC sp_AddCauHinh N'OPPO Reno6 Z 5G', N'Chip', N'MediaTek Dimensity 800U 5G'
EXEC sp_AddCauHinh N'OPPO Reno6 Z 5G', N'RAM', N'8 GB'
EXEC sp_AddCauHinh N'OPPO Reno6 Z 5G', N'Bộ nhớ trong', N'128 GB'
EXEC sp_AddCauHinh N'OPPO Reno6 Z 5G', N'SIM', N'2 Nano SIM, Hỗ trợ 5G'
EXEC sp_AddCauHinh N'OPPO Reno6 Z 5G', N'Pin, Sạc', N'4310 mAh, 30 W'

EXEC sp_AddCauHinh N'OPPO A74', N'Màn hình', N'AMOLED, 6.43", Full HD+'
EXEC sp_AddCauHinh N'OPPO A74', N'Hệ điều hành', N'Android 11'
EXEC sp_AddCauHinh N'OPPO A74', N'Camera sau', N'Chính 48 MP & Phụ 2 MP, 2 MP'
EXEC sp_AddCauHinh N'OPPO A74', N'Camera trước', N'16 MP'
EXEC sp_AddCauHinh N'OPPO A74', N'Chip', N'Snapdragon 662'
EXEC sp_AddCauHinh N'OPPO A74', N'RAM', N'8 GB'
EXEC sp_AddCauHinh N'OPPO A74', N'Bộ nhớ trong', N'128 GB'
EXEC sp_AddCauHinh N'OPPO A74', N'SIM', N'2 Nano SIM, Hỗ trợ 4G'
EXEC sp_AddCauHinh N'OPPO A74', N'Pin, Sạc', N'5000 mAh, 33 W'

EXEC sp_AddCauHinh N'OPPO A55', N'Màn hình', N'IPS LCD, 6.5", HD+'
EXEC sp_AddCauHinh N'OPPO A55', N'Hệ điều hành', N'Android 11'
EXEC sp_AddCauHinh N'OPPO A55', N'Camera sau', N'Chính 50 MP & Phụ 2 MP, 2 MP'
EXEC sp_AddCauHinh N'OPPO A55', N'Camera trước', N'16 MP'
EXEC sp_AddCauHinh N'OPPO A55', N'Chip', N'MediaTek Helio G35'
EXEC sp_AddCauHinh N'OPPO A55', N'RAM', N'4 GB'
EXEC sp_AddCauHinh N'OPPO A55', N'Bộ nhớ trong', N'64 GB'
EXEC sp_AddCauHinh N'OPPO A55', N'SIM', N'2 Nano SIM, Hỗ trợ 4G'
EXEC sp_AddCauHinh N'OPPO A55', N'Pin, Sạc', N'5000 mAh, 18 W'

EXEC sp_AddCauHinh N'OPPO Reno5 Marvel', N'Màn hình', N'AMOLED, 6.43", HD+'
EXEC sp_AddCauHinh N'OPPO Reno5 Marvel', N'Hệ điều hành', N'Android 11'
EXEC sp_AddCauHinh N'OPPO Reno5 Marvel', N'Camera sau', N'Chính 64 MP & Phụ 8 MP, 2 MP, 2 MP'
EXEC sp_AddCauHinh N'OPPO Reno5 Marvel', N'Camera trước', N'44 MP'
EXEC sp_AddCauHinh N'OPPO Reno5 Marvel', N'Chip', N'Snapdragon 720G'
EXEC sp_AddCauHinh N'OPPO Reno5 Marvel', N'RAM', N'8 GB'
EXEC sp_AddCauHinh N'OPPO Reno5 Marvel', N'Bộ nhớ trong', N'128 GB'
EXEC sp_AddCauHinh N'OPPO Reno5 Marvel', N'SIM', N'2 Nano SIM, Hỗ trợ 4G'
EXEC sp_AddCauHinh N'OPPO Reno5 Marvel', N'Pin, Sạc', N'4310 mAh, 50 W'

EXEC sp_AddCauHinh N'Vivo Y21', N'Màn hình', N'IPS LCD, 6.51", HD+'
EXEC sp_AddCauHinh N'Vivo Y21', N'Hệ điều hành', N'Android 11'
EXEC sp_AddCauHinh N'Vivo Y21', N'Camera sau', N'Chính 13 MP & Phụ 2 MP'
EXEC sp_AddCauHinh N'Vivo Y21', N'Camera trước', N'8 MP'
EXEC sp_AddCauHinh N'Vivo Y21', N'Chip', N'MediaTek Helio P35'
EXEC sp_AddCauHinh N'Vivo Y21', N'RAM', N'4 GB'
EXEC sp_AddCauHinh N'Vivo Y21', N'Bộ nhớ trong', N'64 GB'
EXEC sp_AddCauHinh N'Vivo Y21', N'SIM', N'2 Nano SIM, Hỗ trợ 4G'
EXEC sp_AddCauHinh N'Vivo Y21', N'Pin, Sạc', N'5000 mAh, 18 W'

EXEC sp_AddCauHinh N'Vivo X70 Pro 5G', N'Màn hình', N'AMOLED, 6.56", Full HD+'
EXEC sp_AddCauHinh N'Vivo X70 Pro 5G', N'Hệ điều hành', N'Android 11'
EXEC sp_AddCauHinh N'Vivo X70 Pro 5G', N'Camera sau', N'Chính 50 MP & Phụ 12 MP, 12 MP, 8 MP'
EXEC sp_AddCauHinh N'Vivo X70 Pro 5G', N'Camera trước', N'32 MP'
EXEC sp_AddCauHinh N'Vivo X70 Pro 5G', N'Chip', N'MediaTek Dimensity 1200'
EXEC sp_AddCauHinh N'Vivo X70 Pro 5G', N'RAM', N'12 GB'
EXEC sp_AddCauHinh N'Vivo X70 Pro 5G', N'Bộ nhớ trong', N'256 GB'
EXEC sp_AddCauHinh N'Vivo X70 Pro 5G', N'SIM', N'2 Nano SIM, Hỗ trợ 5G'
EXEC sp_AddCauHinh N'Vivo X70 Pro 5G', N'Pin, Sạc', N'4450 mAh, 44 W'

EXEC sp_AddCauHinh N'Vivo Y72 5G', N'Màn hình', N'IPS LCD, 6.58", Full HD+'
EXEC sp_AddCauHinh N'Vivo Y72 5G', N'Hệ điều hành', N'Android 11'
EXEC sp_AddCauHinh N'Vivo Y72 5G', N'Camera sau', N'Chính 64 MP & Phụ 8 MP, 2 MP'
EXEC sp_AddCauHinh N'Vivo Y72 5G', N'Camera trước', N'16 MP'
EXEC sp_AddCauHinh N'Vivo Y72 5G', N'Chip', N'MediaTek Dimensity 700'
EXEC sp_AddCauHinh N'Vivo Y72 5G', N'RAM', N'8 GB'
EXEC sp_AddCauHinh N'Vivo Y72 5G', N'Bộ nhớ trong', N'128 GB'
EXEC sp_AddCauHinh N'Vivo Y72 5G', N'SIM', N'2 Nano SIM (SIM 2 chung khe thẻ nhớ), Hỗ trợ 5G'
EXEC sp_AddCauHinh N'Vivo Y72 5G', N'Pin, Sạc', N'5000 mAh, 18 W'

EXEC sp_AddCauHinh N'Vivo V20 SE', N'Màn hình', N'AMOLED, 6.44", Full HD+'
EXEC sp_AddCauHinh N'Vivo V20 SE', N'Hệ điều hành', N'Android 10'
EXEC sp_AddCauHinh N'Vivo V20 SE', N'Camera sau', N'Chính 48 MP & Phụ 8 MP, 2 MP'
EXEC sp_AddCauHinh N'Vivo V20 SE', N'Camera trước', N'32 MP'
EXEC sp_AddCauHinh N'Vivo V20 SE', N'Chip', N'Snapdragon 665'
EXEC sp_AddCauHinh N'Vivo V20 SE', N'RAM', N'8 GB'
EXEC sp_AddCauHinh N'Vivo V20 SE', N'Bộ nhớ trong', N'128 GB'
EXEC sp_AddCauHinh N'Vivo V20 SE', N'SIM', N'2 Nano SIM, Hỗ trợ 4G'
EXEC sp_AddCauHinh N'Vivo V20 SE', N'Pin, Sạc', N'4100 mAh, 33 W'

EXEC sp_AddCauHinh N'Xiaomi 11T 5G 256GB', N'Màn hình', N'AMOLED, 6.67", Full HD+'
EXEC sp_AddCauHinh N'Xiaomi 11T 5G 256GB', N'Hệ điều hành', N'Android 11'
EXEC sp_AddCauHinh N'Xiaomi 11T 5G 256GB', N'Camera sau', N'Chính 108 MP & Phụ 8 MP, 5 MP'
EXEC sp_AddCauHinh N'Xiaomi 11T 5G 256GB', N'Camera trước', N'16 MP'
EXEC sp_AddCauHinh N'Xiaomi 11T 5G 256GB', N'Chip', N'MediaTek Dimensity 1200'
EXEC sp_AddCauHinh N'Xiaomi 11T 5G 256GB', N'RAM', N'8 GB'
EXEC sp_AddCauHinh N'Xiaomi 11T 5G 256GB', N'Bộ nhớ trong', N'256 GB'
EXEC sp_AddCauHinh N'Xiaomi 11T 5G 256GB', N'SIM', N'2 Nano SIM, Hỗ trợ 5G'
EXEC sp_AddCauHinh N'Xiaomi 11T 5G 256GB', N'Pin, Sạc', N'5000 mAh, 67 W'

EXEC sp_AddCauHinh N'Xiaomi 11 Lite 5G NE', N'Màn hình', N'AMOLED, 6.55", Full HD+'
EXEC sp_AddCauHinh N'Xiaomi 11 Lite 5G NE', N'Hệ điều hành', N'Android 11'
EXEC sp_AddCauHinh N'Xiaomi 11 Lite 5G NE', N'Camera sau', N'Chính 64 MP & Phụ 8 MP, 5 MP'
EXEC sp_AddCauHinh N'Xiaomi 11 Lite 5G NE', N'Camera trước', N'20 MP'
EXEC sp_AddCauHinh N'Xiaomi 11 Lite 5G NE', N'Chip', N'Snapdragon 778G 5G 8 nhân'
EXEC sp_AddCauHinh N'Xiaomi 11 Lite 5G NE', N'RAM', N'8 GB'
EXEC sp_AddCauHinh N'Xiaomi 11 Lite 5G NE', N'Bộ nhớ trong', N'128 GB'
EXEC sp_AddCauHinh N'Xiaomi 11 Lite 5G NE', N'SIM', N'2 Nano SIM (SIM 2 chung khe thẻ nhớ), Hỗ trợ 5G'
EXEC sp_AddCauHinh N'Xiaomi 11 Lite 5G NE', N'Pin, Sạc', N'4250 mAh, 33 W'

EXEC sp_AddCauHinh N'Xiaomi Redmi Note 9', N'Màn hình', N'IPS LCD, 6.53", Full HD+'
EXEC sp_AddCauHinh N'Xiaomi Redmi Note 9', N'Hệ điều hành', N'Android 10'
EXEC sp_AddCauHinh N'Xiaomi Redmi Note 9', N'Camera sau', N'Chính 48 MP & Phụ 8 MP, 2 MP, 2 MP'
EXEC sp_AddCauHinh N'Xiaomi Redmi Note 9', N'Camera trước', N'13 MP'
EXEC sp_AddCauHinh N'Xiaomi Redmi Note 9', N'Chip', N'MediaTek Helio G85'
EXEC sp_AddCauHinh N'Xiaomi Redmi Note 9', N'RAM', N'4 GB'
EXEC sp_AddCauHinh N'Xiaomi Redmi Note 9', N'Bộ nhớ trong', N'128 GB'
EXEC sp_AddCauHinh N'Xiaomi Redmi Note 9', N'SIM', N'2 Nano SIM, Hỗ trợ 4G'
EXEC sp_AddCauHinh N'Xiaomi Redmi Note 9', N'Pin, Sạc', N'5020 mAh, 18 W'

EXEC sp_AddCauHinh N'Xiaomi Redmi Note 10S', N'Màn hình', N'AMOLED, 6.43", Full HD+'
EXEC sp_AddCauHinh N'Xiaomi Redmi Note 10S', N'Hệ điều hành', N'Android 11'
EXEC sp_AddCauHinh N'Xiaomi Redmi Note 10S', N'Camera sau', N'Chính 64 MP & Phụ 8 MP, 2 MP, 2 MP'
EXEC sp_AddCauHinh N'Xiaomi Redmi Note 10S', N'Camera trước', N'13 MP'
EXEC sp_AddCauHinh N'Xiaomi Redmi Note 10S', N'Chip', N'MediaTek Helio G95'
EXEC sp_AddCauHinh N'Xiaomi Redmi Note 10S', N'RAM', N'8 GB'
EXEC sp_AddCauHinh N'Xiaomi Redmi Note 10S', N'Bộ nhớ trong', N'128 GB'
EXEC sp_AddCauHinh N'Xiaomi Redmi Note 10S', N'SIM', N'2 Nano SIM, Hỗ trợ 4G'
EXEC sp_AddCauHinh N'Xiaomi Redmi Note 10S', N'Pin, Sạc', N'5000 mAh, 33 W'

--SẠC DỰ PHÒNG
EXEC sp_AddCauHinh N'Pin sạc dự phòng Polymer 10.000 mAh Type C Xiaomi Power Bank 3 Ultra Compact', N'Hiệu suất sạc', N'55%'
EXEC sp_AddCauHinh N'Pin sạc dự phòng Polymer 10.000 mAh Type C Xiaomi Power Bank 3 Ultra Compact', N'Dung lượng pin', N'10.000 mAh'
EXEC sp_AddCauHinh N'Pin sạc dự phòng Polymer 10.000 mAh Type C Xiaomi Power Bank 3 Ultra Compact', N'Thời gian sạc đầy pin', N'10 - 11 giờ (dùng Adapter 1A)6 - 8 giờ (dùng Adapter 2A)'
EXEC sp_AddCauHinh N'Pin sạc dự phòng Polymer 10.000 mAh Type C Xiaomi Power Bank 3 Ultra Compact', N'Nguồn vào', N'Type C: 5V - 3A, 9V - 2.5A, 12V - 1.85AMicro USB: 5V - 2A, 9V - 2A'
EXEC sp_AddCauHinh N'Pin sạc dự phòng Polymer 10.000 mAh Type C Xiaomi Power Bank 3 Ultra Compact', N'Nguồn ra', N'Type C: 5V - 3A, 9V - 2.5A, 12V - 1.85AUSB: 5V - 2.4A, 9V - 2.5A, 12V - 1.85A'
EXEC sp_AddCauHinh N'Pin sạc dự phòng Polymer 10.000 mAh Type C Xiaomi Power Bank 3 Ultra Compact', N'Lõi pin', N'Polymer'
EXEC sp_AddCauHinh N'Pin sạc dự phòng Polymer 10.000 mAh Type C Xiaomi Power Bank 3 Ultra Compact', N'Công nghệ/Tiện ích', N'Đèn LED báo hiệu Power Delivery'
EXEC sp_AddCauHinh N'Pin sạc dự phòng Polymer 10.000 mAh Type C Xiaomi Power Bank 3 Ultra Compact', N'Kích thước', N'Dài 9 cm - Rộng 6.5 cm - Dày 2.5 cm'
EXEC sp_AddCauHinh N'Pin sạc dự phòng Polymer 10.000 mAh Type C Xiaomi Power Bank 3 Ultra Compact', N'Trọng lượng', N'200 g'

EXEC sp_AddCauHinh N'Pin sạc dự phòng Polymer 10.000mAh Type C Fast Charge Xiaomi Mi Power Bank 3', N'Hiệu suất sạc', N'55%'
EXEC sp_AddCauHinh N'Pin sạc dự phòng Polymer 10.000mAh Type C Fast Charge Xiaomi Mi Power Bank 3 ', N'Dung lượng pin', N'10.000 mAh'
EXEC sp_AddCauHinh N'Pin sạc dự phòng Polymer 10.000mAh Type C Fast Charge Xiaomi Mi Power Bank 3 ', N'Thời gian sạc đầy pin', N'10 - 11 giờ (dùng Adapter 1A)3 - 4 giờ (dùng 9V/2A hoặc 12V/1.5A)5 - 6 giờ (dùng Adapter 2A)'
EXEC sp_AddCauHinh N'Pin sạc dự phòng Polymer 10.000mAh Type C Fast Charge Xiaomi Mi Power Bank 3 ', N'Nguồn vào', N'Micro USB/ Type C: 5V - 2.6A, 9V - 2.1A, 12V - 1.5A (18W MAX)'
EXEC sp_AddCauHinh N'Pin sạc dự phòng Polymer 10.000mAh Type C Fast Charge Xiaomi Mi Power Bank 3 ', N'Nguồn ra', N'USB: 5V - 2.6A, 9V - 2.1A, 12V - 1.5AUSB: 5V - 2.6A'
EXEC sp_AddCauHinh N'Pin sạc dự phòng Polymer 10.000mAh Type C Fast Charge Xiaomi Mi Power Bank 3 ', N'Lõi pin', N'Polymer'
EXEC sp_AddCauHinh N'Pin sạc dự phòng Polymer 10.000mAh Type C Fast Charge Xiaomi Mi Power Bank 3 ', N'Công nghệ/Tiện ích', N'Quick Charge 3.0. Đèn LED báo hiệu'
EXEC sp_AddCauHinh N'Pin sạc dự phòng Polymer 10.000mAh Type C Fast Charge Xiaomi Mi Power Bank 3 ', N'Kích thước', N'Dài 14.8cm - Rộng 7.4cm - Dày 1.5cm'
EXEC sp_AddCauHinh N'Pin sạc dự phòng Polymer 10.000mAh Type C Fast Charge Xiaomi Mi Power Bank 3 ', N'Trọng lượng', N'343g'

EXEC sp_AddCauHinh N'Pin sạc dự phòng Polymer 10.000 mAh Type C PD Samsung EB-P3300', N'Hiệu suất sạc', N'55%'
EXEC sp_AddCauHinh N'Pin sạc dự phòng Polymer 10.000 mAh Type C PD Samsung EB-P3300', N'Dung lượng pin', N'10.000 mAh'
EXEC sp_AddCauHinh N'Pin sạc dự phòng Polymer 10.000 mAh Type C PD Samsung EB-P3300', N'Thời gian sạc đầy pin', N'10 - 11 giờ (dùng Adapter 1A)6 - 8 giờ (dùng Adapter 2A)'
EXEC sp_AddCauHinh N'Pin sạc dự phòng Polymer 10.000 mAh Type C PD Samsung EB-P3300', N'Nguồn vào', N'Type C: 5V - 2A, 9V - 1.67A, 12V - 2.1A (Adaptive Fast Charging)Type C: 5V - 3A, 9V - 2.77A (Power Delivery)'
EXEC sp_AddCauHinh N'Pin sạc dự phòng Polymer 10.000 mAh Type C PD Samsung EB-P3300', N'Nguồn ra', N'USB: 5V - 2A, 9V - 1.7A, 12V - 2.1AType C: 5V - 2A, 9V - 2A, 12V - 2.1A'
EXEC sp_AddCauHinh N'Pin sạc dự phòng Polymer 10.000 mAh Type C PD Samsung EB-P3300', N'Lõi pin', N'Polymer'
EXEC sp_AddCauHinh N'Pin sạc dự phòng Polymer 10.000 mAh Type C PD Samsung EB-P3300', N'Công nghệ/Tiện ích', N'Super Fast Charging. Đèn LED báo hiệu Power Delivery'
EXEC sp_AddCauHinh N'Pin sạc dự phòng Polymer 10.000 mAh Type C PD Samsung EB-P3300', N'Kích thước', N'Dài 14 cm - Ngang 7 cm - Dày 1.3 cm'
EXEC sp_AddCauHinh N'Pin sạc dự phòng Polymer 10.000 mAh Type C PD Samsung EB-P3300', N'Trọng lượng', N'240 g'

EXEC sp_AddCauHinh N'Pin sạc dự phòng Polymer 20.000 mAh Type C PD Energizer UE20011PQ', N'Hiệu suất sạc', N'64%'
EXEC sp_AddCauHinh N'Pin sạc dự phòng Polymer 20.000 mAh Type C PD Energizer UE20011PQ', N'Dung lượng pin', N'20.000 mAh'
EXEC sp_AddCauHinh N'Pin sạc dự phòng Polymer 20.000 mAh Type C PD Energizer UE20011PQ', N'Thời gian sạc đầy pin', N'12 - 14 giờ (dùng Adapter 2A)'
EXEC sp_AddCauHinh N'Pin sạc dự phòng Polymer 20.000 mAh Type C PD Energizer UE20011PQ', N'Nguồn vào', N'Micro USB: 5V - 2AType-C: 5V - 2A, 9V - 2A'
EXEC sp_AddCauHinh N'Pin sạc dự phòng Polymer 20.000 mAh Type C PD Energizer UE20011PQ', N'Nguồn ra', N'Type C: 5V - 2A, 9V - 2A, 12V - 1.5AUSB: 5V - 4.5A, 9V - 2A, 12V - 1.5A'
EXEC sp_AddCauHinh N'Pin sạc dự phòng Polymer 20.000 mAh Type C PD Energizer UE20011PQ', N'Lõi pin', N'Polymer'
EXEC sp_AddCauHinh N'Pin sạc dự phòng Polymer 20.000 mAh Type C PD Energizer UE20011PQ', N'Công nghệ/Tiện ích', N'Auto Voltage Sensing Power Delivery'
EXEC sp_AddCauHinh N'Pin sạc dự phòng Polymer 20.000 mAh Type C PD Energizer UE20011PQ', N'Kích thước', N'Dài 14 cm - Rộng 6.9 cm - Dày 2.8 cm'
EXEC sp_AddCauHinh N'Pin sạc dự phòng Polymer 20.000 mAh Type C PD Energizer UE20011PQ', N'Trọng lượng', N'415 g'

-------------------------- IMEI NUMBER -------------------------------------
--SELECT * FROM IMEICODE
INSERT INTO IMEICODE (MA, ID_SP)
VALUES
('359159074600001', 'SP001'),
('359159074600002', 'SP001'),
('359159074600003', 'SP001'),
('359159074600004', 'SP001'),
('359159074600005', 'SP001'),
('359159074600006', 'SP001'),
('359159074600007', 'SP001'),
('359159074600008', 'SP001'),
('359159074600009', 'SP001'),
('359159074600010', 'SP001')
GO

INSERT INTO IMEICODE (MA, ID_SP)
VALUES
('359115074600001', 'SP002'),
('359115074600002', 'SP002'),
('359115074600003', 'SP002'),
('359115074600004', 'SP002'),
('359115074600005', 'SP002'),
('359115074600006', 'SP002'),
('359115074600007', 'SP002'),
('359115074600008', 'SP002'),
('359115074600009', 'SP002'),
('359115074600010', 'SP002')
GO

INSERT INTO IMEICODE (MA, ID_SP)
VALUES
('358996074600001', 'SP003'),
('358996074600002', 'SP003'),
('358996074600003', 'SP003'),
('358996074600004', 'SP003'),
('358996074600005', 'SP003'),
('358996074600006', 'SP003'),
('358996074600007', 'SP003'),
('358996074600008', 'SP003'),
('358996074600009', 'SP003'),
('358996074600010', 'SP003')
GO

INSERT INTO IMEICODE (MA, ID_SP)
VALUES
('359096724500001', 'SP004'),
('359096724500002', 'SP004'),
('359096724500003', 'SP004'),
('359096724500004', 'SP004'),
('359096724500005', 'SP004'),
('359096724500006', 'SP004'),
('359096724500007', 'SP004'),
('359096724500008', 'SP004'),
('359096724500009', 'SP004'),
('359096724500010', 'SP004')
GO

INSERT INTO IMEICODE (MA, ID_SP)
VALUES
('359296725500001', 'SP005'),
('359296725500002', 'SP005'),
('359296725500003', 'SP005'),
('359296725500004', 'SP005'),
('359296725500005', 'SP005'),
('359296725500006', 'SP005'),
('359296725500007', 'SP005'),
('359296725500008', 'SP005'),
('359296725500009', 'SP005'),
('359296725500010', 'SP005')
GO

INSERT INTO IMEICODE (MA, ID_SP)
VALUES
('357292722200001', 'SP006'),
('357292722200002', 'SP006'),
('357292722200003', 'SP006'),
('357292722200004', 'SP006'),
('357292722200005', 'SP006'),
('357292722200006', 'SP006'),
('357292722200007', 'SP006'),
('357292722200008', 'SP006'),
('357292722200009', 'SP006'),
('357292722200010', 'SP006')
GO

INSERT INTO IMEICODE (MA, ID_SP)
VALUES
('355695723100001', 'SP007'),
('355695723100002', 'SP007'),
('355695723100003', 'SP007'),
('355695723100004', 'SP007'),
('355695723100005', 'SP007'),
('355695723100006', 'SP007'),
('355695723100007', 'SP007'),
('355695723100008', 'SP007'),
('355695723100009', 'SP007'),
('355695723100010', 'SP007')
GO

INSERT INTO IMEICODE (MA, ID_SP)
VALUES
('357815726800001', 'SP008'),
('357815726800002', 'SP008'),
('357815726800003', 'SP008'),
('357815726800004', 'SP008'),
('357815726800005', 'SP008'),
('357815726800006', 'SP008'),
('357815726800007', 'SP008'),
('357815726800008', 'SP008'),
('357815726800009', 'SP008'),
('357815726800010', 'SP008')
GO

INSERT INTO IMEICODE (MA, ID_SP)
VALUES
('353415822400001', 'SP009'),
('353415822400002', 'SP009'),
('353415822400003', 'SP009'),
('353415822400004', 'SP009'),
('353415822400005', 'SP009'),
('353415822400006', 'SP009'),
('353415822400007', 'SP009'),
('353415822400008', 'SP009'),
('353415822400009', 'SP009'),
('353415822400010', 'SP009')
GO

INSERT INTO IMEICODE (MA, ID_SP)
VALUES
('356926829600001', 'SP010'),
('356926829600002', 'SP010'),
('356926829600003', 'SP010'),
('356926829600004', 'SP010'),
('356926829600005', 'SP010'),
('356926829600006', 'SP010'),
('356926829600007', 'SP010'),
('356926829600008', 'SP010'),
('356926829600009', 'SP010'),
('356926829600010', 'SP010')
GO

INSERT INTO IMEICODE (MA, ID_SP)
VALUES
('357922820900001', 'SP011'),
('357922820900002', 'SP011'),
('357922820900003', 'SP011'),
('357922820900004', 'SP011'),
('357922820900005', 'SP011'),
('357922820900006', 'SP011'),
('357922820900007', 'SP011'),
('357922820900008', 'SP011'),
('357922820900009', 'SP011'),
('357922820900010', 'SP011')
GO

INSERT INTO IMEICODE (MA, ID_SP)
VALUES
('354498822100001', 'SP012'),
('354498822100002', 'SP012'),
('354498822100003', 'SP012'),
('354498822100004', 'SP012'),
('354498822100005', 'SP012'),
('354498822100006', 'SP012'),
('354498822100007', 'SP012'),
('354498822100008', 'SP012'),
('354498822100009', 'SP012'),
('354498822100010', 'SP012')
GO

INSERT INTO IMEICODE (MA, ID_SP)
VALUES
('351492823600001', 'SP013'),
('351492823600002', 'SP013'),
('351492823600003', 'SP013'),
('351492823600004', 'SP013'),
('351492823600005', 'SP013'),
('351492823600006', 'SP013'),
('351492823600007', 'SP013'),
('351492823600008', 'SP013'),
('351492823600009', 'SP013'),
('351492823600010', 'SP013')
GO

INSERT INTO IMEICODE (MA, ID_SP)
VALUES
('355494623900001', 'SP014'),
('355494623900002', 'SP014'),
('355494623900003', 'SP014'),
('355494623900004', 'SP014'),
('355494623900005', 'SP014'),
('355494623900006', 'SP014'),
('355494623900007', 'SP014'),
('355494623900008', 'SP014'),
('355494623900009', 'SP014'),
('355494623900010', 'SP014')
GO

INSERT INTO IMEICODE (MA, ID_SP)
VALUES
('358464607900001', 'SP015'),
('358464607900002', 'SP015'),
('358464607900003', 'SP015'),
('358464607900004', 'SP015'),
('358464607900005', 'SP015'),
('358464607900006', 'SP015'),
('358464607900007', 'SP015'),
('358464607900008', 'SP015'),
('358464607900009', 'SP015'),
('358464607900010', 'SP015')
GO

INSERT INTO IMEICODE (MA, ID_SP)
VALUES
('353694604900001', 'SP016'),
('353694604900002', 'SP016'),
('353694604900003', 'SP016'),
('353694604900004', 'SP016'),
('353694604900005', 'SP016'),
('353694604900006', 'SP016'),
('353694604900007', 'SP016'),
('353694604900008', 'SP016'),
('353694604900009', 'SP016'),
('353694604900010', 'SP016')
GO

INSERT INTO IMEICODE (MA, ID_SP)
VALUES
('357793502700001', 'SP017'),
('357793502700002', 'SP017'),
('357793502700003', 'SP017'),
('357793502700004', 'SP017'),
('357793502700005', 'SP017'),
('357793502700006', 'SP017'),
('357793502700007', 'SP017'),
('357793502700008', 'SP017'),
('357793502700009', 'SP017'),
('357793502700010', 'SP017')
GO

INSERT INTO IMEICODE (MA, ID_SP)
VALUES
('355763506600001', 'SP018'),
('355763506600002', 'SP018'),
('355763506600003', 'SP018'),
('355763506600004', 'SP018'),
('355763506600005', 'SP018'),
('355763506600006', 'SP018'),
('355763506600007', 'SP018'),
('355763506600008', 'SP018'),
('355763506600009', 'SP018'),
('355763506600010', 'SP018')
GO

INSERT INTO IMEICODE (MA, ID_SP)
VALUES
('351190504800001', 'SP019'),
('351190504800002', 'SP019'),
('351190504800003', 'SP019'),
('351190504800004', 'SP019'),
('351190504800005', 'SP019'),
('351190504800006', 'SP019'),
('351190504800007', 'SP019'),
('351190504800008', 'SP019'),
('351190504800009', 'SP019'),
('351190504800010', 'SP019')
GO

INSERT INTO IMEICODE (MA, ID_SP)
VALUES
('356129905000001', 'SP020'),
('356129905000002', 'SP020'),
('356129905000003', 'SP020'),
('356129905000004', 'SP020'),
('356129905000005', 'SP020'),
('356129905000006', 'SP020'),
('356129905000007', 'SP020'),
('356129905000008', 'SP020'),
('356129905000009', 'SP020'),
('356129905000010', 'SP020')
GO

INSERT INTO IMEICODE (MA, ID_SP)
VALUES
('357999902100001', 'SP021'),
('357999902100002', 'SP021'),
('357999902100003', 'SP021'),
('357999902100004', 'SP021'),
('357999902100005', 'SP021'),
('357999902100006', 'SP021'),
('357999902100007', 'SP021'),
('357999902100008', 'SP021'),
('357999902100009', 'SP021'),
('357999902100010', 'SP021')
GO

INSERT INTO IMEICODE (MA, ID_SP)
VALUES
('352245934100001', 'SP022'),
('352245934100002', 'SP022'),
('352245934100003', 'SP022'),
('352245934100004', 'SP022'),
('352245934100005', 'SP022'),
('352245934100006', 'SP022'),
('352245934100007', 'SP022'),
('352245934100008', 'SP022'),
('352245934100009', 'SP022'),
('352245934100010', 'SP022')
GO

INSERT INTO IMEICODE (MA, ID_SP)
VALUES
('353296244500001', 'SP023'),
('353296244500002', 'SP023'),
('353296244500003', 'SP023'),
('353296244500004', 'SP023'),
('353296244500005', 'SP023'),
('353296244500006', 'SP023'),
('353296244500007', 'SP023'),
('353296244500008', 'SP023'),
('353296244500009', 'SP023'),
('353296244500010', 'SP023')
GO

INSERT INTO IMEICODE (MA, ID_SP)
VALUES
('354911646900001', 'SP024'),
('354911646900002', 'SP024'),
('354911646900003', 'SP024'),
('354911646900004', 'SP024'),
('354911646900005', 'SP024'),
('354911646900006', 'SP024'),
('354911646900007', 'SP024'),
('354911646900008', 'SP024'),
('354911646900009', 'SP024'),
('354911646900010', 'SP024')
GO

INSERT INTO IMEICODE (MA, ID_SP)
VALUES
('357643621100001', 'SP025'),
('357643621100002', 'SP025'),
('357643621100003', 'SP025'),
('357643621100004', 'SP025'),
('357643621100005', 'SP025'),
('357643621100006', 'SP025'),
('357643621100007', 'SP025'),
('357643621100008', 'SP025'),
('357643621100009', 'SP025'),
('357643621100010', 'SP025')
GO

INSERT INTO IMEICODE (MA, ID_SP)
VALUES
('353623728800001', 'SP026'),
('353623728800002', 'SP026'),
('353623728800003', 'SP026'),
('353623728800004', 'SP026'),
('353623728800005', 'SP026'),
('353623728800006', 'SP026'),
('353623728800007', 'SP026'),
('353623728800008', 'SP026'),
('353623728800009', 'SP026'),
('353623728800010', 'SP026')
GO

INSERT INTO IMEICODE (MA, ID_SP)
VALUES
('354896721200001', 'SP027'),
('354896721200002', 'SP027'),
('354896721200003', 'SP027'),
('354896721200004', 'SP027'),
('354896721200005', 'SP027'),
('354896721200006', 'SP027'),
('354896721200007', 'SP027'),
('354896721200008', 'SP027'),
('354896721200009', 'SP027'),
('354896721200010', 'SP027')
GO

INSERT INTO IMEICODE (MA, ID_SP)
VALUES
('351555223700001', 'SP028'),
('351555223700002', 'SP028'),
('351555223700003', 'SP028'),
('351555223700004', 'SP028'),
('351555223700005', 'SP028'),
('351555223700006', 'SP028'),
('351555223700007', 'SP028'),
('351555223700008', 'SP028'),
('351555223700009', 'SP028'),
('351555223700010', 'SP028')
GO

INSERT INTO IMEICODE (MA, ID_SP)
VALUES
('354728926700001', 'SP029'),
('354728926700002', 'SP029'),
('354728926700003', 'SP029'),
('354728926700004', 'SP029'),
('354728926700005', 'SP029'),
('354728926700006', 'SP029'),
('354728926700007', 'SP029'),
('354728926700008', 'SP029'),
('354728926700009', 'SP029'),
('354728926700010', 'SP029')
GO

INSERT INTO IMEICODE (MA, ID_SP)
VALUES
('355632926800001', 'SP030'),
('355632926800002', 'SP030'),
('355632926800003', 'SP030'),
('355632926800004', 'SP030'),
('355632926800005', 'SP030'),
('355632926800006', 'SP030'),
('355632926800007', 'SP030'),
('355632926800008', 'SP030'),
('355632926800009', 'SP030'),
('355632926800010', 'SP030')
GO

INSERT INTO IMEICODE (MA, ID_SP)
VALUES
('356231723900001', 'SP031'),
('356231723900002', 'SP031'),
('356231723900003', 'SP031'),
('356231723900004', 'SP031'),
('356231723900005', 'SP031'),
('356231723900006', 'SP031'),
('356231723900007', 'SP031'),
('356231723900008', 'SP031'),
('356231723900009', 'SP031'),
('356231723900010', 'SP031')
GO

INSERT INTO IMEICODE (MA, ID_SP)
VALUES
('354763643800001', 'SP032'),
('354763643800002', 'SP032'),
('354763643800003', 'SP032'),
('354763643800004', 'SP032'),
('354763643800005', 'SP032'),
('354763643800006', 'SP032'),
('354763643800007', 'SP032'),
('354763643800008', 'SP032'),
('354763643800009', 'SP032'),
('354763643800010', 'SP032')
GO

INSERT INTO IMEICODE (MA, ID_SP)
VALUES
('355424843300001', 'SP033'),
('355424843300002', 'SP033'),
('355424843300003', 'SP033'),
('355424843300004', 'SP033'),
('355424843300005', 'SP033'),
('355424843300006', 'SP033'),
('355424843300007', 'SP033'),
('355424843300008', 'SP033'),
('355424843300009', 'SP033'),
('355424843300010', 'SP033')
GO

INSERT INTO IMEICODE (MA, ID_SP)
VALUES
('356892841100001', 'SP034'),
('356892841100002', 'SP034'),
('356892841100003', 'SP034'),
('356892841100004', 'SP034'),
('356892841100005', 'SP034'),
('356892841100006', 'SP034'),
('356892841100007', 'SP034'),
('356892841100008', 'SP034'),
('356892841100009', 'SP034'),
('356892841100010', 'SP034')
GO

INSERT INTO IMEICODE (MA, ID_SP)
VALUES
('354462478100001', 'SP035'),
('354462478100002', 'SP035'),
('354462478100003', 'SP035'),
('354462478100004', 'SP035'),
('354462478100005', 'SP035'),
('354462478100006', 'SP035'),
('354462478100007', 'SP035'),
('354462478100008', 'SP035'),
('354462478100009', 'SP035'),
('354462478100010', 'SP035')
GO

INSERT INTO IMEICODE (MA, ID_SP)
VALUES
('352478618400001', 'SP036'),
('352478618400002', 'SP036'),
('352478618400003', 'SP036'),
('352478618400004', 'SP036'),
('352478618400005', 'SP036'),
('352478618400006', 'SP036'),
('352478618400007', 'SP036'),
('352478618400008', 'SP036'),
('352478618400009', 'SP036'),
('352478618400010', 'SP036')
GO

INSERT INTO IMEICODE (MA, ID_SP)
VALUES
('356592512300001', 'SP037'),
('356592512300002', 'SP037'),
('356592512300003', 'SP037'),
('356592512300004', 'SP037'),
('356592512300005', 'SP037'),
('356592512300006', 'SP037'),
('356592512300007', 'SP037'),
('356592512300008', 'SP037'),
('356592512300009', 'SP037'),
('356592512300010', 'SP037')
GO

INSERT INTO IMEICODE (MA, ID_SP)
VALUES
('352546812800001', 'SP038'),
('352546812800002', 'SP038'),
('352546812800003', 'SP038'),
('352546812800004', 'SP038'),
('352546812800005', 'SP038'),
('352546812800006', 'SP038'),
('352546812800007', 'SP038'),
('352546812800008', 'SP038'),
('352546812800009', 'SP038'),
('352546812800010', 'SP038')
GO

INSERT INTO IMEICODE (MA, ID_SP)
VALUES
('357516244700001', 'SP039'),
('357516244700002', 'SP039'),
('357516244700003', 'SP039'),
('357516244700004', 'SP039'),
('357516244700005', 'SP039'),
('357516244700006', 'SP039'),
('357516244700007', 'SP039'),
('357516244700008', 'SP039'),
('357516244700009', 'SP039'),
('357516244700010', 'SP039')
GO

INSERT INTO IMEICODE (MA, ID_SP)
VALUES
('358619388700001', 'SP040'),
('358619388700002', 'SP040'),
('358619388700003', 'SP040'),
('358619388700004', 'SP040'),
('358619388700005', 'SP040'),
('358619388700006', 'SP040'),
('358619388700007', 'SP040'),
('358619388700008', 'SP040'),
('358619388700009', 'SP040'),
('358619388700010', 'SP040')
GO

INSERT INTO IMEICODE (MA, ID_SP)
VALUES
('869259074600001', 'SP041'),
('869259074600002', 'SP041'),
('869259074600003', 'SP041'),
('869259074600004', 'SP041'),
('869259074600005', 'SP041'),
('869259074600006', 'SP041'),
('869259074600007', 'SP041'),
('869259074600008', 'SP041'),
('869259074600009', 'SP041'),
('869259074600010', 'SP041')
GO

INSERT INTO IMEICODE (MA, ID_SP)
VALUES
('869726074600001', 'SP042'),
('869726074600002', 'SP042'),
('869726074600003', 'SP042'),
('869726074600004', 'SP042'),
('869726074600005', 'SP042'),
('869726074600006', 'SP042'),
('869726074600007', 'SP042'),
('869726074600008', 'SP042'),
('869726074600009', 'SP042'),
('869726074600010', 'SP042')
GO

INSERT INTO IMEICODE (MA, ID_SP)
VALUES
('868026074600001', 'SP043'),
('868026074600002', 'SP043'),
('868026074600003', 'SP043'),
('868026074600004', 'SP043'),
('868026074600005', 'SP043'),
('868026074600006', 'SP043'),
('868026074600007', 'SP043'),
('868026074600008', 'SP043'),
('868026074600009', 'SP043'),
('868026074600010', 'SP043')
GO

INSERT INTO IMEICODE (MA, ID_SP)
VALUES
('869626724500001', 'SP044'),
('869626724500002', 'SP044'),
('869626724500003', 'SP044'),
('869626724500004', 'SP044'),
('869626724500005', 'SP044'),
('869626724500006', 'SP044'),
('869626724500007', 'SP044'),
('869626724500008', 'SP044'),
('869626724500009', 'SP044'),
('869626724500010', 'SP044')
GO

INSERT INTO IMEICODE (MA, ID_SP)
VALUES
('863296725500001', 'SP045'),
('863296725500002', 'SP045'),
('863296725500003', 'SP045'),
('863296725500004', 'SP045'),
('863296725500005', 'SP045'),
('863296725500006', 'SP045'),
('863296725500007', 'SP045'),
('863296725500008', 'SP045'),
('863296725500009', 'SP045'),
('863296725500010', 'SP045')
GO

INSERT INTO IMEICODE (MA, ID_SP)
VALUES
('867992721200001', 'SP046'),
('867992721200002', 'SP046'),
('867992721200003', 'SP046'),
('867992721200004', 'SP046'),
('867992721200005', 'SP046'),
('867992721200006', 'SP046'),
('867992721200007', 'SP046'),
('867992721200008', 'SP046'),
('867992721200009', 'SP046'),
('867992721200010', 'SP046')
GO

INSERT INTO IMEICODE (MA, ID_SP)
VALUES
('865795783100001', 'SP047'),
('865795783100002', 'SP047'),
('865795783100003', 'SP047'),
('865795783100004', 'SP047'),
('865795783100005', 'SP047'),
('865795783100006', 'SP047'),
('865795783100007', 'SP047'),
('865795783100008', 'SP047'),
('865795783100009', 'SP047'),
('865795783100010', 'SP047')
GO

INSERT INTO IMEICODE (MA, ID_SP)
VALUES
('867912726800001', 'SP048'),
('867912726800002', 'SP048'),
('867912726800003', 'SP048'),
('867912726800004', 'SP048'),
('867912726800005', 'SP048'),
('867912726800006', 'SP048'),
('867912726800007', 'SP048'),
('867912726800008', 'SP048'),
('867912726800009', 'SP048'),
('867912726800010', 'SP048')
GO

INSERT INTO IMEICODE (MA, ID_SP)
VALUES
('862415812400001', 'SP049'),
('862415812400002', 'SP049'),
('862415812400003', 'SP049'),
('862415812400004', 'SP049'),
('862415812400005', 'SP049'),
('862415812400006', 'SP049'),
('862415812400007', 'SP049'),
('862415812400008', 'SP049'),
('862415812400009', 'SP049'),
('862415812400010', 'SP049')
GO

INSERT INTO IMEICODE (MA, ID_SP)
VALUES
('867026129600001', 'SP050'),
('867026129600002', 'SP050'),
('867026129600003', 'SP050'),
('867026129600004', 'SP050'),
('867026129600005', 'SP050'),
('867026129600006', 'SP050'),
('867026129600007', 'SP050'),
('867026129600008', 'SP050'),
('867026129600009', 'SP050'),
('867026129600010', 'SP050')
GO

INSERT INTO IMEICODE (MA, ID_SP)
VALUES
('863922830900001', 'SP051'),
('863922830900002', 'SP051'),
('863922830900003', 'SP051'),
('863922830900004', 'SP051'),
('863922830900005', 'SP051'),
('863922830900006', 'SP051'),
('863922830900007', 'SP051'),
('863922830900008', 'SP051'),
('863922830900009', 'SP051'),
('863922830900010', 'SP051')
GO

INSERT INTO IMEICODE (MA, ID_SP)
VALUES
('865498812100001', 'SP052'),
('865498812100002', 'SP052'),
('865498812100003', 'SP052'),
('865498812100004', 'SP052'),
('865498812100005', 'SP052'),
('865498812100006', 'SP052'),
('865498812100007', 'SP052'),
('865498812100008', 'SP052'),
('865498812100009', 'SP052'),
('865498812100010', 'SP052')
GO

INSERT INTO IMEICODE (MA, ID_SP)
VALUES
('862492723600001', 'SP053'),
('862492723600002', 'SP053'),
('862492723600003', 'SP053'),
('862492723600004', 'SP053'),
('862492723600005', 'SP053'),
('862492723600006', 'SP053'),
('862492723600007', 'SP053'),
('862492723600008', 'SP053'),
('862492723600009', 'SP053'),
('862492723600010', 'SP053')
GO

INSERT INTO IMEICODE (MA, ID_SP)
VALUES
('866494613900001', 'SP054'),
('866494613900002', 'SP054'),
('866494613900003', 'SP054'),
('866494613900004', 'SP054'),
('866494613900005', 'SP054'),
('866494613900006', 'SP054'),
('866494613900007', 'SP054'),
('866494613900008', 'SP054'),
('866494613900009', 'SP054'),
('866494613900010', 'SP054')
GO

INSERT INTO IMEICODE (MA, ID_SP)
VALUES
('868463907900001', 'SP055'),
('868463907900002', 'SP055'),
('868463907900003', 'SP055'),
('868463907900004', 'SP055'),
('868463907900005', 'SP055'),
('868463907900006', 'SP055'),
('868463907900007', 'SP055'),
('868463907900008', 'SP055'),
('868463907900009', 'SP055'),
('868463907900010', 'SP055')
GO

INSERT INTO IMEICODE (MA, ID_SP)
VALUES
('864794604900001', 'SP056'),
('864794604900002', 'SP056'),
('864794604900003', 'SP056'),
('864794604900004', 'SP056'),
('864794604900005', 'SP056'),
('864794604900006', 'SP056'),
('864794604900007', 'SP056'),
('864794604900008', 'SP056'),
('864794604900009', 'SP056'),
('864794604900010', 'SP056')
GO

INSERT INTO IMEICODE (MA, ID_SP)
VALUES
('868783502700001', 'SP057'),
('868783502700002', 'SP057'),
('868783502700003', 'SP057'),
('868783502700004', 'SP057'),
('868783502700005', 'SP057'),
('868783502700006', 'SP057'),
('868783502700007', 'SP057'),
('868783502700008', 'SP057'),
('868783502700009', 'SP057'),
('868783502700010', 'SP057')
GO

INSERT INTO IMEICODE (MA, ID_SP)
VALUES
('864863516600001', 'SP058'),
('864863516600002', 'SP058'),
('864863516600003', 'SP058'),
('864863516600004', 'SP058'),
('864863516600005', 'SP058'),
('864863516600006', 'SP058'),
('864863516600007', 'SP058'),
('864863516600008', 'SP058'),
('864863516600009', 'SP058'),
('864863516600010', 'SP058')
GO

INSERT INTO IMEICODE (MA, ID_SP)
VALUES
('861191504800001', 'SP059'),
('861191504800002', 'SP059'),
('861191504800003', 'SP059'),
('861191504800004', 'SP059'),
('861191504800005', 'SP059'),
('861191504800006', 'SP059'),
('861191504800007', 'SP059'),
('861191504800008', 'SP059'),
('861191504800009', 'SP059'),
('861191504800010', 'SP059')
GO

INSERT INTO IMEICODE (MA, ID_SP)
VALUES
('866239905000001', 'SP060'),
('866239905000002', 'SP060'),
('866239905000003', 'SP060'),
('866239905000004', 'SP060'),
('866239905000005', 'SP060'),
('866239905000006', 'SP060'),
('866239905000007', 'SP060'),
('866239905000008', 'SP060'),
('866239905000009', 'SP060'),
('866239905000010', 'SP060')
GO

INSERT INTO IMEICODE (MA, ID_SP)
VALUES
('868792902100001', 'SP061'),
('868792902100002', 'SP061'),
('868792902100003', 'SP061'),
('868792902100004', 'SP061'),
('868792902100005', 'SP061'),
('868792902100006', 'SP061'),
('868792902100007', 'SP061'),
('868792902100008', 'SP061'),
('868792902100009', 'SP061'),
('868792902100010', 'SP061')
GO

INSERT INTO IMEICODE (MA, ID_SP)
VALUES
('863645134100001', 'SP062'),
('863645134100002', 'SP062'),
('863645134100003', 'SP062'),
('863645134100004', 'SP062'),
('863645134100005', 'SP062'),
('863645134100006', 'SP062'),
('863645134100007', 'SP062'),
('863645134100008', 'SP062'),
('863645134100009', 'SP062'),
('863645134100010', 'SP062')
GO

INSERT INTO IMEICODE (MA, ID_SP)
VALUES
('863186244500001', 'SP063'),
('863186244500002', 'SP063'),
('863186244500003', 'SP063'),
('863186244500004', 'SP063'),
('863186244500005', 'SP063'),
('863186244500006', 'SP063'),
('863186244500007', 'SP063'),
('863186244500008', 'SP063'),
('863186244500009', 'SP063'),
('863186244500010', 'SP063')
GO

INSERT INTO IMEICODE (MA, ID_SP)
VALUES
('865921346900001', 'SP064'),
('865921346900002', 'SP064'),
('865921346900003', 'SP064'),
('865921346900004', 'SP064'),
('865921346900005', 'SP064'),
('865921346900006', 'SP064'),
('865921346900007', 'SP064'),
('865921346900008', 'SP064'),
('865921346900009', 'SP064'),
('865921346900010', 'SP064')
GO

INSERT INTO IMEICODE (MA, ID_SP)
VALUES
('868643632100001', 'SP065'),
('868643632100002', 'SP065'),
('868643632100003', 'SP065'),
('868643632100004', 'SP065'),
('868643632100005', 'SP065'),
('868643632100006', 'SP065'),
('868643632100007', 'SP065'),
('868643632100008', 'SP065'),
('868643632100009', 'SP065'),
('868643632100010', 'SP065')
GO

INSERT INTO IMEICODE (MA, ID_SP)
VALUES
('864723128800001', 'SP066'),
('864723128800002', 'SP066'),
('864723128800003', 'SP066'),
('864723128800004', 'SP066'),
('864723128800005', 'SP066'),
('864723128800006', 'SP066'),
('864723128800007', 'SP066'),
('864723128800008', 'SP066'),
('864723128800009', 'SP066'),
('864723128800010', 'SP066')
GO

INSERT INTO IMEICODE (MA, ID_SP)
VALUES
('864996729200001', 'SP067'),
('864996729200002', 'SP067'),
('864996729200003', 'SP067'),
('864996729200004', 'SP067'),
('864996729200005', 'SP067'),
('864996729200006', 'SP067'),
('864996729200007', 'SP067'),
('864996729200008', 'SP067'),
('864996729200009', 'SP067'),
('864996729200010', 'SP067')
GO

INSERT INTO IMEICODE (MA, ID_SP)
VALUES
('862565283700001', 'SP068'),
('862565283700002', 'SP068'),
('862565283700003', 'SP068'),
('862565283700004', 'SP068'),
('862565283700005', 'SP068'),
('862565283700006', 'SP068'),
('862565283700007', 'SP068'),
('862565283700008', 'SP068'),
('862565283700009', 'SP068'),
('862565283700010', 'SP068')
GO

INSERT INTO IMEICODE (MA, ID_SP)
VALUES
('866128936700001', 'SP069'),
('866128936700002', 'SP069'),
('866128936700003', 'SP069'),
('866128936700004', 'SP069'),
('866128936700005', 'SP069'),
('866128936700006', 'SP069'),
('866128936700007', 'SP069'),
('866128936700008', 'SP069'),
('866128936700009', 'SP069'),
('866128936700010', 'SP069')
GO

INSERT INTO IMEICODE (MA, ID_SP)
VALUES
('865672936800001', 'SP070'),
('865672936800002', 'SP070'),
('865672936800003', 'SP070'),
('865672936800004', 'SP070'),
('865672936800005', 'SP070'),
('865672936800006', 'SP070'),
('865672936800007', 'SP070'),
('865672936800008', 'SP070'),
('865672936800009', 'SP070'),
('865672936800010', 'SP070')
GO

INSERT INTO IMEICODE (MA, ID_SP)
VALUES
('866234723900001', 'SP071'),
('866234723900002', 'SP071'),
('866234723900003', 'SP071'),
('866234723900004', 'SP071'),
('866234723900005', 'SP071'),
('866234723900006', 'SP071'),
('866234723900007', 'SP071'),
('866234723900008', 'SP071'),
('866234723900009', 'SP071'),
('866234723900010', 'SP071')
GO

INSERT INTO IMEICODE (MA, ID_SP)
VALUES
('864261643800001', 'SP072'),
('864261643800002', 'SP072'),
('864261643800003', 'SP072'),
('864261643800004', 'SP072'),
('864261643800005', 'SP072'),
('864261643800006', 'SP072'),
('864261643800007', 'SP072'),
('864261643800008', 'SP072'),
('864261643800009', 'SP072'),
('864261643800010', 'SP072')
GO

INSERT INTO IMEICODE (MA, ID_SP)
VALUES
('865427849300001', 'SP073'),
('865427849300002', 'SP073'),
('865427849300003', 'SP073'),
('865427849300004', 'SP073'),
('865427849300005', 'SP073'),
('865427849300006', 'SP073'),
('865427849300007', 'SP073'),
('865427849300008', 'SP073'),
('865427849300009', 'SP073'),
('865427849300010', 'SP073')
GO

INSERT INTO IMEICODE (MA, ID_SP)
VALUES
('868928475100001', 'SP074'),
('868928475100002', 'SP074'),
('868928475100003', 'SP074'),
('868928475100004', 'SP074'),
('868928475100005', 'SP074'),
('868928475100006', 'SP074'),
('868928475100007', 'SP074'),
('868928475100008', 'SP074'),
('868928475100009', 'SP074'),
('868928475100010', 'SP074')
GO

INSERT INTO IMEICODE (MA, ID_SP)
VALUES
('864562478100001', 'SP075'),
('864562478100002', 'SP075'),
('864562478100003', 'SP075'),
('864562478100004', 'SP075'),
('864562478100005', 'SP075'),
('864562478100006', 'SP075'),
('864562478100007', 'SP075'),
('864562478100008', 'SP075'),
('864562478100009', 'SP075'),
('864562478100010', 'SP075')
GO

INSERT INTO IMEICODE (MA, ID_SP)
VALUES
('862475618400001', 'SP076'),
('862475618400002', 'SP076'),
('862475618400003', 'SP076'),
('862475618400004', 'SP076'),
('862475618400005', 'SP076'),
('862475618400006', 'SP076'),
('862475618400007', 'SP076'),
('862475618400008', 'SP076'),
('862475618400009', 'SP076'),
('862475618400010', 'SP076')
GO

INSERT INTO IMEICODE (MA, ID_SP)
VALUES
('866592712300001', 'SP077'),
('866592712300002', 'SP077'),
('866592712300003', 'SP077'),
('866592712300004', 'SP077'),
('866592712300005', 'SP077'),
('866592712300006', 'SP077'),
('866592712300007', 'SP077'),
('866592712300008', 'SP077'),
('866592712300009', 'SP077'),
('866592712300010', 'SP077')
GO
-----------------------------------------------------------------------------

------------------------------------ THONGKECMT -----------------------------
INSERT THONGKECMT
VALUES
(N'Sản phẩm sài rất tốt','SP014','06/06/2022'),
(N'Tầm giá này thì sài quá tuyệt rồi','SP014','06/06/2022'),
(N'Máy xài rất mướt tôi rất thích','SP014','06/06/2022'),
(N'Thiết kế đẹp chụp hình xuất sắc luôn','SP014','06/06/2022'),
(N'Sản phẩm sử dụng rất tốt có rất nhiều tính năng hay và còn được tặng ốp lương và miếng dán trống sức nữa rất đáng để mua','SP014','06/06/2022'),
(N'Xài tốt','SP014','06/06/2022'),
(N'Sản phẩm rất tốt, đáng tiền mua. Cấu hình mạnh','SP014','06/06/2022'),
(N'Máy xài mướt, tôi rất thích, cấu hình cao, thiết kế đẹp','SP014','06/06/2022'),
(N'sản phẩm quá tốt trong tầm giá sài mấy năm rồi mà vẫn mượt mà','SP014','06/06/2022'),
(N'Thiết kế đẹp bắt mắt sản phẩm rất tốt ạ','SP014','06/06/2022'),

(N'Máy xịn chụp hình đẹp, nên mua nha mọi người','SP014','06/06/2022'),
(N'Rất hài lòng.... Tuy máy có 1 số lỗi nhứt định nhưng hàng điện tử mà không có cái nào là hoàn hảo nhất. Và đây là 1 sản phẩm của anh Sơn Tùng làm người quản bá thương hiệu thì là 1 sản phẩm cực kì đáng mua.','SP014','06/06/2022'),
(N'Thiết kế đẹp','SP014','06/06/2022'),
(N'Xài ngon, màn đẹp, máy mạnh, chụp hình xuất sắc trong tầm giá','SP014','06/06/2022'),
(N'Mới dùng được 5 ngày cũng khá ok','SP014','06/06/2022'),
(N'Dùng rất tốt, đáng mua','SP014','06/06/2022'),
(N'Máy rất đẹp và xài rất mượt','SP014','06/06/2022'),
(N'Máy tốt, tôi không dùng nhiều như vậy tuyệt vời. Thiết kế đẹp','SP014','06/06/2022'),
(N'Xài máy rất êm.thích nhất cái sạc nhanh của oppo','SP014','06/06/2022'),
(N'Sản phẩm Sài rất thích','SP014','06/06/2022'),

(N'Máy chụp hình cực đẹp','SP014','06/06/2022'),
(N'Vừa mua bé này xong. Dùng thích ghê','SP014','06/06/2022'),
(N'Sản phẩm tốt trong tầm giá','SP014','06/06/2022'),
(N'Sản phẩm ok nha cả nhà','SP014','06/06/2022'),
(N'Mọi Thứ đều tốt nhưng pin không được trâu','SP014','06/06/2022'),
(N'Video call quá xấu. Khá thất vọng','SP014','06/06/2022'),
(N'Mới mua mà pin tuột nhanh quá trời Camera xấu quá Thà đừng mua chứ mua rồi ôm cục tức','SP014','06/06/2022'),
(N'Màn hình rất đẹp máy rất mỏng','SP014','06/06/2022'),
(N'Máy dùng rất ngon. Pin cực kỳ trâu. Sạc thì rất nhanh. Thiết kế thì quá đẹp. Cấu hình mạnh.','SP014','06/06/2022'),
(N'Máy rất ngon không có gì để chê ','SP014','06/06/2022'),

(N'Máy mượt ok chụp ảnh chơi game đều ổn','SP014','06/06/2022'),
(N'Màn đẹp, sạc khoẻ, bộ nhớ lớn','SP014','06/06/2022'),
(N'Dùng rất thích , màn đẹp , sạc nhanh , chụp ảnh cũng rất ảo nữa ','SP014','06/06/2022'),
(N'Máy rất đẹp, màn hình cong nhìn rất sang chảnh, máy thao tác vuốt mượt mà không chậm lag, chụp hình và quay phim rõ nét đẹp, rất hài lòng','SP014','06/06/2022'),
(N'Máy đẹp,nghe nhạc xem phim rất thích,chụp hình đẹp, mình ko có chơi game liên quân nên ko đánh giá được, có điều xài nhiều thì máy tụt pin nhanh bù lại sạc cực nhanh','SP014','06/06/2022'),
(N'Sản phẩm quá tuyệt vời nhưng sẽ nhanh tuột pin còn lại thì mượt mà sẽ giới thiệu cho bạn','SP014','06/06/2022'),
(N'Mới mua hôm qua . Không có gì để chê , mượt , màn đẹp , chơi tốc chiến mượt , coi phim đã , loa to . Pin dùng khá ok . Sạc nhanh cực Máy quá ok và ngon','SP014','06/06/2022'),
(N'Máy tuyệt vời, vượt sự tưởng tượng. Sạc nhanh tầm 30 mấy phút là đầy pin rồi, pin cầm dữ lắm, nhẹ. Nên cầm chơi game, thích cực, máy mượt, loa nghe ấm. Nói chug đáng đồng tiền. Anh em nên mua nhá. Màn hình cong mê cực,','SP014','06/06/2022'),
(N'Khá ok ngon về mọi thứ màn mượt.pin khỏe ','SP014','06/06/2022'),
(N'Máy sài quá ok ! Ko có gì để chê','SP014','06/06/2022'),

(N'Sản phẩm rất tốt, máy mỏng đẹp rất nhẹ. Cầm vừa tay, nữ xài màu trắng rất sang. Sạc siêu nhanh, màn hình mượn. Đánh giá chung tốt','SP014','06/06/2022'),
(N'Sản phẩm sử dụng rất oke đáng đồng tiền xài được sạc pin cực nhanh thời gian sử dụng lâu khoảng 10 tiếng','SP014','06/06/2022'),
(N'Sản phẩm quá tuyệt vời với tầm giá này','SP014','06/06/2022'),
(N'Dùng mượt ,pin trâu dùng được lâu ,cảm biến nhại','SP014','06/06/2022'),
(N'Tuyệt vời, sản phẩm mượt mà, chụp ảnh đẹp trải nghiệm máy rất OK luôn, quay video chống rung bảo xịn sò, mua xài đi mọi người','SP014','06/06/2022'),
(N'Sản phẩm tuyệt trong tầm giá','SP014','06/06/2022'),
(N'Thiết kế đẹp, pin ổn , sạc nhanh, camera đẹp. Rất đáng để mua','SP014','06/06/2022'),
(N'Máy đẹp, camera ok, pin trâu, sạc nhanh chỉ chán cử chỉ không chạm nhưng ok lắm, oppo luôn làm hài lòng','SP014','06/06/2022'),
(N'Máy dùng rất là ok,pin sài lâu, không chê chỗ nào được hết','SP014','06/06/2022'),
(N'Sản phẩm sài rất tốt','SP014','06/06/2022'),

(N'Hàng đẹp dùng bền, đã mua được mấy tháng','SP014','06/06/2022'),
(N'Sài ok nhé ko lỗi gì cả,rất ưng ý 1 điều là máy sạc pin rất nhanh','SP014','06/06/2022'),
(N'Mua máy từ lúc ra xài tới giờ rất ok. Chưa phát hiện lỗi. Máy xài mượt,chơi game bao phê','SP014','06/06/2022'),
(N'Máy đẹp, nhỏ gọn, màn hình cong tràn viền rất sexy. Pin xuống rất chậm sạc thì lại nhanh. Mọi tác vụ đều mượt mà, độ sáng màn hình cao nên chỉ để cỡ 10% là đủ nhìn có lẽ vì vậy nên mình xài không tốn pin. Đây là lần thứ 5 mình chọn hãng Oppo rồi, không có gì để chê cả.','SP014','06/06/2022'),
(N'Sản phẩm quá tuyệt vời, cấu hình ngon mượt, sạc siêu nhanh.đáng mua lắm ạ','SP014','06/06/2022'),
(N'Thiết kế đẹp tất cả đều ok','SP014','06/06/2022'),
(N'Sản phẩm khá ok','SP014','06/06/2022'),
(N'Thấy khá là ổn trong phân khúc này. Sẽ giới thiệu cho những ai thích sạc nhanh','SP014','06/06/2022'),
(N'Sản phẩm dùng tốt, chất lượng hình ảnh đẹp,pin tạm ổn','SP014','06/06/2022'),
(N'Sản phẩm sài rất tốt','SP014','06/06/2022'),

(N'Xài rất tệ','SP014','06/06/2022'),
(N'Điện thoại xài ổn định','SP014','06/06/2022'),
(N'Máy sài được tầm 1 năm thì 3 phím cứng bị đơ toàn bộ','SP014','06/06/2022'),
(N'lỗi nghiêm trọng làm mình rất thất vọng','SP014','06/06/2022'),
(N'Quá tệ so với giá','SP014','06/06/2022'),
(N'Máy dùng rất tốt, có nhiều chức năng mới,để sử dụng, tiền nào của nấy','SP014','06/06/2022'),
(N'Sản phẩm quá ok. Nên mua nhé','SP014','06/06/2022'),
(N'Máy dùng tốt lắm chạy mượt chơi game mượt Sạc rất nhanh luôn á mọi người Nói chung rất oke','SP014','06/06/2022'),
(N'Mình sử dụng reno 6 thấy khá mượt mà thiết kế rất đẹp','SP014','06/06/2022'),
(N'Rất tốt, chụp ảnh đẹp. Cấu hình mạnh Nói chung là tuyệt vời','SP014','06/06/2022'),

(N'Sản phẩm chơi game mượt, chụp hình thì quá xuất sắc.sạc pin cực kì nhanh. Nói chung rất đang đồng tiền bỏ ra. Sẽ giới thiệu cho người thân','SP014','06/06/2022'),
(N'Màn hình rất mượt, lướt đã tay lắm','SP014','06/06/2022'),
(N'máy rất ổn, pin trâu','SP014','06/06/2022'),
(N'Sản phẩm đẹp rất tốt Dòng cao cấp không làm thât vọng Tuyệt vời đáng đồng tiền','SP014','06/06/2022'),
(N'sản phẩm rất tốt và tôi rất hài lòng ','SP014','06/06/2022'),
(N'Sản phẩm rất đẹp , sạc pin siêu nhanhh tần số quyét mượt mà , chụp hình siêu đẹp luôn các bạn ạ. Rất hài lòng về sản phẩm sẽ giới thiệu cho người thân dùng','SP014','06/06/2022'),
(N'Sản phẩm xài quá ok. Đẹp mà cấu hình cao . sạc nhanh pin trâu','SP014','06/06/2022'),
(N'Dùng tuyệt vời với tầm giá này','SP014','06/06/2022'),
(N'Phải nói thiết kế máy rất đẹp','SP014','06/06/2022'),
(N'Ngoại hình đẹp, sang. Chụp hình nét, đẹp, sáng. Pin dùng đc lâu','SP014','06/06/2022'),

(N'Máy xài trên cả tuyệt vời,pin trâu, màn hình thì mượt khỏi chê','SP014','06/06/2022'),
(N'Tốt mượt mà sài ok','SP014','06/06/2022'),
(N'Máy ngon ko thể tả,cảm ứng mượt mà','SP014','06/06/2022'),
(N'Máy thiết kế đẹp, chất lượng rất tốt','SP014','06/06/2022'),
(N'cấu hình mạnh mượt mà','SP014','06/06/2022'),
(N'Nói thiệt Sài ức chế dễ ghê luôn','SP014','06/06/2022'),
(N'Đọc báo toàn đơ, ứng dụng đơn giản máy cũng đơ','SP014','06/06/2022'),
(N'Điện thoại Sài ngon .pin trâu','SP014','06/06/2022'),
(N'Sản phẩm sài rất tốt','SP014','06/06/2022'),
(N'Sản phẩm sài rất tốt','SP014','06/06/2022'),

(N'Mấy quá tệ, mua máy gần 1 năm xài chưa đc 2 tháng, mỗi tháng mang ra bảo hành 3 lần..quá tệ','SP014','06/06/2022'),
(N'Cảm ứng không mượt so với sản phẩm khác cùng giá tiền','SP014','06/06/2022'),
(N'Loa rất tệ','SP014','06/06/2022'),
(N'Nó rất tệ. Quá thất vọng. Mới mua mà bật wifi không được','SP014','06/06/2022'),
(N'Xem video và nghe nhạc âm thanh lúc to lúc nhỏ ko hài lòng','SP014','06/06/2022'),
(N'phần mềm quá tệ','SP014','06/06/2022'),
(N'Màn hình càm ứng chậm, chạm phải 2 lần mới được. Cảm biến cũng chậm','SP014','06/06/2022'),
(N'hàng không chất lượng thất vọng','SP014','06/06/2022'),
(N'Máy bắt sóng khá tệ','SP014','06/06/2022'),
(N'điện thoại giá cao mà chất lượng lại quá kèm','SP014','06/06/2022'),


(N'Mua đc 5 ngày , máy rất mượt , loa to , cam ổn','SP024','07/06/2022'),
(N'Máy thiết kế đẹp, chơi game mượt, nhân viên hỗ trợ tốt, camera chụp ảnh sắc nét, sẽ giới thiệu người thân','SP024','07/06/2022'),
(N'máy bi lỗi chức năng gọi điện thoại','SP024','07/06/2022'),
(N'Sản phẩm xuất sắc, mượt mà, giá thành chân thực, chụp hình đẹp, cấu hình cao, pin trâu, xử lí dữ liệu mượt mà','SP024','07/06/2022'),
(N'Sản phẩm tốt sử dụng rất mượt mà, pin trâu, sử dụng không thấy hiện tượng giật lag, màn hình đẹp rất hài lòng về sản phẩm','SP024','07/06/2022'),
(N'Máy đẹp, ngon, mượt','SP024','07/06/2022'),
(N'Máy mạnh, mượt, màn hình rât đẹp, loa to','SP024','07/06/2022'),
(N'Sản phẩm TỐT, PIN QUÁ OK, sạc nhanh','SP024','07/06/2022'),
(N'Sản phẩm ngon, pin trâu, các tác vụ đều rất ngon, tất cả đều tuyệt vời, xứng đáng giá tiền','SP024','07/06/2022'),
(N'Hiệu năng rất tốt, pin khoẻ, màn hình mượt. Mình thấy rất hài lòng','SP024','07/06/2022'),

(N'Thiết kế đẹp, camera ngon, màn hình Amoled ngon, pin trâu, sạc nhanh','SP024','07/06/2022'),
(N'Sản phẩm tốt . Pin trâu . Game chiến tốt ','SP024','07/06/2022'),
(N'Sản phẩm pin trâu, tác vụ thường ngày cũng mượt mà, camera tương đối ổn','SP024','07/06/2022'),
(N'Pin kém quá','SP024','07/06/2022'),
(N'Thiết kế đẹp. Camera chụp ảnh nét. Vào game nhanh, mượt','SP024','07/06/2022'),
(N'Điện thoại dùng rất tốt pin trâu màn hình đẹp hiệu năng quá tốt','SP024','07/06/2022'),
(N'Điện thoại màn hình rất đẹp','SP024','07/06/2022'),
(N'Hài lòng lắm với sản phẩm. Chất lượng ok Máy đẹp','SP024','07/06/2022'),
(N'Máy thiết kế đẹp, chơi game mượt không bị lag, pin trâu, chụp ảnh đẹp, tốc độ xử lí nhanh, màn hình rõ đẹp. Mọi thứ đều tuyệt vời, phù hợp với giá tiền','SP024','07/06/2022'),
(N'máy rất mượt mà, pin trâu, màn đẹp, chụp hình tốt trong tầm giá, cấu hình mạnh mẽ, chơi game ko quá nóng,vân tay nhạy,nói chung rất tuyệt.','SP024','07/06/2022'),

(N'Sản phẩm rất tốt, hơi nóng một tí, chip mạnh, pin hết hơi nhanh , rất hài lòng','SP024','07/06/2022'),
(N'Điênh thoại tốt. Hiệu năng cao.được Xiaomi rẻ bền tốt','SP024','07/06/2022'),
(N'Sản phẩm tốt, cấu hình mạnh chơi game ok, nhân viên tư vấn nhiệt tình, sẽ giới thiệu cho bạn bè','SP024','07/06/2022'),
(N'Máy sài không gì chê cả. Rất ok','SP024','07/06/2022'),
(N'Sản phẩm ngon, pin trâu, các tác vụ đều rất ngon, tất cả đều tuyệt vời, xứng đáng giá tiền','SP024','07/06/2022'),
(N'Pin trâu máy mượt, màn hình siêu đẹp. Game ngon','SP024','07/06/2022'),
(N'Sản phẩm tốt trong tầm giá. Sài pin trâu. Mượt mà, mà hơi tuột pin nhanh. Đánh giá rất ổn','SP024','07/06/2022'),
(N'Máy rât tốt trong tầm giá, rất mạnh và mượt, xài ok, nhân viên tư vấn nhiệt tình','SP024','07/06/2022'),
(N'máy rất tốt xài mượt êm','SP024','07/06/2022'),
(N'Cấu hình tốt. Màn hình đẹp với cả pin cũng trâu..cầm rất đầm tay, xứng đáng với giá tiền','SP024','07/06/2022'),

(N'thiết kế đẹp.ngoài thưc tế nhìn đẹp hơn trong ảnh.chụp hình rất đẹp . màng hình rất sáng cảm ứng rất nhanh pin ngon. đặc biệt cảm biến vân tay và gương mặt cực kì nhạy','SP024','07/06/2022'),
(N'Máy rất mạnh, chơi game khỏi chê, thiết kế rât xịn xò con bò luôn, sóng rât ổn luôn','SP024','07/06/2022'),
(N'Sản phẩm ngon, pin trâu, các tác vụ đều rất ngon, tất cả đều tuyệt vời, xứng đáng giá tiền','SP024','07/06/2022'),
(N'Thiết kế đẹp,máy chạy mượt mà','SP024','07/06/2022'),
(N'Mình thấy máy dùng mượt , chơi game ổn, cam chụp cũng khá đẹp. Pin trâu , sạc pin thì nhanh','SP024','07/06/2022'),
(N'Sản phẩm tốt trong tầm giá . Mới mua về sài mợt . Chơi game ổn . Pin cũng khá oki','SP024','07/06/2022'),
(N'Máy thiết kế đẹp, cấu hình ổn định, pin trâu, camera đẹp','SP024','07/06/2022'),
(N'Ok sản phẩm tốt','SP024','07/06/2022'),
(N'Sử dụng tốt trong tầm giá, Camera ổn, Sạc cực nhanh Đôi lúc lag nhẹ. Nói chung ổn','SP024','07/06/2022'),
(N'mượt và màn hình sáng đẹp','SP024','07/06/2022'),

(N'máy thiết kế đẹp, chạy mượt mà, màn hình đẹp và camera chụp rõ, rất đáng mua tại thế giới di động','SP024','07/06/2022'),
(N'Máy rất tốt, pin sử dụng được lâu nghe gọi, đọc báo các kiểu 3 hôm sạc lại, sạc hỗ trợ nhanh, tôi sẽ quay lại Thegioididong và giới thiệu cho bạn bè.','SP024','07/06/2022'),
(N'Mình đã trãi nghiệm máy note 10 này , cảm thấy rất mượt rất oke , rất tin tưởng về Xiaomi','SP024','07/06/2022'),
(N'Vừa chơi game vừa sạc lên rất chậm','SP024','07/06/2022'),
(N'Mọi thứ điều oke','SP024','07/06/2022'),
(N'Máy này hay bị lỗi. Đơ màn hình và bị treo','SP024','07/06/2022'),
(N'Camera lâu lâu bị lỗi! Còn gọi video thì cũng lỗi camera! Hơi tệ!','SP024','07/06/2022'),
(N'Tầm giá này thì điện thoại này tốt nhất rồi','SP024','07/06/2022'),
(N'Máy dùng ổn định pin trâu. Dùng rất ok','SP024','07/06/2022'),
(N'Rất ỗn với tầm giá.','SP024','07/06/2022'),

(N'Sau khi dùng mấy ngày thì tôi thấy máy rất ok, bắt sóng wifi tốt','SP024','07/06/2022'),
(N'Sử dụng tốt. Màn hình mượt hiển thị cũng sắc nét','SP024','07/06/2022'),
(N'máy bắt wiffi yếu quá','SP024','07/06/2022'),
(N'Hơi thất vọng về pin Thời gian sử dụng không thực tế Lướt fb tik tok tụt pin quá nhanh','SP024','07/06/2022'),
(N'máy sài OK Máy khá đẹp, pin tốt, màn hình bình thường, chụp ảnh tốt, nhiều chế độ chụp','SP024','07/06/2022'),
(N'Màn hình sáng, đẹp, loa nghe nhạc rất hay, cam trước chụp ổn, cam sau mình dùng gcam để chụp rất ok','SP024','07/06/2022'),
(N'bắt mạng kém thì mọi thứ ổn','SP024','07/06/2022'),
(N'Máy đùng khá tốt, pin khỏe, chơi game rất mượt','SP024','07/06/2022'),
(N'máy thiết kế đẹp,cấu hình mạnh,âm thanh ổn,pin khá trâu','SP024','07/06/2022'),
(N'Tôi mới mua được 1 tuần mọi thứ khá ổn','SP024','07/06/2022'),

(N'Điện thoại chơi game bị giật lag, có lỗi ở chỗ thông báo nền hiển thị lâu','SP024','07/06/2022'),
(N'Lỗi vặt quá nhiều','SP024','07/06/2022'),
(N'Pin tuột nhanh mặc dù không xài gì nhiều cam chụp hình thấy bình thường . Hơi thất vọng về pin','SP024','07/06/2022'),
(N'Loa bị lỗi. Gọi đầu dây bên kia nghe nhỏ rè','SP024','07/06/2022'),
(N'Dùng chơi game, lướt mạng xã hội, chụp ảnh ok Thời lượng pin tốt.. Quay video cũng rất tốt','SP024','07/06/2022'),
(N'Hay lỗi về nút quay về, phím hơi nhỏ, cam tốt, lướt wed khá tốt. Pin trâu xài tạm ổn','SP024','07/06/2022'),
(N'Chất lượng mic thoại cực kém','SP024','07/06/2022'),
(N'Điện thoại bị lỗi màn hình đen khi thực hiện cuộc gọi','SP024','07/06/2022'),
(N'Sài cũng ổn mà máy mau nóng và bị lỗi messenger cảm hơi thất vọng không đúng theo mong muốn','SP024','07/06/2022'),
(N'Chụp hình xấu tệ','SP024','07/06/2022'),

(N'Mặt lưng kính, màn hình đẹp, loa kép khá ok','SP024','07/06/2022'),
(N'Mình mua đc một tuần cảm nhận mọi thứ đều ổn','SP024','07/06/2022'),
(N'Sài bình thường','SP024','07/06/2022'),
(N'Mua đc 2 tháng thì thấy pin con này quá tệ','SP024','07/06/2022'),
(N'Máy nhận vân tay kém,mới mua đc gần 2 tháng,giờ toàn báo cảm ứng vân tay bạn ko nhận đc vân tay trong khi đó đã vệ sinh sạch sẽ,rất thất vọng','SP024','07/06/2022'),
(N'Cấu hình thì rất tốt','SP024','07/06/2022'),
(N'sản phẩm tệ quá','SP024','07/06/2022'),
(N'Mọi thứ đều ổn nhưng Lỗi cam chán quá','SP024','07/06/2022'),
(N'Gọi điện bắt sóng rất yêú. Gọi điện xong k tắt được. Pin tụt nhanh. Chụp hình thì dở tệ','SP024','07/06/2022'),
(N'Nhắn tin bong bong chat bị lỗi. Lúc bị đơ ... Quá tệ','SP024','07/06/2022'),

(N'Thất vọng quá, Xiaomi note 10 pro camera dùng chán hơn Xiaomi note 9 pro cũ của mình. Chup hình và quay camera rất mờ.','SP024','07/06/2022'),
(N'Máy dùng quá tệ bị nhiều lỗi','SP024','07/06/2022'),
(N'Máy rất tệ micro gọi nghe không rõ','SP024','07/06/2022'),
(N'Sản phẩm rất tệ hay bị lỗi đơ chất lượng rất tệ','SP024','07/06/2022'),
(N'Lỗi tùm lum hết chán ghê','SP024','07/06/2022'),
(N'Máy mình bị lỗi gọi điện, bấm gọi mãi không được, người khác gọi đến thì chỉ hiện gọi nhỡ,sim máy hoạt động bình thường','SP024','07/06/2022'),
(N'Ko hài lòng mới mua đc 2 tháng mà lỗi camera lỗi loa rồi thông báo chậm bắt wifi kém','SP024','07/06/2022'),
(N'sài rất tệ . ko mượt . nóng máy','SP024','07/06/2022'),
(N'Máy lỗi quá nhiều. Lỗi không thể kết nối camera, lỗi mic không thể thu tiếng hay người khác nghe nhỏ, chơi game thì tựa game nhẹ như liên quân cũng giật lác đùng đùng. KHÔNG ĐÁNG TIỀN ĐỂ MUA. QUÁ NHIỀU LỖI, QUÁ THẤT VỌNG','SP024','07/06/2022'),
(N'Điện thoại dùng bị lỗi camera kết nối chậm. Rất tệ','SP024','07/06/2022'),

(N'Máy tốt trong tầm giá, tất cả mọi thứ đều ổn','SP024','07/06/2022'),
(N'Máy sài rất mượt , Pin Trâu Chơi Game Quá Ok , Chụp Hình Đẹp , Sản phẩm 5 Sao Ok','SP024','07/06/2022'),
(N'máy dùng rất mượt với tầm tiền','SP024','07/06/2022'),
(N'Máy tốt,mượt ,màn hình sáng Chơi game ổn chụp hình tạm được phải tải thêm app cho 5 sao','SP024','07/06/2022'),
(N'Máy dùng ổn, bắt wifi, 4G rất mạnh, pin dùng bình thường 2 ngày 1 đêm mới phải sạc. Mọi thứ rất ổn trong tầm giá','SP024','07/06/2022'),
(N'Máy dùng tốt,đẹp và sang trọng cấu hình tốt','SP024','07/06/2022'),
(N'Máy đẹp, Pin rất ổn , cất hình tốt ,Rất hài lòng','SP024','07/06/2022'),
(N'Chất lượng sản phẩm tuyệt vời. Tốt trong tầm giá. Cam lồi nhưng cũng ok','SP024','07/06/2022'),
(N'Điện thoại rất tốt rất hài lòng','SP024','07/06/2022'),
(N'Quá tuyệt vời luôn,chơi game bao mượt','SP024','07/06/2022')
-----------------------------------------------------------------------------

-- CREATE PROC sp_AddHD
-- @maHD VARCHAR(10),
-- @tenKH NVARCHAR(50),
-- @tenNV NVARCHAR(50),
-- @soIMEI VARCHAR(16)
-- BẢNG HÓA ĐƠN VÀ CHITIETHD
DECLARE @maHD_ VARCHAR(10)
EXEC sp_GetMaHD @maHD_ OUTPUT
EXEC sp_AddHD @maHD_, N'Lê Thị Linh', N'Đỗ Gia Nguyên', '866592712300001'
EXEC sp_AddHD @maHD_, N'Lê Thị Linh', N'Đỗ Gia Nguyên', '359159074600001'
EXEC sp_AddHD @maHD_, N'Lê Thị Linh', N'Đỗ Gia Nguyên', '865921346900001'
EXEC sp_AddHD @maHD_, N'Lê Thị Linh', N'Đỗ Gia Nguyên', '865921346900002'
UPDATE HOADON set NGTAO = '1/10/2019' WHERE ID = @maHD_

EXEC sp_GetMaHD @maHD_ OUTPUT
EXEC sp_AddHD @maHD_, N'Cao Gia Vinh', N'Từ Huệ Sơn', '359159074600002'
EXEC sp_AddHD @maHD_, N'Cao Gia Vinh', N'Từ Huệ Sơn', '867026129600001'
EXEC sp_AddHD @maHD_, N'Cao Gia Vinh', N'Từ Huệ Sơn', '359159074600003'
UPDATE HOADON set NGTAO = '2019/02/13' WHERE ID = @maHD_

EXEC sp_GetMaHD @maHD_ OUTPUT
EXEC sp_AddHD @maHD_, N'Cao Gia Vinh', N'Đỗ Gia Nguyên', '359115074600001'
EXEC sp_AddHD @maHD_, N'Cao Gia Vinh', N'Đỗ Gia Nguyên', '351492823600001'
EXEC sp_AddHD @maHD_, N'Cao Gia Vinh', N'Đỗ Gia Nguyên', '868643632100005'
UPDATE HOADON set NGTAO = '3/2/2019' WHERE ID = @maHD_

EXEC sp_GetMaHD @maHD_ OUTPUT
EXEC sp_AddHD @maHD_, N'Nguyễn Thị Thương', N'Từ Huệ Sơn', '359159074600006'
EXEC sp_AddHD @maHD_, N'Nguyễn Thị Thương', N'Từ Huệ Sơn', '864723128800006'
EXEC sp_AddHD @maHD_, N'Nguyễn Thị Thương', N'Từ Huệ Sơn', '865795783100004'
EXEC sp_AddHD @maHD_, N'Nguyễn Thị Thương', N'Từ Huệ Sơn', '356592512300006'
UPDATE HOADON set NGTAO = '2019/04/21' WHERE ID = @maHD_

EXEC sp_GetMaHD @maHD_ OUTPUT
EXEC sp_AddHD @maHD_, N'Hồ Minh Ngọc', N'Lê Đức Tài', '359159074600008'
EXEC sp_AddHD @maHD_, N'Hồ Minh Ngọc', N'Lê Đức Tài', '357292722200001'
EXEC sp_AddHD @maHD_, N'Hồ Minh Ngọc', N'Lê Đức Tài', '866494613900001'
EXEC sp_AddHD @maHD_, N'Hồ Minh Ngọc', N'Lê Đức Tài', '868643632100002'
UPDATE HOADON set NGTAO = '2019/05/22' WHERE ID = @maHD_

EXEC sp_GetMaHD @maHD_ OUTPUT
EXEC sp_AddHD @maHD_, N'Lý Gia Huy', N'Nguyễn văn Tèo', '359159074600004'
EXEC sp_AddHD @maHD_, N'Lý Gia Huy', N'Nguyễn văn Tèo', '868643632100004'
EXEC sp_AddHD @maHD_, N'Lý Gia Huy', N'Nguyễn văn Tèo', '864562478100005'
UPDATE HOADON set NGTAO = '2019/06/20' WHERE ID = @maHD_

EXEC sp_GetMaHD @maHD_ OUTPUT
EXEC sp_AddHD @maHD_, N'Nguyễn Văn Cao', N'Nguyễn văn Tèo', '359159074600005'
EXEC sp_AddHD @maHD_, N'Nguyễn Văn Cao', N'Nguyễn văn Tèo', '353415822400007'
EXEC sp_AddHD @maHD_, N'Nguyễn Văn Cao', N'Nguyễn văn Tèo', '866128936700005'
EXEC sp_AddHD @maHD_, N'Nguyễn Văn Cao', N'Nguyễn văn Tèo', '866128936700006'
UPDATE HOADON set NGTAO = '2019/07/14' WHERE ID = @maHD_

EXEC sp_GetMaHD @maHD_ OUTPUT
EXEC sp_AddHD @maHD_, N'Huỳnh Ái Linh', N'Lê Đức Tài', '359159074600007'
EXEC sp_AddHD @maHD_, N'Huỳnh Ái Linh', N'Lê Đức Tài', '357292722200005'
EXEC sp_AddHD @maHD_, N'Huỳnh Ái Linh', N'Lê Đức Tài', '866592712300005'
UPDATE HOADON set NGTAO = '8/2/2019' WHERE ID = @maHD_

EXEC sp_GetMaHD @maHD_ OUTPUT
EXEC sp_AddHD @maHD_, N'Nguyễn Thị Thương', N'Từ Huệ Sơn', '359115074600003'
EXEC sp_AddHD @maHD_, N'Nguyễn Thị Thương', N'Từ Huệ Sơn', '359115074600009'
EXEC sp_AddHD @maHD_, N'Nguyễn Thị Thương', N'Từ Huệ Sơn', '864562478100004'
UPDATE HOADON set NGTAO = '9/11/2019' WHERE ID = @maHD_

EXEC sp_GetMaHD @maHD_ OUTPUT
EXEC sp_AddHD @maHD_, N'Trần Ngọc Sang', N'Lê Đức Tài', '357815726800008'
EXEC sp_AddHD @maHD_, N'Trần Ngọc Sang', N'Lê Đức Tài', '861191504800006'
EXEC sp_AddHD @maHD_, N'Trần Ngọc Sang', N'Lê Đức Tài', '868463907900003'
UPDATE HOADON set NGTAO = '10/4/2019' WHERE ID = @maHD_

EXEC sp_GetMaHD @maHD_ OUTPUT
EXEC sp_AddHD @maHD_, N'Huỳnh Ái Linh', N'Lê Đức Tài', '359115074600005'
EXEC sp_AddHD @maHD_, N'Huỳnh Ái Linh', N'Lê Đức Tài', '862565283700010'
EXEC sp_AddHD @maHD_, N'Huỳnh Ái Linh', N'Lê Đức Tài', '862415812400007'
EXEC sp_AddHD @maHD_, N'Huỳnh Ái Linh', N'Lê Đức Tài', '869626724500004'
UPDATE HOADON set NGTAO = '11/2/2019' WHERE ID = @maHD_

EXEC sp_GetMaHD @maHD_ OUTPUT
EXEC sp_AddHD @maHD_, N'Đỗ Ái Vy', N'Từ Huệ Sơn', '358996074600003'
EXEC sp_AddHD @maHD_, N'Đỗ Ái Vy', N'Từ Huệ Sơn', '357922820900003'
EXEC sp_AddHD @maHD_, N'Đỗ Ái Vy', N'Từ Huệ Sơn', '356231723900005'
EXEC sp_AddHD @maHD_, N'Đỗ Ái Vy', N'Từ Huệ Sơn', '869726074600005'
UPDATE HOADON set NGTAO = '12/12/2019' WHERE ID = @maHD_

EXEC sp_GetMaHD @maHD_ OUTPUT
EXEC sp_AddHD @maHD_, N'Nguyễn Văn Cao', N'Từ Huệ Sơn', '358996074600005'
EXEC sp_AddHD @maHD_, N'Nguyễn Văn Cao', N'Từ Huệ Sơn', '351190504800004'
EXEC sp_AddHD @maHD_, N'Nguyễn Văn Cao', N'Từ Huệ Sơn', '354728926700001'
EXEC sp_AddHD @maHD_, N'Nguyễn Văn Cao', N'Từ Huệ Sơn', '863296725500005'
EXEC sp_AddHD @maHD_, N'Nguyễn Văn Cao', N'Từ Huệ Sơn', '862492723600009'
UPDATE HOADON set NGTAO = '1/2/2020' WHERE ID = @maHD_

EXEC sp_GetMaHD @maHD_ OUTPUT
EXEC sp_AddHD @maHD_, N'Lê Hồng Đào', N'Trần Vũ', '358464607900006'
EXEC sp_AddHD @maHD_, N'Lê Hồng Đào', N'Trần Vũ', '353694604900007'
EXEC sp_AddHD @maHD_, N'Lê Hồng Đào', N'Trần Vũ', '355424843300003'
EXEC sp_AddHD @maHD_, N'Lê Hồng Đào', N'Trần Vũ', '356892841100002'
EXEC sp_AddHD @maHD_, N'Lê Hồng Đào', N'Trần Vũ', '864794604900003'
UPDATE HOADON set NGTAO = '2/2/2020' WHERE ID = @maHD_

EXEC sp_GetMaHD @maHD_ OUTPUT
EXEC sp_AddHD @maHD_, N'Hồ Minh Ngọc', N'Từ Huệ Sơn', '359115074600002'
EXEC sp_AddHD @maHD_, N'Hồ Minh Ngọc', N'Từ Huệ Sơn', '351492823600003'
EXEC sp_AddHD @maHD_, N'Hồ Minh Ngọc', N'Từ Huệ Sơn', '862475618400009'
EXEC sp_AddHD @maHD_, N'Hồ Minh Ngọc', N'Từ Huệ Sơn', '866592712300004'
EXEC sp_AddHD @maHD_, N'Hồ Minh Ngọc', N'Từ Huệ Sơn', '864996729200010'
UPDATE HOADON set NGTAO = '3/11/2020' WHERE ID = @maHD_

EXEC sp_GetMaHD @maHD_ OUTPUT
EXEC sp_AddHD @maHD_, N'Đỗ Ái Vy', N'Nguyễn văn Tèo', '357815726800005'
EXEC sp_AddHD @maHD_, N'Đỗ Ái Vy', N'Nguyễn văn Tèo', '352245934100002'
EXEC sp_AddHD @maHD_, N'Đỗ Ái Vy', N'Nguyễn văn Tèo', '352478618400004'
EXEC sp_AddHD @maHD_, N'Đỗ Ái Vy', N'Nguyễn văn Tèo', '869626724500007'
EXEC sp_AddHD @maHD_, N'Đỗ Ái Vy', N'Nguyễn văn Tèo', '864863516600003'
UPDATE HOADON set NGTAO = '4/3/2020' WHERE ID = @maHD_

EXEC sp_GetMaHD @maHD_ OUTPUT
EXEC sp_AddHD @maHD_, N'Lý Gia Huy', N'Đỗ Gia Nguyên', '358996074600001'
EXEC sp_AddHD @maHD_, N'Lý Gia Huy', N'Đỗ Gia Nguyên', '351492823600004'
EXEC sp_AddHD @maHD_, N'Lý Gia Huy', N'Đỗ Gia Nguyên', '357643621100002'
EXEC sp_AddHD @maHD_, N'Lý Gia Huy', N'Đỗ Gia Nguyên', '863296725500002'
UPDATE HOADON set NGTAO = '5/12/2020' WHERE ID = @maHD_

EXEC sp_GetMaHD @maHD_ OUTPUT
EXEC sp_AddHD @maHD_, N'Huỳnh Ái Linh', N'Đào kim huệ', '359115074600010'
EXEC sp_AddHD @maHD_, N'Huỳnh Ái Linh', N'Đào kim huệ', '358996074600004'
EXEC sp_AddHD @maHD_, N'Huỳnh Ái Linh', N'Đào kim huệ', '354498822100006'
EXEC sp_AddHD @maHD_, N'Huỳnh Ái Linh', N'Đào kim huệ', '357999902100005'
EXEC sp_AddHD @maHD_, N'Huỳnh Ái Linh', N'Đào kim huệ', '352478618400009'
UPDATE HOADON set NGTAO = '5/12/2020' WHERE ID = @maHD_

EXEC sp_GetMaHD @maHD_ OUTPUT
EXEC sp_AddHD @maHD_, N'Đỗ Ái Vy', N'Lê Đức Tài', '358996074600006'
EXEC sp_AddHD @maHD_, N'Đỗ Ái Vy', N'Lê Đức Tài', '359296725500001'
EXEC sp_AddHD @maHD_, N'Đỗ Ái Vy', N'Lê Đức Tài', '357815726800002'
EXEC sp_AddHD @maHD_, N'Đỗ Ái Vy', N'Lê Đức Tài', '357999902100002'
EXEC sp_AddHD @maHD_, N'Đỗ Ái Vy', N'Lê Đức Tài', '351555223700008'
EXEC sp_AddHD @maHD_, N'Đỗ Ái Vy', N'Lê Đức Tài', '868792902100008'
UPDATE HOADON set NGTAO = '6/7/2020' WHERE ID = @maHD_

EXEC sp_GetMaHD @maHD_ OUTPUT
EXEC sp_AddHD @maHD_, N'Hồ Minh Ngọc', N'vũ thanh long', '355763506600007'
EXEC sp_AddHD @maHD_, N'Hồ Minh Ngọc', N'vũ thanh long', '357643621100010'
EXEC sp_AddHD @maHD_, N'Hồ Minh Ngọc', N'vũ thanh long', '354462478100002'
EXEC sp_AddHD @maHD_, N'Hồ Minh Ngọc', N'vũ thanh long', '862415812400005'
EXEC sp_AddHD @maHD_, N'Hồ Minh Ngọc', N'vũ thanh long', '862492723600001'
EXEC sp_AddHD @maHD_, N'Hồ Minh Ngọc', N'vũ thanh long', '865921346900010'
EXEC sp_AddHD @maHD_, N'Hồ Minh Ngọc', N'vũ thanh long', '862475618400010'
UPDATE HOADON set NGTAO = '7/2/2020' WHERE ID = @maHD_

EXEC sp_GetMaHD @maHD_ OUTPUT
EXEC sp_AddHD @maHD_, N'Lê Hồng Đào', N'Trần Vũ', '353415822400009'
EXEC sp_AddHD @maHD_, N'Lê Hồng Đào', N'Trần Vũ', '356926829600002'
EXEC sp_AddHD @maHD_, N'Lê Hồng Đào', N'Trần Vũ', '356926829600008'
EXEC sp_AddHD @maHD_, N'Lê Hồng Đào', N'Trần Vũ', '357643621100005'
EXEC sp_AddHD @maHD_, N'Lê Hồng Đào', N'Trần Vũ', '865795783100008'
UPDATE HOADON set NGTAO = '8/11/2020' WHERE ID = @maHD_

EXEC sp_GetMaHD @maHD_ OUTPUT
EXEC sp_AddHD @maHD_, N'Nguyễn Văn Cao', N'Lý Tường', '358996074600009'
EXEC sp_AddHD @maHD_, N'Nguyễn Văn Cao', N'Lý Tường', '353623728800008'
EXEC sp_AddHD @maHD_, N'Nguyễn Văn Cao', N'Lý Tường', '354462478100009'
EXEC sp_AddHD @maHD_, N'Nguyễn Văn Cao', N'Lý Tường', '869626724500005'
EXEC sp_AddHD @maHD_, N'Nguyễn Văn Cao', N'Lý Tường', '867026129600007'
UPDATE HOADON set NGTAO = '9/2/2020' WHERE ID = @maHD_

EXEC sp_GetMaHD @maHD_ OUTPUT
EXEC sp_AddHD @maHD_, N'Lê Hồng Đào', N'Trần Vũ', '359096724500001'
EXEC sp_AddHD @maHD_, N'Lê Hồng Đào', N'Trần Vũ', '356926829600007'
EXEC sp_AddHD @maHD_, N'Lê Hồng Đào', N'Trần Vũ', '353694604900004'
EXEC sp_AddHD @maHD_, N'Lê Hồng Đào', N'Trần Vũ', '354911646900004'
EXEC sp_AddHD @maHD_, N'Lê Hồng Đào', N'Trần Vũ', '354763643800007'
UPDATE HOADON set NGTAO = '9/4/2020' WHERE ID = @maHD_

EXEC sp_GetMaHD @maHD_ OUTPUT
EXEC sp_AddHD @maHD_, N'Hồ Minh Ngọc', N'Đỗ Gia Nguyên', '359096724500003'
EXEC sp_AddHD @maHD_, N'Hồ Minh Ngọc', N'Đỗ Gia Nguyên', '354498822100002'
EXEC sp_AddHD @maHD_, N'Hồ Minh Ngọc', N'Đỗ Gia Nguyên', '357793502700009'
EXEC sp_AddHD @maHD_, N'Hồ Minh Ngọc', N'Đỗ Gia Nguyên', '355632926800010'
EXEC sp_AddHD @maHD_, N'Hồ Minh Ngọc', N'Đỗ Gia Nguyên', '869726074600001'
EXEC sp_AddHD @maHD_, N'Hồ Minh Ngọc', N'Đỗ Gia Nguyên', '868463907900008'
UPDATE HOADON set NGTAO = '10/1/2020' WHERE ID = @maHD_

EXEC sp_GetMaHD @maHD_ OUTPUT
EXEC sp_AddHD @maHD_, N'Huỳnh Ái Linh', N'Đỗ Gia Nguyên', '358996074600010'
EXEC sp_AddHD @maHD_, N'Huỳnh Ái Linh', N'Đỗ Gia Nguyên', '359096724500005'
EXEC sp_AddHD @maHD_, N'Huỳnh Ái Linh', N'Đỗ Gia Nguyên', '352245934100005'
EXEC sp_AddHD @maHD_, N'Huỳnh Ái Linh', N'Đỗ Gia Nguyên', '352546812800007'
EXEC sp_AddHD @maHD_, N'Huỳnh Ái Linh', N'Đỗ Gia Nguyên', '868928475100002'
UPDATE HOADON set NGTAO = '11/5/2020' WHERE ID = @maHD_

EXEC sp_GetMaHD @maHD_ OUTPUT
EXEC sp_AddHD @maHD_, N'Lý Gia Huy', N'Lê Đức Tài', '359096724500009'
EXEC sp_AddHD @maHD_, N'Lý Gia Huy', N'Lê Đức Tài', '354911646900010'
EXEC sp_AddHD @maHD_, N'Lý Gia Huy', N'Lê Đức Tài', '866128936700007'
EXEC sp_AddHD @maHD_, N'Lý Gia Huy', N'Lê Đức Tài', '865672936800002'
EXEC sp_AddHD @maHD_, N'Lý Gia Huy', N'Lê Đức Tài', '865672936800007'
EXEC sp_AddHD @maHD_, N'Lý Gia Huy', N'Lê Đức Tài', '868928475100005'
UPDATE HOADON set NGTAO = '12/12/2020' WHERE ID = @maHD_

EXEC sp_GetMaHD @maHD_ OUTPUT
EXEC sp_AddHD @maHD_, N'Lý Gia Huy', N'Lê Đức Tài', '351492823600006'
EXEC sp_AddHD @maHD_, N'Lý Gia Huy', N'Lê Đức Tài', '354462478100005'
EXEC sp_AddHD @maHD_, N'Lý Gia Huy', N'Lê Đức Tài', '352478618400001'
EXEC sp_AddHD @maHD_, N'Lý Gia Huy', N'Lê Đức Tài', '866128936700002'
EXEC sp_AddHD @maHD_, N'Lý Gia Huy', N'Lê Đức Tài', '865672936800006'
UPDATE HOADON set NGTAO = '12/1/2020' WHERE ID = @maHD_

EXEC sp_GetMaHD @maHD_ OUTPUT
EXEC sp_AddHD @maHD_, N'Lê Thị Linh', N'Đỗ Gia Nguyên', '358996074600008'
EXEC sp_AddHD @maHD_, N'Lê Thị Linh', N'Đỗ Gia Nguyên', '353694604900003'
EXEC sp_AddHD @maHD_, N'Lê Thị Linh', N'Đỗ Gia Nguyên', '868026074600002'
UPDATE HOADON set NGTAO = '1/12/2021' WHERE ID = @maHD_

EXEC sp_GetMaHD @maHD_ OUTPUT
EXEC sp_AddHD @maHD_, N'Cao Gia Vinh', N'Từ Huệ Sơn', '861191504800007'
EXEC sp_AddHD @maHD_, N'Cao Gia Vinh', N'Từ Huệ Sơn', '866239905000002'
EXEC sp_AddHD @maHD_, N'Cao Gia Vinh', N'Từ Huệ Sơn', '864996729200007'
UPDATE HOADON set NGTAO = '1/12/2021' WHERE ID = @maHD_

EXEC sp_GetMaHD @maHD_ OUTPUT
EXEC sp_AddHD @maHD_, N'Cao Gia Vinh', N'Đỗ Gia Nguyên', '351190504800006'
EXEC sp_AddHD @maHD_, N'Cao Gia Vinh', N'Đỗ Gia Nguyên', '351555223700009'
EXEC sp_AddHD @maHD_, N'Cao Gia Vinh', N'Đỗ Gia Nguyên', '863922830900010'
UPDATE HOADON set NGTAO = '2/2/2021' WHERE ID = @maHD_

EXEC sp_GetMaHD @maHD_ OUTPUT
EXEC sp_AddHD @maHD_, N'Nguyễn Thị Thương', N'Từ Huệ Sơn', '353623728800003'
EXEC sp_AddHD @maHD_, N'Nguyễn Thị Thương', N'Từ Huệ Sơn', '357516244700003'
EXEC sp_AddHD @maHD_, N'Nguyễn Thị Thương', N'Từ Huệ Sơn', '863922830900009'
UPDATE HOADON set NGTAO = '2/6/2021' WHERE ID = @maHD_

EXEC sp_GetMaHD @maHD_ OUTPUT
EXEC sp_AddHD @maHD_, N'Hồ Minh Ngọc', N'Lê Đức Tài', '351492823600010'
EXEC sp_AddHD @maHD_, N'Hồ Minh Ngọc', N'Lê Đức Tài', '354728926700009'
EXEC sp_AddHD @maHD_, N'Hồ Minh Ngọc', N'Lê Đức Tài', '867992721200004'
UPDATE HOADON set NGTAO = '2/5/2021' WHERE ID = @maHD_

EXEC sp_GetMaHD @maHD_ OUTPUT
EXEC sp_AddHD @maHD_, N'Lý Gia Huy', N'Nguyễn văn Tèo', '353296244500005'
EXEC sp_AddHD @maHD_, N'Lý Gia Huy', N'Nguyễn văn Tèo', '354911646900001'
EXEC sp_AddHD @maHD_, N'Lý Gia Huy', N'Nguyễn văn Tèo', '865795783100009'
UPDATE HOADON set NGTAO = '3/3/2021' WHERE ID = @maHD_

EXEC sp_GetMaHD @maHD_ OUTPUT
EXEC sp_AddHD @maHD_, N'Nguyễn Văn Cao', N'Nguyễn văn Tèo', '357922820900005'
EXEC sp_AddHD @maHD_, N'Nguyễn Văn Cao', N'Nguyễn văn Tèo', '356129905000002'
EXEC sp_AddHD @maHD_, N'Nguyễn Văn Cao', N'Nguyễn văn Tèo', '867912726800008'
EXEC sp_AddHD @maHD_, N'Nguyễn Văn Cao', N'Nguyễn văn Tèo', '864863516600001'
UPDATE HOADON set NGTAO = '3/4/2021' WHERE ID = @maHD_

EXEC sp_GetMaHD @maHD_ OUTPUT
EXEC sp_AddHD @maHD_, N'Huỳnh Ái Linh', N'Lê Đức Tài', '356129905000006'
EXEC sp_AddHD @maHD_, N'Huỳnh Ái Linh', N'Lê Đức Tài', '357999902100006'
EXEC sp_AddHD @maHD_, N'Huỳnh Ái Linh', N'Lê Đức Tài', '358619388700007'
EXEC sp_AddHD @maHD_, N'Huỳnh Ái Linh', N'Lê Đức Tài', '869726074600002'
EXEC sp_AddHD @maHD_, N'Huỳnh Ái Linh', N'Lê Đức Tài', '864863516600004'
UPDATE HOADON set NGTAO = '4/3/2021' WHERE ID = @maHD_

EXEC sp_GetMaHD @maHD_ OUTPUT
EXEC sp_AddHD @maHD_, N'Nguyễn Thị Thương', N'Từ Huệ Sơn', '867912726800009'
EXEC sp_AddHD @maHD_, N'Nguyễn Thị Thương', N'Từ Huệ Sơn', '862415812400009'
EXEC sp_AddHD @maHD_, N'Nguyễn Thị Thương', N'Từ Huệ Sơn', '865672936800001'
EXEC sp_AddHD @maHD_, N'Nguyễn Thị Thương', N'Từ Huệ Sơn', '862475618400005'
UPDATE HOADON set NGTAO = '5/12/2021' WHERE ID = @maHD_

EXEC sp_GetMaHD @maHD_ OUTPUT
EXEC sp_AddHD @maHD_, N'Trần Ngọc Sang', N'Lê Đức Tài', '351190504800007'
EXEC sp_AddHD @maHD_, N'Trần Ngọc Sang', N'Lê Đức Tài', '354462478100001'
EXEC sp_AddHD @maHD_, N'Trần Ngọc Sang', N'Lê Đức Tài', '862415812400001'
UPDATE HOADON set NGTAO = '6/11/2021' WHERE ID = @maHD_

EXEC sp_GetMaHD @maHD_ OUTPUT
EXEC sp_AddHD @maHD_, N'Lý Gia Huy', N'Nguyễn văn Tèo', '357999902100008'
EXEC sp_AddHD @maHD_, N'Lý Gia Huy', N'Nguyễn văn Tèo', '352245934100007'
EXEC sp_AddHD @maHD_, N'Lý Gia Huy', N'Nguyễn văn Tèo', '867026129600008'
UPDATE HOADON set NGTAO = '6/1/2021' WHERE ID = @maHD_

EXEC sp_GetMaHD @maHD_ OUTPUT
EXEC sp_AddHD @maHD_, N'Nguyễn Thị Thương', N'Trần Vũ', '355763506600004'
EXEC sp_AddHD @maHD_, N'Nguyễn Thị Thương', N'Trần Vũ', '356231723900007'
EXEC sp_AddHD @maHD_, N'Nguyễn Thị Thương', N'Trần Vũ', '869626724500003'
EXEC sp_AddHD @maHD_, N'Nguyễn Thị Thương', N'Trần Vũ', '868643632100001'
UPDATE HOADON set NGTAO = '7/12/2021' WHERE ID = @maHD_

EXEC sp_GetMaHD @maHD_ OUTPUT
EXEC sp_AddHD @maHD_, N'Huỳnh Ái Linh', N'Lê Đức Tài', '355763506600010'
EXEC sp_AddHD @maHD_, N'Huỳnh Ái Linh', N'Lê Đức Tài', '356129905000005'
EXEC sp_AddHD @maHD_, N'Huỳnh Ái Linh', N'Lê Đức Tài', '354763643800009'
EXEC sp_AddHD @maHD_, N'Huỳnh Ái Linh', N'Lê Đức Tài', '863645134100002'
UPDATE HOADON set NGTAO = '7/5/2021' WHERE ID = @maHD_

EXEC sp_GetMaHD @maHD_ OUTPUT
EXEC sp_AddHD @maHD_, N'Đỗ Ái Vy', N'Trần Vũ', '352245934100006'
EXEC sp_AddHD @maHD_, N'Đỗ Ái Vy', N'Trần Vũ', '352546812800004'
EXEC sp_AddHD @maHD_, N'Đỗ Ái Vy', N'Trần Vũ', '865498812100010'
UPDATE HOADON set NGTAO = '8/12/2021' WHERE ID = @maHD_

EXEC sp_GetMaHD @maHD_ OUTPUT
EXEC sp_AddHD @maHD_, N'Lý Gia Huy', N'Lý Tường', '353296244500007'
EXEC sp_AddHD @maHD_, N'Lý Gia Huy', N'Lý Tường', '355424843300009'
EXEC sp_AddHD @maHD_, N'Lý Gia Huy', N'Lý Tường', '356892841100007'
EXEC sp_AddHD @maHD_, N'Lý Gia Huy', N'Lý Tường', '866234723900009'
EXEC sp_AddHD @maHD_, N'Lý Gia Huy', N'Lý Tường', '864261643800007'
UPDATE HOADON set NGTAO = '8/6/2021' WHERE ID = @maHD_

EXEC sp_GetMaHD @maHD_ OUTPUT
EXEC sp_AddHD @maHD_, N'Cao Gia Vinh', N'Lê Đức Tài', '358996074600007'
EXEC sp_AddHD @maHD_, N'Cao Gia Vinh', N'Lê Đức Tài', '353694604900006'
EXEC sp_AddHD @maHD_, N'Cao Gia Vinh', N'Lê Đức Tài', '863296725500006'
EXEC sp_AddHD @maHD_, N'Cao Gia Vinh', N'Lê Đức Tài', '865921346900008'
EXEC sp_AddHD @maHD_, N'Cao Gia Vinh', N'Lê Đức Tài', '864723128800002'
UPDATE HOADON set NGTAO = '9/7/2021' WHERE ID = @maHD_

EXEC sp_GetMaHD @maHD_ OUTPUT
EXEC sp_AddHD @maHD_, N'Đỗ Ái Vy', N'Trần Vũ', '354911646900008'
EXEC sp_AddHD @maHD_, N'Đỗ Ái Vy', N'Trần Vũ', '353623728800001'
EXEC sp_AddHD @maHD_, N'Đỗ Ái Vy', N'Trần Vũ', '863296725500001'
EXEC sp_AddHD @maHD_, N'Đỗ Ái Vy', N'Trần Vũ', '867992721200003'
EXEC sp_AddHD @maHD_, N'Đỗ Ái Vy', N'Trần Vũ', '862475618400002'
UPDATE HOADON set NGTAO = '9/12/2021' WHERE ID = @maHD_

EXEC sp_GetMaHD @maHD_ OUTPUT
EXEC sp_AddHD @maHD_, N'Lê Hồng Đào', N'Lê Đức Tài', '359096724500004'
EXEC sp_AddHD @maHD_, N'Lê Hồng Đào', N'Lê Đức Tài', '353296244500006'
EXEC sp_AddHD @maHD_, N'Lê Hồng Đào', N'Lê Đức Tài', '352546812800002'
EXEC sp_AddHD @maHD_, N'Lê Hồng Đào', N'Lê Đức Tài', '867992721200005'
EXEC sp_AddHD @maHD_, N'Lê Hồng Đào', N'Lê Đức Tài', '863186244500004'
EXEC sp_AddHD @maHD_, N'Lê Hồng Đào', N'Lê Đức Tài', '868928475100010'
UPDATE HOADON set NGTAO = '10/11/2021' WHERE ID = @maHD_

EXEC sp_GetMaHD @maHD_ OUTPUT
EXEC sp_AddHD @maHD_, N'Nguyễn Thị Thương', N'vũ thanh long', '359296725500002'
EXEC sp_AddHD @maHD_, N'Nguyễn Thị Thương', N'vũ thanh long', '351190504800010'
EXEC sp_AddHD @maHD_, N'Nguyễn Thị Thương', N'vũ thanh long', '357999902100003'
EXEC sp_AddHD @maHD_, N'Nguyễn Thị Thương', N'vũ thanh long', '868026074600003'
EXEC sp_AddHD @maHD_, N'Nguyễn Thị Thương', N'vũ thanh long', '866494613900010'
EXEC sp_AddHD @maHD_, N'Nguyễn Thị Thương', N'vũ thanh long', '862565283700005'
UPDATE HOADON set NGTAO = '10/10/2021' WHERE ID = @maHD_

EXEC sp_GetMaHD @maHD_ OUTPUT
EXEC sp_AddHD @maHD_, N'Nguyễn Văn Cao', N'Từ Huệ Sơn', '355763506600002'
EXEC sp_AddHD @maHD_, N'Nguyễn Văn Cao', N'Từ Huệ Sơn', '356231723900004'
EXEC sp_AddHD @maHD_, N'Nguyễn Văn Cao', N'Từ Huệ Sơn', '354763643800008'
EXEC sp_AddHD @maHD_, N'Nguyễn Văn Cao', N'Từ Huệ Sơn', '865498812100008'
EXEC sp_AddHD @maHD_, N'Nguyễn Văn Cao', N'Từ Huệ Sơn', '866592712300002'
UPDATE HOADON set NGTAO = '11/11/2021' WHERE ID = @maHD_

EXEC sp_GetMaHD @maHD_ OUTPUT
EXEC sp_AddHD @maHD_, N'Cao Gia Vinh', N'Từ Huệ Sơn', '359115074600006'
EXEC sp_AddHD @maHD_, N'Cao Gia Vinh', N'Từ Huệ Sơn', '355494623900003'
EXEC sp_AddHD @maHD_, N'Cao Gia Vinh', N'Từ Huệ Sơn', '863645134100007'
EXEC sp_AddHD @maHD_, N'Cao Gia Vinh', N'Từ Huệ Sơn', '865427849300005'
UPDATE HOADON set NGTAO = '11/2/2021' WHERE ID = @maHD_

EXEC sp_GetMaHD @maHD_ OUTPUT
EXEC sp_AddHD @maHD_, N'Huỳnh Ái Linh', N'Lý Tường', '356892841100003'
EXEC sp_AddHD @maHD_, N'Huỳnh Ái Linh', N'Lý Tường', '869259074600002'
EXEC sp_AddHD @maHD_, N'Huỳnh Ái Linh', N'Lý Tường', '868463907900002'
EXEC sp_AddHD @maHD_, N'Huỳnh Ái Linh', N'Lý Tường', '864261643800005'
UPDATE HOADON set NGTAO = '12/5/2021' WHERE ID = @maHD_

EXEC sp_GetMaHD @maHD_ OUTPUT
EXEC sp_AddHD @maHD_, N'Nguyễn Thị Thương', N'vũ thanh long', '354728926700003'
EXEC sp_AddHD @maHD_, N'Nguyễn Thị Thương', N'vũ thanh long', '356592512300008'
EXEC sp_AddHD @maHD_, N'Nguyễn Thị Thương', N'vũ thanh long', '868783502700004'
EXEC sp_AddHD @maHD_, N'Nguyễn Thị Thương', N'vũ thanh long', '864562478100008'
EXEC sp_AddHD @maHD_, N'Nguyễn Thị Thương', N'vũ thanh long', '866592712300006'
UPDATE HOADON set NGTAO = '12/11/2021' WHERE ID = @maHD_

SET DATEFORMAT DMY
INSERT INTO PHIEUKIEMKHO
VALUES
	('PKK001','NV001','10/05/2022',NULL,'09:00:00',NULL,0),
	('PKK002','NV002','10/04/2022',NULL,'09:00:00',NULL,0),
	('PKK003','NV003','12/05/2022',NULL,'09:00:00',NULL,0),
	('PKK004','NV004','16/03/2022',NULL,'09:00:00',NULL,0),
	('PKK005','NV005','13/05/2022',NULL,'09:00:00',NULL,0)

INSERT INTO CT_PHIEUKIEMKHO
VALUES
	('SP001','PKK001',10,NULL,NULL,NULL),
	('SP002','PKK001',10,NULL,NULL,NULL),
	('SP003','PKK002',10,NULL,NULL,NULL),
	('SP004','PKK002',10,NULL,NULL,NULL),
	('SP005','PKK003',10,NULL,NULL,NULL),
	('SP006','PKK003',10,NULL,NULL,NULL),
	('SP007','PKK004',10,NULL,NULL,NULL),
	('SP008','PKK004',10,NULL,NULL,NULL),
	('SP009','PKK005',10,NULL,NULL,NULL),
	('SP010','PKK005',10,NULL,NULL,NULL)

------------------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------------------
-------------------------------------    DEBUG     ---------------------------------------------------
------------------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------------------
/* 
SELECT * FROM SANPHAM
update SANPHAM set hinhanh='' where id = 'sp078'
SELECT * FROM CauHinh
SELECT * FROM danhmuc
select * from loaisp
SELECT * FROM HOADON
SELECT * FROM CHITIETHD
SELECT * FROM DONGIA
select * from thongtintaikhoan
select * from KHACHHANG
select * from nhanvien

select * from thongtintaikhoan join khachhang on thongtintaikhoan.id_TaiKhoan=khachhang.id_tk

select * from sanpham join cauhinh on cauhinh.id_SP=sanpham.id

select * from taikhoan
select * from nhanvien nv join taikhoan tk on nv.id_tk=tk.id join thongtintaikhoan tttk on tttk.id_taikhoan=tk.id

EXEC sp_UpTTTK 'NV001', N'Từ Huệ Sơn', '2-5-2001', N'nam', 'tuhueson@gmail.com', '0938252793', ''

EXEC sp_GetKhachHang

exec sp_CKAcc 'tuhueson', '123', N'Nhân Viên'
EXEC sp_ChangeAcc 'admin', '123', N'Admin'

select nv.id, tk.id idtk, hoten, tinhtrang, ngsinh, gtinh, ngtao, email, sdt, dchi from nhanvien nv join taikhoan tk on nv.id_tk=tk.id join thongtintaikhoan tttk on tttk.id_taikhoan=tk.id where hoten like '%T%'

tìm kiếm nhân viên
select nv.id, hoten, tinhtrang, ngsinh, gtinh, ngtao, email, sdt, dchi from nhanvien nv join taikhoan tk on nv.id_tk=tk.id join thongtintaikhoan tttk on tttk.id_taikhoan=tk.id where nv.id = 'nv001'

select * from sanpham join danhmuc on sanpham.id_danhmuc=danhmuc.id left join dongia on dongia.id_sp=sanpham.id where dongia.id=(select top 1 dg.id from dongia dg where dg.id_sp=sanpham.id order by dg.id desc)

delete taikhoan where username = 'abc'


select * from sanpham left join dongia on dongia.id_sp=sanpham.id where dongia.id=(select top 1 dg.id from dongia dg where dg.id_sp=sanpham.id)


REPORT
exec sp_ReportHD 2021

sp_ReportBill 'HD001', 153450000


select ngtao, sum(dongia) from hoadon where year(ngtao)=2020 group by ngtao

select * from KhachHang


sp_ChartSanPham 2021
sp_ChartNhanVien 2020
sp_ChartDoanhThu 2020

select * from hoadon
exec sp_CKUsername 's', N'Nhân Viên'
select * from sanpham
select * from danhmuc
		-------------------------------------- debug lấy đơn giá ---------------------------------------
		SELECT SUM(GIA)
		FROM DONGIA
			WHERE id_sp = 'sp001'
			GROUP BY NGCAPNHAT
			ORDER BY NGCAPNHAT DESC
			select * from dongia
		-------------------------------------- debug ---------------------------------------

XEM SỐ LƯỢNG SP
SELECT TENSP, COUNT(MA) SOLUONG
FROM SANPHAM SP JOIN IMEICODE
    ON SP.ID = IMEICODE.ID_SP
WHERE TRANGTHAI = 1
GROUP BY TENSP

exec sp_chitietdonhang_kh 'kh003'

select * from phieunhap

select * from IMEICODE
*/
