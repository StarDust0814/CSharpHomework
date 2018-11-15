namespace homework8
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.findPanel = new System.Windows.Forms.Panel();
            this.findbutton = new System.Windows.Forms.Button();
            this.findComboBox = new System.Windows.Forms.ComboBox();
            this.textbox = new System.Windows.Forms.TextBox();
            this.dataPanel = new System.Windows.Forms.Panel();
            this.buttonPanel = new System.Windows.Forms.Panel();
            this.addbutton = new System.Windows.Forms.Button();
            this.changebutton = new System.Windows.Forms.Button();
            this.removebutton = new System.Windows.Forms.Button();
            this.exportbutton = new System.Windows.Forms.Button();
            this.importbutton = new System.Windows.Forms.Button();
            this.orderdatagridview = new System.Windows.Forms.DataGridView();
            this.orderPanel = new System.Windows.Forms.Panel();
            this.orderdetaildatagridview = new System.Windows.Forms.DataGridView();
            this.orderdetailbindingsource = new System.Windows.Forms.BindingSource(this.components);
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.goodIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.goodNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.goodNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.singlePriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orderbindingsource = new System.Windows.Forms.BindingSource(this.components);
            this.orderNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.guestNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sumDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.findPanel.SuspendLayout();
            this.dataPanel.SuspendLayout();
            this.buttonPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.orderdatagridview)).BeginInit();
            this.orderPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.orderdetaildatagridview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderdetailbindingsource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderbindingsource)).BeginInit();
            this.SuspendLayout();
            // 
            // findPanel
            // 
            this.findPanel.Controls.Add(this.textbox);
            this.findPanel.Controls.Add(this.findComboBox);
            this.findPanel.Controls.Add(this.findbutton);
            this.findPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.findPanel.Location = new System.Drawing.Point(0, 0);
            this.findPanel.Name = "findPanel";
            this.findPanel.Size = new System.Drawing.Size(838, 73);
            this.findPanel.TabIndex = 0;
            // 
            // findbutton
            // 
            this.findbutton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.findbutton.Location = new System.Drawing.Point(685, 29);
            this.findbutton.Name = "findbutton";
            this.findbutton.Size = new System.Drawing.Size(75, 23);
            this.findbutton.TabIndex = 1;
            this.findbutton.Text = "Findit";
            this.findbutton.UseVisualStyleBackColor = true;
            this.findbutton.Click += new System.EventHandler(this.findbutton_Click);
            // 
            // findComboBox
            // 
            this.findComboBox.FormattingEnabled = true;
            this.findComboBox.Items.AddRange(new object[] {
            "FindAll",
            "FindByGoodName",
            "FindByGuestName",
            "FindByOrderNumber",
            "FindBySum"});
            this.findComboBox.Location = new System.Drawing.Point(12, 27);
            this.findComboBox.Name = "findComboBox";
            this.findComboBox.Size = new System.Drawing.Size(243, 23);
            this.findComboBox.TabIndex = 2;
            // 
            // textbox
            // 
            this.textbox.Location = new System.Drawing.Point(292, 27);
            this.textbox.Name = "textbox";
            this.textbox.Size = new System.Drawing.Size(288, 25);
            this.textbox.TabIndex = 3;
            this.textbox.Text = "Please input what you want to find";
            // 
            // dataPanel
            // 
            this.dataPanel.Controls.Add(this.orderdetaildatagridview);
            this.dataPanel.Controls.Add(this.orderPanel);
            this.dataPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataPanel.Location = new System.Drawing.Point(0, 73);
            this.dataPanel.Name = "dataPanel";
            this.dataPanel.Size = new System.Drawing.Size(838, 335);
            this.dataPanel.TabIndex = 1;
            // 
            // buttonPanel
            // 
            this.buttonPanel.Controls.Add(this.importbutton);
            this.buttonPanel.Controls.Add(this.exportbutton);
            this.buttonPanel.Controls.Add(this.removebutton);
            this.buttonPanel.Controls.Add(this.changebutton);
            this.buttonPanel.Controls.Add(this.addbutton);
            this.buttonPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonPanel.Location = new System.Drawing.Point(0, 408);
            this.buttonPanel.Name = "buttonPanel";
            this.buttonPanel.Size = new System.Drawing.Size(838, 43);
            this.buttonPanel.TabIndex = 2;
            // 
            // addbutton
            // 
            this.addbutton.Location = new System.Drawing.Point(382, 8);
            this.addbutton.Name = "addbutton";
            this.addbutton.Size = new System.Drawing.Size(75, 23);
            this.addbutton.TabIndex = 0;
            this.addbutton.Text = "add";
            this.addbutton.UseVisualStyleBackColor = true;
            this.addbutton.Click += new System.EventHandler(this.createbutton_Click);
            // 
            // changebutton
            // 
            this.changebutton.Location = new System.Drawing.Point(205, 8);
            this.changebutton.Name = "changebutton";
            this.changebutton.Size = new System.Drawing.Size(75, 23);
            this.changebutton.TabIndex = 1;
            this.changebutton.Text = "change";
            this.changebutton.UseVisualStyleBackColor = true;
            this.changebutton.Click += new System.EventHandler(this.changebutton_Click);
            // 
            // removebutton
            // 
            this.removebutton.Location = new System.Drawing.Point(40, 8);
            this.removebutton.Name = "removebutton";
            this.removebutton.Size = new System.Drawing.Size(75, 23);
            this.removebutton.TabIndex = 2;
            this.removebutton.Text = "remove";
            this.removebutton.UseVisualStyleBackColor = true;
            this.removebutton.Click += new System.EventHandler(this.removebutton_Click);
            // 
            // exportbutton
            // 
            this.exportbutton.Location = new System.Drawing.Point(541, 8);
            this.exportbutton.Name = "exportbutton";
            this.exportbutton.Size = new System.Drawing.Size(75, 23);
            this.exportbutton.TabIndex = 3;
            this.exportbutton.Text = "export";
            this.exportbutton.UseVisualStyleBackColor = true;
            this.exportbutton.Click += new System.EventHandler(this.exportbutton_Click);
            // 
            // importbutton
            // 
            this.importbutton.Location = new System.Drawing.Point(713, 8);
            this.importbutton.Name = "importbutton";
            this.importbutton.Size = new System.Drawing.Size(75, 23);
            this.importbutton.TabIndex = 4;
            this.importbutton.Text = "import";
            this.importbutton.UseVisualStyleBackColor = true;
            this.importbutton.Click += new System.EventHandler(this.importbutton_Click);
            // 
            // orderdatagridview
            // 
            this.orderdatagridview.AutoGenerateColumns = false;
            this.orderdatagridview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.orderdatagridview.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.orderNumberDataGridViewTextBoxColumn,
            this.guestNameDataGridViewTextBoxColumn,
            this.sumDataGridViewTextBoxColumn});
            this.orderdatagridview.DataSource = this.orderbindingsource;
            this.orderdatagridview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.orderdatagridview.Location = new System.Drawing.Point(0, 0);
            this.orderdatagridview.Name = "orderdatagridview";
            this.orderdatagridview.RowTemplate.Height = 27;
            this.orderdatagridview.Size = new System.Drawing.Size(309, 335);
            this.orderdatagridview.TabIndex = 0;
            this.orderdatagridview.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.orderdatagridview_CellContentClick);
            // 
            // orderPanel
            // 
            this.orderPanel.Controls.Add(this.orderdatagridview);
            this.orderPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.orderPanel.Location = new System.Drawing.Point(0, 0);
            this.orderPanel.Name = "orderPanel";
            this.orderPanel.Size = new System.Drawing.Size(309, 335);
            this.orderPanel.TabIndex = 1;
            // 
            // orderdetaildatagridview
            // 
            this.orderdetaildatagridview.AutoGenerateColumns = false;
            this.orderdetaildatagridview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.orderdetaildatagridview.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.goodIdDataGridViewTextBoxColumn,
            this.goodNameDataGridViewTextBoxColumn,
            this.goodNumberDataGridViewTextBoxColumn,
            this.singlePriceDataGridViewTextBoxColumn});
            this.orderdetaildatagridview.DataSource = this.orderdetailbindingsource;
            this.orderdetaildatagridview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.orderdetaildatagridview.Location = new System.Drawing.Point(309, 0);
            this.orderdetaildatagridview.Name = "orderdetaildatagridview";
            this.orderdetaildatagridview.RowTemplate.Height = 27;
            this.orderdetaildatagridview.Size = new System.Drawing.Size(529, 335);
            this.orderdetaildatagridview.TabIndex = 2;
            this.orderdetaildatagridview.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.orderdetaildatagridview_CellContentClick);
            // 
            // orderdetailbindingsource
            // 
            this.orderdetailbindingsource.DataMember = "orderDetail";
            this.orderdetailbindingsource.DataSource = this.orderbindingsource;
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.FileName = "XML Files (*.xml)|*.xml";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "XML Files (*.xml)|*.xml";
            // 
            // goodIdDataGridViewTextBoxColumn
            // 
            this.goodIdDataGridViewTextBoxColumn.DataPropertyName = "goodId";
            this.goodIdDataGridViewTextBoxColumn.HeaderText = "goodId";
            this.goodIdDataGridViewTextBoxColumn.Name = "goodIdDataGridViewTextBoxColumn";
            this.goodIdDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // goodNameDataGridViewTextBoxColumn
            // 
            this.goodNameDataGridViewTextBoxColumn.DataPropertyName = "goodName";
            this.goodNameDataGridViewTextBoxColumn.HeaderText = "goodName";
            this.goodNameDataGridViewTextBoxColumn.Name = "goodNameDataGridViewTextBoxColumn";
            this.goodNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // goodNumberDataGridViewTextBoxColumn
            // 
            this.goodNumberDataGridViewTextBoxColumn.DataPropertyName = "goodNumber";
            this.goodNumberDataGridViewTextBoxColumn.HeaderText = "goodNumber";
            this.goodNumberDataGridViewTextBoxColumn.Name = "goodNumberDataGridViewTextBoxColumn";
            this.goodNumberDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // singlePriceDataGridViewTextBoxColumn
            // 
            this.singlePriceDataGridViewTextBoxColumn.DataPropertyName = "singlePrice";
            this.singlePriceDataGridViewTextBoxColumn.HeaderText = "singlePrice";
            this.singlePriceDataGridViewTextBoxColumn.Name = "singlePriceDataGridViewTextBoxColumn";
            this.singlePriceDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // orderbindingsource
            // 
            this.orderbindingsource.DataSource = typeof(homework8.Order);
            // 
            // orderNumberDataGridViewTextBoxColumn
            // 
            this.orderNumberDataGridViewTextBoxColumn.DataPropertyName = "orderNumber";
            this.orderNumberDataGridViewTextBoxColumn.HeaderText = "orderNumber";
            this.orderNumberDataGridViewTextBoxColumn.Name = "orderNumberDataGridViewTextBoxColumn";
            this.orderNumberDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // guestNameDataGridViewTextBoxColumn
            // 
            this.guestNameDataGridViewTextBoxColumn.DataPropertyName = "guestName";
            this.guestNameDataGridViewTextBoxColumn.HeaderText = "guestName";
            this.guestNameDataGridViewTextBoxColumn.Name = "guestNameDataGridViewTextBoxColumn";
            this.guestNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // sumDataGridViewTextBoxColumn
            // 
            this.sumDataGridViewTextBoxColumn.DataPropertyName = "Sum";
            this.sumDataGridViewTextBoxColumn.HeaderText = "Sum";
            this.sumDataGridViewTextBoxColumn.Name = "sumDataGridViewTextBoxColumn";
            this.sumDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(838, 451);
            this.Controls.Add(this.buttonPanel);
            this.Controls.Add(this.dataPanel);
            this.Controls.Add(this.findPanel);
            this.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.findPanel.ResumeLayout(false);
            this.findPanel.PerformLayout();
            this.dataPanel.ResumeLayout(false);
            this.buttonPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.orderdatagridview)).EndInit();
            this.orderPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.orderdetaildatagridview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderdetailbindingsource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderbindingsource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel findPanel;
        private System.Windows.Forms.TextBox textbox;
        private System.Windows.Forms.ComboBox findComboBox;
        private System.Windows.Forms.Button findbutton;
        private System.Windows.Forms.Panel dataPanel;
        private System.Windows.Forms.Panel buttonPanel;
        private System.Windows.Forms.DataGridView orderdetaildatagridview;
        private System.Windows.Forms.Panel orderPanel;
        private System.Windows.Forms.DataGridView orderdatagridview;
        private System.Windows.Forms.Button importbutton;
        private System.Windows.Forms.Button exportbutton;
        private System.Windows.Forms.Button removebutton;
        private System.Windows.Forms.Button changebutton;
        private System.Windows.Forms.Button addbutton;
        private System.Windows.Forms.BindingSource orderbindingsource;
        private System.Windows.Forms.BindingSource orderdetailbindingsource;
        private System.Windows.Forms.DataGridViewTextBoxColumn goodIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn goodNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn goodNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn singlePriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn orderNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn guestNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sumDataGridViewTextBoxColumn;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}

