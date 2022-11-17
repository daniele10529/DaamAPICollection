using System;
using System.Collections.Generic;
using System.Xml;

namespace DaamApiCollection
{
    namespace DaamXMLParser
    {
        /// <summary>
        /// Classe per la lettura di file XML
        /// </summary>
        public class ReadingXML
        {
            //Attributi privati
            private string pathFile;

            /// <summary>
            /// Costruttore dell'oggetto ReadingXML
            /// </summary>
            /// <param name="pathFile">Percorso del file XML da leggere</param>
            public ReadingXML(string pathFile)
            {
                this.pathFile = pathFile;
            }

            /// <summary>
            /// Metodo per la lettura di un nodo di un file XML
            /// </summary>
            /// <param name="node">Nome del nodo da leggere</param>
            /// <returns>Ritorna il valore string del nodo</returns>
            public string readNode(string node)
            {
                try
                {

                    //Istanza alla classe XmlReader con il percorso del file
                    XmlReader xmr = XmlReader.Create(pathFile);
                    //Ricava il nodo dal nome
                    xmr.ReadToFollowing(node);
                    //Legge il contenuto del nodo
                    string value = xmr.ReadElementContentAsString();
                    //Ritorna il valore stringa del nodo
                    return value;

                }
                catch(Exception ex)
                {
                    throw new Exception("Impossibile leggere il nodo: " + ex.Message);
                }
                
            }

            /// <summary>
            /// Metodo per la lettura di più nodi uguali
            /// </summary>
            /// <param name="pathNodes">Percorso dei nodi da leggere</param>
            /// <returns>Ritorna una lista con i valori stringa dei nodi</returns>
            public List<string> readNodesFromPath(string pathNodes)
            {
                try
                {

                    List<string> values = new List<string>();

                    //Istanza alla classe XmlDocument
                    XmlDocument xml = new XmlDocument();

                    //Carica il file XML
                    xml.Load(pathFile);
                    //Ricava il percorso gerarchico dei nodi dal percorso passato come argomento
                    XmlNodeList nodelist = xml.SelectNodes(pathNodes);

                    //Cicla tra i nodi e ne ricava il valore
                    foreach (XmlNode node in nodelist)
                    {
                        //Assegna il valore alla lista
                        values.Add(node.InnerText);
                    }

                    //Ritorna la lista contenente i valori dei nodi
                    return values;

                }
                catch(Exception ex)
                {
                    throw new Exception("Impossibile leggere i nodi:" + ex.Message);
                }
                
            }

            /// <summary>
            /// Metodo per la lettura di un nodo
            /// </summary>
            /// <param name="pathNodes">Percorso del nodo da leggere</param>
            /// <returns>Ritorna il valore stringa del nodo</returns>
            public string readNodeFromPath(string pathNodes)
            {
                try
                {

                    //Istanza alla classe XmlDocument
                    XmlDocument xml = new XmlDocument();
                    //Carica il file XML
                    xml.Load(pathFile);

                    //Ricava il valore del nodo
                    XmlNode node = xml.SelectSingleNode(pathNodes);
                    //Ricava il valore stringa del contenuto del nodo
                    string value = node.InnerText;

                    //Ritorna la lista contenente i valori dei nodi
                    return value;

                }
                catch(Exception ex)
                {
                    throw new Exception("Impossibile leggere il nodo:" + ex.Message);
                }              

            }

        }

    }
}
    
