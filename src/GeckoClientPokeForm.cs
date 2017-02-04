
using System;
using System.Drawing;
using System.Windows.Forms;

namespace NewAshAIO
{
	/// <summary>
	/// Description of GeckoClientPokeForm.
	/// </summary>
	public partial class GeckoClientPokeForm : Form
	{
		public TCPGecko Gecko;
		public string addressAsString;
		public uint valueAsString;
		public GeckoClientPokeForm()
		{
			InitializeComponent();
		}
		void ClosePokeButtonClick(object sender, EventArgs e)
		{
			this.Close();
		}
		void PokeValuesButtonClick(object sender, EventArgs e)
		{	
			uint converted = Convert.ToUInt32(addressBox.Text, 32);
			uint convertedTwo = Convert.ToUInt32(valueBox.Text, 32);
			try
			{
			Gecko.poke(converted, convertedTwo);
			}
			catch (ArgumentException)
			{
				MessageBox.Show("Failed to poke values.");
			}
			catch (Exception)
			{
				MessageBox.Show("Failed to poke values.");
			}
		}
	}
}
