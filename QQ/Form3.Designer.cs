namespace QQ
{
    partial class Form3
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form3));
            this.backPicture = new System.Windows.Forms.PictureBox();
            this.chooseBackground = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.robo = new System.Windows.Forms.Panel();
            this.neko = new System.Windows.Forms.Panel();
            this.paff = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.backPicture)).BeginInit();
            this.chooseBackground.SuspendLayout();
            this.SuspendLayout();
            // 
            // backPicture
            // 
            this.backPicture.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("backPicture.BackgroundImage")));
            this.backPicture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.backPicture.Location = new System.Drawing.Point(1, 1);
            this.backPicture.Name = "backPicture";
            this.backPicture.Size = new System.Drawing.Size(1175, 724);
            this.backPicture.TabIndex = 0;
            this.backPicture.TabStop = false;
            // 
            // chooseBackground
            // 
            this.chooseBackground.AutoScroll = true;
            this.chooseBackground.BackColor = System.Drawing.Color.Transparent;
            this.chooseBackground.Controls.Add(this.panel3);
            this.chooseBackground.Controls.Add(this.panel2);
            this.chooseBackground.Controls.Add(this.robo);
            this.chooseBackground.Controls.Add(this.neko);
            this.chooseBackground.Controls.Add(this.paff);
            this.chooseBackground.Location = new System.Drawing.Point(3, 4);
            this.chooseBackground.Name = "chooseBackground";
            this.chooseBackground.Size = new System.Drawing.Size(1172, 720);
            this.chooseBackground.TabIndex = 1;
            // 
            // panel3
            // 
            
            this.panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel3.Location = new System.Drawing.Point(977, 88);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(212, 541);
            this.panel3.TabIndex = 5;
            // 
            // panel2
            // 
            
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel2.Location = new System.Drawing.Point(1274, 88);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(212, 541);
            this.panel2.TabIndex = 5;
            // 
            // robo
            // 
           
            this.robo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.robo.Location = new System.Drawing.Point(675, 88);
            this.robo.Name = "robo";
            this.robo.Size = new System.Drawing.Size(212, 541);
            this.robo.TabIndex = 5;
            // 
            // neko
            // 
           
            this.neko.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.neko.Location = new System.Drawing.Point(368, 88);
            this.neko.Name = "neko";
            this.neko.Size = new System.Drawing.Size(212, 541);
            this.neko.TabIndex = 4;
            // 
            // paff
            // 
           
            this.paff.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.paff.Location = new System.Drawing.Point(71, 88);
            this.paff.Name = "paff";
            this.paff.Size = new System.Drawing.Size(212, 541);
            this.paff.TabIndex = 3;
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(50)))), ((int)(((byte)(117)))));
            this.ClientSize = new System.Drawing.Size(1177, 726);
            this.Controls.Add(this.chooseBackground);
            this.Controls.Add(this.backPicture);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form3";
            this.ShowInTaskbar = false;
            this.Text = "Form3";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.Load += new System.EventHandler(this.Form3_Load);
            ((System.ComponentModel.ISupportInitialize)(this.backPicture)).EndInit();
            this.chooseBackground.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox backPicture;
        private System.Windows.Forms.Panel chooseBackground;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel robo;
        private System.Windows.Forms.Panel neko;
        private System.Windows.Forms.Panel paff;
    }
}