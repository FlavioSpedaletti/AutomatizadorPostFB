using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace WebBot
{
    public class ComboManipulador
    {
        private IWebElement _combo;
        private String _nomeCombo;
        ChromeDriver _browser;

        public ComboManipulador(ChromeDriver browser, string nomeCombo)
        {
            _nomeCombo = nomeCombo;
            _browser = browser;
            Load();
        }

        public void Load()
        {
            _combo = _browser.FindElement(By.Id(_nomeCombo));
        }

        public void SetNextItemCombo()
        {
            try
            {
                SelectElement cbox = new SelectElement(_combo);
                string tidx = this.GetSelectedIndex();
                if (!string.IsNullOrEmpty(tidx))
                {
                    int index = int.Parse(tidx);
                    index++;
                    cbox.SelectByIndex(index);
                }
            }
            catch
            {

            }
        }

        public bool ComboHasNextItem()
        {
            try
            {
                SelectElement cbox = new SelectElement(_combo);
                string tidx = GetSelectedIndex();
                if (!string.IsNullOrEmpty(tidx))
                {
                    int index = int.Parse(tidx);
                    int total = cbox.Options.Count;
                    index++;
                    return total > index;
                }

                return false;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public string GetSelectedIndex()
        {
            try
            {
                SelectElement cbox = new SelectElement(_combo);
                if (cbox.SelectedOption != null)
                {
                    var item = cbox.SelectedOption;
                    return item.GetAttribute("index");
                }

                return null;
            }
            catch
            {
                return null;
            }
        }
    }
}
