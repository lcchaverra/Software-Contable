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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conexionBD = new SqlConnection("server=LUCAS\\SYSTSALUD; " + "database=sfcontable; " + "integrated security = true");
            string cuentaContable = comboBox1.Text.TrimEnd();
            string comandoconsulta = "SELECT SUM(Debito) as TotalDebito,SUM(Credito) as TotalCredito FROM [sfcontable].[dbo].[Asientos] where Cuenta like " + "'" +cuentaContable + "'";
            conexionBD.Open();
            SqlCommand comando = new SqlCommand(comandoconsulta, conexionBD);
            SqlDataReader registro = comando.ExecuteReader();
            while (registro.Read())
            {
                double VTotalDebito = Convert.ToDouble(registro["TotalDebito".ToString()]);
                double VTotalCredito = Convert.ToDouble(registro["TotalCredito".ToString()]);
                double VTotalCuenta = VTotalDebito - VTotalCredito;
                MessageBox.Show("El Saldo Actual de la cuenta; '" + cuentaContable + "' Es de: " + Convert.ToString(VTotalCuenta));
            }
            conexionBD.Close();
        }
    }
}
