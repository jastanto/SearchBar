using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.ComponentModel;
using System.Threading;

namespace SearchBar
{
    
    class FileSearch
    {
        private PopupFileSearchForm sForm;
        private delegate void LookupFilesDelegate(String textToLookup);
        private List<FileInfo> lastLookup;
        private List<FileInfo> workingLastLookup;
        private BackgroundWorker executableFileBW;
        private static Mutex mut = new Mutex();
        private DateTime lastExecutableFileSearch;


        public FileSearch(ref PopupFileSearchForm sForm)
        {
            this.sForm = sForm;
            lastLookup = new List<FileInfo>();
            workingLastLookup = new List<FileInfo>();
            lastExecutableFileSearch = DateTime.Now;
            executableFileBW = new BackgroundWorker();
            executableFileBW.DoWork += ExecutableFileBW_DoWork;
            executableFileBW.RunWorkerAsync();
        }

        private void ExecutableFileBW_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                workingLastLookup.Clear();
                DirectoryInfo diTop = new DirectoryInfo(@"c:\");
                foreach (var fi in diTop.EnumerateFiles("*.exe"))
                {
                    try
                    {
                        workingLastLookup.Add(fi);
                        System.Drawing.Icon iconForFile = System.Drawing.SystemIcons.WinLogo;
                        if (!sForm.imageList1.Images.ContainsKey(fi.FullName))
                        {
                            iconForFile = System.Drawing.Icon.ExtractAssociatedIcon(fi.FullName);
                            sForm.imageList1.Images.Add(fi.FullName, iconForFile);
                        }
                    }
                    catch (Exception topE)
                    {
                        Console.WriteLine("{0}", topE.Message);
                    }
                }

                foreach (var di in diTop.EnumerateDirectories("*"))
                {
                    try
                    {
                        foreach (var fi in di.EnumerateFiles("*.exe", SearchOption.AllDirectories))
                        {
                            try
                            {
                                System.Drawing.Icon iconForFile = System.Drawing.SystemIcons.WinLogo;
                                if (!sForm.imageList1.Images.ContainsKey(fi.FullName))
                                {
                                    iconForFile = System.Drawing.Icon.ExtractAssociatedIcon(fi.FullName);
                                    sForm.imageList1.Images.Add(fi.FullName, iconForFile);
                                }
                                workingLastLookup.Add(fi);
                            }
                            catch (Exception fileE)
                            {
                                Console.WriteLine("{0}", fileE.Message);
                            }
                        }
                    }
                    catch (Exception dirE)
                    {
                        Console.WriteLine("{0}", dirE.Message);
                    }
                }
            }
            catch (Exception e2)
            {
                Console.WriteLine("{0}", e2.Message);
            }
            
            mut.WaitOne();
            try
            {
                lastLookup = workingLastLookup.ToList();
                lastExecutableFileSearch = DateTime.Now;
            } catch (Exception e3)
            {
                Console.WriteLine(e3.Message);
            }
            mut.ReleaseMutex();

        }

        public void lookupFiles(String textToLookup)
        {
            if (sForm.InvokeRequired)
            {
                sForm.BeginInvoke((LookupFilesDelegate)lookupFiles, textToLookup);
            }
            
            ((ListView)sForm.Controls["ListViewFileSearch"]).Items.Clear();
            mut.WaitOne();
            ListViewItem item;
            
            foreach (var fi in lastLookup)
            {
                try
                {
                    if (fi.Name.StartsWith(textToLookup))
                    {
                        

                        item = new ListViewItem(fi.Name, 1);

                        
                        item.ImageKey = fi.FullName;
                        ((ListView)sForm.Controls["ListViewFileSearch"]).Items.Add(item);
                        //((ListView)sForm.Controls["ListViewFileSearch"]).Items.Add(fi.Name);
                    }
                }
                catch (Exception UnAuthTop)
                {
                    Console.WriteLine("{0}", UnAuthTop.Message);
                }
            }
            mut.ReleaseMutex();
            if (!executableFileBW.IsBusy && DateTime.Now.Subtract(lastExecutableFileSearch).TotalSeconds > 10)
            {
                executableFileBW.RunWorkerAsync();
            }
            





            /*
            try
            {
                var dirs = from dir in
                   Directory.EnumerateFileSystemEntries("c:\\", textToLookup + "*",
                     SearchOption.AllDirectories)
                           select dir;
                foreach (var curFile in dirs)
                {
                    ((ListView)sForm.Controls["ListViewFileSearch"]).Items.Add(curFile.Substring(curFile.LastIndexOf("\\") + 1));
                }
            } catch (UnauthorizedAccessException uae)
            {
                System.Console.Write(uae.ToString());
            }
            */

        }
    }
}
