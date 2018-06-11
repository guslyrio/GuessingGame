using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace HoplonGuessingGame
{
    public class InputDialog
    {
        public InputDialog() { }

        public static DialogResult Show(string label, string title, ref string input)
        {
            System.Drawing.Size size = new System.Drawing.Size(480, 127);
            Form inputBox = new Form();

            inputBox.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            inputBox.ClientSize = size;
            inputBox.Text = title;
            inputBox.StartPosition = FormStartPosition.CenterScreen;

            System.Windows.Forms.Label textLabel = new Label();
            textLabel.Size = new System.Drawing.Size(size.Width - 30, 23);
            textLabel.Location = new System.Drawing.Point(15, 15);
            textLabel.Text = label;
            inputBox.Controls.Add(textLabel);

            System.Windows.Forms.TextBox textBox = new TextBox();
            textBox.Size = new System.Drawing.Size(size.Width - 30, 23);
            textBox.Location = new System.Drawing.Point(15, 35);
            textBox.Text = "";
            inputBox.Controls.Add(textBox);

            Button okButton = new Button();
            okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            okButton.Name = "okButton";
            okButton.Size = new System.Drawing.Size(75, 23);
            okButton.Text = "&OK";
            okButton.Location = new System.Drawing.Point(size.Width - 75 - 15, 81);
            inputBox.Controls.Add(okButton);

            inputBox.AcceptButton = okButton;
            
            DialogResult result = inputBox.ShowDialog();
            input = textBox.Text;
            return result;
        }
    }
}
