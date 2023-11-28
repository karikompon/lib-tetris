using System.Windows;
using System.Windows.Media;

namespace TetrisForWPF;

public interface ICustomizer
{
    public Brush BackgroundColor { get; set; }
    public Brush LFigureColor { get; set; }
    public Brush JFigureColor { get; set; }
    public Brush OFigureColor { get; set; }
    public Brush TFigureColor { get; set; }
    public Brush IFigureColor { get; set; }
    public Brush SFigureColor { get; set; }
    public Brush ZFigureColor { get; set; }
    public Brush InactiveBlocksColor { get; set; }
    public Thickness BlockPadding { get; set; }
    public Thickness BlockMargin { get; set; }
    public Thickness BlockBorderThickness { get; set; }
    public Brush BlockBorderBrush { get; set; }
}

public class Customizer : ICustomizer
{
    public Brush BackgroundColor { get; set; } = Brushes.Black;
    public Brush LFigureColor { get; set; } = Brushes.OrangeRed;
    public Brush JFigureColor { get; set; } = Brushes.Orange;
    public Brush OFigureColor { get; set; } = Brushes.Gold;
    public Brush SFigureColor { get; set; } = Brushes.GreenYellow;
    public Brush ZFigureColor { get; set; } = Brushes.LimeGreen;
    public Brush TFigureColor { get; set; } = Brushes.DodgerBlue;
    public Brush IFigureColor { get; set; } = Brushes.MediumPurple;
    public Brush InactiveBlocksColor { get; set; } = Brushes.White;
    public Thickness BlockPadding { get; set; } = new Thickness(0.5);
    public Thickness BlockMargin { get; set; } = new Thickness(0);
    public Thickness BlockBorderThickness { get; set; } = new Thickness(1);
    public Brush BlockBorderBrush { get; set; } = Brushes.White;
}
