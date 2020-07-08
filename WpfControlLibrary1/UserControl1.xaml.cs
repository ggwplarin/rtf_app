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
using Microsoft.Win32;
using System.IO;

namespace WpfControlLibrary1
{
    /// <summary>
    /// Логика взаимодействия для UserControl1.xaml
    /// </summary>
    public partial class UserControl1 : UserControl
    {
        public ObservableCollection<int> fontSizes = new ObservableCollection<int>() { 8, 10, 12, 14, 16, 18, 24, 36, 48, 72 };
        public ObservableCollection<System.Drawing.FontFamily> fonts;
        public ObservableCollection<string> fontColors;


        public UserControl1()
        {
            fonts = new ObservableCollection<System.Drawing.FontFamily>(new InstalledFontCollection().Families);
            fontColors = new ObservableCollection<string>(typeof(Colors).GetProperties().Select(c=>c.Name));
            InitializeComponent();
            FontSizeSelector.ItemsSource = fontSizes;
            FontFamilySelector.ItemsSource = fonts;
            ColorSelector.ItemsSource = fontColors;
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Rich text files (*.rtf)|*.rtf|All files (*.*)|*.*";
            if (saveFileDialog.ShowDialog() == true)
            {
                FileStream fStream;
                TextRange range = new TextRange(Rich.Document.ContentStart, Rich.Document.ContentEnd);
                fStream = new FileStream(saveFileDialog.FileName, FileMode.Create);
                range.Save(fStream, DataFormats.Rtf);
                fStream.Close();
            }
        }

        private void OpenBtn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Rich text files (*.rtf)|*.rtf|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                TextRange range = new TextRange(Rich.Document.ContentStart, Rich.Document.ContentEnd);
                FileStream fStream = new FileStream(openFileDialog.FileName, FileMode.OpenOrCreate);
                range.Load(fStream, DataFormats.Rtf);

                fStream.Close();
            }
        }

        private void ColorSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Rich.Selection.ApplyPropertyValue(ForegroundProperty, ColorSelector.SelectedItem);
        }

        private void FontFamilySelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Rich.Selection.ApplyPropertyValue(FontFamilyProperty, ((System.Drawing.FontFamily)FontFamilySelector.SelectedItem).Name);
        }
    }
}
