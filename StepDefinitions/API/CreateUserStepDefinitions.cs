using RestSharp;
using SpecFlowAutomationFramework.Helpers.API;
using SpecFlowAutomationFramework.Models.Request;
using SpecFlowAutomationFramework.Utility;
using System;
using System.Net;
using TechTalk.SpecFlow;

namespace SpecFlowAutomationFramework.StepDefinitions.API
{
    [Binding]
    public class CreateUserStepDefinitions
    {
        private CreateUserReq createUserReq;
        private RestResponse response;
        private ScenarioContext scenarioContext;
        private HttpStatusCode statusCode;

        
        public CreateUserStepDefinitions(CreateUserReq createUserReq, ScenarioContext scenarioContext)
        {
            this .createUserReq = createUserReq;
            this.scenarioContext = scenarioContext;
                
        }


        [Given(@"user with name ""([^""]*)""")]
        public void GivenUserWithName(string name)
        {
           createUserReq.name = name;


        }

        [Given(@"user with job ""([^""]*)""")]
        public void GivenUserWithJob(string job)
        {
            createUserReq.job = job;
        }

        [When(@"Send request to create user")]
        public async Task WhenSendRequestToCreateUser()
        {
            var api = new APIClient();
           response = await api.CreateUser<CreateUserReq>(createUserReq);

        }

        [Then(@"Validate user is created")]
        public void ThenValidateUserIsCreated()
        {
           statusCode = response.StatusCode;
            var code = (int)statusCode;
            ClassicAssert.AreEqual(201, code);


            var content=HandleContent.getContent<CreateUserReq> (response);
            ClassicAssert.AreEqual(createUserReq.name, content.name);
            ClassicAssert.AreEqual(createUserReq.job, content.job);
        }
    }
}
