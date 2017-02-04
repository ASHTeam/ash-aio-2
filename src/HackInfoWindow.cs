
using System;
using System.Drawing;
using System.Windows.Forms;

namespace NewAshAIO
{
	/// <summary>
	/// Description of HackInfoWindow.
	/// </summary>
	public partial class HackInfoWindow : Form
	{
		public HackInfoWindow()
		{
			InitializeComponent();
		}
		void CloseWindowButtonClick(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
