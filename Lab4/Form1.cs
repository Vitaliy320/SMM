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

namespace Lab4
{
    public partial class Form1 : Form
    {

        Source source;
        public Form1()
        {
            InitializeComponent();

            source = new Source();
        }

        private async void buttonStart_Click(object sender, EventArgs e)
        {
            await Start();
        }

        private async Task Start()
        {
            await source.ExecuteAsync(new CancellationToken(false));
        }
    }
}
