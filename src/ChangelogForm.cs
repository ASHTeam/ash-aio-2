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
		void Button1Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
