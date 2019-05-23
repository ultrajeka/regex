namespace regex
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
            this.btnChek = new System.Windows.Forms.Button();
            this.tbInput = new System.Windows.Forms.TextBox();
            this.lblShowData = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnChek
            // 
            this.btnChek.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnChek.Location = new System.Drawing.Point(16, 377);
            this.btnChek.Name = "btnChek";
            this.btnChek.Size = new System.Drawing.Size(169, 61);
            this.btnChek.TabIndex = 1;
            this.btnChek.Text = "Узнать";
            this.btnChek.UseVisualStyleBackColor = true;
            this.btnChek.Click += new System.EventHandler(this.btnChek_Click);
            // 
            // tbInput
            // 
            this.tbInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.tbInput.Location = new System.Drawing.Point(16, 339);
            this.tbInput.Name = "tbInput";
            this.tbInput.Size = new System.Drawing.Size(169, 20);
            this.tbInput.TabIndex = 2;
            this.tbInput.TextChanged += new System.EventHandler(this.tbInput_TextChanged);
            // 
            // lblShowData
            // 
            this.lblShowData.AutoSize = true;
            this.lblShowData.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblShowData.Location = new System.Drawing.Point(12, 29);
            this.lblShowData.Name = "lblShowData";
            this.lblShowData.Size = new System.Drawing.Size(51, 20);
            this.lblShowData.TabIndex = 3;
            this.lblShowData.Text = "label1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(638, 450);
            this.Controls.Add(this.lblShowData);
            this.Controls.Add(this.tbInput);
            this.Controls.Add(this.btnChek);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnChek;
        private System.Windows.Forms.TextBox tbInput;
        private System.Windows.Forms.Label lblShowData;
    }
}

