using System;
using TextParsing;
using Xunit;
using FluentAssertions;

namespace TextParsingTest
{
    public class TextProcessingFixture
    {
        [Fact]
        public void string_from_text_to_Region_object()
        {
            string inText = "704|Barter Island|Barter Island, Alaska, United States of America|70.129562|-143.662949|tree";
            string[] tokens = inText.Split('|');

            var actualOutput = new Region(tokens);
            actualOutput.RegionID.Should().Be(704);
            actualOutput.RegionName.Should().Be("Barter Island");
            actualOutput.RegionNameLong.Should().Be("Barter Island, Alaska, United States of America");
            actualOutput.Latitude.Should().Be(70.129562);
            actualOutput.Longitude.Should().Be(-143.662949);
            actualOutput.SubClassification.Should().Be("tree");

        }

        public void empty_string_lead_to_null_object()
        {
            string inText = "704|Barter Island|Barter Island, Alaska, United States of America||-143.662949|";
            string[] tokens = inText.Split('|');

            var actualOutput = new Region(tokens);
            actualOutput.RegionID.Should().Be(704);
            actualOutput.RegionName.Should().Be("Barter Island");
            actualOutput.RegionNameLong.Should().Be("Barter Island, Alaska, United States of America");
            actualOutput.Latitude.Should().Be(null);
            actualOutput.Longitude.Should().Be(-143.662949);
            actualOutput.SubClassification.Should().Be("");

        }
    }
}
