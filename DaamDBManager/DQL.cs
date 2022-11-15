using System;

namespace DaamApiCollection
{
    namespace DaamDBManager
    {
        /// <summary>
        /// Classe per i comandi Sql di tipo DQL
        /// </summary>
        public class DQL
        {
            private static string query;

            /// <summary>
            /// Metodo per la creazione del comando Select
            /// </summary>
            /// <param name="field">Campo per il Select</param>
            /// <param name="distinct">Funzione Distinct opzionale</param>
            /// <returns>Ritorna l'oggetto DQL</returns>
            public DQL Select(string field = "*", bool distinct = false)
            {
                DQL.query = "";

                if (distinct) DQL.query += "SELECT DISTINCT" + field + " ";
                else DQL.query += "SELECT " + field + " ";
                return this;
            }

            /// <summary>
            /// Metodo per la creazione del comando From
            /// </summary>
            /// <param name="table">Tabella su cui fare il mapping</param>
            /// <returns>Ritorna l'oggetto DQL</returns>
            public DQL From(string table)
            {
                if (!(DQL.query.Contains("SELECT")))
                {
                    DQL.query = "";
                    //Genera l'eccezione da gestire tramite Try Catch
                    throw new Exception("Manca comando SELECT");
                }
                DQL.query += "FROM " + table + " ";
                return this;

            }

            /// <summary>
            /// Metodo per la creazione dell'Inner Join
            /// </summary>
            /// <param name="table">Tabella con cui fare l'InnerJoin</param>
            /// <returns>Ritorna l'oggetto DQL</returns>
            public DQL InnerJoin(string table)
            {
                if (!(DQL.query.Contains("FROM")))
                {
                    DQL.query = "";
                    //Genera l'eccezione da gestire tramite Try Catch
                    throw new Exception("Manca comando FROM");
                }
                DQL.query += "INNER JOIN " + table + " ";
                return this;
            }

            /// <summary>
            /// Clausula di vincolo integrità referenziale
            /// </summary>
            /// <param name="field">Campo su cui verificare la clausula</param>
            /// <returns>Ritorna oggetto DQL con DQL.query creata(parziale)</returns>
            public DQL Where(string field)
            {
                if (!(DQL.query.Contains("FROM")))
                {
                    DQL.query = "";
                    throw new ArgumentException("Manca comando FROM");
                }
                DQL.query += "WHERE " + field + " ";
                return this;
            }

            /// <summary>
            /// Clausula di vincolo integrità referenziale
            /// </summary>
            /// <param name="field">Campo su cui verificare la clausula</param>
            /// <returns>Ritorna oggetto DQL con DQL.query creata(parziale)</returns>
            public DQL ON(string field)
            {
                if (!(DQL.query.Contains("INNER JOIN")))
                {
                    DQL.query = "";
                    throw new ArgumentException("Manca comando INNER JOIN");
                }
                DQL.query += "ON " + field + " ";
                return this;
            }

            /// <summary>
            /// Operatore di uguaglianza =
            /// </summary>
            /// <param name="value">Valore da confrontare</param>
            /// <returns>Ritorna oggetto DQL con DQL.query creata(parziale)</returns>
            public DQL Equals(int value)
            {
                if (!(DQL.query.Contains("WHERE")))
                {
                    DQL.query = "";
                    throw new ArgumentException("Manca comando WHERE");
                }
                DQL.query += "= " + value + " ";
                return this;
            }

            /// <summary>
            /// Operatore di uguaglianza =
            /// </summary>
            /// <param name="value">Valore da confrontare</param>
            /// <returns>Ritorna oggetto DQL con DQL.query creata(parziale)</returns>
            public DQL Equals(double value)
            {
                if (!(DQL.query.Contains("WHERE")))
                {
                    DQL.query = "";
                    throw new ArgumentException("Manca comando WHERE");
                }
                DQL.query += "= " + value + " ";
                return this;
            }

            /// <summary>
            /// Operatore di uguaglianza su stringa
            /// </summary>
            /// <param name="value">Valore da confrontare</param>
            /// <returns>Ritorna oggetto DQL con DQL.query creata(parziale)</returns>
            public DQL Equals(string value)
            {
                if (!(DQL.query.Contains("WHERE")))
                {
                    DQL.query = "";
                    throw new ArgumentException("Manca comando WHERE");
                }
                DQL.query += "= " + value + " ";
                return this;
            }

            /// <summary>
            /// Metodo Like confronto completo
            /// </summary>
            /// <param name="value">Valore da confrontare</param>
            /// <returns>Ritorna oggetto DQL con DQL.query creata(parziale)</returns>
            public DQL Like(string value)
            {
                if (!(DQL.query.Contains("WHERE")))
                {
                    DQL.query = "";
                    throw new ArgumentException("Manca comando WHERE");
                }
                DQL.query += "LIKE(%" + value + "%)";
                return this;
            }

            /// <summary>
            /// Operatore AND
            /// </summary>
            /// <param name="field">Campo successivo all'AND per il confronto</param>
            /// <returns>Ritorna oggetto DQL con DQL.query creata(parziale)</returns>
            public DQL And(string field)
            {
                if (!(DQL.query.Contains("WHERE")) || !(DQL.query.Contains("ON")))
                {
                    DQL.query = "";
                    throw new ArgumentException("Manca comando WHERE oppure comando ON");
                }
                DQL.query += "AND " + field + " ";
                return this;
            }

            /// <summary>
            /// Inserisce il ; finale
            /// </summary>
            /// <returns>Ritorna oggetto DQL con DQL.query creata(parziale)</returns>
            public DQL endLine()
            {
                DQL.query += ";";
                return this;
            }

            /// <summary>
            /// Getter DQL.query creata
            /// </summary>
            /// <returns>Restituisce la DQL.query creata</returns>
            public string getQuery() { return DQL.query; }

        }
    }
}
    
