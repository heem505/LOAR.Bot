using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;
using AutoIt;

namespace LOAR.Bot
{
    public partial class Client : Form
    {
        public ChromiumWebBrowser Chromium_Browser;

        public Client()
        {
            InitializeComponent();
            //Initialize_Chromium();
            //MessageBox.Show("123");

        }


        #region Other Functions

        public void Initialize_Chromium()
        {
            // Initialize CEF with the provided settings
            CefSettings settings = new CefSettings();

            Cef.Initialize(settings);

            Chromium_Browser = new ChromiumWebBrowser("")
            {
                //Location = new Point(0,0),
                //Size = new Size(985, 580),
                Dock = DockStyle.Fill,

            };


            Chromium_Browser.FrameLoadEnd += OnBrowserFrameLoadEnd;
            this.Server_Panel.Controls.Add(Chromium_Browser);
            //Browser_Added = 1;

        }

        private void OnBrowserFrameLoadEnd(object sender, FrameLoadEndEventArgs args)
        {
            if (args.Frame.IsMain)
            {
                // Shows an alert after page is loaded so it definitely works
                //args
                //    .Browser
                //    .MainFrame
                //    .ExecuteJavaScriptAsync("alert('HELLO!')");

                // Scrollbars are still visible after this fires
                AutoItX.Sleep(1000);
                args
                    .Browser
                    .MainFrame
                    .ExecuteJavaScriptAsync(
                    "(function() { document.body.style.overflow = 'hidden'; });");
            }
        }


        #endregion Other Functions


        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void panel_Client_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Client_FormClosed(object sender, FormClosedEventArgs e)
        {
            Cef.Shutdown();
        }
    }
}
