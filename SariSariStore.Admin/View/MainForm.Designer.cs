namespace SariSariStore.Admin
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
            components = new System.ComponentModel.Container();
            historyButton = new Button();
            ordersDataGrid = new DataGridView();
            markAsPaidButton = new Button();
            deleteProductButton = new Button();
            editProductButton = new Button();
            addProductButton = new Button();
            productsDataGrid = new DataGridView();
            Product_ID = new DataGridViewTextBoxColumn();
            Product_Name = new DataGridViewTextBoxColumn();
            Description = new DataGridViewTextBoxColumn();
            Category = new DataGridViewTextBoxColumn();
            Price = new DataGridViewTextBoxColumn();
            Stock = new DataGridViewTextBoxColumn();
            Image = new DataGridViewTextBoxColumn();
            RefreshTimer = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)ordersDataGrid).BeginInit();
            ((System.ComponentModel.ISupportInitialize)productsDataGrid).BeginInit();
            SuspendLayout();
            // 
            // historyButton
            // 
            historyButton.Location = new Point(683, 384);
            historyButton.Name = "historyButton";
            historyButton.Size = new Size(75, 46);
            historyButton.TabIndex = 14;
            historyButton.Text = "History";
            historyButton.UseVisualStyleBackColor = true;
            historyButton.Click += historyButton_Click;
            // 
            // ordersDataGrid
            // 
            ordersDataGrid.AllowUserToAddRows = false;
            ordersDataGrid.AllowUserToDeleteRows = false;
            ordersDataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            ordersDataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            ordersDataGrid.Location = new Point(12, 186);
            ordersDataGrid.Name = "ordersDataGrid";
            ordersDataGrid.ReadOnly = true;
            ordersDataGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            ordersDataGrid.Size = new Size(774, 194);
            ordersDataGrid.TabIndex = 13;
            // 
            // markAsPaidButton
            // 
            markAsPaidButton.Location = new Point(544, 384);
            markAsPaidButton.Name = "markAsPaidButton";
            markAsPaidButton.Size = new Size(133, 44);
            markAsPaidButton.TabIndex = 12;
            markAsPaidButton.Text = "MARK AS A PAID";
            markAsPaidButton.UseVisualStyleBackColor = true;
            // 
            // deleteProductButton
            // 
            deleteProductButton.Location = new Point(208, 384);
            deleteProductButton.Name = "deleteProductButton";
            deleteProductButton.Size = new Size(75, 44);
            deleteProductButton.TabIndex = 11;
            deleteProductButton.Text = "DELETE";
            deleteProductButton.UseVisualStyleBackColor = true;
            deleteProductButton.Click += deleteProductButton_Click;
            // 
            // editProductButton
            // 
            editProductButton.Location = new Point(108, 384);
            editProductButton.Name = "editProductButton";
            editProductButton.Size = new Size(75, 44);
            editProductButton.TabIndex = 10;
            editProductButton.Text = "EDIT";
            editProductButton.UseVisualStyleBackColor = true;
            editProductButton.Click += editProductButton_Click;
            // 
            // addProductButton
            // 
            addProductButton.Location = new Point(13, 384);
            addProductButton.Name = "addProductButton";
            addProductButton.Size = new Size(75, 44);
            addProductButton.TabIndex = 9;
            addProductButton.Text = "ADD";
            addProductButton.UseVisualStyleBackColor = true;
            addProductButton.Click += addProductButton_Click;
            // 
            // productsDataGrid
            // 
            productsDataGrid.AllowUserToAddRows = false;
            productsDataGrid.AllowUserToDeleteRows = false;
            productsDataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            productsDataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            productsDataGrid.Columns.AddRange(new DataGridViewColumn[] { Product_ID, Product_Name, Description, Category, Price, Stock, Image });
            productsDataGrid.Location = new Point(12, 21);
            productsDataGrid.Name = "productsDataGrid";
            productsDataGrid.ReadOnly = true;
            productsDataGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            productsDataGrid.Size = new Size(776, 150);
            productsDataGrid.TabIndex = 8;
            // 
            // Product_ID
            // 
            Product_ID.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Product_ID.HeaderText = "Product ID";
            Product_ID.Name = "Product_ID";
            Product_ID.ReadOnly = true;
            // 
            // Product_Name
            // 
            Product_Name.HeaderText = "Name";
            Product_Name.Name = "Product_Name";
            Product_Name.ReadOnly = true;
            // 
            // Description
            // 
            Description.HeaderText = "Description";
            Description.Name = "Description";
            Description.ReadOnly = true;
            // 
            // Category
            // 
            Category.HeaderText = "Category";
            Category.Name = "Category";
            Category.ReadOnly = true;
            // 
            // Price
            // 
            Price.HeaderText = "Price";
            Price.Name = "Price";
            Price.ReadOnly = true;
            // 
            // Stock
            // 
            Stock.HeaderText = "Stock";
            Stock.Name = "Stock";
            Stock.ReadOnly = true;
            // 
            // Image
            // 
            Image.HeaderText = "Image";
            Image.Name = "Image";
            Image.ReadOnly = true;
            // 
            // RefreshTimer
            // 
            RefreshTimer.Enabled = true;
            RefreshTimer.Interval = 2000;
            RefreshTimer.Tick += RefreshTimer_Tick;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(historyButton);
            Controls.Add(ordersDataGrid);
            Controls.Add(markAsPaidButton);
            Controls.Add(deleteProductButton);
            Controls.Add(editProductButton);
            Controls.Add(addProductButton);
            Controls.Add(productsDataGrid);
            Name = "MainForm";
            Text = "Form1";
            Load += MainForm_Load;
            ((System.ComponentModel.ISupportInitialize)ordersDataGrid).EndInit();
            ((System.ComponentModel.ISupportInitialize)productsDataGrid).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button historyButton;
        private DataGridView ordersDataGrid;
        private Button markAsPaidButton;
        private Button deleteProductButton;
        private Button editProductButton;
        private Button addProductButton;
        private DataGridView productsDataGrid;
        private System.Windows.Forms.Timer RefreshTimer;
        private DataGridViewTextBoxColumn Product_ID;
        private DataGridViewTextBoxColumn Product_Name;
        private DataGridViewTextBoxColumn Description;
        private DataGridViewTextBoxColumn Category;
        private DataGridViewTextBoxColumn Price;
        private DataGridViewTextBoxColumn Stock;
        private DataGridViewTextBoxColumn Image;
    }
}
