namespace CompE561Lab5
{
    partial class BookForm
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
            this.back = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBook = new System.Windows.Forms.ComboBox();
            this.Title = new System.Windows.Forms.TextBox();
            this.Author = new System.Windows.Forms.TextBox();
            this.ISBN = new System.Windows.Forms.TextBox();
            this.Price = new System.Windows.Forms.TextBox();
            this.NewBook = new System.Windows.Forms.Button();
            this.save = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // back
            // 
            this.back.Location = new System.Drawing.Point(1192, 24);
            this.back.Name = "back";
            this.back.Size = new System.Drawing.Size(168, 40);
            this.back.TabIndex = 0;
            this.back.Text = "Back";
            this.back.UseVisualStyleBackColor = true;
            this.back.Click += new System.EventHandler(this.back_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Select Book";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 128);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Title";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 416);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 25);
            this.label3.TabIndex = 3;
            this.label3.Text = "Price";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(32, 320);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 25);
            this.label4.TabIndex = 4;
            this.label4.Text = "ISBN";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(32, 224);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 25);
            this.label5.TabIndex = 5;
            this.label5.Text = "Author";
            // 
            // comboBook
            // 
            this.comboBook.FormattingEnabled = true;
            this.comboBook.Location = new System.Drawing.Point(160, 32);
            this.comboBook.Name = "comboBook";
            this.comboBook.Size = new System.Drawing.Size(896, 33);
            this.comboBook.TabIndex = 6;
            this.comboBook.SelectedIndexChanged += new System.EventHandler(this.comboBook_SelectedIndexChanged);
            // 
            // Title
            // 
            this.Title.Location = new System.Drawing.Point(160, 128);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(976, 31);
            this.Title.TabIndex = 7;
            // 
            // Author
            // 
            this.Author.Location = new System.Drawing.Point(160, 224);
            this.Author.Name = "Author";
            this.Author.Size = new System.Drawing.Size(976, 31);
            this.Author.TabIndex = 8;
            // 
            // ISBN
            // 
            this.ISBN.Location = new System.Drawing.Point(160, 320);
            this.ISBN.Name = "ISBN";
            this.ISBN.Size = new System.Drawing.Size(408, 31);
            this.ISBN.TabIndex = 9;
            // 
            // Price
            // 
            this.Price.Location = new System.Drawing.Point(160, 416);
            this.Price.Name = "Price";
            this.Price.Size = new System.Drawing.Size(408, 31);
            this.Price.TabIndex = 10;
            // 
            // NewBook
            // 
            this.NewBook.Location = new System.Drawing.Point(1192, 120);
            this.NewBook.Name = "NewBook";
            this.NewBook.Size = new System.Drawing.Size(168, 40);
            this.NewBook.TabIndex = 11;
            this.NewBook.Text = "New Book";
            this.NewBook.UseVisualStyleBackColor = true;
            this.NewBook.Click += new System.EventHandler(this.newBook_Click);
            // 
            // save
            // 
            this.save.Location = new System.Drawing.Point(1192, 224);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(168, 40);
            this.save.TabIndex = 12;
            this.save.Text = "Save";
            this.save.UseVisualStyleBackColor = true;
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // cancel
            // 
            this.cancel.Location = new System.Drawing.Point(1192, 328);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(168, 40);
            this.cancel.TabIndex = 13;
            this.cancel.Text = "Cancel";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // BookForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1397, 498);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.save);
            this.Controls.Add(this.NewBook);
            this.Controls.Add(this.Price);
            this.Controls.Add(this.ISBN);
            this.Controls.Add(this.Author);
            this.Controls.Add(this.Title);
            this.Controls.Add(this.comboBook);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.back);
            this.Name = "BookForm";
            this.Text = "Book";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button back;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBook;
        private System.Windows.Forms.TextBox Title;
        private System.Windows.Forms.TextBox Author;
        private System.Windows.Forms.TextBox ISBN;
        private System.Windows.Forms.TextBox Price;
        private System.Windows.Forms.Button NewBook;
        private System.Windows.Forms.Button save;
        private System.Windows.Forms.Button cancel;
    }
}