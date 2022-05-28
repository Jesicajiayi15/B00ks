
namespace B00ks.Customer
{
    partial class RentBook
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label4 = new System.Windows.Forms.Label();
            this.todate = new System.Windows.Forms.DateTimePicker();
            this.fromdate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.searchbox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.dataGridViewdrentbook = new System.Windows.Forms.DataGridView();
            this.rnt_box = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.cncl_btn = new System.Windows.Forms.Button();
            this.canclall_btn = new System.Windows.Forms.Button();
            this.ids = new System.Windows.Forms.TextBox();
            this.fname = new System.Windows.Forms.TextBox();
            this.lname = new System.Windows.Forms.TextBox();
            this.phone = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.iDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.titleDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iSBNDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qtyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fromDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rentRecieptDataBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rentBookDataBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewdrentbook)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rentRecieptDataBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rentBookDataBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Retroica", 9.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(409, 153);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(166, 21);
            this.label4.TabIndex = 71;
            this.label4.Text = "Rent Duration";
            // 
            // todate
            // 
            this.todate.CustomFormat = "yyyy-MM-dd";
            this.todate.Enabled = false;
            this.todate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.todate.Location = new System.Drawing.Point(596, 179);
            this.todate.Name = "todate";
            this.todate.Size = new System.Drawing.Size(159, 26);
            this.todate.TabIndex = 70;
            // 
            // fromdate
            // 
            this.fromdate.CustomFormat = "yyyy-MM-dd";
            this.fromdate.Enabled = false;
            this.fromdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.fromdate.Location = new System.Drawing.Point(413, 179);
            this.fromdate.Name = "fromdate";
            this.fromdate.Size = new System.Drawing.Size(155, 26);
            this.fromdate.TabIndex = 69;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Retroica", 9.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(30, 157);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 21);
            this.label2.TabIndex = 65;
            this.label2.Text = "Last Name";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Retroica", 9.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(30, 97);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(130, 21);
            this.label6.TabIndex = 63;
            this.label6.Text = "First Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Retroica", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(28, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(193, 33);
            this.label1.TabIndex = 62;
            this.label1.Text = "Rent Book";
            // 
            // searchbox
            // 
            this.searchbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchbox.Location = new System.Drawing.Point(120, 279);
            this.searchbox.Name = "searchbox";
            this.searchbox.Size = new System.Drawing.Size(254, 26);
            this.searchbox.TabIndex = 75;
            this.searchbox.TextChanged += new System.EventHandler(this.searchbox_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Retroica", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(31, 288);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(70, 17);
            this.label9.TabIndex = 74;
            this.label9.Text = "Search";
            // 
            // dataGridViewdrentbook
            // 
            this.dataGridViewdrentbook.AllowUserToAddRows = false;
            this.dataGridViewdrentbook.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(23)))), ((int)(((byte)(31)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(232)))));
            this.dataGridViewdrentbook.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewdrentbook.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewdrentbook.AutoGenerateColumns = false;
            this.dataGridViewdrentbook.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(23)))), ((int)(((byte)(31)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(232)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewdrentbook.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewdrentbook.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewdrentbook.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDDataGridViewTextBoxColumn,
            this.titleDataGridViewTextBoxColumn,
            this.iSBNDataGridViewTextBoxColumn,
            this.qtyDataGridViewTextBoxColumn,
            this.fromDateDataGridViewTextBoxColumn,
            this.toDateDataGridViewTextBoxColumn});
            this.dataGridViewdrentbook.DataSource = this.rentRecieptDataBindingSource;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(23)))), ((int)(((byte)(31)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(232)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewdrentbook.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewdrentbook.Location = new System.Drawing.Point(34, 329);
            this.dataGridViewdrentbook.Margin = new System.Windows.Forms.Padding(3, 3, 3, 20);
            this.dataGridViewdrentbook.Name = "dataGridViewdrentbook";
            this.dataGridViewdrentbook.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(23)))), ((int)(((byte)(31)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(232)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewdrentbook.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewdrentbook.RowHeadersWidth = 62;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(23)))), ((int)(((byte)(31)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(231)))));
            this.dataGridViewdrentbook.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewdrentbook.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewdrentbook.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(23)))), ((int)(((byte)(31)))));
            this.dataGridViewdrentbook.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(232)))));
            this.dataGridViewdrentbook.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
            this.dataGridViewdrentbook.RowTemplate.Height = 28;
            this.dataGridViewdrentbook.Size = new System.Drawing.Size(721, 308);
            this.dataGridViewdrentbook.TabIndex = 73;
            this.dataGridViewdrentbook.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewdrentbook_CellClick);
            this.dataGridViewdrentbook.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewdrentbook_CellContentClick);
            this.dataGridViewdrentbook.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewdrentbook_CellContentDoubleClick);
            this.dataGridViewdrentbook.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewdrentbook_CellDoubleClick);
            // 
            // rnt_box
            // 
            this.rnt_box.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(150)))), ((int)(((byte)(35)))));
            this.rnt_box.FlatAppearance.BorderSize = 0;
            this.rnt_box.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rnt_box.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rnt_box.ForeColor = System.Drawing.Color.White;
            this.rnt_box.Location = new System.Drawing.Point(599, 226);
            this.rnt_box.Name = "rnt_box";
            this.rnt_box.Size = new System.Drawing.Size(156, 41);
            this.rnt_box.TabIndex = 76;
            this.rnt_box.Text = "Rent";
            this.rnt_box.UseVisualStyleBackColor = false;
            this.rnt_box.Click += new System.EventHandler(this.rnt_box_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Retroica", 9.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(575, 179);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(16, 21);
            this.label5.TabIndex = 77;
            this.label5.Text = "-";
            // 
            // cncl_btn
            // 
            this.cncl_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(167)))));
            this.cncl_btn.FlatAppearance.BorderSize = 0;
            this.cncl_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cncl_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cncl_btn.ForeColor = System.Drawing.Color.White;
            this.cncl_btn.Location = new System.Drawing.Point(218, 660);
            this.cncl_btn.Name = "cncl_btn";
            this.cncl_btn.Size = new System.Drawing.Size(156, 41);
            this.cncl_btn.TabIndex = 79;
            this.cncl_btn.Text = "Cancel";
            this.cncl_btn.UseVisualStyleBackColor = false;
            this.cncl_btn.Click += new System.EventHandler(this.cncl_btn_Click);
            // 
            // canclall_btn
            // 
            this.canclall_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(0)))), ((int)(((byte)(26)))));
            this.canclall_btn.FlatAppearance.BorderSize = 0;
            this.canclall_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.canclall_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.canclall_btn.ForeColor = System.Drawing.Color.White;
            this.canclall_btn.Location = new System.Drawing.Point(35, 660);
            this.canclall_btn.Name = "canclall_btn";
            this.canclall_btn.Size = new System.Drawing.Size(156, 41);
            this.canclall_btn.TabIndex = 78;
            this.canclall_btn.Text = "Cancel All";
            this.canclall_btn.UseVisualStyleBackColor = false;
            this.canclall_btn.Click += new System.EventHandler(this.canclall_btn_Click);
            // 
            // ids
            // 
            this.ids.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ids.Location = new System.Drawing.Point(702, 35);
            this.ids.Name = "ids";
            this.ids.ReadOnly = true;
            this.ids.Size = new System.Drawing.Size(53, 26);
            this.ids.TabIndex = 80;
            // 
            // fname
            // 
            this.fname.Location = new System.Drawing.Point(34, 121);
            this.fname.Name = "fname";
            this.fname.Size = new System.Drawing.Size(339, 26);
            this.fname.TabIndex = 81;
            // 
            // lname
            // 
            this.lname.Location = new System.Drawing.Point(35, 181);
            this.lname.Name = "lname";
            this.lname.Size = new System.Drawing.Size(339, 26);
            this.lname.TabIndex = 82;
            // 
            // phone
            // 
            this.phone.Location = new System.Drawing.Point(413, 121);
            this.phone.Name = "phone";
            this.phone.Size = new System.Drawing.Size(339, 26);
            this.phone.TabIndex = 84;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Retroica", 9.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(409, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(174, 21);
            this.label3.TabIndex = 83;
            this.label3.Text = "Phone Number";
            // 
            // iDDataGridViewTextBoxColumn
            // 
            this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn.HeaderText = "ID";
            this.iDDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
            this.iDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // titleDataGridViewTextBoxColumn
            // 
            this.titleDataGridViewTextBoxColumn.DataPropertyName = "Title";
            this.titleDataGridViewTextBoxColumn.HeaderText = "Title";
            this.titleDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.titleDataGridViewTextBoxColumn.Name = "titleDataGridViewTextBoxColumn";
            this.titleDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // iSBNDataGridViewTextBoxColumn
            // 
            this.iSBNDataGridViewTextBoxColumn.DataPropertyName = "ISBN";
            this.iSBNDataGridViewTextBoxColumn.HeaderText = "ISBN";
            this.iSBNDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.iSBNDataGridViewTextBoxColumn.Name = "iSBNDataGridViewTextBoxColumn";
            this.iSBNDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // qtyDataGridViewTextBoxColumn
            // 
            this.qtyDataGridViewTextBoxColumn.DataPropertyName = "Qty";
            this.qtyDataGridViewTextBoxColumn.HeaderText = "Qty";
            this.qtyDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.qtyDataGridViewTextBoxColumn.Name = "qtyDataGridViewTextBoxColumn";
            this.qtyDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // fromDateDataGridViewTextBoxColumn
            // 
            this.fromDateDataGridViewTextBoxColumn.DataPropertyName = "From_Date";
            this.fromDateDataGridViewTextBoxColumn.HeaderText = "From_Date";
            this.fromDateDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.fromDateDataGridViewTextBoxColumn.Name = "fromDateDataGridViewTextBoxColumn";
            this.fromDateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // toDateDataGridViewTextBoxColumn
            // 
            this.toDateDataGridViewTextBoxColumn.DataPropertyName = "To_Date";
            this.toDateDataGridViewTextBoxColumn.HeaderText = "To_Date";
            this.toDateDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.toDateDataGridViewTextBoxColumn.Name = "toDateDataGridViewTextBoxColumn";
            this.toDateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // rentRecieptDataBindingSource
            // 
            this.rentRecieptDataBindingSource.DataSource = typeof(B00ks.Customer.Classes.RentReciept_Data);
            // 
            // rentBookDataBindingSource
            // 
            this.rentBookDataBindingSource.DataSource = typeof(B00ks.Customer.Classes.Rent_Book_Data);
            // 
            // RentBook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(23)))), ((int)(((byte)(31)))));
            this.ClientSize = new System.Drawing.Size(794, 724);
            this.Controls.Add(this.phone);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lname);
            this.Controls.Add(this.fname);
            this.Controls.Add(this.ids);
            this.Controls.Add(this.cncl_btn);
            this.Controls.Add(this.canclall_btn);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.rnt_box);
            this.Controls.Add(this.searchbox);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.dataGridViewdrentbook);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.todate);
            this.Controls.Add(this.fromdate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label1);
            this.Name = "RentBook";
            this.Text = "RentBook";
            this.Load += new System.EventHandler(this.RentBook_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewdrentbook)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rentRecieptDataBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rentBookDataBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker todate;
        private System.Windows.Forms.DateTimePicker fromdate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox searchbox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridView dataGridViewdrentbook;
        private System.Windows.Forms.Button rnt_box;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button cncl_btn;
        private System.Windows.Forms.Button canclall_btn;
        private System.Windows.Forms.TextBox ids;
        private System.Windows.Forms.TextBox fname;
        private System.Windows.Forms.TextBox lname;
        private System.Windows.Forms.TextBox phone;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn titleDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iSBNDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn qtyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fromDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn toDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource rentBookDataBindingSource;
        private System.Windows.Forms.BindingSource rentRecieptDataBindingSource;
    }
}