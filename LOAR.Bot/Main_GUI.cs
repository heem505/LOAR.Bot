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
using CefSharp;
using CefSharp.WinForms;
using CefSharp.WinForms.Internals;
using AutoIt;
using System.Diagnostics;
using System.Drawing.Imaging;



namespace LOAR.Bot
{
    public partial class Main_GUI : Form
    {

        public ChromiumWebBrowser Browser;

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

            /*
            Form1 test = new Form1();
            test.Show();
            */
            //sart_Browser();
            //Test_Browser();

            Scan_Browser();


        }

        private void Test_Browser()
        {
            //in Form 1
            this.Hide();
            this.WindowState = FormWindowState.Minimized;
            this.Location = new Point(-1000, -1000);
            Browser Browser_Form = new Browser();
            Browser_Form.StartPosition = FormStartPosition.CenterScreen;
            Browser_Form.Show();


            CefSettings settings = new CefSettings();
            // Initialize cef with the provided settings
            Cef.Initialize(settings);
            // Create a browser component
            string URL = "https://loar.oasgames.com/login";
            Browser = new ChromiumWebBrowser(URL);

            foreach (Control c in Browser_Form.Controls)
                if (c.Name == "Pan_Browser")
                {
                    c.Controls.Add(Browser);
                    Browser.Dock = DockStyle.Fill;
                }
        }

        private void Start_Browser()
        {
            //in Form 1
            Browser Browser_Form = new Browser();
            Browser_Form.Show();


            CefSettings settings = new CefSettings();
            // Initialize cef with the provided settings
            Cef.Initialize(settings);
            // Create a browser component
            string URL = "about:blank";
            Browser = new ChromiumWebBrowser(URL);

            foreach (Control c in Browser_Form.Controls)
                if (c.Name == "Pan_Browser")
                {
                    c.Controls.Add(Browser);
                    Browser.Dock = DockStyle.Fill;
                }

        }


        /*
        private void Login() //Here
        {
            string Email = Inp_Email.Text;
            string Password = Inp_Password.Text;
            string Server_ID = Inp_Server_ID.Text;

            string Server_URL = "https://loar.oasgames.com/login?server_id=" + Server_ID;

            Progress_Login.Value = 10;
            Browser.FrameLoadEnd += Wait_Page_Load;
            //##here >>do wait until Browser load
            Progress_Login.Value = 40;
            Browser.ExecuteScriptAsync("document.getElementById('user_email').value= " + Email);
            Browser.ExecuteScriptAsync("document.getElementById('user_password').value= " + Password);
            Browser.EvaluateScriptAsync("document.getElementsByClassName('login_btn')[0].click()");
            Progress_Login.Value = 50;
            //##here >>do wait until Browser load
            Progress_Login.Value = 100;

        }
        */

        /*
        private void Wait_Page_Load(object sender, FrameLoadEndEventArgs args)
        {
            if (args.Frame.IsMain)
            {
                // Shows an alert after page is loaded so it definitely works
                args
                    .Browser
                    .MainFrame
                    .ExecuteJavaScriptAsync(""); //alert('HELLO!')

                Page_Loaded = true;

                
                //args
                  //  .Browser
                    //.MainFrame
                    //.ExecuteJavaScriptAsync(
                    //"document.body.style.overflow = 'hidden'");
                
            }
        }
        */

        private void Main_GUI_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Cef.Shutdown();
        }

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
                if(Inp_Password.PasswordChar == '$')
                {
                    Inp_Password.PasswordChar = '\0';
                    //this.Btn_Password_Show_Hide.BackgroundImage = global::LOAR.Bot.Resource_GUI.See_Password;
                    this.Btn_Password_Show_Hide.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                }
                else
                {
                    Inp_Password.PasswordChar = '$';
                    //this.Btn_Password_Show_Hide.BackgroundImage = global::LOAR.Bot.Resource_GUI.Hide_Password;
                    this.Btn_Password_Show_Hide.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                }
 
        }

        private void Btn_Login_Click(object sender, EventArgs e)
        {
            //Login();

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

        private void Panel_Frame_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void Timer_Browser_View_Tick(object sender, EventArgs e)
        {
            IntPtr Hwnd = AutoItX.WinGetHandle("[Class:WindowsForms10.Window.8.app.0.378734a]");
            Bitmap Browser_Image = Func.Capture_Window(Hwnd);
            this.Pan_Browser_View.BackgroundImage = Browser_Image;
        }


        #region GUI_Events

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
