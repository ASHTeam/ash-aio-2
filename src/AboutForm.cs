using System;
using System.Drawing;
using System.Windows.Forms;

namespace NewAshAIO
{
	public partial class AboutForm : Form
	{
		public AboutForm()
		{
			InitializeComponent();
		}
		public void AboutFormLoad(object sender, EventArgs e)
		{
			Text = "About - AshAIO";
		}
		void Button1Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
