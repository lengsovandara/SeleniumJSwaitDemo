using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumJSwaitDemo.Tool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumJSwaitDemo
{
    public class Fixtures
    {
        public IWebDriver _driver;
        public WebDriverWait _wait;
        public JSWaitHelper _jSWaitHelper;
        public IJavaScriptExecutor js;

        [SetUp]
        public void Setup()
        {
            InitDriver();
            // Wait set to 20 seconds, can be increased.
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(20));
            // In case we need to execute the Js scripts
            js = (IJavaScriptExecutor)_driver;
            //JS Helper;
            _jSWaitHelper = new JSWaitHelper(_driver, _wait, js);
        }

        private void InitDriver()
        {
            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("--window-size=1920,1080");
            chromeOptions.AddArgument("disable-infobars");
            _driver = new ChromeDriver(@"C:\WEBDRIVERS", chromeOptions);           
            _driver.Manage().Window.Maximize();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            _driver.Quit();
        }
        [TearDown]
        public void TearDown()
        {
            _driver.Manage().Cookies.DeleteAllCookies();
        }
    }
}
