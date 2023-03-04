using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoBDII
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form7 Asientos = new Form7();
            Asientos.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form9 FormCuentasT = new Form9();
            FormCuentasT.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form4 FormConsultaDeSaldos = new Form4();
            FormConsultaDeSaldos.Show();
        }
    }
}
