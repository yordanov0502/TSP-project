
namespace zadanie1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.менюToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.въвежданеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.колиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.поръчкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.справкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.qryTotalOrdersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.изходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.менюToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // менюToolStripMenuItem
            // 
            this.менюToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.въвежданеToolStripMenuItem,
            this.справкиToolStripMenuItem,
            this.изходToolStripMenuItem});
            this.менюToolStripMenuItem.Name = "менюToolStripMenuItem";
            this.менюToolStripMenuItem.Size = new System.Drawing.Size(65, 24);
            this.менюToolStripMenuItem.Text = "Меню";
            // 
            // въвежданеToolStripMenuItem
            // 
            this.въвежданеToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.колиToolStripMenuItem,
            this.поръчкиToolStripMenuItem});
            this.въвежданеToolStripMenuItem.Name = "въвежданеToolStripMenuItem";
            this.въвежданеToolStripMenuItem.Size = new System.Drawing.Size(178, 26);
            this.въвежданеToolStripMenuItem.Text = "Въвеждане";
            this.въвежданеToolStripMenuItem.Click += new System.EventHandler(this.въвежданеToolStripMenuItem_Click);
            // 
            // колиToolStripMenuItem
            // 
            this.колиToolStripMenuItem.Name = "колиToolStripMenuItem";
            this.колиToolStripMenuItem.Size = new System.Drawing.Size(154, 26);
            this.колиToolStripMenuItem.Text = "Коли";
            this.колиToolStripMenuItem.Click += new System.EventHandler(this.колиToolStripMenuItem_Click);
            // 
            // поръчкиToolStripMenuItem
            // 
            this.поръчкиToolStripMenuItem.Name = "поръчкиToolStripMenuItem";
            this.поръчкиToolStripMenuItem.Size = new System.Drawing.Size(154, 26);
            this.поръчкиToolStripMenuItem.Text = "Поръчки";
            this.поръчкиToolStripMenuItem.Click += new System.EventHandler(this.поръчкиToolStripMenuItem_Click);
            // 
            // справкиToolStripMenuItem
            // 
            this.справкиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.qryTotalOrdersToolStripMenuItem});
            this.справкиToolStripMenuItem.Name = "справкиToolStripMenuItem";
            this.справкиToolStripMenuItem.Size = new System.Drawing.Size(178, 26);
            this.справкиToolStripMenuItem.Text = "Справки";
            // 
            // qryTotalOrdersToolStripMenuItem
            // 
            this.qryTotalOrdersToolStripMenuItem.Name = "qryTotalOrdersToolStripMenuItem";
            this.qryTotalOrdersToolStripMenuItem.Size = new System.Drawing.Size(190, 26);
            this.qryTotalOrdersToolStripMenuItem.Text = "qryTotalOrders";
            this.qryTotalOrdersToolStripMenuItem.Click += new System.EventHandler(this.qryTotalOrdersToolStripMenuItem_Click);
            // 
            // изходToolStripMenuItem
            // 
            this.изходToolStripMenuItem.Name = "изходToolStripMenuItem";
            this.изходToolStripMenuItem.Size = new System.Drawing.Size(178, 26);
            this.изходToolStripMenuItem.Text = "Изход";
            this.изходToolStripMenuItem.Click += new System.EventHandler(this.изходToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Начална страница";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem менюToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem въвежданеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem справкиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem изходToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem колиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem поръчкиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem qryTotalOrdersToolStripMenuItem;
    }
}

