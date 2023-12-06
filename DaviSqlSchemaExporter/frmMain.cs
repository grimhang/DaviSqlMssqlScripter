using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Sdk.Sfc;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Smo.Wmi;
using Microsoft.SqlServer.Management.SqlScriptPublish;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DaviSqlSchemaExporter
{
    public partial class frmMain : Form
    {
        private string strServerAddr;
        private string strDatabaseName;
        private Server dbServer;
        private Scripter scripter;
        public frmMain()
        {
            InitializeComponent();

            strServerAddr = "localhost";            //The SQL Server instance
            txtServerAddr.Text = strServerAddr;

            chkUseIntegrated.Checked = true;
            txtLoginId.Enabled = false;
            txtPassword.Enabled = false;

            //txtServerAddr.Focus();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            lstDatabase.Items.Clear();

            //strDatabaseName = "Tangy";
            var serverConn = new ServerConnection();

            if (chkUseIntegrated.Checked)
            {
                serverConn.ConnectionString = $"Server={txtServerAddr.Text},{txtPort.Text};Database=master;Trusted_Connection=True;Encrypt=no";
            } else
            {
                serverConn.ConnectionString = $"Server={txtServerAddr.Text},{txtPort.Text};Database=master;User Id={txtLoginId.Text};Password={txtPassword.Text};Encrypt=no";
            }            

            dbServer = new Server(serverConn);
            
            foreach (Database db  in dbServer.Databases)
            {
                if (db.IsSystemObject == false)
                {
                    lstDatabase.Items.Add(db.Name);                    
                }
            }
        }


        private void btnConnect_Start(object sender, EventArgs e)
        {
            /*
            // List 2
            var mngComputer = new ManagedComputer();

            foreach (Service service in mngComputer.Services)
            {
                txtResult.Text += (service.Name + " | " + service.ServiceState + Environment.NewLine);
            }
            */

            /*
            // List 4
            var dbServer = new Server(txtComputerName.Text);

            txtResult.Text += dbServer.Name + Environment.NewLine + Environment.NewLine;

            foreach (Database db in dbServer.Databases)
            {
                txtResult.Text += (db.Name + Environment.NewLine);
            }
            */

            /*
            // List 5
            var dbServer = new Server(txtComputerName.Text);

            txtResult.Text += dbServer.Configuration.MaxServerMemory.RunValue.ToString() + "|" + dbServer.Information.Version +Environment.NewLine;
            */

            /*// List 7
            var serverConn = new ServerConnection();
            serverConn.ConnectionString = $"data source = {myComputerName}; initial catalog = master; trusted_connection = true;Encrypt=no";
            var dbServer = new Server(serverConn);

            txtResult.Text = dbServer.Databases[0].Name;
            */


            /*// List 9
            string myDatabase = "Tangy";
            //$MyScriptPath = "$($env:HOMEDRIVE)$($env:HOMEPATH)\Documents\$($MyDatabase).sql"

            var dbServer = new Server(txtComputerName.Text);
            var db = dbServer.Databases[myDatabase];// new Database(dbServer,myDatabase);
            var transfer = new Transfer(db);

            foreach (var script in transfer.ScriptTransfer())
            {
                txtResult.Text += (script + Environment.NewLine);
            }*/

            /*
            string myDatabase = "Tangy";
            var dbServer = new Server(txtServerAddr.Text);
            var scripter = new Scripter(dbServer);
            scripter.Options.ScriptDrops = false;
            scripter.Options.WithDependencies = true;
            //scripter.Options.IncludeIfNotExists = true;
            scripter.Options.Indexes = true;   // To include indexes  
            scripter.Options.NoCollation = true;

            //System.Collections.Specialized.StringCollection stringCollection = scripter.Script(dbServer.Databases[myDatabase].Tables.urn);

            StringBuilder sb = new StringBuilder();

            // Iterate through the tables in database and script each one. Display the script.     
            foreach (Table tb in dbServer.Databases[myDatabase].Tables)
            {
                // check if the table is not a system table  
                if (tb.IsSystemObject == false)
                {
                    sb.Append($"-- Scripting for table {tb.Name} {Environment.NewLine}");

                    // Generating script for table tb  
                    System.Collections.Specialized.StringCollection sc = scripter.Script(new Urn[] { tb.Urn });
                    foreach (string st in sc)
                    {
                        //Console.WriteLine(st);
                        sb.Append(st + Environment.NewLine);
                    }
                    sb.Append("GO" + Environment.NewLine + Environment.NewLine);
                }
            }

            txtResult.Text = sb.ToString();
            */

            string myDatabase = lstDatabase.SelectedItem.ToString();                       

            var scripter = new Scripter(dbServer);
            var scriptOptions = scripter.Options;
            scriptOptions.IncludeHeaders = true;


            //var scripts = dbServer.Databases[myDatabase].Script(scriptOptions);
            var exporter = new DBSchemaExporterSQLServer();
            var scripts = exporter.CleanSqlScript(exporter.StringCollectionToList(dbServer.Databases[myDatabase].Script(scriptOptions)));

            foreach (var script in scripts)
            {
                txtResult.Text += (script + Environment.NewLine);
            }
            

        }

        private void chkUseIntegrated_CheckedChanged(object sender, EventArgs e)
        {
            if (chkUseIntegrated.Checked)
            {
                txtLoginId.Enabled = false;
                txtPassword.Enabled = false;
            } else
            {
                txtLoginId.Enabled = true;
                txtPassword.Enabled = true;
            }
        }
    }
}
