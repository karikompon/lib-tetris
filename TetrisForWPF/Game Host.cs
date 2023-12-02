using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisForWPF;

public class GameHost
{
    public static IHost GetHost()
    {
        return Host.CreateDefaultBuilder()
            .ConfigureServices((services) =>
            {
                services.AddSingleton<GameWindow>();
 
                services.AddSingleton<IGridSettings, GridSettings>();
                services.AddSingleton<IGridGenerator, GridGenerator>();
                services.AddSingleton<IBlockPositionWriter, BlockPositionWriter>();
                services.AddSingleton<ICustomizer, Customizer>();
                services.AddSingleton<IBlockRepository, BlockRepository>();
                services.AddSingleton<IFigureTypeHandler, FigureTypeHandler>();
            })
            .Build();
    }
}