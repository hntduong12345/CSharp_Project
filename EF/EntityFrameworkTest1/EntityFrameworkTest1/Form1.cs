    using EntityFrameworkTest1.Models;
using Microsoft.EntityFrameworkCore.Storage;

namespace EntityFrameworkTest1
{
    public partial class Form1 : Form
    {
        TestEntityContext db = new TestEntityContext();

        public Form1()
        {
            InitializeComponent();
            LoadData();
            Addbinding();
        }

        #region methods
        void Addbinding()
        {
            txtID.DataBindings.Add(new Binding("Text", dataGridView1.DataSource, "IDLop", true, DataSourceUpdateMode.Never));
            txtName.DataBindings.Add(new Binding("Text", dataGridView1.DataSource, "Name", true, DataSourceUpdateMode.Never));
        }
        void LoadData()
        {
            //var result = db.SinhViens.Select(p => p).ToList();
            //var result = from c in db.SinhViens select c;
            //var result = from c in db.SinhViens select new { ID = c.Id, Name = c.Name, Lop = c.IdlopNavigation.Name };
            //var result = from c in db.Lops select new {ID = c.Id, Name = c.Name, SL = c.SinhViens.Count };
            var result = from c in db.SinhViens
                             //where c.Id > 1 && c.Id < 4
                         select c;
            //var result = db.SinhViens.Find(2);
            //dataGridView1.DataSource = result;
            dataGridView1.DataSource = result.ToList();
        }
        void AddSinhVien()
        {
            SinhVien sv = new SinhVien() { Name = txtName.Text, Idlop = Convert.ToInt32(txtID.Text) };
            db.SinhViens.Add(sv);
            db.SaveChanges();
        }
        void DeleteSinhVien()
        {
            int idLop = Convert.ToInt32(txtID.Text);
            SinhVien sv = db.SinhViens.Where(p=> p.Idlop == idLop && p.Name == txtName.Text).SingleOrDefault();
            db.SinhViens.Remove(sv);
            db.SaveChanges();
        }
        void EditSinhVien()
        {
            int id = Convert.ToInt32(dataGridView1.SelectedCells[0].OwningRow.Cells["ID"].Value.ToString());
            SinhVien sv = db.SinhViens.Find(id);
            sv.Name = txtName.Text;
            sv.Idlop = Convert.ToInt32(txtID.Text);
            db.SaveChanges();
        }
        #endregion

        #region Events
        private void btnShow_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddSinhVien();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteSinhVien();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            EditSinhVien();
        }
        #endregion
    }
}