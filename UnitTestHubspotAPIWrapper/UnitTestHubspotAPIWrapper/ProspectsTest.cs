﻿using System;
using System.Json;
using HubspotAPIWrapper;
using NUnit.Framework;
using Rhino.Mocks;
using Microsoft.Security.Application;

namespace UnitTestHubspotAPIWrapper
{
    [TestFixture]
    public class ProspectsTest
    {
        [Test]
        public void ProspectGetHiddenProspectUrlFormedCorrectly()
        {
            var mockDataSource = MockRepository.GenerateMock<IWebClient>();
            var expectedUrl = Constants.ListHiddenProspectsUrl;

            // Arrange
            mockDataSource
                .Stub(x => x.UploadString(
                    Arg<string>.Is.Anything, // uri
                    Arg<string>.Is.Anything, // method
                    Arg<string>.Is.Anything, // content-type
                    Arg<string>.Is.Anything // data
                               ))
                .Return(string.Empty);

            // Act
            var target = new Prospects(accessToken: Constants.AccessToken)
                {
                    UserWebClient = mockDataSource
                };

            target.GetHiddenProspect();


            // Assert
            mockDataSource.AssertWasCalled(c => c.UploadString(
                Arg<string>.Matches(actualUrl => actualUrl == expectedUrl),
                Arg<string>.Is.Anything,
                Arg<string>.Is.Anything,
                Arg<string>.Is.Anything));
        }


        [Test]
        public void ProspectGetProspectsWithOffsetUrlFormedCorrectly()
        {
            var mockDataSource = MockRepository.GenerateMock<IWebClient>();
            var expectedUrl = Constants.GetProspectWithTimeOffsetUrl;

            // Arrange
            mockDataSource
                .Stub(x => x.UploadString(
                    Arg<string>.Is.Anything, // uri
                    Arg<string>.Is.Anything, // method
                    Arg<string>.Is.Anything, // content-type
                    Arg<string>.Is.Anything // data
                               ))
                .Return(string.Empty);

            // Act
            var target = new Prospects(accessToken: Constants.AccessToken)
                {
                    UserWebClient = mockDataSource
                };
            target.GetProspects(timeOffset: Constants.TimeOffset, orgOffset: Constants.OrgOffset);

            // Assert
            mockDataSource.AssertWasCalled(c => c.UploadString(
                Arg<string>.Matches(actualUrl => actualUrl == expectedUrl),
                Arg<string>.Is.Anything,
                Arg<string>.Is.Anything,
                Arg<string>.Is.Anything));
        }

        [Test]
        [ExpectedException(typeof (ArgumentException), ExpectedMessage = "Need both Time Offset and Organization Offset"
            )]
        public void ProspectGetProspectsWithOrgOffsetOnlyShouldFail()
        {
            var expect = new Prospects(accessToken: Constants.AccessToken);
            expect.GetProspects(orgOffset: Constants.OrgOffset);
        }

        [Test]
        [ExpectedException(typeof (ArgumentException), ExpectedMessage = "Need both Time Offset and Organization Offset"
            )]
        public void ProspectGetProspectsWithTimeOffsetOnlyShouldFail()
        {
            var expect = new Prospects(accessToken: Constants.AccessToken);
            expect.GetProspects(timeOffset: Constants.TimeOffset);
        }

        [Test]
        public
        void ProspectUnHideAProspectUrlFormedCorrectly()
        {
            var mockDataSource = MockRepository.GenerateMock<IWebClient>();
            const string data = "";
            string expectedUrl = Constants.UnHideAProspectUrl;

            // Arrange
            mockDataSource
                .Stub(x => x.UploadString(
                    Arg<string>.Is.Anything, // uri
                    Arg<string>.Is.Anything, // method
                    Arg<string>.Is.Anything, // content-type
                    Arg<string>.Is.Anything // data
                               ))
                .Return(data);

            // Act
            var target = new Prospects(accessToken: Constants.AccessToken)
                {
                    UserWebClient = mockDataSource
                };

            target.UnHideAProspect(Constants.ProspectOrganization);

            // Assert
            mockDataSource.AssertWasCalled(c => c.UploadString(
                Arg<string>.Matches(actualUrl => actualUrl == expectedUrl),
                Arg<string>.Is.Anything,
                Arg<string>.Is.Anything,
                Arg<string>.Is.Anything));
        }

