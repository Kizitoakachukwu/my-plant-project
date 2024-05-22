using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace my_plant_project.Windows
{
    public partial class specialtreatmentForm2 : Form
    {
        DataAccess db = new DataAccess();
        public specialtreatmentForm2()
        {
            InitializeComponent();
       //     dataGridView1.DataSource = db.Getspecial_treatment();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Insertbut_Click(object sender, EventArgs e)
        {
            db.Insert(new special_treatment(comboBox2.Text));
        }

        private void delbut_Click(object sender, EventArgs e)
        {
            object T = dataGridView1.SelectedRows;
            db.Delete((special_treatment)T);
        }

        private void updatebut_Click(object sender, EventArgs e)
        {
            object T = dataGridView1.SelectedRows;
            db.Update((special_treatment)T);
        }
    }
}
