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
using System.Linq.Expressions;

namespace Login1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection("SERVER=DESKTOP-C1CCQ4G;DATABASE=ejemplo;Integrated security=true");
        

        public void logear(string usuario, string contrasena)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT Nombre, Tipo_usuario FROM usuarios WHERE Usuario = @usuario AND Password = @pas", con);
                cmd.Parameters.AddWithValue("usuario", usuario);
                cmd.Parameters.AddWithValue("pas", contrasena);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                if (dt.Rows.Count == 1) {

                    this.Hide();
                    if (dt.Rows[0][1].ToString() == "Admin") {
                        new Admin(dt.Rows[0][0].ToString()).Show();

                    }
                    else if (dt.Rows[0][1].ToString() == "Usuario")
                    {
                        new Usuario(dt.Rows[0][0].ToString()).Show();
                    }
                }
                    else {
                        MessageBox.Show("Usuario y/o Contrasena incorrecta");
                    }
                }
            
                catch (Exception e){
                MessageBox.Show(e.Message);
                }
            finally
            {
                con.Close();
            }
            }

        private void button1_Click(object sender, EventArgs e)
        {
            logear(this.txtUsuario.Text, this.txtPassword.Text);
        }

        // Test Conecction MSSQL SERVER
        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection conexion = new SqlConnection("SERVER=DESKTOP-C1CCQ4G;DATABASE=ejemplo;Integrated security=true");
            conexion.Open();
            MessageBox.Show("Se abrió la conexión con el servidor SQL Server y se seleccionó la base de datos");
            conexion.Close();
            MessageBox.Show("Se cerró la conexión.");
        }
    }
    }

