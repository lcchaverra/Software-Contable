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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form10 FormBalancedePrueba = new Form10();
            FormBalancedePrueba.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form11 FormBalancedeGeneral = new Form11();
            FormBalancedeGeneral.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form12 FormEstadodeResultad = new Form12();
            FormEstadodeResultad.Show();
        }
    }
}
