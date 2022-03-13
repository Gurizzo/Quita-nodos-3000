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


            var configGuardada = Configuracion.CargarConfig();
            if (configGuardada != null)
            {
                textBoxFinal.Text = configGuardada.DirectorioFinal;
                textBoxInicial.Text = configGuardada.DirectorioInicio;
                foreach (var item in configGuardada.Xpaths)
                {
                    listXpath.Items.Add(item);
                }
            }
            

        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                List<string> list = new List<string>();
                foreach (var item in listXpath.Items)
                {
                    list.Add(item.ToString());
                }
                Configuracion configuracion = new Configuracion()
                {
                    DirectorioFinal = textBoxFinal.Text,
                    DirectorioInicio = textBoxInicial.Text,
                    Xpaths = list
                };
                configuracion.GuardarConfiguracion();

                System.Windows.MessageBox.Show("Configuracion guardada con exito.", "Configuracion", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {

                System.Windows.MessageBox.Show(ex.Message, "Error interno", MessageBoxButton.OK, MessageBoxImage.Error);
            }

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

        private void button_Click(object sender, RoutedEventArgs e)
        {
            listXpath.Items.Add(xpathtxt.Text);
            xpathtxt.Text = "";
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                listXpath.Items.RemoveAt(listXpath.Items.IndexOf(listXpath.SelectedItem));
            }
            catch (Exception ex)
            {

                System.Windows.MessageBox.Show(ex.Message, "Error interno", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            

        }

        private void btnEjecutar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Servicios.QuitarNodos(listXpath.Items, textBoxInicial.Text, textBoxFinal.Text);
                System.Windows.MessageBox.Show("Nodos removidos con exito.","Tarea completada",MessageBoxButton.OK);
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message, "Error interno", MessageBoxButton.OK, MessageBoxImage.Error);
                
            }
            
           
        }
    }
}
