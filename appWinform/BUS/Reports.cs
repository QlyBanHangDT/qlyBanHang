using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using DTO;
using Syncfusion.XlsIO;
using System.Windows.Forms;

namespace BUS
{
    public class Reports<T>
    {
        private bool _IsPringPriview = false;
        private static IWorkbook workbook;

        private static void PrinPriview(string fileToPrint)
        {
            if (string.IsNullOrEmpty(fileToPrint))
            {
                return;
            }

            Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook wb = null;

            try
            {
                wb = excelApp.Workbooks.Open(fileToPrint);

                if (wb != null)
                {
                    // Show print preview
                    excelApp.Visible = true;
                    wb.PrintPreview(true);
                }
            }
            catch (Exception ex)
            {
                //ShowMessage
                throw ex;
            }
            finally
            {
                // Cleanup:
                GC.Collect();
                GC.WaitForPendingFinalizers();

                wb.Close(false, Type.Missing, Type.Missing);
                Marshal.FinalReleaseComObject(wb);

                excelApp.Quit();
                Marshal.FinalReleaseComObject(excelApp);
            }
        }

        private static string SaveFile()
        {
            string result = string.Empty;

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = Constants.FILTER_EXCEL;
            saveFileDialog.AddExtension = true;
            saveFileDialog.DefaultExt = Constants.FILE_EXT_XLSX;

            if (saveFileDialog.ShowDialog() == DialogResult.OK && saveFileDialog.CheckPathExists)
            {
                workbook.SaveAs(saveFileDialog.FileName);
                result = saveFileDialog.FileName;
            }

            return result;
        }

        /// <summary>
        /// Opens the file.
        /// </summary>
        /// <param name="pPathFile">The p path file.</param>
        private static void OpenFile(string pPathFile)
        {
            if (string.IsNullOrEmpty(pPathFile))
            {
                return;
            }

            if (MessageBox.Show("Bạn muốn mở file", "Thông tin", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                System.Diagnostics.Process proc = new System.Diagnostics.Process();
                proc.StartInfo.FileName = pPathFile;
                proc.Start();
            }
        }

        public static void export(IList<T> data, string pObj, string pFileName, object dataOther = null)
        {
            using (ExcelEngine excelEngine = new ExcelEngine())
            {
                IApplication application = excelEngine.Excel;
                application.DefaultVersion = ExcelVersion.Excel2013;
                workbook = application.Workbooks.Open(pFileName + ".xlsx");
                IWorksheet worksheet = workbook.Worksheets[0];

                //Create template marker processor for the workbook
                ITemplateMarkersProcessor marker = workbook.CreateTemplateMarkersProcessor();

                //GetSalesReports method returns list of sales persons and their reports
                IList<T> reports = data;

                //Adding reports collection to marker variables
                //Where the name should match with the input template
                marker.AddVariable(pObj, reports);

                switch (pObj)
                {
                    case "IMEICODE":
                        {
                            marker.AddVariable("TenSP", ((List<ImeiCode>)reports)[0].TenSP);
                        } break;
                    default:
                        break;
                }

                //Applying Markers
                marker.ApplyMarkers();

                //Saving the workbook
                workbook.SaveAs(pFileName + "Result.xlsx");

                // print preview 
                string urlPriview = string.Format("{0}/{1}", Directory.GetCurrentDirectory(), pFileName + "Result.xlsx");
                
                PrinPriview(urlPriview);
                File.Delete(urlPriview);

                if (MessageBox.Show("Bạn muốn lưu kết quả?", "Thông tin", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    OpenFile(SaveFile());
                }
            }
        }
    }
}
