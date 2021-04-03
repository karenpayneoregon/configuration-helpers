using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
            _textBoxeslist = new List<TextBox>()
            {
                txtFirstName, 
                txtLastName, 
                txtEmailAddress, 
                txtboxAddress, 
                txtPassword, 
                txtboxContact
            };
        }

        private List<TextBox> _textBoxeslist;
        private void SignUpButton_Click(object sender, EventArgs e)
        {
            
            if (_textBoxeslist.Any(textbox => string.IsNullOrWhiteSpace(textbox.Text)))
            {
                MessageBox.Show("Please ensure all fields have been entered!");
            }
            else
            {
                List<string> customerEmails = null;
                customerEmails = checkBox2.Checked ? new List<string>() {""} : new List<string>();

                
                if (customerEmails.Count() >=1)
                {
                    Debug.WriteLine("Have emails");
                }
                else
                {
                    Debug.WriteLine("Have no emails");
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                _textBoxeslist.ForEach(tb => tb.Text = "Hello");
            }
            else
            {
                _textBoxeslist.ForEach(tb => tb.Text = "");
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                
            }
        }
    }
}
