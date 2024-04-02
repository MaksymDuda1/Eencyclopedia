using Microsoft.Extensions.DependencyInjection;

namespace Eencyclopedia.Application.Models;


public class LazyInstance<T> : Lazy<T>
{
    public LazyInstance(IServiceProvider serviceProvider)
        : base(() => serviceProvider.GetRequiredService<T>())
    {

    }
}