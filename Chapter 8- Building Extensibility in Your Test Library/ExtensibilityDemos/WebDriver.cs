﻿using System;
using System.Collections.Generic;
using ExtensibilityDemos.Locators;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Opera;
using OpenQA.Selenium.Safari;
using OpenQA.Selenium.Support.UI;

namespace ExtensibilityDemos
{
    public class WebDriver : Driver
    {
        private IWebDriver _webDriver;
        private WebDriverWait _webDriverWait;
        private NativeElementFinderService _nativeElementFinderService;

        public WebDriver()
        {
           
        }
        public override Uri Url => new Uri(_webDriver.Url);

        public override void Start(Browser browser)
        {
            switch (browser)
            {
                case Browser.Chrome:
                    _webDriver = new ChromeDriver(Environment.CurrentDirectory);
                    break;
                case Browser.Firefox:
                    _webDriver = new FirefoxDriver(Environment.CurrentDirectory);
                    break;
                case Browser.Edge:
                    _webDriver = new EdgeDriver(Environment.CurrentDirectory);
                    break;
                case Browser.Opera:
                    _webDriver = new OperaDriver(Environment.CurrentDirectory);
                    break;
                case Browser.Safari:
                    _webDriver = new SafariDriver(Environment.CurrentDirectory);
                    break;
                case Browser.InternetExplorer:
                    _webDriver = new InternetExplorerDriver(Environment.CurrentDirectory);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(browser), browser, null);
            }

            _webDriverWait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(30));
            _webDriverWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            _webDriverWait.IgnoreExceptionTypes(typeof(WebDriverException));

