using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using System.Windows.Forms;
using System.Xml.Schema;

namespace DaviSqlMssqlScripter
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

            /*foreach (Database db  in dbServer.Databases)
            {
                if (db.IsSystemObject == false)
                {
                    lstDatabase.Items.Add(db.Name);                    
                }
            }*/

            UpdateDatabaseList(dbServer);
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

            if (lstDatabase.SelectedItems.Count == 0)
            {
                MessageBox.Show("Select Database");
                return;
            }

            txtResult.Text = "";

            ExportDbScript();
            ExportDbSchemaScript();
            ExportDbFullTextScript();
            ExportDbXmlSchemaScript();
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

        private void UpdateDatabaseList(Server dbServer)
        {
            try
            {
                //mWorking = true;
                //EnableDisableControls();

                //UpdatePauseUnpauseCaption(DBSchemaExporterBase.PauseStatusConstants.Unpaused);
                //Application.DoEvents();

                //if (!VerifyOrUpdateServerConnection(true))
                //    return;

                // Cache the currently selected names so that we can re-highlight them below
                var selectedDatabaseNamesSaved = new SortedSet<string>();

                foreach (var item in lstDatabase.SelectedItems)
                {
                    selectedDatabaseNamesSaved.Add(item.ToString());
                }

                lstDatabase.Items.Clear();

                foreach (Database db in dbServer.Databases)
                {
                    if (db.IsSystemObject == false)
                    {
                        var itemIndex = lstDatabase.Items.Add(db.Name);

                        //if (selectedDatabaseNamesSaved.Contains(db.Name))
                        //{
                        //    // Highlight this table name
                        //    lstDatabase.SetSelected(itemIndex, true);
                        //}
                    }
                }

                //AppendNewMessage(string.Format("Found {0} databases on {1}", lstDatabasesToProcess.Items.Count, txtServerName.Text), MessageTypeConstants.Normal);
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Error in UpdateDatabaseList: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally
            {
                /*mWorking = false;
                EnableDisableControls();*/
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }

        private void ExportDbScript()
        {
            StringBuilder sb = new StringBuilder();

            string myDatabase = lstDatabase.SelectedItem.ToString();

            var scripter = new Scripter(dbServer);
            var scriptOptions = scripter.Options;
            //scriptOptions.IncludeHeaders = true;
            scriptOptions.IncludeDatabaseContext = true;
            scriptOptions.NoCollation = true;

            //var scripts = dbServer.Databases[myDatabase].Script(scriptOptions);
            var exporter = new DBSchemaExporterSQLServer();
            var db = dbServer.Databases[myDatabase];
            var scripts = exporter.CleanSqlScript(exporter.StringCollectionToList(db.Script(scriptOptions)));



            foreach (var script in scripts)
            {
                if (script.StartsWith("IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))"))
                {
                    sb.Append($"ALTER DATABASE [{db.Name}] SET COMPATIBILITY_LEVEL = {db.CompatibilityLevel.ToString().Replace("Version", "")}\r\nGO\r\n");
                }

                if (script.StartsWith($"ALTER DATABASE [{db.Name}] SET QUERY_STORE"))
                {
                    sb.Append($"EXEC sys.sp_db_vardecimal_storage_format N'{db.Name}', N'ON'\r\nGO\r\n");
                }

                if (script.StartsWith($"ALTER DATABASE [{db.Name}] SET  READ_WRITE"))
                {
                    sb.Append($"USE [master]\r\nGO\r\n");
                }

                sb.Append(script + Environment.NewLine);
                sb.Append("GO" + Environment.NewLine);
            }

            txtResult.Text += sb.ToString();
        }

        private void ExportDbSchemaScript()
        {
            StringBuilder sb = new StringBuilder();

            string myDatabase = lstDatabase.SelectedItem.ToString();

            var scripter = new Scripter(dbServer);
            var scriptOptions = scripter.Options;
            //scriptOptions.IncludeHeaders = true;
            //scriptOptions.IncludeDatabaseContext = true;
            scriptOptions.NoCollation = true;

            //var scripts = dbServer.Databases[myDatabase].Script(scriptOptions);
            var exporter = new DBSchemaExporterSQLServer();
            var db = dbServer.Databases[myDatabase];

            StringCollection schemaNames = new StringCollection();

            foreach (Schema one in db.Schemas)
            {
                if (one.Name != "db_accessadmin" && one.Name != "db_backupoperator" && one.Name != "db_datareader" && one.Name != "db_datawriter"
                    && one.Name != "db_ddladmin" && one.Name != "db_denydatareader" && one.Name != "db_denydatawriter" && one.Name != "db_owner"
                    && one.Name != "db_securityadmin" && one.Name != "dbo" && one.Name != "guest" && one.Name != "INFORMATION_SCHEMA" && one.Name != "sys")
                {
                    schemaNames.Add(one.Name);
                }
            }

            if (schemaNames.Count > 0)
            {
                sb.Append($"USE [{db.Name}]\r\nGO\r\n");
            }            

            foreach (var schemaName in schemaNames)
            {
                var scriptInfo = exporter.CleanSqlScript(exporter.StringCollectionToList(db.Schemas[schemaName].Script(scriptOptions)));

                foreach (var script in scriptInfo)
                {
                    sb.Append(script + Environment.NewLine);
                    sb.Append("GO" + Environment.NewLine);
                }

                
            }

            txtResult.Text += sb.ToString();

        }

        private void ExportDbFullTextScript()
        {
            StringBuilder sb = new StringBuilder();

            string myDatabase = lstDatabase.SelectedItem.ToString();

            var scripter = new Scripter(dbServer);
            var scriptOptions = scripter.Options;
            //scriptOptions.IncludeHeaders = true;
            //scriptOptions.IncludeDatabaseContext = true;
            scriptOptions.NoCollation = true;

            var exporter = new DBSchemaExporterSQLServer();
            var db = dbServer.Databases[myDatabase];            

            foreach (FullTextCatalog oneCatalog in db.FullTextCatalogs)
            {
                var scriptInfo = exporter.CleanSqlScript(exporter.StringCollectionToList(oneCatalog.Script(scriptOptions)));

                foreach (var script in scriptInfo)
                {
                    sb.Append(script);  // 줄바꿈이 끝에 포함되어 있음
                    sb.Append("GO" + Environment.NewLine);
                }
            }

            txtResult.Text += sb.ToString();
        }

        private void ExportDbXmlSchemaScript()
        {
            StringBuilder sb = new StringBuilder();

            string myDatabase = lstDatabase.SelectedItem.ToString();

            var scripter = new Scripter(dbServer);
            var scriptOptions = scripter.Options;
            //scriptOptions.IncludeHeaders = true;
            //scriptOptions.IncludeDatabaseContext = true;
            scriptOptions.NoCollation = true;

            var exporter = new DBSchemaExporterSQLServer();
            var db = dbServer.Databases[myDatabase];

            foreach (Microsoft.SqlServer.Management.Smo.XmlSchemaCollection oneXmlSchema in db.XmlSchemaCollections)
            {
                var scriptInfo = exporter.CleanSqlScript(exporter.StringCollectionToList(oneXmlSchema.Script(scriptOptions)));

                foreach (var script in scriptInfo)
                {
                    sb.Append(script + Environment.NewLine);
                    sb.Append("GO" + Environment.NewLine);
                }
            }

            txtResult.Text += sb.ToString();
        }
        /*private void ResetToDefaults(bool confirm)
        {
            try
            {
                if (confirm)
                {
                    var response = MessageBox.Show(
                        "Are you sure you want to reset all settings to their default values?",
                        "Reset to Defaults",
                        MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                    if (response != DialogResult.Yes)
                    {
                        return;
                    }
                }

                Width = 1000;   // 초기 화면 width
                Height = 600;

                if (string.IsNullOrEmpty(txtServerName.Text))   // 2023-09-11  텍스트박스가 비어있을때만 디폰트이름으로 한다
                    txtServerName.Text = DBSchemaExporterSQLServer.SQL_SERVER_NAME_DEFAULT;

                chkUseIntegratedAuthentication.Checked = true;
                chkPostgreSQL.Checked = false;

                chkUsePgDump.Checked = false;
                chkUsePgInsert.Checked = false;

                txtUsername.Text = DBSchemaExporterSQLServer.SQL_SERVER_USERNAME_DEFAULT;
                txtPassword.Text = DBSchemaExporterSQLServer.SQL_SERVER_PASSWORD_DEFAULT;

                chkSkipSchemaExport.Checked = false;

                mnuEditScriptObjectsThreaded.Checked = false;
                mnuEditIncludeSystemObjects.Checked = false;
                mnuEditPauseAfterEachDatabase.Checked = false;
                mnuEditIncludeTimestampInScriptFileHeader.Checked = false;

                mnuEditIncludeTableRowCounts.Checked = true;
                mnuEditAutoSelectDefaultTableNames.Checked = true;
                mnuEditSaveDataAsInsertIntoStatements.Checked = true;
                mnuEditWarnOnHighTableRowCount.Checked = true;

                chkCreateDirectoryForEachDB.Checked = true;
                txtOutputDirectoryNamePrefix.Text = SchemaExportOptions.DEFAULT_DB_OUTPUT_DIRECTORY_NAME_PREFIX;

                chkExportServerSettingsLoginsAndJobs.Checked = false;
                txtServerOutputDirectoryNamePrefix.Text = SchemaExportOptions.DEFAULT_SERVER_OUTPUT_DIRECTORY_NAME_PREFIX;

                mTableNamesToAutoSelect.Clear();
                foreach (var item in DBSchemaExportTool.GetTableNamesToAutoExportData(chkPostgreSQL.Checked))
                {
                    mTableNamesToAutoSelect.Add(item);
                }

                mTableNameAutoSelectRegEx.Clear();
                foreach (var item in DBSchemaExportTool.GetTableRegExToAutoExportData())
                {
                    mTableNameAutoSelectRegEx.Add(item);
                }

                mDefaultDMSDatabaseList.Clear();
                mDefaultMTSDatabaseList.Clear();

                // PostgreSQL database names
                mDefaultDMSDatabaseList.Add("dms");
                mDefaultDMSDatabaseList.Add("dmsdev");

                // SQL Server database names
                mDefaultDMSDatabaseList.Add("DMS5");
                mDefaultDMSDatabaseList.Add("DMS_Capture");
                mDefaultDMSDatabaseList.Add("DMS_Data_Package");
                mDefaultDMSDatabaseList.Add("DMS_Pipeline");
                mDefaultDMSDatabaseList.Add("Ontology_Lookup");
                mDefaultDMSDatabaseList.Add("Protein_Sequences");
                mDefaultDMSDatabaseList.Add("DMSHistoricLog1");

                mDefaultMTSDatabaseList.Add("mts");
                mDefaultMTSDatabaseList.Add("MT_Template_01");
                mDefaultMTSDatabaseList.Add("PT_Template_01");
                mDefaultMTSDatabaseList.Add("MT_Main");
                mDefaultMTSDatabaseList.Add("MTS_Master");
                mDefaultMTSDatabaseList.Add("Prism_IFC");
                mDefaultMTSDatabaseList.Add("Prism_RPT");
                mDefaultMTSDatabaseList.Add("PAST_BB");
                mDefaultMTSDatabaseList.Add("Master_Sequences");
                mDefaultMTSDatabaseList.Add("MT_Historic_Log");
                mDefaultMTSDatabaseList.Add("MT_HistoricLog");

                EnableDisableControls();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in ResetToDefaults: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }*/
    }
}
