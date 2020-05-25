using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.Security.Permissions;

namespace Lab4
{
    [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
    public partial class Form1 : Form
    {

        Source source;
        public Form1()
        {
            InitializeComponent();

            source = new Source();

            using(FileSystemWatcher watcher = new FileSystemWatcher())
            {
                watcher.Path = @"C:\Users\Evgentus\Desktop\SmmLogs\QueueValues";
                watcher.NotifyFilter = NotifyFilters.Attributes |
                NotifyFilters.CreationTime |
                NotifyFilters.DirectoryName |
                NotifyFilters.FileName |
                NotifyFilters.LastAccess |
                NotifyFilters.LastWrite |
                NotifyFilters.Security |
                NotifyFilters.Size;

                watcher.Changed += OnChanged;
                watcher.Created += OnChanged; 
                watcher.Deleted += OnChanged;

                watcher.Filter = "*.txt";

                watcher.EnableRaisingEvents = true;
            }
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            new Thread(Start).Start();
        }

        private void Start()
        {
            source.ExecuteAsync(new CancellationToken(false));
        }

        private void OnChanged(object source, FileSystemEventArgs e)
        {
            textBoxQueue1.Text = "test";
        }
    }
}
