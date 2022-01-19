using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using tests.Pages;
using tests.Hooks;
using framework.Settings;

namespace tests.Steps
{
    [Binding]
    public class CreateEmployeeStep : HookInitialize
    {
        public CreateEmployeeStep(ParallelConfig parallelConfig, FeatureContext featureContext, ScenarioContext scenarioContext) : base(parallelConfig, featureContext, scenarioContext)
        {
        }

        [Then(@"I enter following details")]
        public void ThenIEnterFollowingDetails(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            _parallelConfig.CurrentPage.As<CreateEmployeePage>().CreateEmployee(data.Name,
                data.Salary.ToString(), data.DurationWorked.ToString(), data.Grade.ToString(), data.Email);

        }

        [Then(@"I create and delete user")]
        public void ThenICreateAndDeleteUser()
        {
            //ScenarioContext.Current.Pending();
        }
    }
}
