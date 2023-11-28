namespace TetrisForWPF;

public interface IGridSettings
{
    public int BlockSize { get; set; }
    public int VerticalBlockCount { get; set; }
    public int HorizontalBlockCount { get; set; }
}

public class GridSettings : IGridSettings
{
    public int BlockSize { get; set; } = 50;
    public int VerticalBlockCount { get; set; } = 13;
    public int HorizontalBlockCount { get; set; } = 20;
}