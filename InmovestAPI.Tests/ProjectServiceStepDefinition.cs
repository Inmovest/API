using TechTalk.SpecFlow;

namespace InmovestAPI.Tests
{
    [Binding]
    public class ProjectServiceStepDefinition
    {
        [Given(@"the Endpoint https://localhost:(.*)/api/v(.*)/projects is available")]
        public void GivenTheEndpointHttpsLocalhostApiVProjectsIsAvailable(int port, int version)
        {
            //ScenarioContext.StepIsPending();
        }

        [Given(@"A Manager is already stored")]
        public void GivenAManagerIsAlreadyStored(Table table)
        {
            //ScenarioContext.StepIsPending();
        }

        [When(@"A Post Request is sent")]
        public void WhenAPostRequestIsSent(Table table)
        {
            //ScenarioContext.StepIsPending();
        }

        [Then(@"A Response with Status (.*) is received")]
        public void ThenAResponseWithStatusIsReceived(int p0)
        {
            //ScenarioContext.StepIsPending();
        }

        [Then(@"A Project Resource is included in Response")]
        public void ThenAProjectResourceIsIncludedInResponse(Table table)
        {
            //ScenarioContext.StepIsPending();
        }

        [Then(@"A Message of ""(.*)"" is included in Response Body")]
        public void ThenAMessageOfIsIncludedInResponseBody(string p0)
        {
            //ScenarioContext.StepIsPending();
        }
    }
}