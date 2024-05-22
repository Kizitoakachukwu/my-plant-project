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
    public partial class main : Form
    {
        public main()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            harmfulForm2 harmfulForm2 = new harmfulForm2();
            harmfulForm2.ShowDialog();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            specialtreatmentForm2 special_treatment = new specialtreatmentForm2();
            special_treatment.ShowDialog();

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            MethodtreatmentForm2 Methodtreatment = new MethodtreatmentForm2();
            Methodtreatment.ShowDialog();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            operationForm2 operationForm2 = new operationForm2();
            operationForm2.ShowDialog();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            operationForm2 operationForm2 = new operationForm2();
            operationForm2.ShowDialog();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
