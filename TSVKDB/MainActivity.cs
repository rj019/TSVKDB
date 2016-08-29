using System;
using Android.App;
using Android.Widget;
using Android.OS;
using MySql.Data.MySqlClient;
using System.Data;

namespace TSVKDB
{
    [Activity(Label = "Team Datenbank", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {

        private Button btnlogin;
        private TextView txtSysLog;
        private static EditText txtLogin;
        private static EditText txtPassword;
        private dbconnect dbconnect = new dbconnect();

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Aktivieren Main Layout
            SetContentView(Resource.Layout.Main);
            
            // Buttons verknüpfen     
            btnlogin = FindViewById<Button>(Resource.Id.btnLogin);
            txtSysLog = FindViewById<TextView>(Resource.Id.txtSysLog);
            txtLogin = FindViewById<EditText>(Resource.Id.txtLogin);
            txtPassword= FindViewById<EditText>(Resource.Id.txtPasswort);
            

        // Methode für Button Klick
        btnlogin.Click += Btnlogin_Click;
        }

        private void Btnlogin_Click(object sender, EventArgs e)
        {
            if (dbconnect.connect())
            {
               if (dbconnect.logInUser(txtLogin.Text, txtPassword.Text))
                {
                    SetContentView(Resource.Layout.Teams);
                }
                else
                {
                    txtSysLog.Text = "Name oder Passwort falsch!";
                }
            }else
            {
                txtSysLog.Text = "Name oder Passwort falsch!";
            }

            
            

            
        }
    }
}

