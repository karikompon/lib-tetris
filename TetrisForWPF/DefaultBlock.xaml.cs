using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Media;

namespace TetrisForWPF;

public partial class DefaultBlock : BlockBase, INotifyPropertyChanged
{
    private Brush? _color;

    public DefaultBlock(ICustomizer customizer, int row, int column, Brush color)
    {
        InitializeComponent();
        DataContext = this;

        Padding = customizer.BlockPadding;
        Margin = customizer.BlockMargin;
        BorderThickness = customizer.BlockBorderThickness;
        BorderBrush = customizer.BlockBorderBrush;
        Row = row;
        Column = column;
        Color = color;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    public override Brush? Color
    {
        get { return _color; }
        set { _color = value; OnPropertyChanged(); }
    }

    private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
