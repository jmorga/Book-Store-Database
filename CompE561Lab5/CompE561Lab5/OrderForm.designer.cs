namespace CompE561Lab5
{
    partial class OrderForm
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
            this.masterBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.authorText = new System.Windows.Forms.TextBox();
            this.PriceText = new System.Windows.Forms.TextBox();
            this.isbnText = new System.Windows.Forms.TextBox();
            this.quantityText = new System.Windows.Forms.TextBox();
            this.addButton = new System.Windows.Forms.Button();
            this.dataGrid = new System.Windows.Forms.DataGridView();
            this.Title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QTY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LineTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.subtotalText = new System.Windows.Forms.TextBox();
            this.taxtBox = new System.Windows.Forms.TextBox();
            this.totalText = new System.Windows.Forms.TextBox();
            this.Confirmation = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            this.customerCombo = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // masterBox
            // 
            this.masterBox.FormattingEnabled = true;
            this.masterBox.Location = new System.Drawing.Point(33, 87);
            this.masterBox.Name = "masterBox";
            this.masterBox.Size = new System.Drawing.Size(729, 33);
            this.masterBox.TabIndex = 0;
            this.masterBox.Text = "Choose Text Book";
            this.masterBox.SelectedIndexChanged += new System.EventHandler(this.masterBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(105, 144);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Author";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(456, 144);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "ISBN";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(110, 217);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 25);
            this.label3.TabIndex = 3;
            this.label3.Text = "Price";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(456, 217);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 25);
            this.label4.TabIndex = 4;
            this.label4.Text = "Quantity";
            // 
            // authorText
            // 
            this.authorText.Location = new System.Drawing.Point(208, 144);
            this.authorText.Name = "authorText";
            this.authorText.ReadOnly = true;
            this.authorText.Size = new System.Drawing.Size(234, 31);
            this.authorText.TabIndex = 5;
            // 
            // PriceText
            // 
            this.PriceText.Location = new System.Drawing.Point(208, 217);
            this.PriceText.Name = "PriceText";
            this.PriceText.ReadOnly = true;
            this.PriceText.Size = new System.Drawing.Size(152, 31);
            this.PriceText.TabIndex = 6;
            // 
            // isbnText
            // 
            this.isbnText.Location = new System.Drawing.Point(560, 144);
            this.isbnText.Name = "isbnText";
            this.isbnText.ReadOnly = true;
            this.isbnText.Size = new System.Drawing.Size(152, 31);
            this.isbnText.TabIndex = 7;
            // 
            // quantityText
            // 
            this.quantityText.Location = new System.Drawing.Point(560, 217);
            this.quantityText.Name = "quantityText";
            this.quantityText.Size = new System.Drawing.Size(119, 31);
            this.quantityText.TabIndex = 8;
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(832, 208);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(136, 41);
            this.addButton.TabIndex = 9;
            this.addButton.Text = "Add Title";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // dataGrid
            // 
            this.dataGrid.AllowUserToAddRows = false;
            this.dataGrid.AllowUserToDeleteRows = false;
            this.dataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Title,
            this.Price,
            this.QTY,
            this.LineTotal});
            this.dataGrid.Location = new System.Drawing.Point(8, 264);
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.ReadOnly = true;
            this.dataGrid.RowTemplate.Height = 33;
            this.dataGrid.Size = new System.Drawing.Size(989, 372);
            this.dataGrid.TabIndex = 10;
            // 
            // Title
            // 
            this.Title.HeaderText = "Title";
            this.Title.MinimumWidth = 10;
            this.Title.Name = "Title";
            this.Title.ReadOnly = true;
            this.Title.Width = 150;
            // 
            // Price
            // 
            this.Price.HeaderText = "Price";
            this.Price.Name = "Price";
            this.Price.ReadOnly = true;
            // 
            // QTY
            // 
            this.QTY.HeaderText = "QTY";
            this.QTY.Name = "QTY";
            this.QTY.ReadOnly = true;
            // 
            // LineTotal
            // 
            this.LineTotal.HeaderText = "Line Total";
            this.LineTotal.Name = "LineTotal";
            this.LineTotal.ReadOnly = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(139, 668);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 25);
            this.label5.TabIndex = 11;
            this.label5.Text = "Subtotal";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(395, 668);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 25);
            this.label6.TabIndex = 12;
            this.label6.Text = "Tax";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(606, 668);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 25);
            this.label7.TabIndex = 13;
            this.label7.Text = "Total";
            // 
            // subtotalText
            // 
            this.subtotalText.Location = new System.Drawing.Point(237, 668);
            this.subtotalText.Name = "subtotalText";
            this.subtotalText.ReadOnly = true;
            this.subtotalText.Size = new System.Drawing.Size(138, 31);
            this.subtotalText.TabIndex = 14;
            // 
            // taxtBox
            // 
            this.taxtBox.Location = new System.Drawing.Point(449, 668);
            this.taxtBox.Name = "taxtBox";
            this.taxtBox.ReadOnly = true;
            this.taxtBox.Size = new System.Drawing.Size(138, 31);
            this.taxtBox.TabIndex = 15;
            // 
            // totalText
            // 
            this.totalText.Location = new System.Drawing.Point(672, 668);
            this.totalText.Name = "totalText";
            this.totalText.ReadOnly = true;
            this.totalText.Size = new System.Drawing.Size(138, 31);
            this.totalText.TabIndex = 16;
            // 
            // Confirmation
            // 
            this.Confirmation.Location = new System.Drawing.Point(265, 732);
            this.Confirmation.Name = "Confirmation";
            this.Confirmation.Size = new System.Drawing.Size(206, 46);
            this.Confirmation.TabIndex = 17;
            this.Confirmation.Text = "Confirm Order";
            this.Confirmation.UseVisualStyleBackColor = true;
            this.Confirmation.Click += new System.EventHandler(this.Confirmation_Click);
            // 
            // Cancel
            // 
            this.Cancel.Location = new System.Drawing.Point(545, 732);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(196, 46);
            this.Cancel.TabIndex = 18;
            this.Cancel.Text = "Cancel Order";
            this.Cancel.UseVisualStyleBackColor = true;
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // customerCombo
            // 
            this.customerCombo.FormattingEnabled = true;
            this.customerCombo.Location = new System.Drawing.Point(32, 24);
            this.customerCombo.Name = "customerCombo";
            this.customerCombo.Size = new System.Drawing.Size(729, 33);
            this.customerCombo.TabIndex = 19;
            this.customerCombo.Text = "Select a Customer";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(832, 24);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(136, 41);
            this.button1.TabIndex = 20;
            this.button1.Text = "Back";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // OrderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1007, 836);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.customerCombo);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.Confirmation);
            this.Controls.Add(this.totalText);
            this.Controls.Add(this.taxtBox);
            this.Controls.Add(this.subtotalText);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dataGrid);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.quantityText);
            this.Controls.Add(this.isbnText);
            this.Controls.Add(this.PriceText);
            this.Controls.Add(this.authorText);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.masterBox);
            this.Name = "OrderForm";
            this.Text = "Orders";
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox masterBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox authorText;
        private System.Windows.Forms.TextBox PriceText;
        private System.Windows.Forms.TextBox isbnText;
        private System.Windows.Forms.TextBox quantityText;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.DataGridView dataGrid;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox subtotalText;
        private System.Windows.Forms.TextBox taxtBox;
        private System.Windows.Forms.TextBox totalText;
        private System.Windows.Forms.Button Confirmation;
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.DataGridViewTextBoxColumn Title;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn QTY;
        private System.Windows.Forms.DataGridViewTextBoxColumn LineTotal;
        private System.Windows.Forms.ComboBox customerCombo;
        private System.Windows.Forms.Button button1;
    }
}

