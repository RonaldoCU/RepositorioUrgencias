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

namespace SistemaUrgencia_v2._0.viewLayer.RegistroUrgencias
{
    /// <summary>
    /// Lógica de interacción para UrgenciasP4.xaml
    /// </summary>
    public partial class UrgenciasP4 : Page
    {
        SqlConnection conexion = new SqlConnection("Data Source=DESKTOP-D8TLHID;Initial Catalog=UrgSqlServer;Integrated Security=True");
        public UrgenciasP4()
        {
            InitializeComponent();
        }

        private void Atras3(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new UrgenciasP3());
        }

        private void Guardar(object sender, RoutedEventArgs e)
        {

            conexion.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO Solicitud(codigo, nombre, cargo) VALUES (" + this.txtcodigo.Text + ",'" + this.txtnombre.Text + "','" + this.txtcargo.Text + "')", conexion);
            cmd.ExecuteNonQuery();

            SqlCommand cmd2 = new SqlCommand("INSERT INTO Analisis (nivel_A,sangre,heces,orina,precion,inmunologia,quimica,solicitud) VALUES ('" + this.txtnivelA.Text + "','" + this.txtsangre.Text + "','" + this.txtheces.Text + "','" + this.txtorina.Text + "','" + this.txtprecion.Text + "','" + this.txtinmumologia.Text + "','" + this.txtquimica.Text + "','" + this.txtsolicitud.Text + "')", conexion);
            cmd2.ExecuteNonQuery();

            SqlCommand cmd3 = new SqlCommand("INSERT INTO Imagenes (nivel_I,cabeza,Ext_sup_Izq,Ext_sup_Der,tronco,Ext_inf_Izq,Ext_inf_Der,solicitud) VALUES ('" + this.txtnivelI.Text + "','" + this.txtcabeza.Text + "','" + this.txtBI.Text + "','" + this.txtBD.Text + "','" + this.txtTronco.Text + "','" + this.txtPI.Text + "','" + this.txtPD.Text + "','" + this.txtRadiografia.Text + "')", conexion);
            cmd3.ExecuteNonQuery();

            MessageBox.Show("Datos guardados");
            conexion.Close();
        }

        private void Siguiente4(object sender, RoutedEventArgs e)
        {

            NavigationService.Navigate(new UrgenciasP5());
        }

        private void b1(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Urgencias());
        }
        private void b2(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new UrgenciasP2());
        }
        private void b3(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new UrgenciasP3());
        }
        private void b5(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new UrgenciasP5());
        }
    }
}
