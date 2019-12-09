using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Runtime.InteropServices;


namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Point mouseOffset;
        int tuopan = 0;
        int touming = 1;
        int shanbi = 0;
        double i=1;
        bool isMouseDown;
        private void Form1_Load(object sender, EventArgs e)
        {

            string path = Application.ExecutablePath;
            RegistryKey rk = Registry.LocalMachine;
            RegistryKey rk2 = rk.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run");
            rk2.SetValue("JcShutdown", path);
            rk2.Close();
            rk.Close();
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(0, 0);
           
        }




        private void 度透明ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Opacity = .50;
            i = 0.50;
        }

        private void 退出QToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void 度透明ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Opacity = .30;
            i = 0.30;
        }

        private void 度透明ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            this.Opacity = .60;
            i = 0.60;
        }

        private void 度透明ToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            this.Opacity = .70;
            i = 0.70;
        }

        private void 全透明ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Opacity = 100;
            i = 1.0;
        }

        private void 度透明ToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            this.Opacity = .80;
            i = 0.80;
        }

        private void 度透明ToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            this.Opacity = .90;
            i = 0.90;
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (tuopan == 1)
            {
                int xOffset;

                int yOffset;

                if (e.Button == MouseButtons.Left)
                {

                    xOffset = -e.X;

                    yOffset = -e.Y;

                    mouseOffset = new Point(xOffset, yOffset);

                    isMouseDown = true;
                }
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (tuopan == 1)
            {
                if (isMouseDown)
                {

                    Point mousePos = Control.MousePosition;

                    mousePos.Offset(mouseOffset.X, mouseOffset.Y);

                    Location = mousePos;

                }
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if (tuopan == 1)
            {
                if (e.Button == MouseButtons.Left)
                {

                    isMouseDown = false;

                }
            }
        }

  

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            
            notifyIcon1.Visible = false;
            shanbi = 0;
           
            //this.ContextMenuStrip = contextMenuStrip1;
            //tuopan = 1;
        }

        private void 自动透明ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (touming == 1)
            {
                touming = 0;
            }
            else touming = 1;
        }

        private void Form1_MouseEnter(object sender, EventArgs e)
        {
            if(shanbi==1)  this.Location=new Point(Screen.PrimaryScreen.Bounds.Width-this.Location.X-454,this.Location.Y);
            if (touming == 1) this.Opacity = 1;
            
        }

        private void Form1_MouseLeave(object sender, EventArgs e)
        {
            if (touming == 1) this.Opacity = i;
        }

        private void 闪避鼠标ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            shanbi = 1;
            notifyIcon1.Visible = true;

        }

        //private const uint WS_EX_LAYERED = 0x80000;
        //private const int WS_EX_TRANSPARENT = 0x20;
        //private const int GWL_STYLE = (-16);
        //private const int GWL_EXSTYLE = (-20);
        //private const int LWA_ALPHA = 0;

        //[DllImport("user32", EntryPoint = "SetWindowLong")]
        //private static extern uint SetWindowLong(
        //IntPtr hwnd,
        //int nIndex,
        //uint dwNewLong
        //);

        //[DllImport("user32", EntryPoint = "GetWindowLong")]
        //private static extern uint GetWindowLong(
        //IntPtr hwnd,
        //int nIndex
        //);

        //[DllImport("user32", EntryPoint = "SetLayeredWindowAttributes")]
        //private static extern int SetLayeredWindowAttributes(
        //IntPtr hwnd,
        //int crKey,
        //int bAlpha,
        //int dwFlags
        //);

        ///// <summary> 
        ///// 设置窗体具有鼠标穿透效果 
        ///// </summary> 
        //public void SetPenetrate()
        //{
        //    GetWindowLong(this.Handle, GWL_EXSTYLE);
        //    SetWindowLong(this.Handle, GWL_EXSTYLE, WS_EX_TRANSPARENT | WS_EX_LAYERED);
        //    SetLayeredWindowAttributes(this.Handle, 0, 50, LWA_ALPHA);
        //}

        private void 鼠标穿透ToolStripMenuItem_Click(object sender, EventArgs e)
        {
           // SetPenetrate();
            notifyIcon2.Visible = true;
            this.TransparencyKey = Color.Fuchsia;
            this.BackColor =  Color.Fuchsia;
            tuopan = 0;
            
        }

        private void notifyIcon2_DoubleClick(object sender, EventArgs e)
        {
            this.TransparencyKey = Color.OrangeRed;
            this.BackColor = Color.OrangeRed;
            notifyIcon2.Visible = false;
            tuopan = 1;
        }


        //private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        //{
        //    shanbi = 0;
        //    notifyIcon1.Visible = false;
        //}

     

        
    }
}