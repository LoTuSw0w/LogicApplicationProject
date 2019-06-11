namespace LogicApplication
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
            this.btnConvert = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.lbInput = new System.Windows.Forms.Label();
            this.lbOutput = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbNoOfPropositions = new System.Windows.Forms.Label();
            this.lbCanBeSimplifiedOrNot = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDNF = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtInput
            // 
            this.txtInput.Font = new System.Drawing.Font("DejaVu Sans Mono", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInput.Location = new System.Drawing.Point(161, 12);
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(728, 31);
            this.txtInput.TabIndex = 0;
            // 
            // txtOutput
            // 
            this.txtOutput.Font = new System.Drawing.Font("DejaVu Sans Mono", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOutput.Location = new System.Drawing.Point(161, 49);
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.Size = new System.Drawing.Size(728, 31);
            this.txtOutput.TabIndex = 1;
            // 
            // btnConvert
            // 
            this.btnConvert.Font = new System.Drawing.Font("DejaVu Sans Mono", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConvert.Location = new System.Drawing.Point(222, 161);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(140, 32);
            this.btnConvert.TabIndex = 2;
            this.btnConvert.Text = "Convert to Infix";
            this.btnConvert.UseVisualStyleBackColor = true;
            this.btnConvert.Click += new System.EventHandler(this.BtnConvert_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("DejaVu Sans Mono", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(368, 161);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(139, 33);
            this.button1.TabIndex = 3;
            this.button1.Text = "View Binary Tree";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("DejaVu Sans Mono", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(513, 161);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(159, 33);
            this.button2.TabIndex = 4;
            this.button2.Text = "Generate truth table";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("DejaVu Sans Mono", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(161, 86);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(728, 31);
            this.textBox1.TabIndex = 5;
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("DejaVu Sans Mono", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(160, 162);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(56, 31);
            this.textBox2.TabIndex = 6;
            // 
            // listBox1
            // 
            this.listBox1.Font = new System.Drawing.Font("DejaVu Sans Mono", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 14;
            this.listBox1.Location = new System.Drawing.Point(26, 243);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(353, 256);
            this.listBox1.TabIndex = 7;
            // 
            // listBox2
            // 
            this.listBox2.Font = new System.Drawing.Font("DejaVu Sans Mono", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox2.FormattingEnabled = true;
            this.listBox2.ItemHeight = 14;
            this.listBox2.Location = new System.Drawing.Point(404, 313);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(304, 186);
            this.listBox2.TabIndex = 9;
            // 
            // lbInput
            // 
            this.lbInput.AutoSize = true;
            this.lbInput.Font = new System.Drawing.Font("DejaVu Sans Mono", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbInput.Location = new System.Drawing.Point(12, 20);
            this.lbInput.Name = "lbInput";
            this.lbInput.Size = new System.Drawing.Size(111, 15);
            this.lbInput.TabIndex = 10;
            this.lbInput.Text = "Prefix Input:";
            // 
            // lbOutput
            // 
            this.lbOutput.AutoSize = true;
            this.lbOutput.Font = new System.Drawing.Font("DejaVu Sans Mono", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbOutput.Location = new System.Drawing.Point(12, 59);
            this.lbOutput.Name = "lbOutput";
            this.lbOutput.Size = new System.Drawing.Size(111, 15);
            this.lbOutput.TabIndex = 11;
            this.lbOutput.Text = "Infix output:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("DejaVu Sans Mono", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 15);
            this.label1.TabIndex = 12;
            this.label1.Text = "Postfix form:";
            // 
            // lbNoOfPropositions
            // 
            this.lbNoOfPropositions.AutoSize = true;
            this.lbNoOfPropositions.Font = new System.Drawing.Font("DejaVu Sans Mono", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNoOfPropositions.Location = new System.Drawing.Point(11, 172);
            this.lbNoOfPropositions.Name = "lbNoOfPropositions";
            this.lbNoOfPropositions.Size = new System.Drawing.Size(143, 15);
            this.lbNoOfPropositions.TabIndex = 13;
            this.lbNoOfPropositions.Text = "No. Propositions:";
            // 
            // lbCanBeSimplifiedOrNot
            // 
            this.lbCanBeSimplifiedOrNot.AutoSize = true;
            this.lbCanBeSimplifiedOrNot.Font = new System.Drawing.Font("DejaVu Sans Mono", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCanBeSimplifiedOrNot.Location = new System.Drawing.Point(22, 206);
            this.lbCanBeSimplifiedOrNot.Name = "lbCanBeSimplifiedOrNot";
            this.lbCanBeSimplifiedOrNot.Size = new System.Drawing.Size(0, 19);
            this.lbCanBeSimplifiedOrNot.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("DejaVu Sans Mono", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(11, 133);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 15);
            this.label2.TabIndex = 16;
            this.label2.Text = "DNF:";
            // 
            // txtDNF
            // 
            this.txtDNF.Font = new System.Drawing.Font("DejaVu Sans Mono", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDNF.Location = new System.Drawing.Point(160, 123);
            this.txtDNF.Name = "txtDNF";
            this.txtDNF.Size = new System.Drawing.Size(728, 31);
            this.txtDNF.TabIndex = 15;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(898, 537);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtDNF);
            this.Controls.Add(this.lbCanBeSimplifiedOrNot);
            this.Controls.Add(this.lbNoOfPropositions);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbOutput);
            this.Controls.Add(this.lbInput);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnConvert);
            this.Controls.Add(this.txtOutput);
            this.Controls.Add(this.txtInput);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.TextBox txtOutput;
        private System.Windows.Forms.Button btnConvert;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.Label lbInput;
        private System.Windows.Forms.Label lbOutput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbNoOfPropositions;
        private System.Windows.Forms.Label lbCanBeSimplifiedOrNot;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDNF;
    }
}

