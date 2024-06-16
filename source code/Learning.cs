using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game_platformer5
{
    public partial class Learning : Form
    {
        public bool checkClick;
        public Learning()
        {
            InitializeComponent();
            checkClick = false;
        }

        private void Learning_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void StartGame(object sender, EventArgs e)
        {
            checkClick = true;
            Level1 level1 = new Level1();
            level1.Show();
            Hide();
        }
    }
}
