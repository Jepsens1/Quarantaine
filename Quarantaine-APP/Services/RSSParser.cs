using Quarantaine_APP.Interfaces;
using System.Collections.ObjectModel;
using System.ServiceModel.Syndication;
using System.Xml;

namespace Quarantaine_APP.Services
{
    public class RSSParser : IParse
    {
        public ObservableCollection<string> Parse(string url)
        {
            ObservableCollection<string> titles = new ObservableCollection<string>();
            SyndicationFeed feed = null;
            try
            {
                using (var reader = XmlReader.Create(url))
                {
                    feed = SyndicationFeed.Load(reader);
                }
            }
            catch { }
            if (feed != null)
            {
                if (url.Contains("ssi.dk/rss"))
                {
                    foreach (var element in feed.Items)
                    {
                        if (element.Summary.Text.Contains("retningslinjer") || element.Title.Text.Contains("retningslinjer"))
                        {
                            titles.Add(element.Title.Text);
                        }
                    }
                }
                else
                {
                    foreach (var element in feed.Items)
                    {
                        titles.Add(element.Title.Text);
                    }
                }
            }
            return titles;
        }
    }
}
