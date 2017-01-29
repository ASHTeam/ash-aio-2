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
            }
			this.Text = "AshAIO (version " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString() + ")";
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
			}
			catch (ETCPGeckoException)
			{
				MessageBox.Show("Failed to connect to the Wii U. Make sure you've ran TCPGecko on your Wii U and that you are on the same network as your Wii U.");
				return;
			}
			catch (System.Net.Sockets.SocketException)
			{
				MessageBox.Show("Invalid IP entered.");
				return;
			}
			if (Gecko.peek(0x12CDADA0) == 0x000003F2)
            {
                diff = 0x0;
            }
            else if (Gecko.peek(0x12CE2DA0) == 0x000003F2)
            {
                diff = 0x8000;
            }
            else if (Gecko.peek(0x12CE3DA0) == 0x000003F2)
            {
                diff = 0x9000;
            }
            else
            {
                MessageBox.Show("Failed to find diff.");

                Gecko.Disconnect();
                return;
            }            
            connectBox.Enabled = false;
            disconnectBox.Enabled = true;

            release();
		}
	    public void release()
		{
			ipBox.Enabled = false;
			connectBox.Enabled = false;
			disconnectBox.Enabled = true;
			bigInklingButton.Enabled = true;
			darkInkButton.Enabled = true;
			giantInklingButton.Enabled = true;
			glowingStageButton.Enabled = true;
			lightInkButton.Enabled = true;
			makeEverythingBigButton.Enabled = true;
			makeEverythingSmallButton.Enabled = true;
			noInklingButton.Enabled = true;
			smallInklingButton.Enabled = true;
			transparentInklingButton.Enabled = true;
			whiteBlindInkButton.Enabled = true;
			stanceAngleButton.Enabled = true;
			faceplantButton.Enabled = true;
			glideButton.Enabled = true;
			cinemaModeButton.Enabled = true;
			tentacleModButton.Enabled = true;
			alphaButton.Enabled = true;
			apelingButton.Enabled = true;
			noHeadButton.Enabled = true;
			crazyTankButton.Enabled = true;
			bigInvInklingButton.Enabled = true;
			corruptTexButton.Enabled = true;
			smoothTexButton.Enabled = true;
			fromBeginningButton.Enabled = true;
			wipFlyButton.Enabled = true;
			sustainedJumpButton.Enabled = true;
			speedButton.Enabled = true;
			bounceWalkButton.Enabled = true;
			bombBounceButton.Enabled = true;
			deleteInklingButton.Enabled = true;
			invisibilityTwoButton.Enabled = true;
			revertButton.Enabled = true;
		}
		public void hold()
		{
			ipBox.Enabled = true;
			connectBox.Enabled = true;
			disconnectBox.Enabled = false;
			bigInklingButton.Enabled = false;
			darkInkButton.Enabled = false;
			giantInklingButton.Enabled = false;
			glowingStageButton.Enabled = false;
			lightInkButton.Enabled = false;
			makeEverythingBigButton.Enabled = false;
			makeEverythingSmallButton.Enabled = false;
			noInklingButton.Enabled = false;
			smallInklingButton.Enabled = false;
			transparentInklingButton.Enabled = false;
			whiteBlindInkButton.Enabled = false;
			stanceAngleButton.Enabled = false;
			faceplantButton.Enabled = false;
			glideButton.Enabled = false;
			cinemaModeButton.Enabled = false;
			tentacleModButton.Enabled = false;
			alphaButton.Enabled = false;
			apelingButton.Enabled = false;
			noHeadButton.Enabled = false;
			crazyTankButton.Enabled = false;
			bigInvInklingButton.Enabled = false;
			corruptTexButton.Enabled = false;
			smoothTexButton.Enabled = false;
			fromBeginningButton.Enabled = false;
			wipFlyButton.Enabled = false;
			sustainedJumpButton.Enabled = false;
			speedButton.Enabled = false;
			bounceWalkButton.Enabled = false;
			bombBounceButton.Enabled = false;
			deleteInklingButton.Enabled = false;
			invisibilityTwoButton.Enabled = false;
			revertButton.Enabled = false;
		}
		void DisconnectBoxClick(object sender, EventArgs e)
		{
			try
			{
				disconnectBox.Enabled = false;
				hold();
				Gecko.Disconnect();
				connectBox.Enabled = true;
			}
			catch (NullReferenceException n)
			{
				MessageBox.Show("Failed to disconnect. NullReferenceException encountered. Details:\n" + n);
			}
			catch (Exception f)
			{
				MessageBox.Show("Failed to disconnect. Details:\n" + f);
			}
		}
		void BigInklingButtonClick(object sender, EventArgs e)
		{
	      try
	      {
	      	Gecko.poke(0x105EF2B0, 0x3FC00000);
	      }
	      catch (Exception)
	      {
	      	MessageBox.Show("Failed to poke Big Inkling hack.");
	      }
		}
		void DarkInkButtonClick(object sender, EventArgs e)
		{
	      try
	      {
	      	Gecko.poke(0x106D37A8, 0x3FF00000);
	      }
	      catch (Exception)
	      {
	      	MessageBox.Show("Failed to poke Darker Ink hack.");
	      }
		}
		void GiantInklingButtonClick(object sender, EventArgs e)
		{
			try
			{
				Gecko.poke(0x105EF2B0, 0x40000000);
			}
			catch (Exception)
			{
				MessageBox.Show("Failed to poke Giant Inkling Hack.");
			}
		}
		void GlowingStageButtonClick(object sender, EventArgs e)
		{
		   try
		   {
		   	Gecko.poke(0x10633774, 0x3F830000);
		   }
		   catch (Exception)
		   {
		   	MessageBox.Show("Failed to poke Glowing Stage hack.");
		   }
		}
		void LightInkButtonClick(object sender, EventArgs e)
		{
	       try
	       {
	       	Gecko.poke(0x106D37A8,0x3F100000);
	       }
	       catch (Exception)
	       {
	       	MessageBox.Show("Failed to poke Lighter Ink hack.");
	       }
		}
		void MakeEverythingBigButtonClick(object sender, EventArgs e)
		{
	      try
	      {
	      	Gecko.poke(0x106D3858,0x3FF00000);
	      }
	      catch (Exception)
	      {
	      	MessageBox.Show("Failed to poke Make Everything Big hack.");
	      }
		}
		void MakeEverythingSmallButtonClick(object sender, EventArgs e)
		{
	      try
	      {
	      	Gecko.poke(0x106D3858,0x3F100000);
	      }
	      catch (Exception)
	      {
	      	MessageBox.Show("Failed to poke Make Everthing Small hack.");
	      }
		}
		void NoInklingButtonClick(object sender, EventArgs e)
		{
	      try
	      {
	      	Gecko.poke(0x105EF2B0,0x30000000);
	      }
	      catch (Exception)
	      {
	      	MessageBox.Show("Failed to poke No Inkling hack.");
	      }
		}
		void SmallInklingButtonClick(object sender, EventArgs e)
		{
	       try
	       {
	       	Gecko.poke(0x105EF2B0,0x3F000000);
	       }
	       catch (Exception)
	       {
	       	MessageBox.Show("Failed to poke Small Inkling hack.");
	       }
		}
		void TransparentInklingButtonClick(object sender, EventArgs e)
		{
	      try
	      {
	      	Gecko.poke(0x105EBE34,0x3F100000);
	      	Gecko.poke(0x105EBE40,0x3F100000);
	      }
	      catch (Exception)
	      {
	      	MessageBox.Show("Failed to poke Transparent Inkling hack.");
	      }
		}
		void WhiteBlindInkButtonClick(object sender, EventArgs e)
		{
	      try
	      {
	      	Gecko.poke(0x106D37A8,0x30000000);
	      	MessageBox.Show("!!! WARNING !!! :: Using White/Blind Ink Hacks will corrupt your game sound. Please make sure you have turned down your television/gamepad volume before using this hack.");
	      }
	      catch (Exception)
	      {
	      	MessageBox.Show("Failed to poke White/Blind Ink hack.");
	      }
		}
		void StanceAngleButtonClick(object sender, EventArgs e)
		{
	      try
	      {
	      	Gecko.poke(0x105EC944, 0x3F100000);
	      }
	      catch (Exception)
	      {
	      	MessageBox.Show("Failed to poke Stance Angle hack.");
	      }
		}
		void FaceplantButtonClick(object sender, EventArgs e)
		{
	      try
	      {
	      	Gecko.poke(0x105EC944, 0x30F00000);
	      }
	      catch (Exception)
	      {
	      	MessageBox.Show("Failed to poke Faceplant hack.");
	      }
		}
		void GlideButtonClick(object sender, EventArgs e)
		{
			try
			{
				Gecko.poke(0x105EC944, 0x30A00000);
			}
			catch (Exception)
			{
				MessageBox.Show("Failed to poke Glide hacks.");
			}
		}
		void CinemaModeButtonClick(object sender, EventArgs e)
		{
			try
			{
				Gecko.poke(0x105ECA40, 0x3F400000);
			}
			catch (Exception)
			{
				MessageBox.Show("Failed to poke Cinema Mode hack.");
			}
		}
		void TentacleModButtonClick(object sender, EventArgs e)
		{
	      try
	      {
	      	Gecko.poke(0x105EEBC4, 0x3F300000);
	      }
	      catch (Exception)
	      {
	      	MessageBox.Show("Failed to poke Tentacle Mod hack.");
	      }
		}
		void AlphaButtonClick(object sender, EventArgs e)
		{
			try
			{
				Gecko.poke(0x105F14EC, 30000000);
			}
			catch (Exception)
			{
				MessageBox.Show("Failed to poke AlphaHax.");
			}
		}
		void ApelingButtonClick(object sender, EventArgs e)
		{
	       try
	       {
	       	Gecko.poke(0x10509848, 0x3F900000);
	       }
	       catch (Exception)
	       {
	       	MessageBox.Show("Failed to poke Apeling/Apelong hack.");
	       }
		}
		void NoHeadButtonClick(object sender, EventArgs e)
		{
	      try
	      {
	      	Gecko.poke(0x10509848, 0x3F100000);
	      }
	      catch (Exception)
	      {
	      	MessageBox.Show("Failed to poke Headless Body + Baby Squib hack.");
	      }
		}
		void CrazyTankButtonClick(object sender, EventArgs e)
		{
	      try
	      {
	      	Gecko.poke(0x105098DC, 0x3F500000);
	      }
	      catch (Exception)
	      {
	      	MessageBox.Show("Failed to poke Crazy Ink Tank hack.");
	      }
		}
		void BigInvInklingButtonClick(object sender, EventArgs e)
		{
	      try
	      {
	      	Gecko.poke(0x1050590C, 0x3FF00000);
	      }
	      catch (Exception)
	      {
	      	MessageBox.Show("Failed to poke Big Inkling in Inventory hack.");
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
	      }
	      catch (Exception)
	      {
	      	MessageBox.Show("Failed to poke Corrupt Textures hack.");
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
	      	Gecko.poke(0x10665648, 0xDF000000);
	      	Gecko.poke(0x1066403C, 0xDF000000);
	      	Gecko.poke(0x1065AD60, 0xDF000000);
	      	Gecko.poke(0x10655700, 0xDF000000);
	      	Gecko.poke(0x1064F290, 0xDF000000);
	      	Gecko.poke(0x106331D8, 0xDF000000);
	      	Gecko.poke(0x1062D854, 0xDF000000);
	      	Gecko.poke(0x10612818, 0xDF000000);
	      }
	      catch (Exception)
	      {
	      	MessageBox.Show("Failed to poke Smooth Textures hack.");
	      }
		}
		void FromBeginningButtonClick(object sender, EventArgs e)
		{
	      try
	      {
	      	Gecko.poke(0x10514254, 0x3F000000);
	      }
	      catch (Exception)
	      {
	      	MessageBox.Show("Failed to poke From the Beginning hack.");
	      }
		}
		void BounceWalkButtonClick(object sender, EventArgs e)
		{
	      try
	      {
	      	Gecko.poke(0x105F14EC, 0x3FF00000);
	      }
	      catch (Exception)
	      {
	      	MessageBox.Show("Failed to poke Bouncy Walk hack.");
	      }
		}
		// all safe hacks have been added, now adding dangerous hacks
		void WipFlyButtonClick(object sender, EventArgs e)
		{
	      try
	      {
	      	Gecko.poke(0x105EBE34,0x3FEF0000);
	      }
	      catch (Exception)
	      {
	      	MessageBox.Show("Failed to poke WIP Flyhax.");
	      }
		}
		void SustainedJumpButtonClick(object sender, EventArgs e)
		{
	      try
	      {
	      	Gecko.poke(0x105EBE34, 0x3FC00000);
	      }
	      catch (Exception)
	      {
	      	MessageBox.Show("Failed to poke Sustained Jump hacks.");
	      }
		}
		void SpeedButtonClick(object sender, EventArgs e)
		{
	      try
	      {
	      	Gecko.poke(0x105EBE40, 0x3F100000);
	      }
	      catch (Exception)
	      {
	      	MessageBox.Show("Failed to poke SpeedHax.");
	      }
		}
		void BombBounceButtonClick(object sender, EventArgs e)
		{
	      try
	      {
	      	Gecko.poke(0x1050990C, 0x3F500000);
	      }
	      catch (Exception)
	      {
	      	MessageBox.Show("Failed to poke Bomb Bounce hack.");
	      }
		}
		void InvisibilityTwoButtonClick(object sender, EventArgs e)
		{
		  try
		  {
		  	Gecko.poke(0x10509848, 0x30000000);
		  }
		  catch (Exception)
		  {
		  	MessageBox.Show("Failed to poke Invisibility 2.0 hack.");
		  }
		}
		void DeleteInklingButtonClick(object sender, EventArgs e)
		{
	      try
	      {
	      	Gecko.poke(0x106E757C, 0x70800000);
	      }
	      catch (Exception)
	      {
	      	MessageBox.Show("Failed to poke ?NoInkling hack.");
	      }
		}
		// added all dangerous hacks
		// now adding the tool strip menu items
		void ExitToolStripMenuItemClick(object sender, EventArgs e)
		{
			this.Close();
		}
		void ViewSourceCodeToolStripMenuItemClick(object sender, EventArgs e)
		{
			System.Diagnostics.Process.Start("https://github.com/ASHTeam/ash-aio-2");
		}
		void ViewPovlursSiteToolStripMenuItemClick(object sender, EventArgs e)
		{
			System.Diagnostics.Process.Start("http://povlur.com");
		}
		void ViewHexexpecksSiteToolStripMenuItemClick(object sender, EventArgs e)
		{
			System.Diagnostics.Process.Start("http://hexexpeck.me");
		}
		void ViewASHTeamSiteToolStripMenuItemClick(object sender, EventArgs e)
		{
			System.Diagnostics.Process.Start("http://ashteam.ml");
		}
		void ReportAnIssueToolStripMenuItemClick(object sender, EventArgs e)
		{
			System.Diagnostics.Process.Start("https://github.com/ASHTeam/ash-aio-2/issues/new");
		}
		void JoinASHTeamDiscordToolStripMenuItemClick(object sender, EventArgs e)
		{
			System.Diagnostics.Process.Start("https://discord.gg/fj3Y7px");
		}
		void CheckForUpdatesToolStripMenuItemClick(object sender, EventArgs e)
		{
			Checker checker = new Checker();
            if (checker.getdata() == 0 && checker.ver > GetCurrentVersion())
            {
                checker.ShowDialog();
            }
            else
            {
            	MessageBox.Show("You are up to date.");
            }
		}
		void AboutAshAIOToolStripMenuItem1Click(object sender, EventArgs e)
		{
	      try
	      {
	      	AboutForm aboutForm = new AboutForm();
            aboutForm.ShowDialog(this);
	      }
	      catch (Exception)
	      {
	      	MessageBox.Show("Failed to load About dialog box.");
	      }
		}
		void RevertButtonClick(object sender, EventArgs e)
		{
			try
			{
				Gecko.poke(0x105EF2B0,0x3F800000);
                Gecko.poke(0x106D37A8,0x3F800000);
                Gecko.poke(0x10633774,0x3F800000);
                Gecko.poke(0x106D3858,0x3F800000);
                Gecko.poke(0x105EBE40,0x3F000000);
                Gecko.poke(0x105EBE34,0x3F800000);
                Gecko.poke(0x105EC944, 0x3F800000);
                Gecko.poke(0x105ECA40, 0x3F000000);
                Gecko.poke(0x105EEBC4, 0x3F000000);
                Gecko.poke(0x105F14EC, 0x3F800000);
			}
			catch (Exception)
			{
				MessageBox.Show("Failed to revert hacks.");
			}
		}
		void ViewChangelogToolStripMenuItemClick(object sender, EventArgs e)
		{
			ChangelogForm changelogForm = new ChangelogForm();
			changelogForm.ShowDialog(this);
		}
		void AshAIOLicenseToolStripMenuItemClick(object sender, EventArgs e)
		{
			LicenseForm licenseForm = new LicenseForm();
			licenseForm.ShowDialog();
		}
		void InfoAboutHacksToolStripMenuItemClick(object sender, EventArgs e)
		{
			System.Diagnostics.Process.Start("https://github.com/ASHTeam/ash-aio-2/wiki/information-about-hacks");
		}
		void HowToInstallAshAIOToolStripMenuItemClick(object sender, EventArgs e)
		{
			System.Diagnostics.Process.Start("https://github.com/ASHTeam/ash-aio-2/wiki/How-to-get-ASH-AIO");
		}
		void WikiHomepageToolStripMenuItemClick(object sender, EventArgs e)
		{
	       Help.ShowHelp(this, helpProvider1.HelpNamespace);
		}
	}
}