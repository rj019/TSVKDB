using System;
using Android.App;
using Android.Widget;
using Android.OS;
using MySql.Data.MySqlClient;
using System.Data;
using Android.Content;

namespace TSVKDB
{
    [Activity(Label = "Team Datenbank", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {

        private Button btnlogin;
        private TextView txtSysLog;
        private EditText txtLogin;
        private EditText txtPassword;
        private Button btnRegistration;
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
           btnRegistration = FindViewById<Button>(Resource.Id.btnRegistration);


           

        // Methode für Button Klick
        btnlogin.Click += Btnlogin_Click;
        btnRegistration.Click += BtnRegistration_Click;

        }

        private void BtnRegistration_Click(object sender, EventArgs e)
        {
            // layout Registration ausführen mit dazugehörigem Code
            var activity1 = new Intent(this, typeof(registrationActivity));
            StartActivity(activity1);

        }


        private void Btnlogin_Click(object sender, EventArgs e)
        {

            if (dbconnect.connect())
            {
                if (dbconnect.logInUser(txtLogin.Text, txtPassword.Text))
                {
                    // layout TeamsActivity ausführen mit dazugehörigem Code
                    var activity2 = new Intent(this, typeof(TeamsActivity));
                    activity2.PutExtra("user", txtLogin.Text);
                    StartActivity(activity2);

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

