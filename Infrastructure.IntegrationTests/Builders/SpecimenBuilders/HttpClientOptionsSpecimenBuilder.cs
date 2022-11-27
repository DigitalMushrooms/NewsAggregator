using AutoFixture.Kernel;
using Infrastructure.Http.TheGuardian.Options;

namespace Infrastructure.IntegrationTests.Builders.SpecimenBuilders;

public class HttpClientOptionsSpecimenBuilder : ISpecimenBuilder
{
    public object Create(object request, ISpecimenContext context)
    {
        if (request is not Type type || type != typeof(HttpClientOptions)) 
            return new NoSpecimen();
        
        var uriSpecimen = context.Resolve(typeof(Uri)) as Uri;
        if (uriSpecimen == null)
        {
            throw new Exception($"There's no class that implements {nameof(ISpecimenBuilder)} for Uri type.");
        }

        var stringSpecimen = context.Resolve(typeof(string)) as string;
        if (stringSpecimen == null)
        {
            throw new Exception($"There's no class that implements {nameof(ISpecimenBuilder)} for String type.");
        }
            
        var result = new HttpClientOptions();
        result.Url = uriSpecimen.ToString();
        result.Key = stringSpecimen;
        return result;
    }
}