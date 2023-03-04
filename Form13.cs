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
    public partial class Form13 : Form
    {
        public Form13()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conexionBD = new SqlConnection("server=LUCAS\\SYSTSALUD; " + "database=sfcontable; " + "integrated security = true");
            conexionBD.Open();
            string id = textBox1.Text.TrimEnd();
            string trabajo = textBox2.Text.TrimEnd();
            string dueño = textBox3.Text.TrimEnd();
            string deuda = textBox4.Text.TrimEnd();
            string deposito = textBox5.Text.TrimEnd();
            try
            {
                SqlCommand comando = new SqlCommand("insert into Cobros(Id,Trabajo,Dueño,Debe,Deposito) values ('" + id + "','" + trabajo + "','" + dueño + "','" + deuda + "','" + deposito + "')", conexionBD);
                comando.ExecuteNonQuery();
                MessageBox.Show(" ¡Registro Exitoso! ");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            conexionBD.Close();
            textBox3.Clear();
            textBox1.Clear();
            textBox2.Clear();
            textBox4.Clear();
            textBox5.Clear();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlConnection conexionBD = new SqlConnection("server=LUCAS\\SYSTSALUD; " + "database=sfcontable; " + "integrated security = true");
            conexionBD.Open();
            string id = textBox1.Text.TrimEnd();
            string comandoconsulta = "select*from Cobros where Id =" + id;
            SqlCommand comando = new SqlCommand(comandoconsulta, conexionBD);
            SqlDataReader registro = comando.ExecuteReader();
            if (registro.Read())
            {
                textBox2.Text = registro["Trabajo"].ToString();
                textBox3.Text = registro["Dueño"].ToString();
                textBox4.Text = registro["Debe"].ToString();
                textBox5.Text = registro["Deposito"].ToString();
            }
            else
            {
                MessageBox.Show("No se encontró nada");
            }
            label9.Text = (Convert.ToString(((Convert.ToInt32(textBox4.Text)) - (Convert.ToInt32(textBox5.Text)))));
            conexionBD.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection conexionBD = new SqlConnection("server=LUCAS\\SYSTSALUD; " + "database=sfcontable; " + "integrated security = true");
            conexionBD.Open();
            string id = textBox1.Text.TrimEnd();
            string comandoeliminar = "delete from Cobros where Id =" + id;
            try
            {
                SqlCommand comando = new SqlCommand(comandoeliminar, conexionBD);
                comando.ExecuteNonQuery();
                MessageBox.Show("Eliminado Exitosamente...");
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

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection conexionBD = new SqlConnection("server=LUCAS\\SYSTSALUD; " + "database=sfcontable; " + "integrated security = true");
            conexionBD.Open();
            string id = textBox1.Text.TrimEnd();
            string trabajo = textBox2.Text.TrimEnd();
            string dueño = textBox3.Text.TrimEnd();
            string deuda = textBox4.Text.TrimEnd();
            string deposito = textBox5.Text.TrimEnd();
            string comandoactualizacion = "update Cobros set Trabajo='" + trabajo + "', Dueño= '" + dueño + "', Debe='" + deuda + "', Deposito='" + deposito + "' where Id = " + id + ";";
            try
            {
                SqlCommand comando = new SqlCommand(comandoactualizacion, conexionBD);
                comando.ExecuteNonQuery();
                MessageBox.Show("Se modificaron los campos: ");
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

        private void button2_Click(object sender, EventArgs e)
        {
            DataTable tabla = new DataTable();
            using (SqlConnection conexionBD = new SqlConnection("server=LUCAS\\SYSTSALUD; " + "database=sfcontable; " + "integrated security = true"))
            {
                conexionBD.Open();
                SqlDataAdapter adaptador = new SqlDataAdapter("select * from Cobros", conexionBD);
                adaptador.Fill(tabla);
            }
            dataGridView1.DataSource = tabla;
        }
    }
}
