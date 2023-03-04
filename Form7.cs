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
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }

        private void Cancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void toolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void Form7_Load(object sender, EventArgs e)
        {
            int[] numeros = new int[25];
            Random r = new Random();

            int auxiliar = 0;
            int contador = 0;

            for (int i = 0; i < 25; i++)
            {
                auxiliar = r.Next(1, 9999);
                bool continuar = false;

                while (!continuar)
                {
                    for (int j = 0; j <= contador; j++)
                    {
                        if (auxiliar == numeros[j])
                        {
                            continuar = true;
                            j = contador;
                        }
                    }

                    if (continuar)
                    {
                        auxiliar = r.Next(1, 9999);
                        continuar = false;
                    }
                    else
                    {
                        continuar = true;
                        numeros[contador] = auxiliar;
                        contador++;
                    }
                }
            }
            idas.Text = auxiliar.ToString();
            DateTime fecha = DateTime.Now;
            fechaas.Text = fecha.ToString();
        }

        private void Buscar_Click(object sender, EventArgs e)
        {
            Form8 FormConsultaAsientos = new Form8();
            FormConsultaAsientos.Show();
        }

        private void Guardar_Click(object sender, EventArgs e)
        {
            SqlConnection conexionBD = new SqlConnection("server=LUCAS\\SYSTSALUD; " + "database=sfcontable; " + "integrated security = true");
            conexionBD.Open();
            string vid = idas.Text.TrimEnd();
            string vfecha = fechaas.Text.TrimEnd();
            string vcuenta = comboBox1.Text.TrimEnd();
            string vdescripcion = textBox3.Text.TrimEnd();
            string vdebito = textBox1.Text.TrimEnd();
            string vcredito = textBox2.Text.TrimEnd();
            string vid2 = idas.Text.TrimEnd();
            string vfecha2 = fechaas.Text.TrimEnd();
            string vcuenta2 = comboBox2.Text.TrimEnd();
            string vdescripcion2 = textBox4.Text.TrimEnd();
            string vdebito2 = textBox5.Text.TrimEnd();
            string vcredito2 = textBox6.Text.TrimEnd();
            try
            {
                SqlCommand comando = new SqlCommand("insert into Asientos(ID,Fecha,Cuenta,Descripcion,Debito,Credito) values ('" + vid + "','" + vfecha + "','" + vcuenta + "','" + vdescripcion + "','" + vdebito + "','" + vcredito + "')", conexionBD);
                comando.ExecuteNonQuery();
                SqlCommand comando2 = new SqlCommand("insert into Asientos(ID,Fecha,Cuenta,Descripcion,Debito,Credito) values ('" + vid2 + "','" + vfecha2 + "','" + vcuenta2 + "','" + vdescripcion2 + "','" + vdebito2 + "','" + vcredito2 + "')", conexionBD);
                comando2.ExecuteNonQuery();
                MessageBox.Show(" ¡Registro Exitoso! ");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            conexionBD.Close();
            idas.Clear();
            fechaas.Clear();
            textBox3.Clear();
            textBox1.Clear();
            textBox2.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form3 FormFactura = new Form3();
            FormFactura.Show();
        }
    }
}
