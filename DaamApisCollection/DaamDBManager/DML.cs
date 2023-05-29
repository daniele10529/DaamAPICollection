using System;

namespace DaamApiCollection
{
    namespace DaamDBManager
    {
        /// <summary>
        /// Classe per la costruzione di istruzioni SQL di tipo DML
        /// </summary>
        public class DML
        {
            //Attributi privati
            private static string cudOperation;
            private int nColumns;

            /// <summary>
            /// Costruttore di defualt
            /// </summary>
            public DML() { }

            /// <summary>
            /// Metodo per la creazione del comando Insert Into
            /// </summary>
            /// <param name="table">Tabella dove inserire il record</param>
            /// <returns>Ritorna oggetto DML con cudOperation creata(parziale)</returns>
            public DML InsertInto(string table)
            {
                cudOperation = "";
                cudOperation += "INSERT INTO " + table + " ";
                return this;
            }

            /// <summary>
            /// Metodo per definire i campi da inserire dopo il metodo InsertInto
            /// </summary>
            /// <param name="fields">Array string con i nomi dei campi</param>
            /// <returns>Ritorna oggetto DML con cudOperation creata(parziale)</returns>
            public DML Fields(params string[] fields)
            {
                string parameters = "";

                if (!(cudOperation.Contains("INSERT INTO")))
                {
                    cudOperation = "";
                    //Genera l'eccezione da gestire tramite Try Catch
                    throw new ArgumentException("Manca comando INSERT INTO");
                }
                else
                {
                    //Iterazione di tutti i parametri passati
                    foreach (string field in fields)
                    {
                        parameters += field + ",";
                        //Conta il numero di campi per il corretto inserimento dei valori
                        nColumns++;
                    }
                    //Rimuove l'ultima virgola
                    parameters = parameters.Remove(parameters.Length - 1);
                }

                cudOperation += "(" + parameters + ")" + " ";
                return this;
            }

            /// <summary>
            /// Metodo per passare i valori dei campi alla cudOperation di Insert Into
            /// </summary>
            /// <param name="values">Array string con i valori da inserire</param>
            /// <returns>Ritorna oggetto DML con cudOperation creata(parziale)</returns>
            public DML Values(params string[] values)
            {
                string parameters = "";

                //Verifica che il numero di valori passati corrisponda al numero di campi
                //della cudOperation creata
                if (values.Length != nColumns)
                {
                    cudOperation = "";
                    //Genera l'eccezione da gestire tramite Try Catch
                    throw new ArgumentException("I valori passati al metodo non corrispondo al numero di campi creati");
                }
                else
                {
                    //Iterazione di tutti i valori passati
                    foreach (string value in values)
                    {
                        parameters += value + ",";
                    }
                    //Rimuove l'ultima virgola
                    parameters = parameters.Remove(parameters.Length - 1);
                }

                cudOperation += "VALUES(" + parameters + ")";
                return this;

            }

            /// <summary>
            /// Metodo per l'update
            /// </summary>
            /// <param name="table">Tabella su cui effettuare l'update</param>
            /// <returns>Ritorna oggetto DML con cudOperation creata(parziale)</returns>
            public DML Update(string table)
            {
                cudOperation = "";
                cudOperation += "UPDATE " + table + " ";
                return this;
            }

            /// <summary>
            /// Metodo per definire i campi del comando Set con il valore assegnato al campo
            /// </summary>
            /// <param name="fieldsEqualsValues">Campo con valore assegnato separato da lsimbolo '='</param>
            /// <returns>Ritorna oggetto DML con cudOperation creata(parziale)</returns>
            public DML Set(params string[] fieldsEqualsValues)
            {
                string parameters = "";

                if (!(cudOperation.Contains("UPDATE")))
                {
                    cudOperation = "";
                    //Genera l'eccezione da gestire tramite Try Catch
                    throw new ArgumentException("Manca comando UPDATE");
                }
                else
                {
                    //Iterazione di tutti i parametri passati
                    foreach (string field in fieldsEqualsValues)
                    {
                        parameters += field + ",";
                        //Conta il numero di campi per il corretto inserimento dei valori
                        nColumns++;
                    }
                    //Rimuove l'ultima virgola
                    parameters = parameters.Remove(parameters.Length - 1);
                }

                cudOperation += "SET " + parameters + " ";
                return this;
            }

