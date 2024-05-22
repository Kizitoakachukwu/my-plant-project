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
    public partial class PlantForm : Form
    {
        DataAccess db=new DataAccess();
        public PlantForm()
        {
            InitializeComponent();
          //  dataGridView1.DataSource=db.GetPlants();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void submitbut_Click(object sender, EventArgs e)
        {
            string name=comboBox1.Text;
            string namePlant = comboBox2.Text;    
            plants plants=new plants(name,namePlant);
            db.Insert(plants);
            dataGridView1.DataSource = db.GetPlants();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void InputNPlant_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void delbut_Click(object sender, EventArgs e)
        {
            object Item = dataGridView1.SelectedRows;
            db.Delete((plants)Item);
        }

        private void updatebut_Click(object sender, EventArgs e)
        {
            object Item = dataGridView1.SelectedRows;
            db.Delete((plants)Item);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
