using System;
using Coypu;
using NUnit.Framework;
using WebSpecs.Pages;

namespace WebSpecs.PageTests
{
    public class TestSite : Site
    {
        internal static readonly string AppHost = "test.com";

        public TestSite(SessionConfiguration configuration) : base(configuration, AppHost)
        {
        }
    }

    [TestFixture]
    public class SiteFactoryTests
    {
        [Test]
        public void Should_auto_register_sites()
        {
            Assert.That(SiteFactory.Instance.Find("TestSite"), Is.EqualTo(typeof(TestSite)));
        }

        [Test]
        public void Find_should_throw_if_site_class_cannot_be_found()
        {
            Assert.Throws<ArgumentException>(() => SiteFactory.Instance.Find("There should be no site with this name"));
        }

        [TestCase("TestSite")]
        [TestCase("Test Site")]
        [TestCase("PageTests.TestSite")]
        [TestCase("WebSpecs.PageTests.TestSite")]
        public void Find_should_locate_with_partial_or_full_class_name_match(string siteName)
        {
            Assert.That(SiteFactory.Instance.Find(siteName), Is.EqualTo(typeof(TestSite)));
        }

        [TestCase("PageTestsTestSite")]
        [TestCase("WebSpecsPageTestsTestSite")]
        public void Find_remove_punctuation_from_site_names(string siteName)
        {
            Assert.That(SiteFactory.Instance.Find(siteName), Is.EqualTo(typeof(TestSite)));
        }
    }
}
