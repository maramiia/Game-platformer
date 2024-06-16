using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game_platformer5
{
    public partial class Menu : Form
    {
        Timer timer1;
        Form form;
        SoundPlayer music;
        public Menu(Timer timer1, Form form, SoundPlayer music)
        {
            InitializeComponent();
            this.timer1 = timer1;
            this.form = form;
            this.music = music;
        }

        private void OpenMainMenu(object sender, EventArgs e)
        {
            LoadingScreenForm mainMenu = new LoadingScreenForm();
            mainMenu.Show();
            Hide();
            form.Hide();
            music.Stop();
            timer1.Stop();
        }

        private void HideMenu(object sender, EventArgs e)
        {
            Hide();
            timer1.Start();
        }

        private void OpenLearning(object sender, EventArgs e)
        {
            Application.Exit();
            
        }
    }
}
