﻿using System;
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
    public partial class End : Form
    {
        public End()
        {
            InitializeComponent();
        }

        private void End_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void GameClose(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
