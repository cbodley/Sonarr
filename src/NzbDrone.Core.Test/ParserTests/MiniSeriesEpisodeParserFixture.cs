using System;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using NzbDrone.Core.Parser;
using NzbDrone.Core.Test.Framework;

namespace NzbDrone.Core.Test.ParserTests
{

    [TestFixture]
    public class MiniSeriesEpisodeParserFixture : CoreTest
    {
        [TestCase("The.Kennedys.Part.2.DSR.XviD-SYS", "The Kennedys", 2)]
        [TestCase("the-pacific-e07-720p", "the-pacific", 7)]
        [TestCase("Hatfields and McCoys 2012 Part 1 REPACK 720p HDTV x264 2HD", "Hatfields and McCoys 2012", 1)]
//        [TestCase("Band.Of.Brothers.EP02.Day.Of.Days.DVDRiP.XviD-DEiTY", "Band.Of.Brothers", 2)]
//        [TestCase("", "", 0, 0)]
        public void should_parse_mini_series_episode(String postTitle, String title, Int32 episodeNumber)
        {
            var result = Parser.Parser.ParseTitle(postTitle);
            result.Should().NotBeNull();
            result.EpisodeNumbers.Should().HaveCount(1);
            result.SeasonNumber.Should().Be(1);
            result.EpisodeNumbers.First().Should().Be(episodeNumber);
            result.SeriesTitle.Should().Be(title);
            result.AbsoluteEpisodeNumbers.Should().BeEmpty();
            result.FullSeason.Should().BeFalse();
        }
    }
}
