using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace my_plant_project
{
    public partial class OperationForm : Form
    {
         DataAccess db = new DataAccess();

        public OperationForm()
        {
            InitializeComponent();
           // dataGridView1.DataSource=db.GetOperations();
        }

      
        private void button5_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Insertbut_Click(object sender, EventArgs e)
        {
            db.Insert(new Operation(comboBox2.Text));
        }

        private void updatebut_Click(object sender, EventArgs e)
        {
            object t = dataGridView1.SelectedRows;
            db.Update((Operation)t);
        }

        private void delbut_Click(object sender, EventArgs e)
        {
            object t = dataGridView1.SelectedRows;
            db.Delete((Operation)t);
        }
    }
}
