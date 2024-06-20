namespace CleanShopDesktop
{
    partial class CSForm
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
            components = new System.ComponentModel.Container();
            ActionTabs = new TabControl();
            tabPage1 = new TabPage();
            ProductsSalesGrid = new DataGridView();
            tabPage2 = new TabPage();
            label1 = new Label();
            GlobalSalesTextBox = new TextBox();
            tabPage3 = new TabPage();
            BestSellersGridView = new DataGridView();
            tabPage4 = new TabPage();
            InventoryGridView = new DataGridView();
            ProductSalesDataBinding = new BindingSource(components);
            StatusPanel = new FlowLayoutPanel();
            StatusTextbox = new TextBox();
            RetryBtn = new Button();
            ActionTabs.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ProductsSalesGrid).BeginInit();
            tabPage2.SuspendLayout();
            tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)BestSellersGridView).BeginInit();
            tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)InventoryGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ProductSalesDataBinding).BeginInit();
            StatusPanel.SuspendLayout();
            SuspendLayout();
            // 
            // ActionTabs
            // 
            ActionTabs.Controls.Add(tabPage1);
            ActionTabs.Controls.Add(tabPage2);
            ActionTabs.Controls.Add(tabPage3);
            ActionTabs.Controls.Add(tabPage4);
            ActionTabs.Dock = DockStyle.Fill;
            ActionTabs.Location = new Point(0, 0);
            ActionTabs.Name = "ActionTabs";
            ActionTabs.SelectedIndex = 0;
            ActionTabs.Size = new Size(1348, 681);
            ActionTabs.TabIndex = 0;
            ActionTabs.SelectedIndexChanged += ActionTabs_SelectedIndexChanged;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(ProductsSalesGrid);
            tabPage1.Location = new Point(4, 29);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1340, 648);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Ventas x árticulo";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // ProductsSalesGrid
            // 
            ProductsSalesGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            ProductsSalesGrid.BackgroundColor = SystemColors.AppWorkspace;
            ProductsSalesGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            ProductsSalesGrid.Dock = DockStyle.Fill;
            ProductsSalesGrid.Location = new Point(3, 3);
            ProductsSalesGrid.Name = "ProductsSalesGrid";
            ProductsSalesGrid.ReadOnly = true;
            ProductsSalesGrid.RowHeadersWidth = 51;
            ProductsSalesGrid.Size = new Size(1334, 642);
            ProductsSalesGrid.TabIndex = 0;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(label1);
            tabPage2.Controls.Add(GlobalSalesTextBox);
            tabPage2.Location = new Point(4, 29);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1340, 648);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Ventas globales";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(9, 9);
            label1.Name = "label1";
            label1.Size = new Size(55, 20);
            label1.TabIndex = 1;
            label1.Text = "Ventas:";
            // 
            // GlobalSalesTextBox
            // 
            GlobalSalesTextBox.Enabled = false;
            GlobalSalesTextBox.Location = new Point(70, 6);
            GlobalSalesTextBox.Name = "GlobalSalesTextBox";
            GlobalSalesTextBox.Size = new Size(125, 27);
            GlobalSalesTextBox.TabIndex = 0;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(BestSellersGridView);
            tabPage3.Location = new Point(4, 29);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(1340, 648);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Árticulos más vendidos";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // BestSellersGridView
            // 
            BestSellersGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            BestSellersGridView.BackgroundColor = SystemColors.AppWorkspace;
            BestSellersGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            BestSellersGridView.Dock = DockStyle.Fill;
            BestSellersGridView.Location = new Point(3, 3);
            BestSellersGridView.Name = "BestSellersGridView";
            BestSellersGridView.ReadOnly = true;
            BestSellersGridView.RowHeadersWidth = 51;
            BestSellersGridView.Size = new Size(1334, 642);
            BestSellersGridView.TabIndex = 0;
            // 
            // tabPage4
            // 
            tabPage4.Controls.Add(InventoryGridView);
            tabPage4.Location = new Point(4, 29);
            tabPage4.Name = "tabPage4";
            tabPage4.Padding = new Padding(3);
            tabPage4.Size = new Size(1340, 648);
            tabPage4.TabIndex = 3;
            tabPage4.Text = "Inventario";
            tabPage4.UseVisualStyleBackColor = true;
            // 
            // InventoryGridView
            // 
            InventoryGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            InventoryGridView.BackgroundColor = SystemColors.AppWorkspace;
            InventoryGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            InventoryGridView.Dock = DockStyle.Fill;
            InventoryGridView.Location = new Point(3, 3);
            InventoryGridView.Name = "InventoryGridView";
            InventoryGridView.RowHeadersWidth = 51;
            InventoryGridView.Size = new Size(1334, 642);
            InventoryGridView.TabIndex = 0;
            // 
            // StatusPanel
            // 
            StatusPanel.AutoSize = true;
            StatusPanel.Controls.Add(StatusTextbox);
            StatusPanel.Controls.Add(RetryBtn);
            StatusPanel.Dock = DockStyle.Bottom;
            StatusPanel.Location = new Point(0, 626);
            StatusPanel.Name = "StatusPanel";
            StatusPanel.Padding = new Padding(10);
            StatusPanel.Size = new Size(1348, 55);
            StatusPanel.TabIndex = 2;
            // 
            // StatusTextbox
            // 
            StatusTextbox.BorderStyle = BorderStyle.None;
            StatusTextbox.Location = new Point(13, 13);
            StatusTextbox.Name = "StatusTextbox";
            StatusTextbox.ReadOnly = true;
            StatusTextbox.Size = new Size(1214, 20);
            StatusTextbox.TabIndex = 0;
            // 
            // RetryBtn
            // 
            RetryBtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            RetryBtn.Enabled = false;
            RetryBtn.Location = new Point(1233, 13);
            RetryBtn.Name = "RetryBtn";
            RetryBtn.Size = new Size(94, 29);
            RetryBtn.TabIndex = 1;
            RetryBtn.Text = "Reintentar";
            RetryBtn.UseVisualStyleBackColor = true;
            RetryBtn.Click += RetryBtn_Click;
            // 
            // CSForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1348, 681);
            Controls.Add(StatusPanel);
            Controls.Add(ActionTabs);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "CSForm";
            Text = "CleanShop Admin";
            Load += CSForm_Load;
            ActionTabs.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)ProductsSalesGrid).EndInit();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)BestSellersGridView).EndInit();
            tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)InventoryGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)ProductSalesDataBinding).EndInit();
            StatusPanel.ResumeLayout(false);
            StatusPanel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TabControl ActionTabs;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TabPage tabPage3;
        private TabPage tabPage4;
        private DataGridView ProductsSalesGrid;
        private BindingSource ProductSalesDataBinding;
        private FlowLayoutPanel StatusPanel;
        private TextBox StatusTextbox;
        private Button RetryBtn;
        private Label label1;
        private TextBox GlobalSalesTextBox;
        private DataGridView BestSellersGridView;
        private DataGridView InventoryGridView;
    }
}
