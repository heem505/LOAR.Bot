using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using AutoIt;
using System.Diagnostics;
using System.Drawing.Imaging;

using Gecko;


namespace LOAR.Bot
{
    public partial class Main_GUI : Form
    {

        public static GeckoWebBrowser browser = new GeckoWebBrowser();

        // [UDF(Move Window By a Control)]
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        // [UDF(Move Window By a Control)END.Funcs]

        public bool Page_Loaded = false;

        public static string Main_Window = "Calculator";
        public static string Main_Window_Class = "[Class:WindowsForms10.Window.8.app.0.378734a]";
        public static string Main_Control = "[CLASS:Button; INSTANCE:5]";

        public Main_GUI()
        {

            #region To-Do
            /*
            //clange skill image after selection
            this.pictureBox3.BackgroundImage = global::LOAR.Bot.Resource_GUI.Blank_Hero_Skill;
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
             */
            ///*[UDF]*/var task = frame.EvaluateScriptAsync("(function() { return document.getElementsByClassName('mw-headline')[0].innerText; })();", null); /*GetObjByClass*/
            #endregion

            InitializeComponent();

            this.WindowState = FormWindowState.Minimized;
            Start_Browser();
            Login();
            


        }
        
        private void Start_Browser()
        {
            //in Form 1
            Browser Browser_Form = new Browser();
            string URL = "about:blank";
 
            Xpcom.Initialize("Firefox");
            browser.Navigate(URL);
            foreach (Control c in Browser_Form.Controls)
                if (c.Name == "Pan_Browser")
                {
                    c.Controls.Add(browser);
                    browser.Dock = DockStyle.Fill;
       

                }
            Browser_Form.Show();

            Browser_Form.Location = new Point(0, 0);

        }
        
        private void Login()
        {
            /*
            string Email = Inp_Email.Text;
            string Password = Inp_Password.Text;
            string Server_ID = Inp_Server_ID.Text;
            */

            string Email = "ibrahemesam2001@gmail.com";
            string Password = "legend@onliner";
            string Server_ID = "273";

            string Server_URL = "https://loar.oasgames.com/login?server_id=" + Server_ID;
            browser.Navigate(Server_URL);
            Progress_Login.Value = 10;
            browser.DocumentCompleted += Browser_DocumentCompleted;

        browser_wait_load_1:

            Page_Loaded = false;
            Application.DoEvents();
            if (Page_Loaded != true) { goto browser_wait_load_1; }
            Page_Loaded = false;

            Progress_Login.Value = 40;

            browser.Document.GetElementById("user_email").SetAttribute("value", Email);
            browser.Document.GetElementById("user_password").SetAttribute("value", Password);
            Gecko.GeckoHtmlElement btn_login = (Gecko.GeckoHtmlElement)browser.DomDocument.GetElementsByClassName("login_btn")[0];
            btn_login.Click();

            Progress_Login.Value = 50;

        browser_wait_load_2:

            Page_Loaded = false;
            Application.DoEvents();
            if (Page_Loaded != true) { goto browser_wait_load_2; }
            Page_Loaded = false;

            Gecko.GeckoHtmlElement home_playFrame = (Gecko.GeckoHtmlElement)browser.DomDocument.GetElementById("home_playFrame");
            var src = home_playFrame.GetAttribute("src");
            browser.Navigate(src);

        browser_wait_load_3:

            Page_Loaded = false;
            Application.DoEvents();
            if (Page_Loaded != true) { goto browser_wait_load_3; }
            Page_Loaded = false;

            browser.Document.Body.Style.CssText = "overflow: hidden ! important;";

            Progress_Login.Value = 100;
            
        }
        
        private void Browser_DocumentCompleted(object sender, EventArgs args)
        {

                Page_Loaded = true;

        }
        
        private void Test_Click(object sender, EventArgs e)
        {
            /*
            Stopwatch i = new Stopwatch();
            i.Start();
            //Point U = Func._Image_Search_EX("F:/Coding/C#-Sharp Studio/New Bitmap Image.bmp", "Calculator", 20);
            var ii = Func._Click("F:/Coding/C#-Sharp Studio/New Bitmap Image.bmp",0);
            i.Stop();
            MessageBox.Show(i.ElapsedMilliseconds.ToString() + "   " + ii.ToString());
            */



        }

        private void Timer_Browser_View_Tick(object sender, EventArgs e)
        {
            IntPtr Hwnd = AutoItX.WinGetHandle("Browser_Random_3425");
            Bitmap Browser_Image = Func.Capture_Window(Hwnd);
            this.Pan_Browser_View.BackgroundImage = Browser_Image;
        }

        #region GUI_Events

        // [UDF(Move Window By a Control)]
        private void Pan_Title_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        // [UDF(Move Window By a Control)=End]

        private void Btn_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Btn_Minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Lab_Title_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void Pic_Title_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void Btn_Password_Show_Hide_Click(object sender, EventArgs e)
        {
            if (Inp_Password.PasswordChar == '$')
            {
                Inp_Password.PasswordChar = '\0';
                this.Btn_Password_Show_Hide.BackgroundImage = global::LOAR.Bot.Resource_GUI.See_Password;
                this.Btn_Password_Show_Hide.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            }
            else
            {
                Inp_Password.PasswordChar = '$';
                this.Btn_Password_Show_Hide.BackgroundImage = global::LOAR.Bot.Resource_GUI.Hide_Password;
                this.Btn_Password_Show_Hide.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            }

        }

