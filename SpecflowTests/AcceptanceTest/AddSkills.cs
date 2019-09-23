using System;
using TechTalk.SpecFlow;

namespace SpecflowTests.AcceptanceTest
{
    [Binding]
    public class AddSkills
    {
        [Given(@"I clicked on the Skills tab under Profile page")]
        public void GivenIClickedOnTheSkillsTabUnderProfilePage()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I add a new Skill")]
        public void WhenIAddANewSkill()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"that Skill should be displayed on my listings")]
        public void ThenThatSkillShouldBeDisplayedOnMyListings()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
