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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conexionBD = new SqlConnection("server=LUCAS\\SYSTSALUD; " + "database=sfcontable; " + "integrated security = true");
            conexionBD.Open();
            string CedulaCliente = textBox1.Text;
            string ComandoConsulta = "select*from Clientes where Cedula =" + CedulaCliente;
            SqlCommand comando = new SqlCommand(ComandoConsulta, conexionBD);
            SqlDataReader registros = comando.ExecuteReader();
            if (registros.Read())
            {
                label18.Text = registros["Nombres"].ToString();
                label19.Text = registros["Apellidos"].ToString();
                label21.Text = registros["Telefono"].ToString();
                label20.Text = registros["Edad"].ToString();
            }
            else
            {
                MessageBox.Show("No existe un Usuario con ese Numero de Documento ingresado");
            }
            conexionBD.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            DateTime fecha = DateTime.Now;
            label8.Text = fecha.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection conexionBD = new SqlConnection("server=LUCAS\\SYSTSALUD; " + "database=sfcontable; " + "integrated security = true");
            conexionBD.Open();
            string IdeAsiento = textBox3.Text.TrimEnd();
            SqlCommand comando = new SqlCommand("select Descripcion,Credito from Asientos where ID =" + IdeAsiento+ "and Credito >0", conexionBD);
            SqlDataReader registros = comando.ExecuteReader();
            while (registros.Read())
            {
                label6.Text = IdeAsiento;
                label16.Text = registros["Credito"].ToString();
                textBox2.AppendText(registros["Descripcion"].ToString());
                textBox2.AppendText(" --- ");
                textBox2.AppendText(registros["Credito"].ToString());
                textBox2.AppendText(Environment.NewLine);
            }
            conexionBD.Close();
        }

        private void button2_Click(object sender, EventArgs e)
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
                exportar.WriteLine("--------------------------------- FACTURA ------------------------------------");
                exportar.WriteLine("Fecha: " + label8.Text);
                exportar.WriteLine("Numero de Factura: " + label6.Text);
                exportar.WriteLine("---------------- Información de La Empresa ----------------");
                exportar.WriteLine(label1.Text);
                exportar.WriteLine(label2.Text);
                exportar.WriteLine(label4.Text);
                exportar.WriteLine("---------------- Información del Comprador ----------------");
                exportar.WriteLine("Nombre Completo; " + label18.Text + " " + label19.Text);
                exportar.WriteLine("Telefono; " + label21.Text);
                exportar.WriteLine("Edad; "+ label20.Text);
                exportar.WriteLine("---------------------------------------------------------");
                exportar.WriteLine("Productos Comprados & Precios");
                exportar.WriteLine(textBox2.Text);
                exportar.WriteLine("Total: "+ label16.Text);
                exportar.WriteLine("------------------------------------------------------------------------------");
                exportar.Close();
            }
            guardar.Dispose();
        }
    }
}