            /// <summary>
            /// Metodo per il Delete
            /// </summary>
            /// <param name="table">Tabella su cui effettuare il delete</param>
            /// <returns>Ritorna oggetto DML con cudOperation creata(parziale)</returns>
            public DML DeleteFrom(string table)
            {
                cudOperation = "";
                cudOperation += "DELETE FROM " + table;
                return this;
            }

            /// <summary>
            /// Clausula di vincolo integrità referenziale
            /// </summary>
            /// <param name="field">Campo su cui verificare la clausula</param>
            /// <returns>Ritorna oggetto DML con cudOperation creata(parziale)</returns>
            public DML Where(string field)
            {
                if ((cudOperation.Contains("SET")))
                {
                    cudOperation += "WHERE " + field + " ";
                    return this;
                }
                else if (cudOperation.Contains("DELETE FROM"))
                {
                    cudOperation += "WHERE " + field + " ";
                    return this;
                }
                else
                {   
                    cudOperation = "";
                    throw new ArgumentException("Manca comando FROM");
                }
                
            }

            /// <summary>
            /// Operatore di uguaglianza =
            /// </summary>
            /// <param name="value">Valore da confrontare</param>
            /// <returns>Ritorna oggetto DML con cudOperation creata(parziale)</returns>
            public DML Equals(int value)
            {
                if (!(cudOperation.Contains("WHERE")))
                {
                    cudOperation = "";
                    throw new ArgumentException("Manca comando WHERE");
                }
                cudOperation += "= " + value + " ";
                return this;
            }

            /// <summary>
            /// Operatore di uguaglianza =
            /// </summary>
            /// <param name="value">Valore da confrontare</param>
            /// <returns>Ritorna oggetto DML con cudOperation creata(parziale)</returns>
            public DML Equals(double value)
            {
                if (!(cudOperation.Contains("WHERE")))
                {
                    cudOperation = "";
                    throw new ArgumentException("Manca comando WHERE");
                }
                cudOperation += "= " + value + " ";
                return this;
            }

            /// <summary>
            /// Operatore di uguaglianza su stringa
            /// </summary>
            /// <param name="value">Valore da confrontare</param>
            /// <returns>Ritorna oggetto DML con cudOperation creata(parziale)</returns>
            public DML Equals(string value)
            {
                if (!(cudOperation.Contains("WHERE")))
                {
                    cudOperation = "";
                    throw new ArgumentException("Manca comando WHERE");
                }
                cudOperation += "= " + value + " ";
                return this;
            }

            /// <summary>
            /// Metodo Like confronto completo
            /// </summary>
            /// <param name="value">Valore da confrontare</param>
            /// <returns>Ritorna oggetto DML con cudOperation creata(parziale)</returns>
            public DML Like(string value)
            {
                if (!(cudOperation.Contains("WHERE")))
                {
                    cudOperation = "";
                    throw new ArgumentException("Manca comando WHERE");
                }
                cudOperation += "LIKE(%" + value + "%)";
                return this;
            }

            /// <summary>
            /// Operatore AND
            /// </summary>
            /// <param name="field">Campo successivo all'AND per il confronto</param>
            /// <returns>Ritorna oggetto DML con cudOperation creata(parziale)</returns>
            public DML And(string field)
            {
                if (!(cudOperation.Contains("WHERE")))
                {
                    cudOperation = "";
                    throw new ArgumentException("Manca comando WHERE oppure comando ON");
                }
                cudOperation += "AND " + field + " ";
                return this;
            }

            /// <summary>
            /// Inserisce il ; finale
            /// </summary>
            /// <returns>Ritorna oggetto DML con cudOperation creata(parziale)</returns>
            public DML endLine()
            {
                cudOperation += ";";
                return this;
            }

            /// <summary>
            /// Getter con l'operazione di create, update, delete creata
            /// </summary>
            /// <returns>Ritorna la stringa SQL creata</returns>
            public string getCudOperation() { return cudOperation; }
       

        }
    }
    
}
