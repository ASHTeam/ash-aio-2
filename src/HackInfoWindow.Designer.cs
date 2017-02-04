
namespace NewAshAIO
{
	partial class HackInfoWindow
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.WebBrowser webBrowser1;
		private System.Windows.Forms.Button closeWindowButton;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.closeWindowButton = new System.Windows.Forms.Button();
			this.webBrowser1 = new System.Windows.Forms.WebBrowser();
			this.SuspendLayout();
			// 
			// closeWindowButton
			// 
			this.closeWindowButton.Location = new System.Drawing.Point(276, 366);
			this.closeWindowButton.Name = "closeWindowButton";
			this.closeWindowButton.Size = new System.Drawing.Size(145, 23);
			this.closeWindowButton.TabIndex = 0;
			this.closeWindowButton.Text = "Close";
			this.closeWindowButton.UseVisualStyleBackColor = true;
			this.closeWindowButton.Click += new System.EventHandler(this.CloseWindowButtonClick);
			// 
			// webBrowser1
			// 
			this.webBrowser1.Location = new System.Drawing.Point(12, 12);
			this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
			this.webBrowser1.Name = "webBrowser1";
			this.webBrowser1.Size = new System.Drawing.Size(672, 348);
			this.webBrowser1.TabIndex = 1;
			this.webBrowser1.Url = new System.Uri("https://github.com/ASHTeam/ash-aio-2/wiki/information-about-hacks", System.UriKind.Absolute);
			// 
			// HackInfoWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(696, 401);
			this.Controls.Add(this.webBrowser1);
			this.Controls.Add(this.closeWindowButton);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.MaximizeBox = false;
			this.Name = "HackInfoWindow";
			this.Text = "Information about hacks - AshAIO";
			this.ResumeLayout(false);

		}
	}
}
