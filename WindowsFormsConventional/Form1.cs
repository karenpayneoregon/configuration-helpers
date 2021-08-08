using System;
using System.Windows.Forms;
using WindowsFormsConventional.Classes;

namespace WindowsFormsConventional
{
    public partial class Form1 : Form
    {
        private readonly BindingSource _bindingSource = new BindingSource();
        public Form1()
        {
            InitializeComponent();
     
            Shown += OnShown;
        }

        private void OnShown(object sender, EventArgs e)
        {

            var (success, exception) = Operations.TestConnection();
            if (success)
            {
                var (dataTable, _) = Operations.GetCourses();
                
                _bindingSource.DataSource = dataTable;
                dataGridView1.DataSource = _bindingSource;
            }
            else
            {
                MessageBox.Show(exception.Message);
            }


        }
    }
}
