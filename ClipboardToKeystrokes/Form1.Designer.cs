namespace ClipboardToKeystrokes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.batchSizeTB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.delayTB = new System.Windows.Forms.TextBox();
            this.cb_replaceCarrage = new System.Windows.Forms.CheckBox();
            this.cb_shiftReturn = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.textBox1.Location = new System.Drawing.Point(0, 92);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(553, 358);
            this.textBox1.TabIndex = 0;
            // 
            // batchSizeTB
            // 
            this.batchSizeTB.Location = new System.Drawing.Point(101, 16);
            this.batchSizeTB.Name = "batchSizeTB";
            this.batchSizeTB.Size = new System.Drawing.Size(100, 26);
            this.batchSizeTB.TabIndex = 1;
            this.batchSizeTB.Text = "1000";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Batch size";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(256, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(179, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Delay Between Batches";
            // 
            // delayTB
            // 
            this.delayTB.Location = new System.Drawing.Point(441, 16);
            this.delayTB.Name = "delayTB";
            this.delayTB.Size = new System.Drawing.Size(100, 26);
            this.delayTB.TabIndex = 4;
            this.delayTB.Text = "2000";
            // 
            // cb_replaceCarrage
            // 
            this.cb_replaceCarrage.AutoSize = true;
            this.cb_replaceCarrage.Checked = true;
            this.cb_replaceCarrage.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_replaceCarrage.Location = new System.Drawing.Point(13, 52);
            this.cb_replaceCarrage.Name = "cb_replaceCarrage";
            this.cb_replaceCarrage.Size = new System.Drawing.Size(169, 24);
            this.cb_replaceCarrage.TabIndex = 5;
            this.cb_replaceCarrage.Text = "Replace \\r\\n with \\n";
            this.cb_replaceCarrage.UseVisualStyleBackColor = true;
            // 
            // cb_shiftReturn
            // 
            this.cb_shiftReturn.AutoSize = true;
            this.cb_shiftReturn.Checked = true;
            this.cb_shiftReturn.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_shiftReturn.Location = new System.Drawing.Point(260, 51);
            this.cb_shiftReturn.Name = "cb_shiftReturn";
            this.cb_shiftReturn.Size = new System.Drawing.Size(150, 24);
            this.cb_shiftReturn.TabIndex = 6;
            this.cb_shiftReturn.Text = "Return with shift";
            this.cb_shiftReturn.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(553, 450);
            this.Controls.Add(this.cb_shiftReturn);
            this.Controls.Add(this.cb_replaceCarrage);
            this.Controls.Add(this.delayTB);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.batchSizeTB);
            this.Controls.Add(this.textBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Clipboard to Keystrokes";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox batchSizeTB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox delayTB;
        private System.Windows.Forms.CheckBox cb_replaceCarrage;
        private System.Windows.Forms.CheckBox cb_shiftReturn;
    }
}