        private void Btn_Login_Click(object sender, EventArgs e)
        {
            Login();

        }

        private void Panel_Frame_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void Browser_Tab_Enter(object sender, EventArgs e)
        {
            //mer_Browser_View.Start();
        }

        private void Browser_Tab_Leave(object sender, EventArgs e)
        {
            Timer_Browser_View.Stop();
            this.Pan_Browser_View.BackgroundImage = global::LOAR.Bot.Resource_GUI.Server_Wallpaper;
        }

        private void Browser_View_Tools_ScreenShot_MouseHover(object sender, EventArgs e)
        {

            this.Browser_View_Tools_ScreenShot.BackgroundImage = global::LOAR.Bot.Resource_GUI.Screen_shot_2;
        }

        private void Browser_View_Tools_ScreenShot_MouseLeave(object sender, EventArgs e)
        {
            this.Browser_View_Tools_ScreenShot.BackgroundImage = global::LOAR.Bot.Resource_GUI.Screen_shot_1;
        }

        private void Browser_View_Tools_ScreenShot_MouseEnter(object sender, EventArgs e)
        {
            this.Browser_View_Tools_ScreenShot.BackgroundImage = global::LOAR.Bot.Resource_GUI.Screen_shot_2;
        }

        private void Browser_View_Tools_ScreenShot_MouseDown(object sender, MouseEventArgs e)
        {
            this.Browser_View_Tools_ScreenShot.BackgroundImage = global::LOAR.Bot.Resource_GUI.Screen_shot_3;
        }

        private void Browser_View_Tools_ScreenShot_MouseUp(object sender, MouseEventArgs e)
        {
            this.Browser_View_Tools_ScreenShot.BackgroundImage = global::LOAR.Bot.Resource_GUI.Screen_shot_2;
        }

        private void Browser_View_Tools_Volume_MouseClick(object sender, MouseEventArgs e)
        {
            this.Browser_View_Tools_Volume.BackgroundImage = global::LOAR.Bot.Resource_GUI.Volume_3;
        }

        private void Browser_View_Tools_Volume_MouseDown(object sender, MouseEventArgs e)
        {
            this.Browser_View_Tools_Volume.BackgroundImage = global::LOAR.Bot.Resource_GUI.Volume_3;
        }

        private void Browser_View_Tools_Volume_MouseEnter(object sender, EventArgs e)
        {
            this.Browser_View_Tools_Volume.BackgroundImage = global::LOAR.Bot.Resource_GUI.Volume_2;
        }

        private void Browser_View_Tools_Volume_MouseHover(object sender, EventArgs e)
        {
            this.Browser_View_Tools_Volume.BackgroundImage = global::LOAR.Bot.Resource_GUI.Volume_2;
        }

        private void Browser_View_Tools_Volume_MouseLeave(object sender, EventArgs e)
        {
            this.Browser_View_Tools_Volume.BackgroundImage = global::LOAR.Bot.Resource_GUI.Volume_1;
        }

        private void Browser_View_Tools_Volume_MouseUp(object sender, MouseEventArgs e)
        {
            this.Browser_View_Tools_Volume.BackgroundImage = global::LOAR.Bot.Resource_GUI.Volume_2;
        }

        private void Browser_View_Tools_View_Resume_Click(object sender, EventArgs e)
        {
            Timer_Browser_View.Start();
        }

        private void Browser_View_Tools_View_Pause_Click(object sender, EventArgs e)
        {
            Timer_Browser_View.Stop();
        }

        private void Browser_View_Tools_View_Stop_Click(object sender, EventArgs e)
        {
            Timer_Browser_View.Stop();
            this.Pan_Browser_View.BackgroundImage = global::LOAR.Bot.Resource_GUI.Server_Wallpaper;
        }


        #endregion GUI_Events

        private void button18_Click(object sender, EventArgs e)
        {
            Stopwatch i = new Stopwatch();

            i.Start();
            var j = AutoItX.WinGetHandle("[Class:WindowsForms10.Window.8.app.0.378734a]");
            i.Stop();
            MessageBox.Show(i.ElapsedMilliseconds.ToString());

            //Func._WinSetStyle_To_POPUP("[Class:WindowsForms10.Window.8.app.0.378734a]");


        }

        public void Scan_Browser()
        {
            Func._WinSetStyle_To_POPUP(Main_Window_Class);
            AutoItX.ControlHide(Main_Window_Class, "", "[NAME:outputLabel]");
            AutoItX.ControlHide(Main_Window_Class, "", "[NAME:toolStrip1]");
            AutoItX.ControlHide(Main_Window_Class, "", "[NAME:menuStrip1]");
            AutoItX.ControlMove(Main_Window_Class, "", "[CLASS:NativeWindowClass; INSTANCE:1]", 0, 0);
            AutoItX.WinMove(Main_Window_Class, "", 0, 0, 1016, 670);
        }


}



}
