namespace AsyncTest.Winform
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
            this.btnGetFile = new System.Windows.Forms.Button();
            this.tbxFile = new System.Windows.Forms.RichTextBox();
            this.tbxHttp = new System.Windows.Forms.RichTextBox();
            this.btnHttp = new System.Windows.Forms.Button();
            this.tbxCount = new System.Windows.Forms.RichTextBox();
            this.btnCounter = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnGetFile
            // 
            this.btnGetFile.Location = new System.Drawing.Point(29, 57);
            this.btnGetFile.Name = "btnGetFile";
            this.btnGetFile.Size = new System.Drawing.Size(100, 39);
            this.btnGetFile.TabIndex = 0;
            this.btnGetFile.Text = "btnGetFile";
            this.btnGetFile.UseVisualStyleBackColor = true;
            this.btnGetFile.Click += new System.EventHandler(this.btnGetFile_Click);
            // 
            // tbxFile
            // 
            this.tbxFile.Location = new System.Drawing.Point(29, 122);
            this.tbxFile.Name = "tbxFile";
            this.tbxFile.Size = new System.Drawing.Size(100, 116);
            this.tbxFile.TabIndex = 1;
            this.tbxFile.Text = "";
            // 
            // tbxHttp
            // 
            this.tbxHttp.Location = new System.Drawing.Point(355, 122);
            this.tbxHttp.Name = "tbxHttp";
            this.tbxHttp.Size = new System.Drawing.Size(100, 116);
            this.tbxHttp.TabIndex = 3;
            this.tbxHttp.Text = "";
            // 
            // btnHttp
            // 
            this.btnHttp.Location = new System.Drawing.Point(355, 57);
            this.btnHttp.Name = "btnHttp";
            this.btnHttp.Size = new System.Drawing.Size(100, 39);
            this.btnHttp.TabIndex = 2;
            this.btnHttp.Text = "Http";
            this.btnHttp.UseVisualStyleBackColor = true;
            // 
            // tbxCount
            // 
            this.tbxCount.Location = new System.Drawing.Point(192, 122);
            this.tbxCount.Name = "tbxCount";
            this.tbxCount.Size = new System.Drawing.Size(100, 116);
            this.tbxCount.TabIndex = 5;
            this.tbxCount.Text = "";
            // 
            // btnCounter
            // 
            this.btnCounter.Location = new System.Drawing.Point(192, 57);
            this.btnCounter.Name = "btnCounter";
            this.btnCounter.Size = new System.Drawing.Size(100, 39);
            this.btnCounter.TabIndex = 4;
            this.btnCounter.Text = "Count";
            this.btnCounter.UseVisualStyleBackColor = true;
            this.btnCounter.Click += new System.EventHandler(this.btnCounter_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(547, 356);
            this.Controls.Add(this.tbxCount);
            this.Controls.Add(this.btnCounter);
            this.Controls.Add(this.tbxHttp);
            this.Controls.Add(this.btnHttp);
            this.Controls.Add(this.tbxFile);
            this.Controls.Add(this.btnGetFile);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnGetFile;
        private System.Windows.Forms.RichTextBox tbxFile;
        private System.Windows.Forms.RichTextBox tbxHttp;
        private System.Windows.Forms.Button btnHttp;
        private System.Windows.Forms.RichTextBox tbxCount;
        private System.Windows.Forms.Button btnCounter;
    }
}

