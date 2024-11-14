using System;
using System.Collections.ObjectModel;

using WPF_MVVM.Commands;
using WPF_MVVM.Data;
using WPF_MVVM.Models;
using WPF_MVVM.ViewModels.Base;

namespace WPF_MVVM.ViewModels
{
    public class StatisticsViewModel : ViewModel
    {
        public static NavigationCommand NavigateToMenuPage { get => new(null, NavigateToPage, new Uri("Views/Pages/MenuPage.xaml", UriKind.RelativeOrAbsolute)); }
        public static ObservableCollection<Player> StatisticsCollection { get => Statistics.Players; }
    }
}
