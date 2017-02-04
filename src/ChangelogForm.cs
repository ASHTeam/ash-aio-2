using System.Net;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace NewAshAIO
{
	/// <summary>
	/// Description of ChangelogForm.
	/// </summary>
	public partial class ChangelogForm : Form
	{
		public WebClient boi = new WebClient();
		public ChangelogForm()
		{
			InitializeComponent();
		}
		void ChangelogFormLoad(object sender, EventArgs e)
		{
		  String changelog = boi.DownloadString("https://raw.githubusercontent.com/ASHTeam/ash-aio-2/master/changelog.txt").Replace("\n", Environment.NewLine);
          changelogTextBox.Text = changelog;
		}
		void Button1Click(object sender, EventArgs e)
		{
			this.Close();
		}
		void ChangelogTextBoxTextChanged(object sender, EventArgs e)
		{
	        String changelog = boi.DownloadString("https://raw.githubusercontent.com/ASHTeam/ash-aio-2/master/changelog.txt").Replace("\n", Environment.NewLine);
            changelogTextBox.Text = changelog;
		}
	}
}
