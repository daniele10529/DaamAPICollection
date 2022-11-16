using System;

namespace DaamApiCollection
{
    namespace DaamDBManager
    {
        /// <summary>
        /// Classe per la costruzione di istruzioni SQL di tipo DML
        /// </summary>
        class DML : DQL
        {
            //Attributi privati
            private static string query;
            private int nColumns;

            /// <summary>
            /// Costruttore di defualt
            /// </summary>
            public DML() { }

            /// <summary>
            /// Metodo per la creazione del comando Insert Into
            /// </summary>
            /// <param name="table">Tabella dove inserire il record</param>
            /// <returns>Ritorna oggetto DML con query creata(parziale)</returns>
            public DML InsertInto(string table)
            {
                query = "";
                query += "INSERT INTO " + table + " ";
                return this;
            }

            /// <summary>
            /// Metodo per definire i campi da inserire dopo il metodo InsertInto
            /// </summary>
            /// <param name="fields">Array string con i nomi dei campi</param>
            /// <returns>Ritorna oggetto DML con query creata(parziale)</returns>
            public DML Fields(params string[] fields)
            {
                string parameters = "";

                if (!(query.Contains("INSERT INTO")))
                {
                    query = "";
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
                    parameters.Remove(parameters.Length - 1);
                }

                query += "(" + parameters + ")" + " ";
                return this;
            }

            /// <summary>
            /// Metodo per passare i valori dei campi alla query di Insert Into
            /// </summary>
            /// <param name="values">Array string con i valori da inserire</param>
            /// <returns>Ritorna oggetto DML con query creata(parziale)</returns>
            public DML Values(params string[] values)
            {
                string parameters = "";

                //Verifica che il numero di valori passati corrisponda al numero di campi
                //della query creata
                if (values.Length != nColumns)
                {
                    query = "";
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
                    parameters.Remove(parameters.Length - 1);
                }

                return this;

            }

            /// <summary>
            /// Metodo per l'update
            /// </summary>
            /// <param name="table">Tabella su cui effettuare l'update</param>
            /// <returns>Ritorna oggetto DML con query creata(parziale)</returns>
            public DML Update(string table)
            {
                query = "";
                query += "UPDATE " + table;
                return this;
            }

            /// <summary>
            /// Metodo per definire i campi del comando Set con il valore assegnato al campo
            /// </summary>
            /// <param name="fieldsEqualsValues">Campo con valore assegnato separato da lsimbolo '='</param>
            /// <returns>Ritorna oggetto DML con query creata(parziale)</returns>
            public DML Set(params string[] fieldsEqualsValues)
            {
                string parameters = "";

                if (!(query.Contains("UPDATE")))
                {
                    query = "";
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
                    parameters.Remove(parameters.Length - 1);
                }

                query += "SET " + parameters + " ";
                return this;
            }

            /// <summary>
            /// Metodo per il Delete
            /// </summary>
            /// <param name="table">Tabella su cui effettuare il delete</param>
            /// <returns>Ritorna oggetto DML con query creata(parziale)</returns>
            public DML DeleteFrom(string table)
            {
                query = "";
                query += "DELETE FORM " + table;
                return this;
            }

        }
    }
    
}
