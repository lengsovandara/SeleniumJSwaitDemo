using NUnit.Framework;
using SeleniumJSwaitDemo.Tool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumJSwaitDemo
{
    [TestFixture]
    public class DemoScenarios : Fixtures
    {
        [TestCase]
        public void JavaScriptIsLoad()
        {
            _driver.Navigate().GoToUrl("https://www.truffaut.com/");
            _jSWaitHelper.waitUntilJSReady();
        }
        [TestCase]
        public void JQueryIsLoad()
        {
            _driver.Navigate().GoToUrl("http://google.com/");
            _jSWaitHelper.waitUntilJQueryReady();
        }
    }
}
