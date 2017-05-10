using SimpleFeedReader;
using System.Collections.Generic;
using System.Timers;
using System.Xml;
using System.Linq;
using System.Windows.Forms;
using System.ServiceModel.Syndication;
using System.Globalization;
using System;

namespace RSSReader
{
    public class Reader
    {
        // Pytanie, czym się różni funcja Feeds() od xmel(), mam wrażenie że obie realizują to samo zadanie.
        public static string Feeds()
        {
            var reader = new FeedReader();
            // Docelowo dane zaczytywane od użytkownika
            var items = reader.RetrieveFeed("http://www.nytimes.com/services/xml/rss/nyt/International.xml");
            string feeds = "";
            foreach (var i in items)
            {
                var x = (string.Format("{0}\t{1}",
                        i.Date.ToString("g"),
                        i.Title)
                );
                feeds += x + "\n";
            }
            return feeds;
        }
    }

    public class Getter
    {
        public static List<Post> xmel()
        {
            var feedsList = new List<Post>();
            List<string> UrlList = new List<string>();
            // UrlList.Add("http://www.tvn24.pl/najnowsze.xml");
            UrlList.Add("http://wiadomosci.wp.pl/ver,rss,rss.xml");
            // UrlList.Add("http://www.tvn24.pl/biznes-gospodarka,6.xml");
            UrlList.Add("http://fakty.interia.pl/feed");

            foreach (var link in UrlList)
            {
                XmlReader reader = XmlReader.Create(link);
                SyndicationFeed feed = SyndicationFeed.Load(reader);
                foreach (var item in feed.Items)
                {
                    Post post = new Post(DateTime.Now);
                    post.Title = item.Title.Text;
                    post.Description = item.Summary.Text;
                    post.PublishedDate = item.PublishDate.DateTime;
                    post.Link = item.Links[0].Uri.ToString();

                    feedsList.Add(post);
                }

            }
            return feedsList;
        }
    }

    #region cutter
    //public class Cutter
    //{
    //    public static Post Posts(IEnumerable<FeedItem> x)
    //    {
    //        XmlDocument doc = new XmlDocument();
    //        doc.Load("c:\\temp.xml");
    //        var pos = new Post();
    //        foreach (XmlNode node in doc.DocumentElement.ChildNodes)
    //        {
    //            string text = node.InnerText; //or loop through its children as well
    //            string attr = node.Attributes["link"]?.InnerText;
    //        }

    //        return;


    //    }
    //}
    #endregion


    public class TimerClass
    {
        public static System.Timers.Timer _timer;
        public static void SetTimer()
        {
            _timer = new System.Timers.Timer(30000);
            _timer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            _timer.AutoReset = true;
            _timer.Start();
            _timer.Enabled = true;
        }

        private static void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            MessageBox.Show("The Elapsed event was raised at {0:HH:mm:ss.fff}" + e.SignalTime);
        }
    }

    public class TnijXML
    {
        public static List<string> GetLinksFromFile(string myXmlString)
        {
            XmlDocument xml = new XmlDocument();
            List<string> linki = null;
            xml.LoadXml(myXmlString);

            XmlNodeList xnList = xml.SelectNodes("/ArrayOfString");
            foreach (XmlNode xn in xnList)
            {
                string link = xn["String"].InnerText;

                linki.Add(link);
            }
            return linki;

        }
    }

}