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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conexionBD = new SqlConnection("server=LUCAS\\SYSTSALUD; " + "database=sfcontable; " + "integrated security = true");
            conexionBD.Open();
            string vcedula = textBox1.Text.TrimEnd();
            string vnombres = textBox2.Text.TrimEnd();
            string vapellidos = textBox3.Text.TrimEnd();
            string vtelefono = textBox4.Text.TrimEnd();
            string vedad = textBox5.Text.TrimEnd();
            try
            {
                SqlCommand comando = new SqlCommand("insert into Clientes(Cedula,Nombres,Apellidos,Telefono,Edad) values ('" + vcedula + "','" + vnombres + "','" + vapellidos + "','" + vtelefono + "','" + vedad + "')", conexionBD);
                comando.ExecuteNonQuery();
                MessageBox.Show(" ¡Registro Exitoso! ");
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            conexionBD.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection conexionBD = new SqlConnection("server=LUCAS\\SYSTSALUD; " + "database=sfcontable; " + "integrated security = true");
            conexionBD.Open();
            string CedulaCliente = textBox1.Text;
            string ComandoConsulta = "select*from Clientes where Cedula =" + CedulaCliente;
            SqlCommand comando = new SqlCommand(ComandoConsulta, conexionBD);
            SqlDataReader registros = comando.ExecuteReader();
            if (registros.Read())
            {
                textBox1.Text = registros["Cedula"].ToString();
                textBox2.Text = registros["Nombres"].ToString();
                textBox3.Text = registros["Apellidos"].ToString();
                textBox4.Text = registros["Telefono"].ToString();
                textBox5.Text = registros["Edad"].ToString();
            }
            else
            {
                MessageBox.Show("No existe un Usuario con ese Numero de Documento ingresado");
            }
            conexionBD.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection conexionBD = new SqlConnection("server=LUCAS\\SYSTSALUD; " + "database=sfcontable; " + "integrated security = true");
            conexionBD.Open();
            string CedulaCliente = textBox1.Text;
            string ComandoEliminar = "delete from Clientes where Cedula =" + CedulaCliente;
            SqlCommand comando = new SqlCommand(ComandoEliminar, conexionBD);
            int cant;
            cant = comando.ExecuteNonQuery();
            if (cant == 1)
            {
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                MessageBox.Show("Se eliminó el usuario con exito");
            }
            conexionBD.Close();
        }
    }
}
