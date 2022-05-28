
namespace B00ks.Customer
{
    partial class ReturnBook
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.searchbox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.dataGridViewdreturnbook = new System.Windows.Forms.DataGridView();
            this.lname = new System.Windows.Forms.TextBox();
            this.fname = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.title_cm = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.todate = new System.Windows.Forms.DateTimePicker();
            this.fromdate = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.latereturn = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.retn_btn = new System.Windows.Forms.Button();
            this.qty = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.labelnote = new System.Windows.Forms.Label();
            this.ids = new System.Windows.Forms.TextBox();
            this.isbn_rO = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewdreturnbook)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Retroica", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(28, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(230, 33);
            this.label1.TabIndex = 63;
            this.label1.Text = "Return Book";
            // 
            // searchbox
            // 
            this.searchbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchbox.Location = new System.Drawing.Point(120, 90);
            this.searchbox.Name = "searchbox";
            this.searchbox.Size = new System.Drawing.Size(254, 26);
            this.searchbox.TabIndex = 78;
            this.searchbox.TextChanged += new System.EventHandler(this.searchbox_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Retroica", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(31, 99);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(70, 17);
            this.label9.TabIndex = 77;
            this.label9.Text = "Search";
            // 
            // dataGridViewdreturnbook
            // 
            this.dataGridViewdreturnbook.AllowUserToAddRows = false;
            this.dataGridViewdreturnbook.AllowUserToDeleteRows = false;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(23)))), ((int)(((byte)(31)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(232)))));
            this.dataGridViewdreturnbook.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewdreturnbook.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewdreturnbook.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(23)))), ((int)(((byte)(31)))));
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(232)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewdreturnbook.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridViewdreturnbook.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(23)))), ((int)(((byte)(31)))));
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(232)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewdreturnbook.DefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridViewdreturnbook.Location = new System.Drawing.Point(34, 140);
            this.dataGridViewdreturnbook.Margin = new System.Windows.Forms.Padding(3, 3, 3, 20);
            this.dataGridViewdreturnbook.Name = "dataGridViewdreturnbook";
            this.dataGridViewdreturnbook.ReadOnly = true;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(23)))), ((int)(((byte)(31)))));
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(232)))));
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewdreturnbook.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dataGridViewdreturnbook.RowHeadersWidth = 62;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(23)))), ((int)(((byte)(31)))));
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(231)))));
            this.dataGridViewdreturnbook.RowsDefaultCellStyle = dataGridViewCellStyle10;
            this.dataGridViewdreturnbook.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewdreturnbook.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(23)))), ((int)(((byte)(31)))));
            this.dataGridViewdreturnbook.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(232)))));
            this.dataGridViewdreturnbook.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
            this.dataGridViewdreturnbook.RowTemplate.Height = 28;
            this.dataGridViewdreturnbook.Size = new System.Drawing.Size(721, 245);
            this.dataGridViewdreturnbook.TabIndex = 76;
            this.dataGridViewdreturnbook.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewdreturnbook_CellClick);
            this.dataGridViewdreturnbook.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewdreturnbook_CellContentClick);
            this.dataGridViewdreturnbook.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewdreturnbook_CellContentDoubleClick);
            this.dataGridViewdreturnbook.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewdreturnbook_CellDoubleClick);
            // 
            // lname
            // 
            this.lname.Enabled = false;
            this.lname.Location = new System.Drawing.Point(39, 488);
            this.lname.Name = "lname";
            this.lname.Size = new System.Drawing.Size(339, 26);
            this.lname.TabIndex = 86;
            // 
            // fname
            // 
            this.fname.Enabled = false;
            this.fname.Location = new System.Drawing.Point(38, 428);
            this.fname.Name = "fname";
            this.fname.Size = new System.Drawing.Size(339, 26);
            this.fname.TabIndex = 85;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Retroica", 9.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(34, 464);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 21);
            this.label2.TabIndex = 84;
            this.label2.Text = "Last Name";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Retroica", 9.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(34, 404);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(130, 21);
            this.label6.TabIndex = 83;
            this.label6.Text = "First Name";
            // 
            // title_cm
            // 
            this.title_cm.Enabled = false;
            this.title_cm.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.title_cm.FormattingEnabled = true;
            this.title_cm.Location = new System.Drawing.Point(38, 548);
            this.title_cm.Name = "title_cm";
            this.title_cm.Size = new System.Drawing.Size(340, 28);
            this.title_cm.TabIndex = 88;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Retroica", 9.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(34, 524);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 21);
            this.label3.TabIndex = 87;
            this.label3.Text = "Title";
            // 
            // todate
            // 
            this.todate.CustomFormat = "yyyy-MM-dd";
            this.todate.Enabled = false;
            this.todate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.todate.Location = new System.Drawing.Point(599, 426);
            this.todate.Name = "todate";
            this.todate.Size = new System.Drawing.Size(159, 26);
            this.todate.TabIndex = 90;
            // 
            // fromdate
            // 
            this.fromdate.CustomFormat = "yyyy-MM-dd";
            this.fromdate.Enabled = false;
            this.fromdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.fromdate.Location = new System.Drawing.Point(416, 426);
            this.fromdate.Name = "fromdate";
            this.fromdate.Size = new System.Drawing.Size(155, 26);
            this.fromdate.TabIndex = 89;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Retroica", 9.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(577, 428);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(16, 21);
            this.label5.TabIndex = 91;
            this.label5.Text = "-";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Retroica", 9.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(412, 402);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 21);
            this.label4.TabIndex = 92;
            this.label4.Text = "Start";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Retroica", 9.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(595, 402);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 21);
            this.label7.TabIndex = 93;
            this.label7.Text = "End";
            // 
            // latereturn
            // 
            this.latereturn.Enabled = false;
            this.latereturn.Location = new System.Drawing.Point(416, 488);
            this.latereturn.Name = "latereturn";
            this.latereturn.Size = new System.Drawing.Size(227, 26);
            this.latereturn.TabIndex = 95;
            this.latereturn.TextChanged += new System.EventHandler(this.latereturn_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Retroica", 9.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(412, 464);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(92, 21);
            this.label8.TabIndex = 94;
            this.label8.Text = "Charge";
            // 
            // retn_btn
            // 
            this.retn_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(169)))), ((int)(((byte)(22)))));
            this.retn_btn.FlatAppearance.BorderSize = 0;
            this.retn_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.retn_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.retn_btn.ForeColor = System.Drawing.Color.Black;
            this.retn_btn.Location = new System.Drawing.Point(599, 606);
            this.retn_btn.Name = "retn_btn";
            this.retn_btn.Size = new System.Drawing.Size(156, 41);
            this.retn_btn.TabIndex = 96;
            this.retn_btn.Text = "Return Book";
            this.retn_btn.UseVisualStyleBackColor = false;
            this.retn_btn.Click += new System.EventHandler(this.retn_btn_Click);
            // 
            // qty
            // 
            this.qty.Enabled = false;
            this.qty.Location = new System.Drawing.Point(662, 488);
            this.qty.Name = "qty";
            this.qty.Size = new System.Drawing.Size(96, 26);
            this.qty.TabIndex = 98;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Retroica", 9.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(657, 464);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(51, 21);
            this.label10.TabIndex = 97;
            this.label10.Text = "Qty";
            // 
            // labelnote
            // 
            this.labelnote.AutoSize = true;
            this.labelnote.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelnote.ForeColor = System.Drawing.Color.Red;
            this.labelnote.Location = new System.Drawing.Point(34, 684);
            this.labelnote.Name = "labelnote";
            this.labelnote.Size = new System.Drawing.Size(67, 20);
            this.labelnote.TabIndex = 99;
            this.labelnote.Text = "label11";
            // 
            // ids
            // 
            this.ids.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ids.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ids.Location = new System.Drawing.Point(702, 37);
            this.ids.Name = "ids";
            this.ids.ReadOnly = true;
            this.ids.Size = new System.Drawing.Size(53, 26);
            this.ids.TabIndex = 100;
            // 
            // isbn_rO
            // 
            this.isbn_rO.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.isbn_rO.FormattingEnabled = true;
            this.isbn_rO.Location = new System.Drawing.Point(39, 606);
            this.isbn_rO.Name = "isbn_rO";
            this.isbn_rO.Size = new System.Drawing.Size(340, 28);
            this.isbn_rO.TabIndex = 102;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Retroica", 9.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(35, 582);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(61, 21);
            this.label11.TabIndex = 101;
            this.label11.Text = "ISBN";
            // 
            // ReturnBook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(23)))), ((int)(((byte)(31)))));
            this.ClientSize = new System.Drawing.Size(794, 724);
            this.Controls.Add(this.isbn_rO);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.ids);
            this.Controls.Add(this.labelnote);
            this.Controls.Add(this.qty);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.retn_btn);
            this.Controls.Add(this.latereturn);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.todate);
            this.Controls.Add(this.fromdate);
            this.Controls.Add(this.title_cm);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lname);
            this.Controls.Add(this.fname);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.searchbox);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.dataGridViewdreturnbook);
            this.Controls.Add(this.label1);
            this.Name = "ReturnBook";
            this.Text = "ReturnBook";
            this.Load += new System.EventHandler(this.ReturnBook_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewdreturnbook)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox searchbox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridView dataGridViewdreturnbook;
        private System.Windows.Forms.TextBox lname;
        private System.Windows.Forms.TextBox fname;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox title_cm;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker todate;
        private System.Windows.Forms.DateTimePicker fromdate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox latereturn;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button retn_btn;
        private System.Windows.Forms.TextBox qty;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label labelnote;
        private System.Windows.Forms.TextBox ids;
        private System.Windows.Forms.ComboBox isbn_rO;
        private System.Windows.Forms.Label label11;
    }
}