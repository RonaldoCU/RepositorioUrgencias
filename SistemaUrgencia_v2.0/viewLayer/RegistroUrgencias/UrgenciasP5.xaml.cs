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
    /// Lógica de interacción para UrgenciasP5.xaml
    /// </summary>
    public partial class UrgenciasP5 : Page
    {
        SqlConnection conexion = new SqlConnection("Data Source=DESKTOP-D8TLHID;Initial Catalog=UrgSqlServer;Integrated Security=True");
        public UrgenciasP5()
        {
            InitializeComponent();
        }

        private void atras4(object sender, RoutedEventArgs e)
        {
            
            NavigationService.Navigate(new UrgenciasP4());
        }

        private void Guardar(object sender, RoutedEventArgs e)
        {
            conexion.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO TipoPrescripcion(via_oral,via_sublingual,via_transdermica,via_topica,via_otica,via_vaginal,via_oftalmica,via_inhalatoria,via_recta,via_intranasal,via_parenteral,Prescripcion) VALUES ('" + this.txt1.Text + "','" + this.txt2.Text + "','" + this.txt3.Text + "','" + this.txt4.Text + "','" + this.txt5.Text + "','" + this.txt6.Text + "','" + this.txt7.Text + "','" + this.txt8.Text + "','" + this.txt9.Text + "','" + this.txt10.Text + "','" + this.txt11.Text + "','" + this.txtprescripcion.Text + "')",conexion);
            cmd.ExecuteNonQuery();
            conexion.Close();

            NavigationService.Navigate(new Urgencias());
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
        private void b4(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new UrgenciasP4());
        }
    }
}
