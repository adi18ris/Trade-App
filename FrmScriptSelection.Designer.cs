namespace TradeApp
{
    partial class FrmScriptSelection
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
            this.DgvScriptName = new System.Windows.Forms.DataGridView();
            this.ScriptNameSearch = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TxtSearch = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.LBoxScripts = new System.Windows.Forms.ListBox();
            this.BtnAddScript = new System.Windows.Forms.Button();
            this.LabSelScript = new System.Windows.Forms.Label();
            this.BtnRemove = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtComment = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TxtLowerLimit = new System.Windows.Forms.NumericUpDown();
            this.TxtUpperLimit = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.DgvScriptName)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TxtLowerLimit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtUpperLimit)).BeginInit();
            this.SuspendLayout();
            // 
            // DgvScriptName
            // 
            this.DgvScriptName.AllowUserToAddRows = false;
            this.DgvScriptName.AllowUserToDeleteRows = false;
            this.DgvScriptName.AllowUserToResizeRows = false;
            this.DgvScriptName.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvScriptName.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ScriptNameSearch,
            this.ID});
            this.DgvScriptName.Location = new System.Drawing.Point(13, 39);
            this.DgvScriptName.MultiSelect = false;
            this.DgvScriptName.Name = "DgvScriptName";
            this.DgvScriptName.ReadOnly = true;
            this.DgvScriptName.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvScriptName.ShowEditingIcon = false;
            this.DgvScriptName.Size = new System.Drawing.Size(196, 405);
            this.DgvScriptName.TabIndex = 0;
            this.DgvScriptName.SelectionChanged += new System.EventHandler(this.DgvScriptName_SelectionChanged);
            // 
            // ScriptNameSearch
            // 
            this.ScriptNameSearch.DataPropertyName = "ScriptsName";
            this.ScriptNameSearch.HeaderText = "Script Name";
            this.ScriptNameSearch.Name = "ScriptNameSearch";
            this.ScriptNameSearch.ReadOnly = true;
            this.ScriptNameSearch.Width = 175;
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ScriptId";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            // 
            // TxtSearch
            // 
            this.TxtSearch.Location = new System.Drawing.Point(58, 13);
            this.TxtSearch.Name = "TxtSearch";
            this.TxtSearch.Size = new System.Drawing.Size(151, 20);
            this.TxtSearch.TabIndex = 1;
            this.TxtSearch.TextChanged += new System.EventHandler(this.TxtSearch_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Search :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(217, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Script:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(216, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Upper Limit:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(216, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Lower Limit:";
            // 
            // LBoxScripts
            // 
            this.LBoxScripts.FormattingEnabled = true;
            this.LBoxScripts.Location = new System.Drawing.Point(219, 210);
            this.LBoxScripts.Name = "LBoxScripts";
            this.LBoxScripts.Size = new System.Drawing.Size(193, 199);
            this.LBoxScripts.TabIndex = 8;
            // 
            // BtnAddScript
            // 
            this.BtnAddScript.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAddScript.Location = new System.Drawing.Point(219, 176);
            this.BtnAddScript.Name = "BtnAddScript";
            this.BtnAddScript.Size = new System.Drawing.Size(193, 29);
            this.BtnAddScript.TabIndex = 9;
            this.BtnAddScript.Text = "Add Script";
            this.BtnAddScript.UseVisualStyleBackColor = true;
            this.BtnAddScript.Click += new System.EventHandler(this.BtnAddScript_Click);
            // 
            // LabSelScript
            // 
            this.LabSelScript.AutoSize = true;
            this.LabSelScript.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabSelScript.Location = new System.Drawing.Point(251, 17);
            this.LabSelScript.Name = "LabSelScript";
            this.LabSelScript.Size = new System.Drawing.Size(91, 13);
            this.LabSelScript.TabIndex = 10;
            this.LabSelScript.Text = "None Selected";
            // 
            // BtnRemove
            // 
            this.BtnRemove.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnRemove.Location = new System.Drawing.Point(219, 414);
            this.BtnRemove.Name = "BtnRemove";
            this.BtnRemove.Size = new System.Drawing.Size(193, 29);
            this.BtnRemove.TabIndex = 11;
            this.BtnRemove.Text = "Remove Script";
            this.BtnRemove.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtComment);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.TxtLowerLimit);
            this.groupBox1.Controls.Add(this.TxtUpperLimit);
            this.groupBox1.Location = new System.Drawing.Point(4, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(417, 450);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            // 
            // txtComment
            // 
            this.txtComment.Location = new System.Drawing.Point(292, 117);
            this.txtComment.Multiline = true;
            this.txtComment.Name = "txtComment";
            this.txtComment.Size = new System.Drawing.Size(116, 50);
            this.txtComment.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(216, 117);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Comments:";
            // 
            // TxtLowerLimit
            // 
            this.TxtLowerLimit.Location = new System.Drawing.Point(292, 83);
            this.TxtLowerLimit.Name = "TxtLowerLimit";
            this.TxtLowerLimit.Size = new System.Drawing.Size(120, 20);
            this.TxtLowerLimit.TabIndex = 1;
            // 
            // TxtUpperLimit
            // 
            this.TxtUpperLimit.Location = new System.Drawing.Point(292, 44);
            this.TxtUpperLimit.Name = "TxtUpperLimit";
            this.TxtUpperLimit.Size = new System.Drawing.Size(120, 20);
            this.TxtUpperLimit.TabIndex = 0;
            // 
            // FrmScriptSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(425, 456);
            this.Controls.Add(this.BtnRemove);
            this.Controls.Add(this.LabSelScript);
            this.Controls.Add(this.BtnAddScript);
            this.Controls.Add(this.LBoxScripts);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TxtSearch);
            this.Controls.Add(this.DgvScriptName);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmScriptSelection";
            this.Text = "FrmScriptSelection";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmScriptSelection_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.DgvScriptName)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TxtLowerLimit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtUpperLimit)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DgvScriptName;
        private System.Windows.Forms.TextBox TxtSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox LBoxScripts;
        private System.Windows.Forms.Button BtnAddScript;
        private System.Windows.Forms.Label LabSelScript;
        private System.Windows.Forms.Button BtnRemove;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown TxtLowerLimit;
        private System.Windows.Forms.NumericUpDown TxtUpperLimit;
        private System.Windows.Forms.TextBox txtComment;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridViewTextBoxColumn ScriptNameSearch;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
    }
}