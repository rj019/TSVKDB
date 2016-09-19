using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace TSVKDB
{
    [Activity(Label = "registrationActivity")]
    public class registrationActivity : Activity
    {
        private dbconnect dbconnect = new dbconnect();
        private EditText usrName;
        private EditText pswText;
        private EditText pswRepText;
        private Button btnOK;
        private Button btnCancel;
        private TextView txtSysLog;

        protected override void OnCreate(Bundle savedInstanceState)
        {

           
            base.OnCreate(savedInstanceState);

            // Zeigt das Layout an
            SetContentView(Resource.Layout.registration);


            // Zuordnung Android Layouts
            usrName = FindViewById<EditText>(Resource.Id.usrName);
            pswText = FindViewById<EditText>(Resource.Id.pswText);
            pswRepText = FindViewById<EditText>(Resource.Id.pswRepText);
            btnOK = FindViewById<Button>(Resource.Id.btnOK);
            btnCancel = FindViewById<Button>(Resource.Id.btnCancel);
            txtSysLog = FindViewById<TextView>(Resource.Id.txtSysLog);


            btnOK.Click += BtnOK_Click;


            // Create your application here
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {

                // Prüfen auf vorhandenen User
               if (!(dbconnect.userExists(usrName.Text)))
                {
                            // Prüfen auf Passwort eingabe
                            if (pswText.Text.Equals("") | pswRepText.Equals(""))
                            {
                                txtSysLog.Text = "Bitte Passwort eingeben.";
                            }
                            else if (!(pswText.Text.Equals(pswRepText.Text)))
                            {
                                txtSysLog.Text = "Die eingegebenen Passwörter stimmen nicht überein";
                            }
                            else
                            {
                                // Registrierung gestatten
                                dbconnect.addUser(usrName.Text, pswText.Text);
                                txtSysLog.Text = "Registrierung abgeschlossen";
                            }
                }
               else
                {
                    txtSysLog.Text = "Benutzername bereits vergeben";
                }

        }
       



        public registrationActivity()
        {

        }
    }
}