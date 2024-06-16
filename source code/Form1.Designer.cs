namespace Game_platformer5
{
    partial class Level1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.player = new System.Windows.Forms.PictureBox();
            this.block = new System.Windows.Forms.PictureBox();
            this.healthBar = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.portal = new System.Windows.Forms.PictureBox();
            this.obelisk = new System.Windows.Forms.PictureBox();
            this.block3 = new System.Windows.Forms.PictureBox();
            this.block1 = new System.Windows.Forms.PictureBox();
            this.block2 = new System.Windows.Forms.PictureBox();
            this.enemy = new System.Windows.Forms.PictureBox();
            this.portalToNextLevel = new System.Windows.Forms.PictureBox();
            this.health = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.player)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.block)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.portal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.obelisk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.block3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.block1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.block2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.enemy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.portalToNextLevel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.health)).BeginInit();
            this.SuspendLayout();
            // 
            // player
            // 
            this.player.Location = new System.Drawing.Point(117, 310);
            this.player.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.player.Name = "player";
            this.player.Size = new System.Drawing.Size(100, 70);
            this.player.TabIndex = 0;
            this.player.TabStop = false;
            // 
            // block
            // 
            this.block.Image = global::Game_platformer5.Properties.Resources.block5;
            this.block.Location = new System.Drawing.Point(1, 382);
            this.block.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.block.Name = "block";
            this.block.Size = new System.Drawing.Size(645, 39);
            this.block.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.block.TabIndex = 1;
            this.block.TabStop = false;
            // 
            // healthBar
            // 
            this.healthBar.BackColor = System.Drawing.Color.Honeydew;
            this.healthBar.ForeColor = System.Drawing.Color.OrangeRed;
            this.healthBar.Location = new System.Drawing.Point(168, 18);
            this.healthBar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.healthBar.Name = "healthBar";
            this.healthBar.Size = new System.Drawing.Size(181, 28);
            this.healthBar.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Font = new System.Drawing.Font("Old English Text MT", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(9, 5);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 53);
            this.label1.TabIndex = 3;
            this.label1.Text = "Health";
            // 
            // portal
            // 
            this.portal.Image = global::Game_platformer5.Properties.Resources.portal;
            this.portal.Location = new System.Drawing.Point(24, 287);
            this.portal.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.portal.Name = "portal";
            this.portal.Size = new System.Drawing.Size(85, 94);
            this.portal.TabIndex = 4;
            this.portal.TabStop = false;
            // 
            // obelisk
            // 
            this.obelisk.Image = global::Game_platformer5.Properties.Resources.Obelisk;
            this.obelisk.Location = new System.Drawing.Point(1233, 212);
            this.obelisk.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.obelisk.Name = "obelisk";
            this.obelisk.Size = new System.Drawing.Size(80, 132);
            this.obelisk.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.obelisk.TabIndex = 5;
            this.obelisk.TabStop = false;
            // 
            // block3
            // 
            this.block3.Image = global::Game_platformer5.Properties.Resources.block5;
            this.block3.Location = new System.Drawing.Point(1039, 341);
            this.block3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.block3.Name = "block3";
            this.block3.Size = new System.Drawing.Size(321, 39);
            this.block3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.block3.TabIndex = 6;
            this.block3.TabStop = false;
            // 
            // block1
            // 
            this.block1.Image = global::Game_platformer5.Properties.Resources.block5;
            this.block1.Location = new System.Drawing.Point(743, 252);
            this.block1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.block1.Name = "block1";
            this.block1.Size = new System.Drawing.Size(163, 34);
            this.block1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.block1.TabIndex = 7;
            this.block1.TabStop = false;
            // 
            // block2
            // 
            this.block2.Image = global::Game_platformer5.Properties.Resources.block5;
            this.block2.Location = new System.Drawing.Point(388, 148);
            this.block2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.block2.Name = "block2";
            this.block2.Size = new System.Drawing.Size(240, 34);
            this.block2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.block2.TabIndex = 8;
            this.block2.TabStop = false;
            // 
            // enemy
            // 
            this.enemy.Image = global::Game_platformer5.Properties.Resources.hell_beast_idle;
            this.enemy.Location = new System.Drawing.Point(459, 299);
            this.enemy.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.enemy.Name = "enemy";
            this.enemy.Size = new System.Drawing.Size(132, 89);
            this.enemy.TabIndex = 9;
            this.enemy.TabStop = false;
            // 
            // portalToNextLevel
            // 
            this.portalToNextLevel.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.portalToNextLevel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.portalToNextLevel.Image = global::Game_platformer5.Properties.Resources.spr_portal1;
            this.portalToNextLevel.Location = new System.Drawing.Point(419, 5);
            this.portalToNextLevel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.portalToNextLevel.Name = "portalToNextLevel";
            this.portalToNextLevel.Size = new System.Drawing.Size(109, 164);
            this.portalToNextLevel.TabIndex = 10;
            this.portalToNextLevel.TabStop = false;
            // 
            // health
            // 
            this.health.Image = global::Game_platformer5.Properties.Resources.health1;
            this.health.Location = new System.Drawing.Point(281, 325);
            this.health.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.health.Name = "health";
            this.health.Size = new System.Drawing.Size(43, 55);
            this.health.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.health.TabIndex = 11;
            this.health.TabStop = false;
            // 
            // Level1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Game_platformer5.Properties.Resources.background1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1419, 422);
            this.Controls.Add(this.block2);
            this.Controls.Add(this.block3);
            this.Controls.Add(this.block1);
            this.Controls.Add(this.block);
            this.Controls.Add(this.player);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.healthBar);
            this.Controls.Add(this.obelisk);
            this.Controls.Add(this.enemy);
            this.Controls.Add(this.portalToNextLevel);
            this.Controls.Add(this.health);
            this.Controls.Add(this.portal);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Level1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Level1_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.player)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.block)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.portal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.obelisk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.block3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.block1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.block2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.enemy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.portalToNextLevel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.health)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox player;
        private System.Windows.Forms.PictureBox block;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox portal;
        private System.Windows.Forms.PictureBox obelisk;
        private System.Windows.Forms.PictureBox block3;
        private System.Windows.Forms.PictureBox block1;
        private System.Windows.Forms.PictureBox block2;
        private System.Windows.Forms.PictureBox enemy;
        private System.Windows.Forms.PictureBox health;
        public System.Windows.Forms.ProgressBar healthBar;
        public System.Windows.Forms.PictureBox portalToNextLevel;
    }
}

