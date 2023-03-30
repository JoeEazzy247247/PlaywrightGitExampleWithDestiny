using BoDi;
using Microsoft.Playwright;
using TechTalk.SpecFlow;

namespace PlaywrightGitExampleWithDestiny
{
    [Binding]
    public sealed class BaseHooks
    {
        IObjectContainer _objectContainer;
        private IPlaywright _playwright;
        public IBrowser _browser;
        public IPage _page;
        public BaseHooks(IObjectContainer objectContainer)
        {
            this._objectContainer = objectContainer;
        }

        [BeforeScenario]
        public async Task BeforeScenarioWithTag()
        {
            _playwright = await Playwright.CreateAsync();
            _browser = await _playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Channel = "chrome",
                Headless = false,
                SlowMo = 10
            });
            _page = await _browser.NewPageAsync(new BrowserNewPageOptions
            {
                ViewportSize = new ViewportSize
                {
                    Height = 1080,
                    Width = 1920
                }
            });
            await _page.GotoAsync("https://demoqa.com");
            _objectContainer.RegisterInstanceAs(_page);
        }

        
        [AfterScenario]
        public async Task AfterScenario()
        {
            await _browser.CloseAsync();
        }
    }
}