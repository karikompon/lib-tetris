using System.Windows.Media;

namespace TetrisForWPF;

public struct Offset
{
    public int Column;
    public int Row;

    public Offset(int column, int row)
    {
        Column = column;
        Row = row;
    }
}

public interface IFigureType
{
    public Brush BlockColor { get; }

    public int BlockCount { get; }
    public Offset[] StartPositionOffsets { get; }
    public Offset[][] RotationOffsets { get; }
}

public class L_Figure : IFigureType
{
    public L_Figure(Brush blockColor)
    {
        BlockColor = blockColor;
    }

    public Brush BlockColor { get; private set; }

    public int BlockCount { get; } = 4;

    public Offset[] StartPositionOffsets { get; } =
    {
        new Offset(0, 0), // 0 block (central)
        new Offset(0, -1), // 1 block
        new Offset(0, +1), // 2 block
        new Offset(+1, +1), // 3 block
    };

    public Offset[][] RotationOffsets { get; } =
    {
        new Offset[] // 0 block (central)
        {
            new Offset(0, 0),
            new Offset(0, 0),
            new Offset(0, 0),
            new Offset(0, 0),
        },
        new Offset[] // 1 block
        {
            new Offset(+1, +1),
            new Offset(-1, +1),
            new Offset(-1, -1),
            new Offset(+1, -1),
        },
        new Offset[] // 2 block
        {
            new Offset(-1, -1),
            new Offset(+1, -1),
            new Offset(+1, +1),
            new Offset(-1, +1),
        },
        new Offset[] // 3 block
        {
            new Offset(-2, 0),
            new Offset(0, -2),
            new Offset(+2, 0),
            new Offset(0, +2),
        },
    };
}

public class J_Figure : IFigureType
{
    public J_Figure(Brush blockColor)
    {
        BlockColor = blockColor;
    }

    public Brush BlockColor { get; private set; }

    public int BlockCount { get; } = 4;

    public Offset[] StartPositionOffsets { get; } =
    {
        new Offset(0, 0), // 0 block (central)
        new Offset(0, -1), // 1 block
        new Offset(0, +1), // 2 block
        new Offset(-1, +1), // 3 block
    };

    public Offset[][] RotationOffsets { get; } =
    {
        new Offset[] // 0 block (central)
        {
            new Offset(0, 0),
            new Offset(0, 0),
            new Offset(0, 0),
            new Offset(0, 0),
        },
        new Offset[] // 1 block
        {
            new Offset(+1, +1),
            new Offset(-1, +1),
            new Offset(-1, -1),
            new Offset(+1, -1),
        },
        new Offset[] // 2 block
        {
            new Offset(-1, -1),
            new Offset(+1, -1),
            new Offset(+1, +1),
            new Offset(-1, +1),
        },
        new Offset[] // 3 block
        {
            new Offset(0, -2),
            new Offset(+2, 0),
            new Offset(0, +2),
            new Offset(-2, 0),
        },
    };
}

public class O_Figure : IFigureType
{
    public O_Figure(Brush blockColor)
    {
        BlockColor = blockColor;
    }

    public Brush BlockColor { get; private set; }

    public int BlockCount { get; } = 4;

    public Offset[] StartPositionOffsets { get; } =
    {
        new Offset(0, 0), // 0 block (central)
        new Offset(-1, 0), // 1 block
        new Offset(-1, -1), // 2 block
        new Offset(0, -1), // 3 block
    };

    public Offset[][] RotationOffsets { get; } =
    {
        new Offset[] // 0 block (central)
        {
            new Offset(0, 0),
            new Offset(0, 0),
            new Offset(0, 0),
            new Offset(0, 0),
        },
        new Offset[] // 1 block
        {
            new Offset(0, 0),
            new Offset(0, 0),
            new Offset(0, 0),
            new Offset(0, 0),
        },
        new Offset[] // 2 block
        {
            new Offset(0, 0),
            new Offset(0, 0),
            new Offset(0, 0),
            new Offset(0, 0),
        },
        new Offset[] // 3 block
        {
            new Offset(0, 0),
            new Offset(0, 0),
            new Offset(0, 0),
            new Offset(0, 0),
        },
    };
}

public class T_Figure : IFigureType
{
    public T_Figure(Brush blockColor)
    {
        BlockColor = blockColor;
    }

    public Brush BlockColor { get; private set; }

    public int BlockCount { get; } = 4;

    public Offset[] StartPositionOffsets { get; } =
    {
        new Offset(0, 0), // 0 block (central)
        new Offset(-1, 0), // 1 block
        new Offset(0, -1), // 2 block
        new Offset(+1, 0), // 3 block
    };

