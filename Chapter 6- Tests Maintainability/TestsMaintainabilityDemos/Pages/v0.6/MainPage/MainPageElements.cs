﻿using OpenQA.Selenium;

namespace TestsMaintainabilityDemos.Sixth
{
    public class MainPageElements
    {
        private readonly Driver _driver;

        public MainPageElements(Driver driver) => _driver = driver;

        public Element AddToCartFalcon9 => _driver.FindElement(By.CssSelector("[data-product_id*='28']"));
        public Element ViewCartButton => _driver.FindElement(By.CssSelector("[class*='added_to_cart wc-forward']"));

        public Element GetProductBoxByName(string name)
        {
            return _driver.FindElement(By.XPath($"//h2[text()='{name}']/parent::a[1]"));
        }
    }
}
