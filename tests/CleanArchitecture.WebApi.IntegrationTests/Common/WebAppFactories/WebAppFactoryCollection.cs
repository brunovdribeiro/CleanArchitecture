namespace CleanArchitecture.WebApi.IntegrationTests.Common.WebAppFactories;

[CollectionDefinition(CollectionName)]
public class WebAppFactoryCollection : ICollectionFixture<WebAppFactory>
{
    public const string CollectionName = "WebAppFactoryCollection";
}