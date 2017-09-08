using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Student_Profil
{
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            using (ModelContext db = new ModelContext())
            {
                studentBindingSource.DataSource = db.StudentList.ToList();

            }
            pContainer.Enabled = false;

            Student obj = studentBindingSource.Current as Student;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
           
            pContainer.Enabled = true;
            studentBindingSource.Add(new Student());
            studentBindingSource.MoveLast();
            txtFullName.Focus();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            pContainer.Enabled = true;
            txtFullName.Focus();
            Student obj = studentBindingSource.Current as Student;
           
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            pContainer.Enabled = false;
            studentBindingSource.ResetBindings(false);
            Form1_Load(sender, e);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Student obj = studentBindingSource.Current as Student;
           
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MetroFramework.MetroMessageBox.Show(this, "Bu kaydı silmek istediğinize emin misiniz?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                using (ModelContext db = new ModelContext())
                {
                    Student obj = studentBindingSource.Current as Student;
                    if (obj != null)
                    {
                        if (db.Entry<Student>(obj).State == System.Data.Entity.EntityState.Detached)
                            db.Set<Student>().Attach(obj);
                        db.Entry<Student>(obj).State = System.Data.Entity.EntityState.Deleted;
                        db.SaveChanges();
                        studentBindingSource.RemoveCurrent();
                        pContainer.Enabled = false;
                      
                    }
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            using (ModelContext db = new ModelContext())
            {
                Student obj = studentBindingSource.Current as Student;
                if (obj != null)
                {
                    if (db.Entry<Student>(obj).State == System.Data.Entity.EntityState.Detached)
                        db.Set<Student>().Attach(obj);
                    if (obj.StudentID==0)
                        db.Entry<Student>(obj).State = System.Data.Entity.EntityState.Added;
                    else 
                        db.Entry<Student>(obj).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    dataGridView1.Refresh();
                    pContainer.Enabled = false;
                 



                }
            }
        }

        private void chkGender_CheckStateChanged(object sender, EventArgs e)
        {
            if (chkGender.CheckState == CheckState.Checked)
                chkGender.Text = "Female";
            else if (chkGender.CheckState == CheckState.Unchecked)
                chkGender.Text = "Male";
            else
                chkGender.Text = "???";
        }

    }
}
