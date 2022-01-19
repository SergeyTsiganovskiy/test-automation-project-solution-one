using framework.Helpers;
using framework.Settings;
using TechTalk.SpecFlow;
using tests.Hooks;
using tests.Pages;

namespace tests.Steps
{
    [Binding]
    internal class ExtendedSteps : HookInitialize
    {
        public ExtendedSteps(ParallelConfig parallelConfig, FeatureContext featureContext, ScenarioContext scenarioContext) : base(parallelConfig, featureContext, scenarioContext)
        {
        }

        public void NaviateSite()
        {
            _parallelConfig.Driver.Navigate().GoToUrl(_settings.Url);
            //LogHelpers.Write("Opened the browser !!!");
        }

        [Given(@"I have navigated to the application")]
        public void GivenIHaveNavigatedToTheApplication()
        {
            NaviateSite();
            _parallelConfig.CurrentPage = new HomePage(_parallelConfig);
        }


        [Given(@"I Delete employee '(.*)' before I start running test")]
        public void GivenIDeleteEmployeeBeforeIStartRunningTest(string employeeName)
        {
            string query = "delete from Employees where Name = '" + employeeName + "'";
            _settings.ApplicationDbConnection.ExecuteQuery(query);
        }

        [Given(@"I see application opened")]
        public void GivenISeeApplicationOpened()
        {
            _parallelConfig.CurrentPage.As<HomePage>().CheckIfLoginExist();
        }

        [Then(@"I click (.*) link")]
        public void ThenIClickLink(string linkName)
        {
            if (linkName == "login")
                _parallelConfig.CurrentPage = _parallelConfig.CurrentPage.As<HomePage>().ClickLogin();
            else if (linkName == "employeeList")
                _parallelConfig.CurrentPage = _parallelConfig.CurrentPage.As<HomePage>().ClickEmployeeList();
        }

        [Then(@"I click (.*) button")]
        public void ThenIClickButton(string buttonName)
        {
            if (buttonName == "login")
                _parallelConfig.CurrentPage = _parallelConfig.CurrentPage.As<LoginPage>().ClickLoginButton();
            if (buttonName == "logins")
                _parallelConfig.CurrentPage = _parallelConfig.CurrentPage.As<LoginPage>().ClickLoginButtons();
            else if (buttonName == "createnew")
                _parallelConfig.CurrentPage = _parallelConfig.CurrentPage.As<EmployeeListPage>().ClickCreateNew();
            else if (buttonName == "createnews")
                _parallelConfig.CurrentPage = _parallelConfig.CurrentPage.As<EmployeeListPage>().ClickCreateNews();
            else if (buttonName == "create")
                _parallelConfig.CurrentPage = _parallelConfig.CurrentPage.As<CreateEmployeePage>().ClickCreateButton();
        }

        [Then(@"I click log off")]
        public void ThenIClickLogOff()
        {
            _parallelConfig.CurrentPage.As<EmployeeListPage>().ClickLogoff();
        }


    }
}
