using BoDi;
using Microsoft.Playwright;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;

namespace PlaywrightGitExampleWithDestiny.StepDefinitions
{
    [Binding]
    public class DemoqaStepDefinitions
    {
        private IPage _page;
        public DemoqaStepDefinitions(IObjectContainer objectContainer)
        {
            _page = objectContainer.Resolve<IPage>();
        }

        [Given(@"I am on demoqa site")]
        public async Task GivenIAmOnDemoqaSite()
        {
            Assert.True(await Task.FromResult(_page.Url.Contains("demoqa")));
        }

        [When(@"I click elements")]
        public async Task WhenIClickElements()
        {
            await _page.GetByText("Elements").ClickAsync();
        }

        [Then(@"I am on elements page")]
        public async Task ThenIAmOnElementsPage()
        {
            Assert.True(await Task.FromResult(_page.Url.Contains("elements")));
        }
    }
}
