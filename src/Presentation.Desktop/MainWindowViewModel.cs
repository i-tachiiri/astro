using CommunityToolkit.Mvvm.ComponentModel;

namespace Presentation.Desktop;

public partial class MainWindowViewModel : ObservableObject
{
    public DashboardViewModel DashboardViewModel { get; }

    public MainWindowViewModel(DashboardViewModel dashboardViewModel)
    {
        DashboardViewModel = dashboardViewModel;
    }
}
