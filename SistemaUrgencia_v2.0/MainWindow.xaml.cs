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
using SistemaUrgencia_v2._0.viewLayer.ListaUrgencias;
using SistemaUrgencia_v2._0.viewLayer.RegistroUrgencias;

namespace SistemaUrgencia_v2._0
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class page : Window
    {
        public page()
        {
            InitializeComponent();
        }
        private void Bt_urgencias(object sender, RoutedEventArgs e)
        {
            Main.Content = new Urgencias();
        }

        private void Vistas_Navigated(object sender, NavigationEventArgs e)
        {

        }

        private void Bt_Listas(object sender, RoutedEventArgs e)
        {
            Main.Content = new listaUrgencias();
        }

        private void Bt_Listas2(object sender, RoutedEventArgs e)
        {
            Main.Content = new listaDolicitudanalisis();
        }
        private void Bt_Listas3(object sender, RoutedEventArgs e)
        {
            Main.Content = new listaSolicitudRadio();
        }
    }
}
