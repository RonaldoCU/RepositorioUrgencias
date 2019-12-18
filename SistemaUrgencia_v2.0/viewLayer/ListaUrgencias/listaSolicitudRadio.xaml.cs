using System;
using System.Collections.Generic;
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
using System.Data.SqlClient;

namespace SistemaUrgencia_v2._0.viewLayer.ListaUrgencias
{

    public partial class listaSolicitudRadio : Page
    {
        SqlConnection conexion = new SqlConnection("Data Source=DESKTOP-D8TLHID;Initial Catalog=UrgSqlServer;Integrated Security=True");
        public listaSolicitudRadio()
        {
            InitializeComponent();
            String connectionString = @"Data Source=DESKTOP-D8TLHID;Initial Catalog=UrgSqlServer;Integrated Security=True";
            String sql = @"SELECT * FROM Imagenes";
            DataTable tabla = new DataTable();
            SqlConnection connection = new SqlConnection(connectionString);
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = new SqlCommand(sql, connection);
            adapter.Fill(tabla);
            data1.DataContext = tabla;
            connection.Close();
        }

        private void bt_eliminar(object sender, RoutedEventArgs e)
        {
            conexion.Open();
            string cod = id_imagenTextBox.Text;
            string cadena = "DELETE FROM Imagenes where id_imagen = " + cod;
            SqlCommand comando = new SqlCommand(cadena, conexion);
            int cant;
            cant = comando.ExecuteNonQuery();
            if (cant == 1)
            {
                MessageBox.Show("se borro del articulo");
                NavigationService.Navigate(new listaSolicitudRadio());
            }
            else
            {
                MessageBox.Show("No existe el articulo ingresado");
            }
            conexion.Close();
        }
    }
}
