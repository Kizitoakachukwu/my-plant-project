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
    public partial class operationlistForm2 : Form
    {
        public operationlistForm2()
        {
            InitializeComponent();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            PlantForm plantForm = new PlantForm();
            plantForm.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            OperationForm form = new OperationForm();
            form.ShowDialog();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            harmfulForm2 form2 =new harmfulForm2();
            form2.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
