namespace guiapp
{
    partial class FormUDPLogger
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
            this.textBoxLogger = new System.Windows.Forms.TextBox();
            this.buttonCheck1 = new System.Windows.Forms.Button();
            this.buttonCheck2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxLogger
            // 
            this.textBoxLogger.Location = new System.Drawing.Point(51, 31);
            this.textBoxLogger.Multiline = true;
            this.textBoxLogger.Name = "textBoxLogger";
            this.textBoxLogger.Size = new System.Drawing.Size(645, 241);
            this.textBoxLogger.TabIndex = 0;
            this.textBoxLogger.TextChanged += new System.EventHandler(this.TextBox1_TextChanged);
            // 
            // buttonCheck1
            // 
            this.buttonCheck1.Location = new System.Drawing.Point(48, 314);
            this.buttonCheck1.Name = "buttonCheck1";
            this.buttonCheck1.Size = new System.Drawing.Size(230, 107);
            this.buttonCheck1.TabIndex = 1;
            this.buttonCheck1.Text = "Check1";
            this.buttonCheck1.UseVisualStyleBackColor = true;
            this.buttonCheck1.Click += new System.EventHandler(this.ButtonCheck1_Click);
            // 
            // buttonCheck2
            // 
            this.buttonCheck2.Location = new System.Drawing.Point(409, 327);
            this.buttonCheck2.Name = "buttonCheck2";
            this.buttonCheck2.Size = new System.Drawing.Size(205, 79);
            this.buttonCheck2.TabIndex = 2;
            this.buttonCheck2.Text = "Check2";
            this.buttonCheck2.UseVisualStyleBackColor = true;
            this.buttonCheck2.Click += new System.EventHandler(this.ButtonCheck2_Click);
            // 
            // FormUDPLogger
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonCheck2);
            this.Controls.Add(this.buttonCheck1);
            this.Controls.Add(this.textBoxLogger);
            this.Name = "FormUDPLogger";
            this.Text = "UDPLogger";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxLogger;
        private System.Windows.Forms.Button buttonCheck1;
        private System.Windows.Forms.Button buttonCheck2;
    }
}

