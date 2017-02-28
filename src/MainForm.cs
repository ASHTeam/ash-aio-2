/* Copyright (c) 2017 ASH Team

Permission is hereby granted, free of charge, to any person obtaining a copy of this
software and associated documentation files (the "Software"), to deal in the Software
without restriction, including without limitation the rights to use, copy, modify, merge,
publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons
to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or
substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED,
INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR
PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE
FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR
OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
DEALINGS IN THE SOFTWARE.
*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Reflection;

namespace NewAshAIO
{
	/// <summary>
	/// Main file for ASH-AIO, an all in one tool for Splatoon hacking, contains hacks found by the Actual Splatoon Hacking Team.
	/// </summary>
	public partial class MainForm : Form
	{
		// general vars
		public uint diff;
		public uint revert;
		public TCPGecko Gecko;
		private NoteSheets notes;
		// end general vars
		// now we can do real code
		public MainForm()
		{
			InitializeComponent();
		}
		
		public void MainFormLoad(object sender, EventArgs e)
		{
			hold();
			helpProvider1.HelpNamespace = "https://github.com/ASHTeam/ash-aio-2/wiki";
            helpProvider1.SetShowHelp(this, true);
			Checker checker = new Checker();
			if (checker.getdata() == 0 && checker.ver > GetCurrentVersion())
            {
                checker.ShowDialog();
                statusLabel.Text = "Update available.";
            }
			else if (checker.getdata() == 0 && checker.ver < GetCurrentVersion())
			{
				MessageBox.Show("Development Mode Warning: You are using a version of AshAIO that is not available to the public yet. This version can contain lots of bugs/unfinished content, so please use caution.");
				statusLabel.Text = "Ready - AshAIO Development Mode";
			}
			this.Text = "AshAIO (version " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString() + ")";
			notes = new NoteSheets();
		}
		public static int GetCurrentVersion()
        {
            String version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
            StringBuilder builder = new StringBuilder(version.Length);

            for (int i = 0; i < version.Length; i++)
            {
                if (!version[i].Equals('.'))
                {
                    builder.Append(version[i]);
                }
            }

            return Convert.ToInt32(builder.ToString());
		}
	    void ConnectBoxClick(object sender, EventArgs e)
		{
	    	Gecko = new TCPGecko(ipBox.Text, 7331);
			try
			{
				Gecko.Connect();
				statusLabel.Text = "Connected to TCPGecko.";
			}
			catch (ETCPGeckoException)
			{
				MessageBox.Show("Failed to connect to the Wii U. Make sure you've ran TCPGecko on your Wii U and that you are on the same network as your Wii U.");
				statusLabel.Text = "Failed to connect, TCPGecko not found.";
				return;
			}
			catch (System.Net.Sockets.SocketException)
			{
				MessageBox.Show("Invalid IP entered.");
				statusLabel.Text = "Failed to connect, invalid IP entered.";
				return;
			}
			//offset difference checker (not used unless needed)
			/*uint JRAddr = Gecko.peek(0x106E975C) + 0x92D8;
			if (Gecko.peek(JRAddr) == 0x000003F2)
			{
				diff = JRAddr - 0x12CDADA0;
			}
			else
			{
				MessageBox.Show("Failed to find diff.");
				statusLabel.Text = "Failed to find diff.";
				Gecko.Disconnect();
				return;
			}*/
			connectBox.Enabled = false;
			disconnectBox.Enabled = true;

			release();
		}
		public void release()
		{
			ipBox.Enabled = false;
			connectBox.Enabled = false;
			disconnectBox.Enabled = true;
			revertButton.Enabled = true;
			hackBrowser.Enabled = true;
			moddedTCPGeckoClientToolStripMenuItem.Enabled = true;
		}
		public void hold()
		{
			ipBox.Enabled = true;
			connectBox.Enabled = true;
			disconnectBox.Enabled = false;
			revertButton.Enabled = false;
			hackBrowser.Enabled = false;
			moddedTCPGeckoClientToolStripMenuItem.Enabled = false;
		}
		void DisconnectBoxClick(object sender, EventArgs e)
		{
			try
			{
				disconnectBox.Enabled = false;
				hold();
				Gecko.Disconnect();
				connectBox.Enabled = true;
				statusLabel.Text = "Disconnected from Wii U.";
			}
			catch (NullReferenceException)
			{
				MessageBox.Show("Failed to disconnect. You are not connected, how do you expect me to disconnect?.");
				statusLabel.Text = "Not connected, cannot disconnect.";
			}
			catch (Exception f)
			{
				MessageBox.Show("Failed to disconnect. Report this issue on the AshAIO 2 GitHub (https://github.com/ASHTeam/ash-aio-2/issues/new) and include the following information:\n" + f);
				statusLabel.Text = "Unknown exception occured during disconnection.";
			}
		}
		void BigInklingButtonClick(object sender, EventArgs e)
		{
	      try
	      {
	      	Gecko.poke(0x105EF2B0, 0x3FC00000);
	      	statusLabel.Text = "Big Inkling hack poked.";
	      }
	      catch (Exception)
	      {
	      	MessageBox.Show("Failed to poke Big Inkling hack.");
	      	statusLabel.Text = "Failed to poke Big Inkling hack.";
	      }
		}
		void DarkInkButtonClick(object sender, EventArgs e)
		{
	      try
	      {
	      	Gecko.poke(0x106D37A8, 0x3FF00000);
	      	statusLabel.Text = "Darker Ink hack poked.";
	      }
	      catch (Exception)
	      {
	      	MessageBox.Show("Failed to poke Darker Ink hack.");
	      	statusLabel.Text = "Failed to poke Darker Ink hack.";
	      }
		}
		void GiantInklingButtonClick(object sender, EventArgs e)
		{
			try
			{
				Gecko.poke(0x105EF2B0, 0x40000000);
				statusLabel.Text = "Giant Inkling hack poked.";
			}
			catch (Exception)
			{
				MessageBox.Show("Failed to poke Giant Inkling hack.");
				statusLabel.Text = "Failed to poke Giant Inkling hack.";
			}
		}
		void GlowingStageButtonClick(object sender, EventArgs e)
		{
		   try
		   {
		   	Gecko.poke(0x10633774, 0x3F830000);
		   	statusLabel.Text = "Glowing Stage hack poked.";
		   }
		   catch (Exception)
		   {
		   	MessageBox.Show("Failed to poke Glowing Stage hack.");
		   	statusLabel.Text = "Failed to poke Glowing Stage hack.";
		   }
		}
		void LightInkButtonClick(object sender, EventArgs e)
		{
	       try
	       {
	       	Gecko.poke(0x106D37A8,0x3F100000);
	       	statusLabel.Text = "Lighter Ink hack poked.";
	       }
	       catch (Exception)
	       {
	       	MessageBox.Show("Failed to poke Lighter Ink hack.");
	       	statusLabel.Text = "Failed to poke Lighter Ink hack.";
	       }
		}
		void MakeEverythingBigButtonClick(object sender, EventArgs e)
		{
	      try
	      {
	      	Gecko.poke(0x106D3858,0x3FF00000);
	      	statusLabel.Text = "Make Everything Big hack poked.";
	      }
	      catch (Exception)
	      {
	      	MessageBox.Show("Failed to poke Make Everything Big hack.");
	      	statusLabel.Text = "Failed to poke Make Everything Big hack.";
	      }
		}
		void MakeEverythingSmallButtonClick(object sender, EventArgs e)
		{
	      try
	      {
	      	Gecko.poke(0x106D3858,0x3F100000);
	      	statusLabel.Text = "Make Everything Small hack poked.";
	      }
	      catch (Exception)
	      {
	      	MessageBox.Show("Failed to poke Make Everything Small hack.");
	      	statusLabel.Text = "Failed to poke Make Everything Small hack.";
	      }
		}
		void NoInklingButtonClick(object sender, EventArgs e)
		{
	      try
	      {
	      	Gecko.poke(0x105EF2B0,0x30000000);
	      	statusLabel.Text = "No Inkling hack poked.";
	      }
	      catch (Exception)
	      {
	      	MessageBox.Show("Failed to poke No Inkling hack.");
	      	statusLabel.Text = "Failed to poke No Inkling hack.";
	      }
		}
		void SmallInklingButtonClick(object sender, EventArgs e)
		{
	       try
	       {
	       	Gecko.poke(0x105EF2B0,0x3F000000);
	       	statusLabel.Text = "Small Inkling hack poked.";
	       }
	       catch (Exception)
	       {
	       	MessageBox.Show("Failed to poke Small Inkling hack.");
	       	statusLabel.Text = "Failed to poke Small Inkling hack.";
	       }
		}
		void TransparentInklingButtonClick(object sender, EventArgs e)
		{
	      try
	      {
	      	Gecko.poke(0x105EBE34,0x3F100000);
	      	Gecko.poke(0x105EBE40,0x3F100000);
	      	statusLabel.Text = "Transparent Inkling hack poked.";
	      }
	      catch (Exception)
	      {
	      	MessageBox.Show("Failed to poke Transparent Inkling hack.");
	      	statusLabel.Text = "Failed to poke Transparent Inkling hack.";
	      }
		}
		void WhiteBlindInkButtonClick(object sender, EventArgs e)
		{
	      try
	      {
	      	Gecko.poke(0x106D37A8,0x30000000);
	      	MessageBox.Show("!!! WARNING !!! :: Using White/Blind Ink Hacks will corrupt your game sound. Please make sure you have turned down your television/gamepad volume before using this hack.");
	      	statusLabel.Text = "White/Blind Ink hack poked.";
	      }
	      catch (Exception)
	      {
	      	MessageBox.Show("Failed to poke White/Blind Ink hack.");
	      	statusLabel.Text = "Failed to poke White/Blind Ink hack.";
	      }
		}
		void StanceAngleButtonClick(object sender, EventArgs e)
		{
	      try
	      {
	      	Gecko.poke(0x105EC944, 0x3F100000);
	      	statusLabel.Text = "Stance Angle hack poked.";
	      }
	      catch (Exception)
	      {
	      	MessageBox.Show("Failed to poke Stance Angle hack.");
	      	statusLabel.Text = "Failed to poke Stance Angle hack.";
	      }
		}
		void FaceplantButtonClick(object sender, EventArgs e)
		{
	      try
	      {
	      	Gecko.poke(0x105EC944, 0x30F00000);
	      	statusLabel.Text = "Faceplant hack poked.";
	      }
	      catch (Exception)
	      {
	      	MessageBox.Show("Failed to poke Faceplant hack.");
	      	statusLabel.Text = "Failed to poke Faceplant hack.";
	      }
		}
		void GlideButtonClick(object sender, EventArgs e)
		{
			try
			{
				Gecko.poke(0x105EC944, 0x30A00000);
				statusLabel.Text = "Glide hack poked.";
			}
			catch (Exception)
			{
				MessageBox.Show("Failed to poke Glide hack.");
				statusLabel.Text = "Failed to poke Glide hack.";
			}
		}
		void CinemaModeButtonClick(object sender, EventArgs e)
		{
			try
			{
				Gecko.poke(0x105ECA40, 0x3F400000);
				statusLabel.Text = "Cinema Mode hack poked.";
			}
			catch (Exception)
			{
				MessageBox.Show("Failed to poke Cinema Mode hack.");
				statusLabel.Text = "Failed to poke Cinema Mode hack.";
			}
		}
		void TentacleModButtonClick(object sender, EventArgs e)
		{
	      try
	      {
	      	Gecko.poke(0x105EEBC4, 0x3F300000);
	      	statusLabel.Text = "Tentacle Mod hack poked.";
	      }
	      catch (Exception)
	      {
	      	MessageBox.Show("Failed to poke Tentacle Mod hack.");
	      	statusLabel.Text = "Failed to poke Tentacle Mod hack.";
	      }
		}
		void AlphaButtonClick(object sender, EventArgs e)
		{
			try
			{
				Gecko.poke(0x105F14EC, 30000000);
				statusLabel.Text = "AlphaHax poked.";
			}
			catch (Exception)
			{
				MessageBox.Show("Failed to poke AlphaHax.");
				statusLabel.Text = "Failed to poke AlphaHax.";
			}
		}
		void ApelingButtonClick(object sender, EventArgs e)
		{
	       try
	       {
	       	Gecko.poke(0x10509848, 0x3F900000);
	       	statusLabel.Text = "Apeling/apelong hack poked.";
	       }
	       catch (Exception)
	       {
	       	MessageBox.Show("Failed to poke Apeling/Apelong hack.");
	       	statusLabel.Text = "Failed to poke Apeling/apelong hack.";
	       }
		}
		void NoHeadButtonClick(object sender, EventArgs e)
		{
	      try
	      {
	      	Gecko.poke(0x10509848, 0x3F100000);
	      	statusLabel.Text = "Headless Body hack poked.";
	      }
	      catch (Exception)
	      {
	      	MessageBox.Show("Failed to poke Headless Body + Baby Squib hack.");
	      	statusLabel.Text = "Failed to poke Headless Body hack.";
	      }
		}
		void CrazyTankButtonClick(object sender, EventArgs e)
		{
	      try
	      {
	      	Gecko.poke(0x105098DC, 0x3F500000);
	      	statusLabel.Text = "Crazy Ink Tank hack poked.";
	      }
	      catch (Exception)
	      {
	      	MessageBox.Show("Failed to poke Crazy Ink Tank hack.");
	      	statusLabel.Text = "Failed to poke Crazy Ink Tank hack.";
	      }
		}
		void BigInvInklingButtonClick(object sender, EventArgs e)
		{
	      try
	      {
	      	Gecko.poke(0x1050590C, 0x3FF00000);
	      	statusLabel.Text = "BigInvInkling hack poked.";
	      }
	      catch (Exception)
	      {
	      	MessageBox.Show("Failed to poke Big Inkling in Inventory hack.");
	      	statusLabel.Text = "Failed to poke BigInvInkling hack.";
	      }
		}
		void CorruptTexButtonClick(object sender, EventArgs e)
		{
	      try
	      {
	      	Gecko.poke(0x106FA63C, 0xAF000000);
	      	Gecko.poke(0x106DD694, 0xAF000000);
	      	Gecko.poke(0x106DD4A8, 0xAF000000);
	      	Gecko.poke(0x106DCB70, 0xAF000000);
	      	Gecko.poke(0x106DC9F8, 0xAF000000);
	      	Gecko.poke(0x106DC2DC, 0xAF000000);
	      	Gecko.poke(0x106DBF68, 0xAF000000);
	      	Gecko.poke(0x106DA588, 0xAF000000);
	      	Gecko.poke(0x106D89AC, 0xAF000000);
	      	Gecko.poke(0x106D7B48, 0xAF000000);
	      	Gecko.poke(0x106D1DF8, 0xAF000000);
	      	Gecko.poke(0x106D1DEC, 0xAF000000);
	      	Gecko.poke(0x106D1DD4, 0xAF000000);
	      	Gecko.poke(0x106D1924, 0xAF000000);
	      	Gecko.poke(0x106CE0B8, 0xAF000000);
	      	Gecko.poke(0x10699C30, 0xAF000000);
	      	Gecko.poke(0x1067C9C4, 0xAF000000);
	      	Gecko.poke(0x10667A24, 0xAF000000);
	      	Gecko.poke(0x10665648, 0xAF000000);
	      	Gecko.poke(0x1066403C, 0xAF000000);
	      	Gecko.poke(0x1065AD60, 0xAF000000);
	      	Gecko.poke(0x10655700, 0xAF000000);
	      	Gecko.poke(0x1064F290, 0xAF000000);
	      	Gecko.poke(0x106331D8, 0xAF000000);
	      	Gecko.poke(0x1062D854, 0xAF000000);
	      	Gecko.poke(0x10612818, 0xAF000000);
	      	statusLabel.Text = "Poked Corrupt Textures.";
	      }
	      catch (Exception)
	      {
	      	MessageBox.Show("Failed to poke Corrupt Textures hack.");
	      	statusLabel.Text = "Failed to poke Corrupt Textures.";
	      }
		}
		void SmoothTexButtonClick(object sender, EventArgs e)
		{
	      try
	      {
	        Gecko.poke(0x106FA63C, 0xDF000000);
	      	Gecko.poke(0x106DD694, 0xDF000000);
	      	Gecko.poke(0x106DD4A8, 0xDF000000);
	      	Gecko.poke(0x106DCB70, 0xDF000000);
	      	Gecko.poke(0x106DC9F8, 0xDF000000);
	      	Gecko.poke(0x106DC2DC, 0xDF000000);
	      	Gecko.poke(0x106DBF68, 0xDF000000);
	      	Gecko.poke(0x106DA588, 0xDF000000);
	      	Gecko.poke(0x106D89AC, 0xDF000000);
	      	Gecko.poke(0x106D7B48, 0xDF000000);
	      	Gecko.poke(0x106D1DF8, 0xDF000000);
	      	Gecko.poke(0x106D1DEC, 0xDF000000);
	      	Gecko.poke(0x106D1DD4, 0xDF000000);
	      	Gecko.poke(0x106D1924, 0xDF000000);
	      	Gecko.poke(0x106CE0B8, 0xDF000000);
	      	Gecko.poke(0x10699C30, 0xDF000000);
	      	Gecko.poke(0x1067C9C4, 0xDF000000);
	      	Gecko.poke(0x10667A24, 0xDF000000);
	      	Gecko.poke(0x10665648, 0xDF000000);
	      	Gecko.poke(0x1066403C, 0xDF000000);
	      	Gecko.poke(0x1065AD60, 0xDF000000);
	      	Gecko.poke(0x10655700, 0xDF000000);
	      	Gecko.poke(0x1064F290, 0xDF000000);
	      	Gecko.poke(0x106331D8, 0xDF000000);
	      	Gecko.poke(0x1062D854, 0xDF000000);
	      	Gecko.poke(0x10612818, 0xDF000000);
	      	statusLabel.Text = "Poked Smooth Textures.";
	      }
	      catch (Exception)
	      {
	      	MessageBox.Show("Failed to poke Smooth Textures hack.");
	      	statusLabel.Text = "Failed to poke Smooth Textures.";
	      }
		}
		void FromBeginningButtonClick(object sender, EventArgs e)
		{
	      try
	      {
	      	Gecko.poke(0x10514254, 0x3F000000);
	      	statusLabel.Text = "From the Beginning hack poked.";
	      }
	      catch (Exception)
	      {
	      	MessageBox.Show("Failed to poke From the Beginning hack.");
	      	statusLabel.Text = "Failed to poke From the Beginning hack.";
	      }
		}
		void BounceWalkButtonClick(object sender, EventArgs e)
		{
	      try
	      {
	      	Gecko.poke(0x105F14EC, 0x3FF00000);
	      	statusLabel.Text = "Bouncy Walk hack poked.";
	      }
	      catch (Exception)
	      {
	      	MessageBox.Show("Failed to poke Bouncy Walk hack.");
	      	statusLabel.Text = "Failed to poke Bouncy Walk hack.";
	      }
		}
		// all safe hacks have been added, now adding dangerous hacks
		void WipFlyButtonClick(object sender, EventArgs e)
		{
	      try
	      {
	      	Gecko.poke(0x105EBE34,0x3FEF0000);
	      	statusLabel.Text = "WIP Flyhax poked.";
	      }
	      catch (Exception)
	      {
	      	MessageBox.Show("Failed to poke WIP Flyhax.");
	      	statusLabel.Text = "Failed to poke WIP Flyhax.";
	      }
		}
		void SustainedJumpButtonClick(object sender, EventArgs e)
		{
	      try
	      {
	      	Gecko.poke(0x105EBE34, 0x3FC00000);
	      	statusLabel.Text = "Sustained Jump hack poked.";
	      }
	      catch (Exception)
	      {
	      	MessageBox.Show("Failed to poke Sustained Jump hacks.");
	      	statusLabel.Text = "Failed to poke Sustained Jump hack.";
	      }
		}
		void SpeedButtonClick(object sender, EventArgs e)
		{
	      try
	      {
	      	Gecko.poke(0x105EBE40, 0x3F100000);
	      	statusLabel.Text = "SpeedHax poked.";
	      }
	      catch (Exception)
	      {
	      	MessageBox.Show("Failed to poke SpeedHax.");
	      	statusLabel.Text = "Failed to poke SpeedHax.";
	      }
		}
		void BombBounceButtonClick(object sender, EventArgs e)
		{
	      try
	      {
	      	Gecko.poke(0x1050990C, 0x3F500000);
	      	statusLabel.Text = "Bomb Bounce hack poked.";
	      }
	      catch (Exception)
	      {
	      	MessageBox.Show("Failed to poke Bomb Bounce hack.");
	      	statusLabel.Text = "Failed to poke Bomb Bounce hack.";
	      }
		}
		void InvisibilityTwoButtonClick(object sender, EventArgs e)
		{
		  try
		  {
		  	Gecko.poke(0x10509848, 0x30000000);
		  	statusLabel.Text = "Invisibility 2.0 hack poked.";
		  }
		  catch (Exception)
		  {
		  	MessageBox.Show("Failed to poke Invisibility 2.0 hack.");
		  	statusLabel.Text = "Failed to poke Invisibility 2.0 hack.";
		  }
		}
		void DeleteInklingButtonClick(object sender, EventArgs e)
		{
	      try
	      {
	      	Gecko.poke(0x106E757C, 0x70800000);
	      	statusLabel.Text = "?NoInkling hack poked.";
	      }
	      catch (Exception)
	      {
	      	MessageBox.Show("Failed to poke ?NoInkling hack.");
	      	statusLabel.Text = "Failed to poke ?NoInkling hack.";
	      }
		}

        private void hideGUIButton_Click(object sender, EventArgs e)
        {
            try
            {
                Gecko.poke(0x10650778, 0x50000000);
                Gecko.poke(0x10655644, 0x50000000);
                Gecko.poke(0x106556E0, 0x50000000);
                statusLabel.Text = "Hide GUI poked.";
            }
            catch (Exception)
            {
                MessageBox.Show("Failed to poke hide GUI hack.");
                statusLabel.Text = "Failed to poke hide GUI hack.";
            }
        }
		// added all dangerous hacks
		// now adding the tool strip menu items
		void ExitToolStripMenuItemClick(object sender, EventArgs e)
		{
			this.Close();
		}
		void ViewPovlursSiteToolStripMenuItemClick(object sender, EventArgs e)
		{
			System.Diagnostics.Process.Start("http://povlur.com");
			statusLabel.Text = "Opened povlur's site.";
		}
		void ViewHexexpecksSiteToolStripMenuItemClick(object sender, EventArgs e)
		{
			System.Diagnostics.Process.Start("http://hexexpeck.me");
			statusLabel.Text = "Opened Hexexpeck's site.";
		}
		void ViewASHTeamSiteToolStripMenuItemClick(object sender, EventArgs e)
		{
			System.Diagnostics.Process.Start("http://ashteam.ml");
			statusLabel.Text = "Opened ASH Team site.";
		}
		void JoinASHTeamDiscordToolStripMenuItemClick(object sender, EventArgs e)
		{
			System.Diagnostics.Process.Start("https://discord.gg/fj3Y7px");
			statusLabel.Text = "Opened Discord.";
		}
		void CheckForUpdatesToolStripMenuItemClick(object sender, EventArgs e)
		{
			Checker checker = new Checker();
            if (checker.getdata() == 0 && checker.ver > GetCurrentVersion())
            {
                checker.ShowDialog();
                statusLabel.Text = "Update available.";
            }
            else if (checker.getdata() == 0 && checker.ver < GetCurrentVersion())
            {
            	MessageBox.Show("You are on a version that is not yet released to the public or not yet released on the official ASH AIO 2 GitHub repository.");
            	statusLabel.Text = "You are on a unreleased version of AshAIO.";
            }
            else
            {
            	MessageBox.Show("You are up to date.");
            	statusLabel.Text = "You are up to date.";
            }
		}
		void AboutAshAIOToolStripMenuItem1Click(object sender, EventArgs e)
		{
	      try
	      {
	      	AboutForm aboutForm = new AboutForm();
            aboutForm.ShowDialog(this);
            statusLabel.Text = "Opened About dialog.";
	      }
	      catch (Exception)
	      {
	      	MessageBox.Show("Failed to load About dialog box.");
	      	statusLabel.Text = "Failed to open About window.";
	      }
		}
		void RevertButtonClick(object sender, EventArgs e)
		{
			try
			{
                //GUI
                Gecko.poke(0x10650778, 0x3F800000);
                Gecko.poke(0x10655644, 0x3F800000);
                Gecko.poke(0x106556E0, 0x3F800000);

                //others
                Gecko.poke(0x105EF2B0, 0x3F800000);
                Gecko.poke(0x106D37A8, 0x3F800000);
                Gecko.poke(0x10633774, 0x3F800000);
                Gecko.poke(0x106D3858, 0x3F800000);
                Gecko.poke(0x105EBE40, 0x3F000000);
                Gecko.poke(0x105EBE34, 0x3F800000);
                Gecko.poke(0x105EC944, 0x3F800000);
                Gecko.poke(0x105ECA40, 0x3F000000);
                Gecko.poke(0x105EEBC4, 0x3F000000);
                Gecko.poke(0x105F14EC, 0x3F800000);
                Gecko.poke(0x10509848, 0x3F800000);
                Gecko.poke(0x105098DC, 0x3F000000);
                Gecko.poke(0x1050590C, 0x3F800000);
                Gecko.poke(0x10514254, 0x3F800000);
                Gecko.poke(0x1050990C, 0x3F000000);
                Gecko.poke(0x106E757C, 0x40800000);

                //textures
                Gecko.poke(0x106FA63C, 0xBF000000);
                Gecko.poke(0x106DD694, 0xBF000000);
                Gecko.poke(0x106DD4A8, 0xBF000000);
                Gecko.poke(0x106DCB70, 0xBF000000);
                Gecko.poke(0x106DC9F8, 0xBF000000);
                Gecko.poke(0x106DC2DC, 0xBF000000);
                Gecko.poke(0x106DBF68, 0xBF000000);
                Gecko.poke(0x106DA588, 0xBF000000);
                Gecko.poke(0x106D89AC, 0xBF000000);
                Gecko.poke(0x106D7B48, 0xBF000000);
                Gecko.poke(0x106D1DF8, 0xBF000000);
                Gecko.poke(0x106D1DEC, 0xBF000000);
                Gecko.poke(0x106D1DD4, 0xBF000000);
                Gecko.poke(0x106D1924, 0xBF000000);
                Gecko.poke(0x106CE0B8, 0xBF000000);
                Gecko.poke(0x10699C30, 0xBF000000);
                Gecko.poke(0x1067C9C4, 0xBF000000);
                Gecko.poke(0x10667A24, 0xBF000000);
                Gecko.poke(0x10665648, 0xBF000000);
                Gecko.poke(0x1066403C, 0xBF000000);
                Gecko.poke(0x1065AD60, 0xBF000000);
                Gecko.poke(0x10655700, 0xBF000000);
                Gecko.poke(0x1064F290, 0xBF000000);
                Gecko.poke(0x106331D8, 0xBF000000);
                Gecko.poke(0x1062D854, 0xBF000000);
                Gecko.poke(0x10612818, 0xBF000000);

                statusLabel.Text = "Revert hacks poked.";
			}
			catch (Exception)
			{
				MessageBox.Show("Failed to revert hacks.");
				statusLabel.Text = "Failed to revert.";
			}
		}
		void ViewChangelogToolStripMenuItemClick(object sender, EventArgs e)
		{
			ChangelogForm changelogForm = new ChangelogForm();
			changelogForm.ShowDialog(this);
			statusLabel.Text = "Viewed changelog.";
		}
		void AshAIOLicenseToolStripMenuItemClick(object sender, EventArgs e)
		{
			LicenseForm licenseForm = new LicenseForm();
			licenseForm.ShowDialog();
			statusLabel.Text = "Viewed license.";
		}
		void InfoAboutHacksToolStripMenuItemClick(object sender, EventArgs e)
		{
			HackInfoWindow hackInfoWindow = new HackInfoWindow();
			hackInfoWindow.ShowDialog();
			statusLabel.Text = "Opened Hack Information window.";
		}
		void WikiHomepageToolStripMenuItemClick(object sender, EventArgs e)
		{
	       Help.ShowHelp(this, helpProvider1.HelpNamespace);
	       statusLabel.Text = "Opened GitHub Wiki for AshAIO.";
		}
		void ViewSourceCodeToolStripMenuItem1Click(object sender, EventArgs e)
		{
			System.Diagnostics.Process.Start("https://github.com/ASHTeam/ash-aio-2");
			statusLabel.Text = "Opened GitHub.";
		}
		void ReportAnIssueToolStripMenuItem1Click(object sender, EventArgs e)
		{
			System.Diagnostics.Process.Start("https://github.com/ASHTeam/ash-aio-2/issues/new");
			MessageBox.Show("If you are asked to login or create an account, please do so, it is required for the issue to get submitted to ASH Team.");
			statusLabel.Text = "Opened GitHub issue tracker.";
		}
		void RelatedProjectsToolStripMenuItemClick(object sender, EventArgs e)
		{
			System.Diagnostics.Process.Start("https://github.com/ASHTeam/ash-aio-2/wiki/related-projects");
			statusLabel.Text = "Successfully opened Related projects site.";
		}
		void dangerousHacksClick(object sender, EventArgs e)
		{
			MessageBox.Show("WARNING: ASH Team is NOT responsible if you get banned while using dangerous hacks online. Use caution");
		}
		void AshAioNotifyIconClick(object sender, EventArgs e)
		{
			MessageBox.Show("AshAIO is running on your computer. To close, double click the notification bar icon.");
		}
		void AshAioNotifyIconMouseRightClick(object sender, MouseEventArgs e)
		{
			this.Close();
		}
		void NotepadToolStripMenuItemClick(object sender, EventArgs e)
		{
			notes.Show();
		}
		void ViewMyPCsIPAddressToolStripMenuItemClick(object sender, EventArgs e)
		{
			string hostName = Dns.GetHostName();
            string myIP = Dns.GetHostByName(hostName).AddressList[0].ToString();
            MessageBox.Show("Your IP Address is: "+myIP);
            statusLabel.Text = "Viewed local IP address.";
		}
		void ModdedTCPGeckoClientToolStripMenuItemClick(object sender, EventArgs e)
		{
			TCPGeckoClient tcpGeckoClient = new TCPGeckoClient();
			tcpGeckoClient.ShowDialog();
		}
		void AshAioNotifyIconMouseDoubleClick(object sender, MouseEventArgs e)
		{
			this.Close();
		}
	}
}