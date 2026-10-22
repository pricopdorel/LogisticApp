namespace LogisticaDepozit
{
    partial class ShopForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShopForm));
            this.label1 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripBackS = new System.Windows.Forms.ToolStripButton();
            this.addBalanceButton = new System.Windows.Forms.Button();
            this.balanceLabel = new System.Windows.Forms.Label();
            this.buttonPlaceOreder = new System.Windows.Forms.Button();
            this.labelOrderTotal = new System.Windows.Forms.Label();
            this.textBoxTotalPrice = new System.Windows.Forms.TextBox();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(160)))));
            this.label1.Location = new System.Drawing.Point(124, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(235, 39);
            this.label1.TabIndex = 14;
            this.label1.Text = "Product Shop";
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripBackS});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(588, 27);
            this.toolStrip1.TabIndex = 25;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripBackS
            // 
            this.toolStripBackS.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripBackS.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBackS.Image")));
            this.toolStripBackS.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBackS.Name = "toolStripBackS";
            this.toolStripBackS.Size = new System.Drawing.Size(29, 24);
            this.toolStripBackS.Text = "toolStripButton1";
            this.toolStripBackS.Click += new System.EventHandler(this.toolStripBackS_Click_1);
            // 
            // addBalanceButton
            // 
            this.addBalanceButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(70)))), ((int)(((byte)(160)))));
            this.addBalanceButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addBalanceButton.ForeColor = System.Drawing.Color.White;
            this.addBalanceButton.Location = new System.Drawing.Point(528, 37);
            this.addBalanceButton.Name = "addBalanceButton";
            this.addBalanceButton.Size = new System.Drawing.Size(49, 46);
            this.addBalanceButton.TabIndex = 26;
            this.addBalanceButton.Text = "+";
            this.addBalanceButton.UseVisualStyleBackColor = false;
            this.addBalanceButton.Click += new System.EventHandler(this.addBalanceButton_Click);
            // 
            // balanceLabel
            // 
            this.balanceLabel.AutoSize = true;
            this.balanceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.balanceLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(160)))));
            this.balanceLabel.Location = new System.Drawing.Point(436, 33);
            this.balanceLabel.Name = "balanceLabel";
            this.balanceLabel.Size = new System.Drawing.Size(70, 20);
            this.balanceLabel.TabIndex = 27;
            this.balanceLabel.Text = "Balance";
            // 
            // buttonPlaceOreder
            // 
            this.buttonPlaceOreder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(70)))), ((int)(((byte)(160)))));
            this.buttonPlaceOreder.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPlaceOreder.ForeColor = System.Drawing.Color.White;
            this.buttonPlaceOreder.Location = new System.Drawing.Point(187, 404);
            this.buttonPlaceOreder.Name = "buttonPlaceOreder";
            this.buttonPlaceOreder.Size = new System.Drawing.Size(183, 38);
            this.buttonPlaceOreder.TabIndex = 30;
            this.buttonPlaceOreder.Text = "Place Order";
            this.buttonPlaceOreder.UseVisualStyleBackColor = false;
            this.buttonPlaceOreder.Click += new System.EventHandler(this.buttonPlaceOreder_Click);
            // 
            // labelOrderTotal
            // 
            this.labelOrderTotal.AutoSize = true;
            this.labelOrderTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelOrderTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(51)))), ((int)(((byte)(160)))));
            this.labelOrderTotal.Location = new System.Drawing.Point(484, 342);
            this.labelOrderTotal.Name = "labelOrderTotal";
            this.labelOrderTotal.Size = new System.Drawing.Size(90, 20);
            this.labelOrderTotal.TabIndex = 29;
            this.labelOrderTotal.Text = "Total Price";
            // 
            // textBoxTotalPrice
            // 
            this.textBoxTotalPrice.Location = new System.Drawing.Point(498, 366);
            this.textBoxTotalPrice.Name = "textBoxTotalPrice";
            this.textBoxTotalPrice.ReadOnly = true;
            this.textBoxTotalPrice.Size = new System.Drawing.Size(74, 22);
            this.textBoxTotalPrice.TabIndex = 28;
            this.textBoxTotalPrice.Text = "0";
            // 
            // ShopForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Yellow;
            this.ClientSize = new System.Drawing.Size(588, 452);
            this.Controls.Add(this.buttonPlaceOreder);
            this.Controls.Add(this.labelOrderTotal);
            this.Controls.Add(this.textBoxTotalPrice);
            this.Controls.Add(this.addBalanceButton);
            this.Controls.Add(this.balanceLabel);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "ShopForm";
            this.Text = "ShopForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.formClosing);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripBackS;
        private System.Windows.Forms.Button addBalanceButton;
        private System.Windows.Forms.Label balanceLabel;
        private System.Windows.Forms.Button buttonPlaceOreder;
        private System.Windows.Forms.Label labelOrderTotal;
        private System.Windows.Forms.TextBox textBoxTotalPrice;
    }
}