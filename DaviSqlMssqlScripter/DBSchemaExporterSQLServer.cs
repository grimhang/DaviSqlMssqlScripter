using Microsoft.SqlServer.Management.Smo.Mail;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace DaviSqlMssqlScripter
{
    public sealed class DBSchemaExporterSQLServer : DBSchemaExporterBase
    {
        private readonly SortedSet<string> mSchemaToIgnore;

        public DBSchemaExporterSQLServer() : base()
        {
            mSchemaToIgnore = new SortedSet<string>(StringComparer.OrdinalIgnoreCase)
            {
                // ReSharper disable StringLiteralTypo
                "db_accessadmin",
                "db_backupoperator",
                "db_datareader",
                "db_datawriter",
                "db_ddladmin",
                "db_denydatareader",
                "db_denydatawriter",
                "db_owner",
                "db_securityadmin",
                "dbo",
                "guest",
                "information_schema",
                "sys"
                // ReSharper restore StringLiteralTypo
            };
        }
        /*public DBSchemaExporterSQLServer(SchemaExportOptions options) : base(options)
        {
            mSchemaToIgnore = new SortedSet<string>(StringComparer.OrdinalIgnoreCase)
            {
                // ReSharper disable StringLiteralTypo
                "db_accessadmin",
                "db_backupoperator",
                "db_datareader",
                "db_datawriter",
                "db_ddladmin",
                "db_denydatareader",
                "db_denydatawriter",
                "db_owner",
                "db_securityadmin",
                "dbo",
                "guest",
                "information_schema",
                "sys"
                // ReSharper restore StringLiteralTypo
            };
            //mTableDataScripter = null;
            //mTableDataScripterInitialized = false;

            if (string.IsNullOrWhiteSpace(mOptions.ServerName))
                return;

            *//*var success = ConnectToServer();

            if (!success)
            {
                //OnWarningEvent("Unable to connect to server " + mOptions.ServerName);
            }*//*
        }*/

        public IEnumerable<string> StringCollectionToList(StringCollection items)
        {
            var scriptInfo = new List<string>();

            foreach (var item in items)
            {
                scriptInfo.Add(item);
            }

            return scriptInfo;
        }

        public IEnumerable<string> CleanSqlScript(IEnumerable<string> scriptInfo)
        {
            return CleanSqlScript(scriptInfo, false, false);
        }

        private List<string> CleanSqlScript(IEnumerable<string> scriptInfo, bool removeAllScriptDateOccurrences, bool removeDuplicateHeaderLine)
        {
            var cleanScriptInfo = new List<string>();

            try
            {
                /*if (mOptions.ScriptingOptions.IncludeTimestampInScriptFileHeader)
                {
                    return cleanScriptInfo;
                }*/

                // Look for and remove the timestamp from the first line of the Sql script
                // For example: "Script Date: 08/14/2006 20:14:31" prior to each "******/"
                //
                // If removeAllScriptDateOccurrences = True, searches for all occurrences
                // If removeAllScriptDateOccurrences = False, does not look past the first carriage return of each entry in scriptInfo
                foreach (var item in scriptInfo)
                {
                    var currentLine = item;

                    var indexStart = 0;
                    int finalSearchIndex;

                    if (removeAllScriptDateOccurrences)
                    {
                        finalSearchIndex = currentLine.Length - 1;
                    } else
                    {
                        // Find the first CrLf after the first non-blank line in currentLine
                        // However, if the script starts with several SET statements, we need to skip those lines
                        var objectCommentStartIndex = currentLine.IndexOf(COMMENT_START_TEXT + "Object:", StringComparison.Ordinal);

                        if (currentLine.Trim().StartsWith("SET") && objectCommentStartIndex > 0)
                        {
                            indexStart = objectCommentStartIndex;
                        }

                        do
                        {
                            finalSearchIndex = currentLine.IndexOf("\r\n", indexStart, StringComparison.Ordinal);

                            if (finalSearchIndex == indexStart)
                            {
                                indexStart += 2;
                            }
                        }
                        while (finalSearchIndex >= 0 && finalSearchIndex < indexStart && indexStart < currentLine.Length);

                        if (finalSearchIndex < 0)
                        {
                            finalSearchIndex = currentLine.Length - 1;
                        }
                    }

                    while (true)
                    {
                        var indexStartCurrent = currentLine.IndexOf(COMMENT_SCRIPT_DATE_TEXT, indexStart, StringComparison.Ordinal);

                        if (indexStartCurrent > 0 && indexStartCurrent <= finalSearchIndex)
                        {
                            var indexEndCurrent = currentLine.IndexOf(COMMENT_END_TEXT_SHORT, indexStartCurrent, StringComparison.Ordinal);

                            if (indexEndCurrent > indexStartCurrent && indexEndCurrent <= finalSearchIndex)
                            {
                                currentLine =
                                    currentLine.Substring(0, indexStartCurrent).TrimEnd() + COMMENT_END_TEXT +
                                    currentLine.Substring(indexEndCurrent + COMMENT_END_TEXT_SHORT.Length);
                            }
                        }

                        if (!(removeAllScriptDateOccurrences && indexStartCurrent > 0))
                            break;
                    }

                    if (removeDuplicateHeaderLine)
                    {
                        var firstCrLf = currentLine.IndexOf("\r\n", 0, StringComparison.Ordinal);

                        if (firstCrLf > 0 && firstCrLf < currentLine.Length)
                        {
                            var nextCrLf = currentLine.IndexOf("\r\n", firstCrLf + 1, StringComparison.Ordinal);

                            if (nextCrLf > firstCrLf &&
                                currentLine.Substring(0, firstCrLf) ==
                                currentLine.Substring(firstCrLf + 2, nextCrLf - (firstCrLf - 2)))
                            {
                                currentLine = currentLine.Substring(firstCrLf + 2);
                            }
                        }
                    }

                    cleanScriptInfo.Add(currentLine);
                }

                return cleanScriptInfo;
            }
            catch (Exception ex)
            {
                //OnWarningEvent("Error in CleanSqlScript: " + ex.Message);
                return cleanScriptInfo;
            }
        }

        
    }
}
