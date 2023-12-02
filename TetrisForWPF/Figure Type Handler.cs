﻿using System;

namespace TetrisForWPF;

public interface IFigureTypeHandler
{
    IFigureType GetRandomType();
}

internal class FigureTypeHandler : IFigureTypeHandler
{
    private readonly Random _random;
    private readonly IFigureType[] _types;

    public FigureTypeHandler(ICustomizer customizer)
    {
        _types = new IFigureType[]
        {
            new Z_Figure(customizer.ZFigureColor),
            new S_Figure(customizer.SFigureColor),
            new I_Figure(customizer.IFigureColor),
            new T_Figure(customizer.TFigureColor),
            new O_Figure(customizer.OFigureColor),
            new J_Figure(customizer.JFigureColor),
            new L_Figure(customizer.LFigureColor),
        };

        _random = new Random();
    }

    public IFigureType GetRandomType()
    {
        return _types[_random.Next(_types.Length)];
    }
}
