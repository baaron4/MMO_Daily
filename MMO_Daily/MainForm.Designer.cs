namespace MMO_Daily
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button_Import = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.textBox_CSVFilePath = new System.Windows.Forms.TextBox();
            this.checkBox_AutoLoad = new System.Windows.Forms.CheckBox();
            this.checkBox_AutoLoadDB = new System.Windows.Forms.CheckBox();
            this.textBox_DBCSV = new System.Windows.Forms.TextBox();
            this.button_SetDBCSV = new System.Windows.Forms.Button();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.button_OpenDBCSV = new System.Windows.Forms.Button();
            this.button_OpenCSV = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Location = new System.Drawing.Point(12, 24);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(1398, 929);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // button_Import
            // 
            this.button_Import.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Import.Location = new System.Drawing.Point(1105, 999);
            this.button_Import.Name = "button_Import";
            this.button_Import.Size = new System.Drawing.Size(181, 34);
            this.button_Import.TabIndex = 1;
            this.button_Import.Text = "Import CSV";
            this.button_Import.UseVisualStyleBackColor = true;
            this.button_Import.Click += new System.EventHandler(this.button_Import_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // textBox_CSVFilePath
            // 
            this.textBox_CSVFilePath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_CSVFilePath.Location = new System.Drawing.Point(12, 1003);
            this.textBox_CSVFilePath.Name = "textBox_CSVFilePath";
            this.textBox_CSVFilePath.Size = new System.Drawing.Size(912, 26);
            this.textBox_CSVFilePath.TabIndex = 2;
            // 
            // checkBox_AutoLoad
            // 
            this.checkBox_AutoLoad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox_AutoLoad.AutoSize = true;
            this.checkBox_AutoLoad.Location = new System.Drawing.Point(930, 1003);
            this.checkBox_AutoLoad.Name = "checkBox_AutoLoad";
            this.checkBox_AutoLoad.Size = new System.Drawing.Size(142, 24);
            this.checkBox_AutoLoad.TabIndex = 3;
            this.checkBox_AutoLoad.Text = "AutoLoad CSV";
            this.checkBox_AutoLoad.UseVisualStyleBackColor = true;
            this.checkBox_AutoLoad.CheckedChanged += new System.EventHandler(this.checkBox_AutoLoad_CheckedChanged);
            // 
            // checkBox_AutoLoadDB
            // 
            this.checkBox_AutoLoadDB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox_AutoLoadDB.AutoSize = true;
            this.checkBox_AutoLoadDB.Location = new System.Drawing.Point(930, 961);
            this.checkBox_AutoLoadDB.Name = "checkBox_AutoLoadDB";
            this.checkBox_AutoLoadDB.Size = new System.Drawing.Size(169, 24);
            this.checkBox_AutoLoadDB.TabIndex = 6;
            this.checkBox_AutoLoadDB.Text = "AutoLoad DB CSV";
            this.checkBox_AutoLoadDB.UseVisualStyleBackColor = true;
            this.checkBox_AutoLoadDB.CheckedChanged += new System.EventHandler(this.checkBox_AutoLoadDB_CheckedChanged);
            // 
            // textBox_DBCSV
            // 
            this.textBox_DBCSV.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_DBCSV.Location = new System.Drawing.Point(12, 959);
            this.textBox_DBCSV.Name = "textBox_DBCSV";
            this.textBox_DBCSV.Size = new System.Drawing.Size(912, 26);
            this.textBox_DBCSV.TabIndex = 5;
            // 
            // button_SetDBCSV
            // 
            this.button_SetDBCSV.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_SetDBCSV.Location = new System.Drawing.Point(1105, 955);
            this.button_SetDBCSV.Name = "button_SetDBCSV";
            this.button_SetDBCSV.Size = new System.Drawing.Size(181, 34);
            this.button_SetDBCSV.TabIndex = 4;
            this.button_SetDBCSV.Text = "Set DB CSV";
            this.button_SetDBCSV.UseVisualStyleBackColor = true;
            this.button_SetDBCSV.Click += new System.EventHandler(this.button_SetDBCSV_Click);
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.FileName = "openFileDialog2";
            // 
            // button_OpenDBCSV
            // 
            this.button_OpenDBCSV.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_OpenDBCSV.Location = new System.Drawing.Point(1292, 957);
            this.button_OpenDBCSV.Name = "button_OpenDBCSV";
            this.button_OpenDBCSV.Size = new System.Drawing.Size(132, 34);
            this.button_OpenDBCSV.TabIndex = 8;
            this.button_OpenDBCSV.Text = "Open DB";
            this.button_OpenDBCSV.UseVisualStyleBackColor = true;
            this.button_OpenDBCSV.Click += new System.EventHandler(this.button_OpenDBCSV_Click);
            // 
            // button_OpenCSV
            // 
            this.button_OpenCSV.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_OpenCSV.Location = new System.Drawing.Point(1292, 1001);
            this.button_OpenCSV.Name = "button_OpenCSV";
            this.button_OpenCSV.Size = new System.Drawing.Size(132, 34);
            this.button_OpenCSV.TabIndex = 7;
            this.button_OpenCSV.Text = "Open CSV";
            this.button_OpenCSV.UseVisualStyleBackColor = true;
            this.button_OpenCSV.Click += new System.EventHandler(this.button_OpenCSV_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1436, 1047);
            this.Controls.Add(this.button_OpenDBCSV);
            this.Controls.Add(this.button_OpenCSV);
            this.Controls.Add(this.checkBox_AutoLoadDB);
            this.Controls.Add(this.textBox_DBCSV);
            this.Controls.Add(this.button_SetDBCSV);
            this.Controls.Add(this.checkBox_AutoLoad);
            this.Controls.Add(this.textBox_CSVFilePath);
            this.Controls.Add(this.button_Import);
            this.Controls.Add(this.dataGridView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "MMO Daily";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button_Import;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox textBox_CSVFilePath;
        private System.Windows.Forms.CheckBox checkBox_AutoLoad;
        private System.Windows.Forms.CheckBox checkBox_AutoLoadDB;
        private System.Windows.Forms.TextBox textBox_DBCSV;
        private System.Windows.Forms.Button button_SetDBCSV;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
        private System.Windows.Forms.Button button_OpenDBCSV;
        private System.Windows.Forms.Button button_OpenCSV;
    }
}

