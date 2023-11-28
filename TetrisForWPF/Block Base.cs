using System.Windows.Controls;
using System.Windows.Media;

namespace TetrisForWPF;

public abstract class BlockBase : UserControl
{
    public abstract Brush? Color { get; set; }

    public int Row { get; set; }

    public int Column { get; set; }
}
