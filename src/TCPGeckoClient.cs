
using System;
using System.Drawing;
using System.Windows.Forms;

namespace NewAshAIO
{
	/// <summary>
	/// Description of TCPGeckoClient.
	/// </summary>
	public partial class TCPGeckoClient : Form
	{
		public TCPGecko gecko;
		public TCPGeckoClient()
		{
			InitializeComponent();
		}
		void PokeButtonClick(object sender, EventArgs e)
		{
			try
			{
			    uint addressConverted = Convert.ToUInt32(addressBox.Text);
			    uint valueConverted = Convert.ToUInt32(valueBox.Text);
			    gecko.poke(addressConverted, valueConverted);
			}
			catch (Exception)
			{
				MessageBox.Show("Failed to poke values.");
				return;
			}
		}
		void CloseGeckoClientWindowClick(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
