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
                connection = new MySqlConnection("++++;Port=3306;database=teamdb;User ID=++++++;Password=+++++;Charset=utf8");

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
           String query = "select login, pass from benutzer where login = '" + name + "' and pass =  '" + password + "'";
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

        // Suche nach zugehörigen Teams
        public bool userTeam(String ID)
        {
            String query = "select * from teams where ID='"+ ID +"'";
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