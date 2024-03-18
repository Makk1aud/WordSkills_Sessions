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
using Word_Skills_Desktop.Helpers;
using Word_Skills_Desktop.Pages;

namespace Word_Skills_Desktop
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainClass.FrameMainStruct = FrameMainStruct;
            MainClass.Context = new Models.WorldSkillsEntities();
            MainClass.FrameMainStruct.Navigate(new PageAuthorization());
        }
    }
}
