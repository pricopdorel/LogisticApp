namespace LogisticaDepozit
{
    partial class SettingsForm
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
            this.changeEmailButton = new System.Windows.Forms.Button();
            this.changePasswordButton = new System.Windows.Forms.Button();
            this.addFundsButton = new System.Windows.Forms.Button();
            this.deleteAccountButton = new System.Windows.Forms.Button();
            this.changeUsernameButton = new System.Windows.Forms.Button();
            this.overviewUsernameTextBox = new System.Windows.Forms.TextBox();
            this.overviewEmailTextBox = new System.Windows.Forms.TextBox();
            this.overviewBalanceTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // changeEmailButton
            // 
            this.changeEmailButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(70)))), ((int)(((byte)(160)))));
            this.changeEmailButton.ForeColor = System.Drawing.Color.White;
            this.changeEmailButton.Location = new System.Drawing.Point(24, 106);
            this.changeEmailButton.Name = "changeEmailButton";
            this.changeEmailButton.Size = new System.Drawing.Size(188, 41);
            this.changeEmailButton.TabIndex = 0;
            this.changeEmailButton.Text = "Change Email";
            this.changeEmailButton.UseVisualStyleBackColor = false;
            this.changeEmailButton.Click += new System.EventHandler(this.changeEmailClicked);
            // 
            // changePasswordButton
            // 
            this.changePasswordButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(70)))), ((int)(((byte)(160)))));
            this.changePasswordButton.ForeColor = System.Drawing.Color.White;
            this.changePasswordButton.Location = new System.Drawing.Point(24, 164);
            this.changePasswordButton.Name = "changePasswordButton";
            this.changePasswordButton.Size = new System.Drawing.Size(188, 41);
            this.changePasswordButton.TabIndex = 1;
            this.changePasswordButton.Text = "Change Password";
            this.changePasswordButton.UseVisualStyleBackColor = false;
            this.changePasswordButton.Click += new System.EventHandler(this.changePasswordClicked);
            // 
            // addFundsButton
            // 
            this.addFundsButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(70)))), ((int)(((byte)(160)))));
            this.addFundsButton.ForeColor = System.Drawing.Color.White;
            this.addFundsButton.Location = new System.Drawing.Point(24, 220);
            this.addFundsButton.Name = "addFundsButton";
            this.addFundsButton.Size = new System.Drawing.Size(188, 41);
            this.addFundsButton.TabIndex = 2;
            this.addFundsButton.Text = "Add Funds";
            this.addFundsButton.UseVisualStyleBackColor = false;
            this.addFundsButton.Click += new System.EventHandler(this.addFundsClick);
            // 
            // deleteAccountButton
            // 
            this.deleteAccountButton.BackColor = System.Drawing.Color.Red;
            this.deleteAccountButton.ForeColor = System.Drawing.Color.White;
            this.deleteAccountButton.Location = new System.Drawing.Point(24, 324);
            this.deleteAccountButton.Name = "deleteAccountButton";
            this.deleteAccountButton.Size = new System.Drawing.Size(188, 41);
            this.deleteAccountButton.TabIndex = 3;
            this.deleteAccountButton.Text = "Delete Account";
            this.deleteAccountButton.UseVisualStyleBackColor = false;
            this.deleteAccountButton.Click += new System.EventHandler(this.deleteAccountButtonClick);
            // 
            // changeUsernameButton
            // 
            this.changeUsernameButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(70)))), ((int)(((byte)(160)))));
            this.changeUsernameButton.ForeColor = System.Drawing.Color.White;
            this.changeUsernameButton.Location = new System.Drawing.Point(24, 47);
            this.changeUsernameButton.Name = "changeUsernameButton";
            this.changeUsernameButton.Size = new System.Drawing.Size(188, 41);
            this.changeUsernameButton.TabIndex = 4;
            this.changeUsernameButton.Text = "Change Username";
            this.changeUsernameButton.UseVisualStyleBackColor = false;
            this.changeUsernameButton.Click += new System.EventHandler(this.changeUsernameClicked);
            // 
            // overviewUsernameTextBox
            // 
            this.overviewUsernameTextBox.Location = new System.Drawing.Point(264, 56);
            this.overviewUsernameTextBox.Name = "overviewUsernameTextBox";
            this.overviewUsernameTextBox.ReadOnly = true;
            this.overviewUsernameTextBox.Size = new System.Drawing.Size(166, 22);
            this.overviewUsernameTextBox.TabIndex = 6;
            // 
            // overviewEmailTextBox
            // 
            this.overviewEmailTextBox.Location = new System.Drawing.Point(264, 124);
            this.overviewEmailTextBox.Name = "overviewEmailTextBox";
            this.overviewEmailTextBox.ReadOnly = true;
            this.overviewEmailTextBox.Size = new System.Drawing.Size(166, 22);
            this.overviewEmailTextBox.TabIndex = 7;
            // 
            // overviewBalanceTextBox
            // 
            this.overviewBalanceTextBox.Location = new System.Drawing.Point(264, 192);
            this.overviewBalanceTextBox.Name = "overviewBalanceTextBox";
            this.overviewBalanceTextBox.ReadOnly = true;
            this.overviewBalanceTextBox.Size = new System.Drawing.Size(166, 22);
            this.overviewBalanceTextBox.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(160)))));
            this.label1.Location = new System.Drawing.Point(264, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 16);
            this.label1.TabIndex = 9;
            this.label1.Text = "Username";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(160)))));
            this.label2.Location = new System.Drawing.Point(264, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 16);
            this.label2.TabIndex = 10;
            this.label2.Text = "Email";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(160)))));
            this.label3.Location = new System.Drawing.Point(264, 173);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 16);
            this.label3.TabIndex = 11;
            this.label3.Text = "Balance";
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Yellow;
            this.ClientSize = new System.Drawing.Size(481, 404);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.overviewBalanceTextBox);
            this.Controls.Add(this.overviewEmailTextBox);
            this.Controls.Add(this.overviewUsernameTextBox);
            this.Controls.Add(this.changeUsernameButton);
            this.Controls.Add(this.deleteAccountButton);
            this.Controls.Add(this.addFundsButton);
            this.Controls.Add(this.changePasswordButton);
            this.Controls.Add(this.changeEmailButton);
            this.Name = "SettingsForm";
            this.Text = "Settings";
            this.ResumeLayout(false);
            this.PerformLayout();
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SettingsFormClosing);

        }

        #endregion

        private System.Windows.Forms.Button changeEmailButton;
        private System.Windows.Forms.Button changePasswordButton;
        private System.Windows.Forms.Button addFundsButton;
        private System.Windows.Forms.Button deleteAccountButton;
        private System.Windows.Forms.Button changeUsernameButton;
        private System.Windows.Forms.TextBox overviewUsernameTextBox;
        private System.Windows.Forms.TextBox overviewEmailTextBox;
        private System.Windows.Forms.TextBox overviewBalanceTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}