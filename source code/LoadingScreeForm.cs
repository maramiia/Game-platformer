using System;
using System.Windows.Forms;

namespace Game_platformer5
{
    public partial class LoadingScreenForm : Form
    {
        public LoadingScreenForm()
        {
            InitializeComponent();
        }

        private void LoadGame(object sender, EventArgs e)
        {
            Learning learning = new Learning();

            learning.Show();
            this.Hide();
        }

        private void GameClose(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
