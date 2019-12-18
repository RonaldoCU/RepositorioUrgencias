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
using System.Data;


namespace SistemaUrgencia_v2._0.viewLayer.RegistroUrgencias
{
    /// <summary>
    /// Lógica de interacción para UrgenciasP3.xaml
    /// </summary>
    public partial class UrgenciasP3 : Page
    {
        SqlConnection conexion = new SqlConnection("Data Source=DESKTOP-D8TLHID;Initial Catalog=UrgSqlServer;Integrated Security=True");
        public UrgenciasP3()
        {
            InitializeComponent();
            String connectionString = @"Data Source=DESKTOP-D8TLHID;Initial Catalog=UrgSqlServer;Integrated Security=True";
            String sql = @"SELECT * FROM ConstantesVitales";
            DataTable tabla = new DataTable();
            SqlConnection connection = new SqlConnection(connectionString);
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = new SqlCommand(sql, connection);
            adapter.Fill(tabla);
            data1.DataContext = tabla;
            connection.Close();

            String connectionString2 = @"Data Source=DESKTOP-D8TLHID;Initial Catalog=UrgSqlServer;Integrated Security=True";
            String sql2 = @"SELECT * FROM Perdida_liquidos";
            DataTable tabla2 = new DataTable();
            SqlConnection connection2 = new SqlConnection(connectionString2);
            SqlDataAdapter adapter2 = new SqlDataAdapter();
            adapter.SelectCommand = new SqlCommand(sql2, connection);
            adapter.Fill(tabla2);
            data2.DataContext = tabla2;
            connection.Close();
        }

        private void atras2(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new UrgenciasP2());
        }
        

        private void Guardar(object sender, RoutedEventArgs e)
        {
            conexion.Open();
            SqlCommand cmd = new SqlCommand(@"INSERT INTO ConstantesVitales (hora,P_A,F_C,F_R,T) VALUES ('" + this.txthoras.Text + "'," + this.txtPA.Text + "," + this.txtFC.Text + "," + this.txtFR.Text + "," + this.txtT.Text + ")", conexion);
            cmd.ExecuteNonQuery();

            SqlCommand cmd2 = new SqlCommand(@"INSERT INTO Perdida_liquidos (hora, diuresis,deposicion,vomito) VALUES ('" + this.txthoras2.Text + "','" + this.txtdiuresis.Text + "','" + this.txtdeposicion.Text + "','" + this.txtvomitos.Text + "')", conexion);
            cmd2.ExecuteNonQuery();

            MessageBox.Show("Datos guardados");
            conexion.Close();

            NavigationService.Navigate(new UrgenciasP3());
        }

        private void Siguiente3(object sender, RoutedEventArgs e)
        {
            
            NavigationService.Navigate(new UrgenciasP4());
        }

        private void FechaHora1(object sender, RoutedEventArgs e)
        {
            DateTime fecha = DateTime.Now;
            string formato = "dd-MM-yyyy HH:mm:ss";
            //string formato = "HH:mm:ss";
            txthoras.Text = fecha.ToString(formato);
        }
        private void FechaHora2(object sender, RoutedEventArgs e)
        {
            DateTime fecha = DateTime.Now;
            string formato = "dd-MM-yyyy HH:mm:ss";
            //string formato = "HH:mm:ss";
            txthoras2.Text = fecha.ToString(formato);
        }

        private void bt1(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Urgencias());
        }
        private void bt2(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new UrgenciasP2());
        }
        private void bt4(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new UrgenciasP4());
        }
        private void bt5(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new UrgenciasP5());
        }
       
    }
}
