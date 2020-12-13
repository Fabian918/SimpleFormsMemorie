namespace Memory
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.memoriePanel = new System.Windows.Forms.Panel();
            this.lblPunkteStandanzeigen = new System.Windows.Forms.Label();
            this.panelPunkte = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Enabled = false;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(12, 12);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(184, 21);
            this.comboBox1.TabIndex = 0;
            // 
            // memoriePanel
            // 
            this.memoriePanel.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.memoriePanel.Location = new System.Drawing.Point(264, 12);
            this.memoriePanel.Name = "memoriePanel";
            this.memoriePanel.Size = new System.Drawing.Size(935, 585);
            this.memoriePanel.TabIndex = 1;
            // 
            // lblPunkteStandanzeigen
            // 
            this.lblPunkteStandanzeigen.AutoSize = true;
            this.lblPunkteStandanzeigen.Location = new System.Drawing.Point(12, 51);
            this.lblPunkteStandanzeigen.Name = "lblPunkteStandanzeigen";
            this.lblPunkteStandanzeigen.Size = new System.Drawing.Size(0, 13);
            this.lblPunkteStandanzeigen.TabIndex = 2;
            // 
            // panelPunkte
            // 
            this.panelPunkte.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panelPunkte.Location = new System.Drawing.Point(-2, 94);
            this.panelPunkte.Name = "panelPunkte";
            this.panelPunkte.Size = new System.Drawing.Size(260, 503);
            this.panelPunkte.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1211, 609);
            this.Controls.Add(this.panelPunkte);
            this.Controls.Add(this.lblPunkteStandanzeigen);
            this.Controls.Add(this.memoriePanel);
            this.Controls.Add(this.comboBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Panel memoriePanel;
        private System.Windows.Forms.Label lblPunkteStandanzeigen;
        private System.Windows.Forms.FlowLayoutPanel panelPunkte;
    }
}

