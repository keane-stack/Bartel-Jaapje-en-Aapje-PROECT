using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace Bartel_Jaapje_en_Aapje_PROECT.Database
{
    public static class DatabaseConnector
    {
        // stel in waar de database gevonden kan worden
        static string connectionString = "Server=172.16.160.21;Port=3306;Database=110735;Uid=110735;Pwd=inf2122sql;";

        public static List<Dictionary<string, object>> GetRows(string query)
        {          

            // maak een lege lijst waar we de namen in gaan opslaan
            List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();


            // verbinding maken met de database
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                // verbinding openen
                conn.Open();

                // SQL query die we willen uitvoeren
                MySqlCommand cmd = new MySqlCommand(query, conn);

                // resultaat van de query lezen
                using (var reader = cmd.ExecuteReader())
                {
                    var tableData = reader.GetSchemaTable();

                    // elke keer een regel (of eigenlijk: database rij) lezen
                    while (reader.Read())
                    {
                        var row = new Dictionary<string, object>();

                        // haal voor elke kolom de waarde op en voeg deze toe
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            row[reader.GetName(i)] = reader.GetValue(i);
                        }

                        rows.Add(row);
                    }
                }
            }

            // return de lijst met namen
            return rows;
        }
        public static void SavePerson(Person person)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("INSERT INTO klant(voornaam, achternaam, email, telefoon, adres, beschrijving) VALUES(?voornaam, ?achternaam, ?email, ?telefoon, ?adres, ?beschrijving)", conn);

                // Elke parameter moet je handmatig toevoegen aan de query
                cmd.Parameters.Add("?voornaam", MySqlDbType.Text).Value = person.Voornaam;
                cmd.Parameters.Add("?achternaam", MySqlDbType.Text).Value = person.Achternaam;
                cmd.Parameters.Add("?email", MySqlDbType.Text).Value = person.Email;
                cmd.Parameters.Add("?telefoon", MySqlDbType.Text).Value = person.Telefoonnummer;
                cmd.Parameters.Add("?adres", MySqlDbType.Text).Value = person.Adres;
                cmd.Parameters.Add("?beschrijving", MySqlDbType.Text).Value = person.Beschrijving;                
                cmd.ExecuteNonQuery();
            }
        }   
    }
}
