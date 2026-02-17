
using System.Drawing.Drawing2D;
namespace AE.Application
{
    public partial class Main_Screen_Form : Form
    {
        public Main_Screen_Form()
        {
            InitializeComponent();
            // Apply theme if previously set
            ThemeManager.ApplyThemeToForm(this);

            UC_Home myHome = new UC_Home();
            loadForm(myHome);
            btnHome.ImageSize = new Size(24, 24);
        }
        bool sidebarExpand = false;
        private void btnHome_Click(object sender, EventArgs e)
        {
            UC_Home myHome = new UC_Home();
            loadForm(myHome);
        }

        private void sidebarTimer_Tick(object sender, EventArgs e)
        {
            int minWidth = 50;
            int maxWidth = 200;

            if (sidebarExpand == false)
            {
                sidebar.Width += 10;

                if (sidebar.Width >= maxWidth)
                {
                    sidebarExpand = true;
                    sidebarTimer.Stop();
                }
            }
            else
            {
                sidebar.Width -= 10;

                if (sidebar.Width <= minWidth)
                {
                    sidebarExpand = false;
                    sidebarTimer.Stop();
                }
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            sidebarTimer.Start();
        }
        public void loadForm(UserControl customizedControl)
        {
            pnlMainContent.Controls.Clear();

            customizedControl.Dock = DockStyle.Fill;

            pnlMainContent.Controls.Add(customizedControl);

            pnlMainContent.SendToBack();
            // Apply theme to the newly loaded user control
            if (ThemeManager.IsDarkMode)
                ThemeManager.ApplyThemeRecursively(customizedControl, true);
        }

        private void btnClasses_Click(object sender, EventArgs e)
        {
            UC_Classes myClasses = new UC_Classes();
            loadForm(myClasses);
        }

        private void btnRecords_Click(object sender, EventArgs e)
        {
            UC_Settings myRecords = new UC_Settings();
            loadForm(myRecords);
        }

        private void btnTeacher_Click(object sender, EventArgs e)
        {
            UC_Teacher myTeacher = new UC_Teacher();
            loadForm(myTeacher);
        }
        public void RoundControl(Control control, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddArc(0, 0, radius, radius, 180, 90);
            path.AddArc(control.Width - radius, 0, radius, radius, 270, 90);
            path.AddArc(control.Width - radius, control.Height - radius, radius, radius, 0, 90);
            path.AddArc(0, control.Height - radius, radius, radius, 90, 90);
            path.CloseFigure();

            control.Region = new Region(path);
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnHome_MouseHover(object sender, EventArgs e)
        {
            btnHome.ImageSize = new Size(22,22);
        }
    }
}
