using System;
using MySql.Data.MySqlClient;
using System.Data;

namespace DaamApiCollection
{
    namespace DaamDBManager
    {
        /// <summary>
        /// Classe per la connessione con un DB MySql
        /// </summary>
        public class Connecting
        {
            //Attributi privati
            private string strConnection;

            /// <summary>
            /// Costruttore dell'oggetto Connecting
            /// </summary>
            /// <param name="strConnection">Stringa per la connessione al DB</param>
            public Connecting(string strConnection)
            {
                this.strConnection = strConnection;
            }

            /// <summary>
            /// Metodo per aprire una connessione al DB MySql
            /// </summary>
            /// <returns>Restituisce una connessione aperta</returns>
            public MySqlConnection getOpenConnection()
            {
                MySqlConnection conn = null;
                try
                {
                    //Crea una connessione al DB MySql e la apre
                    conn = new MySqlConnection(strConnection);
                    conn.Open();
                    //Restituisce la connessione aperta
                    return conn;

                }
                catch (Exception ex)
                {
                    throw new Exception("Impossibile aprire una connessione con il DB");
                }

            }

            /// <summary>
            /// Metodo per creare un Command con query associata
            /// </summary>
            /// <param name="connection">Connessione aperta</param>
            /// <param name="query">Query da associare al Command</param>
            /// <returns>Ritorna un Command da eseguire</returns>
            public MySqlCommand getCommand(MySqlConnection connection, string query)
            {
                //Crea un oggetto command e lo restituisce
                MySqlCommand command;

                try
                {
                    command = new MySqlCommand(query, connection);
                    return command;
                }
                catch (Exception ex)
                {
                    throw new Exception("Impossibile creare il Command");
                }

            }

            /// <summary>
            /// Metodo per la creazione di un Reader
            /// </summary>
            /// <param name="command">Command con query associata</param>
            /// <returns>Restituisce un Reader per la lettura dati da DB</returns>
            public MySqlDataReader getReader(MySqlCommand command)
            {
                MySqlDataReader read;
                try
                {
                    //Esegue la query ed assegna il risultato ad un oggetto MysqlReader
                    read = command.ExecuteReader();
                    //restituisce l'oggetto
                    return read;
                }
                catch (Exception ex)
                {
                    throw new Exception("Impossibile creare il Reader");
                }

            }

            /// <summary>
            /// Metodo per la creazione di un Reader con query da associare
            /// </summary>
            /// <param name="command">Command con query associata</param>
            /// <returns>Restituisce un Reader per la lettura dati da DB</returns>
            public MySqlDataReader getReader(MySqlCommand command, string query)
            {
                MySqlDataReader read;
                try
                {
                    //Associa la query al command
                    command.CommandText = query;
                    //esegue la query ed assegna il risultato ad un oggetto MysqlReader
                    read = command.ExecuteReader();
                    //restituisce l'oggetto
                    return read;
                }
                catch (Exception ex)
                {
                    throw new Exception("Impossibile creare il Reader");
                }

            }

            /// <summary>
            /// Metodo per popolare una tabella attraverso un DataAdapter
            /// </summary>
            /// <param name="command">Command con query associata</param>
            /// <param name="table">Tabella da popolare</param>
            public void bindingDataTable(MySqlCommand command, DataTable table)
            {
                try
                {
                    //Istanza a un DataAdapter a cui passa un Command con query associata
                    MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                    //Popola la tabella 
                    adapter.Fill(table);
                }
                catch (Exception ex)
                {
                    throw new Exception("Impossibile popolare la tabella attraverso il DataAdapter");
                }

            }

            /// <summary>
            /// Metodo per eseguire un inserimento nel DB
            /// </summary>
            /// <param name="command">Command con query si inserimento associata</param>
            /// <returns>Ritorna il numero di righe interessate dal CUD</returns>
            public int writer(MySqlCommand command)
            {
                try
                {
                    //Esegue la query associata al Command 
                    int rows = command.ExecuteNonQuery();
                    //Se la query ha avuto esito restituisce il numero di righe inserite
                    if (rows > 0) return rows;
                    //Altrimenti restituisce un eccezione
                    else throw new Exception("Nessuna riga inserita");

                }
                catch(Exception ex)
                {
                    throw new Exception("Impossibile inserire i dati nel DB");
                }

            }

        }

    }
}

