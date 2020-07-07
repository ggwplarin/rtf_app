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
using System.Collections.ObjectModel;
using System.Drawing.Text;
using System.Drawing;

namespace WpfControlLibrary1
{
    /// <summary>
    /// Логика взаимодействия для UserControl1.xaml
    /// </summary>
    public partial class UserControl1 : UserControl
    {
        public ObservableCollection<int> fontSizes = new ObservableCollection<int>() { 8, 10, 12, 14, 16, 18, 24, 36, 48, 72 };
        public ObservableCollection<System.Drawing.FontFamily> fonts;
        
        
        public UserControl1()
        {
            fonts = new ObservableCollection<System.Drawing.FontFamily>(new InstalledFontCollection().Families);
            InitializeComponent();
            FontSizeSelector.ItemsSource = fontSizes;
            FontFamilySelector.ItemsSource = fonts;
        }
    }
}
