using System;
using System.Xml;

namespace DaamApiCollection
{
    namespace DaamXMLParser
    {
        /// <summary>
        /// Classe per la scrittura di un file XML
        /// </summary>
        public class WriterXML
        {
            //Attributi privati
            private string pathFile;

            /// <summary>
            /// Costruttore dell'oggetto WriterXML
            /// </summary>
            /// <param name="pathFile"></param>
            public WriterXML(string pathFile)
            {
                this.pathFile = pathFile;
            }

            /// <summary>
            /// Metodo per la riscrittura di un nodo
            /// </summary>
            /// <param name="pathNode">Nodo da riscrivere</param>
            /// <param name="insertValue">Valore da inserire nel nodo</param>
            /// <returns>Ritorna true se inserimento avvenuto correttamente</returns>
            public bool reWriteNode(string pathNode, string insertValue)
            {
                try
                {

                    //Istanza alla classe XMlDoxument
                    XmlDocument doc = new XmlDocument();
                    //Carica il file
                    doc.Load(pathFile);
                    //Acquisisce il nodo dal percorso
                    XmlNode node = doc.SelectSingleNode(pathNode);
                    //Assegna al nodo il valore stringa passato
                    node.InnerText = insertValue;
                    //Salva il file XML modificato
                    doc.Save(pathFile);
                    //Ritorna true se salvataggio corretto
                    return true;

                }catch(Exception ex)
                {
                    throw new Exception("Impossibile aggiornare il file XML: " + ex.Message);
                }

            }

        }
    }
}

    