    public Offset[][] RotationOffsets { get; } =
    {
        new Offset[] // 0 block (central)
        {
            new Offset(0, 0),
            new Offset(0, 0),
            new Offset(0, 0),
            new Offset(0, 0),
        },
        new Offset[] // 1 block
        {
            new Offset(+1, -1),
            new Offset(+1, +1),
            new Offset(-1, +1),
            new Offset(-1, -1),
        },
        new Offset[] // 2 block
        {
            new Offset(+1, +1),
            new Offset(-1, +1),
            new Offset(-1, -1),
            new Offset(+1, -1),
        },
        new Offset[] // 3 block
        {
            new Offset(-1, +1),
            new Offset(-1, -1),
            new Offset(+1, -1),
            new Offset(+1, +1),
        },
    };
}

public class I_Figure : IFigureType
{
    public I_Figure(Brush blockColor)
    {
        BlockColor = blockColor;
    }

    public Brush BlockColor { get; private set; }

    public int BlockCount { get; } = 4;

    public Offset[] StartPositionOffsets { get; } =
    {
        new Offset(0, 0), // 0 block (central)
        new Offset(0, -1), // 1 block
        new Offset(0, +1), // 2 block
        new Offset(0, +2), // 3 block
    };

    public Offset[][] RotationOffsets { get; } =
    {
        new Offset[] // 0 block (central)
        {
            new Offset(0, 0),
            new Offset(0, 0),
            new Offset(0, 0),
            new Offset(0, 0),
        },
        new Offset[] // 1 block
        {
            new Offset(+1, +1),
            new Offset(-1, +1),
            new Offset(-1, -1),
            new Offset(+1, -1),
        },
        new Offset[] // 2 block
        {
            new Offset(-1, -1),
            new Offset(+1, -1),
            new Offset(+1, +1),
            new Offset(-1, +1),
        },
        new Offset[] // 3 block
        {
            new Offset(-2, -2),
            new Offset(+2, -2),
            new Offset(+2, +2),
            new Offset(-2, +2),
        },
    };
}

public class S_Figure : IFigureType
{
    public S_Figure(Brush blockColor)
    {
        BlockColor = blockColor;
    }

    public Brush BlockColor { get; private set; }

    public int BlockCount { get; } = 4;

    public Offset[] StartPositionOffsets { get; } =
    {
        new Offset(0, 0), // 0 block (central)
        new Offset(+1, -1), // 1 block
        new Offset(+1, 0), // 2 block
        new Offset(0, +1), // 3 block
    };

    public Offset[][] RotationOffsets { get; } =
    {
        new Offset[] // 0 block (central)
        {
            new Offset(0, 0),
            new Offset(0, 0),
            new Offset(0, 0),
            new Offset(0, 0),
        },
        new Offset[] // 1 block
        {
            new Offset(0, +2),
            new Offset(-2, 0),
            new Offset(0, -2),
            new Offset(+2, 0),
        },
        new Offset[] // 2 block
        {
            new Offset(-1, +1),
            new Offset(-1, -1),
            new Offset(+1, -1),
            new Offset(+1, +1),
        },
        new Offset[] // 3 block
        {
            new Offset(-1, -1),
            new Offset(+1, -1),
            new Offset(+1, +1),
            new Offset(-1, +1),
        },
    };
}

public class Z_Figure : IFigureType
{
    public Z_Figure(Brush blockColor)
    {
        BlockColor = blockColor;
    }

    public Brush BlockColor { get; private set; }

    public int BlockCount { get; } = 4;

    public Offset[] StartPositionOffsets { get; } =
    {
        new Offset(0, 0), // 0 block (central)
        new Offset(0, -1), // 1 block
        new Offset(+1, 0), // 2 block
        new Offset(+1, +1), // 3 block
    };

    public Offset[][] RotationOffsets { get; } =
    {
        new Offset[] // 0 block (central)
        {
            new Offset(0, 0),
            new Offset(0, 0),
            new Offset(0, 0),
            new Offset(0, 0),
        },
        new Offset[] // 1 block
        {
            new Offset(+1, +1),
            new Offset(-1, +1),
            new Offset(-1, -1),
            new Offset(+1, -1),
        },
        new Offset[] // 2 block
        {
            new Offset(-1, +1),
            new Offset(-1, -1),
            new Offset(+1, -1),
            new Offset(+1, +1),
        },
        new Offset[] // 3 block
        {
            new Offset(-2, 0),
            new Offset(0, -2),
            new Offset(+2, 0),
            new Offset(0, +2),
        },
    };
}
