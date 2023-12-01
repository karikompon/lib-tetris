using System.Collections;
using System.Collections.Generic;

namespace TetrisForWPF;

public interface IBlockRepository : IEnumerable<BlockBase>
{
    void Add(BlockBase block);

    void Remove(BlockBase block);
}

public class BlockRepository : IBlockRepository
{
    private readonly List<BlockBase> _blocks;

    public BlockRepository()
    {
        _blocks = new List<BlockBase>();
    }

    public void Add(BlockBase block)
    {
        _blocks.Add(block);
    }

    public void Remove(BlockBase block)
    {
        _blocks.Remove(block);
    }

    public IEnumerator<BlockBase> GetEnumerator()
    {
        return _blocks.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}