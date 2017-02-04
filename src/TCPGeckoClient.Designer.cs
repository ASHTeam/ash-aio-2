
namespace NewAshAIO
{
	partial class TCPGeckoClient
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage pokeValueTab;
		private System.Windows.Forms.Button closeGeckoClientWindow;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button pokeButton;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox addressBox;
		private System.Windows.Forms.TextBox valueBox;
		
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
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.pokeValueTab = new System.Windows.Forms.TabPage();
			this.pokeButton = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.addressBox = new System.Windows.Forms.TextBox();
			this.valueBox = new System.Windows.Forms.TextBox();
			this.closeGeckoClientWindow = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.tabControl1.SuspendLayout();
			this.pokeValueTab.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.pokeValueTab);
			this.tabControl1.Location = new System.Drawing.Point(12, 27);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(531, 209);
			this.tabControl1.TabIndex = 0;
			// 
			// pokeValueTab
			// 
			this.pokeValueTab.Controls.Add(this.pokeButton);
			this.pokeValueTab.Controls.Add(this.label2);
			this.pokeValueTab.Controls.Add(this.addressBox);
			this.pokeValueTab.Controls.Add(this.valueBox);
			this.pokeValueTab.Location = new System.Drawing.Point(4, 22);
			this.pokeValueTab.Name = "pokeValueTab";
			this.pokeValueTab.Padding = new System.Windows.Forms.Padding(3);
			this.pokeValueTab.Size = new System.Drawing.Size(523, 183);
			this.pokeValueTab.TabIndex = 0;
			this.pokeValueTab.Text = "Poke a value";
			this.pokeValueTab.UseVisualStyleBackColor = true;
			// 
			// pokeButton
			// 
			this.pokeButton.Location = new System.Drawing.Point(191, 90);
			this.pokeButton.Name = "pokeButton";
			this.pokeButton.Size = new System.Drawing.Size(136, 23);
			this.pokeButton.TabIndex = 3;
			this.pokeButton.Text = "Poke";
			this.pokeButton.UseVisualStyleBackColor = true;
			this.pokeButton.Click += new System.EventHandler(this.PokeButtonClick);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(96, 38);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(360, 23);
			this.label2.TabIndex = 2;
			this.label2.Text = "Type in the 2-part code you would like to poke and click the Poke button";
			// 
			// addressBox
			// 
			this.addressBox.Location = new System.Drawing.Point(144, 64);
			this.addressBox.Name = "addressBox";
			this.addressBox.Size = new System.Drawing.Size(100, 20);
			this.addressBox.TabIndex = 1;
			// 
			// valueBox
			// 
			this.valueBox.Location = new System.Drawing.Point(286, 64);
			this.valueBox.Name = "valueBox";
			this.valueBox.Size = new System.Drawing.Size(100, 20);
			this.valueBox.TabIndex = 0;
			// 
			// closeGeckoClientWindow
			// 
			this.closeGeckoClientWindow.Location = new System.Drawing.Point(207, 242);
			this.closeGeckoClientWindow.Name = "closeGeckoClientWindow";
			this.closeGeckoClientWindow.Size = new System.Drawing.Size(136, 23);
			this.closeGeckoClientWindow.TabIndex = 1;
			this.closeGeckoClientWindow.Text = "Close";
			this.closeGeckoClientWindow.UseVisualStyleBackColor = true;
			this.closeGeckoClientWindow.Click += new System.EventHandler(this.CloseGeckoClientWindowClick);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(207, 1);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(136, 23);
			this.label1.TabIndex = 2;
			this.label1.Text = "Modified TCPGecko Client";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// TCPGeckoClient
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(555, 277);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.closeGeckoClientWindow);
			this.Controls.Add(this.tabControl1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.MaximizeBox = false;
			this.Name = "TCPGeckoClient";
			this.Text = "TCPGeckoClient";
			this.tabControl1.ResumeLayout(false);
			this.pokeValueTab.ResumeLayout(false);
			this.pokeValueTab.PerformLayout();
			this.ResumeLayout(false);

		}
	}
}
