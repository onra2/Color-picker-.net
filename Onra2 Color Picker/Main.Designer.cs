namespace Onra2_Color_Picker
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.labelRGB = new MaterialSkin.Controls.MaterialLabel();
            this.MouseMoveTimer = new System.Windows.Forms.Timer(this.components);
            this.NewButton = new MaterialSkin.Controls.MaterialFlatButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelRGB
            // 
            this.labelRGB.AutoSize = true;
            this.labelRGB.Depth = 0;
            this.labelRGB.Font = new System.Drawing.Font("Roboto", 11F);
            this.labelRGB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelRGB.Location = new System.Drawing.Point(13, 67);
            this.labelRGB.MouseState = MaterialSkin.MouseState.HOVER;
            this.labelRGB.Name = "labelRGB";
            this.labelRGB.Size = new System.Drawing.Size(97, 19);
            this.labelRGB.TabIndex = 0;
            this.labelRGB.Text = "R: 0 G: 0 B: 0 ";
            // 
            // MouseMoveTimer
            // 
            this.MouseMoveTimer.Interval = 10;
            this.MouseMoveTimer.Tick += new System.EventHandler(this.MouseMoveTimer_Tick);
            // 
            // NewButton
            // 
            this.NewButton.AutoSize = true;
            this.NewButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.NewButton.Depth = 0;
            this.NewButton.Icon = null;
            this.NewButton.Location = new System.Drawing.Point(13, 92);
            this.NewButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.NewButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.NewButton.Name = "NewButton";
            this.NewButton.Primary = false;
            this.NewButton.Size = new System.Drawing.Size(51, 36);
            this.NewButton.TabIndex = 1;
            this.NewButton.Text = "New";
            this.NewButton.UseVisualStyleBackColor = true;
            this.NewButton.Click += new System.EventHandler(this.NewButton_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(160, 71);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(94, 64);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(263, 143);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.NewButton);
            this.Controls.Add(this.labelRGB);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "Main";
            this.Sizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Color Picker";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Main_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialLabel labelRGB;
        private System.Windows.Forms.Timer MouseMoveTimer;
        private MaterialSkin.Controls.MaterialFlatButton NewButton;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

