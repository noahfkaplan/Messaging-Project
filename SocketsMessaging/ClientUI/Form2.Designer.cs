namespace ClientUI
{
    partial class Form2
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
            this.UsernameLabel = new System.Windows.Forms.Label();
            this.usernameTextBox = new System.Windows.Forms.TextBox();
            this.SubmitUsernameButton = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // UsernameLabel
            // 
            this.UsernameLabel.AutoSize = true;
            this.UsernameLabel.Location = new System.Drawing.Point(54, 184);
            this.UsernameLabel.Name = "UsernameLabel";
            this.UsernameLabel.Size = new System.Drawing.Size(95, 13);
            this.UsernameLabel.TabIndex = 0;
            this.UsernameLabel.Text = "Enter a Username:";
            // 
            // usernameTextBox
            // 
            this.usernameTextBox.Location = new System.Drawing.Point(57, 200);
            this.usernameTextBox.Name = "usernameTextBox";
            this.usernameTextBox.Size = new System.Drawing.Size(165, 20);
            this.usernameTextBox.TabIndex = 1;
            // 
            // SubmitUsernameButton
            // 
            this.SubmitUsernameButton.Location = new System.Drawing.Point(197, 226);
            this.SubmitUsernameButton.Name = "SubmitUsernameButton";
            this.SubmitUsernameButton.Size = new System.Drawing.Size(75, 23);
            this.SubmitUsernameButton.TabIndex = 2;
            this.SubmitUsernameButton.Text = "Submit";
            this.SubmitUsernameButton.UseVisualStyleBackColor = true;
            this.SubmitUsernameButton.Click += new System.EventHandler(this.SubmitUsernameButton_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ClientUI.Properties.Resources.Placeholder_Logo;
            this.pictureBox1.Location = new System.Drawing.Point(57, 27);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(165, 130);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(59, 227);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "";
            // 
            // Form2
            // 
            this.AcceptButton = this.SubmitUsernameButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.SubmitUsernameButton);
            this.Controls.Add(this.usernameTextBox);
            this.Controls.Add(this.UsernameLabel);
            this.Name = "Form2";
            this.Text = "Noah\'s Chat App";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label UsernameLabel;
        private System.Windows.Forms.TextBox usernameTextBox;
        private System.Windows.Forms.Button SubmitUsernameButton;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
    }
}