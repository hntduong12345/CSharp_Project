using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using Excel = Microsoft.Office.Interop.Excel;

namespace ChooseExelFolder
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            dataGridView1.Columns.Add("No.", "No.");
            dataGridView1.Hide();
            btnClose.Hide();
        }

        Excel.Application xlApp = new Excel.Application();
        Excel.Workbook xlWorkBook;
        Excel.Worksheet xlWorkSheet;

        private void btnChooseFolder_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                txtFolderName.Text = folderBrowserDialog1.SelectedPath;

                //Take Excel File Path.
                List<string> filePath = new List<string>();
                filePath = ScanFileInDirectory(txtFolderName.Text);

                foreach (string file in filePath)
                {
                    listBox1.Items.Add(file);
                }


            }
        }

        /// <summary>
        /// Scan directory and return a list of file path with *.xls extension
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>

        private List<string> ScanFileInDirectory(string path)
        {
            List<string> list = Directory.GetFiles(path, "*.xlsx", SearchOption.AllDirectories).ToList();
            //List<string> list = Directory.GetFiles(path, "*.xls", SearchOption.AllDirectories).ToList();

            return list;
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
            {
                var fileName = listBox1.SelectedItems[0];
                var fullPath = txtFolderName.Text + "\\" + fileName;
                //MessageBox.Show(fullPath);
                //ParseExcel(fullPath);
                List<StudentCourse> studentList = ParseExcel(fileName.ToString());
                dataGridView1.DataSource = studentList;

                dataGridView1.Show();
                btnClose.Show();
            }
        }

        private List<StudentCourse> ParseExcel(string xlsFile)
        {
            //open excel workbook
            //get first sheet
            //Scane each row
            // read data and convert to StudentCourse obj
            // Add to list
            // return

            List<StudentCourse> studentList = new List<StudentCourse>();

            //Interdrop            
            //xlApp = new Excel.Application();
            //xlWorkBook = xlApp.Workbooks.Open(xlsFile);           
            //xlWorkSheet = xlWorkBook.Worksheets["Sheet1"];


            //for (int iRow = 2; iRow <= xlWorkSheet.Rows.Count; iRow++)  
            //{
            //    StudentCourse studentCourse = 
            //        new StudentCourse() { 
            //            CourseName = xlWorkSheet.Cells[iRow, 1].value,
            //            StudentID = xlWorkSheet.Cells[iRow, 2].value,
            //            Email = xlWorkSheet.Cells[iRow, 3].value,
            //            FullName = xlWorkSheet.Cells[iRow, 4].value,
            //        };
            //    studentList.Add(studentCourse);
            //}

            //xlWorkBook.Close();
            //xlApp.Quit();


            //SpreadsheetDocument
            using (SpreadsheetDocument doc = SpreadsheetDocument.Open(xlsFile, false))
            {
                WorkbookPart workbookPart = doc.WorkbookPart;
                SharedStringTablePart sstpart = workbookPart.GetPartsOfType<SharedStringTablePart>().First();
                SharedStringTable sst = sstpart.SharedStringTable;

                WorksheetPart worksheetPart = workbookPart.WorksheetParts.First();
                SheetData sheetData = worksheetPart.Worksheet.Elements<SheetData>().First();

                int numRows = sheetData.Elements<Row>().Count();
                for (int r = 1; r < numRows; r++)
                {
                    Row row = sheetData.Elements<Row>().ElementAt(r);
                    StudentCourse studentCourse = new StudentCourse();
                    int count = 1;

                    foreach (Cell c in row.Elements<Cell>())
                    {
                        if (c.DataType != null && c.DataType == CellValues.SharedString)
                        {
                            int ssid = Convert.ToInt32(c.CellValue.Text);
                            string result = sst.ChildElements[ssid].InnerText;
                            if (result != string.Empty)
                            {
                                switch (count)
                                {
                                    case 1:
                                        studentCourse.CourseName = result;
                                        break;
                                    case 2:
                                        studentCourse.StudentID = result;
                                        break;
                                    case 3:
                                        studentCourse.Email = result;
                                        break;
                                    case 4:
                                        studentCourse.FullName = result;
                                        break;
                                }
                                count++;
                            }
                        }
                        else if (c.DataType != null)
                        {
                            MessageBox.Show($"Cell contents: {c.CellValue.Text}");
                        }
                    }
                    studentList.Add(studentCourse);
                }
            }
            return studentList;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            dataGridView1.Columns.Clear();
            dataGridView1.Hide();
            btnClose.Hide();
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            this.dataGridView1.Rows[e.RowIndex].Cells[0].Value = (e.RowIndex + 1).ToString();
        }
    }
}