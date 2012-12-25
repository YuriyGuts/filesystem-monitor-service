using System;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FileSystemMonitor.UI.AdminApplication.Properties;
using FileSystemMonitor.Common;
using FileSystemMonitor.Common.Logging;
using System.Xml;
using FileSystemMonitor.Core;
using FileSystemMonitor.Data.Interfaces;
using System.Diagnostics;
using System.Threading;
using FileSystemMonitor.Common.Export;

namespace FileSystemMonitor.UI.AdminApplication
{
    public partial class FormMain : Form
    {
        #region Open/Save constants

        const string rootElementName = "FolderTraceProfile";
        const string traceElementName = "FolderTrace";
        const string traceNameAttributeName = "Name";
        const string traceGuidAttributeName = "GUID";
        const string folderElementName = "Folder";
        const string folderPathAttributeName = "Path";
        const string folderIncludeSubfoldersAttributeName = "IncludeSubfolders";
        const string trueValue = "True";
        const string falseValue = "False";

        #endregion

        public FormMain()
        {
            InitializeComponent();
            profileChanged = false;
            CurrentFileName = null;
            if (!DataProvider.IsInitialized)
            {
                DataProvider.Initialize(Settings.Default.DBConnectionString);
            }
        }

        private FolderTrace activeFolderTrace;

        public FolderTrace ActiveFolderTrace
        {
            get
            {
                return activeFolderTrace;
            }
            set
            {
                activeFolderTrace = value;
                RefreshFolderList();
                LoadEventsFromDatabase();
            }
        }


        public bool CanEditFolders
        {
            get
            {
                return (ActiveFolderTrace != null) ? (ActiveFolderTrace.State != FolderTraceState.Running) : false;
            }
        }

        private bool profileChanged;
        private string currentFileName;

        public string CurrentFileName
        {
            get { return currentFileName; }
            set
            {
                currentFileName = value;
                Text = string.Format("[{0}] - FileSystemMonitor Admin", currentFileName ?? "Untitled");
            }
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            try
            {
                menuToolsStartServer.Enabled = true;
                menuToolsStopServer.Enabled = false;
                gridTraces.Rows.Clear();
                FolderTraceProfile activeProfile = DataProvider.Server.ActiveProfile;
                if (activeProfile != null)
                {
                    foreach (FolderTrace trace in activeProfile.Traces)
                    {
                        int newRowIndex = gridTraces.Rows.Add(trace.Name, trace.State.ToString(), trace.Items.Count, 0);
                        gridTraces[colTraceState.Index, newRowIndex].Style.ForeColor = trace.State == FolderTraceState.Running ? Color.Green : Color.Red;
                        gridTraces.Rows[newRowIndex].Tag = trace;
                    }
                    if (gridTraces.Rows.Count > 0)
                    {
                        ActiveFolderTrace = (FolderTrace)gridTraces.Rows[0].Tag;
                    }
                }
                menuToolsStartServer.Enabled = false;
                menuToolsStopServer.Enabled = true;
            }
            catch (Exception ex)
            {
                EventLogger.RecordException(Constants.AdminApplicationEventSource, ex, "Failed to connect to server: ");
                FormHelper.ShowErrorMessage("Cannot establish connection to server! Please check that the service is started.", "Error");
            }
        }

        private void cmsTraceGridAdd_Click(object sender, EventArgs e)
        {
            AddNewTrace();
        }

        private void cmsExistingTraceAdd_Click(object sender, EventArgs e)
        {
            AddNewTrace();
        }

        private void cmsFolderGridAdd_Click(object sender, EventArgs e)
        {
            AddNewFolder();
        }

        private void cmsExistingFolderAdd_Click(object sender, EventArgs e)
        {
            AddNewFolder();
        }

