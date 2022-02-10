using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using System.Windows;

//Напишите программу, которая бы позволила вам по указанному адресу web-страницы 
//выбирать все ссылки на другие страницы, номера телефонов, почтовые адреса и сохраняла 
//полученный результат в файл. 

namespace Task_2
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

        private void getPage_Click(object sender, RoutedEventArgs e)
        {
            string urlStr = url.Text;
//          https://atm.pb.ua/ci/reports

            // Create a request for the URL. 
            WebRequest request = WebRequest.Create(urlStr);
            // Get the response.
            WebResponse response = request.GetResponse();
            // Display the status.
            outEdit.AppendText(((HttpWebResponse)response).StatusDescription + "\n\n");
            // Get the stream containing content returned by the server.
            Stream dataStream = response.GetResponseStream();
            // Open the stream using a StreamReader for easy access.
            StreamReader reader = new StreamReader(dataStream);
            // Read the content.
            string responseFromServer = reader.ReadToEnd();
            reader.Close();
            response.Close();

            //outEdit.AppendText(responseFromServer);

            var regex = new Regex(@"href='(?<link>\S+)'>");
            foreach (Match m in regex.Matches(responseFromServer))
            {
                outEdit.AppendText(" - " + m.Groups["link"] + "\n");
            }

        }

        private void saveToFile_Click(object sender, RoutedEventArgs e)
        {
            using (StreamWriter writer = new StreamWriter(new FileStream(@"save.txt", FileMode.CreateNew)))
            {
                writer.WriteLine(outEdit.Text);
                writer.Close();
            }
        }
    }
}