        [Test]
        public void ProspectsClassInitializes()
        {
            var target = new Prospects(apiKey: Constants.ApiKey);
            Assert.IsNotNull(target);
        }

        [Test]
        public void ProspectsGetProspectInfoRequestIsFormedCorrectly()
        {
            var mockDataSource = MockRepository.GenerateMock<IWebClient>();
            var expectedUrl = Constants.GetProspectInfoUrl;

            // Arrange
            mockDataSource
                .Stub(x => x.UploadString(
                    Arg<string>.Is.Anything, // uri
                    Arg<string>.Is.Anything, // method
                    Arg<string>.Is.Anything, // content-type
                    Arg<string>.Is.Anything // data
                               ))
                .Return(string.Empty);


            // Act
            var target = new Prospects(accessToken: Constants.AccessToken)
                {
                    UserWebClient = mockDataSource
                };
            target.GetProspectInfo(Constants.ProspectInfoOrganization);


            // Assert
            mockDataSource.AssertWasCalled(c => c.UploadString(
                Arg<string>.Matches(actualUrl => actualUrl == expectedUrl),
                Arg<string>.Is.Anything,
                Arg<string>.Is.Anything,
                Arg<string>.Is.Anything));
        }

        [Test]
        public void ProspectsGetProspectsRequestIsFormedCorrectly()
        {
            var mockDataSource = MockRepository.GenerateMock<IWebClient>();
            var expectedUrl = Constants.GetProspectUrl;

            // Arrange
            mockDataSource
                .Stub(x => x.UploadString(
                    Arg<string>.Is.Anything, // uri
                    Arg<string>.Is.Anything, // method
                    Arg<string>.Is.Anything, // content-type
                    Arg<string>.Is.Anything // data
                               ))
                .Return(string.Empty);


            // Act
            var target = new Prospects(accessToken: Constants.AccessToken)
                {
                    UserWebClient = mockDataSource
                };
            target.GetProspects();


            // Assert
            mockDataSource.AssertWasCalled(c => c.UploadString(
                Arg<string>.Matches(actualUrl => actualUrl == expectedUrl),
                Arg<string>.Is.Anything,
                Arg<string>.Is.Anything,
                Arg<string>.Is.Anything));
        }

        [Test]
        public
        void ProspectsHideAProspectRequestIsFormedCorrectly()
        {
            var mockDataSource = MockRepository.GenerateMock<IWebClient>();
            const string data = "";
            var expectedUrl = Constants.UnHideAProspectUrl;


            // Arrange
            mockDataSource
                .Stub(x => x.UploadString(
                    Arg<string>.Is.Anything, // uri
                    Arg<string>.Is.Anything, // method
                    Arg<string>.Is.Anything, // content-type
                    Arg<string>.Is.Anything // data
                               ))
                .Return(data);

            // Act
            var target = new Prospects(accessToken: Constants.AccessToken)
                {
                    UserWebClient = mockDataSource
                };

            target.HideAProspect(Encoder.UrlEncode(Constants.ProspectOrganization));

            // Assert
            mockDataSource.AssertWasCalled(c => c.UploadString(
                Arg<string>.Matches(actualUrl => actualUrl == expectedUrl),
                Arg<string>.Matches(actualMethod => actualMethod == "POST"),
                Arg<string>.Matches(actualContentType => actualContentType == "application/x-www-form-urlencoded"),
                Arg<string>.Matches(actaulData => actaulData == "marriott%20hotel")));
        }

        [Test]
        public void ProspectsSearchForProspectsRequestIsFormedCorrectly()
        {
            var mockDataSource = MockRepository.GenerateMock<IWebClient>();
            var expectedUrl = Constants.SearchForProspectsUrl;

            // Arrange
            mockDataSource
                .Stub(x => x.UploadString(
                    Arg<string>.Is.Anything, // uri
                    Arg<string>.Is.Anything, // method
                    Arg<string>.Is.Anything, // content-type
                    Arg<string>.Is.Anything // data
                               ))
                .Return(string.Empty);


            // Act
            var target = new Prospects(accessToken: Constants.AccessToken)
                {
                    UserWebClient = mockDataSource
                };
            target.SearchForProspects("city", "Cambridge");


            // Assert
            mockDataSource.AssertWasCalled(c => c.UploadString(
                Arg<string>.Matches(actualUrl => actualUrl == expectedUrl),
                Arg<string>.Is.Anything,
                Arg<string>.Is.Anything,
                Arg<string>.Is.Anything));
        }
    }
}