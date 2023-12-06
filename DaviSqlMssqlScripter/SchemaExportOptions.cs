using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using PRISM;

namespace DaviSqlMssqlScripter
{
    public class SchemaExportOptions
    {
        /// <summary>
        /// Options defining what to script
        /// </summary>
        public DatabaseScriptingOptions ScriptingOptions { get; }

        /// <summary>
        /// Server name
        /// </summary>
        [Option("Server", Required = true, HelpShowsDefault = false,
            HelpText = "Database server name; assumed to be Microsoft SQL Server unless /PgUser is provided (or PgUser is defined in the .conf file)")]
        public string ServerName { get; set; }
    }
}