            _nativeElementFinderService = new NativeElementFinderService(_webDriver);
        }

        public override void Quit()
        {
            _webDriver.Quit();
        }

        public override void GoToUrl(string url)
        {
            _webDriver.Navigate().GoToUrl(url);
        }

        ////public override Element FindElement(By locator)
        ////{
        ////    IWebElement nativeWebElement = _webDriverWait.Until(drv => drv.FindElement(locator));
        ////    Element element = new WebElement(_webDriver, nativeWebElement, locator);

        ////    // If we use log decorator.
        ////    LogElement logElement = new LogElement(element);

        ////    return logElement;
        ////}

        ////public override List<Element> FindElements(By locator)
        ////{
        ////    ReadOnlyCollection<IWebElement> nativeWebElements = _webDriverWait.Until(drv => drv.FindElements(locator));
        ////    List<Element> elements = new List<Element>();
        ////    foreach (var nativeWebElement in nativeWebElements)
        ////    {
        ////        Element element = new WebElement(_webDriver, nativeWebElement, locator);
        ////        elements.Add(element);
        ////    }

        ////    return elements;
        ////}

        public override List<Element> FindAllByClass(string cssClass)
        {
            var byClassStrategy = new ByClassStrategy(cssClass);
            var nativeElements = _nativeElementFinderService.FindAll(byClassStrategy);
            var resultElements = new List<Element>();
            foreach (var nativeElement in nativeElements)
            {
                resultElements.Add(new WebElement(_webDriver, nativeElement, byClassStrategy.Convert()));
            }
            return resultElements;
        }

        public override List<Element> FindAllById(string id)
        {
            var byClassStrategy = new ByIdStrategy(id);
            var nativeElements = _nativeElementFinderService.FindAll(byClassStrategy);
            var resultElements = new List<Element>();
            foreach (var nativeElement in nativeElements)
            {
                resultElements.Add(new WebElement(_webDriver, nativeElement, byClassStrategy.Convert()));
            }
            return resultElements;
        }

        public override List<Element> FindAllByTag(string tag)
        {
            var byClassStrategy = new ByTagStrategy(tag);
            var nativeElements = _nativeElementFinderService.FindAll(byClassStrategy);
            var resultElements = new List<Element>();
            foreach (var nativeElement in nativeElements)
            {
                resultElements.Add(new WebElement(_webDriver, nativeElement, byClassStrategy.Convert()));
            }
            return resultElements;
        }

        public override List<Element> FindAllByXPath(string xpath)
        {
            var byClassStrategy = new ByXPathStrategy(xpath);
            var nativeElements = _nativeElementFinderService.FindAll(byClassStrategy);
            var resultElements = new List<Element>();
            foreach (var nativeElement in nativeElements)
            {
                resultElements.Add(new WebElement(_webDriver, nativeElement, byClassStrategy.Convert()));
            }
            return resultElements;
        }

        public override List<Element> FindAllByCss(string css)
        {
            var byClassStrategy = new ByCssStrategy(css);
            var nativeElements = _nativeElementFinderService.FindAll(byClassStrategy);
            var resultElements = new List<Element>();
            foreach (var nativeElement in nativeElements)
            {
                resultElements.Add(new WebElement(_webDriver, nativeElement, byClassStrategy.Convert()));
            }
            return resultElements;
        }

        public override List<Element> FindAllByLinkText(string linkText)
        {
            var byClassStrategy = new ByLinkTextStrategy(linkText);
            var nativeElements = _nativeElementFinderService.FindAll(byClassStrategy);
            var resultElements = new List<Element>();
            foreach (var nativeElement in nativeElements)
            {
                resultElements.Add(new WebElement(_webDriver, nativeElement, byClassStrategy.Convert()));
            }
            return resultElements;
        }

        public override Element FindByCss(string css)
        {
            var byStrategy = new ByCssStrategy(css);
            var nativeElement = _nativeElementFinderService.Find(byStrategy);
            return new WebElement(_webDriver, nativeElement, byStrategy.Convert());
        }

        public override Element FindByLinkText(string linkText)
        {
            var byStrategy = new ByLinkTextStrategy(linkText);
            var nativeElement = _nativeElementFinderService.Find(byStrategy);
            return new WebElement(_webDriver, nativeElement, byStrategy.Convert());
        }

        public override Element FindByClass(string cssClass)
        {
            var byStrategy = new ByClassStrategy(cssClass);
            var nativeElement = _nativeElementFinderService.Find(byStrategy);
            return new WebElement(_webDriver, nativeElement, byStrategy.Convert());
        }

        public override Element FindById(string id)
        {
            var byStrategy = new ByIdStrategy(id);
            var nativeElement = _nativeElementFinderService.Find(byStrategy);
            return new WebElement(_webDriver, nativeElement, byStrategy.Convert());
        }

        public override Element FindByTag(string tag)
        {
            var byStrategy = new ByTagStrategy(tag);
            var nativeElement = _nativeElementFinderService.Find(byStrategy);
            return new WebElement(_webDriver, nativeElement, byStrategy.Convert());
        }

        public override Element FindByXPath(string xpath)
        {
            var byStrategy = new ByXPathStrategy(xpath);
            var nativeElement = _nativeElementFinderService.Find(byStrategy);
            return new WebElement(_webDriver, nativeElement, byStrategy.Convert());
        }

        public override void WaitForAjax()
        {
            var js = (IJavaScriptExecutor)_webDriver;
            _webDriverWait.Until(wd => js.ExecuteScript("return jQuery.active").ToString() == "0");
        }

        public override void WaitForJavaScriptAnimations()
        {
            var js = (IJavaScriptExecutor)_webDriver;
            _webDriverWait.Until(wd => js.ExecuteScript("jQuery(':animated').length").ToString() == "0");
        }

        public override void WaitUntilPageLoadsCompletely()
        {
            var js = (IJavaScriptExecutor)_webDriver;
            _webDriverWait.Until(wd => js.ExecuteScript("return document.readyState").ToString() == "complete");
        }

        public override List<TElement> FindAll<TByStrategy, TElement>(string value)
        {
            var byStrategy = (TByStrategy)Activator.CreateInstance(typeof(TByStrategy), value);
            var nativeElements = _nativeElementFinderService.FindAll(byStrategy);
            var resultElements = new List<TElement>();
            foreach (var nativeElement in nativeElements)
            {
                resultElements.Add(new WebElement(_webDriver, nativeElement, byStrategy.Convert()) as TElement);
            }
            return resultElements;
        }

        public override TElement Find<TByStrategy, TElement>(string value)
        {
            var byStrategy = (TByStrategy)Activator.CreateInstance(typeof(TByStrategy), value);
            var nativeElement = _nativeElementFinderService.Find(byStrategy);
            ////return new WebElement(_webDriver, nativeElement, byStrategy.Convert()) as TElement;

            // or

            return new LogElement(new WebElement(_webDriver, nativeElement, byStrategy.Convert())) as TElement;
        }
       
    }
}