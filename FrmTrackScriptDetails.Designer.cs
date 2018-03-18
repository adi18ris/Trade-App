namespace TradeApp
{
    partial class FrmTrackScriptDetails
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTrackScriptDetails));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.TxtComments = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.CmbMCSentiment = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.TxtTargetPrice = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.TxtRatio = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.TxtBasePrice = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.DtResultDate = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.CmbDivident = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.TxtNetSell = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.TxtRevenue = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.TxtNetProfit = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.CmbBlockDeal = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.CmbHGrowing = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.CmbBulkDeal = new System.Windows.Forms.ComboBox();
            this.TxtPHolding = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.BtnAdd = new System.Windows.Forms.Button();
            this.LabScriptName = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TxtTargetPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtRatio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtBasePrice)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TxtNetSell)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtRevenue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtNetProfit)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TxtPHolding)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.TxtComments);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.groupBox1.Location = new System.Drawing.Point(12, 220);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(212, 122);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Comments";
            // 
            // TxtComments
            // 
            this.TxtComments.Location = new System.Drawing.Point(6, 19);
            this.TxtComments.Multiline = true;
            this.TxtComments.Name = "TxtComments";
            this.TxtComments.Size = new System.Drawing.Size(199, 91);
            this.TxtComments.TabIndex = 14;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.CmbMCSentiment);
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Controls.Add(this.TxtTargetPrice);
            this.groupBox4.Controls.Add(this.label12);
            this.groupBox4.Controls.Add(this.TxtRatio);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Controls.Add(this.TxtBasePrice);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.groupBox4.Location = new System.Drawing.Point(251, 187);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(222, 155);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Custom Analysis";
            // 
            // CmbMCSentiment
            // 
            this.CmbMCSentiment.FormattingEnabled = true;
            this.CmbMCSentiment.Items.AddRange(new object[] {
            "Very Good",
            "Good",
            "Neutral",
            "Bad"});
            this.CmbMCSentiment.Location = new System.Drawing.Point(95, 121);
            this.CmbMCSentiment.Name = "CmbMCSentiment";
            this.CmbMCSentiment.Size = new System.Drawing.Size(120, 21);
            this.CmbMCSentiment.TabIndex = 13;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.label13.Location = new System.Drawing.Point(6, 124);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(81, 13);
            this.label13.TabIndex = 15;
            this.label13.Text = "M/C Sentiment:";
            // 
            // TxtTargetPrice
            // 
            this.TxtTargetPrice.Location = new System.Drawing.Point(95, 86);
            this.TxtTargetPrice.Name = "TxtTargetPrice";
            this.TxtTargetPrice.Size = new System.Drawing.Size(120, 20);
            this.TxtTargetPrice.TabIndex = 12;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.label12.Location = new System.Drawing.Point(6, 88);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(68, 13);
            this.label12.TabIndex = 13;
            this.label12.Text = "Target Price:";
            // 
            // TxtRatio
            // 
            this.TxtRatio.Location = new System.Drawing.Point(95, 52);
            this.TxtRatio.Name = "TxtRatio";
            this.TxtRatio.Size = new System.Drawing.Size(120, 20);
            this.TxtRatio.TabIndex = 11;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.label11.Location = new System.Drawing.Point(6, 54);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(85, 13);
            this.label11.TabIndex = 11;
            this.label11.Text = "High/Low Ratio:";
            // 
            // TxtBasePrice
            // 
            this.TxtBasePrice.Location = new System.Drawing.Point(95, 19);
            this.TxtBasePrice.Name = "TxtBasePrice";
            this.TxtBasePrice.Size = new System.Drawing.Size(120, 20);
            this.TxtBasePrice.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.label1.Location = new System.Drawing.Point(4, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Base Price :";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.DtResultDate);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.CmbDivident);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.TxtNetSell);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.TxtRevenue);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.TxtNetProfit);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.groupBox3.Location = new System.Drawing.Point(10, 25);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(214, 188);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Results And Divident";
            // 
            // DtResultDate
            // 
            this.DtResultDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtResultDate.Location = new System.Drawing.Point(93, 155);
            this.DtResultDate.Name = "DtResultDate";
            this.DtResultDate.Size = new System.Drawing.Size(114, 20);
            this.DtResultDate.TabIndex = 5;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.label9.Location = new System.Drawing.Point(6, 157);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(66, 13);
            this.label9.TabIndex = 15;
            this.label9.Text = "Result Date:";
            // 
            // CmbDivident
            // 
            this.CmbDivident.FormattingEnabled = true;
            this.CmbDivident.Items.AddRange(new object[] {
            "YES",
            "NO"});
            this.CmbDivident.Location = new System.Drawing.Point(93, 122);
            this.CmbDivident.Name = "CmbDivident";
            this.CmbDivident.Size = new System.Drawing.Size(115, 21);
            this.CmbDivident.TabIndex = 4;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.label8.Location = new System.Drawing.Point(7, 126);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 13);
            this.label8.TabIndex = 13;
            this.label8.Text = "Divident:";
            // 
            // TxtNetSell
            // 
            this.TxtNetSell.Location = new System.Drawing.Point(94, 90);
            this.TxtNetSell.Name = "TxtNetSell";
            this.TxtNetSell.Size = new System.Drawing.Size(115, 20);
            this.TxtNetSell.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.label7.Location = new System.Drawing.Point(6, 92);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Net Sell:";
            // 
            // TxtRevenue
            // 
            this.TxtRevenue.Location = new System.Drawing.Point(93, 58);
            this.TxtRevenue.Name = "TxtRevenue";
            this.TxtRevenue.Size = new System.Drawing.Size(115, 20);
            this.TxtRevenue.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.label6.Location = new System.Drawing.Point(7, 58);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Revenue:";
            // 
            // TxtNetProfit
            // 
            this.TxtNetProfit.Location = new System.Drawing.Point(93, 23);
            this.TxtNetProfit.Name = "TxtNetProfit";
            this.TxtNetProfit.Size = new System.Drawing.Size(115, 20);
            this.TxtNetProfit.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.label5.Location = new System.Drawing.Point(7, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Net Profit:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.CmbBlockDeal);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.CmbHGrowing);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.CmbBulkDeal);
            this.groupBox2.Controls.Add(this.TxtPHolding);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.groupBox2.Location = new System.Drawing.Point(251, 25);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(222, 150);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Holding Pattern";
            // 
            // CmbBlockDeal
            // 
            this.CmbBlockDeal.FormattingEnabled = true;
            this.CmbBlockDeal.Items.AddRange(new object[] {
            "YES",
            "NO"});
            this.CmbBlockDeal.Location = new System.Drawing.Point(94, 122);
            this.CmbBlockDeal.Name = "CmbBlockDeal";
            this.CmbBlockDeal.Size = new System.Drawing.Size(114, 21);
            this.CmbBlockDeal.TabIndex = 9;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.label10.Location = new System.Drawing.Point(7, 125);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(62, 13);
            this.label10.TabIndex = 10;
            this.label10.Text = "Block Deal:";
            // 
            // CmbHGrowing
            // 
            this.CmbHGrowing.FormattingEnabled = true;
            this.CmbHGrowing.Items.AddRange(new object[] {
            "YES",
            "NO"});
            this.CmbHGrowing.Location = new System.Drawing.Point(94, 53);
            this.CmbHGrowing.Name = "CmbHGrowing";
            this.CmbHGrowing.Size = new System.Drawing.Size(114, 21);
            this.CmbHGrowing.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.label4.Location = new System.Drawing.Point(5, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Holding Growing";
            // 
            // CmbBulkDeal
            // 
            this.CmbBulkDeal.FormattingEnabled = true;
            this.CmbBulkDeal.Items.AddRange(new object[] {
            "YES",
            "NO"});
            this.CmbBulkDeal.Location = new System.Drawing.Point(94, 88);
            this.CmbBulkDeal.Name = "CmbBulkDeal";
            this.CmbBulkDeal.Size = new System.Drawing.Size(114, 21);
            this.CmbBulkDeal.TabIndex = 8;
            // 
            // TxtPHolding
            // 
            this.TxtPHolding.Location = new System.Drawing.Point(94, 20);
            this.TxtPHolding.Name = "TxtPHolding";
            this.TxtPHolding.Size = new System.Drawing.Size(115, 20);
            this.TxtPHolding.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.label3.Location = new System.Drawing.Point(7, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Promoter holding";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.label2.Location = new System.Drawing.Point(7, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Bulk Deal:";
            // 
            // BtnCancel
            // 
            this.BtnCancel.Location = new System.Drawing.Point(12, 348);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(212, 23);
            this.BtnCancel.TabIndex = 16;
            this.BtnCancel.Text = "Cancel";
            this.BtnCancel.UseVisualStyleBackColor = true;
            // 
            // BtnAdd
            // 
            this.BtnAdd.Location = new System.Drawing.Point(251, 349);
            this.BtnAdd.Name = "BtnAdd";
            this.BtnAdd.Size = new System.Drawing.Size(222, 23);
            this.BtnAdd.TabIndex = 15;
            this.BtnAdd.Text = "Add";
            this.BtnAdd.UseVisualStyleBackColor = true;
            this.BtnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // LabScriptName
            // 
            this.LabScriptName.AutoSize = true;
            this.LabScriptName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabScriptName.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.LabScriptName.Location = new System.Drawing.Point(9, 6);
            this.LabScriptName.Name = "LabScriptName";
            this.LabScriptName.Size = new System.Drawing.Size(23, 13);
            this.LabScriptName.TabIndex = 0;
            this.LabScriptName.Text = "##";
            // 
            // FrmTrackScriptDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(480, 375);
            this.Controls.Add(this.LabScriptName);
            this.Controls.Add(this.BtnAdd);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmTrackScriptDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Track Script Details";
            this.Load += new System.EventHandler(this.FrmTrackScriptDetails_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TxtTargetPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtRatio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtBasePrice)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TxtNetSell)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtRevenue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtNetProfit)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TxtPHolding)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ComboBox CmbMCSentiment;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.NumericUpDown TxtTargetPrice;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.NumericUpDown TxtRatio;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown TxtBasePrice;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DateTimePicker DtResultDate;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox CmbDivident;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown TxtNetSell;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown TxtRevenue;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown TxtNetProfit;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox CmbBlockDeal;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox CmbHGrowing;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox CmbBulkDeal;
        private System.Windows.Forms.NumericUpDown TxtPHolding;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtComments;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.Button BtnAdd;
        private System.Windows.Forms.Label LabScriptName;
    }
}