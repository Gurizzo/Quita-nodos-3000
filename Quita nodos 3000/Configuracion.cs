using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Quita_nodos_3000
{
    [XmlRoot(ElementName = "Configuracion")]
    public class Configuracion
    {
        [XmlElement(ElementName = "DirectorioInicio")]
        public string DirectorioInicio { get; set; }

        [XmlElement(ElementName = "DirectorioFinal")]
        public string DirectorioFinal { get; set; }

        [XmlElement(ElementName = "Xpaths")]
        public List<string> Xpaths { get; set; }

        [XmlAttribute(AttributeName = "xsi")]
        public string Xsi { get; set; }

        [XmlAttribute(AttributeName = "xsd")]
        public string Xsd { get; set; }

        [XmlText]
        public string Text { get; set; }

        internal void GuardarConfiguracion()
        {
            string directorio = AppDomain.CurrentDomain.BaseDirectory;
            XmlSerializer ser = new XmlSerializer(typeof(Configuracion));

            using (FileStream fs = new FileStream(directorio + "configuracion.xml", FileMode.Create))
            {
                ser.Serialize(fs, this);
            }
        }
        
        internal Configuracion CargarConfig()
        {
            string directorio = AppDomain.CurrentDomain.BaseDirectory;
            XmlSerializer ser = new XmlSerializer(typeof(Configuracion));
            string direccionArchivo = directorio + "configuracion.xml";
            if (File.Exists(direccionArchivo))
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(direccionArchivo);

                using (StringReader reader = new StringReader(doc.OuterXml))
                {
                    return (Configuracion)ser.Deserialize(reader);
                }
            }
            
            return null;
        }
    }
}
