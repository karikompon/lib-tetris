using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace TetrisForWPF;

public partial class GameWindow : Window, INotifyPropertyChanged
{
    private readonly Grid _grid;
    private readonly (int Row, int Column) _figureCenter;
    private readonly IGridSettings _gridSettings;
    private readonly IGridGenerator _gridGenerator;
    private readonly IBlockPositionWriter _blockPositionWriter;
    private readonly ICustomizer _customizer;
    private readonly IBlocksCollection _inactiveBlocks;
    private readonly IFigureTypesHandler _figureTypesHandler;

    private IFigure _figure;
    private int _theSpeedAtWhichFigureFalls = 1000;
    private int _score;

    public GameWindow(IGridSettings gridSettings, IGridGenerator gridGenerator, IBlockPositionWriter blockPositionWriter, ICustomizer customizer, IBlocksCollection inactiveBlocks, IFigureTypesHandler figureTypesHandler)
    {
        InitializeComponent();
        DataContext = this;

        _gridSettings = gridSettings;
        _gridGenerator = gridGenerator;
        _blockPositionWriter = blockPositionWriter;
        _customizer = customizer;
        _inactiveBlocks = inactiveBlocks;
        _figureTypesHandler = figureTypesHandler;

        _figureCenter.Row = 1;
        _figureCenter.Column = _gridSettings.HorizontalBlockCount / 2;

        _grid = _gridGenerator.GenerateGrid();
        _containerGrid.Children.Add(_grid);
        Grid.SetRow(_grid, 1);

        PreviewKeyDown += KeyDownHandler;

        FigureIsFalling();
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    public int Score
    {
        get { return _score; }
        private set
        {
            _score = value;
            if (_theSpeedAtWhichFigureFalls > 100)
                _theSpeedAtWhichFigureFalls -= 10;
            OnPropertyChanged();
        }
    }

    private void KeyDownHandler(object sender, KeyEventArgs e)
    {
        switch (e.Key)
        {
            case Key.Up:
                _figure.TryRotate();
                break;
            case Key.Left:
                _figure.TryMoveLeft();
                break;
            case Key.Right:
                _figure.TryMoveRight();
                break;
            case Key.Down:
                _figure.TryMoveDown();
                break;
        }
    }

    private async Task FigureIsFalling()
    {
        _figure = new Figure(
            _figureTypesHandler.GetRandomType(),
            _blockPositionWriter,
            (_figureCenter.Row, _figureCenter.Column),
            _grid, _customizer);

        await Task.Delay(_theSpeedAtWhichFigureFalls);

        while (_figure.TryMoveDown())
        {
            await Task.Delay(_theSpeedAtWhichFigureFalls);
        }

        foreach (BlockBase block in _figure)
        {
            block.Color = _customizer.InactiveBlocksColor;
            _inactiveBlocks.Add(block);
        }

        for (int row = _gridSettings.VerticalBlockCount; row >= 0; row -= 1)
        {
            var currentRow = _inactiveBlocks.Where(block => block.Row == row).ToList();

            if (currentRow.Count != _gridSettings.HorizontalBlockCount)
                continue;

            foreach (BlockBase block in currentRow)
            {
                _inactiveBlocks.Remove(block);
                _grid.Children.Remove(block);
            }

            var allRowsAbove = _inactiveBlocks.Where(block => block.Row < row);
            foreach (BlockBase block in allRowsAbove)
            {
                _blockPositionWriter.SetBlockPosition(block, block.Row + 1, block.Column);
            }

            row += 1;
            Score += 100;
        }

        FigureIsFalling();
    }

    private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    private void CloseTheWindow(object sender, RoutedEventArgs e)
    {
        var result = MessageBox.Show("Are you sure you want to quit?", "", MessageBoxButton.YesNo);
        if (result == MessageBoxResult.Yes)
            Close();
    }

    private void MinimizeTheWindow(object sender, RoutedEventArgs e)
    {
        WindowState = WindowState.Minimized;
    }

    private void DragTheWindow(object sender, RoutedEventArgs e)
    {
        DragMove();
    }
}

