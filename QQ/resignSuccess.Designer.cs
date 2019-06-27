namespace QQ
{
    partial class resignSuccess
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
            this.success = new System.Windows.Forms.Label();
            this.conforButton = new System.Windows.Forms.Button();
            this.backGround = new System.Windows.Forms.PictureBox();
            this.clickButten = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.backGround)).BeginInit();
            this.SuspendLayout();
            // 
            // success
            // 
            this.success.AutoSize = true;
            this.success.BackColor = System.Drawing.Color.Transparent;
            this.success.Font = new System.Drawing.Font("微软雅黑", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.success.ForeColor = System.Drawing.Color.Aqua;
            this.success.Location = new System.Drawing.Point(229, 86);
            this.success.Name = "success";
            this.success.Size = new System.Drawing.Size(223, 52);
            this.success.TabIndex = 0;
            this.success.Text = "注册成功！";
            // 
            // conforButton
            // 
            this.conforButton.BackColor = System.Drawing.Color.Transparent;
            this.conforButton.FlatAppearance.BorderSize = 0;
            this.conforButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DeepSkyBlue;
            this.conforButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightCyan;
            this.conforButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.conforButton.Font = new System.Drawing.Font("微软雅黑", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.conforButton.ForeColor = System.Drawing.Color.Aqua;
            this.conforButton.Location = new System.Drawing.Point(536, 306);
            this.conforButton.Margin = new System.Windows.Forms.Padding(0);
            this.conforButton.Name = "conforButton";
            this.conforButton.Size = new System.Drawing.Size(129, 64);
            this.conforButton.TabIndex = 22;
            this.conforButton.Text = "确认";
            this.conforButton.UseVisualStyleBackColor = false;
            this.conforButton.Click += new System.EventHandler(this.ConforButton_Click);
            // 
            // backGround
            // 
            this.backGround.Image = global::QQ.Properties.Resources.cytus2_no;
            this.backGround.Location = new System.Drawing.Point(1, 1);
            this.backGround.Name = "backGround";
            this.backGround.Size = new System.Drawing.Size(664, 369);
            this.backGround.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.backGround.TabIndex = 23;
            this.backGround.TabStop = false;
            // 
            // clickButten
            // 
            this.clickButten.AutoSize = true;
            this.clickButten.BackColor = System.Drawing.Color.Transparent;
            this.clickButten.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.clickButten.ForeColor = System.Drawing.Color.Aqua;
            this.clickButten.Location = new System.Drawing.Point(185, 218);
            this.clickButten.Name = "clickButten";
            this.clickButten.Size = new System.Drawing.Size(317, 39);
            this.clickButten.TabIndex = 24;
            this.clickButten.Text = "点击确认返回登录界面";
            // 
            // resignSuccess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Aqua;
            this.ClientSize = new System.Drawing.Size(666, 371);
            this.Controls.Add(this.clickButten);
            this.Controls.Add(this.conforButton);
            this.Controls.Add(this.success);
            this.Controls.Add(this.backGround);
            this.ForeColor = System.Drawing.Color.DimGray;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "resignSuccess";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "resignSuccess";
            this.Load += new System.EventHandler(this.ResignSuccess_Load);
            ((System.ComponentModel.ISupportInitialize)(this.backGround)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label success;
        private System.Windows.Forms.Button conforButton;
        private System.Windows.Forms.PictureBox backGround;
        private System.Windows.Forms.Label clickButten;
    }
}