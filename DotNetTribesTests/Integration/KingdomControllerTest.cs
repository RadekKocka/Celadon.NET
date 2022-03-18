﻿using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using DotNetTribes;
using DotNetTribes.DTOs;
using DotNetTribes.Models;
using DotNetTribes.Services;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Xunit;

namespace DotNetTribesTests.Integration
{
    public class KingdomControllerTest
    {
        [Fact]
        public void KingdomController_KingdomInfo_ReturnKingdomDto()
        {
            //Arrange
            using var client = new CustomWebApplicationFactory<Startup>().CreateClient();
            var jwtServiceTest = new JwtService();

            var token = jwtServiceTest.CreateToken("Hrnik", "1");

            //Act
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = client.GetAsync("/kingdom").Result;

            var responseString = response.Content.ReadAsStringAsync().Result;

            var responseObject = JsonConvert.DeserializeObject<KingdomDto>(responseString);

            //Assert
            Assert.Equal("Hrnik", responseObject.Username);
            Assert.Equal("Cool Kingdom Name", responseObject.KingdomName);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}