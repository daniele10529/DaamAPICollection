using System;
using System.IO;
using MySql.Data.MySqlClient;
using DaamInputBox;
using System.Windows.Forms;

namespace DaamApiCollection.DaamDBManager
{
    /// <summary>
    /// Classe per l'esecuzione del Dump del DB
    /// </summary>
    public class Dumper
    {
        #region Attributi privati

        //Attributo privato per la stringa di connessione con il DB
        private string stringConnection;

        #endregion

        /// <summary>
        /// Costruttore per la classe Dumper per l'esecuzione del DB nel DB
        /// </summary>
        /// <param name="stringConnection">Stringa di connessione con il DB</param>
        public Dumper(string stringConnection)
        {
            this.stringConnection = stringConnection;
        }

        #region Getter and Setter

        /// <summary>
        /// Percorso della cartella dove eseguire il Dump del DB
        /// </summary>
        public string PathWhereExecuteDump { get; set; }

        /// <summary>
        /// Nome dell'applicazione richiedente il Dump
        /// Il nome viene aggiunto come nome del file .sql
        /// </summary>
        public string NameApp { get; set; }

        #endregion


        /// <summary>
        /// Esegue il Dump del DB
        /// </summary>
        /// <returns>Restituisce un messaggio in caso di Dump eseguito con successo</returns>
        public string ExecuteDump()
        {
            //Inizializzazione dell'attributo con la directory di Dump
            string finalPath = "";
            //Inizializzazione dell'attributo di estensione per file già esistente
            string estensione = "";
            //Messaggio di response
            string response = "";

            try
            {
                //Verifica sia stato settato un path dove depositare il file di dump
                if(PathWhereExecuteDump.Length == 0)
                {
                    throw new Exception("Impossibile eseguire il Dump del DB senza specificare un " +
                        "percorso per il file contenente il Dump");
                }

                //Ottiene la data odierna
                DateTime date = DateTime.Now;

                //Preleva mese e anno dalla data odierna
                int mese = date.Month;
                int anno = date.Year;
                //Forma il nome del file in modalità stringa dal mese e anno odierni
                string namefile = NameApp + "_" + mese.ToString()+ "_" + anno.ToString();

                //Se la directory non esiste la crea
                if (!(Directory.Exists(PathWhereExecuteDump + @"\" + namefile)))
                {
                    Directory.CreateDirectory(PathWhereExecuteDump + @"\" + namefile);
                    //setto il percorso finale per il dump
                    finalPath = PathWhereExecuteDump + @"\" + namefile + @"\" + namefile + ".sql";
                }
                else //Se esiste già la directory
                {
                    do
                    { 
                        //Visualizza e verifica l'InputBox per la richiesta di un'estenzione
                        if(InputBox.ShowDialog("DUMP ESISTENTE", "Scegli un'estensione per il nome del file di Dump",
                            InputBoxImage.Message) == DialogResult.OK)
                        {
                            //Ricava l'inserimento nell'InputBox
                            estensione = InputBox.AnswerResult;
                        }

                        //Se non esiste l'estensione scelta la crea
                        if (!(Directory.Exists(PathWhereExecuteDump + namefile + estensione)))
                        {
                            Directory.CreateDirectory(PathWhereExecuteDump + @"\" + namefile + estensione);
                            //Set del percorso finale per il dump
                            finalPath = PathWhereExecuteDump + @"\" + namefile + estensione + @"\" + namefile + ".sql";
                        }
                        //Cicla finche non è scelta un estensione valida
                    }
                    while (Directory.Exists(PathWhereExecuteDump + namefile + estensione));

                }

                //Connessione al DB essenziale per il dump attraverso la classe  MySqlBackup
                Connecting connecting = new Connecting(stringConnection);

                var connection = connecting.getOpenConnection();
                var command = connecting.getCommand(connection, "");
                //Istanza alla classe dopo aver aggiunto la referenza dal pacchetto nuget MySqlBackup.NET 2.3.8
                //Scaricato dall'indirizzo https://nuget.info/packages/MySqlBackup.NET/2.3.8
                MySqlBackup backup = new MySqlBackup(command);
                //Esporta il DB aperto in connessione
                backup.ExportToFile(finalPath);

                //Scarica le risorse
                command.Dispose();
                backup.Dispose();
                //Restituisce il messaggio di response
                response = "Dump eseguito con successo!!";
                return response;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
