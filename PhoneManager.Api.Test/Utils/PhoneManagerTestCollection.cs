using Xunit;
namespace PhoneManager.Api.Test.Utils
{
    /// <summary>
    /// Test group definition class.
    /// </summary>
    [CollectionDefinition(Name)]
    public class PhoneManagerTestCollection : ICollectionFixture<Fixture>
    {
        public const string Name = "PhoneManagerTestCollection";
    }
}

