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
using System.IO;

namespace ProyectoBDII
{
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form8_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conexionBD = new SqlConnection("server=LUCAS\\SYSTSALUD; " + "database=sfcontable; " + "integrated security = true");
            conexionBD.Open();
            SqlCommand comando = new SqlCommand("select*from Asientos order by ID", conexionBD);
            SqlDataReader registros = comando.ExecuteReader();
            while (registros.Read())
            {
                textBox1.AppendText("ID: ");
                textBox1.AppendText(registros["ID"].ToString());
                textBox1.AppendText(" - ");
                textBox1.AppendText("Fecha Y Hora: ");
                textBox1.AppendText(registros["Fecha"].ToString());
                textBox1.AppendText(" - ");
                textBox1.AppendText("Cuenta Contable: ");
                textBox1.AppendText(registros["Cuenta"].ToString());
                textBox1.AppendText(" - ");
                textBox1.AppendText("Descripción: ");
                textBox1.AppendText(registros["Descripcion"].ToString());
                textBox1.AppendText(" - ");
                textBox1.AppendText("Debito: ");
                textBox1.AppendText(registros["Debito"].ToString());
                textBox1.AppendText(" - ");
                textBox1.AppendText("Credito: ");
                textBox1.AppendText(registros["Credito"].ToString());
                textBox1.AppendText(Environment.NewLine);
            }
            conexionBD.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection conexionBD = new SqlConnection("server=LUCAS\\SYSTSALUD; " + "database=sfcontable; " + "integrated security = true");
            conexionBD.Open();
            string IdeAsiento = textBox2.Text.TrimEnd();
            SqlCommand comando = new SqlCommand("select*from Asientos where ID =" + IdeAsiento + "order by ID", conexionBD);
            SqlDataReader registros = comando.ExecuteReader();
            while (registros.Read())
            {
                textBox1.AppendText("ID: ");
                textBox1.AppendText(registros["ID"].ToString());
                textBox1.AppendText(" - ");
                textBox1.AppendText("Fecha Y Hora: ");
                textBox1.AppendText(registros["Fecha"].ToString());
                textBox1.AppendText(" - ");
                textBox1.AppendText("Cuenta Contable: ");
                textBox1.AppendText(registros["Cuenta"].ToString());
                textBox1.AppendText(" - ");
                textBox1.AppendText("Descripción: ");
                textBox1.AppendText(registros["Descripcion"].ToString());
                textBox1.AppendText(" - ");
                textBox1.AppendText("Debito: ");
                textBox1.AppendText(registros["Debito"].ToString());
                textBox1.AppendText(" - ");
                textBox1.AppendText("Credito: ");
                textBox1.AppendText(registros["Credito"].ToString());
                textBox1.AppendText(Environment.NewLine);
            }
            conexionBD.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string ruta = "";
            TextWriter exportar;
            SaveFileDialog guardar = new SaveFileDialog();
            guardar.Filter = "Archivos De Texto|*.txt";
            guardar.Title = "Guardar";
            if (guardar.ShowDialog() == DialogResult.OK)
            {
                ruta = guardar.FileName;
                exportar = new StreamWriter(ruta);
                exportar.WriteLine("----------------------------- Asientos Contables -----------------------------");
                exportar.WriteLine(textBox1.Text);
                exportar.WriteLine("------------------------------------------------------------------------------");
                exportar.Close();
            }
            guardar.Dispose();
        }
    }
}
