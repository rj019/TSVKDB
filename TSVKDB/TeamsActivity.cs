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
using System.Data;
using static Android.Views.ViewGroup;

namespace TSVKDB
{
    [Activity(Label = "TeamsActivity")]
    public class TeamsActivity : Activity
    {

        private dbconnect dbconnect = new dbconnect();
        

        protected override void OnCreate(Bundle savedInstanceState)
        {
            string user = Intent.GetStringExtra("user") ?? "Data not available";

            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Teams);

            String[] sTeams = dbconnect.userTeam(user);

            LayoutParams layoutParams = new TableRow.LayoutParams(
            ViewGroup.LayoutParams.MatchParent);

            // Zuordnung Tablelayout
            TableLayout tblLayout = FindViewById<TableLayout>(Resource.Id.tblTeam);

            int i = 0;

            foreach (String sT in sTeams)
            {
                // TableRow erzeugen

                TableRow tblRow = new TableRow(this);
                Button bButton = new Button(this);
                bButton.Text = sT;
                bButton.LayoutParameters = layoutParams;
                tblRow.LayoutParameters = layoutParams;
                tblRow.AddView(bButton, 0);
                tblLayout.AddView(tblRow, i);
                i++;
            }
        }

        public TeamsActivity()
        {

        }



    }
}