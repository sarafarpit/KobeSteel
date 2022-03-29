namespace ICADConnectorPOC
{
    partial class ModelSearch1
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.dwnldBtn = new System.Windows.Forms.Button();
            this.cnclBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(861, 412);
            this.panel1.TabIndex = 0;
            // 
            // dwnldBtn
            // 
            this.dwnldBtn.Location = new System.Drawing.Point(561, 439);
            this.dwnldBtn.Name = "dwnldBtn";
            this.dwnldBtn.Size = new System.Drawing.Size(110, 23);
            this.dwnldBtn.TabIndex = 1;
            this.dwnldBtn.Text = "Download";
            this.dwnldBtn.UseVisualStyleBackColor = true;
            this.dwnldBtn.Click += new System.EventHandler(this.dwnldBtn_Click);
            // 
            // cnclBtn
            // 
            this.cnclBtn.Location = new System.Drawing.Point(700, 439);
            this.cnclBtn.Name = "cnclBtn";
            this.cnclBtn.Size = new System.Drawing.Size(75, 23);
            this.cnclBtn.TabIndex = 2;
            this.cnclBtn.Text = "Cancel";
            this.cnclBtn.UseVisualStyleBackColor = true;
            this.cnclBtn.Click += new System.EventHandler(this.cnclBtn_Click);
            // 
            // ModelSearch1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(885, 474);
            this.Controls.Add(this.cnclBtn);
            this.Controls.Add(this.dwnldBtn);
            this.Controls.Add(this.panel1);
            this.Name = "ModelSearch1";
            this.Text = "ModelSearch";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
            this.Load += new System.EventHandler(this.ModelSearch1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button dwnldBtn;
        private System.Windows.Forms.Button cnclBtn;
    }
}