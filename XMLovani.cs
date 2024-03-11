using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Windows.Forms;

namespace zhashenii
{
    public class XMLovani
    {
        private SQLiteConnection sqlite_conn;

        public XMLovani(string databasePath)
        {
            sqlite_conn = new SQLiteConnection($"Data Source={databasePath}; Version=3;");
            CreateTable(sqlite_conn); // Vytvoří tabulku při vytváření instance
        }

        private void CreateTable(SQLiteConnection conn)
        {
            try
            {
                conn.Open();
                SQLiteCommand sqlite_cmd = conn.CreateCommand();
                string createTableQuery = "CREATE TABLE IF NOT EXISTS users (jmeno TEXT, heslo TEXT, admin BOOLEAN, ID INTEGER PRIMARY KEY AUTOINCREMENT)";
                sqlite_cmd.CommandText = createTableQuery;
                sqlite_cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Chyba při vytváření tabulky: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        public List<Uzivatel> DataLoader()
        {
            List<Uzivatel> UserList = new List<Uzivatel>();

            try
            {
                sqlite_conn.Open();
                SQLiteCommand sqlite_cmd = sqlite_conn.CreateCommand();
                sqlite_cmd.CommandText = "SELECT jmeno, heslo FROM users";

                SQLiteDataReader sqlite_datareader = sqlite_cmd.ExecuteReader();
                while (sqlite_datareader.Read())
                {
                    string jm = sqlite_datareader.GetString(0);
                    string hh = sqlite_datareader.GetString(1);
                    UserList.Add(new Uzivatel(jm, hh, false));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Chyba při načítání uživatelů z databáze: " + ex.Message);
            }
            finally
            {
                sqlite_conn.Close();
            }

            return UserList;
        }

        public void DataSavo(List<Uzivatel> useri)
        {
            try
            {
                sqlite_conn.Open();
                SQLiteCommand sqlite_cmd = sqlite_conn.CreateCommand();

                sqlite_cmd.CommandText = "DELETE FROM users";
                sqlite_cmd.ExecuteNonQuery();

                foreach (Uzivatel u in useri)
                {
                    sqlite_cmd.CommandText = $"INSERT INTO users (jmeno, heslo) VALUES ('{u.Jmeno}', '{u.HashHesla}')";
                    sqlite_cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Chyba při ukládání uživatelů do databáze: " + ex.Message);
            }
            finally
            {
                sqlite_conn.Close();
            }
        }
    }
}


















/*
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Windows.Forms;

namespace zhashenii
{
    public class XMLovani
    {
        private SQLiteConnection sqlite_conn;

        public XMLovani(string databasePath)
        {
            sqlite_conn = new SQLiteConnection($"Data Source={databasePath}; Version=3;");
        }

        public List<Uzivatel> DataLoader(string coNacitam)
        {
            List<Uzivatel> UserList = new List<Uzivatel>();
            List<Administrator> AdminList = new List<Administrator>();

            sqlite_conn.Open();
            SQLiteCommand sqlite_cmd = sqlite_conn.CreateCommand();
            sqlite_cmd.CommandText = "SELECT jmeno, heslo FROM users"; // Přizpůsobte dotaz vašim potřebám

            SQLiteDataReader sqlite_datareader = sqlite_cmd.ExecuteReader();
            while (sqlite_datareader.Read())
            {
                string jm = sqlite_datareader.GetString(0);
                string hh = sqlite_datareader.GetString(1);

                if (coNacitam == "userse")
                    UserList.Add(new Uzivatel(jm, hh, false));
                else if (coNacitam == "admins")
                    AdminList.Add(new Administrator(jm, hh, false));
            }

            sqlite_conn.Close();

            //return coNacitam == "userse" ? UserList : AdminList;
            return UserList;
        }

        public void DataSavo(List<Uzivatel> useri, List<Administrator> admini)
        {
            sqlite_conn.Open();
            SQLiteCommand sqlite_cmd = sqlite_conn.CreateCommand();
            sqlite_cmd.CommandText = "DELETE FROM users"; // Smazat všechny uživatele před uložením nových

            sqlite_cmd.ExecuteNonQuery();

            foreach (Uzivatel u in useri)
            {
                sqlite_cmd.CommandText = $"INSERT INTO users (jmeno, heslo) VALUES ('{u.Jmeno}', '{u.HashHesla}')";
                sqlite_cmd.ExecuteNonQuery();
            }

            foreach (Administrator a in admini)
            {
                sqlite_cmd.CommandText = $"INSERT INTO admins (jmeno, heslo) VALUES ('{a.Jmeno}', '{a.HashHesla}')";
                sqlite_cmd.ExecuteNonQuery();
            }

            sqlite_conn.Close();
        }
    }
}

*/











/*Původní





//#nullable enable

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace zhashenii
{
    public class XMLovani
    {
        string nameOfSaveFileInPhonebókSlashbinSlashDebugInxmlFormat__TohleNeniPhonebookAleUzivateleSHashema_TakJmenoTohoXML = "U.XML";
        private string[] xmlTags = { };

        public object DataLoader(string coNacitam)
        {
            List<Uzivatel> UserList = new List<Uzivatel>();
            List<Administrator> AdminList = new List<Administrator>();
            //UserList.Add(new Administrator("dfg", "sdf", false)); vonotodEEEEEEEEE
            bool jo = true;
            if (File.Exists(nameOfSaveFileInPhonebókSlashbinSlashDebugInxmlFormat__TohleNeniPhonebookAleUzivateleSHashema_TakJmenoTohoXML))
            {
                using (StreamReader sr = new StreamReader(nameOfSaveFileInPhonebókSlashbinSlashDebugInxmlFormat__TohleNeniPhonebookAleUzivateleSHashema_TakJmenoTohoXML))
                {
                    string line;
                    //string? jm, hh;
                    string jm = "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA";
                    string hh = "Severity\tCode\tDescription\tProject\tFile\tLine\tSuppression State\r\nError\tCS0165\tUse of unassigned local variable 'hh'\tzhashenii\tC:\\Users\\vrbickym\\Desktop\\Heč\\zhashenii\\XMLovani.cs\t39\tActive\r\n";
                    //Uzivatel zitavuel = new Uzivatel(null, null, null, null, null, false, false, false, false, false);
                    while ((line = sr.ReadLine()) != $"</{coNacitam}>")
                    {
                        if (line.Contains("<user>") || line== "<adminaccount>" || line== "<admins>" || line == "<userse>" || line == "</userse>")
                        {
                            continue;
                        }
                        else if (line.Contains("</user>") && coNacitam== "userse")
                        {
                            UserList.Add(new Uzivatel(jm, hh, false));
                            //zitavuel = new Kontakt(null, null, null, null, null, false, false, false, false, false); kontrola jestli má uživ tó a to??
                        }
                        else if (line.Contains("</adminaccount>") && coNacitam == "admins")
                        {
                            AdminList.Add(new Administrator(jm, hh, false));
                        }
                        else if (line.Contains("<meno>"))
                        {
                            //zitavuel.forname = TakCoTamJe(line);
                            //jm = sr.ReadLine();
                            jm = TakCoTamJe(line);
                        }
                        else if (line.Contains("<heslo>"))
                        {
                            hh = TakCoTamJe(line);
                        }
                    }
                    jo = false;
                }


                if (AdminList.Count == 0  &&  coNacitam == "admins"  &&  Program.prihlaseni.uzivatels.Count == 0)
                {
                    MessageBox.Show("V " + nameOfSaveFileInPhonebókSlashbinSlashDebugInxmlFormat__TohleNeniPhonebookAleUzivateleSHashema_TakJmenoTohoXML + " nic neni, to je blbý.");
                }
            }
            else
            {
                MessageBox.Show("Neni tu " + nameOfSaveFileInPhonebókSlashbinSlashDebugInxmlFormat__TohleNeniPhonebookAleUzivateleSHashema_TakJmenoTohoXML + ", bude založen nový.");
            }
            if (jo)
            {
                //nic
            }
            if(coNacitam== "userse")
                return UserList;
            else if (coNacitam== "admins")
                return AdminList;
            return new object();
        }
        

        public void DataSavo(List<Uzivatel> useri, List<Administrator> admini)
        {
            using (StreamWriter sw = new StreamWriter(nameOfSaveFileInPhonebókSlashbinSlashDebugInxmlFormat__TohleNeniPhonebookAleUzivateleSHashema_TakJmenoTohoXML))
            {
                sw.WriteLine("<userse>");
                foreach (Uzivatel u in useri)
                {
                    sw.WriteLine("   <user>");
                    sw.WriteLine("      <meno>" + u.Jmeno + "</meno>");
                    sw.WriteLine("      <heslo>" + u.HashHesla + "</heslo>");
                    sw.WriteLine("   </user>");
                }
                sw.WriteLine("</userse>");
                sw.WriteLine("<admins>");
                foreach (Administrator u in admini)
                {
                    sw.WriteLine("   <adminaccount>");
                    sw.WriteLine("      <meno>" + u.Jmeno + "</meno>");
                    sw.WriteLine("      <heslo>" + u.HashHesla + "</heslo>");
                    sw.WriteLine("   </adminaccount>");
                }
                sw.Write("</admins>");
            }
        }

        private string TakCoTamJe(string fghb)
        {
            bool uz = false;
            string value = "";
            for (int i = 0; i < fghb.Length; i++)
            {
                if (fghb[i] == '>')
                {
                    uz = true;
                }
                else if (fghb[i] == '<' && uz)
                {
                    break;
                }
                else if (uz)
                {
                    value += fghb[i];
                }
            }
            return value;
        }

    }

}
*/