using System.Text;
using System.Windows.Forms;
using ConfigurationLibrary.Classes;
using static ConfigurationLibrary.Classes.ConfigurationHelper;

namespace MultiplesForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            ConfigurationMap map = Connections();

            StringBuilder builder = new();
            builder.AppendLine($"Current connection: {ConnectionString()}");
            builder.AppendLine($"Current environment: {CurrentEnvironment}");
            builder.AppendLine("");
            builder.AppendLine($"Development: {map.Development}");
            builder.AppendLine($"Stage: {map.Stage}");
            builder.AppendLine($"Prod: {map.Production}");

            ResultsTextBox.Text = builder.ToString();
            ResultsTextBox.Select(0, 0);
        }

    }
}
