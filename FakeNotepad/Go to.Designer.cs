namespace FakeNotepad
{
    partial class Go_to
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
            this.label1 = new System.Windows.Forms.Label();
            this.txbx_linenumber = new System.Windows.Forms.TextBox();
            this.btn_goto = new System.Windows.Forms.Button();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Line";
            // 
            // txbx_linenumber
            // 
            this.txbx_linenumber.Location = new System.Drawing.Point(61, 32);
            this.txbx_linenumber.Name = "txbx_linenumber";
            this.txbx_linenumber.Size = new System.Drawing.Size(211, 20);
            this.txbx_linenumber.TabIndex = 1;
            // 
            // btn_goto
            // 
            this.btn_goto.Location = new System.Drawing.Point(61, 58);
            this.btn_goto.Name = "btn_goto";
            this.btn_goto.Size = new System.Drawing.Size(75, 23);
            this.btn_goto.TabIndex = 2;
            this.btn_goto.Text = "Go to";
            this.btn_goto.UseVisualStyleBackColor = true;
            this.btn_goto.Click += new System.EventHandler(this.btn_goto_Click);
            // 
            // btn_cancel
            // 
            this.btn_cancel.Location = new System.Drawing.Point(159, 58);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_cancel.TabIndex = 3;
            this.btn_cancel.Text = "Cancel";
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // Go_to
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(311, 110);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_goto);
            this.Controls.Add(this.txbx_linenumber);
            this.Controls.Add(this.label1);
            this.Name = "Go_to";
            this.Text = "Go_to";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txbx_linenumber;
        private System.Windows.Forms.Button btn_goto;
        private System.Windows.Forms.Button btn_cancel;
    }
}