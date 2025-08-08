using sqlParse;
namespace sqlParse
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
            this.passwordInput = new System.Windows.Forms.TextBox();
            this.ip_addressInput = new System.Windows.Forms.TextBox();
            this.usernameInput = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.connectButton = new System.Windows.Forms.Button();
            this.queryText = new System.Windows.Forms.RichTextBox();
            this.queryButton = new System.Windows.Forms.Button();
            this.outputBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // passwordInput
            // 
            this.passwordInput.Location = new System.Drawing.Point(171, 21);
            this.passwordInput.Name = "passwordInput";
            this.passwordInput.Size = new System.Drawing.Size(142, 20);
            this.passwordInput.TabIndex = 1;
            // 
            // ip_addressInput
            // 
            this.ip_addressInput.Location = new System.Drawing.Point(319, 21);
            this.ip_addressInput.Name = "ip_addressInput";
            this.ip_addressInput.Size = new System.Drawing.Size(142, 20);
            this.ip_addressInput.TabIndex = 2;
            // 
            // usernameInput
            // 
            this.usernameInput.Location = new System.Drawing.Point(23, 21);
            this.usernameInput.Name = "usernameInput";
            this.usernameInput.Size = new System.Drawing.Size(142, 20);
            this.usernameInput.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(58, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Username";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(212, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Password";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(364, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "IP Address";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // connectButton
            // 
            this.connectButton.Location = new System.Drawing.Point(467, 15);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(95, 26);
            this.connectButton.TabIndex = 7;
            this.connectButton.Text = "Connect";
            this.connectButton.UseVisualStyleBackColor = true;
            this.connectButton.Click += new System.EventHandler(this.connectButton_Click);
            // 
            // queryText
            // 
            this.queryText.Location = new System.Drawing.Point(22, 403);
            this.queryText.Name = "queryText";
            this.queryText.Size = new System.Drawing.Size(410, 23);
            this.queryText.TabIndex = 8;
            this.queryText.Text = "";
            this.queryText.TextChanged += new System.EventHandler(this.queryText_TextChanged);
            // 
            // queryButton
            // 
            this.queryButton.Location = new System.Drawing.Point(438, 403);
            this.queryButton.Name = "queryButton";
            this.queryButton.Size = new System.Drawing.Size(113, 22);
            this.queryButton.TabIndex = 9;
            this.queryButton.Text = "query";
            this.queryButton.UseVisualStyleBackColor = true;
            this.queryButton.Click += new System.EventHandler(this.RunQuerybutton_Click);
            // 
            // outputBox
            // 
            this.outputBox.Location = new System.Drawing.Point(24, 57);
            this.outputBox.Multiline = true;
            this.outputBox.Name = "outputBox";
            this.outputBox.ReadOnly = true;
            this.outputBox.Size = new System.Drawing.Size(537, 326);
            this.outputBox.TabIndex = 10;
            this.outputBox.TextChanged += new System.EventHandler(this.outputBox_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(589, 450);
            this.Controls.Add(this.outputBox);
            this.Controls.Add(this.queryButton);
            this.Controls.Add(this.queryText);
            this.Controls.Add(this.connectButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.usernameInput);
            this.Controls.Add(this.ip_addressInput);
            this.Controls.Add(this.passwordInput);
            this.Name = "Form1";
            this.Text = "sqlParse";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox passwordInput;
        private System.Windows.Forms.TextBox ip_addressInput;
        private System.Windows.Forms.TextBox usernameInput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button connectButton;
        private System.Windows.Forms.RichTextBox queryText;
        private System.Windows.Forms.Button queryButton;
        private System.Windows.Forms.TextBox outputBox;
    }
}

