using System.Collections.Generic;
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
            /// Getter definisce la tabella da valorizzare nei
            /// metodi per il binding con il DataGridView
            /// </summary>
            DataTable getTable { get; }

            /// <summary>
            /// Metodo per ottenere tutti i record di una tabella, popola il DataTable
            /// </summary>
            /// <param name="record">Record da cui ricavare la clausula di join</param>
            /// <returns>Ritorna true se il mapping è avvenuto correttamente</returns>
            bool getAll(object record);

            /// <summary>
            /// Metodo per ottenere tutti i record di una tabella attraverso una lista di tipo ADT
            /// </summary>
            /// <param name="condition">Condizione opzionale di creazione della lista</param>
            /// <returns>Ritorna una lista di oggetti ADT</returns>
            List<object> getAll(bool condition = false);

            /// <summary>
            /// Metodo per ottenere tutti i record di una tabella, popola un proprio DataTable
            /// </summary>
            /// <returns>Ritorna una DataTable popolato</returns>
            DataTable getAll();

            /// <summary>
            /// Metodo per il mapping con tabulazione partendo da uno specifico index, popola il DataTable
            /// </summary>
            /// <param name="record">Record da cui ricavare la clausula di join</param>
            /// <param name="table">Tabella da popolare con i dati del mapping</param>
            /// <param name="indexStart">Indice di partenza per la tabulazione, opzionale</param>
            /// <returns>Ritorna true se il mapping è avvenuto correttamente</returns>
            bool selectData(object record, DataTable table, int indexStart = 0);

            /// <summary>
            /// Metodo per ricavare uno o più record in base ai criteri di ricerca, popola il DataTable
            /// </summary>
            /// <param name="record">Record da cercare nel DB</param>
            /// <returns>Ritorna true se il mapping è avvenuto correttamente</returns>
            bool find(object record);

            /// <summary>
            /// Metodo per la tabulazione scorrendo in avanti di pagina
            /// </summary>
            /// <param name="record">Record da cui ricavare la clausula di join</param>
            void forward(object record);

            /// <summary>
            /// Metodo per la tabulazione scorrendo in dietro di pagina
            /// </summary>
            /// <param name="record">Record da cui ricavare la clausula di join</param>
            void back(object record);

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
            bool update(object record, string table = "");

            /// <summary>
            /// Metodo per l'eliminazione di un record dalla tabella
            /// </summary>
            /// <param name="reccord">Record da eliminare</param>
            /// <param name="table">Tabella in cui eliminare il record, opzionale</param>
            /// <returns>Ritorna True se l'eliminazione è corretta</returns>
            bool delete(object reccord, string table = "");

        }

    }

}
