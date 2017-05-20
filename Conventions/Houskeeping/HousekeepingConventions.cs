using System.Linq;
using Conventional;
using ReactiveSearch.App;
using ReactiveSearch.Services;
using ReactiveSearch.Services.Connected;
using ReactiveSearch.Services.Disconnected;
using ReactiveSearch.UnitTests;
using ReactiveSearch.UnitTests.Utility;
using ReactiveSearch.Utility;
using Xunit;

namespace Conventions.Houskeeping
{
    // When we want to contribute some code to an existing codebase, we should do so in a way that
    // aligns with the codebases existing conventions. Nothing makes navigating anything beyond
    // trivial codebases harder than poor organisation, imposing a large cognitive overhead and makes
    // contributing code an exercise in guesswork and frustration. Here we instruct the codebase to
    // enforce it's own housekeeping rules to ensure new contributors can get up to speed easily and
    // extend the codebase with minimal brainpower expended on trivialities like where to put X or
    // what to name Y.
    public class HousekeepingConventions : IClassFixture<BaseFixture>
    {
        public HousekeepingConventions(BaseFixture baseFixture)
        {
            _baseFixture = baseFixture;
        }

        private readonly BaseFixture _baseFixture;

        [Fact]
        public void AppAssemblyMustNotTakeADependancyOn()
        {
            typeof(AppAssembly).MustConformTo(Convention.MustNotTakeADependencyOn(typeof(CoreAssembly), "TODO"));
            typeof(AppAssembly).MustConformTo(Convention.MustNotTakeADependencyOn(typeof(ViewModelAssembly), "TODO"));
            typeof(AppAssembly).MustConformTo(Convention.MustNotTakeADependencyOn(typeof(UnitTestsAssembly), "TODO"));
            typeof(AppAssembly).MustConformTo(Convention.MustNotTakeADependencyOn(typeof(UnitTestsUtilityAssembly),
                "TODO"));
        }

        [Fact]
        public void AssembliesMustNotReferenceDllsFromBinOrObjDirectories()
        {
            _baseFixture.ApplicationAssemblies.Select(
                x => x.Assembly.MustConformTo(Convention.MustNotReferenceDllsFromBinOrObjDirectories));
        }

        [Fact]
        public void CoreAssemblyMustNotTakeADependancyOn()
        {
            typeof(CoreAssembly).MustConformTo(Convention.MustNotTakeADependencyOn(typeof(AppAssembly), "TODO"));
            typeof(CoreAssembly).MustConformTo(Convention.MustNotTakeADependencyOn(typeof(ServicesAssembly), "TODO"));
            typeof(CoreAssembly).MustConformTo(Convention.MustNotTakeADependencyOn(typeof(ServicesConnectedAssembly),
                "TODO"));
            typeof(CoreAssembly).MustConformTo(Convention.MustNotTakeADependencyOn(
                typeof(ServicesDisconnectedAssembly), "TODO"));
            typeof(CoreAssembly).MustConformTo(Convention.MustNotTakeADependencyOn(typeof(ViewModelAssembly), "TODO"));
            typeof(CoreAssembly).MustConformTo(Convention.MustNotTakeADependencyOn(typeof(UnitTestsAssembly), "TODO"));
            typeof(CoreAssembly).MustConformTo(Convention.MustNotTakeADependencyOn(typeof(UnitTestsUtilityAssembly),
                "TODO"));
        }

        [Fact]
        public void ServicesAssemblyMustNotTakeADependancyOn()
        {
            typeof(ServicesAssembly).MustConformTo(Convention.MustNotTakeADependencyOn(typeof(AppAssembly), "TODO"));
            typeof(ServicesAssembly).MustConformTo(Convention.MustNotTakeADependencyOn(typeof(CoreAssembly), "TODO"));
            typeof(ServicesAssembly).MustConformTo(Convention.MustNotTakeADependencyOn(
                typeof(ServicesConnectedAssembly), "TODO"));
            typeof(ServicesAssembly).MustConformTo(
                Convention.MustNotTakeADependencyOn(typeof(ServicesDisconnectedAssembly), "TODO"));
            typeof(ServicesAssembly).MustConformTo(Convention.MustNotTakeADependencyOn(typeof(ViewModelAssembly), "TODO"));
            typeof(ServicesAssembly).MustConformTo(Convention.MustNotTakeADependencyOn(typeof(UnitTestsAssembly), "TODO"));
            typeof(ServicesAssembly).MustConformTo(Convention.MustNotTakeADependencyOn(
                typeof(UnitTestsUtilityAssembly), "TODO"));
        }

