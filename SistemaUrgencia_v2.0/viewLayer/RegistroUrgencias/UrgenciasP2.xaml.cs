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
    /// Lógica de interacción para UrgenciasP2.xaml
    /// </summary>
    public partial class UrgenciasP2 : Page
    {
        SqlConnection conexion = new SqlConnection("Data Source=DESKTOP-D8TLHID;Initial Catalog=UrgSqlServer;Integrated Security=True");
        public UrgenciasP2()
        {
            InitializeComponent();
        }
        
        private void atras1(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Urgencias());
        }

        private void Guardar(object sender, RoutedEventArgs e)
        {
            conexion.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO Valoracion_inicial (dolor,tipo_dolor,localizacion,alergias,otros_sig_sin,necesidad_ayu) VALUES ('" + this.txtDolor.Text + "','" + this.txtTipo.Text + "','" + this.txtLugar.Text + "','" + this.txtAlergias.Text + "','" + this.txtSigSintomas.Text + "','" + this.txtAyudaNecesidad.Text + "')", conexion);
            cmd.ExecuteNonQuery();

            SqlCommand cmd2 = new SqlCommand("INSERT INTO Necesidades (respiratorio, hidratacion,conciencia,seguridad,sensorial,eliminacion,movilidad,comunicacion,tipo_Ayuda) VALUES ('" + this.txtRespiracion.Text + "','" + this.txthidratacion.Text + "','" + this.txtconciencia.Text + "','" + this.txtseguridad.Text + "','" + this.txtsensorial.Text + "','" + this.txtEliminacion.Text + "','" + this.txtmovilidad.Text + "','" + this.txtcomunicacion.Text + "','" + this.txtAyudaNecesidad.Text + "')", conexion);
            cmd2.ExecuteNonQuery();

            MessageBox.Show("Datos guardados");
            conexion.Close();
        }

        private void Siguiente2(object sender, RoutedEventArgs e)
        {
            
            NavigationService.Navigate(new UrgenciasP3());
        }

        private void bt_1(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Urgencias());
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
