using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.Data;

namespace TSVKDB
{
   
    
    public class dbconnect
    {
        //Attributes

        private DataTable table = new DataTable();
        private MySqlConnection connection;
        private MySqlDataAdapter adapter;




        // Functions
        public dbconnect()
        {
          
        }

        // DB Verbindung
        public bool connect()
        {
            try
            {
                connection = new MySqlConnection("server=homenas.dnshome.de;Port=3306;database=teamdb;User ID=teamdb;Password=admin;Charset=utf8");

                if (connection.State == System.Data.ConnectionState.Closed)
                {
                    connection.Open();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch(Exception e)
            {

                return false;
                
            }
        }

        // User Login
        public bool logInUser(String name, String password)
        {
           table = new DataTable();
           String query = "select login, pass from benutzer where login = '" + name + "' and pass = '" + password + "'";
           adapter = new MySqlDataAdapter(query, connection);
           adapter.Fill(table);

//TODO -  VERBESSERN!!!!! Keine Tabelle Count sonder User abfrage
            if (table.Rows.Count <= 0)
            {
                return false;
            }
            else
            {
                return true;  // Bleibt auf true! Muss aber wieder zu false werden sonst dauerlogin möglich ohne Datenbankabfrage
            }

        }

        // Zuordnung Benutzer mit Team(s)
        public String[] userTeam(String user)
        {
            connect();
            table = new DataTable();
            String query = "select Verein from teams t INNER JOIN benutzerteam bt on t.ID = bt.VereinID and BenutzerID ='" + user +"'";

            adapter = new MySqlDataAdapter(query, connection);
            adapter.Fill(table);
            String[] sTeams = new String[table.Rows.Count];

            int i = 0;

            foreach (DataRow tRow in table.Rows)
            {
                
                sTeams[i] = tRow.ItemArray[0].ToString();
                i++;
                
            }
            return sTeams;
        }


        // Neuen User Registrieren
        public void addUser(String Username, String Password)
        {
            connect();
            String query = "insert into benutzer (login, pass) Values('" + Username + "','" + Password +"')";
            MySqlCommand sqlCmd = new MySqlCommand(query, connection);
            sqlCmd.ExecuteNonQuery();
        }

        // Abfrage ob User bereits existiert.
        public bool userExists(String Username)
        {
            connect();
            String query = "select login from benutzer where login='" + Username + "'";
            adapter = new MySqlDataAdapter(query, connection);
            adapter.Fill(table);

            if (table.Rows.Count <= 0)
            {
                return false;
            }
            else
            {
                return true;
            }

        }



    }
}