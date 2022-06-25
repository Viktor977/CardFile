using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace CardFile.TESTS.IntegrationTests
{
    public class ReactionIntegratonTest
    {
        private CardFileWebApplicationFactory _factory;
        private HttpClient _client;
        private const string RequestUri = "api/";

        [SetUp]
        public void Init()
        {
            _factory = new CardFileWebApplicationFactory();
            _client = _factory.CreateClient();
        }
        //------------------



        [TearDown]
        public void TearDown()
        {
            _factory.Dispose();
            _client.Dispose();
        }
    }
}
