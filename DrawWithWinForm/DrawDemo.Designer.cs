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
            btnClose = new Button();
            chkboxShapes = new CheckedListBox();
            btnAddText = new Button();
            txtAdd = new TextBox();
            SuspendLayout();
            // 
            // btnStartStop
            // 
            btnStartStop.BackColor = Color.FromArgb(255, 128, 0);
            btnStartStop.FlatStyle = FlatStyle.Flat;
            btnStartStop.Location = new Point(12, 12);
            btnStartStop.Name = "btnStartStop";
            btnStartStop.Size = new Size(105, 29);
            btnStartStop.TabIndex = 0;
            btnStartStop.Text = "Start";
            btnStartStop.UseVisualStyleBackColor = false;
            btnStartStop.Click += btnStartStop_Click;
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnClose.BackColor = Color.FromArgb(255, 128, 0);
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Location = new Point(683, 12);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(105, 29);
            btnClose.TabIndex = 1;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            // 
            // chkboxShapes
            // 
            chkboxShapes.BackColor = Color.FromArgb(255, 128, 0);
            chkboxShapes.CausesValidation = false;
            chkboxShapes.FormattingEnabled = true;
            chkboxShapes.Items.AddRange(new object[] { "Rectangle", "Triangle", "Ellipse", "Text" });
            chkboxShapes.Location = new Point(12, 47);
            chkboxShapes.Name = "chkboxShapes";
            chkboxShapes.Size = new Size(105, 92);
            chkboxShapes.TabIndex = 2;
            // 
            // btnAddText
            // 
            btnAddText.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnAddText.BackColor = Color.FromArgb(255, 128, 0);
            btnAddText.FlatStyle = FlatStyle.Flat;
            btnAddText.Location = new Point(683, 411);
            btnAddText.Name = "btnAddText";
            btnAddText.Size = new Size(105, 29);
            btnAddText.TabIndex = 3;
            btnAddText.Text = "Add Text";
            btnAddText.UseVisualStyleBackColor = false;
            btnAddText.Click += btnAddText_Click;
            // 
            // txtAdd
            // 
            txtAdd.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtAdd.BackColor = Color.FromArgb(255, 128, 0);
            txtAdd.Location = new Point(12, 413);
            txtAdd.Name = "txtAdd";
            txtAdd.Size = new Size(665, 27);
            txtAdd.TabIndex = 4;
            txtAdd.KeyDown += txtAdd_KeyDown;
            // 
            // DrawDemo
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(800, 450);
            ControlBox = false;
            Controls.Add(txtAdd);
            Controls.Add(btnAddText);
            Controls.Add(chkboxShapes);
            Controls.Add(btnClose);
            Controls.Add(btnStartStop);
            Name = "DrawDemo";
            ShowIcon = false;
            ShowInTaskbar = false;
            Text = "DrawDemo";
            WindowState = FormWindowState.Maximized;
            FormClosing += DrawDemo_FormClosing;
            KeyDown += DrawDemo_KeyDown;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnStartStop;
        private Button btnClose;
        private CheckedListBox chkboxShapes;
        private Button btnAddText;
        private TextBox txtAdd;
    }
}