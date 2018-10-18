﻿using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FirstWPF
{
    /// <summary>
    /// Interaction logic for MyControl.xaml
    /// </summary>
    public partial class MyControl : UserControl
    {
        public MyControl()
        {
            InitializeComponent();
        }

        public string FileName
        {
            get { return FBCTextBox.Text; }
            set { FBCTextBox.Text = value; }
        }
        public string BGColor
        {
            get { return FBCTextBox.Background.ToString(); }
            set
            {
                var converter = new System.Windows.Media.BrushConverter();
                FBCTextBox.Background = (Brush)converter.ConvertFromString(value);
            }
        }

        private void FBCButton_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog openFileDlg = new Microsoft.Win32.OpenFileDialog();

            if (openFileDlg.ShowDialog() == true)
                this.FileName = openFileDlg.FileName;
        }
        public event EventHandler<EventArgs> FileNameChanged;
        private void FBCTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            e.Handled = true;
            if (FileNameChanged != null)
                FileNameChanged(this, EventArgs.Empty);
        }
    }
}
