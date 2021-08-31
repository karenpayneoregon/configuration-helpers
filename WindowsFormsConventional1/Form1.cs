using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsConventional1.Classes;

namespace WindowsFormsConventional1
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
