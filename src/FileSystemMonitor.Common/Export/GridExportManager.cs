using System;
using System.IO;
using System.Windows.Forms;
using FileSystemMonitor.Common.Logging;
using System.Diagnostics;

namespace FileSystemMonitor.Common.Export
{
    public static class GridExportManager
    {
        public static string ExportToMSOffice(DataGridView grid, bool openInWordAfterExport, bool openInExcelAfterExport)
        {
            try
            {
                EventLogger.RecordEvent(Constants.CommonLibraryEventSource, LogEventType.Information, "Beginning grid HTML export...");

                string htmlFileName = Path.GetTempFileName() + ".html";

                HtmlWriter htmlWriter = new HtmlWriter(htmlFileName);
                htmlWriter.Open();
                htmlWriter.UseIndentation = true;
                htmlWriter.WriteStartElement("html");
                htmlWriter.WriteStartElement("head");
                htmlWriter.WriteEndElement(); // </head>

                htmlWriter.WriteStartElement("body");
                htmlWriter.WriteStartElement("table", "style", "font-family: Tahoma; font-size: 9pt;");

                htmlWriter.WriteStartElement("tr");
                for (int i = 0; i < grid.Columns.Count; i++)
                {
                    if (grid.Columns[i].Visible)
                    {
                        AddCell(htmlWriter, "", "<b>" + grid.Columns[i].HeaderText + "</b>", grid.Columns[i].Name == "colEventFileName" ? 1000 : 0);
                    }
                }
                htmlWriter.WriteEndElement(); // </tr>

                for (int i = 0; i < grid.Rows.Count; i++)
                {
                    if (grid.Rows[i].Visible)
                    {
                        htmlWriter.WriteStartElement("tr");
                        for (int j = 0; j < grid.Columns.Count; j++)
                        {
                            if (grid.Columns[j].Visible)
                            {
                                object cellValue = grid[j, i].Value;
                                AddCell(htmlWriter, "", cellValue, 0);
                            }
                        }
                        htmlWriter.WriteEndElement(); // </tr>
                    }
                }
                htmlWriter.WriteEndElement(); // </table>
                htmlWriter.WriteEndElement(); // </body>
                htmlWriter.WriteEndElement(); // </html>
                htmlWriter.Close();
                htmlWriter.Dispose();

                if (openInWordAfterExport)
                {
                    Process.Start("winword", '"' + htmlFileName + '"');
                }
                if (openInExcelAfterExport)
                {
                    Process.Start("excel", '"' + htmlFileName + '"');
                }

                EventLogger.RecordEvent(Constants.CommonLibraryEventSource, LogEventType.Information, "Grid HTML generation successful. Saved as: " + htmlFileName);
                return htmlFileName;
            }
            catch (Exception ex)
            {
                EventLogger.RecordException(Constants.CommonLibraryEventSource, ex, "HTML generation error: ");
                throw;
            }
        }

        public static string ExportToText(DataGridView grid, bool openInExcelAfterExport)
        {
            return null;
        }

        public static void AddCell(HtmlWriter htmlWriter, string className, object value, int width)
        {
            string cellValue = (value == null || value.ToString().Length == 0) ? HtmlWriter.HtmlWhitespace : value.ToString();
            if (width > 0)
            {
                htmlWriter.WriteStartElement("td", "class", className, "width", width, "height", 25);
            }
            else
            {
                htmlWriter.WriteStartElement("td", "class", className, "height", 25);
            }
            htmlWriter.WriteText(cellValue);
            htmlWriter.WriteEndElement();
        }
    }
}