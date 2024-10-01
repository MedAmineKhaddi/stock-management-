
namespace Systeme_GS.PL
{
    partial class USER_Liste_Client
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.textRecherche = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.comboRecherche = new System.Windows.Forms.ComboBox();
            this.dvgclient = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnsupprimerClient = new System.Windows.Forms.Button();
            this.btnmodifierClient = new System.Windows.Forms.Button();
            this.btnajouterClient = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dvgclient)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.panel1.Location = new System.Drawing.Point(25, 74);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1076, 3);
            this.panel1.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.panel2.Location = new System.Drawing.Point(25, 137);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1076, 3);
            this.panel2.TabIndex = 4;
            // 
            // textRecherche
            // 
            this.textRecherche.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textRecherche.BackColor = System.Drawing.SystemColors.Control;
            this.textRecherche.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textRecherche.Font = new System.Drawing.Font("Segoe UI Light", 16.25F);
            this.textRecherche.ForeColor = System.Drawing.Color.LightGray;
            this.textRecherche.Location = new System.Drawing.Point(658, 87);
            this.textRecherche.Multiline = true;
            this.textRecherche.Name = "textRecherche";
            this.textRecherche.Size = new System.Drawing.Size(300, 32);
            this.textRecherche.TabIndex = 5;
            this.textRecherche.Text = "Recherche";
            this.textRecherche.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textRecherche.TextChanged += new System.EventHandler(this.textRecherche_TextChanged);
            this.textRecherche.Enter += new System.EventHandler(this.textRecherche_Enter);
            this.textRecherche.Leave += new System.EventHandler(this.textRecherche_Leave);
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.panel3.Location = new System.Drawing.Point(657, 121);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(300, 3);
            this.panel3.TabIndex = 6;
            // 
            // comboRecherche
            // 
            this.comboRecherche.BackColor = System.Drawing.Color.White;
            this.comboRecherche.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboRecherche.Font = new System.Drawing.Font("Segoe UI Light", 14.25F);
            this.comboRecherche.ForeColor = System.Drawing.Color.Black;
            this.comboRecherche.FormattingEnabled = true;
            this.comboRecherche.Items.AddRange(new object[] {
            "Nom",
            "Prenom",
            "Adresse",
            "Telephone",
            "Email",
            "Pays",
            "Ville"});
            this.comboRecherche.Location = new System.Drawing.Point(242, 91);
            this.comboRecherche.Name = "comboRecherche";
            this.comboRecherche.Size = new System.Drawing.Size(268, 33);
            this.comboRecherche.TabIndex = 7;
            this.comboRecherche.SelectedIndexChanged += new System.EventHandler(this.comboRecherche_SelectedIndexChanged);
            // 
            // dvgclient
            // 
            this.dvgclient.AllowUserToAddRows = false;
            this.dvgclient.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dvgclient.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dvgclient.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dvgclient.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(143)))), ((int)(((byte)(118)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI Light", 11.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dvgclient.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dvgclient.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvgclient.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column9,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dvgclient.DefaultCellStyle = dataGridViewCellStyle2;
            this.dvgclient.EnableHeadersVisualStyles = false;
            this.dvgclient.Location = new System.Drawing.Point(3, 158);
            this.dvgclient.Name = "dvgclient";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dvgclient.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dvgclient.RowHeadersVisible = false;
            this.dvgclient.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dvgclient.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dvgclient.Size = new System.Drawing.Size(1131, 559);
            this.dvgclient.TabIndex = 8;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Select";
            this.Column1.Name = "Column1";
            // 
            // Column9
            // 
            this.Column9.HeaderText = "Id";
            this.Column9.Name = "Column9";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Nom";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Prenom";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Adresse";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Telephone";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Email";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Pays";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "Ville";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            // 
            // btnsupprimerClient
            // 
            this.btnsupprimerClient.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnsupprimerClient.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(143)))), ((int)(((byte)(118)))));
            this.btnsupprimerClient.FlatAppearance.BorderSize = 0;
            this.btnsupprimerClient.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(222)))), ((int)(((byte)(184)))));
            this.btnsupprimerClient.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnsupprimerClient.Font = new System.Drawing.Font("Segoe UI Light", 18.25F);
            this.btnsupprimerClient.ForeColor = System.Drawing.Color.White;
            this.btnsupprimerClient.Image = global::Systeme_GS.Properties.Resources.remove_user;
            this.btnsupprimerClient.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnsupprimerClient.Location = new System.Drawing.Point(781, 13);
            this.btnsupprimerClient.Name = "btnsupprimerClient";
            this.btnsupprimerClient.Size = new System.Drawing.Size(320, 53);
            this.btnsupprimerClient.TabIndex = 2;
            this.btnsupprimerClient.Text = "Supprimer";
            this.btnsupprimerClient.UseVisualStyleBackColor = false;
            this.btnsupprimerClient.Click += new System.EventHandler(this.btnsupprimerClient_Click);
            // 
            // btnmodifierClient
            // 
            this.btnmodifierClient.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnmodifierClient.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(143)))), ((int)(((byte)(118)))));
            this.btnmodifierClient.FlatAppearance.BorderSize = 0;
            this.btnmodifierClient.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(222)))), ((int)(((byte)(184)))));
            this.btnmodifierClient.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnmodifierClient.Font = new System.Drawing.Font("Segoe UI Light", 18.25F);
            this.btnmodifierClient.ForeColor = System.Drawing.Color.White;
            this.btnmodifierClient.Image = global::Systeme_GS.Properties.Resources.user_profile;
            this.btnmodifierClient.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnmodifierClient.Location = new System.Drawing.Point(401, 13);
            this.btnmodifierClient.Name = "btnmodifierClient";
            this.btnmodifierClient.Size = new System.Drawing.Size(320, 53);
            this.btnmodifierClient.TabIndex = 1;
            this.btnmodifierClient.Text = "Modifier";
            this.btnmodifierClient.UseVisualStyleBackColor = false;
            this.btnmodifierClient.Click += new System.EventHandler(this.btnmodifierClient_Click);
            // 
            // btnajouterClient
            // 
            this.btnajouterClient.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(143)))), ((int)(((byte)(118)))));
            this.btnajouterClient.FlatAppearance.BorderSize = 0;
            this.btnajouterClient.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(222)))), ((int)(((byte)(184)))));
            this.btnajouterClient.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnajouterClient.Font = new System.Drawing.Font("Segoe UI Light", 18.25F);
            this.btnajouterClient.ForeColor = System.Drawing.Color.White;
            this.btnajouterClient.Image = global::Systeme_GS.Properties.Resources.add_user3;
            this.btnajouterClient.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnajouterClient.Location = new System.Drawing.Point(25, 13);
            this.btnajouterClient.Name = "btnajouterClient";
            this.btnajouterClient.Size = new System.Drawing.Size(320, 53);
            this.btnajouterClient.TabIndex = 0;
            this.btnajouterClient.Text = "Ajouter";
            this.btnajouterClient.UseVisualStyleBackColor = false;
            this.btnajouterClient.Click += new System.EventHandler(this.btnajouterClient_Click);
            // 
            // USER_Liste_Client
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dvgclient);
            this.Controls.Add(this.comboRecherche);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.textRecherche);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnsupprimerClient);
            this.Controls.Add(this.btnmodifierClient);
            this.Controls.Add(this.btnajouterClient);
            this.Name = "USER_Liste_Client";
            this.Size = new System.Drawing.Size(1137, 720);
            this.Load += new System.EventHandler(this.USER_Liste_Client_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dvgclient)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnmodifierClient;
        private System.Windows.Forms.Button btnsupprimerClient;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox textRecherche;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ComboBox comboRecherche;
        private System.Windows.Forms.DataGridView dvgclient;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        public System.Windows.Forms.Button btnajouterClient;
    }
}
