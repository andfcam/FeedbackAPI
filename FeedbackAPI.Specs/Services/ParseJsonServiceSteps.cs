using Xunit;
using FeedbackAPI.Data.Models;
using FeedbackAPI.Web.Models;
using FeedbackAPI.Web.Services;
using TechTalk.SpecFlow;

namespace FeedbackAPI.Specs.Services
{
    [Binding]
    public class ParseJsonServiceSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private string _data;
        private dynamic _model;
        private StatusType _status;
        private Request _request;

        public ParseJsonServiceSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"I receive data to create a site with no site id")]
        public void GivenIReceiveDataToCreateASiteWithNoSiteId()
        {
            _data = ParseJsonService.ReadFromFile($"~/App_Data/request-1.json");
        }

        [Given(@"I receive data to update a site with no site id")]
        public void GivenIReceiveDataToUpdateASiteWithNoSiteId()
        {
            _data = ParseJsonService.ReadFromFile($"~/App_Data/request-5.json");
        }

        [Given(@"I receive data to create facilities with no facility ids")]
        public void GivenIReceiveDataToCreateFacilitiesWithNoFacilityIds()
        {
            _data = ParseJsonService.ReadFromFile($"~/App_Data/request-2.json");
        }

        [Given(@"I receive data to update facilities with no facility ids")]
        public void GivenIReceiveDataToUpdateFacilitiesWithNoFacilityIds()
        {
            _data = ParseJsonService.ReadFromFile($"~/App_Data/request-6.json");
        }

        [When(@"I parse the new request")]
        public void WhenIParseTheNewRequest()
        {
            _model = ParseJsonService.Deserialise(_data);
            _status = ParseJsonService.Validate(_model);
            _request = ParseJsonService.Parse(_model, _data, _status);
        }
        
        [Then(@"the request should be identified as a create site request")]
        public void ThenTheRequestShouldBeIdentifiedAsACreateSiteRequest()
        {
            Assert.IsType<SiteRequest>(_model);
            Assert.Equal(ActionType.Create, _request.Action);
        }
        
        [Then(@"the request should be identified as an update facility request")]
        public void ThenTheRequestShouldBeIdentifiedAsAnUpdateFacilityRequest()
        {
            Assert.IsType<FacilityRequest>(_model);
            Assert.Equal(ActionType.Update, _request.Action);
        }
        
        [Then(@"the request should have a site id")]
        public void ThenTheRequestShouldHaveASiteId()
        {
            Assert.NotEqual(0, _model.Site.Id);
        }
        
        [Then(@"the request should be rejected")]
        public void ThenTheRequestShouldBeRejected()
        {
            Assert.Equal(StatusType.Rejected, _request.Status);
        }
    }
}
