using SistemaUrgencia_v2._0.viewLayer.RegistroUrgencias;
using System;
using System.Collections.Generic;
using System.Data;
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


namespace SistemaUrgencia_v2._0.viewLayer.ListaUrgencias
{
    public partial class listaUrgencias : Page
    {
        SqlConnection conexion = new SqlConnection("Data Source=DESKTOP-D8TLHID;Initial Catalog=UrgSqlServer;Integrated Security=True");
        public listaUrgencias()
        {
            InitializeComponent();
            String connectionString = @"Data Source=DESKTOP-D8TLHID;Initial Catalog=UrgSqlServer;Integrated Security=True";
            String sql = @"SELECT DatosUrgencia.id_datosUrgencia, DatosUrgencia.N_hoja, DatosUrgencia.Motivo_consulta, Ingresos.modo_ingreso, Ingresos.nivel_urgencia, DarCamas.destino, DarCamas.bloque, DarCamas.cama, DarCamas.habitacion,TipoPrescripcion.Prescripcion
            FROM DatosUrgencia, Ingresos, DarCamas, TipoPrescripcion
            WHERE DatosUrgencia.id_datosUrgencia = Ingresos.id AND DatosUrgencia.id_datosUrgencia = DarCamas.id AND DatosUrgencia.id_datosUrgencia = TipoPrescripcion.id_tipo_prescripcion;
            ; ";
            DataTable tabla = new DataTable();
            SqlConnection connection = new SqlConnection(connectionString);
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = new SqlCommand(sql, connection);
            adapter.Fill(tabla);
            data1.DataContext = tabla;
            connection.Close();
        }

        private void Eliminarbt(object sender, RoutedEventArgs e)
        {
            //try
            //{
                conexion.Open();
                string cod = id_datosUrgenciaTextBox.Text;
                string cadena = "DELETE FROM DatosUrgencia where id_datosUrgencia = " + cod;
                SqlCommand comando = new SqlCommand(cadena, conexion);

                string cadena2 = "DELETE FROM Ingresos WHERE  id = " + cod;
                SqlCommand comando2 = new SqlCommand(cadena2, conexion);

                string cadena3 = "DELETE FROM DarCamas WHERE  id = " + cod;
                SqlCommand comando3 = new SqlCommand(cadena3, conexion);

                int cant, cant2, cant3;
                cant = comando.ExecuteNonQuery();
                cant2 = comando2.ExecuteNonQuery();
                cant3 = comando3.ExecuteNonQuery();
                if (cant == 1 && cant2 == 1 && cant3 == 1)
                {
                    MessageBox.Show("se borro del articulo");
                    NavigationService.Navigate(new listaUrgencias());
                }
                else
                {
                    MessageBox.Show("No existe el articulo ingresado");
                }
                conexion.Close();
            //}
           // catch (Exception)
           // {

               // MessageBox.Show("ingrese el id del dato que quiere eliminar");
            //}
            
        }


    }
}
