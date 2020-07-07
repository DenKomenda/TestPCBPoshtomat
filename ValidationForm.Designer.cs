namespace Modbus_Poll_CS
{
    partial class myValidation
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
            this.btnCloseMyValidation = new System.Windows.Forms.Button();
            this.txtBoxmyValdation = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnCloseMyValidation
            // 
            this.btnCloseMyValidation.Location = new System.Drawing.Point(122, 60);
            this.btnCloseMyValidation.Name = "btnCloseMyValidation";
            this.btnCloseMyValidation.Size = new System.Drawing.Size(75, 23);
            this.btnCloseMyValidation.TabIndex = 0;
            this.btnCloseMyValidation.Text = "Close";
            this.btnCloseMyValidation.UseVisualStyleBackColor = true;
            this.btnCloseMyValidation.Click += new System.EventHandler(this.btnCloseMyValidation_Click);
            // 
            // txtBoxmyValdation
            // 
            this.txtBoxmyValdation.AutoSize = true;
            this.txtBoxmyValdation.Location = new System.Drawing.Point(12, 9);
            this.txtBoxmyValdation.Name = "txtBoxmyValdation";
            this.txtBoxmyValdation.Size = new System.Drawing.Size(0, 13);
            this.txtBoxmyValdation.TabIndex = 2;
            this.txtBoxmyValdation.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // myValidation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(318, 89);
            this.Controls.Add(this.txtBoxmyValdation);
            this.Controls.Add(this.btnCloseMyValidation);
            this.Name = "myValidation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Error";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCloseMyValidation;
        private System.Windows.Forms.Label txtBoxmyValdation;
    }
}