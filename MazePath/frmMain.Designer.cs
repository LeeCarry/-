namespace MazePath
{
    partial class frmMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.paMaze = new System.Windows.Forms.Panel();
            this.btnSetAll = new System.Windows.Forms.Button();
            this.btnEmptyAll = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.cmbAlgorithm = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // paMaze
            // 
            this.paMaze.Location = new System.Drawing.Point(12, 12);
            this.paMaze.Name = "paMaze";
            this.paMaze.Size = new System.Drawing.Size(501, 501);
            this.paMaze.TabIndex = 0;
            // 
            // btnSetAll
            // 
            this.btnSetAll.Location = new System.Drawing.Point(12, 519);
            this.btnSetAll.Name = "btnSetAll";
            this.btnSetAll.Size = new System.Drawing.Size(97, 23);
            this.btnSetAll.TabIndex = 1;
            this.btnSetAll.Text = "全部设为路障";
            this.btnSetAll.UseVisualStyleBackColor = true;
            this.btnSetAll.Click += new System.EventHandler(this.btnSetAll_Click);
            // 
            // btnEmptyAll
            // 
            this.btnEmptyAll.Location = new System.Drawing.Point(115, 519);
            this.btnEmptyAll.Name = "btnEmptyAll";
            this.btnEmptyAll.Size = new System.Drawing.Size(97, 23);
            this.btnEmptyAll.TabIndex = 2;
            this.btnEmptyAll.Text = "清空所有路障";
            this.btnEmptyAll.UseVisualStyleBackColor = true;
            this.btnEmptyAll.Click += new System.EventHandler(this.btnEmptyAll_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(443, 521);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(70, 23);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "搜索";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // cmbAlgorithm
            // 
            this.cmbAlgorithm.FormattingEnabled = true;
            this.cmbAlgorithm.Location = new System.Drawing.Point(268, 521);
            this.cmbAlgorithm.Name = "cmbAlgorithm";
            this.cmbAlgorithm.Size = new System.Drawing.Size(121, 20);
            this.cmbAlgorithm.TabIndex = 4;
            this.cmbAlgorithm.SelectedIndexChanged += new System.EventHandler(this.cmbAlgorithm_SelectedIndexChanged);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(528, 554);
            this.Controls.Add(this.cmbAlgorithm);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnEmptyAll);
            this.Controls.Add(this.btnSetAll);
            this.Controls.Add(this.paMaze);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMain";
            this.Text = "迷宫最短路径算法";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel paMaze;
        private System.Windows.Forms.Button btnSetAll;
        private System.Windows.Forms.Button btnEmptyAll;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ComboBox cmbAlgorithm;
    }
}

