using System;

namespace DaamApiCollection
{
    namespace DaamDBManager
    {
        /// <summary>
        /// Classe per la costruzione di istruzioni SQL di tipo DQL
        /// </summary>
        public class DQL
        {
            //Attributo privato
            private static string query;

            /// <summary>
            /// Metodo per la creazione del comando Select
            /// </summary>
            /// <param name="field">Campo per il Select</param>
            /// <param name="distinct">Funzione Distinct opzionale</param>
            /// <returns>Ritorna oggetto DQL con query creata(parziale)</returns>
            public DQL Select(string field = "*", bool distinct = false)
            {
                query = "";

                if (distinct) query += "SELECT DISTINCT" + field + " ";
                else query += "SELECT " + field + " ";
                return this;
            }

            /// <summary>
            /// Metodo per la creazione del comando From
            /// </summary>
            /// <param name="table">Tabella su cui fare il mapping</param>
            /// <returns>Ritorna oggetto DQL con query creata(parziale)</returns>
            public DQL From(string table)
            {
                if (!(query.Contains("SELECT")))
                {
                    query = "";
                    //Genera l'eccezione da gestire tramite Try Catch
                    throw new ArgumentException("Manca comando SELECT");
                }
                query += "FROM " + table + " ";
                return this;

            }

            /// <summary>
            /// Metodo per la creazione dell'Inner Join
            /// </summary>
            /// <param name="table">Tabella con cui fare l'InnerJoin</param>
            /// <returns>Ritorna oggetto DQL con query creata(parziale)</returns>
            public DQL InnerJoin(string table)
            {
                if (!(query.Contains("FROM")))
                {
                    query = "";
                    //Genera l'eccezione da gestire tramite Try Catch
                    throw new ArgumentException("Manca comando FROM");
                }
                query += "INNER JOIN " + table + " ";
                return this;
            }

            /// <summary>
            /// Clausula di vincolo integrità referenziale
            /// </summary>
            /// <param name="field">Campo su cui verificare la clausula</param>
            /// <returns>Ritorna oggetto DQL con query creata(parziale)</returns>
            public DQL Where(string field)
            {
                if (!(query.Contains("FROM")))
                {
                    query = "";
                    throw new ArgumentException("Manca comando FROM");
                }
                query += "WHERE " + field + " ";
                return this;
            }

            /// <summary>
            /// Metodo per l'estrazione paginata con il comando LIMIT
            /// </summary>
            /// <param name="startIndex">Indice di partenza per l'estrazione</param>
            /// <param name="maxRows">Numero Max di righe da estrarre</param>
            /// <returns>Ritorna oggetto DQL con query creata(parziale)</returns>
            public DQL Limit(int startIndex, int maxRows)
            {
                if (!(query.Contains("WHERE")))
                {
                    query = "";
                    throw new ArgumentException("Manca comando Where");
                }
                query += $"LIMIT {startIndex},{maxRows}";
                return this;
            }

            /// <summary>
            /// Clausula di vincolo integrità referenziale
            /// </summary>
            /// <param name="field">Campo su cui verificare la clausula</param>
            /// <returns>Ritorna oggetto DQL con query creata(parziale)</returns>
            public DQL ON(string field)
            {
                if (!(query.Contains("INNER JOIN")))
                {
                    query = "";
                    throw new ArgumentException("Manca comando INNER JOIN");
                }
                query += "ON " + field + " ";
                return this;
            }

            /// <summary>
            /// Operatore di uguaglianza =
            /// </summary>
            /// <param name="value">Valore da confrontare</param>
            /// <returns>Ritorna oggetto DQL con query creata(parziale)</returns>
            public DQL Equals(int value)
            {
                if (!(query.Contains("WHERE")))
                {
                    query = "";
                    throw new ArgumentException("Manca comando WHERE");
                }
                query += "= " + value + " ";
                return this;
            }

            /// <summary>
            /// Operatore di uguaglianza =
            /// </summary>
            /// <param name="value">Valore da confrontare</param>
            /// <returns>Ritorna oggetto DQL con query creata(parziale)</returns>
            public DQL Equals(double value)
            {
                if (!(query.Contains("WHERE")))
                {
                    query = "";
                    throw new ArgumentException("Manca comando WHERE");
                }
                query += "= " + value + " ";
                return this;
            }

            /// <summary>
            /// Operatore di uguaglianza su stringa
            /// </summary>
            /// <param name="value">Valore da confrontare</param>
            /// <returns>Ritorna oggetto DQL con query creata(parziale)</returns>
            public DQL Equals(string value)
            {
                if (!(query.Contains("WHERE")))
                {
                    query = "";
                    throw new ArgumentException("Manca comando WHERE");
                }
                query += "= " + value + " ";
                return this;
            }

            /// <summary>
            /// Metodo Like confronto completo
            /// </summary>
            /// <param name="value">Valore da confrontare</param>
            /// <returns>Ritorna oggetto DQL con query creata(parziale)</returns>
            public DQL Like(string value)
            {
                if (!(query.Contains("WHERE")))
                {
                    query = "";
                    throw new ArgumentException("Manca comando WHERE");
                }
                query += "LIKE(%" + value + "%)";
                return this;
            }

            /// <summary>
            /// Operatore AND
            /// </summary>
            /// <param name="field">Campo successivo all'AND per il confronto</param>
            /// <returns>Ritorna oggetto DQL con query creata(parziale)</returns>
            public DQL And(string field)
            {
                if(query.Contains("INNER JOIN"))
                {
                    if (!(query.Contains("ON")))
                    {
                        query = "";
                        throw new ArgumentException("Manca comando ON");
                    }
                }
                else
                {
                      if (!(query.Contains("WHERE")))
                      {
                          query = "";
                          throw new ArgumentException("Manca comando WHERE");
                     }
                }
                
                query += "AND " + field + " ";
                return this;
            }

            /// <summary>
            /// Inserisce il ; finale
            /// </summary>
            /// <returns>Ritorna oggetto DQL con query creata(parziale)</returns>
            public DQL endLine()
            {
                query += ";";
                return this;
            }

            /// <summary>
            /// Getter query creata
            /// </summary>
            /// <returns>Ritorna la stringa query SQL creata</returns>
            public string getQuery() { return query; }

        }
    }
}
    
