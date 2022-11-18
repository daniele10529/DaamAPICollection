using System.Data;

namespace DaamApiCollection
{
    namespace DaamDBManager
    {
        /// <summary>
        /// Interfaccia di definizione del pattern per la gestione dati verso il DB
        /// </summary>
        public interface IGeneralModelData
        {
            /// <summary>
            /// Getter definisce la pagina corrente per la paginazione
            /// </summary>
            int CurrentPage { get; }
            
            /// <summary>
            /// Getter definisce il numero di pagine totali per la paginazione 
            /// </summary>
            int Pages { get; }

            /// <summary>
            /// Metodo per settare le colonne del DataTable
            /// e definire la chiave primaria
            /// </summary>
            /// <returns>Restituisce un DataTable settato per il binding al DataGridView</returns>
            DataTable defineTable();
            
            /// <summary>
            /// Metodo privato per popolare un DataGridView
            /// </summary>
            /// <param name="record">Record da Inserire in tabella</param>
            /// <param name="table">Tabella dove inserire l'oggetto</param>
            void populate(object record, DataTable table);

            /// <summary>
            /// Metodo per ottenere tutti i record di una tabella
            /// </summary>
            /// <param name="record">Record da cui ricavare la clausula di join</param>
            /// <param name="table">Tabella da popolare con i dati del mapping</param>
            /// <returns>Ritorna un DataTable per il binding di un DataGridView</returns>
            bool getAll(object record, DataTable table);

            /// <summary>
            /// Metodo per il mapping con tabulazione partendo da uno specifico index
            /// </summary>
            /// <param name="record">Record da cui ricavare la clausula di join</param>
            /// <param name="table">Tabella da popolare con i dati del mapping</param>
            /// <param name="indexStart">Indice di partenza per la tabulazione, opzionale</param>
            /// <returns>Ritorna un DataTable per il binding di un DataGridView</returns>
            bool selectData(object record, DataTable table, int indexStart = 0);

            /// <summary>
            /// Metodo per la tabulazione scorrendo in avanti di pagina
            /// </summary>
            /// <param name="record">Record da cui ricavare la clausula di join</param>
            /// <param name="table">Tabella da popolare con i dati del mapping</param>
            /// <returns>Ritorna un DataTable per il binding di un DataGridView</returns>
            bool forward(object record, DataTable table);

            /// <summary>
            /// Metodo per la tabulazione scorrendo in dietro di pagina
            /// </summary>
            /// <param name="record">Record da cui ricavare la clausula di join</param>
            /// <param name="table">Tabella da popolare con i dati del mapping</param>
            /// <returns>Ritorna un DataTable per il binding di un DataGridView</returns>
            bool back(object record, DataTable table);

            /// <summary>
            /// Metodo per l'inserimento di un record in tabella
            /// </summary>
            /// <param name="record">Record da inserire in tabella</param>
            /// <param name="table">Nome della tabella dove inserire il record, opzionale</param>
            /// <returns>Ritorna True se l'inserimento è corretto</returns>
            bool insert(object record, string table = "");

            /// <summary>
            /// Metodo per la modifica di un record della tabella
            /// </summary>
            /// <param name="record">Record con i dati aggiornati</param>
            /// <param name="table">Tabella in cui aggiornare il record, opzionale</param>
            /// <returns>Ritorna True se la modifica è corretta</returns>
            bool modifyRecord(object record, string table = "");

            /// <summary>
            /// Metodo per l'eliminazione di un record dalla tabella
            /// </summary>
            /// <param name="reccord">Record da eliminare</param>
            /// <param name="table">Tabella in cui eliminare il record, opzionale</param>
            /// <returns>Ritorna True se l'eliminazione è corretta</returns>
            bool deleteRecord(object reccord, string table = "");

        }

    }

}
