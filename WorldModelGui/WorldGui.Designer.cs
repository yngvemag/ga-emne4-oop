namespace WorldModelGui
{
    partial class WorldGui
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
            treeViewWorld = new TreeView();
            txtCountryFilter = new TextBox();
            label1 = new Label();
            SuspendLayout();
            // 
            // treeViewWorld
            // 
            treeViewWorld.Location = new Point(3, 38);
            treeViewWorld.Name = "treeViewWorld";
            treeViewWorld.Size = new Size(571, 632);
            treeViewWorld.TabIndex = 0;
            // 
            // txtCountryFilter
            // 
            txtCountryFilter.Location = new Point(106, 5);
            txtCountryFilter.Name = "txtCountryFilter";
            txtCountryFilter.Size = new Size(468, 27);
            txtCountryFilter.TabIndex = 2;
            txtCountryFilter.TextChanged += txtCountryFilter_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 8);
            label1.Name = "label1";
            label1.Size = new Size(97, 20);
            label1.TabIndex = 3;
            label1.Text = "Country Filter";
            // 
            // WorldGui
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(579, 682);
            Controls.Add(label1);
            Controls.Add(txtCountryFilter);
            Controls.Add(treeViewWorld);
            Name = "WorldGui";
            Text = "World View";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TreeView treeViewWorld;
        private TextBox txtCountryFilter;
        private Label label1;
    }
}