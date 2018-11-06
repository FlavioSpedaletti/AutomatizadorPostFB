using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace WebBot
{
    public class Robo
    {
        public void Execute()
        {
            #region Configurações
            var driver = new ChromeDriver();
            var user = "flavio.hfs@gmail.com";
            var pass = "xxxx";
            var postUrl = "https://www.facebook.com/PequenosDEVS/posts/2225388261117208";
            var groupName = "Comunidade Scratch Brasil - Imagine, Programe, Compartilhe!";
            var message = "Teste";
            #endregion

            driver.Navigate().GoToUrl("https://www.facebook.com");

            var txtEmail = driver.FindElementById("email");
            txtEmail.SendKeys(user);

            var txtPass = driver.FindElementById("pass");
            txtPass.Click();
            //txtPass.SendKeys(pass);
            //txtPass.Submit();

            Console.ReadKey();

            driver.Navigate().GoToUrl(postUrl);

            //Botão compartilhar
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement ahrefFirstShare = wait.Until<IWebElement>(d => d.FindElement(By.ClassName("share_action_link")));
            ahrefFirstShare.Click();

            //Botão compartilhar no grupo
            driver.FindElementByClassName("_54nc").Click();

            //Caixa de texto para digitar nome do grupo
            var txtGroupName = wait.Until<IWebElement>(d => ((IWebElement)((IJavaScriptExecutor)driver).ExecuteScript("return document.querySelector(\"input[name='audience_group']\")")));
            txtGroupName.SendKeys(groupName);
            txtGroupName.SendKeys(Keys.Down);
            txtGroupName.SendKeys(Keys.Return);

            //Caixa de texto para escrever mensagem de compartilhamento (opcional)
            //var txtMsg = (IWebElement)((IJavaScriptExecutor)driver).ExecuteScript("return document.evaluate(\"//div[contains(text(), 'Say something about this...')]\", document, null, XPathResult.FIRST_ORDERED_NODE_TYPE, null).singleNodeValue");
            var txtMsg = (IWebElement)((IJavaScriptExecutor)driver).ExecuteScript("return document.querySelector(\"div[aria-autocomplete='list']\")");
            txtMsg.Click();
            txtMsg.SendKeys(message);

            //Botão Post
            //var btnPost = wait.Until<IWebElement>(d => ((IWebElement)((IJavaScriptExecutor)driver).ExecuteScript("return document.querySelector(\"div[data-tooltip-content='People who can see posts in the group'] + div > button:nth-child(2)\")")));
            //btnPost.Click();

            Console.ReadKey();
        }
    }
}
