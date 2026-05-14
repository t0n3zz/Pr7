using System;
using System.Windows.Forms;

namespace pr7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            encryptButton.Click += EncryptButton_Click;
            decryptButton.Click += DecryptButton_Click;
        }

        private void EncryptButton_Click(object sender, EventArgs e)
        {
            try
            {
                AdfgvxCipher cipher = new AdfgvxCipher(
                    matrixKeyTextBox.Text,
                    transpositionKeyTextBox.Text);

                textBox4resultTextBox.Text = cipher.Encrypt(inputTextBox.Text);
                matrixTextBox.Text = cipher.GetMatrixAsText();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DecryptButton_Click(object sender, EventArgs e)
        {
            try
            {
                AdfgvxCipher cipher = new AdfgvxCipher(
                    matrixKeyTextBox.Text,
                    transpositionKeyTextBox.Text);

                textBox4resultTextBox.Text = cipher.Decrypt(inputTextBox.Text);
                matrixTextBox.Text = cipher.GetMatrixAsText();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
        }
    }
}