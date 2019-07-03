namespace LOAR.Bot
{
    partial class Browser
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
            this.Pan_Browser = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // Pan_Browser
            // 
            this.Pan_Browser.Location = new System.Drawing.Point(0, 0);
            this.Pan_Browser.Name = "Pan_Browser";
            this.Pan_Browser.Size = new System.Drawing.Size(1050, 650);
            this.Pan_Browser.TabIndex = 0;
            // 
            // Browser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1050, 650);
            this.Controls.Add(this.Pan_Browser);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Location = new System.Drawing.Point(-1000, -1000);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Browser";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Browser_Random_3425";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel Pan_Browser;
    }
}