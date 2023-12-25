using CommunityToolkit.Mvvm.Messaging;
using CustomControls.messages;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CustomControls
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {

            var items = new List<viewmodels.SimpleStringItem>();
            for (int i = 0; i < 100; i++)
            {
                items.Add(new viewmodels.SimpleStringItem(false, $"Item {i}"));
            }
            var vm = new viewmodels.SimpleStringSearchableViewModel(items);

            InitializeComponent();
           
            lstctrl.DataContext = vm;
        }
    }
}
