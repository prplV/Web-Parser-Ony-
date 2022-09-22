using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;


namespace WpfApp116
{
    class Registration
    {
        public static void SetValueInField(ChromeDriver chromeDriver, string Id, string ValueStart, string ValueEnd)
        {
            List<IWebElement> webElements = chromeDriver.FindElements(By.Id(Id)).ToList();
            Random random = new Random();
            Thread.Sleep(300);
            string full_name =  ValueStart + ValueEnd;
            Thread.Sleep(300);
            foreach (var item in webElements)
            {
                if (!item.Displayed)
                    continue;
                for (int i = 0; i < full_name.Length; i++)
                {
                    item.SendKeys(Convert.ToString(full_name[i]));
                    Thread.Sleep(random.Next(100, 201));
                }
                /*item.SendKeys(ValueStart);
                Thread.Sleep(500);
                item.SendKeys(ValueEnd);*/
                //каждую букву Value вводить с задержкой 100-200 мс (done!)
            }
        }
        public static void SetDate(ChromeDriver chromeDriver, string Xpath, string ID)
        {
            Random random = new Random();
            Thread.Sleep(300);
            List<IWebElement> webElements = chromeDriver.FindElements(By.XPath(Xpath)).ToList();
            foreach (var item in webElements)
            {
                if (!item.Displayed)
                    continue;
                item.Click();
                break;
            }
      //при открытии списка и выборе значений сделать рандомную задержку от 100 до 1000 (done!)
            Thread.Sleep(random.Next(100,1001));
            webElements = chromeDriver.FindElements(By.Id(ID)).ToList();
            foreach (var item in webElements)
            {
                if (!item.Displayed)
                    continue;
                item.Click();
                break;
            }
            //разобраться почему работает (done!)
        }
        public static void SetGender(ChromeDriver chromeDriver, string Gender)
        {
            string Male_XPath = "/html/body/div[1]/div[3]/div[3]/div[4]/div/div/div/div/form/div[12]/div[2]/div/label[1]/div[1]/div[2]";
            string  Female_XPath = "/html/body/div[1]/div[3]/div[3]/div[4]/div/div/div/div/form/div[12]/div[2]/div/label[2]/div[1]/div[2]";
            Thread.Sleep(300);
            if (Gender == "male")
            {
                List<IWebElement> webElements = chromeDriver.FindElements(By.XPath(Male_XPath)).ToList();
                foreach (var item in webElements)
                {
                    if (!item.Displayed)
                        continue;
                    item.Click();
                        break;
                }
            }
            else if (Gender == "female") 
            {
                List<IWebElement> webElements = chromeDriver.FindElements(By.XPath(Female_XPath)).ToList();
                foreach (var item in webElements)
                {
                    if (!item.Displayed)
                        continue;
                    item.Click();
                    break;
                }
            }
        }
    public static void SetEmailAdress(ChromeDriver chromeDriver, string Xpath)
    {
      Random random = new Random();
      string email = null;
      string symbols = "_-.";
      string alph = "qwertyuiopasdfghjklzxcvbnm";
      int length = random.Next(10, 15);
      int length_1 = random.Next(1, 6);
      int length_2 = random.Next(3, 5);
      int length_3 = length - (length_1 + length_2);
      List<IWebElement> webElements = chromeDriver.FindElements(By.XPath(Xpath)).ToList();
      Thread.Sleep(300);
      foreach (var element in webElements)
      {
        if (!element.Displayed)
          continue;
        for (int j = 0; j < length_1; j++)
        {
          email = email + alph[random.Next(0, alph.Length - 1)];
        }
        email = email + symbols[random.Next(0, symbols.Length - 1)];
        for (int j = 0; j < length_2; j++)
        {
          email = email + alph[random.Next(0, alph.Length - 1)];
        }
        email = email + symbols[random.Next(0, symbols.Length - 1)];
        for (int j = 0; j < length_3; j++)
        {
          email = email + alph[random.Next(0, alph.Length - 1)];
        }
        
        for (int i = 0; i < email.Length; i++)
        {
          element.SendKeys(Convert.ToString(email[i]));
          Thread.Sleep(random.Next(100,300));
        }

      }
    }
    }
}
