using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace TetrisForWPF;

internal interface IFigure : IEnumerable<BlockBase>
{
    bool TryMoveLeft();

    bool TryMoveRight();

    bool TryMoveDown();

    bool TryRotate();
}

internal class Figure : IFigure, IEnumerable<BlockBase>
{
    private readonly IFigureType _type;
    private readonly IBlockPositionWriter _blockPositionWriter;
    private readonly IReadOnlyList<BlockBase> _activeBlocks;

    private int _rotationCode;

    public Figure(IFigureType type, IBlockPositionWriter blockPositionWriter, (int Row, int Column) figureCenter, Grid grid, ICustomizer customizer)
    {
        _type = type;
        _blockPositionWriter = blockPositionWriter;

        _activeBlocks = _type.StartPositionOffsets
            .Select(
        offset =>
                new DefaultBlock(
                    customizer, 
                    figureCenter.Row + offset.Row, 
                    figureCenter.Column + offset.Column, 
                    _type.BlockColor))
            .ToList();

        if (!_activeBlocks.All(block => _blockPositionWriter.CheckPositionAvailability(block.Row, block.Column)))
        {
            MessageBox.Show("You lose!");
            Application.Current.Shutdown();
        }

        foreach (BlockBase block in _activeBlocks)
        {
            grid.Children.Add(block);
            _blockPositionWriter.SetBlockPosition(block, block.Row, block.Column);
        }
    }

    private int RotationCode
    {
        get { return _rotationCode; }
        set
        {
            if (value > _type.BlockCount - 1) _rotationCode = 0;
            else _rotationCode = value;
        }
    }

    private bool TryMove(int rowOffset, int columnOffset)
    {
        if (!_activeBlocks.All(block => _blockPositionWriter.CheckPositionAvailability(
            block.Row + rowOffset,
            block.Column + columnOffset)))
        {
            return false;
        }

        foreach (BlockBase block in _activeBlocks)
        {
            _blockPositionWriter.SetBlockPosition(block, block.Row + rowOffset, block.Column + columnOffset);
        }
        return true;
    }

    public bool TryMoveLeft()
    {
        return TryMove(rowOffset: 0, columnOffset: -1);
    }

    public bool TryMoveRight()
    {
        return TryMove(rowOffset: 0, columnOffset: +1);
    }

    public bool TryMoveDown()
    {
        return TryMove(rowOffset: +1, columnOffset: 0);
    }

    public bool TryRotate()
    {
        if (_activeBlocks
            .Where(
                (block, index) =>
                _blockPositionWriter.CheckPositionAvailability(
                    block.Row + _type.RotationOffsets[index][RotationCode].Row,
                    block.Column + _type.RotationOffsets[index][RotationCode].Column))
            .Count() != _type.BlockCount)
        {
            return false;
        }

        for (int index = 0; index < _activeBlocks.Count; index++)
        {
            _blockPositionWriter.SetBlockPosition(
                _activeBlocks[index],
                _activeBlocks[index].Row + _type.RotationOffsets[index][RotationCode].Row,
                _activeBlocks[index].Column + _type.RotationOffsets[index][RotationCode].Column);
        }
        RotationCode++;
        return true;
    }

    public IEnumerator GetEnumerator()
    {
        return ((IEnumerable)_activeBlocks).GetEnumerator();
    }

    IEnumerator<BlockBase> IEnumerable<BlockBase>.GetEnumerator()
    {
        return _activeBlocks.GetEnumerator();
    }
}