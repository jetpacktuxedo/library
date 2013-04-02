namespace openLibrary_2._0
{
    partial class frmViewBook
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
            this.components = new System.ComponentModel.Container();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.bOOKIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iSBNDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tITLEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bINDINGDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pUBLISHERDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aUTHORDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pUBDATEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pRICEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pAGESDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bOOKBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.libraryDataSet = new openLibrary_2._0.LibraryDataSet();
            this.bOOKTableAdapter = new openLibrary_2._0.LibraryDataSetTableAdapters.BOOKTableAdapter();
            this.libraryDataSet1 = new openLibrary_2._0.LibraryDataSet1();
            this.bOOKBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.bOOKTableAdapter1 = new openLibrary_2._0.LibraryDataSet1TableAdapters.BOOKTableAdapter();
            this.libraryDataSet3 = new openLibrary_2._0.LibraryDataSet3();
            this.bOOKBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.bOOKTableAdapter2 = new openLibrary_2._0.LibraryDataSet3TableAdapters.BOOKTableAdapter();
            this.libraryDataSet4 = new openLibrary_2._0.LibraryDataSet4();
            this.bOOKBindingSource3 = new System.Windows.Forms.BindingSource(this.components);
            this.bOOKTableAdapter3 = new openLibrary_2._0.LibraryDataSet4TableAdapters.BOOKTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bOOKBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.libraryDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.libraryDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bOOKBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.libraryDataSet3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bOOKBindingSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.libraryDataSet4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bOOKBindingSource3)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.bOOKIDDataGridViewTextBoxColumn,
            this.iSBNDataGridViewTextBoxColumn,
            this.tITLEDataGridViewTextBoxColumn,
            this.bINDINGDataGridViewTextBoxColumn,
            this.pUBLISHERDataGridViewTextBoxColumn,
            this.aUTHORDataGridViewTextBoxColumn,
            this.pUBDATEDataGridViewTextBoxColumn,
            this.pRICEDataGridViewTextBoxColumn,
            this.pAGESDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.bOOKBindingSource3;
            this.dataGridView1.Location = new System.Drawing.Point(30, 33);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(639, 377);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // bOOKIDDataGridViewTextBoxColumn
            // 
            this.bOOKIDDataGridViewTextBoxColumn.DataPropertyName = "BOOK_ID";
            this.bOOKIDDataGridViewTextBoxColumn.HeaderText = "BOOK_ID";
            this.bOOKIDDataGridViewTextBoxColumn.Name = "bOOKIDDataGridViewTextBoxColumn";
            this.bOOKIDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // iSBNDataGridViewTextBoxColumn
            // 
            this.iSBNDataGridViewTextBoxColumn.DataPropertyName = "ISBN";
            this.iSBNDataGridViewTextBoxColumn.HeaderText = "ISBN";
            this.iSBNDataGridViewTextBoxColumn.Name = "iSBNDataGridViewTextBoxColumn";
            this.iSBNDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // tITLEDataGridViewTextBoxColumn
            // 
            this.tITLEDataGridViewTextBoxColumn.DataPropertyName = "TITLE";
            this.tITLEDataGridViewTextBoxColumn.HeaderText = "TITLE";
            this.tITLEDataGridViewTextBoxColumn.Name = "tITLEDataGridViewTextBoxColumn";
            this.tITLEDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // bINDINGDataGridViewTextBoxColumn
            // 
            this.bINDINGDataGridViewTextBoxColumn.DataPropertyName = "BINDING";
            this.bINDINGDataGridViewTextBoxColumn.HeaderText = "BINDING";
            this.bINDINGDataGridViewTextBoxColumn.Name = "bINDINGDataGridViewTextBoxColumn";
            this.bINDINGDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // pUBLISHERDataGridViewTextBoxColumn
            // 
            this.pUBLISHERDataGridViewTextBoxColumn.DataPropertyName = "PUBLISHER";
            this.pUBLISHERDataGridViewTextBoxColumn.HeaderText = "PUBLISHER";
            this.pUBLISHERDataGridViewTextBoxColumn.Name = "pUBLISHERDataGridViewTextBoxColumn";
            this.pUBLISHERDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // aUTHORDataGridViewTextBoxColumn
            // 
            this.aUTHORDataGridViewTextBoxColumn.DataPropertyName = "AUTHOR";
            this.aUTHORDataGridViewTextBoxColumn.HeaderText = "AUTHOR";
            this.aUTHORDataGridViewTextBoxColumn.Name = "aUTHORDataGridViewTextBoxColumn";
            this.aUTHORDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // pUBDATEDataGridViewTextBoxColumn
            // 
            this.pUBDATEDataGridViewTextBoxColumn.DataPropertyName = "PUB_DATE";
            this.pUBDATEDataGridViewTextBoxColumn.HeaderText = "PUB_DATE";
            this.pUBDATEDataGridViewTextBoxColumn.Name = "pUBDATEDataGridViewTextBoxColumn";
            this.pUBDATEDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // pRICEDataGridViewTextBoxColumn
            // 
            this.pRICEDataGridViewTextBoxColumn.DataPropertyName = "PRICE";
            this.pRICEDataGridViewTextBoxColumn.HeaderText = "PRICE";
            this.pRICEDataGridViewTextBoxColumn.Name = "pRICEDataGridViewTextBoxColumn";
            this.pRICEDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // pAGESDataGridViewTextBoxColumn
            // 
            this.pAGESDataGridViewTextBoxColumn.DataPropertyName = "PAGES";
            this.pAGESDataGridViewTextBoxColumn.HeaderText = "PAGES";
            this.pAGESDataGridViewTextBoxColumn.Name = "pAGESDataGridViewTextBoxColumn";
            this.pAGESDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // bOOKBindingSource
            // 
            this.bOOKBindingSource.DataMember = "BOOK";
            this.bOOKBindingSource.DataSource = this.libraryDataSet;
            // 
            // libraryDataSet
            // 
            this.libraryDataSet.DataSetName = "LibraryDataSet";
            this.libraryDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bOOKTableAdapter
            // 
            this.bOOKTableAdapter.ClearBeforeFill = true;
            // 
            // libraryDataSet1
            // 
            this.libraryDataSet1.DataSetName = "LibraryDataSet1";
            this.libraryDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bOOKBindingSource1
            // 
            this.bOOKBindingSource1.DataMember = "BOOK";
            this.bOOKBindingSource1.DataSource = this.libraryDataSet1;
            // 
            // bOOKTableAdapter1
            // 
            this.bOOKTableAdapter1.ClearBeforeFill = true;
            // 
            // libraryDataSet3
            // 
            this.libraryDataSet3.DataSetName = "LibraryDataSet3";
            this.libraryDataSet3.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bOOKBindingSource2
            // 
            this.bOOKBindingSource2.DataMember = "BOOK";
            this.bOOKBindingSource2.DataSource = this.libraryDataSet3;
            // 
            // bOOKTableAdapter2
            // 
            this.bOOKTableAdapter2.ClearBeforeFill = true;
            // 
            // libraryDataSet4
            // 
            this.libraryDataSet4.DataSetName = "LibraryDataSet4";
            this.libraryDataSet4.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bOOKBindingSource3
            // 
            this.bOOKBindingSource3.DataMember = "BOOK";
            this.bOOKBindingSource3.DataSource = this.libraryDataSet4;
            // 
            // bOOKTableAdapter3
            // 
            this.bOOKTableAdapter3.ClearBeforeFill = true;
            // 
            // frmViewBook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(702, 508);
            this.Controls.Add(this.dataGridView1);
            this.Name = "frmViewBook";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bOOKBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.libraryDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.libraryDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bOOKBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.libraryDataSet3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bOOKBindingSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.libraryDataSet4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bOOKBindingSource3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private LibraryDataSet libraryDataSet;
        private System.Windows.Forms.BindingSource bOOKBindingSource;
        private LibraryDataSetTableAdapters.BOOKTableAdapter bOOKTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn bOOKIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iSBNDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tITLEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn bINDINGDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pUBLISHERDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn aUTHORDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pUBDATEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pRICEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pAGESDataGridViewTextBoxColumn;
        private LibraryDataSet1 libraryDataSet1;
        private System.Windows.Forms.BindingSource bOOKBindingSource1;
        private LibraryDataSet1TableAdapters.BOOKTableAdapter bOOKTableAdapter1;
        private LibraryDataSet3 libraryDataSet3;
        private System.Windows.Forms.BindingSource bOOKBindingSource2;
        private LibraryDataSet3TableAdapters.BOOKTableAdapter bOOKTableAdapter2;
        private LibraryDataSet4 libraryDataSet4;
        private System.Windows.Forms.BindingSource bOOKBindingSource3;
        private LibraryDataSet4TableAdapters.BOOKTableAdapter bOOKTableAdapter3;
    }
}