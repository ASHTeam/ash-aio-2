
namespace NewAshAIO
{
	partial class CodeSaver
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button closeCodeSaver;
		private System.Windows.Forms.Button saveButton;
		private System.Windows.Forms.CheckedListBox selectedHacks;
		
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
			this.label1 = new System.Windows.Forms.Label();
			this.closeCodeSaver = new System.Windows.Forms.Button();
			this.saveButton = new System.Windows.Forms.Button();
			this.selectedHacks = new System.Windows.Forms.CheckedListBox();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(260, 29);
			this.label1.TabIndex = 0;
			this.label1.Text = "Please check the boxes next to the codes you want to be saved to a file.";
			// 
			// closeCodeSaver
			// 
			this.closeCodeSaver.Location = new System.Drawing.Point(207, 360);
			this.closeCodeSaver.Name = "closeCodeSaver";
			this.closeCodeSaver.Size = new System.Drawing.Size(104, 23);
			this.closeCodeSaver.TabIndex = 5;
			this.closeCodeSaver.Text = "Close";
			this.closeCodeSaver.UseVisualStyleBackColor = true;
			this.closeCodeSaver.Click += new System.EventHandler(this.CloseCodeSaverClick);
			// 
			// saveButton
			// 
			this.saveButton.Location = new System.Drawing.Point(22, 360);
			this.saveButton.Name = "saveButton";
			this.saveButton.Size = new System.Drawing.Size(155, 23);
			this.saveButton.TabIndex = 6;
			this.saveButton.Text = "Save selected codes to a file";
			this.saveButton.UseVisualStyleBackColor = true;
			this.saveButton.Click += new System.EventHandler(this.SaveButtonClick);
			// 
			// selectedHacks
			// 
			this.selectedHacks.CheckOnClick = true;
			this.selectedHacks.FormattingEnabled = true;
			this.selectedHacks.Items.AddRange(new object[] {
			"Big Inkling",
			"Darker Ink",
			"Giant Inkling",
			"Glowing Stage",
			"Lighter Ink",
			"Make All Things Big",
			"Make All Small",
			"No Inkling",
			"Small Inkling",
			"Transparent Inkling",
			"White/Blind Ink",
			"Stance Angle",
			"Faceplant",
			"Glide",
			"Cinema Mode",
			"Tentacle Mod",
			"AlphaHax",
			"Apeling/apelong",
			"Headless Body",
			"Crazy Ink Tank",
			"BigInvInkling",
			"Corrupt Textures",
			"Smooth Textures",
			"From the Start",
			"Bouncy Walk",
			"WIP Flyhax",
			"Sustained Jump",
			"SpeedHax",
			"Bomb Bounce",
			"Invisibility 2.0",
			"?NoInkling"});
			this.selectedHacks.Location = new System.Drawing.Point(12, 50);
			this.selectedHacks.MultiColumn = true;
			this.selectedHacks.Name = "selectedHacks";
			this.selectedHacks.Size = new System.Drawing.Size(330, 304);
			this.selectedHacks.TabIndex = 7;
			// 
			// CodeSaver
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(354, 395);
			this.Controls.Add(this.selectedHacks);
			this.Controls.Add(this.saveButton);
			this.Controls.Add(this.closeCodeSaver);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.MaximizeBox = false;
			this.Name = "CodeSaver";
			this.Text = "CodeSaver - AshAIO";
			this.ResumeLayout(false);

		}
	}
}
