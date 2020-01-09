using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SeleniumJSwaitDemo.Tool
{
   public class JSWaitHelper
    {
        //Instance Fields;     
        private IWebDriver _driver;
        private WebDriverWait _wait;
        private IJavaScriptExecutor _js;

        //Constructor
        public JSWaitHelper(IWebDriver webDriver, WebDriverWait driverWait, IJavaScriptExecutor javaScriptExecutor)
        {
            this._driver = webDriver;
            this._wait = driverWait;
            this._js = javaScriptExecutor;
        }
        //Property
        
        //Method;
        public void waitUntilJSReady()
        {
            try
            {
                bool jsReady = _js.ExecuteScript("return document.readyState").Equals("complete");
                if (!jsReady)
                {
                    _wait.Until(wd => _js.ExecuteScript("return document.readyState").Equals("complete"));
                    Assert.IsTrue(true);
                }
                Assert.IsTrue(true);
            }
            catch (Exception)
            {
                Assert.IsTrue(false);
            }
        }
        public void waitUntilJQueryReady()
        {
            try
            {
                bool jQueryDefined = (bool)_js.ExecuteScript("return typeof jQuery != 'undefined'");
                if (jQueryDefined)
                {
                    sleep(20);
                    _wait.Until(wd => _js.ExecuteScript("return jQuery.active").Equals("0"));
                    Assert.IsTrue(true);
                    sleep(20);
                }
                Assert.IsTrue(true);
            }
            catch (Exception)
            {
                Assert.IsTrue(false);
            }
        }
        public void ajaxComplete()
        {
            _js.ExecuteScript("var callback = arguments[arguments.length - 1];"
                                + "var xhr = new XMLHttpRequest();" + "xhr.open('GET', '/Ajax_call', true);"
                                + "xhr.onreadystatechange = function() {" + "  if (xhr.readyState == 4) {"
                                + "    callback(xhr.responseText);" + "  }" + "};" + "xhr.send();");
        }
        private void sleep(int timeout)
        {
            Thread.Sleep(timeout);
        }
    }
}
