﻿namespace openLibrary_2._0
{
    partial class frmAddBook
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
            this.txtBinding = new System.Windows.Forms.TextBox();
            this.txtPublisher = new System.Windows.Forms.TextBox();
            this.txtAuthor = new System.Windows.Forms.TextBox();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.txtISBN = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDate = new System.Windows.Forms.TextBox();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.txtPages = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnPopulate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtBinding
            // 
            this.txtBinding.Location = new System.Drawing.Point(107, 136);
            this.txtBinding.Name = "txtBinding";
            this.txtBinding.Size = new System.Drawing.Size(100, 20);
            this.txtBinding.TabIndex = 5;
            // 
            // txtPublisher
            // 
            this.txtPublisher.Location = new System.Drawing.Point(107, 107);
            this.txtPublisher.Name = "txtPublisher";
            this.txtPublisher.Size = new System.Drawing.Size(100, 20);
            this.txtPublisher.TabIndex = 4;
            // 
            // txtAuthor
            // 
            this.txtAuthor.Location = new System.Drawing.Point(107, 78);
            this.txtAuthor.Name = "txtAuthor";
            this.txtAuthor.Size = new System.Drawing.Size(100, 20);
            this.txtAuthor.TabIndex = 3;
            this.txtAuthor.TextChanged += new System.EventHandler(this.txtAuthor_TextChanged);
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(107, 49);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(100, 20);
            this.txtTitle.TabIndex = 2;
            // 
            // txtISBN
            // 
            this.txtISBN.AcceptsTab = true;
            this.txtISBN.Location = new System.Drawing.Point(107, 20);
            this.txtISBN.Name = "txtISBN";
            this.txtISBN.Size = new System.Drawing.Size(100, 20);
            this.txtISBN.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(65, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "ISBN";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(70, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Title";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(59, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Author";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(45, 294);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 10;
            this.btnAdd.Text = "Add Book";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click_1);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(126, 294);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 11;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(47, 114);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Publisher";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(55, 143);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Binding";
            // 
            // txtDate
            // 
            this.txtDate.Location = new System.Drawing.Point(107, 165);
            this.txtDate.Name = "txtDate";
            this.txtDate.Size = new System.Drawing.Size(100, 20);
            this.txtDate.TabIndex = 14;
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(107, 194);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(100, 20);
            this.txtPrice.TabIndex = 15;
            // 
            // txtPages
            // 
            this.txtPages.Location = new System.Drawing.Point(107, 223);
            this.txtPages.Name = "txtPages";
            this.txtPages.Size = new System.Drawing.Size(100, 20);
            this.txtPages.TabIndex = 16;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 172);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "Publishing Date";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(66, 201);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(31, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "Price";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(60, 230);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(37, 13);
            this.label8.TabIndex = 19;
            this.label8.Text = "Pages";
            // 
            // btnPopulate
            // 
            this.btnPopulate.Location = new System.Drawing.Point(73, 262);
            this.btnPopulate.Name = "btnPopulate";
            this.btnPopulate.Size = new System.Drawing.Size(104, 26);
            this.btnPopulate.TabIndex = 20;
            this.btnPopulate.Text = "Populate";
            this.btnPopulate.UseVisualStyleBackColor = true;
            this.btnPopulate.Click += new System.EventHandler(this.btnPopulate_Click);
            // 
            // frmAddBook
            // 
            this.AcceptButton = this.btnAdd;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(255, 332);
            this.Controls.Add(this.btnPopulate);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtPages);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.txtDate);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtISBN);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.txtAuthor);
            this.Controls.Add(this.txtPublisher);
            this.Controls.Add(this.txtBinding);
            this.MaximumSize = new System.Drawing.Size(500, 500);
            this.MinimumSize = new System.Drawing.Size(271, 289);
            this.Name = "frmAddBook";
            this.Text = "Add New Book";
            this.Load += new System.EventHandler(this.frmAddBook_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtBinding;
        private System.Windows.Forms.TextBox txtPublisher;
        private System.Windows.Forms.TextBox txtAuthor;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.TextBox txtISBN;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDate;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.TextBox txtPages;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnPopulate;
    }
}