/* 
 * Marketing Cloud REST API
 *
 * Marketing Cloud's REST API is our newest API. It supports multi-channel use cases, is much more lightweight and easy to use than our SOAP API, and is getting more comprehensive with every release.
 *
 * OpenAPI spec version: 1.0.0
 * Contact: mc_sdk@salesforce.com
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */

using System;
using System.IO;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using RestSharp;
using NUnit.Framework;

using IO.Swagger.Client;
using IO.Swagger.Api;
using IO.Swagger.Model;

namespace IO.Swagger.Test
{
    /// <summary>
    ///  Class for testing CampaignsApi
    /// </summary>
    /// <remarks>
    /// This file is automatically generated by Swagger Codegen.
    /// Please update the test case below to test the API endpoint.
    /// </remarks>
    [TestFixture]
    public class CampaignsApiTests : ApiTests
    {
        private CampaignsApi instance;

        /// <summary>
        /// Setup before each unit test
        /// </summary>
        [SetUp]
        public void Init()
        {
            instance = new CampaignsApi(authBasePath,
                clientId,
                clientSecret,
                accountId);
        }

        /// <summary>
        /// Clean up after each unit test
        /// </summary>
        [TearDown]
        public void Cleanup()
        {

        }
        
        [Test]
        public void CreateCampaignTest()
        {
            string name = "Name1";
            string description = "Description1"; ;
            string campaignCode = "CampaignCode1"; ;
            string color = "000000";
            bool? favorite = true;

            var response = instance.CreateCampaign(name, description, campaignCode, color, favorite);

            Assert.IsInstanceOf<Campaign>(response);
        }

        [Test]
        public void GetCampaignTest()
        {
            string id = "18594";
            var response = instance.GetCampaignById(id);
            Assert.IsInstanceOf<Campaign>(response, "response is Campaign");
        }
    }
}
