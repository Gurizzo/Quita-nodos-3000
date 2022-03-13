using System;
using System.IO;
using System.Windows.Controls;
using System.Xml;

namespace Quita_nodos_3000
{
    internal class Servicios
    {
        internal static void QuitarNodos(ItemCollection items, string directorioInicial, string directorioFinal)
        {

            try
            {
                string[] archivos = Directory.GetFiles(directorioInicial, "*.xml");
                foreach (string archivo in archivos)
                {
                    XmlDocument doc = new XmlDocument();
                    doc.Load(archivo);

                    foreach (var xpath in items)
                    {
                        bool aunHayNodos = true;

                        while (aunHayNodos)
                        {
                            var nodo = doc.SelectSingleNode(xpath.ToString());
                            if (nodo != null)
                            {
                                var nodoPadre = nodo.ParentNode;
                                if (nodoPadre != null)
                                {
                                    nodoPadre.RemoveChild(nodo);
                                }
                            }
                            else
                            {
                                aunHayNodos = false;
                            }


                        }

                    }
                    doc.Save(directorioFinal + "\\" + Guid.NewGuid().ToString().ToLower() + ".xml");
                }

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}