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
            this.btnTableaux = new System.Windows.Forms.Button();
            this.txtInputPredicate = new System.Windows.Forms.TextBox();
            this.txtOutputPredicate = new System.Windows.Forms.TextBox();
            this.btnPredicateReading = new System.Windows.Forms.Button();
            this.txtHashtruthTable = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnConvert
            // 
            this.btnConvert.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConvert.Location = new System.Drawing.Point(8, 118);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(94, 33);
            this.btnConvert.TabIndex = 0;
            this.btnConvert.Text = "Convert";
            this.btnConvert.UseVisualStyleBackColor = true;
            this.btnConvert.Click += new System.EventHandler(this.Button1_Click);
            // 
            // txtInput
            // 
            this.txtInput.BackColor = System.Drawing.SystemColors.Window;
            this.txtInput.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInput.Location = new System.Drawing.Point(113, 12);
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(869, 27);
            this.txtInput.TabIndex = 1;
            // 
            // txtOutput
            // 
            this.txtOutput.BackColor = System.Drawing.SystemColors.Window;
            this.txtOutput.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOutput.Location = new System.Drawing.Point(113, 45);
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.Size = new System.Drawing.Size(869, 27);
            this.txtOutput.TabIndex = 2;
            // 
            // btnGraph
            // 
            this.btnGraph.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGraph.Location = new System.Drawing.Point(108, 120);
            this.btnGraph.Name = "btnGraph";
            this.btnGraph.Size = new System.Drawing.Size(98, 31);
            this.btnGraph.TabIndex = 3;
            this.btnGraph.Text = "Get graph";
            this.btnGraph.UseVisualStyleBackColor = true;
            this.btnGraph.Click += new System.EventHandler(this.BtnGraph_Click);
            // 
            // truthTable
            // 
            this.truthTable.Font = new System.Drawing.Font("MS Reference Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.truthTable.Location = new System.Drawing.Point(27, 167);
            this.truthTable.Name = "truthTable";
            this.truthTable.Size = new System.Drawing.Size(179, 196);
            this.truthTable.TabIndex = 4;
            this.truthTable.Text = "";
            // 
            // SimplifiedTruthTable
            // 
            this.SimplifiedTruthTable.Font = new System.Drawing.Font("MS Reference Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SimplifiedTruthTable.Location = new System.Drawing.Point(228, 167);
            this.SimplifiedTruthTable.Name = "SimplifiedTruthTable";
            this.SimplifiedTruthTable.Size = new System.Drawing.Size(179, 196);
            this.SimplifiedTruthTable.TabIndex = 5;
            this.SimplifiedTruthTable.Text = "";
            // 
            // btnClearAll
            // 
            this.btnClearAll.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearAll.Location = new System.Drawing.Point(212, 121);
            this.btnClearAll.Name = "btnClearAll";
            this.btnClearAll.Size = new System.Drawing.Size(87, 30);
            this.btnClearAll.TabIndex = 6;
            this.btnClearAll.Text = "Clear all";
            this.btnClearAll.UseVisualStyleBackColor = true;
            this.btnClearAll.Click += new System.EventHandler(this.BtnClearAll_Click);
            // 
            // txtDNF
            // 
            this.txtDNF.BackColor = System.Drawing.SystemColors.Window;
            this.txtDNF.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDNF.Location = new System.Drawing.Point(113, 78);
            this.txtDNF.Name = "txtDNF";
            this.txtDNF.Size = new System.Drawing.Size(869, 27);
            this.txtDNF.TabIndex = 8;
            // 
            // btnTableaux
            // 
            this.btnTableaux.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTableaux.Location = new System.Drawing.Point(305, 121);
            this.btnTableaux.Name = "btnTableaux";
            this.btnTableaux.Size = new System.Drawing.Size(95, 32);
            this.btnTableaux.TabIndex = 9;
            this.btnTableaux.Text = "Tableaux";
            this.btnTableaux.UseVisualStyleBackColor = true;
            this.btnTableaux.Click += new System.EventHandler(this.BtnTableaux_Click);
            // 
            // txtInputPredicate
            // 
            this.txtInputPredicate.BackColor = System.Drawing.SystemColors.Window;
            this.txtInputPredicate.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInputPredicate.Location = new System.Drawing.Point(497, 218);
            this.txtInputPredicate.Name = "txtInputPredicate";
            this.txtInputPredicate.Size = new System.Drawing.Size(343, 27);
            this.txtInputPredicate.TabIndex = 10;
            // 
            // txtOutputPredicate
            // 
            this.txtOutputPredicate.BackColor = System.Drawing.SystemColors.Window;
            this.txtOutputPredicate.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOutputPredicate.Location = new System.Drawing.Point(497, 289);
            this.txtOutputPredicate.Name = "txtOutputPredicate";
            this.txtOutputPredicate.Size = new System.Drawing.Size(343, 27);
            this.txtOutputPredicate.TabIndex = 11;
            // 
            // btnPredicateReading
            // 
            this.btnPredicateReading.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPredicateReading.Location = new System.Drawing.Point(497, 251);
            this.btnPredicateReading.Name = "btnPredicateReading";
            this.btnPredicateReading.Size = new System.Drawing.Size(144, 32);
            this.btnPredicateReading.TabIndex = 12;
            this.btnPredicateReading.Text = "Read Predicate";
            this.btnPredicateReading.UseVisualStyleBackColor = true;
            this.btnPredicateReading.Click += new System.EventHandler(this.BtnPredicateReading_Click);
            // 
            // txtHashtruthTable
            // 
            this.txtHashtruthTable.BackColor = System.Drawing.SystemColors.Window;
            this.txtHashtruthTable.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHashtruthTable.Location = new System.Drawing.Point(228, 380);
            this.txtHashtruthTable.Name = "txtHashtruthTable";
            this.txtHashtruthTable.Size = new System.Drawing.Size(189, 27);
            this.txtHashtruthTable.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(4, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 20);
            this.label1.TabIndex = 14;
            this.label1.Text = "Input:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 383);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(210, 20);
            this.label2.TabIndex = 15;
            this.label2.Text = "Hashcode for TruthTable";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(4, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 20);
            this.label3.TabIndex = 16;
            this.label3.Text = "Output:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(4, 81);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 20);
            this.label4.TabIndex = 17;
            this.label4.Text = "DNF String:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(406, 127);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(254, 20);
            this.label5.TabIndex = 18;
            this.label5.Text = "Tableux is still not completed";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(987, 423);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtHashtruthTable);
            this.Controls.Add(this.btnPredicateReading);
            this.Controls.Add(this.txtOutputPredicate);
            this.Controls.Add(this.txtInputPredicate);
            this.Controls.Add(this.btnTableaux);
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
            this.Load += new System.EventHandler(this.Form1_Load);
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
        private System.Windows.Forms.Button btnTableaux;
        private System.Windows.Forms.TextBox txtInputPredicate;
        private System.Windows.Forms.TextBox txtOutputPredicate;
        private System.Windows.Forms.Button btnPredicateReading;
        private System.Windows.Forms.TextBox txtHashtruthTable;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}

