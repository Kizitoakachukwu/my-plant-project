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
    public partial class harmfulForm2 : Form
    {
        DataAccess db = new DataAccess();
        public harmfulForm2()
        {
            InitializeComponent();
            //dataGridView1.DataSource = db.GetHarmful_Objs();
            //foreach( var s in db.Getspecial_treatment())
            //{
            //    comboBox1.Items.Add(s);
            //}
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void Insertbut_Click(object sender, EventArgs e)
        {
            Harmful_obj _Obj = new Harmful_obj
            {
                name = comboBox2.Text,
                specialTreatment = (special_treatment)comboBox1.SelectedItem
            };
            db.Insert(_Obj);

        }

        private void updatebut_Click(object sender, EventArgs e)
        {
            object t = dataGridView1.SelectedRows;
            db.Update((Harmful_obj)t);
        }

        private void delbut_Click(object sender, EventArgs e)
        {
            object t = dataGridView1.SelectedRows;
            db.Delete((Harmful_obj)t);
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
