namespace Zabawki
{
    partial class Form1
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
            this.toyTypeCombo = new System.Windows.Forms.ComboBox();
            this.addButton = new System.Windows.Forms.Button();
            this.toyInstanceCombo = new System.Windows.Forms.ComboBox();
            this.controlsPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // toyTypeCombo
            // 
            this.toyTypeCombo.FormattingEnabled = true;
            this.toyTypeCombo.Location = new System.Drawing.Point(13, 12);
            this.toyTypeCombo.Name = "toyTypeCombo";
            this.toyTypeCombo.Size = new System.Drawing.Size(121, 21);
            this.toyTypeCombo.TabIndex = 0;
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(150, 10);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(75, 23);
            this.addButton.TabIndex = 1;
            this.addButton.Text = "Dodaj";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // toyInstanceCombo
            // 
            this.toyInstanceCombo.FormattingEnabled = true;
            this.toyInstanceCombo.Location = new System.Drawing.Point(13, 37);
            this.toyInstanceCombo.Name = "toyInstanceCombo";
            this.toyInstanceCombo.Size = new System.Drawing.Size(121, 21);
            this.toyInstanceCombo.TabIndex = 3;
            this.toyInstanceCombo.SelectionChangeCommitted += new System.EventHandler(this.toyInstanceCombo_SelectionChangeCommitted);
            // 
            // controlsPanel
            // 
            this.controlsPanel.Location = new System.Drawing.Point(13, 85);
            this.controlsPanel.Name = "controlsPanel";
            this.controlsPanel.Size = new System.Drawing.Size(200, 100);
            this.controlsPanel.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.controlsPanel);
            this.Controls.Add(this.toyInstanceCombo);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.toyTypeCombo);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox toyTypeCombo;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.ComboBox toyInstanceCombo;
        private System.Windows.Forms.FlowLayoutPanel controlsPanel;
    }
}

