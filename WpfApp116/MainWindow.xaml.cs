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
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using System.IO;

namespace WpfApp116
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ChromeDriver chromeDriver = new ChromeDriver();
            chromeDriver.Navigate().GoToUrl("https://mail.ru");
            List<IWebElement> webElements = chromeDriver.FindElements(By.TagName("a")).ToList();
            foreach (var item in webElements)
            {
                if (!item.Displayed)
                    continue;
                if(!item.Text.Trim().ToLower().Equals("создать почту"))
                    continue;
                item.Click();
                break;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ChromeDriver chromeDriver = new ChromeDriver();
            chromeDriver.Navigate().GoToUrl("https://account.mail.ru/signup?from=main&rf=auth.mail.ru&app_id_mytracker=58519");
            Thread.Sleep(300);
            Registration.SetValueInField(chromeDriver, "fname", "Влад", "ислав");
            Thread.Sleep(300);
            Registration.SetValueInField(chromeDriver, "lname", "Дро", "здов");
            Thread.Sleep(300);
            Registration.SetDate(chromeDriver, "/html/body/div[1]/div[3]/div[3]/div[4]/div/div/div/div/form/div[9]/div[2]/div/div[1]/div/div", "react-select-2-option-2");
            Thread.Sleep(300);
            Registration.SetDate(chromeDriver, "/html/body/div[1]/div[3]/div[3]/div[4]/div/div/div/div/form/div[9]/div[2]/div/div/div/div[3]/div/div/div/div[1]", "react-select-3-option-6");
            Thread.Sleep(300);
            Registration.SetDate(chromeDriver, "/html/body/div[1]/div[3]/div[3]/div[4]/div/div/div/div/form/div[9]/div[2]/div/div/div/div[5]/div/div/div/div/div[1]", "react-select-4-option-19");
            Thread.Sleep(300);
            Registration.SetGender(chromeDriver, "male");
            Thread.Sleep(300);
            Registration.SetEmailAdress(chromeDriver, "/html/body/div[1]/div[3]/div[3]/div[4]/div/div/div/div/form/div[15]/div/div[2]/div[1]/div/div/div[1]/div/input");
    }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument(@"user-data-dir=C:\Users\vladd\AppData\Local\Google\Chrome\User Data");
            ChromeDriver chromeDriver = new ChromeDriver(chromeOptions);
            chromeDriver.Navigate().GoToUrl("https://vk.com/feed");
            Thread.Sleep(300);
            List<News> newsLst = new List<News>();
            List<IWebElement> webElements = chromeDriver.FindElements(By.TagName("div")).ToList();
            foreach (var item in webElements)
            {
                try
                {
                    if (!item.Displayed)
                        continue;
                }
                catch (Exception)
                {
                    continue;
                }
                if (item.GetAttribute("class") == null)
                    continue;
                if(!item.GetAttribute("class").Trim().Equals("feed_row"))
                    continue;
                IWebElement webElementDiv = item.FindElement(By.TagName("div"));
                Thread.Sleep(300);
                if (webElementDiv == null)
                    continue;
                if(webElementDiv.GetAttribute("id") == null)
                    continue;
        char[] separators = new char[] { '@' };
        string info_ = item.Text.Replace("\r\n", "@");
        string[] _info = info_.Split(separators, StringSplitOptions.RemoveEmptyEntries);
        string[] info= new string[_info.Length];
        for (int i = 0; i < info.Length;i++)
        {
          info[i] = _info[i].Trim();
        }
                newsLst.Add(new News() { Id = webElementDiv.GetAttribute("id"), Text = item.Text});
                //заполнить остальными данными
            }
        }
        private void SetDataInTextFile(IWebElement item)
        {
            using (StreamWriter streamWriter = new StreamWriter("text1.txt", true))
            {
                streamWriter.WriteLine(item.Text);
            }
        }
    }
}
