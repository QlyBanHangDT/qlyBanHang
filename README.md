# QlyBanHang

# Thành Viên
| MSSV          | Họ tên       |
| :---:         | :---:        |
| 2001190791    | Từ Huệ Sơn   |
| 2001190794    | Lê Đức Tài   |

# Nghiệp vụ
- [x] Quản lý sản phẩm theo số imei/serial
    - Số IMEI (***International Mobile Equipment Identity***) là một mã định danh duy nhất trên mỗi thiết bị
        - [thông tin cơ bản về imei](https://en.wikipedia.org/wiki/International_Mobile_Equipment_Identity)
        - [giải mã số imei](https://en.tab-tv.com/?p=18840)
    - [link tham khảo 1](https://www.kiotviet.vn/huong-dan-su-dung-kiotviet/huong-dan-hang-hoa/hang-hoa-serial-imei/)
    - [Quản lý nhập xuất hàng theo mã imei](https://eshop.misa.vn/help/vi/kb/quan_ly_hang_hoa_theo_serialimei)
- Kiểm tra tồn kho
    - Lập phiếu kiểm kho
        - 1 phiếu kiểm kho bao gồm:
            - Mã
            - Thời gian lập
            - Tổng số lượng lệch
            - Các thông tin chi tiết 
                - Mã sản phẩm
                - Số lượng tồn kho trong hệ thống
                - Số lượng thực tế
        - Công thức tính: Giá trị lệch = Số lượng lệch * Giá vốn tại thời điểm tạo phiếu kiểm kho
        - [link tham khảo](https://www.kiotviet.vn/huong-dan-su-dung-kiotviet/huong-dan-kiem-kho/tao-phieu-kiem-kho/)
- [x] Quản lý thông tin khách hàng
    - [x] Thông tin cơ bản
    - [x] Lịch sử mua hàng
    - [x] Điểm tích lũy
- [x] Mua/bán hàng
    - [x] Tìm kiếm/nhập sản phẩm theo số imei/tên
    - [x] Thực hiện thanh toán & xuất hóa đơn
    - [ ] report nhập hàng
- AI: Đánh giá cảm xúc khách hàng thông qua bình luận
    - Dùng thuật toán ***bayes*** để phân loại (tích cực | tiêu cực)
    - TF-IDF (***Term Frequency – Inverse Document Frequency***): để phân tích đoạn bình luận
