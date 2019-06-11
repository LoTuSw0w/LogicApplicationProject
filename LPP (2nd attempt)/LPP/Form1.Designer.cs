namespace LPP
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
            this.txtInput = new System.Windows.Forms.TextBox();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.btnBinaryTree = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.lbCanBeSimplified = new System.Windows.Forms.Label();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.txtDNF = new System.Windows.Forms.TextBox();
            this.txtClearAll = new System.Windows.Forms.Button();
            this.txtHashCode = new System.Windows.Forms.TextBox();
            this.btnTableaux = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtInput
            // 
            this.txtInput.Location = new System.Drawing.Point(49, 31);
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(428, 20);
            this.txtInput.TabIndex = 0;
            // 
            // txtOutput
            // 
            this.txtOutput.Location = new System.Drawing.Point(49, 67);
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.Size = new System.Drawing.Size(428, 20);
            this.txtOutput.TabIndex = 1;
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(48, 162);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(75, 23);
            this.btnSubmit.TabIndex = 2;
            this.btnSubmit.Text = "Convert ";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.Button1_Click);
            // 
            // btnBinaryTree
            // 
            this.btnBinaryTree.Location = new System.Drawing.Point(129, 162);
            this.btnBinaryTree.Name = "btnBinaryTree";
            this.btnBinaryTree.Size = new System.Drawing.Size(75, 23);
            this.btnBinaryTree.TabIndex = 3;
            this.btnBinaryTree.Text = "Graph";
            this.btnBinaryTree.UseVisualStyleBackColor = true;
            this.btnBinaryTree.Click += new System.EventHandler(this.Button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(210, 162);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Truth Table";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click_1);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(494, 12);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(218, 368);
            this.listBox1.TabIndex = 5;
            // 
            // lbCanBeSimplified
            // 
            this.lbCanBeSimplified.AutoSize = true;
            this.lbCanBeSimplified.Location = new System.Drawing.Point(59, 113);
            this.lbCanBeSimplified.Name = "lbCanBeSimplified";
            this.lbCanBeSimplified.Size = new System.Drawing.Size(0, 13);
            this.lbCanBeSimplified.TabIndex = 6;
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.Location = new System.Drawing.Point(259, 194);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(218, 186);
            this.listBox2.TabIndex = 7;
            // 
            // txtDNF
            // 
            this.txtDNF.Location = new System.Drawing.Point(49, 106);
            this.txtDNF.Name = "txtDNF";
            this.txtDNF.Size = new System.Drawing.Size(428, 20);
            this.txtDNF.TabIndex = 8;
            // 
            // txtClearAll
            // 
            this.txtClearAll.Location = new System.Drawing.Point(291, 162);
            this.txtClearAll.Name = "txtClearAll";
            this.txtClearAll.Size = new System.Drawing.Size(75, 23);
            this.txtClearAll.TabIndex = 9;
            this.txtClearAll.Text = "Clear all";
            this.txtClearAll.UseVisualStyleBackColor = true;
            this.txtClearAll.Click += new System.EventHandler(this.TxtClearAll_Click);
            // 
            // txtHashCode
            // 
            this.txtHashCode.Location = new System.Drawing.Point(48, 136);
            this.txtHashCode.Name = "txtHashCode";
            this.txtHashCode.Size = new System.Drawing.Size(428, 20);
            this.txtHashCode.TabIndex = 10;
            // 
            // btnTableaux
            // 
            this.btnTableaux.Location = new System.Drawing.Point(372, 162);
            this.btnTableaux.Name = "btnTableaux";
            this.btnTableaux.Size = new System.Drawing.Size(75, 23);
            this.btnTableaux.TabIndex = 11;
            this.btnTableaux.Text = "Tableaux";
            this.btnTableaux.UseVisualStyleBackColor = true;
            this.btnTableaux.Click += new System.EventHandler(this.BtnTableaux_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(736, 450);
            this.Controls.Add(this.btnTableaux);
            this.Controls.Add(this.txtHashCode);
            this.Controls.Add(this.txtClearAll);
            this.Controls.Add(this.txtDNF);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.lbCanBeSimplified);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnBinaryTree);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.txtOutput);
            this.Controls.Add(this.txtInput);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.TextBox txtOutput;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Button btnBinaryTree;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label lbCanBeSimplified;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.TextBox txtDNF;
        private System.Windows.Forms.Button txtClearAll;
        private System.Windows.Forms.TextBox txtHashCode;
        private System.Windows.Forms.Button btnTableaux;
    }
}

