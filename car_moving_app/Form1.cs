using System;
using System.Drawing;
using System.Windows.Forms;

namespace car_moving_app
{
    public partial class Form1 : Form
    {

        private Timer timer;
        private int screenWidth = Screen.PrimaryScreen.Bounds.Width;
        private int screenHeight = Screen.PrimaryScreen.Bounds.Height;
        private int currentScreen = 0;
        private int maxScreens = 12;
        private int carSpeed = 10;

        public Form1()
        {
            InitializeComponent();
            InitializeCarAndTimer();
            this.FormBorderStyle = FormBorderStyle.None; 
            this.WindowState = FormWindowState.Maximized;
        }

        private void InitializeCarAndTimer()
        {
            carPictureBox.Image = Image.FromFile("school_bus.png");
            carPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;

            timer = new Timer();
            timer.Interval = 50; 
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            carPictureBox.Left += carSpeed;

            if (carPictureBox.Left >= screenWidth)
            {
                currentScreen++;
                if (currentScreen < maxScreens)
                {
                    MoveToNextScreen();
                }
                else
                {
                    timer.Stop();
                    MessageBox.Show("Az autó elérte a 12 kijelzőt.");
                }
            }
        }

        private void MoveToNextScreen()
        {
            carPictureBox.Left = 0;

            var screen = Screen.AllScreens[currentScreen % Screen.AllScreens.Length];
            this.Location = screen.Bounds.Location;
        }

        
    }
}

