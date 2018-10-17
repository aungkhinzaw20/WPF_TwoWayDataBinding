using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FirstWPF
{
    /// <summary>
    /// Interaction logic for JsonStringReader.xaml
    /// </summary>
    public partial class JsonStringReader : Window
    {
        public JsonStringReader()
        {
            InitializeComponent();
        }

        private void btnCompute_Click(object sender, RoutedEventArgs e)
        {
            var objects = JArray.Parse(txtJsongStr.Text); // parse as array  
            foreach (JObject root in objects)
            {
                foreach (KeyValuePair<String, JToken> app in root)
                {
                    //var appName = app.Key;
                    //var description = (String)app.Value["Description"];
                    //var value = (String)app.Value["Value"];
                    txtOutput.Text = txtOutput.Text + Environment.NewLine + (String)app.Key + " = " + (String)app.Value;
                }
            }
        }
    }
}
