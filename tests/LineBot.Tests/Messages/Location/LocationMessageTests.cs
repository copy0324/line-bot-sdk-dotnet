﻿// Copyright 2017 Dirk Lemstra (https://github.com/dlemstra/line-bot-sdk-dotnet)
//
// Dirk Lemstra licenses this file to you under the Apache License,
// version 2.0 (the "License"); you may not use this file except in compliance
// with the License. You may obtain a copy of the License at:
//
//   https://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS, WITHOUT
// WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the
// License for the specific language governing permissions and limitations
// under the License.

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace Line.Tests
{
    [TestClass]
    public class LocationMessageTests
    {
        [TestMethod]
        public void Constructor_SerializedCorrectly()
        {
            LocationMessage message = new LocationMessage()
            {
                Title = "Correct",
                Address = "Somewhere",
                Latitude = 13.4484625m,
                Longitude = 144.7562962m
            };

            string serialized = JsonConvert.SerializeObject(message);
            Assert.AreEqual(@"{""type"":""location"",""title"":""Correct"",""address"":""Somewhere"",""latitude"":13.4484625,""longitude"":144.7562962}", serialized);
        }

        [TestMethod]
        public void Title_Null_ThrowsException()
        {
            LocationMessage message = new LocationMessage();

            ExceptionAssert.Throws<InvalidOperationException>("The title cannot be null or whitespace.", () =>
            {
                message.Title = null;
            });
        }

        [TestMethod]
        public void Title_Empty_ThrowsException()
        {
            LocationMessage message = new LocationMessage();

            ExceptionAssert.Throws<InvalidOperationException>("The title cannot be null or whitespace.", () =>
            {
                message.Title = string.Empty;
            });
        }

        [TestMethod]
        public void Title_MoreThan100Chars_ThrowsException()
        {
            LocationMessage message = new LocationMessage();

            ExceptionAssert.Throws<InvalidOperationException>("The title cannot be longer than 100 characters.", () =>
            {
                message.Title = new string('x', 101);
            });
        }

        [TestMethod]
        public void Title_100Chars_ThrowsNoException()
        {
            string value = new string('x', 100);

            LocationMessage message = new LocationMessage()
            {
                Title = value
            };

            Assert.AreEqual(value, message.Title);
        }

        [TestMethod]
        public void Address_Null_ThrowsException()
        {
            LocationMessage message = new LocationMessage();

            ExceptionAssert.Throws<InvalidOperationException>("The address cannot be null or whitespace.", () =>
            {
                message.Address = null;
            });
        }

        [TestMethod]
        public void Address_Empty_ThrowsException()
        {
            LocationMessage message = new LocationMessage();

            ExceptionAssert.Throws<InvalidOperationException>("The address cannot be null or whitespace.", () =>
            {
                message.Address = string.Empty;
            });
        }

        [TestMethod]
        public void Address_MoreThan100Chars_ThrowsException()
        {
            LocationMessage message = new LocationMessage();

            ExceptionAssert.Throws<InvalidOperationException>("The address cannot be longer than 100 characters.", () =>
            {
                message.Address = new string('x', 101);
            });
        }

        [TestMethod]
        public void Address_100Chars_ThrowsNoException()
        {
            string value = new string('x', 100);

            LocationMessage message = new LocationMessage()
            {
                Address = value
            };

            Assert.AreEqual(value, message.Address);
        }
    }
}
