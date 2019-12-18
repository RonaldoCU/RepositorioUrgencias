using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;
using SistemaUrgencia_v2._0;

namespace SistemaUrgencia_v2._0.viewLayer.RegistroUrgencias
{
    /// <summary>
    /// Lógica de interacción para Urgencias.xaml
    /// </summary>
    public partial class Urgencias : Page
    {
        SqlConnection conexion = new SqlConnection("Data Source=DESKTOP-D8TLHID;Initial Catalog=UrgSqlServer;Integrated Security=True");
        public Urgencias()
        {
            InitializeComponent();
            DateTime fecha = DateTime.Now;
            string formato = fecha.ToString();//"yyyy-MM-dd hh-mm-ss");
            this.datohrsFch.Text = formato;
        }
        private void Guardar(object sender, RoutedEventArgs e)
        {
            conexion.Open();

            SqlCommand cmd = new SqlCommand(@" INSERT INTO DatosUrgencia (N_hoja,fecha_hora,especialidad,Motivo_consulta) VALUES (" + this.txtNhoja.Text + ",'" + this.datohrsFch.Text + "','" + this.txtEspecialidad.Text + "','" + this.txtMotConsulta.Text + "')", conexion);
            cmd.ExecuteNonQuery();
            SqlCommand cmd2 = new SqlCommand(@"INSERT INTO DarCamas (cama, habitacion,bloque,destino) VALUES (" + this.txtCama.Text + ",'" + this.txtHabitacion.Text + "','" + this.txtBloque.Text + "','" + this.txtDestino.Text + "')", conexion);
            cmd2.ExecuteNonQuery();
            SqlCommand cmd3 = new SqlCommand(@"INSERT INTO Ingresos(modo_ingreso,nivel_urgencia,seguro) VALUES ('" + this.txtModIngreso.Text + "','" + this.txtNvUrgencia.Text + "','" + this.txtSegMedico.Text + "')", conexion);
            cmd3.ExecuteNonQuery();
            MessageBox.Show("Datos guardados");
            conexion.Close();
            
        }

        //private void FechaHora(object sender, RoutedEventArgs e)
        //{ 
            
        //}

        private void Siguiente1(object sender, RoutedEventArgs e)
        {
            
            NavigationService.Navigate(new UrgenciasP2());
        }

        private void bt_2(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new UrgenciasP2());
        }

        private void bt_3(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new UrgenciasP3());
        }

        private void bt_4(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new UrgenciasP4());
        }

        private void bt_5(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new UrgenciasP5());
        }
    }
}