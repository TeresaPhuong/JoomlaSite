using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using JoomlaSite;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;

namespace JoomlaSite.Common_Action
{
    class Configure:Common
    {
        public string BrowserValue()
        {
            string[] control = GetControlValue("browser");
            return control[1];
        }
        public void StartBrowser()
        {
            string browser = BrowserValue();
            browser.ToLower();
            switch(browser)
            {
                case "chrome":
                    driver = new ChromeDriver();
                    break;
                case "firefox":
                    driver = new FirefoxDriver();
                    break;
                case "ie":
                case "internet explorer":
                    driver = new InternetExplorerDriver();
                    break;
            }
            driver.Manage().Window.Maximize();
        }
    }
}
