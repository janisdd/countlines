using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CountLines
{
    public partial class MainWindow : Form
    {
        /// <summary>
        /// the dialog to choose the root (project) dir
        /// </summary>
        private readonly OpenFileDialog _dialog = new OpenFileDialog();

        /// <summary>
        /// the cancellation token source to cancel the run
        /// </summary>
        private CancellationTokenSource _cancelToken = new CancellationTokenSource();

        /// <summary>
        /// the result for the current run
        /// </summary>
        private static CountLinesResult _currentResult;

        /// <summary>
        /// the total files to scan (for the current run)
        /// </summary>
        private static long _totalFilesToScan = 0;

        public MainWindow()
        {
            InitializeComponent();

            _dialog.Multiselect = false;
            _dialog.RestoreDirectory = true;
            _dialog.Title = @"Choose file in target directory";

            btnCancel.Enabled = false;
            //btnPause.Enabled = false;


            tbIgnoreList.AllowDrop = true;
            tbIgnoreList.DragEnter += (sender, args) =>
            {
                if (args.Data.GetDataPresent(DataFormats.FileDrop))
                {
                    args.Effect = DragDropEffects.Link;
                }
            };

            tbIgnoreList.DragDrop += (sender, args) =>
            {
                if (args.Data.GetDataPresent(DataFormats.FileDrop))
                {
                    var paths = (string[]) args.Data.GetData(DataFormats.FileDrop);

                    foreach (var path in paths)
                    {
                        var fileInfo = new FileInfo(path);

                        if (fileInfo.Exists)
                        {
                            //it's a file
                            tbIgnoreList.AppendText(Environment.NewLine + fileInfo.FullName);
                        }

                        var dirInfo = new DirectoryInfo(path);

                        if (dirInfo.Exists)
                        {
                            //it's a dir
                            tbIgnoreList.AppendText(Environment.NewLine + fileInfo.FullName);
                        }
                    }
                    FormatIgnoreList();
                }
            };

        }





        /// <summary>
        /// formats the ignore list entries 
        /// removes duplicate entries
        /// </summary>
        private void FormatIgnoreList()
        {
            string[] lines = tbIgnoreList.Lines;

            var dict = new HashSet<string>();

            foreach (var line in lines)
            {
                if (String.IsNullOrWhiteSpace(line)) continue;

                dict.Add(line.Trim());
            }

            tbIgnoreList.Lines = dict.ToArray();
        }

        private async void btnStart_Click(object sender, EventArgs e)
        {
            rbAllLines.Enabled = false;
            rbIgnoreEmptyLines.Enabled = false;
            rbIgnoreEmptyOrWhitespaceLines.Enabled = false;

            _currentResult = new CountLinesResult();
            lbInfo.Text = "";
            numIgnoreRules.Text = "";
            _totalFilesToScan = 0;
            progBar.Value = 0;
            tbFoundFiles.Clear();

            bool ignoreEmptyLines = rbIgnoreEmptyLines.Checked;
            bool ignoreEmptyorWhitespaceLines = rbIgnoreEmptyOrWhitespaceLines.Checked;

            if (String.IsNullOrWhiteSpace(tbRootDir.Text)) return;

            //get the root directory
            var rootDir = new DirectoryInfo(tbRootDir.Text.Trim());

            if (!rootDir.Exists)
            {
                MessageBox.Show(@"Root directory path is not a directory");
                ResetButtons();
                return;
            }



            //get extensions
            var extensions = tbExtensions.Text.Split(new char[] {','}, StringSplitOptions.RemoveEmptyEntries).ToList();
       
            if (extensions.Count == 0)
            {
                MessageBox.Show(@"No extensions provided");
                ResetButtons();
                return;
            }


            //get files and directories to ignore
            var ignoreList = new HashSet<string>(tbIgnoreList.Lines);

            //also add the ignore files lines

            if (string.IsNullOrEmpty(tbIgnoreFileConfig.Text) == false)
            {
                var ignoreFileInfo = new FileInfo(tbIgnoreFileConfig.Text);

                if (!ignoreFileInfo.Exists)
                {
                    MessageBox.Show(@"Ignore file not found");
                    ResetButtons();
                    return;
                }
                var additionalRules = File.ReadAllLines(ignoreFileInfo.FullName).ToList();
                additionalRules.ForEach(rule => ignoreList.Add(rule));
            }

            var filesToIgnore = new List<FileInfo>();
            var directoriesToIgnore = new List<DirectoryInfo>();

            foreach (var ignoreItem in ignoreList)
            {

                if (ignoreItem.Trim().StartsWith("#")) continue;

                var infoDir = new DirectoryInfo(ignoreItem.Trim());
                var infoFile = new FileInfo(ignoreItem.Trim());


                if (!infoDir.Exists && !infoFile.Exists)
                {
                    //maybe relative path??

                    infoDir = new DirectoryInfo(Path.Combine(rootDir.FullName, ignoreItem.Trim()));
                    infoFile = new FileInfo(Path.Combine(rootDir.FullName, ignoreItem.Trim()));

                    if (!infoDir.Exists && !infoFile.Exists)
                    {
                        MessageBox.Show(ignoreItem + " is not a directory or file");
                        ResetButtons();
                        return;
                    }
                }

                if (infoDir.Exists)
                {
                    directoriesToIgnore.Add(infoDir);
                }
                else if (infoFile.Exists)
                {
                    filesToIgnore.Add(infoFile);
                }
            }

            numIgnoreRules.Text = "Ignore rules: " + (directoriesToIgnore.Count + filesToIgnore.Count);

            //btnPause.Enabled = true;
            btnCancel.Enabled = true;
            btnStart.Enabled = false;


            this._cancelToken = new CancellationTokenSource();
            //cancelToken.Token.Register(ResetButtons);


            try
            {
                await this.CountFiles(rootDir,
                    extensions.Select(p => "." + p).ToList(),
                    filesToIgnore.Select(p => p.FullName).ToList(),
                    directoriesToIgnore.Select(p => p.FullName).ToList()
                );
            }
            catch (Exception)
            {
                //task was cancelled
                lbInfo.Text = "Was cancelled!";
                ResetButtons();
                return;
            }

            //set total files
            lbTotalFiles.Text = 0 + " / " + _totalFilesToScan;

            await this.Scan(rootDir,
                extensions.Select(p => "." + p).ToList(),
                filesToIgnore.Select(p => p.FullName).ToList(),
                directoriesToIgnore.Select(p => p.FullName).ToList(),
                ignoreEmptyLines,
                ignoreEmptyorWhitespaceLines
            );

            lbTotalLines.Text = _currentResult.Lines.ToString();

            if (_cancelToken.IsCancellationRequested)
            {
                lbInfo.Text = "Was cancelled!";
            }
            else
            {
                lbInfo.Text = "Finished";
            }


            ResetButtons();
        }

        private void ResetButtons()
        {
            //btnPause.Enabled = false;
            btnCancel.Enabled = false;
            btnStart.Enabled = true;
            rbAllLines.Enabled = true;
            rbIgnoreEmptyLines.Enabled = true;
            rbIgnoreEmptyOrWhitespaceLines.Enabled = true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this._cancelToken.Cancel();
        }

        private void btnRootDir_Click(object sender, EventArgs e)
        {
            var result = _dialog.ShowDialog();

            if (result != DialogResult.OK) return;

            var info = new FileInfo(_dialog.FileName);

            if (!info.Exists) return;

            tbRootDir.Text = info.DirectoryName;
        }

        private void btnChooseIgnoreFile_Click(object sender, EventArgs e)
        {
            var result = _dialog.ShowDialog();

            if (result != DialogResult.OK) return;

            var info = new FileInfo(_dialog.FileName);

            if (!info.Exists) return;

            tbIgnoreFileConfig.Text = info.FullName;
        }


        /// <summary>
        /// displays the new statistics
        /// </summary>
        /// <param name="fileFullPath">the full path of the current file</param>
        private void ReportProgress(string fileFullPath)
        {
            if (lbTotalLines.InvokeRequired)
            {
                Action invokeAction = () =>
                {
                    progBar.Value = (int) ((_currentResult.Files*100)/_totalFilesToScan);
                    lbTotalFiles.Text = _currentResult.Files + " / " + _totalFilesToScan;
                    lbTotalLines.Text = _currentResult.Lines.ToString();
                    tbFoundFiles.AppendText(Environment.NewLine + fileFullPath);
                };
                this.Invoke(invokeAction);
            }
        }


        /// <summary>
        /// counts the files that will be scanned for lines
        /// </summary>
        /// <param name="rootDir">the root dir to start</param>
        /// <param name="extensions">the extensions for the files to scan (whitelist)</param>
        /// <param name="filesToignore">the files to ignore</param>
        /// <param name="directoriesToIgnore">the directories to ignore</param>
        /// <returns>the task</returns>
        private async Task CountFiles(DirectoryInfo rootDir, List<string> extensions, List<string> filesToignore,
            List<string> directoriesToIgnore)
        {
            await Task.Run(async () =>
            {
                foreach (var fileInfo in rootDir.EnumerateFiles())
                {
                    //is the file ignored?
                    if (filesToignore.Contains(fileInfo.FullName)) continue;

                    //ensure the file extension is in the extensions list
                    if (extensions.Contains(fileInfo.Extension) == false) continue;

                    //scan file for lines
                    _totalFilesToScan++;

                    if (_cancelToken.Token.IsCancellationRequested)
                    {
                        _cancelToken.Token.ThrowIfCancellationRequested();
                    }
                }

                foreach (var directoryInfo in rootDir.EnumerateDirectories())
                {
                    //is the directory ignored?
                    if (directoriesToIgnore.Contains(directoryInfo.FullName)) continue;

                    await this.CountFiles(
                        directoryInfo, extensions, filesToignore, directoriesToIgnore);
                }
            }, _cancelToken.Token);
        }

        /// <summary>
        /// scans/counts the lines of every file in the given root directory
        /// only if the file extensions is in the extensions list and 
        /// only if the file is NOT in the ignore list
        /// also scans sub directories (only if the sub directory is NOT in the ignore list)
        /// </summary>
        /// <param name="rootDir">the root dir</param>
        /// <param name="extensions">the extensions</param>
        /// <param name="filesToignore">the files to ignore</param>
        /// <param name="directoriesToIgnore">the sub directories to ignore</param>
        /// <returns></returns>
        private async Task Scan(DirectoryInfo rootDir, List<string> extensions, List<string> filesToignore,
            List<string> directoriesToIgnore, bool ignoreEmptyLines, bool ignoreEmptyorWhitespaceLines)
        {
            await Task.Run(async () =>
            {
                foreach (var fileInfo in rootDir.EnumerateFiles())
                {
                    //Thread.Sleep(1000);
                    //is the file ignored?
                    if (filesToignore.Contains(fileInfo.FullName)) continue;

                    //ensure the file extension is in the extensions list
                    if (extensions.Contains(fileInfo.Extension) == false) continue;

                    int lines = 0;

                    if (ignoreEmptyLines)
                    {
                        lines = File.ReadLines(fileInfo.FullName).Where(p => !string.IsNullOrEmpty(p)).Count();
                    }
                    else if (ignoreEmptyorWhitespaceLines)
                    {
                        lines = File.ReadLines(fileInfo.FullName).Where(p => !string.IsNullOrWhiteSpace(p)).Count();
                    }
                    else
                    {
                        lines = File.ReadLines(fileInfo.FullName).Count();
                    }

                    _currentResult.Lines += lines;
                    _currentResult.Files += 1;
                    ReportProgress(fileInfo.FullName + "(" + lines + ")");

                    if (_cancelToken.Token.IsCancellationRequested)
                    {
                        return;
                    }
                }

                foreach (var directoryInfo in rootDir.EnumerateDirectories())
                {
                    //is the directory ignored?
                    if (directoriesToIgnore.Contains(directoryInfo.FullName)) continue;

                    await this.Scan(directoryInfo, extensions, filesToignore, directoriesToIgnore, ignoreEmptyLines, ignoreEmptyorWhitespaceLines);
                }
            }, _cancelToken.Token);
        }

    }

    struct CountLinesResult
    {
        /// <summary>
        /// the amount of found files
        /// </summary>
        public long Files { get; set; }

        /// <summary>
        /// the amount of found lines
        /// </summary>
        public long Lines { get; set; }
    }
}