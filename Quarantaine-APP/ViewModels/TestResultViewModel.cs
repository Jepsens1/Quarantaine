using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Quarantaine_APP.Interfaces;

namespace Quarantaine_APP.ViewModels
{
    public partial class TestResultViewModel : ObservableObject
    {
        private ILocation _location;

        [ObservableProperty]
        double distance = 0;

        public TestResultViewModel(ILocation _location)
        {
            this._location = _location;
        }

        [RelayCommand]
        async Task ShowLocation()
        {
           await _location.GetCurrentLocation().ConfigureAwait(false);
        }
        [RelayCommand]
        void CalculateDistance()
        {
            Distance = _location.CalculateDistance();
        }
    }
}
