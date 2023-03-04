using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ProyectoBDII
{
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conexionBD = new SqlConnection("server=LUCAS\\SYSTSALUD; " + "database=sfcontable; " + "integrated security = true");
            conexionBD.Open();
            string IdeAsiento = textBox1.Text.TrimEnd();
            SqlCommand comando = new SqlCommand("select Cuenta,Debito,Credito from Asientos where ID =" + IdeAsiento, conexionBD);
            SqlDataReader registros = comando.ExecuteReader();
            if (registros.Read())
            {
                label1.Text = registros["Cuenta"].ToString();
                label2.Text = registros["Debito"].ToString();
                label3.Text = registros["Credito"].ToString();
                while (registros.Read())
                {
                    label4.Text = registros["Cuenta"].ToString();
                    label5.Text = registros["Debito"].ToString();
                    label6.Text = registros["Credito"].ToString();
                }
            }
            else
            {
                MessageBox.Show(" Hubo un Error En la Consulta, Verifique el ID... ");
            }
            conexionBD.Close();
        }
    }
}
