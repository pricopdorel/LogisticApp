namespace LogisticaDepozit
{
    partial class AddFundsForm
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
            this.cardNumberTextBox = new System.Windows.Forms.TextBox();
            this.enterSumTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.confirmTransactionButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cardNumberTextBox
            // 
            this.cardNumberTextBox.Location = new System.Drawing.Point(39, 69);
            this.cardNumberTextBox.MaxLength = 16;
            this.cardNumberTextBox.Name = "cardNumberTextBox";
            this.cardNumberTextBox.Size = new System.Drawing.Size(193, 22);
            this.cardNumberTextBox.TabIndex = 0;
            // 
            // enterSumTextBox
            // 
            this.enterSumTextBox.Location = new System.Drawing.Point(122, 107);
            this.enterSumTextBox.Name = "enterSumTextBox";
            this.enterSumTextBox.Size = new System.Drawing.Size(110, 22);
            this.enterSumTextBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(160)))));
            this.label1.Location = new System.Drawing.Point(40, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Enter Card Number";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(160)))));
            this.label2.Location = new System.Drawing.Point(40, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Enter Sum";
            // 
            // confirmTransactionButton
            // 
            this.confirmTransactionButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(70)))), ((int)(((byte)(160)))));
            this.confirmTransactionButton.Font = new System.Drawing.Font("Microsoft Tai Le", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.confirmTransactionButton.ForeColor = System.Drawing.Color.White;
            this.confirmTransactionButton.Location = new System.Drawing.Point(39, 148);
            this.confirmTransactionButton.Name = "confirmTransactionButton";
            this.confirmTransactionButton.Size = new System.Drawing.Size(193, 57);
            this.confirmTransactionButton.TabIndex = 4;
            this.confirmTransactionButton.Text = "Confirm Transaction";
            this.confirmTransactionButton.UseVisualStyleBackColor = false;
            this.confirmTransactionButton.Click += new System.EventHandler(this.confirmTransactionClick);
            // 
            // AddFundsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Yellow;
            this.ClientSize = new System.Drawing.Size(276, 245);
            this.Controls.Add(this.confirmTransactionButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.enterSumTextBox);
            this.Controls.Add(this.cardNumberTextBox);
            this.Name = "AddFundsForm";
            this.Text = "Add Funds";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox cardNumberTextBox;
        private System.Windows.Forms.TextBox enterSumTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button confirmTransactionButton;
    }
}