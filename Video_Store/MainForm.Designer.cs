namespace Video_Store
{
    partial class MainForm
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
            treeView = new TreeView();
            dataGridView = new DataGridView();
            buttonLoad = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();
            // 
            // treeView
            // 
            treeView.Location = new Point(12, 12);
            treeView.Name = "treeView";
            treeView.Size = new Size(196, 412);
            treeView.TabIndex = 0;
            treeView.AfterSelect += treeView_AfterSelect;
            // 
            // dataGridView
            // 
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Location = new Point(233, 12);
            dataGridView.Name = "dataGridView";
            dataGridView.RowHeadersWidth = 51;
            dataGridView.Size = new Size(543, 372);
            dataGridView.TabIndex = 1;
            // 
            // buttonLoad
            // 
            buttonLoad.Location = new Point(466, 402);
            buttonLoad.Name = "buttonLoad";
            buttonLoad.Size = new Size(94, 29);
            buttonLoad.TabIndex = 2;
            buttonLoad.Text = "Загрузить";
            buttonLoad.UseVisualStyleBackColor = true;
            buttonLoad.Click += buttonLoad_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(buttonLoad);
            Controls.Add(dataGridView);
            Controls.Add(treeView);
            Name = "MainForm";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TreeView treeView;
        private DataGridView dataGridView;
        private Button buttonLoad;
    }
}
