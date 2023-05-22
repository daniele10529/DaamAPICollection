using System;
using DaamApiCollection.DaamXMLParser;


namespace DaamApiCollection
{
    namespace DaamChecking
    {
        /// <summary>
        /// Classe per la verifica dei campi di inserimento
        /// </summary>
        public class Checking
        {

            //Attributi privati
            private ReadingXML reader;
            private string pathXMlErrorFile;

            /// <summary>
            /// Costruttore di default della classe Checking
            /// </summary>
            /// <param name="pathXMlErrorFile">Path del file XML con la lista errori</param>
            public Checking(string pathXMlErrorFile)
            {
                //Associa all'attributo privato il percorso passato al costruttore
                this.pathXMlErrorFile = pathXMlErrorFile;
                //Istanzia la classe ReadingXML con il percorso passato al costruttore
                reader = new ReadingXML(pathXMlErrorFile);
            }

            /// <summary>
            /// Metodo per la verifica di un campo vuoto
            /// </summary>
            /// <param name="value">Valore stringa da verificare</param>
            /// <returns>Ritorna True se è una strigna vuota</returns>
            public bool isEmpty(string value)
            {
                //Se la stringa è vuota ritorna true
                if (value.Length == 0 || value.Length < 0) return true;
                else
                {
                    //Altrimenti se è stato specificato il file di errore
                    //ritorna l'errore specifico
                    if(pathXMlErrorFile.Length > 0)
                    {
                        throw new Exception(reader.readNodeFromPath("/ListError/Error1"));
                    }
                    //Se non è specificato un file di errore ritorna false
                    return false;
                }

            }

            /// <summary>
            /// Metodo per la verifica di un valore Numerico intero
            /// </summary>
            /// <param name="value">Valore stringa da verificare</param>
            /// <returns>Ritorna True se numerico</returns>
            public bool isNumeric(string value)
            {
                //Prova la conversione in valore intero
                int i = 0;
                bool response = int.TryParse(value, out i);

                if (response) return true;
                else
                {
                    //Altrimenti se è stato specificato il file di errore
                    //ritorna l'errore specifico
                    if (pathXMlErrorFile.Length > 0)
                    {
                        throw new Exception(reader.readNodeFromPath("/ListError/Error2"));
                    }
                    //Se non è specificato un file di errore ritorna false
                    return false;
                }
                
            }

            /// <summary>
            /// Metodo per la verifica di un valore numerico double
            /// </summary>
            /// <param name="value">Valore stringa da verificare</param>
            /// <returns>Ritorna True se valore numerico</returns>
            public bool isNumericDouble(string value)
            {
                //Prova la conversione in valore intero
                double i = 0;
                bool response = double.TryParse(value, out i);

                if (response) return true;
                else
                {
                    //Altrimenti se è stato specificato il file di errore
                    //ritorna l'errore specifico
                    if (pathXMlErrorFile.Length > 0)
                    {
                        throw new Exception(reader.readNodeFromPath("/ListError/Error2"));
                    }
                    //Se non è specificato un file di errore ritorna false
                    return false;
                }

            }

            /// <summary>
            /// Metodo per la verifica di un valore numerico float
            /// </summary>
            /// <param name="value">Valore stringa da verificare</param>
            /// <returns>Ritorna True se valore numerico</returns>
            public bool isNumericFloat(string value)
            {
                //Prova la conversione in valore intero
                float i = 0;
                bool response = float.TryParse(value, out i);

                if (response) return true;
                else
                {
                    //Altrimenti se è stato specificato il file di errore
                    //ritorna l'errore specifico
                    if (pathXMlErrorFile.Length > 0)
                    {
                        throw new Exception(reader.readNodeFromPath("/ListError/Error2"));
                    }
                    //Se non è specificato un file di errore ritorna false
                    return false;
                }

            }

            /// <summary>
            /// Metodo per la verifica di un valore stringa all'interno di un range
            /// </summary>
            /// <param name="value">Valore stringa d controllare</param>
            /// <param name="rangeMin">Valore minimo compreso nel range</param>
            /// <param name="rangeMax">Valore massimo compreso nel range</param>
            /// <returns>Ritorna True se all'interno del range</returns>
            public bool inRange(string value, int rangeMin, int rangeMax)
            {
                //Se la stringa è nulla ritorna false
                if (value.Length == 0) return false;
                //Converte in valore numerico intero
                int v = Int32.Parse(value);

                //Verifica se il valore è all'interno del range stabilito
                if (v >= rangeMin && v <= rangeMax) return true;
                else
                {
                    //Altrimenti se è stato specificato il file di errore
                    //ritorna l'errore specifico
                    if (pathXMlErrorFile.Length > 0)
                    {
                        throw new Exception(reader.readNodeFromPath("/ListError/Error13"));
                    }
                    //Se non è specificato un file di errore ritorna false
                    return false;
                }

            }

            /// <summary>
            /// Metodo per la verifica di un valore int all'interno di un range
            /// </summary>
            /// <param name="value">Valore int da verificare</param>
            /// <param name="rangeMin">Valore minimo compreso nel range</param>
            /// <param name="rangeMax">Valore massimo compreso nel range</param>
            /// <returns>Ritorna True se all'interno del range</returns>
            public bool inRange(int value, int rangeMin, int rangeMax)
            {
                
                //Verifica se il valore è all'interno del range stabilito
                if (value >= rangeMin && value <= rangeMax) return true;
                else
                {
                    //Altrimenti se è stato specificato il file di errore
                    //ritorna l'errore specifico
                    if (pathXMlErrorFile.Length > 0)
                    {
                        throw new Exception(reader.readNodeFromPath("/ListError/Error13"));
                    }
                    //Se non è specificato un file di errore ritorna false
                    return false;
                }

            }

        }

    }
}
   