        [Fact]
        public void ServicesConnectedAssemblyMustNotTakeADependancyOn()
        {
            typeof(ServicesAssembly).MustConformTo(Convention.MustNotTakeADependencyOn(typeof(AppAssembly), "TODO"));
            typeof(ServicesAssembly).MustConformTo(Convention.MustNotTakeADependencyOn(typeof(CoreAssembly), "TODO"));
            typeof(ServicesAssembly).MustConformTo(
                Convention.MustNotTakeADependencyOn(typeof(ServicesDisconnectedAssembly), "TODO"));
            typeof(ServicesAssembly).MustConformTo(Convention.MustNotTakeADependencyOn(typeof(ViewModelAssembly), "TODO"));
            typeof(ServicesAssembly).MustConformTo(Convention.MustNotTakeADependencyOn(typeof(UnitTestsAssembly), "TODO"));
            typeof(ServicesAssembly).MustConformTo(Convention.MustNotTakeADependencyOn(
                typeof(UnitTestsUtilityAssembly), "TODO"));
        }

        [Fact]
        public void ServicesDisconnectedAssemblyMustNotTakeADependancyOn()
        {
            typeof(ServicesDisconnectedAssembly).MustConformTo(Convention.MustNotTakeADependencyOn(typeof(AppAssembly),
                "TODO"));
            typeof(ServicesDisconnectedAssembly).MustConformTo(Convention.MustNotTakeADependencyOn(
                typeof(CoreAssembly), "TODO"));
            typeof(ServicesDisconnectedAssembly).MustConformTo(
                Convention.MustNotTakeADependencyOn(typeof(ServicesConnectedAssembly), "TODO"));
            typeof(ServicesDisconnectedAssembly).MustConformTo(
                Convention.MustNotTakeADependencyOn(typeof(ViewModelAssembly), "TODO"));
            typeof(ServicesDisconnectedAssembly).MustConformTo(
                Convention.MustNotTakeADependencyOn(typeof(UnitTestsAssembly), "TODO"));
            typeof(ServicesDisconnectedAssembly).MustConformTo(
                Convention.MustNotTakeADependencyOn(typeof(UnitTestsUtilityAssembly), "TODO"));
        }

        [Fact]
        public void UtilityAssemblyMustNotTakeADependancyOn()
        {
            typeof(UtilityAssembly).MustConformTo(Convention.MustNotTakeADependencyOn(typeof(AppAssembly), "TODO"));
            typeof(UtilityAssembly).MustConformTo(Convention.MustNotTakeADependencyOn(typeof(CoreAssembly), "TODO"));
            typeof(UtilityAssembly).MustConformTo(Convention.MustNotTakeADependencyOn(typeof(ServicesAssembly), "TODO"));
            typeof(UtilityAssembly).MustConformTo(Convention.MustNotTakeADependencyOn(
                typeof(ServicesConnectedAssembly), "TODO"));
            typeof(UtilityAssembly).MustConformTo(
                Convention.MustNotTakeADependencyOn(typeof(ServicesDisconnectedAssembly), "TODO"));
            typeof(UtilityAssembly).MustConformTo(Convention.MustNotTakeADependencyOn(typeof(ViewModelAssembly), "TODO"));
            typeof(UtilityAssembly).MustConformTo(Convention.MustNotTakeADependencyOn(typeof(UnitTestsAssembly), "TODO"));
            typeof(UtilityAssembly).MustConformTo(Convention.MustNotTakeADependencyOn(typeof(UnitTestsUtilityAssembly),
                "TODO"));
        }

        [Fact]
        public void ViewModelsAssemblyMustNotTakeADependancyOn()
        {
            typeof(ViewModelAssembly).MustConformTo(Convention.MustNotTakeADependencyOn(typeof(AppAssembly), "TODO"));
            typeof(ViewModelAssembly).MustConformTo(Convention.MustNotTakeADependencyOn(typeof(CoreAssembly), "TODO"));
            typeof(ViewModelAssembly).MustConformTo(
                Convention.MustNotTakeADependencyOn(typeof(ServicesConnectedAssembly), "TODO"));
            typeof(ViewModelAssembly).MustConformTo(
                Convention.MustNotTakeADependencyOn(typeof(ServicesDisconnectedAssembly), "TODO"));
            typeof(ViewModelAssembly).MustConformTo(Convention.MustNotTakeADependencyOn(typeof(UnitTestsAssembly),
                "TODO"));
            typeof(ViewModelAssembly).MustConformTo(Convention.MustNotTakeADependencyOn(
                typeof(UnitTestsUtilityAssembly), "TODO"));
        }
    }
}