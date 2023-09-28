using Avalonia.Controls;
using Mapsui.Tiling;

namespace Second.Views;

public partial class MainView : UserControl
{
    public MainView()
    {
        InitializeComponent();
        
        MapControl.Map.Layers.Add(AMap.CreateTileLayer());
        MapControl.Map.Navigator.RotationLock = false;
        MapControl.UnSnapRotationDegrees = 30;
        MapControl.ReSnapRotationDegrees = 5;
    }
}