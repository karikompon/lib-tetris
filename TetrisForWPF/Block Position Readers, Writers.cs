using System.Linq;
using System.Windows.Controls;

namespace TetrisForWPF;

public interface IBlockPositionReader
{
    bool CheckPositionAvailability(int row, int column);
}

public interface IBlockPositionWriter : IBlockPositionReader
{
    void SetBlockPosition(BlockBase block, int row, int column);
}

public class BlockPositionWriter : IBlockPositionWriter
{
    private readonly IBlocksCollection _inactiveBlocksHandler;
    private readonly IGridSettings _gridSettings;

    public BlockPositionWriter(IBlocksCollection inactiveBlocksHandler, IGridSettings gridSettings)
    {
        _inactiveBlocksHandler = inactiveBlocksHandler;
        _gridSettings = gridSettings;
    }

    public bool CheckPositionAvailability(int row, int column)
    {
        return
            row >= 0 && row < _gridSettings.VerticalBlockCount &&
            column >= 0 && column < _gridSettings.HorizontalBlockCount &&
            !_inactiveBlocksHandler.Any(block => block.Row == row && block.Column == column);
    }

    public void SetBlockPosition(BlockBase block, int row, int column)
    {
        block.Row = row;
        block.Column = column;

        Grid.SetRow(block, row);
        Grid.SetColumn(block, column);
    }
}
