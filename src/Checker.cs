using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewAshAIO
{
    public partial class Checker : Form
    {
        public MainForm main;
        public int ver;
        public string data;
        public string ayylmao;
        public WebClient vers = new WebClient();
        public Checker()
        {
            InitializeComponent();
        }
        void CheckerLoad(object sender, EventArgs e)
		{
	      String changelog = vers.DownloadString("https://raw.githubusercontent.com/ASHTeam/ash-aio-2/master/changelog.txt").Replace("\n", Environment.NewLine);
          updateBox.Text = changelog;
		}
        public int getdata()
        { 
            try
            {
            	ayylmao = vers.DownloadString("https://raw.githubusercontent.com/ASHTeam/ash-aio-2/master/version.txt");
                ver = Convert.ToInt32(ayylmao);
                return 0;
            }
            catch
            {
                return 1;
            }

            
        }

        void UpdateLoad(object sender, EventArgs e)
        {
            String changelog = vers.DownloadString("https://raw.githubusercontent.com/ASHTeam/ash-aio-2/master/changelog.txt").Replace("\n", Environment.NewLine);
            updateBox.Text = changelog;
        }

        void CloseButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }
		void GithubButtonClick(object sender, EventArgs e)
		{
			System.Diagnostics.Process.Start("https://github.com/ASHTeam/ash-aio-2/releases/latest");
			MessageBox.Show("Download the latest AIO from the window that just popped up and close this window and the open AIO window.");
			Close();
		}
    }
}
