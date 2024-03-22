using System.Collections.ObjectModel;

namespace Quarantaine_APP.Interfaces
{
    public interface IParse
    {
        ObservableCollection<string> Parse(string url);
    }
}
