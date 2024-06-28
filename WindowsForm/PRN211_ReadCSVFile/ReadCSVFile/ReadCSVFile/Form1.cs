using Microsoft.VisualBasic.FileIO;
using System.Data;
using System.Text;

namespace ReadCSVFile
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            //Take file csv path.
            string fileName = "";
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "Open CSV File";
            dialog.Filter = "CSV Files (*.csv)|*.csv";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                fileName = dialog.FileName;

            }
            else
            {
                return;
            }

            //Create data list and field list
            List<Student> studentList = new List<Student>();
            string[] fieldList = { "MSSV", "Name", "Email", "Phone" };


            //Take data of csv file and add to list
            using (TextFieldParser csvParser = new TextFieldParser(fileName))
            {
                csvParser.CommentTokens = new string[] { "," };
                csvParser.SetDelimiters(new string[] { "," });
                csvParser.HasFieldsEnclosedInQuotes = true;

                csvParser.ReadLine();

                while (!csvParser.EndOfData)
                {
                    string[] fields = csvParser.ReadFields();
                    string Id = fields[1];
                    string Name = fields[2];
                    string Email = fields[3];
                    string Phone = fields[4];

                    studentList.Add(new Student(Id, Name, Email, Phone));
                }
            }


            //Show data
            using (DataTable dt = new DataTable())
            {
                for (int i = 0; i < fieldList.Length; i++)
                {
                    //Add table fields
                    dt.Columns.Add(fieldList[i]);

                    //Create rows to contain data
                    while (dt.Rows.Count < studentList.Count)
                    {
                        dt.Rows.Add();
                    }

                    //Add each student's data to following column.
                    for (int a = 0; a < studentList.Count; a++)
                    {
                        dt.Rows[a][i] = studentList[a].getField(fieldList[i]);
                    }
                }

                //Render the DataGridView
                dataGridView1.DataSource = dt.DefaultView;
            }

        }
    }
}