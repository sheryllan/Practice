namespace PFS_PAA_Analysis
{
    partial class Form1
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
            this.openFileBtn = new System.Windows.Forms.Button();
            this.fileName = new System.Windows.Forms.Label();
            this.dataGrid = new System.Windows.Forms.DataGridView();
            this.dataGrid2 = new System.Windows.Forms.DataGridView();
            this.exportFile = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileBtn
            // 
            this.openFileBtn.Location = new System.Drawing.Point(33, 26);
            this.openFileBtn.Name = "openFileBtn";
            this.openFileBtn.Size = new System.Drawing.Size(75, 23);
            this.openFileBtn.TabIndex = 0;
            this.openFileBtn.Text = "Open file";
            this.openFileBtn.UseVisualStyleBackColor = true;
            this.openFileBtn.Click += new System.EventHandler(this.openFile_Click);
            // 
            // fileName
            // 
            this.fileName.AutoSize = true;
            this.fileName.Location = new System.Drawing.Point(128, 31);
            this.fileName.Name = "fileName";
            this.fileName.Size = new System.Drawing.Size(49, 13);
            this.fileName.TabIndex = 1;
            this.fileName.Text = "file name";
            // 
            // dataGrid
            // 
            this.dataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid.Location = new System.Drawing.Point(12, 86);
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.Size = new System.Drawing.Size(1046, 416);
            this.dataGrid.TabIndex = 2;
            // 
            // dataGrid2
            // 
            this.dataGrid2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid2.Location = new System.Drawing.Point(12, 508);
            this.dataGrid2.Name = "dataGrid2";
            this.dataGrid2.Size = new System.Drawing.Size(1045, 513);
            this.dataGrid2.TabIndex = 3;
            // 
            // exportFile
            // 
            this.exportFile.Location = new System.Drawing.Point(33, 58);
            this.exportFile.Name = "exportFile";
            this.exportFile.Size = new System.Drawing.Size(74, 22);
            this.exportFile.TabIndex = 4;
            this.exportFile.Text = "Exort";
            this.exportFile.UseVisualStyleBackColor = true;
            this.exportFile.Click += new System.EventHandler(this.exportFile_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1070, 784);
            this.Controls.Add(this.exportFile);
            this.Controls.Add(this.dataGrid2);
            this.Controls.Add(this.dataGrid);
            this.Controls.Add(this.fileName);
            this.Controls.Add(this.openFileBtn);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button openFileBtn;
        private System.Windows.Forms.Label fileName;
        private System.Windows.Forms.DataGridView dataGrid;
        private System.Windows.Forms.DataGridView dataGrid2;
        private System.Windows.Forms.Button exportFile;
    }
}

