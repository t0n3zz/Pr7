using System;
using System.Windows.Forms;
namespace pr7
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            matrixKeyTextBox = new TextBox();
            label2 = new Label();
            transpositionKeyTextBox = new TextBox();
            label3 = new Label();
            inputTextBox = new TextBox();
            encryptButton = new Button();
            decryptButton = new Button();
            label4 = new Label();
            textBox4resultTextBox = new TextBox();
            label5 = new Label();
            matrixTextBox = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(177, 19);
            label1.TabIndex = 0;
            label1.Text = "Ключевая фраза матрицы:";
            // 
            // matrixKeyTextBox
            // 
            matrixKeyTextBox.Location = new Point(12, 27);
            matrixKeyTextBox.Name = "matrixKeyTextBox";
            matrixKeyTextBox.Size = new Size(250, 23);
            matrixKeyTextBox.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F);
            label2.Location = new Point(12, 77);
            label2.Name = "label2";
            label2.Size = new Size(139, 19);
            label2.TabIndex = 2;
            label2.Text = "Ключ транспозиции:";
            // 
            // transpositionKeyTextBox
            // 
            transpositionKeyTextBox.Location = new Point(12, 95);
            transpositionKeyTextBox.Name = "transpositionKeyTextBox";
            transpositionKeyTextBox.Size = new Size(250, 23);
            transpositionKeyTextBox.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10F);
            label3.Location = new Point(367, 9);
            label3.Name = "label3";
            label3.Size = new Size(45, 19);
            label3.TabIndex = 4;
            label3.Text = "Текст:";
            // 
            // inputTextBox
            // 
            inputTextBox.Location = new Point(325, 27);
            inputTextBox.Multiline = true;
            inputTextBox.Name = "inputTextBox";
            inputTextBox.Size = new Size(400, 80);
            inputTextBox.TabIndex = 5;
            // 
            // encryptButton
            // 
            encryptButton.Location = new Point(420, 113);
            encryptButton.Name = "encryptButton";
            encryptButton.Size = new Size(100, 23);
            encryptButton.TabIndex = 6;
            encryptButton.Text = "Зашифровать";
            encryptButton.UseVisualStyleBackColor = true;
            // 
            // decryptButton
            // 
            decryptButton.Location = new Point(526, 113);
            decryptButton.Name = "decryptButton";
            decryptButton.Size = new Size(100, 23);
            decryptButton.TabIndex = 7;
            decryptButton.Text = "Расшифровать";
            decryptButton.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 11F);
            label4.Location = new Point(334, 195);
            label4.Name = "label4";
            label4.Size = new Size(78, 20);
            label4.TabIndex = 8;
            label4.Text = "Результат:";
            label4.Click += label4_Click;
            // 
            // textBox4resultTextBoxЫ
            // 
            textBox4resultTextBox.BackColor = SystemColors.Window;
            textBox4resultTextBox.Location = new Point(174, 230);
            textBox4resultTextBox.Multiline = true;
            textBox4resultTextBox.Name = "textBox4resultTextBoxЫ";
            textBox4resultTextBox.ReadOnly = true;
            textBox4resultTextBox.Size = new Size(400, 80);
            textBox4resultTextBox.TabIndex = 9;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 11F);
            label5.Location = new Point(325, 323);
            label5.Name = "label5";
            label5.Size = new Size(101, 20);
            label5.TabIndex = 10;
            label5.Text = "Матрица 6х6:";
            // 
            // matrixTextBox
            // 
            matrixTextBox.Font = new Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            matrixTextBox.Location = new Point(174, 346);
            matrixTextBox.Multiline = true;
            matrixTextBox.Name = "matrixTextBox";
            matrixTextBox.ReadOnly = true;
            matrixTextBox.Size = new Size(400, 140);
            matrixTextBox.TabIndex = 11;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 721);
            Controls.Add(matrixTextBox);
            Controls.Add(label5);
            Controls.Add(textBox4resultTextBox);
            Controls.Add(label4);
            Controls.Add(decryptButton);
            Controls.Add(encryptButton);
            Controls.Add(inputTextBox);
            Controls.Add(label3);
            Controls.Add(transpositionKeyTextBox);
            Controls.Add(label2);
            Controls.Add(matrixKeyTextBox);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox matrixKeyTextBox;
        private Label label2;
        private TextBox transpositionKeyTextBox;
        private Label label3;
        private TextBox inputTextBox;
        private Button encryptButton;
        private Button decryptButton;
        private Label label4;
        private TextBox textBox4resultTextBox;
        private Label label5;
        private TextBox matrixTextBox;
    }
}
