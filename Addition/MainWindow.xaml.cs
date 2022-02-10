using System.Text.RegularExpressions;
using System.Windows;


//Напишите консольное приложение, позволяющие пользователю зарегистрироваться под 
//«Логином», состоящем только из символов латинского алфавита, и пароля, состоящего из 
//цифр и символов. 

namespace Addition
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string petternLogin = @"^[A-Za-z]+$";
            string petternPassword = @"^[A-Za-z0-9\S]+$";

            if (!Regex.IsMatch(login.Text, petternLogin))
            {
                message.Content = "логин не соответствует шаблону!";
                return;
            }

            if (!Regex.IsMatch(passw.Text, petternPassword))
            {
                message.Content = "пароль не соответствует шаблону!";
                return;
            }

            message.Content = "Вы зарегестрированы!";
        }
    }
}
