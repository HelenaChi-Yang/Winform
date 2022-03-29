
namespace Combobox
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
            this.ReadingFile = new System.Windows.Forms.Button();
            this.StockSearch = new System.Windows.Forms.Button();
            this.StockOverboughtOrOversold = new System.Windows.Forms.Button();
            this.StockCombo = new System.Windows.Forms.ComboBox();
            this.ReadingMode = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.QueryTime = new System.Windows.Forms.TextBox();
            this.MainGridView = new System.Windows.Forms.DataGridView();
            this.DataGridViewDealDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StockQueryGridView = new System.Windows.Forms.DataGridView();
            this.fiftyGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.MainGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockQueryGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fiftyGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // ReadingFile
            // 
            this.ReadingFile.Location = new System.Drawing.Point(517, 22);
            this.ReadingFile.Margin = new System.Windows.Forms.Padding(4);
            this.ReadingFile.Name = "ReadingFile";
            this.ReadingFile.Size = new System.Drawing.Size(96, 29);
            this.ReadingFile.TabIndex = 4;
            this.ReadingFile.Text = "讀取檔案";
            this.ReadingFile.UseVisualStyleBackColor = true;
            this.ReadingFile.Click += new System.EventHandler(this.ReadingFile_Click);
            // 
            // StockSearch
            // 
            this.StockSearch.Location = new System.Drawing.Point(517, 68);
            this.StockSearch.Margin = new System.Windows.Forms.Padding(4);
            this.StockSearch.Name = "StockSearch";
            this.StockSearch.Size = new System.Drawing.Size(96, 29);
            this.StockSearch.TabIndex = 5;
            this.StockSearch.Text = "股票查詢";
            this.StockSearch.UseVisualStyleBackColor = true;
            this.StockSearch.Click += new System.EventHandler(this.StockSearch_Click);
            // 
            // StockOverboughtOrOversold
            // 
            this.StockOverboughtOrOversold.Location = new System.Drawing.Point(621, 68);
            this.StockOverboughtOrOversold.Margin = new System.Windows.Forms.Padding(4);
            this.StockOverboughtOrOversold.Name = "StockOverboughtOrOversold";
            this.StockOverboughtOrOversold.Size = new System.Drawing.Size(117, 29);
            this.StockOverboughtOrOversold.TabIndex = 6;
            this.StockOverboughtOrOversold.Text = "股票買賣超50";
            this.StockOverboughtOrOversold.UseVisualStyleBackColor = true;
            this.StockOverboughtOrOversold.Click += new System.EventHandler(this.StockOverboughtOrOversold_Click);
            // 
            // StockCombo
            // 
            this.StockCombo.FormattingEnabled = true;
            this.StockCombo.Location = new System.Drawing.Point(15, 68);
            this.StockCombo.Margin = new System.Windows.Forms.Padding(4);
            this.StockCombo.Name = "StockCombo";
            this.StockCombo.Size = new System.Drawing.Size(494, 27);
            this.StockCombo.TabIndex = 7;
            // 
            // ReadingMode
            // 
            this.ReadingMode.AutoSize = true;
            this.ReadingMode.Location = new System.Drawing.Point(643, 28);
            this.ReadingMode.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ReadingMode.Name = "ReadingMode";
            this.ReadingMode.Size = new System.Drawing.Size(69, 19);
            this.ReadingMode.TabIndex = 8;
            this.ReadingMode.Text = "讀取狀態";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(14, 22);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(494, 27);
            this.textBox1.TabIndex = 9;
            // 
            // QueryTime
            // 
            this.QueryTime.BackColor = System.Drawing.SystemColors.Window;
            this.QueryTime.Location = new System.Drawing.Point(750, 24);
            this.QueryTime.Margin = new System.Windows.Forms.Padding(4);
            this.QueryTime.Multiline = true;
            this.QueryTime.Name = "QueryTime";
            this.QueryTime.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.QueryTime.Size = new System.Drawing.Size(262, 72);
            this.QueryTime.TabIndex = 10;
            // 
            // MainGridView
            // 
            this.MainGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.MainGridView.Location = new System.Drawing.Point(14, 105);
            this.MainGridView.Margin = new System.Windows.Forms.Padding(4);
            this.MainGridView.Name = "MainGridView";
            this.MainGridView.RowHeadersWidth = 51;
            this.MainGridView.RowTemplate.Height = 25;
            this.MainGridView.Size = new System.Drawing.Size(723, 218);
            this.MainGridView.TabIndex = 11;
            // 
            // DataGridViewDealDate
            // 
            this.DataGridViewDealDate.HeaderText = "DealDate";
            this.DataGridViewDealDate.MinimumWidth = 6;
            this.DataGridViewDealDate.Name = "DataGridViewDealDate";
            this.DataGridViewDealDate.Width = 125;
            // 
            // StockQueryGridView
            // 
            this.StockQueryGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.StockQueryGridView.Location = new System.Drawing.Point(14, 331);
            this.StockQueryGridView.Margin = new System.Windows.Forms.Padding(4);
            this.StockQueryGridView.Name = "StockQueryGridView";
            this.StockQueryGridView.RowHeadersWidth = 51;
            this.StockQueryGridView.RowTemplate.Height = 25;
            this.StockQueryGridView.Size = new System.Drawing.Size(723, 224);
            this.StockQueryGridView.TabIndex = 12;
            // 
            // fiftyGridView
            // 
            this.fiftyGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.fiftyGridView.Location = new System.Drawing.Point(748, 105);
            this.fiftyGridView.Margin = new System.Windows.Forms.Padding(4);
            this.fiftyGridView.Name = "fiftyGridView";
            this.fiftyGridView.RowHeadersWidth = 51;
            this.fiftyGridView.RowTemplate.Height = 25;
            this.fiftyGridView.Size = new System.Drawing.Size(265, 448);
            this.fiftyGridView.TabIndex = 13;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1029, 570);
            this.Controls.Add(this.fiftyGridView);
            this.Controls.Add(this.StockQueryGridView);
            this.Controls.Add(this.MainGridView);
            this.Controls.Add(this.QueryTime);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.ReadingMode);
            this.Controls.Add(this.StockCombo);
            this.Controls.Add(this.StockOverboughtOrOversold);
            this.Controls.Add(this.StockSearch);
            this.Controls.Add(this.ReadingFile);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.MainGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockQueryGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fiftyGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button ReadingFile;
        private System.Windows.Forms.Button StockSearch;
        private System.Windows.Forms.Button StockOverboughtOrOversold;
        private System.Windows.Forms.ComboBox StockCombo;
        private System.Windows.Forms.Label ReadingMode;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox QueryTime;
        private System.Windows.Forms.DataGridView MainGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataGridViewDealDate;
        private System.Windows.Forms.DataGridView StockQueryGridView;
        private System.Windows.Forms.DataGridView fiftyGridView;
    }
}

