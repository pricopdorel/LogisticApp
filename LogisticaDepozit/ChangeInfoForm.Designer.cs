namespace LogisticaDepozit
{
    partial class ChangeInfoForm
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
            this.enterTextBox = new System.Windows.Forms.TextBox();
            this.reenterTextBox = new System.Windows.Forms.TextBox();
            this.enter = new System.Windows.Forms.Label();
            this.reenter = new System.Windows.Forms.Label();
            this.submit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // enterTextBox
            // 
            this.enterTextBox.Location = new System.Drawing.Point(162, 24);
            this.enterTextBox.Name = "enterTextBox";
            this.enterTextBox.Size = new System.Drawing.Size(194, 22);
            this.enterTextBox.TabIndex = 0;
            // 
            // reenterTextBox
            // 
            this.reenterTextBox.Location = new System.Drawing.Point(162, 71);
            this.reenterTextBox.Name = "reenterTextBox";
            this.reenterTextBox.Size = new System.Drawing.Size(194, 22);
            this.reenterTextBox.TabIndex = 1;
            // 
            // enter
            // 
            this.enter.AutoSize = true;
            this.enter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(160)))));
            this.enter.Location = new System.Drawing.Point(24, 27);
            this.enter.Name = "enter";
            this.enter.Size = new System.Drawing.Size(44, 16);
            this.enter.TabIndex = 2;
            this.enter.Text = "label1";
            // 
            // reenter
            // 
            this.reenter.AutoSize = true;
            this.reenter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(160)))));
            this.reenter.Location = new System.Drawing.Point(24, 74);
            this.reenter.Name = "reenter";
            this.reenter.Size = new System.Drawing.Size(44, 16);
            this.reenter.TabIndex = 3;
            this.reenter.Text = "label2";
            // 
            // submit
            // 
            this.submit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(70)))), ((int)(((byte)(160)))));
            this.submit.ForeColor = System.Drawing.Color.White;
            this.submit.Location = new System.Drawing.Point(27, 118);
            this.submit.Name = "submit";
            this.submit.Size = new System.Drawing.Size(329, 23);
            this.submit.TabIndex = 4;
            this.submit.Text = "Submit";
            this.submit.UseVisualStyleBackColor = false;
            this.submit.Click += new System.EventHandler(this.submitButtonClicked);
            // 
            // ChangeInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Yellow;
            this.ClientSize = new System.Drawing.Size(389, 165);
            this.Controls.Add(this.submit);
            this.Controls.Add(this.reenter);
            this.Controls.Add(this.enter);
            this.Controls.Add(this.reenterTextBox);
            this.Controls.Add(this.enterTextBox);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "ChangeInfoForm";
            this.Text = "Change Info";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox enterTextBox;
        private System.Windows.Forms.TextBox reenterTextBox;
        private System.Windows.Forms.Label enter;
        private System.Windows.Forms.Label reenter;
        private System.Windows.Forms.Button submit;
    }
}