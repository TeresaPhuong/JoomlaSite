using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Xml;
using System.Diagnostics;
using System.IO;
using Newtonsoft.Json;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace JoomlaSite.Common_Action
{
    class Common
    {
        public static IWebDriver driver;
        #region Read Json file
        private static string GetClassCaller(int level = 4)
        {
            var m = new StackTrace().GetFrame(level).GetMethod();
            string className = m.DeclaringType.Name;
            return className;
        }
        public class control
        {
            public string name { get; set; }
            public string type { get; set; }
            public string value { get; set; }
        }
        public string[] GetControlValue(string controlname)
        {
            string ControlName = controlname.ToLower();
            string page = GetClassCaller();
            string path = Directory.GetParent(System.Reflection.Assembly.GetExecutingAssembly().Location).FullName;
            path = path.Replace("\\bin\\Debug", "");
            string content = string.Empty;
            switch (page)
            {
                case "Configure":
                    content = File.ReadAllText(path + @"\Configure.json");
                    break;
                case "AddArticlePage":
                case "EditArticlePage":
                    content = File.ReadAllText(path + @"\Interfaces\AddEditArticlePage.json");
                    break;
                default:
                    content = File.ReadAllText(path + @"\Interfaces\" + page + ".json");
                    break;
            }
            if (ControlName == "browser")
            {
                var result = JsonConvert.DeserializeObject<control>(content);
                string[] control = new string[2];
                control[0] = result.type;
                control[1] = result.value;
                return control;
            }
            else
            {
                var result = JsonConvert.DeserializeObject<List<control>>(content);
                string[] control = new string[2];
                foreach (var item in result)
                {
                    if (item.name.Equals(ControlName))
                    {
                        control[0] = item.type;
                        control[1] = item.value;
                        return control;
                    }
                }
                return null;
            }
        }
        public class datacontrol
        {
            public string dataname { get; set; }
            public string datavalue { get; set; }
        }
        public string GetData(string nameofdata)
        {
            nameofdata.ToLower();
            string path = Directory.GetParent(System.Reflection.Assembly.GetExecutingAssembly().Location).FullName;
            path = path.Replace("\\bin\\Debug", "\\Data.json");
            string content = string.Empty;
            content = File.ReadAllText(path);
            var result = JsonConvert.DeserializeObject<List<datacontrol>>(content);
            foreach (var item in result)
            {
                if (item.dataname.Equals(nameofdata))
                {
                    string value = item.datavalue;
                    return value;
                }
            }
            return null;
        }
        #endregion
        #region Basic Actions
        public IWebElement FindWebElement(string element)
        {
            string[] control = GetControlValue(element);
            switch (control[0])
            {
                case "id":
                    return driver.FindElement(By.Id(control[1]));
                case "classname":
                    return driver.FindElement(By.ClassName(control[1]));
                default:
                    return driver.FindElement(By.XPath(control[1]));
            }
        }

        public void ClickWebElement(string element)
        {
            WaitToPageLoad(element);
            FindWebElement(element).Click();
        }

        public void TypeText(string element, string text)
        {
            WaitToPageLoad(element);
            FindWebElement(element).Clear();
            FindWebElement(element).SendKeys(text);
        }

        public void SelectDropdownList(string element, string field, string selectvalue)
        {
            WaitToPageLoad(element);
            FindWebElement(element).Click();
            string[] control = GetControlValue(field + "_value");
            string value = string.Format(control[1], selectvalue);
            WaitToPageLoad(value);
            FindWebElement(value).Click();
        }

        public void WaitToPageLoad(string ElementToCheck)
        {
            string[] control = GetControlValue(ElementToCheck);
            switch (control[0])
            {
                case "id":
                    new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementExists((By.Id(control[1]))));
                    break;
                default:
                    new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementExists((By.XPath(control[1]))));
                    break;
            }
        }
        public void AcceptAlertPopup()
        {
            driver.SwitchTo().Alert().Accept();
        }
        public bool CompareMessageContent(string messagename, string element)
        {
            string message = GetData(messagename);
            if(FindWebElement(element).Text == message)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion
    }
}