        private void AddNewTrace()
        {
            try
            {
                int newRowIndex = gridTraces.Rows.Add("New trace", "Stopped", 0, 0);
                gridTraces.CurrentCell = gridTraces.Rows[newRowIndex].Cells[colTraceName.Index];
                gridTraces.BeginEdit(true);
                gridTraces.Rows[newRowIndex].Tag = new FolderTrace("New trace", FolderTraceState.Stopped);
                profileChanged = true;
            }
            catch (Exception ex)
            {
                EventLogger.RecordException(Constants.AdminApplicationEventSource, ex, "AddNewTrace: ");
            }
        }

        private void AddNewFolder()
        {
            try
            {
                dlgFolderPicker = new FolderBrowserDialog();
                DialogResult folderPickResult = dlgFolderPicker.ShowDialog();
                if (folderPickResult == DialogResult.OK)
                {
                    string selectedPath = dlgFolderPicker.SelectedPath;
                    int newRowIndex = gridTraceFolders.Rows.Add(Resources.FolderBitmap, selectedPath, false);
                    FolderTraceEntry newTraceEntry = new FolderTraceEntry(selectedPath, ActiveFolderTrace, false);
                    gridTraceFolders.Rows[newRowIndex].Tag = newTraceEntry;
                    ActiveFolderTrace.Items.Add(newTraceEntry);
                    profileChanged = true;
                }
            }
            catch (Exception ex)
            {
                EventLogger.RecordException(Constants.AdminApplicationEventSource, ex, "AddNewFolder: ");
            }
        }

        private void cmsExistingFolderRemove_Click(object sender, EventArgs e)
        {
            int selectedRowIndex = gridTraceFolders.SelectedRows[0].Index;
            if (selectedRowIndex >= 0)
            {
                RemoveExistingFolderAt(selectedRowIndex);
            }
        }

        private void RemoveExistingFolderAt(int selectedRowIndex)
        {
            FolderTraceEntry traceEntry = (FolderTraceEntry)gridTraceFolders.Rows[selectedRowIndex].Tag;
            if (traceEntry != null)
            {
                ActiveFolderTrace.Items.Remove(traceEntry);
            }
            gridTraceFolders.Rows.RemoveAt(selectedRowIndex);
            profileChanged = true;
        }

        private void cmsExistingTraceDelete_Click(object sender, EventArgs e)
        {
            int selectedRowIndex = gridTraces.SelectedRows[0].Index;
            if (selectedRowIndex >= 0)
            {
                RemoveExistingTraceAt(selectedRowIndex);
            }
        }

        private void RemoveExistingTraceAt(int selectedRowIndex)
        {
            gridTraces.Rows.RemoveAt(selectedRowIndex);
            profileChanged = true;
        }

