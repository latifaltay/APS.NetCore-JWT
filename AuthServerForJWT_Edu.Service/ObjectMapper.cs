using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace AuthServerForJWT_Edu.Service;

public static class ObjectMapper
{
    private static readonly Lazy<IMapper> lazy = new Lazy<IMapper>(() =>
    {
        using var serviceProvider = new ServiceCollection()
            .AddLogging() // ILoggerFactory için gerekli
            .BuildServiceProvider();

        var loggerFactory = serviceProvider.GetService<ILoggerFactory>();

        var config = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<DtoMapper>();
        }, loggerFactory);

        return config.CreateMapper();
    });

    public static IMapper Mapper => lazy.Value;
}
