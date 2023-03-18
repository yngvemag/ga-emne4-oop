using DrawWithWinForm.Controls;

namespace DrawWithWinForm
{
    partial class DrawDemo
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
            btnStartStop = new Button();
            txtAdd = new TextBox();
            drawPanel = new DrawPanel();
            chkboxRectangle = new CheckBox();
            chkboxTriangle = new CheckBox();
            panel1 = new Panel();
            chkboxText = new CheckBox();
            chkboxEllipse = new CheckBox();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // btnStartStop
            // 
            btnStartStop.BackColor = Color.FromArgb(255, 128, 0);
            btnStartStop.FlatStyle = FlatStyle.Flat;
            btnStartStop.Location = new Point(3, 7);
            btnStartStop.Name = "btnStartStop";
            btnStartStop.Size = new Size(100, 41);
            btnStartStop.TabIndex = 0;
            btnStartStop.Text = "Start";
            btnStartStop.UseVisualStyleBackColor = false;
            btnStartStop.Click += btnStartStop_Click;
            // 
            // txtAdd
            // 
            txtAdd.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtAdd.BackColor = Color.FromArgb(255, 128, 0);
            txtAdd.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            txtAdd.ForeColor = SystemColors.Window;
            txtAdd.Location = new Point(3, 51);
            txtAdd.Name = "txtAdd";
            txtAdd.Size = new Size(1047, 43);
            txtAdd.TabIndex = 4;
            txtAdd.KeyDown += txtAdd_KeyDown;
            // 
            // drawPanel
            // 
            drawPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            drawPanel.BackColor = Color.Black;
            drawPanel.DoubleBuffered = false;
            drawPanel.Location = new Point(3, 97);
            drawPanel.Name = "drawPanel";
            drawPanel.Size = new Size(1047, 550);
            drawPanel.TabIndex = 5;
            // 
            // chkboxRectangle
            // 
            chkboxRectangle.AutoSize = true;
            chkboxRectangle.BackColor = Color.FromArgb(255, 128, 0);
            chkboxRectangle.ForeColor = Color.Black;
            chkboxRectangle.Location = new Point(14, 9);
            chkboxRectangle.Name = "chkboxRectangle";
            chkboxRectangle.Size = new Size(97, 24);
            chkboxRectangle.TabIndex = 6;
            chkboxRectangle.Text = "Rectangle";
            chkboxRectangle.UseVisualStyleBackColor = false;
            // 
            // chkboxTriangle
            // 
            chkboxTriangle.AutoSize = true;
            chkboxTriangle.BackColor = Color.FromArgb(255, 128, 0);
            chkboxTriangle.ForeColor = Color.Black;
            chkboxTriangle.Location = new Point(117, 9);
            chkboxTriangle.Name = "chkboxTriangle";
            chkboxTriangle.Size = new Size(84, 24);
            chkboxTriangle.TabIndex = 7;
            chkboxTriangle.Text = "Triangle";
            chkboxTriangle.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = Color.FromArgb(255, 128, 0);
            panel1.Controls.Add(chkboxText);
            panel1.Controls.Add(chkboxEllipse);
            panel1.Controls.Add(chkboxRectangle);
            panel1.Controls.Add(chkboxTriangle);
            panel1.Location = new Point(109, 7);
            panel1.Name = "panel1";
            panel1.Size = new Size(941, 41);
            panel1.TabIndex = 8;
            // 
            // chkboxText
            // 
            chkboxText.AutoSize = true;
            chkboxText.BackColor = Color.FromArgb(255, 128, 0);
            chkboxText.ForeColor = Color.Black;
            chkboxText.Location = new Point(297, 9);
            chkboxText.Name = "chkboxText";
            chkboxText.Size = new Size(58, 24);
            chkboxText.TabIndex = 9;
            chkboxText.Text = "Text";
            chkboxText.UseVisualStyleBackColor = false;
            // 
            // chkboxEllipse
            // 
            chkboxEllipse.AutoSize = true;
            chkboxEllipse.BackColor = Color.FromArgb(255, 128, 0);
            chkboxEllipse.ForeColor = Color.Black;
            chkboxEllipse.Location = new Point(207, 9);
            chkboxEllipse.Name = "chkboxEllipse";
            chkboxEllipse.Size = new Size(74, 24);
            chkboxEllipse.TabIndex = 8;
            chkboxEllipse.Text = "Ellipse";
            chkboxEllipse.UseVisualStyleBackColor = false;
            // 
            // DrawDemo
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Navy;
            ClientSize = new Size(1054, 650);
            Controls.Add(txtAdd);
            Controls.Add(panel1);
            Controls.Add(drawPanel);
            Controls.Add(btnStartStop);
            Name = "DrawDemo";
            ShowIcon = false;
            ShowInTaskbar = false;
            Text = "DrawDemo";
            FormClosing += DrawDemo_FormClosing;
            KeyDown += DrawDemo_KeyDown;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnStartStop;
        private TextBox txtAdd;
        private DrawPanel drawPanel;
        private CheckBox chkboxRectangle;
        private CheckBox chkboxTriangle;
        private Panel panel1;
        private CheckBox chkboxText;
        private CheckBox chkboxEllipse;
    }
}