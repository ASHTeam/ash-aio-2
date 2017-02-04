
namespace NewAshAIO
{
	partial class GeckoClientPokeForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox addressBox;
		private System.Windows.Forms.TextBox valueBox;
		private System.Windows.Forms.Button pokeValuesButton;
		private System.Windows.Forms.Button closePokeButton;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		
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
			this.addressBox = new System.Windows.Forms.TextBox();
			this.valueBox = new System.Windows.Forms.TextBox();
			this.pokeValuesButton = new System.Windows.Forms.Button();
			this.closePokeButton = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(175, 26);
			this.label1.TabIndex = 0;
			this.label1.Text = "Please enter the values to poke";
			// 
			// addressBox
			// 
			this.addressBox.Location = new System.Drawing.Point(142, 38);
			this.addressBox.Name = "addressBox";
			this.addressBox.Size = new System.Drawing.Size(100, 20);
			this.addressBox.TabIndex = 1;
			// 
			// valueBox
			// 
			this.valueBox.Location = new System.Drawing.Point(142, 64);
			this.valueBox.Name = "valueBox";
			this.valueBox.Size = new System.Drawing.Size(100, 20);
			this.valueBox.TabIndex = 2;
			// 
			// pokeValuesButton
			// 
			this.pokeValuesButton.Location = new System.Drawing.Point(32, 102);
			this.pokeValuesButton.Name = "pokeValuesButton";
			this.pokeValuesButton.Size = new System.Drawing.Size(75, 23);
			this.pokeValuesButton.TabIndex = 3;
			this.pokeValuesButton.Text = "Poke";
			this.pokeValuesButton.UseVisualStyleBackColor = true;
			this.pokeValuesButton.Click += new System.EventHandler(this.PokeValuesButtonClick);
			// 
			// closePokeButton
			// 
			this.closePokeButton.Location = new System.Drawing.Point(167, 102);
			this.closePokeButton.Name = "closePokeButton";
			this.closePokeButton.Size = new System.Drawing.Size(75, 23);
			this.closePokeButton.TabIndex = 4;
			this.closePokeButton.Text = "Close";
			this.closePokeButton.UseVisualStyleBackColor = true;
			this.closePokeButton.Click += new System.EventHandler(this.ClosePokeButtonClick);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(32, 38);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 23);
			this.label2.TabIndex = 5;
			this.label2.Text = "Address:";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(32, 64);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(100, 23);
			this.label3.TabIndex = 6;
			this.label3.Text = "Value:";
			// 
			// GeckoClientPokeForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(284, 156);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.closePokeButton);
			this.Controls.Add(this.pokeValuesButton);
			this.Controls.Add(this.valueBox);
			this.Controls.Add(this.addressBox);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.MaximizeBox = false;
			this.Name = "GeckoClientPokeForm";
			this.Text = "Poke a value - AshAIO";
			this.ResumeLayout(false);
			this.PerformLayout();

		}
	}
}
