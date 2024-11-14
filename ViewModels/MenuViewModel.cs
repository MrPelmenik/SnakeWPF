using System;

using WPF_MVVM.Commands;
using WPF_MVVM.ViewModels.Base;

namespace WPF_MVVM.ViewModels
{
    public class MenuViewModel : ViewModel
    {
        public static NavigationCommand NavigateToGamePage { get => new(null, NavigateToPage, new Uri("Views/Pages/GamePage.xaml", UriKind.RelativeOrAbsolute)); }
        public static NavigationCommand NavigateToStatisticsPage { get => new(null, NavigateToPage, new Uri("Views/Pages/StatisticsPage.xaml", UriKind.RelativeOrAbsolute)); }
        public static RelayCommand QuitApp { get => new(Quit); }

    }
}
