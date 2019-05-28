namespace LOAR.Bot
{
    partial class Client
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Client));
            this.Server_Panel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // Server_Panel
            // 
            this.Server_Panel.BackgroundImage = global::LOAR.Bot.Properties.Resources.Server_Wallpaper;
            this.Server_Panel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Server_Panel.Location = new System.Drawing.Point(0, 0);
            this.Server_Panel.Name = "Server_Panel";
            this.Server_Panel.Size = new System.Drawing.Size(1005, 657);
            this.Server_Panel.TabIndex = 0;
            this.Server_Panel.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_Client_Paint);
            // 
            // Client
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1005, 640);
            this.ControlBox = false;
            this.Controls.Add(this.Server_Panel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Client";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Client";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Client_FormClosed);
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel Server_Panel;
    }
}