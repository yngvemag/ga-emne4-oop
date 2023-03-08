namespace SimpleCalculator
{
    partial class SimpleCalc
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
            btnSum = new Button();
            txtTallA = new TextBox();
            txtTallB = new TextBox();
            txtSum = new TextBox();
            button1 = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            lblWarningTallA = new Label();
            lblWarningTallB = new Label();
            grpboxCalc = new GroupBox();
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            openToolStripMenuItem = new ToolStripMenuItem();
            openFile = new OpenFileDialog();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // btnSum
            // 
            btnSum.Location = new Point(156, 189);
            btnSum.Name = "btnSum";
            btnSum.Size = new Size(125, 29);
            btnSum.TabIndex = 0;
            btnSum.Text = "Sum";
            btnSum.UseVisualStyleBackColor = true;
            btnSum.Click += btnSum_Click;
            // 
            // txtTallA
            // 
            txtTallA.Location = new Point(156, 93);
            txtTallA.Name = "txtTallA";
            txtTallA.Size = new Size(125, 27);
            txtTallA.TabIndex = 1;
            // 
            // txtTallB
            // 
            txtTallB.Location = new Point(156, 143);
            txtTallB.Name = "txtTallB";
            txtTallB.Size = new Size(125, 27);
            txtTallB.TabIndex = 2;
            // 
            // txtSum
            // 
            txtSum.Location = new Point(156, 224);
            txtSum.Name = "txtSum";
            txtSum.Size = new Size(125, 27);
            txtSum.TabIndex = 3;
            // 
            // button1
            // 
            button1.Location = new Point(191, 99);
            button1.Name = "button1";
            button1.Size = new Size(8, 8);
            button1.TabIndex = 4;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(41, 96);
            label1.Name = "label1";
            label1.Size = new Size(109, 20);
            label1.TabIndex = 5;
            label1.Text = "Skriv inn et tall:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(41, 146);
            label2.Name = "label2";
            label2.Size = new Size(109, 20);
            label2.TabIndex = 6;
            label2.Text = "Skriv inn et tall:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(41, 227);
            label3.Name = "label3";
            label3.Size = new Size(38, 20);
            label3.TabIndex = 7;
            label3.Text = "Sum";
            // 
            // lblWarningTallA
            // 
            lblWarningTallA.AutoSize = true;
            lblWarningTallA.ForeColor = Color.Red;
            lblWarningTallA.Location = new Point(306, 93);
            lblWarningTallA.Name = "lblWarningTallA";
            lblWarningTallA.Size = new Size(0, 20);
            lblWarningTallA.TabIndex = 8;
            // 
            // lblWarningTallB
            // 
            lblWarningTallB.AutoSize = true;
            lblWarningTallB.ForeColor = Color.Red;
            lblWarningTallB.Location = new Point(306, 146);
            lblWarningTallB.Name = "lblWarningTallB";
            lblWarningTallB.Size = new Size(0, 20);
            lblWarningTallB.TabIndex = 9;
            // 
            // grpboxCalc
            // 
            grpboxCalc.FlatStyle = FlatStyle.Popup;
            grpboxCalc.Location = new Point(25, 50);
            grpboxCalc.Name = "grpboxCalc";
            grpboxCalc.Size = new Size(511, 262);
            grpboxCalc.TabIndex = 10;
            grpboxCalc.TabStop = false;
            grpboxCalc.Text = "Regn Ut";
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(732, 28);
            menuStrip1.TabIndex = 11;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { openToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(46, 24);
            fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            openToolStripMenuItem.Name = "openToolStripMenuItem";
            openToolStripMenuItem.Size = new Size(224, 26);
            openToolStripMenuItem.Text = "Open";
            openToolStripMenuItem.Click += openToolStripMenuItem_Click;
            // 
            // openFile
            // 
            openFile.FileName = "openFile";
            // 
            // SimpleCalc
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(732, 424);
            Controls.Add(lblWarningTallB);
            Controls.Add(lblWarningTallA);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button1);
            Controls.Add(txtSum);
            Controls.Add(txtTallB);
            Controls.Add(txtTallA);
            Controls.Add(btnSum);
            Controls.Add(grpboxCalc);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "SimpleCalc";
            Text = "Simple Calculator";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnSum;
        private TextBox txtTallA;
        private TextBox txtTallB;
        private TextBox txtSum;
        private Button button1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label lblWarningTallA;
        private Label lblWarningTallB;
        private GroupBox grpboxCalc;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem openToolStripMenuItem;
        private OpenFileDialog openFile;
    }
}