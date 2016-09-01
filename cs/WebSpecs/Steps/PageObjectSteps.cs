﻿using BoDi;
using NUnit.Framework;
using TechTalk.SpecFlow;
using WebSpecs.Pages.Google;
using WebSpecs.Support;

namespace WebSpecs.Steps
{
    [Binding]
    public class GoogleHomePageSteps : Base
    {
        private HomePage HomePage { get { return (HomePage) base.Page; } }

        public GoogleHomePageSteps(IObjectContainer objectContainer) : base(objectContainer)
        {
        }

        [When(@"I click on Privacy")]
        public void WhenIClickOnPrivacy()
        {
            HomePage.Privacy.Click();
        }

        [When(@"I search for ""(.*)""")]
        public void WhenISearchFor(string text)
        {
            HomePage.Search(text);
        }

        [Then(@"the search entry should be ""(.*)""")]
        public void ThenTheSearchEntryShouldBe(string text)
        {
            Assert.That(HomePage.SearchText.Value, Is.EqualTo(text));
        }
    }
}
