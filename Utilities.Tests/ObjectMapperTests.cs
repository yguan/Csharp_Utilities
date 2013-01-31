using System;
using System.Collections.Generic;
using System.Reflection;
using MbUnit.Framework;
using SharpTestsEx;
using System.Linq;
using Utilities.Mapper;

namespace Utilities.Mapper.Tests
{
    [TestFixture]
    public class ObjectMapperTests
    {
        private class Source
        {
            public int SValue { get; set; }
        }

        private class Destination
        {
            public int DValue { get; set; }
        }

        [FixtureSetUp]
        public void FixtureSetup()
        {
            // Register the mapping
            ObjectMapper.CreateMap<Source, Destination>(source => new Destination { DValue = source.SValue });
            ObjectMapper.CreateMap<Destination, Source>(dest => new Source { SValue = dest.DValue });
        }

        [Test]
        public void Should_map_objects_correctly()
        {
            var source = new Source { SValue = 2 };

            var dest = source.MapTo<Destination>();
            dest.DValue.Should().Be(source.SValue);
            dest.MapTo<Source>().SValue.Should().Be(source.SValue);
        }
    }
}