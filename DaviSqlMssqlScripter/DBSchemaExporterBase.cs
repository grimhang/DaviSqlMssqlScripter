using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DaviSqlMssqlScripter
{
    public abstract class DBSchemaExporterBase
    {
        /// <summary>
        /// Comment start
        /// </summary>
        public const string COMMENT_START_TEXT = "/****** ";

        /// <summary>
        /// Comment end
        /// </summary>
        public const string COMMENT_END_TEXT = " ******/";

        /// <summary>
        /// Compact comment end
        /// </summary>
        public const string COMMENT_END_TEXT_SHORT = "*/";

        /// <summary>
        /// Script date text
        /// </summary>
        public const string COMMENT_SCRIPT_DATE_TEXT = "Script Date: ";

        /// <summary>
        /// Export options
        /// </summary>
        protected readonly SchemaExportOptions mOptions;

        /*protected DBSchemaExporterBase(SchemaExportOptions options)
        {
            mOptions = options;
        }*/

        protected DBSchemaExporterBase()
        {
            //mOptions = options;
        }
    }
}
