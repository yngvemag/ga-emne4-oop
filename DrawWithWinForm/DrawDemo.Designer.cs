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
            chkboxPolygon = new CheckBox();
            chkboxVector = new CheckBox();
            chkboxCollision = new CheckBox();
            chkboxShowCircumference = new CheckBox();
            chkboxShowArea = new CheckBox();
            chkboxText = new CheckBox();
            chkboxEllipse = new CheckBox();
            hscrollArea = new HScrollBar();
            hscrollCircumference = new HScrollBar();
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
            txtAdd.BackColor = Color.FromArgb(255, 255, 192);
            txtAdd.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            txtAdd.ForeColor = Color.Black;
            txtAdd.Location = new Point(3, 51);
            txtAdd.Name = "txtAdd";
            txtAdd.Size = new Size(752, 43);
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
            drawPanel.Size = new Size(1270, 550);
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
            panel1.Controls.Add(chkboxPolygon);
            panel1.Controls.Add(chkboxVector);
            panel1.Controls.Add(chkboxCollision);
            panel1.Controls.Add(chkboxShowCircumference);
            panel1.Controls.Add(chkboxShowArea);
            panel1.Controls.Add(chkboxText);
            panel1.Controls.Add(chkboxEllipse);
            panel1.Controls.Add(chkboxRectangle);
            panel1.Controls.Add(chkboxTriangle);
            panel1.Location = new Point(109, 7);
            panel1.Name = "panel1";
            panel1.Size = new Size(1164, 41);
            panel1.TabIndex = 8;
            // 
            // chkboxPolygon
            // 
            chkboxPolygon.AutoSize = true;
            chkboxPolygon.BackColor = Color.FromArgb(255, 128, 0);
            chkboxPolygon.ForeColor = Color.Black;
            chkboxPolygon.Location = new Point(402, 9);
            chkboxPolygon.Name = "chkboxPolygon";
            chkboxPolygon.Size = new Size(90, 24);
            chkboxPolygon.TabIndex = 13;
            chkboxPolygon.Text = "Polygons";
            chkboxPolygon.UseVisualStyleBackColor = false;
            // 
            // chkboxVector
            // 
            chkboxVector.AutoSize = true;
            chkboxVector.BackColor = Color.FromArgb(255, 128, 0);
            chkboxVector.ForeColor = Color.Black;
            chkboxVector.Location = new Point(290, 9);
            chkboxVector.Name = "chkboxVector";
            chkboxVector.Size = new Size(106, 24);
            chkboxVector.TabIndex = 12;
            chkboxVector.Text = "VectorLines";
            chkboxVector.UseVisualStyleBackColor = false;
            // 
            // chkboxCollision
            // 
            chkboxCollision.AutoSize = true;
            chkboxCollision.BackColor = Color.FromArgb(255, 128, 0);
            chkboxCollision.ForeColor = Color.Black;
            chkboxCollision.Location = new Point(609, 9);
            chkboxCollision.Name = "chkboxCollision";
            chkboxCollision.Size = new Size(88, 24);
            chkboxCollision.TabIndex = 11;
            chkboxCollision.Text = "Collision";
            chkboxCollision.UseVisualStyleBackColor = false;
            // 
            // chkboxShowCircumference
            // 
            chkboxShowCircumference.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            chkboxShowCircumference.AutoSize = true;
            chkboxShowCircumference.BackColor = Color.FromArgb(255, 128, 0);
            chkboxShowCircumference.ForeColor = Color.Black;
            chkboxShowCircumference.Location = new Point(990, 9);
            chkboxShowCircumference.Name = "chkboxShowCircumference";
            chkboxShowCircumference.RightToLeft = RightToLeft.Yes;
            chkboxShowCircumference.Size = new Size(166, 24);
            chkboxShowCircumference.TabIndex = 10;
            chkboxShowCircumference.Text = "Show Circumference";
            chkboxShowCircumference.UseVisualStyleBackColor = false;
            // 
            // chkboxShowArea
            // 
            chkboxShowArea.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            chkboxShowArea.AutoSize = true;
            chkboxShowArea.BackColor = Color.FromArgb(255, 128, 0);
            chkboxShowArea.ForeColor = Color.Black;
            chkboxShowArea.Location = new Point(809, 9);
            chkboxShowArea.Name = "chkboxShowArea";
            chkboxShowArea.RightToLeft = RightToLeft.Yes;
            chkboxShowArea.Size = new Size(102, 24);
            chkboxShowArea.TabIndex = 7;
            chkboxShowArea.Text = "Show Area";
            chkboxShowArea.UseVisualStyleBackColor = false;
            // 
            // chkboxText
            // 
            chkboxText.AutoSize = true;
            chkboxText.BackColor = Color.FromArgb(255, 128, 0);
            chkboxText.ForeColor = Color.Black;
            chkboxText.Location = new Point(507, 9);
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
            chkboxEllipse.Size = new Size(68, 24);
            chkboxEllipse.TabIndex = 8;
            chkboxEllipse.Text = "Circle";
            chkboxEllipse.UseVisualStyleBackColor = false;
            // 
            // hscrollArea
            // 
            hscrollArea.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            hscrollArea.Location = new Point(760, 51);
            hscrollArea.Name = "hscrollArea";
            hscrollArea.Size = new Size(260, 43);
            hscrollArea.TabIndex = 9;
            // 
            // hscrollCircumference
            // 
            hscrollCircumference.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            hscrollCircumference.Location = new Point(1027, 51);
            hscrollCircumference.Name = "hscrollCircumference";
            hscrollCircumference.Size = new Size(245, 43);
            hscrollCircumference.TabIndex = 10;
            // 
            // DrawDemo
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            BackgroundImageLayout = ImageLayout.None;
            ClientSize = new Size(1277, 650);
            Controls.Add(hscrollCircumference);
            Controls.Add(hscrollArea);
            Controls.Add(txtAdd);
            Controls.Add(panel1);
            Controls.Add(drawPanel);
            Controls.Add(btnStartStop);
            FormBorderStyle = FormBorderStyle.SizableToolWindow;
            KeyPreview = true;
            Name = "DrawDemo";
            ShowIcon = false;
            ShowInTaskbar = false;
            Text = "Draw Shapes Demo";
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
        private CheckBox chkboxShowCircumference;
        private CheckBox chkboxShowArea;
        private HScrollBar hscrollArea;
        private HScrollBar hscrollCircumference;
        private CheckBox chkboxCollision;
        private CheckBox chkboxVector;
        private CheckBox chkboxPolygon;
    }
}