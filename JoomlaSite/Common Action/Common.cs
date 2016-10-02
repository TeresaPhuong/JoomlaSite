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

namespace JoomlaSite.Common_Action
{
    class Common:Browser
    {
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

        public string[] GetControlValue(string ControlName)
        {
            ControlName.ToLower();
            string page = GetClassCaller();
            string path = Directory.GetParent(System.Reflection.Assembly.GetExecutingAssembly().Location).FullName;
            path = path.Replace("\\bin\\Debug", "");
            string content = string.Empty;
            switch (page)
            {
                case "LoginPage":
                    content = File.ReadAllText(path + @"\Interfaces\LoginPage.json");
                    break;
                case "GeneralPage":
                case "NewPageDialog":
                case "EditPageDialog":
                case "PanelConfigurationDialog":
                    content = File.ReadAllText(path + @"\Interfaces\GeneralPage\" + page + ".json");
                    break;
                case "PanelsPage":
                case "NewPanelDialog":
                    content = File.ReadAllText(path + @"\Interfaces\PanelsPage\" + page + ".json");
                    break;
                case "DataProfilesPage":
                case "GeneralSettingsPage":
                case "DisplayFieldsPage":
                    content = File.ReadAllText(path + @"\Interfaces\DataProfilesPage\" + page + ".json");
                    break;
                default:
                    break;
            }

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
        #endregion
        #region Basic Actions
        public IWebElement FindWebElement(string element)
        {
            string[] control = GetControlValue(element);
            return driver.FindElement(By.XPath(control[1]));
        }

        public void ClickWebElement(string element)
        {
            FindWebElement(element).Click();
        }

        public void TypeText(string element, string text)
        {
            FindWebElement(element).Clear();
            FindWebElement(element).SendKeys(text);
        }

        public void SelectDropdownList(string element,string field,string selectvalue)
        {
            FindWebElement(element).Click();
            string[] control = GetControlValue(field + "value");
            string value = string.Format(control[1], selectvalue);
            FindWebElement(selectvalue).Click();
        }

        public void WaitToPageLoad(string ElementToCheck)
        {
            //new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementExists((By.XPath(ElementToCheck))));
        }
        #endregion
    }
}