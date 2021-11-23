using TechTalk.SpecFlow;

namespace InmovestAPI.Tests
{
    [Binding]
    public class CampaignServiceStepDefinition
    {
        [Given(@"the Endpoint https://localhost:(.*)/api/v(.*)/campaigns is available")]
        public void GivenTheEndpointHttpsLocalhostApiVCampaignsIsAvailable(int port, int version)
        {
            //ScenarioContext.StepIsPending();
        }

        [Given(@"A Project is already stored")]
        public void GivenAProjectIsAlreadyStored(Table table)
        {
            //ScenarioContext.StepIsPending();
        }

        [When(@"A Post Campaign Request is sent")]
        public void WhenAPostCampaignRequestIsSent(Table table)
        {
            //ScenarioContext.StepIsPending();
        }

        [Then(@"A Campaign Resource is included in Response")]
        public void ThenACampaignResourceIsIncludedInResponse(Table table)
        {
            //ScenarioContext.StepIsPending();
        }
    }
}