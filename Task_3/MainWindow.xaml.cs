using Microsoft.Win32;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;

//Напишите шуточную программу «Дешифратор», которая бы в текстовом файле могла бы 
//заменить все предлоги на слово «ГАВ!». 

namespace Task_3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        string pathToFile;
        private void openBnt_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "txt |*.txt";
            if (openFileDialog.ShowDialog() == true)
            {
                pathToFile = openFileDialog.FileName;
            }

            using (StreamReader reader = new StreamReader(pathToFile))
            {
                edit.Clear();
                edit.AppendText(reader.ReadToEnd());
            }
        }

        private void parseBtn_Click(object sender, RoutedEventArgs e)
        {
            string pattern = @"\s[а-я]{1,3}\s";
            string newText = Regex.Replace(edit.Text, pattern, " гав! ");

            edit.Clear();
            edit.AppendText(newText);
        }

        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            using (StreamWriter writer = new StreamWriter(new FileStream(pathToFile, FileMode.OpenOrCreate)))
            {
                writer.WriteLine(edit.Text);
                writer.Close();
            }
        }
    }
}
