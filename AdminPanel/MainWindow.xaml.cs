using AdminPanel.SQL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace AdminPanel
{
    public partial class MainWindow : Window
    {
        private int _durationTime;

        public MainWindow()
        {
            InitializeComponent();
            rbFirst.IsChecked = true;
        }

        private void btnKey_Click(object sender, RoutedEventArgs e)
        {
            btnKey.IsEnabled = false;
            string key = Randomer.GenerateKey();
            BackgroundWorker thrd = new BackgroundWorker();
            thrd.DoWork += new DoWorkEventHandler(Thrd_DoWork);
            thrd.RunWorkerCompleted += new RunWorkerCompletedEventHandler(Thrd_RunWorkerCompleted);
            
            tbKey.Text = key;
            tbKey.HorizontalAlignment = HorizontalAlignment.Center;

            object[] obj = new object[] { key, _durationTime };
            thrd.RunWorkerAsync(obj);
        }

        private void Thrd_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btnKey.IsEnabled = true;
        }

        private void Thrd_DoWork(object sender, DoWorkEventArgs e)
        {
            object[] args = e.Argument as object[];
            DataWorker.KeyQuery((string)args[0], (int)args[1]);
        }

        private void rb_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton rButton = (RadioButton)sender;
            _durationTime = Int32.Parse(rButton.Tag.ToString());
        }
    }
}