using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Serialization;

namespace Quita_nodos_3000
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            CargarConfiguracion();
        }

        private void CargarConfiguracion()
        {
            Configuracion configuracion = new Configuracion();

            var configGuardada = configuracion.CargarConfig();

            textBoxFinal.Text = configGuardada.DirectorioFinal;
            textBoxInicial.Text = configGuardada.DirectorioInicio;

        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            List<string> list = new List<string>();
            list.Add("pruebita");
            Configuracion configuracion = new Configuracion()
            {
                DirectorioFinal = textBoxFinal.Text,
                DirectorioInicio = textBoxInicial.Text,
                Xpaths = list
            };
            configuracion.GuardarConfiguracion();

        }
        private void btnInicial_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new FolderBrowserDialog();
            
                dialog.ShowDialog();
            textBoxInicial.Text = dialog.SelectedPath;
        

        }

        private void btnFinal_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new FolderBrowserDialog();

            dialog.ShowDialog();
            textBoxFinal.Text = dialog.SelectedPath;
        }

    }
}
