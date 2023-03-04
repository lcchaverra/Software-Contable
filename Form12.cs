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
    public partial class Form12 : Form
    {
        public Form12()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conexionBD = new SqlConnection("server=LUCAS\\SYSTSALUD; " + "database=sfcontable; " + "integrated security = true");
            conexionBD.Open();
            SqlCommand comando = new SqlCommand("select*from [sfcontable].[dbo].[Asientos] where Cuenta like '4%' or Cuenta like '5%' or Cuenta like '6%' order by ID", conexionBD);
            SqlDataReader registros = comando.ExecuteReader();
            while (registros.Read())
            {
                textBox1.AppendText(registros["Cuenta"].ToString());
                textBox1.AppendText(Environment.NewLine);
                textBox2.AppendText(registros["Debito"].ToString());
                textBox2.AppendText(Environment.NewLine);
                textBox3.AppendText(registros["Credito"].ToString());
                textBox3.AppendText(Environment.NewLine);
            }
            conexionBD.Close();
            string comandoconsulta = "SELECT SUM(Debito) as TotalDebito,SUM(Credito) as TotalCredito FROM [sfcontable].[dbo].[Asientos] where Cuenta like '4%' or Cuenta like '5%' or Cuenta like '6%'";
            conexionBD.Open();
            SqlCommand comandocon = new SqlCommand(comandoconsulta, conexionBD);
            SqlDataReader registro = comandocon.ExecuteReader();
            while (registro.Read())
            {
                label8.Text = registro["TotalDebito"].ToString();
                label9.Text = registro["TotalCredito"].ToString();
                double VTotalDebito = Convert.ToDouble(registro["TotalDebito".ToString()]);
                double VTotalCredito = Convert.ToDouble(registro["TotalCredito".ToString()]);
                double VTotalCuenta = VTotalDebito - VTotalCredito;
                label11.Text = Convert.ToString(VTotalCuenta);
            }
            conexionBD.Close();
        }
    }
}
