namespace LogiX
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
            this.btnConvert = new System.Windows.Forms.Button();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.btnGraph = new System.Windows.Forms.Button();
            this.truthTable = new System.Windows.Forms.RichTextBox();
            this.SimplifiedTruthTable = new System.Windows.Forms.RichTextBox();
            this.btnClearAll = new System.Windows.Forms.Button();
            this.txtDNF = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnConvert
            // 
            this.btnConvert.Location = new System.Drawing.Point(49, 85);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(75, 23);
            this.btnConvert.TabIndex = 0;
            this.btnConvert.Text = "Convert";
            this.btnConvert.UseVisualStyleBackColor = true;
            this.btnConvert.Click += new System.EventHandler(this.Button1_Click);
            // 
            // txtInput
            // 
            this.txtInput.Location = new System.Drawing.Point(45, 36);
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(343, 20);
            this.txtInput.TabIndex = 1;
            // 
            // txtOutput
            // 
            this.txtOutput.Location = new System.Drawing.Point(45, 114);
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.Size = new System.Drawing.Size(343, 20);
            this.txtOutput.TabIndex = 2;
            // 
            // btnGraph
            // 
            this.btnGraph.Location = new System.Drawing.Point(130, 85);
            this.btnGraph.Name = "btnGraph";
            this.btnGraph.Size = new System.Drawing.Size(75, 23);
            this.btnGraph.TabIndex = 3;
            this.btnGraph.Text = "Get graph";
            this.btnGraph.UseVisualStyleBackColor = true;
            this.btnGraph.Click += new System.EventHandler(this.BtnGraph_Click);
            // 
            // truthTable
            // 
            this.truthTable.Location = new System.Drawing.Point(45, 178);
            this.truthTable.Name = "truthTable";
            this.truthTable.Size = new System.Drawing.Size(179, 196);
            this.truthTable.TabIndex = 4;
            this.truthTable.Text = "";
            // 
            // SimplifiedTruthTable
            // 
            this.SimplifiedTruthTable.Location = new System.Drawing.Point(243, 178);
            this.SimplifiedTruthTable.Name = "SimplifiedTruthTable";
            this.SimplifiedTruthTable.Size = new System.Drawing.Size(179, 196);
            this.SimplifiedTruthTable.TabIndex = 5;
            this.SimplifiedTruthTable.Text = "";
            // 
            // btnClearAll
            // 
            this.btnClearAll.Location = new System.Drawing.Point(211, 85);
            this.btnClearAll.Name = "btnClearAll";
            this.btnClearAll.Size = new System.Drawing.Size(75, 23);
            this.btnClearAll.TabIndex = 6;
            this.btnClearAll.Text = "Clear all";
            this.btnClearAll.UseVisualStyleBackColor = true;
            this.btnClearAll.Click += new System.EventHandler(this.BtnClearAll_Click);
            // 
            // txtDNF
            // 
            this.txtDNF.Location = new System.Drawing.Point(45, 140);
            this.txtDNF.Name = "txtDNF";
            this.txtDNF.Size = new System.Drawing.Size(343, 20);
            this.txtDNF.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtDNF);
            this.Controls.Add(this.btnClearAll);
            this.Controls.Add(this.SimplifiedTruthTable);
            this.Controls.Add(this.truthTable);
            this.Controls.Add(this.btnGraph);
            this.Controls.Add(this.txtOutput);
            this.Controls.Add(this.txtInput);
            this.Controls.Add(this.btnConvert);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnConvert;
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.TextBox txtOutput;
        private System.Windows.Forms.Button btnGraph;
        private System.Windows.Forms.RichTextBox truthTable;
        private System.Windows.Forms.RichTextBox SimplifiedTruthTable;
        private System.Windows.Forms.Button btnClearAll;
        private System.Windows.Forms.TextBox txtDNF;
    }
}

