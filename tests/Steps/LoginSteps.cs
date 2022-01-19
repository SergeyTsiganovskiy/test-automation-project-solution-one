using framework.Settings;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using tests.Hooks;
using tests.Pages;

namespace tests.Steps
{
    [Binding]
    public class LoginSteps : HookInitialize
    {
        public LoginSteps(ParallelConfig parallelConfig, FeatureContext featureContext, ScenarioContext scenarioContext) : base(parallelConfig, featureContext, scenarioContext)
        {
        }

        [When(@"I enter UserName and Password")]
        public void WhenIEnterUserNameAndPassword(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            _parallelConfig.CurrentPage.As<LoginPage>().Login(data.UserName, data.Password);
        }

        [Then(@"I should see the username with hello")]
        public void ThenIShouldSeeTheUsernameWithHello()
        {
            if (_parallelConfig.CurrentPage.As<HomePage>().GetLoggedInUser().Contains("admin"))
                System.Console.WriteLine("Sucess login");
            else
                System.Console.WriteLine("Unsucessful login");
        }


        [Then(@"I click logout")]
        public void ThenIClickLogout()
        {
            _parallelConfig.CurrentPage.As<HomePage>().ClickLogOff();
        }
    }
}
