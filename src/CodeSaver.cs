
using System;
using System.Drawing;
using System.Windows.Forms;

namespace NewAshAIO
{
	/// <summary>
	/// Description of CodeSaver.
	/// </summary>
	public partial class CodeSaver : Form
	{
		public CodeSaver()
		{
			InitializeComponent();
		}
		void CloseCodeSaverClick(object sender, EventArgs e)
		{
			this.Close();
		}
		void SaveButtonClick(object sender, EventArgs e)
		{
			String[] chosenhax = {"BigInkling"};
		}
	}
}
