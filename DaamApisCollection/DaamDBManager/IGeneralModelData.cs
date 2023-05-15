using System.Collections.Generic;
using System.Data;

namespace DaamApiCollection
{
    namespace DaamDBManager
    {
        /// <summary>
        /// Interfaccia di definizione del pattern per la gestione dati verso il DB.
        /// Rimane come promemoria per la costruzione delle classi da non implementare!!
        /// L'implementazione crea troppi vincoli per l'utilizzo delle specifiche strutture di record
        /// </summary>
        public interface IGeneralModelData<T>
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
            DataTable getTable();

            /// <summary>
            /// Metodo per ottenere tutti i record di una tabella, popola il DataTable
            /// </summary>
            /// <param name="record">Record da cui ricavare la clausula di join</param>
            /// <returns>Ritorna true se il mapping è avvenuto correttamente</returns>
            bool getAll(T record);

            /// <summary>
            /// Metodo per ottenere tutti i record di una tabella, popola il DataTable
            /// </summary>
            /// <param name="record">Record da cui ricavare la clausula di join</param>
            /// <param name="param">Parametro aggiuntivo come clausula di join</param>
            /// <returns>Ritorna true se il mapping è avvenuto correttamente</returns>
            bool getAll(T record, string param);

            /// <summary>
            /// Metodo per ottenere tutti i record di una tabella attraverso una lista di tipo ADT
            /// </summary>
            /// <param name="condition">Condizione opzionale di creazione della lista</param>
            /// <returns>Ritorna una lista di oggetti ADT</returns>
            List<T> getAll(bool condition);

            /// <summary>
            /// Metodo per ottenere tutti i record di una tabella, popola un proprio DataTable
            /// </summary>
            /// <returns>Ritorna una DataTable popolato</returns>
            DataTable getAll();

            /// <summary>
            /// Metodo per il mapping con tabulazione partendo da uno specifico index, popola il DataTable
            /// </summary>
            /// <param name="record">Record da cui ricavare la clausula di join</param>
            /// <param name="indexStart">Indice di partenza per la tabulazione, opzionale</param>
            /// <returns>Ritorna true se il mapping è avvenuto correttamente</returns>
            bool selectData(T record, int indexStart = 0);

            /// <summary>
            /// Metodo per ricavare uno o più record in base ai criteri di ricerca, popola il DataTable
            /// </summary>
            /// <param name="record">Record da cercare nel DB</param>
            /// <returns>Ritorna true se il mapping è avvenuto correttamente</returns>
            bool find(T record);

            /// <summary>
            /// Metodo per ricavare uno o più record in base ai criteri di ricerca, popola il DataTable
            /// </summary>
            /// <param name="record">Record da cercare nel DB</param>
            /// <param name="param">Parametro aggiuntivo di ricerca</param>
            /// <returns>Ritorna true se il mapping è avvenuto correttamente</returns>
            bool find(T record, string param);

            /// <summary>
            /// Metodo per la tabulazione scorrendo in avanti di pagina
            /// </summary>
            /// <param name="record">Record da cui ricavare la clausula di join</param>
            void forward(T record);

            /// <summary>
            /// Metodo per la tabulazione scorrendo in dietro di pagina
            /// </summary>
            /// <param name="record">Record da cui ricavare la clausula di join</param>
            void back(T record);

            /// <summary>
            /// Metodo per l'inserimento di un record in tabella
            /// </summary>
            /// <param name="record">Record da inserire in tabella</param>
            /// <param name="param">Nome della tabella dove inserire il record, opzionale</param>
            /// <returns>Ritorna True se l'inserimento è corretto</returns>
            bool insert(T record, string param = "");

            /// <summary>
            /// Metodo per la modifica di un record della tabella
            /// </summary>
            /// <param name="record">Record con i dati aggiornati</param>
            /// <param name="param">Tabella in cui aggiornare il record, opzionale</param>
            /// <returns>Ritorna True se la modifica è corretta</returns>
            bool update(T record, string param = "");

            /// <summary>
            /// Metodo per l'eliminazione di un record dalla tabella
            /// </summary>
            /// <param name="reccord">Record da eliminare</param>
            /// <param name="param">Tabella in cui eliminare il record, opzionale</param>
            /// <returns>Ritorna True se l'eliminazione è corretta</returns>
            bool delete(T reccord, string param = "");

        }

    }

}