        private void gridTraces_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                gridTraces.Rows[e.RowIndex].Selected = true;
            }
        }

        private void gridTraceFolders_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                gridTraceFolders.Rows[e.RowIndex].Selected = true;
                if (e.ColumnIndex == colFolderIncludeSubfolders.Index)
                {
                    bool cellValue = (bool)gridTraceFolders[e.ColumnIndex, e.RowIndex].Value;
                    gridTraceFolders[e.ColumnIndex, e.RowIndex].Value = !cellValue;
                    ((FolderTraceEntry)gridTraceFolders.Rows[e.RowIndex].Tag).IncludeSubfolders = !cellValue;
                    profileChanged = true;
                }
            }
        }

        private void gridTraces_SelectionChanged(object sender, EventArgs e)
        {
            if (gridTraces.SelectedRows.Count > 0)
            {
                ActiveFolderTrace = (FolderTrace)gridTraces.SelectedRows[0].Tag;
            }
            else
            {
                if (gridTraces.Rows.Count > 0)
                {
                    gridTraces.CurrentCell = gridTraces.Rows[0].Cells[colTraceName.Index];
                }
            }
        }

        private void gridTraces_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == colTraceName.Index && e.RowIndex >= 0)
            {
                FolderTrace trace = (FolderTrace)gridTraces.Rows[e.RowIndex].Tag;
                trace.Name = gridTraces[e.ColumnIndex, e.RowIndex].Value.ToString();
                ActiveFolderTrace = (FolderTrace)gridTraces.Rows[e.RowIndex].Tag;
                profileChanged = true;
            }
        }

        private void RefreshFolderList()
        {
            gridTraceFolders.Rows.Clear();
            if (ActiveFolderTrace != null)
            {
                foreach (FolderTraceEntry entry in ActiveFolderTrace.Items)
                {
                    int newRowIndex = gridTraceFolders.Rows.Add(Resources.FolderBitmap, entry.FolderName, entry.IncludeSubfolders);
                    gridTraceFolders.Rows[newRowIndex].Tag = entry;
                }
                gridTraceFolders.Enabled = CanEditFolders;
            }
        }

        private void LoadEventsFromDatabase()
        {
            const string eventSelectQueryText =
                @"select * from FileSystemEvent where FolderTraceGUID = @FolderTraceGUID order by FileSystemEventDate desc";

            gridEvents.Rows.Clear();
            if (ActiveFolderTrace != null)
            {
                QueryParameterSet queryParameters = new QueryParameterSet();
                queryParameters.Add("@FolderTraceGUID", ActiveFolderTrace.GUID.ToString());
                IQueryResult queryResult = DataProvider.Database.Query(eventSelectQueryText, queryParameters, true);

                int rowCount = queryResult.Rows.Count;
                for (int i = 0; i < gridTraces.Rows.Count; i++)
                {
                    if (gridTraces.Rows[i].Tag == ActiveFolderTrace)
                    {
                        gridTraces[colTraceEventCount.Index, i].Value = rowCount;
                    }
                }

                for (int i = 0; i < rowCount; i++)
                {
                    int eventType = Convert.ToInt32(queryResult[i]["FileSystemEventType"]);
                    DateTime eventDate = Convert.ToDateTime(queryResult[i]["FileSystemEventDate"]);
                    string oldName = Convert.ToString(queryResult[i]["FileSystemEventOldName"]);
                    string newName = Convert.ToString(queryResult[i]["FileSystemEventNewName"]);

                    FileSystemEvent fsEvent = new FileSystemEvent((FileSystemEventType)eventType, oldName, newName, eventDate);
                    AddEventGridEntry(fsEvent);
                }
            }
        }

        private void gridTraces_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            ActiveFolderTrace = (FolderTrace)gridTraces.SelectedRows[0].Tag;
        }

        private void ApplyProfileToServer()
        {
            FolderTraceProfile profile = new FolderTraceProfile();
            for (int i = 0; i < gridTraces.Rows.Count; i++)
            {
                FolderTrace trace = (FolderTrace)gridTraces.Rows[i].Tag;
                if (trace != null && trace.State == FolderTraceState.Running)
                {
                    profile.Traces.Add(trace);
                }
            }
            try
            {
                DataProvider.Server.ActiveProfile = profile;
            }
            catch (Exception ex)
            {
                EventLogger.RecordException(Constants.AdminApplicationEventSource, ex, "Failed to connect to server: ");
                FormHelper.ShowErrorMessage("Cannot establish connection to server! Please check that the service is started.", "Error");
            }
        }

        private void cmsExistingTraceStart_Click(object sender, EventArgs e)
        {
            int selectedRowIndex = gridTraces.SelectedRows[0].Index;
            if (selectedRowIndex >= 0)
            {
                ChangeTraceState(selectedRowIndex, FolderTraceState.Running);
            }
        }

        private void ChangeTraceState(int selectedRowIndex, FolderTraceState newState)
        {
            FolderTrace trace = (FolderTrace)gridTraces.Rows[selectedRowIndex].Tag;
            if (trace != null)
            {
                trace.State = newState;
                ApplyProfileToServer();
            }
            switch (newState)
            {
                case FolderTraceState.Running:
                    gridTraces[colTraceState.Index, selectedRowIndex].Value = "Running";
                    gridTraces[colTraceState.Index, selectedRowIndex].Style.ForeColor = Color.Green;
                    break;
                case FolderTraceState.Stopped:
                    gridTraces[colTraceState.Index, selectedRowIndex].Value = "Stopped";
                    gridTraces[colTraceState.Index, selectedRowIndex].Style.ForeColor = Color.Red;
                    break;
            }
            RefreshFolderList();
        }

        private void cmsExistingTraceStop_Click(object sender, EventArgs e)
        {
            int selectedRowIndex = gridTraces.SelectedRows[0].Index;
            if (selectedRowIndex >= 0)
            {
                ChangeTraceState(selectedRowIndex, FolderTraceState.Stopped);
            }
        }

        private void cmsExistingFolder_Opening(object sender, CancelEventArgs e)
        {
            foreach (ToolStripMenuItem item in cmsExistingFolder.Items)
            {
                item.Enabled = CanEditFolders;
            }
        }

        private void cmsFolderGrid_Opening(object sender, CancelEventArgs e)
        {
            foreach (ToolStripMenuItem item in cmsFolderGrid.Items)
            {
                item.Enabled = CanEditFolders;
            }
        }

        private void SaveProfile(string fileName)
        {
            try
            {
                XmlTextWriter xmlWriter = new XmlTextWriter(fileName, Encoding.UTF8);
                xmlWriter.Formatting = Formatting.Indented;
                xmlWriter.WriteStartDocument();
                xmlWriter.WriteStartElement(rootElementName);
                for (int i = 0; i < gridTraces.Rows.Count; i++)
                {
                    FolderTrace trace = (FolderTrace)gridTraces.Rows[i].Tag;
                    if (trace != null)
                    {
                        xmlWriter.WriteStartElement(traceElementName);
                        xmlWriter.WriteAttributeString(traceNameAttributeName, trace.Name);
                        xmlWriter.WriteAttributeString(traceGuidAttributeName, trace.GUID.ToString());
                        foreach (FolderTraceEntry traceEntry in trace.Items)
                        {
                            xmlWriter.WriteStartElement(folderElementName);
                            xmlWriter.WriteAttributeString(folderPathAttributeName, traceEntry.FolderName);
                            xmlWriter.WriteAttributeString(folderIncludeSubfoldersAttributeName, traceEntry.IncludeSubfolders ? trueValue : falseValue);
                            xmlWriter.WriteEndElement();
                        }
                        xmlWriter.WriteEndElement();
                    }
                }
                xmlWriter.WriteEndElement();
                xmlWriter.Close();
                profileChanged = false;
            }
            catch (Exception ex)
            {
                EventLogger.RecordException(Constants.AdminApplicationEventSource, ex, "Failed to save profile: ");
                FormHelper.ShowErrorMessage("Failed to save profile: " + ex.Message);
            }
        }

        private void menuFileNewProfile_Click(object sender, EventArgs e)
        {
            ProcessNewProfileRequest();
        }

        private void tsbNewProfile_Click(object sender, EventArgs e)
        {
            ProcessNewProfileRequest();
        }

        private void ProcessNewProfileRequest()
        {
            if (CheckForUnsavedChanges())
            {
                gridTraces.Rows.Clear();
                gridTraceFolders.Rows.Clear();
                gridEvents.Rows.Clear();
                CurrentFileName = null;
                ApplyProfileToServer();
            }
        }

        private void menuFileOpenProfile_Click(object sender, EventArgs e)
        {
            ProcessOpenProfileRequest();
        }

        private void tsbOpenProfile_Click(object sender, EventArgs e)
        {
            ProcessOpenProfileRequest();
        }

        private void ProcessOpenProfileRequest()
        {
            if (CheckForUnsavedChanges())
            {
                string selectedFileName = OpenProfileDialog();
                if (selectedFileName != null)
                {
                    LoadProfile(selectedFileName);
                    CurrentFileName = selectedFileName;
                    ApplyProfileToServer();
                }
            }
        }

        private void LoadProfile(string selectedFileName)
        {
            try
            {
                gridTraces.Rows.Clear();
                gridEvents.Rows.Clear();
                gridTraceFolders.Rows.Clear();

                XmlTextReader xmlReader = new XmlTextReader(selectedFileName);
                while (xmlReader.Read())
                {
                    if (xmlReader.NodeType == XmlNodeType.Element && xmlReader.Name == traceElementName)
                    {
                        string traceName = xmlReader.GetAttribute(traceNameAttributeName);
                        string traceGuid = xmlReader.GetAttribute(traceGuidAttributeName);
                        if (traceGuid != null)
                        {
                            FolderTrace trace = new FolderTrace(traceName, FolderTraceState.Stopped, new Guid(traceGuid));
                            while (xmlReader.Read())
                            {
                                if (xmlReader.NodeType == XmlNodeType.Element && xmlReader.Name == folderElementName)
                                {
                                    string folderPath = xmlReader.GetAttribute(folderPathAttributeName);
                                    bool includeSubDirectories = !(xmlReader.GetAttribute(folderIncludeSubfoldersAttributeName) == falseValue);
                                    trace.Items.Add(new FolderTraceEntry(folderPath, trace, includeSubDirectories));
                                }
                                if (xmlReader.NodeType == XmlNodeType.EndElement && xmlReader.Name == traceElementName)
                                {
                                    break;
                                }
                            }
                            int newRowIndex = gridTraces.Rows.Add(trace.Name, "Stopped", trace.Items.Count);
                            gridTraces.Rows[newRowIndex].Tag = trace;
                        }
                    }
                }
                if (gridTraces.Rows.Count > 0)
                {
                    ActiveFolderTrace = (FolderTrace)gridTraces.Rows[0].Tag;
                }
            }
            catch (Exception ex)
            {
                EventLogger.RecordException(Constants.AdminApplicationEventSource, ex, "Failed to load profile: ");
                FormHelper.ShowErrorMessage("Failed to load profile. The file can be probably corrupt.\r\nDetails:\r\n" + ex.Message);
            }
        }


        private void menuFileSaveProfile_Click(object sender, EventArgs e)
        {
            ProcessSaveProfileRequest();
        }

        private void tsbSaveProfile_Click(object sender, EventArgs e)
        {
            ProcessSaveProfileRequest();
        }

        private void ProcessSaveProfileRequest()
        {
            string fileName = CurrentFileName;
            if (CurrentFileName == null)
            {
                fileName = SaveProfileDialog();
                if (fileName == null)
                {
                    return;
                }
            }
            SaveProfile(fileName);
            CurrentFileName = fileName;
        }

        private void menuFileSaveProfileAs_Click(object sender, EventArgs e)
        {
            ProcessSaveProfileAsRequest();
        }

        private void ProcessSaveProfileAsRequest()
        {
            string fileName = SaveProfileDialog();
            if (fileName == null)
            {
                return;
            }
            SaveProfile(fileName);
            CurrentFileName = fileName;
        }

        private void menuFileExit_Click(object sender, EventArgs e)
        {
            ProcessExitRequest();
        }

        private void ProcessExitRequest()
        {
            if (CheckForUnsavedChanges())
            {
                Close();
            }
        }

        /// <summary>
        /// Checks for unsaved changes in current profile and prompts the user to save them.
        /// </summary>
        /// <returns>False if the pending operation should be cancelled, otherwise - true.</returns>
        private bool CheckForUnsavedChanges()
        {
            if (profileChanged)
            {
                DialogResult result = MessageBox.Show
                    (
                        this,
                        "The profile has been modified. Would you like to save changes?",
                        "Save changes",
                        MessageBoxButtons.YesNoCancel,
                        MessageBoxIcon.Question
                    );
                switch (result)
                {
                    case DialogResult.Yes:
                        if (CurrentFileName == null)
                        {
                            string fileName = SaveProfileDialog();
                            if (fileName != null)
                            {
                                CurrentFileName = fileName;
                            }
                            else
                            {
                                return false;
                            }
                        }
                        SaveProfile(CurrentFileName);
                        return true;
                    case DialogResult.No:
                        return true;
                    default:
                        return false;
                }
            }
            return true;
        }


        private void menuToolsExportToText_Click(object sender, EventArgs e)
        {
            ExportEventGridToWord();
        }

        private void tsbExportToWord_Click(object sender, EventArgs e)
        {
            ExportEventGridToWord();
        }

        private void ExportEventGridToWord()
        {
            colEventIcon.Visible = false;
            GridExportManager.ExportToMSOffice(gridEvents, true, false);
            colEventIcon.Visible = true;
        }

        private void menuToolsExportToExcel_Click(object sender, EventArgs e)
        {
            ExportEventGridToExcel();
        }

        private void tsbExportToExcel_Click(object sender, EventArgs e)
        {
            ExportEventGridToExcel();
        }

        private void ExportEventGridToExcel()
        {
            colEventIcon.Visible = false;
            GridExportManager.ExportToMSOffice(gridEvents, false, true);
            colEventIcon.Visible = true;
        }

        private void menuToolsOptions_Click(object sender, EventArgs e)
        {

        }

        private void tsbOptions_Click(object sender, EventArgs e)
        {

        }

        private void menuHelpAbout_Click(object sender, EventArgs e)
        {
            MessageBox.Show
                (
                    this,
                    "File System Monitor\r\n\r\nCopyright (c) Yuriy Guts, 2008-2009.",
                    "About File System Monitor",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
        }

        private string OpenProfileDialog()
        {
            string result = null;
            DialogResult dialogResult = dlgOpenFile.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                result = dlgOpenFile.FileName;
            }
            return result;
        }

        private string SaveProfileDialog()
        {
            string result = null;
            DialogResult dialogResult = dlgSaveFile.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                result = dlgSaveFile.FileName;
            }
            return result;
        }

        private void AddEventGridEntry(FileSystemEvent fileSystemEvent)
        {
            Bitmap eventIcon;
            Color eventColor;
            string eventString;

            switch (fileSystemEvent.EventType)
            {
                case FileSystemEventType.Created:
                    eventIcon = Resources.EventCreatedBitmap;
                    eventColor = Color.Green;
                    eventString = "Created";
                    break;
                case FileSystemEventType.Deleted:
                    eventIcon = Resources.EventDeletedBitmap;
                    eventColor = Color.Red;
                    eventString = "Deleted";
                    break;
                case FileSystemEventType.Renamed:
                    eventIcon = Resources.EventRenamedBitmap;
                    eventColor = Color.Orange;
                    eventString = "Renamed";
                    break;
                default:
                    eventIcon = Resources.EventModifiedBitmap;
                    eventColor = Color.Blue;
                    eventString = "Modified";
                    break;
            }

            string fileNameColumnValue =
                (fileSystemEvent.EventType != FileSystemEventType.Renamed)
                    ? fileSystemEvent.NewFileName
                    : string.Format("{0} > {1}", fileSystemEvent.OldFileName, fileSystemEvent.NewFileName);
            int newRowIndex = gridEvents.Rows.Add(eventIcon, fileSystemEvent.EventDate.ToString("dd.MM.yyyy HH:mm:ss.ff"), eventString, fileNameColumnValue);
            gridEvents[colEventType.Index, newRowIndex].Style.ForeColor = eventColor;
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!CheckForUnsavedChanges())
            {
                e.Cancel = true;
            }
        }

        private void tsbRefreshEventGrid_Click(object sender, EventArgs e)
        {
            LoadEventsFromDatabase();
        }

        private void menuToolsRefreshLog_Click(object sender, EventArgs e)
        {
            LoadEventsFromDatabase();
        }

        private void menuToolsStartServer_Click(object sender, EventArgs e)
        {
            try
            {
                EventLogger.RecordEvent(Constants.AdminApplicationEventSource, LogEventType.Information, "Start request received. Starting the service...");
                Process.Start("net", "start fsmonsvc");
                Thread.Sleep(2500);
                Trace.WriteLine("Server connection test: " + DataProvider.Server.ServerTestProperty);
                menuToolsStartServer.Enabled = false;
                menuToolsStopServer.Enabled = true;
            }
            catch (Exception ex)
            {
                EventLogger.RecordException(Constants.AdminApplicationEventSource, ex, "Failed to start the service: ");
                FormHelper.ShowErrorMessage("Failed to start the service: " + ex.Message, "Error");
            }
        }

        private void menuToolsStopServer_Click(object sender, EventArgs e)
        {
            try
            {
                EventLogger.RecordEvent(Constants.AdminApplicationEventSource, LogEventType.Information, "Stop request received. Stopping the service...");
                Process.Start("net", "stop fsmonsvc");
                menuToolsStartServer.Enabled = true;
                menuToolsStopServer.Enabled = false;
            }
            catch (Exception ex)
            {
                EventLogger.RecordException(Constants.AdminApplicationEventSource, ex, "Failed to stop the service: ");
                FormHelper.ShowErrorMessage("Failed to stop the service: " + ex.Message, "Error");
            }
        }

        private void menuToolsDatabaseCleanup_Click(object sender, EventArgs e)
        {
            FormDatabaseCleanup frmDatabaseCleanup = new FormDatabaseCleanup();
            if (frmDatabaseCleanup.ShowDialog(this) == DialogResult.OK)
            {
                CleanupDatabase(frmDatabaseCleanup.UnitCount, frmDatabaseCleanup.TimeUnit);
                LoadEventsFromDatabase();
            }
        }

        private void CleanupDatabase(int unitCount, FormDatabaseCleanup.TimeUnitType unitType)
        {
            DateTime maxDateTime = DateTime.Now;
            switch (unitType)
            {
                case FormDatabaseCleanup.TimeUnitType.Year:
                    maxDateTime = maxDateTime.AddYears(-unitCount);
                    break;
                case FormDatabaseCleanup.TimeUnitType.Month:
                    maxDateTime = maxDateTime.AddMonths(-unitCount);
                    break;
                case FormDatabaseCleanup.TimeUnitType.Day:
                    maxDateTime = maxDateTime.AddDays(-unitCount);
                    break;
                case FormDatabaseCleanup.TimeUnitType.Hour:
                    maxDateTime = maxDateTime.AddHours(-unitCount);
                    break;
                case FormDatabaseCleanup.TimeUnitType.Minute:
                    maxDateTime = maxDateTime.AddMinutes(-unitCount);
                    break;
                case FormDatabaseCleanup.TimeUnitType.Second:
                    maxDateTime = maxDateTime.AddSeconds(-unitCount);
                    break;
                default:
                    throw new ArgumentOutOfRangeException("unitType");
            }

            const string dbCleanupQuery = "delete from FileSystemEvent where FileSystemEventDate < @maxDateTime";
            try
            {
                QueryParameterSet queryParameterSet = new QueryParameterSet();
                queryParameterSet.Add("@maxDateTime", maxDateTime.ToString("yyyy-MM-dd HH:mm:ss"));
                DataProvider.Database.Query(dbCleanupQuery, queryParameterSet, false);
            }
            catch (Exception ex)
            {
                EventLogger.RecordException(Constants.AdminApplicationEventSource, ex, "Failed to clean up database: ");
                FormHelper.ShowErrorMessage("Failed to clean up database: " + ex.Message, "Error");
            }
        }
    }
}