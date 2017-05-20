using FluentAssertions;
using ReactiveSearch.Services.State;
using Xunit;

namespace ReactiveSearch.UnitTests.Services.State
{
    public class StateKeysTests
    {
        [InlineData("hello world", "searchQuery-hello world")]
        [InlineData("hello", "searchQuery-hello")]
        [InlineData("", "searchQuery-")]
        [Theory]
        public void SearchQueryKeyShouldBeExpected(string query, string expected)
        {
            var sut = StateKeys.GetKeyForSearchQuery(query);

            sut.Should().Be(expected);
        }
    }
}