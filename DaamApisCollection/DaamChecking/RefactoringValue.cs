using System;

namespace DaamApiCollection
{
    namespace DaamChecking
    {
        /// <summary>
        /// Classe per il refactoring di un valore
        /// </summary>
        public class RefactoringValue
        {

            /// <summary>
            /// Costruttore di default
            /// </summary>
            public RefactoringValue() { }

            /// <summary>
            /// Metodo per troncare alla cifra decimale stabilita un valore double
            /// </summary>
            /// <param name="value">Valore da troncare</param>
            /// <param name="maxDecimal">Numero di decimali da troncare</param>
            /// <returns>Ritorna il valore troncato in formato stringa</returns>
            public string truncateDoubleValue(string value, int maxDecimal = 0)
            {
                double showValue = 0, doubleValue = 0;

                //Se non specificato un numero di decimali per l'arrotondamento
                //viene settato alla seconda cifra decimale
                if (maxDecimal == 0) maxDecimal = 2;
                
                //Converte il valore in double
                doubleValue = Double.Parse(value);
                
                //Arrotonda alla cifra decimale stabilita
                showValue = Math.Round(doubleValue, maxDecimal);
                
                //Restituisce il valore arrotondato in formato stringa
                return showValue.ToString();

            }

            /// <summary>
            /// Metodo per troncare un stringa dopo il simbolo specificato
            /// </summary>
            /// <param name="value">Valore stringa da troncare</param>
            /// <param name="symbolToTruncate">Simbolo dove dividere la stringa</param>
            /// <param name="nChars">Nuemro di caratteri dove troncare la seconda parte della stringa</param>
            /// <returns>Ritorna la stringa troncata</returns>
            public string truncateString(string value, char symbolToTruncate, int nChars = 0)
            {

                string newPart = "", newVal;
                
                //Attributo opzionale, se non valorizzato di default è settato a 2 caratteri dopo il simbolo
                if (nChars == 0) nChars = 2;

                //Tronca la stringa dopo il simbolo specificato
                string[] parts = value.Split(symbolToTruncate);

                //Verifica sia avvenuto lo split
                if (parts.Length > 1)
                {
                    //Se la parte di stringa dopo il simbolo ha una lunghezza
                    //maggiore del numero di caratteri specificato
                    //viene troncata
                    if (parts[1].ToString().Length > nChars)
                    {
                        newPart = parts[1].ToString().Substring(0, nChars);
                        //Assegna il nuovo valore alla textbox
                        newVal = parts[0].ToString() + symbolToTruncate + newPart;
                        return newVal;
                    }
                    else
                    {
                        return value;
                    }
                }
                else
                {
                    return value;
                }

            }

        }

    }
}
    
