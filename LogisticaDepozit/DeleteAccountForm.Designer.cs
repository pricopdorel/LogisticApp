namespace LogisticaDepozit
{
    partial class DeleteAccountForm
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
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.questionLabel = new System.Windows.Forms.Label();
            this.confirmIdentityLabel = new System.Windows.Forms.Label();
            this.yesButton = new System.Windows.Forms.Button();
            this.confirmButton = new System.Windows.Forms.Button();
            this.noButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Location = new System.Drawing.Point(77, 57);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.Size = new System.Drawing.Size(153, 22);
            this.passwordTextBox.TabIndex = 0;
            this.passwordTextBox.Visible = false;
            // 
            // questionLabel
            // 
            this.questionLabel.AutoSize = true;
            this.questionLabel.BackColor = System.Drawing.Color.Red;
            this.questionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.questionLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.questionLabel.Location = new System.Drawing.Point(13, 19);
            this.questionLabel.Name = "questionLabel";
            this.questionLabel.Size = new System.Drawing.Size(330, 18);
            this.questionLabel.TabIndex = 1;
            this.questionLabel.Text = "Are You Sure You Want To Delete This Account?";
            // 
            // confirmIdentityLabel
            // 
            this.confirmIdentityLabel.AutoSize = true;
            this.confirmIdentityLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.confirmIdentityLabel.ForeColor = System.Drawing.Color.White;
            this.confirmIdentityLabel.Location = new System.Drawing.Point(74, 21);
            this.confirmIdentityLabel.Name = "confirmIdentityLabel";
            this.confirmIdentityLabel.Size = new System.Drawing.Size(170, 16);
            this.confirmIdentityLabel.TabIndex = 2;
            this.confirmIdentityLabel.Text = "Enter Password to Proceed";
            this.confirmIdentityLabel.Visible = false;
            // 
            // yesButton
            // 
            this.yesButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.yesButton.Location = new System.Drawing.Point(16, 57);
            this.yesButton.Name = "yesButton";
            this.yesButton.Size = new System.Drawing.Size(165, 67);
            this.yesButton.TabIndex = 3;
            this.yesButton.Text = "Yes";
            this.yesButton.UseVisualStyleBackColor = true;
            this.yesButton.Click += new System.EventHandler(this.yesButtonClicked);
            // 
            // confirmButton
            // 
            this.confirmButton.Location = new System.Drawing.Point(236, 56);
            this.confirmButton.Name = "confirmButton";
            this.confirmButton.Size = new System.Drawing.Size(75, 23);
            this.confirmButton.TabIndex = 5;
            this.confirmButton.Text = "Confirm";
            this.confirmButton.UseVisualStyleBackColor = true;
            this.confirmButton.Visible = false;
            this.confirmButton.Click += new System.EventHandler(this.confirmButtonClicked);
            // 
            // noButton
            // 
            this.noButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.noButton.Location = new System.Drawing.Point(211, 57);
            this.noButton.Name = "noButton";
            this.noButton.Size = new System.Drawing.Size(165, 67);
            this.noButton.TabIndex = 6;
            this.noButton.Text = "No";
            this.noButton.UseVisualStyleBackColor = true;
            this.noButton.Click += new System.EventHandler(this.noButtonClicked);
            // 
            // DeleteAccountForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Red;
            this.ClientSize = new System.Drawing.Size(397, 150);
            this.Controls.Add(this.confirmButton);
            this.Controls.Add(this.confirmIdentityLabel);
            this.Controls.Add(this.questionLabel);
            this.Controls.Add(this.passwordTextBox);
            this.Controls.Add(this.yesButton);
            this.Controls.Add(this.noButton);
            this.ForeColor = System.Drawing.Color.Red;
            this.Name = "DeleteAccountForm";
            this.Text = "Delete Account";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.Label questionLabel;
        private System.Windows.Forms.Label confirmIdentityLabel;
        private System.Windows.Forms.Button yesButton;
        private System.Windows.Forms.Button confirmButton;
        private System.Windows.Forms.Button noButton;
    }
}