namespace ReviewGameGraderAverager
{
    partial class DigitalReviewGameGradeAverager
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.DragAndDropFilesBox = new System.Windows.Forms.ListBox();
            this.CreateNewDataButton = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.DownloadData = new System.Windows.Forms.Button();
            this.OutputFileName = new System.Windows.Forms.TextBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.numQuestionThreshold = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.contextMenuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(680, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Drag and Drop CSV files from Blooket or Gimkit, Ensure students have used the exa" +
    "ct same username in each file. Letter Case does not matter.";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(344, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "EnterThe Desired Name of the output file, ie. Period2Week10WarmUps";
            // 
            // DragAndDropFilesBox
            // 
            this.DragAndDropFilesBox.AllowDrop = true;
            this.DragAndDropFilesBox.ContextMenuStrip = this.contextMenuStrip2;
            this.DragAndDropFilesBox.FormattingEnabled = true;
            this.DragAndDropFilesBox.Location = new System.Drawing.Point(4, 75);
            this.DragAndDropFilesBox.Name = "DragAndDropFilesBox";
            this.DragAndDropFilesBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.DragAndDropFilesBox.Size = new System.Drawing.Size(745, 95);
            this.DragAndDropFilesBox.TabIndex = 2;
            this.DragAndDropFilesBox.SelectedIndexChanged += new System.EventHandler(this.DragAndDropFilesBox_SelectedIndexChanged);
            this.DragAndDropFilesBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DragAndDropFilesBox_KeyDown_1);
            // 
            // CreateNewDataButton
            // 
            this.CreateNewDataButton.Location = new System.Drawing.Point(570, 179);
            this.CreateNewDataButton.Name = "CreateNewDataButton";
            this.CreateNewDataButton.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.CreateNewDataButton.Size = new System.Drawing.Size(112, 43);
            this.CreateNewDataButton.TabIndex = 3;
            this.CreateNewDataButton.Text = "Create File";
            this.CreateNewDataButton.UseVisualStyleBackColor = true;
            this.CreateNewDataButton.Click += new System.EventHandler(this.CreateNewDataButton_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 255);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(737, 555);
            this.dataGridView1.TabIndex = 4;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // DownloadData
            // 
            this.DownloadData.Location = new System.Drawing.Point(321, 816);
            this.DownloadData.Name = "DownloadData";
            this.DownloadData.Size = new System.Drawing.Size(108, 23);
            this.DownloadData.TabIndex = 5;
            this.DownloadData.Text = "Download Data";
            this.DownloadData.UseVisualStyleBackColor = true;
            this.DownloadData.Click += new System.EventHandler(this.DownloadData_Click);
            // 
            // OutputFileName
            // 
            this.OutputFileName.Location = new System.Drawing.Point(4, 25);
            this.OutputFileName.Name = "OutputFileName";
            this.OutputFileName.Size = new System.Drawing.Size(341, 20);
            this.OutputFileName.TabIndex = 6;
            this.OutputFileName.TextChanged += new System.EventHandler(this.OutputFileName_TextChanged);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(12, 192);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(120, 20);
            this.numericUpDown1.TabIndex = 7;
            this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numQuestionThreshold
            // 
            this.numQuestionThreshold.AutoSize = true;
            this.numQuestionThreshold.Location = new System.Drawing.Point(9, 173);
            this.numQuestionThreshold.Name = "numQuestionThreshold";
            this.numQuestionThreshold.Size = new System.Drawing.Size(487, 13);
            this.numQuestionThreshold.TabIndex = 8;
            this.numQuestionThreshold.Text = "Please, Enter the munimum number of questions the student is required to answer t" +
    "o receive full credit.";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteToolStripMenuItem});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(108, 26);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click_1);
            // 
            // DigitalReviewGameGradeAverager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(797, 860);
            this.Controls.Add(this.numQuestionThreshold);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.OutputFileName);
            this.Controls.Add(this.DownloadData);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.CreateNewDataButton);
            this.Controls.Add(this.DragAndDropFilesBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "DigitalReviewGameGradeAverager";
            this.Text = "Digital Review Game Grade Averager";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.contextMenuStrip2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox DragAndDropFilesBox;
        private System.Windows.Forms.Button CreateNewDataButton;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button DownloadData;
        private System.Windows.Forms.TextBox OutputFileName;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label numQuestionThreshold;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
    }
}

