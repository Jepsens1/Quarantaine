using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Quarantaine_APP.Interfaces;
using System.Collections.ObjectModel;

namespace Quarantaine_APP.ViewModels
{
    public partial class MainPageViewModel : ObservableObject
    {
        private INotifyService _notifyService;
        private IParse _rssParser;

        [ObservableProperty]
        ObservableCollection<string> newsFeed;

        [ObservableProperty]
        ObservableCollection<string> ssiFeed;

        public MainPageViewModel(INotifyService notifyService, IParse rssParser)
        {
            _notifyService = notifyService;
            _rssParser = rssParser;
            NewsFeed = _rssParser.Parse("https://www.dr.dk/nyheder/service/feeds/senestenyt");
            SsiFeed = _rssParser.Parse("https://www.ssi.dk/rss");
        }
        [RelayCommand]
        async Task Login()
        {
            await Shell.Current.GoToAsync("LoginPage");
        }
        [RelayCommand]
        async Task TestResult()
        {
            await Shell.Current.GoToAsync("TestResultPage");
        }
    }
}
