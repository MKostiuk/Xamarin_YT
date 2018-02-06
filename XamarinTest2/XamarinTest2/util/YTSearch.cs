using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Text.RegularExpressions;
using XamarinTest2.objects;

namespace XamarinTest2.util
{
    public class YTSearch
    {
        List<VideoInformation> items;

        WebClient webclient;

        string title;
        string author;
        string duration;
        string url;
        string thumbnail;

        /// <summary>
        /// Doing search query with given parameters. Returns a List<> object.
        /// </summary>
        /// <param name="querystring"></param>
        /// <param name="querypages"></param>
        /// <returns></returns>
        public List<VideoInformation> SearchQuery(string querystring, int querypages)
        {
            items = new List<VideoInformation>();

            webclient = new WebClient();

            // Do search
            for (int i = 1; i <= querypages; i++)
            {
                // Search address
                string html = webclient.DownloadString("https://www.youtube.com/results?search_query=" + querystring + "&page=" + i);

                // Search string
                string pattern = "<div class=\"yt-lockup-content\">.*?title=\"(?<NAME>.*?)\".*?yt-uix-sessionlink";
                MatchCollection result = Regex.Matches(html, pattern, RegexOptions.Singleline);

                for (int ctr = 0; ctr <= result.Count - 1; ctr++)
                {
                    // Title
                    title = result[ctr].Groups[1].Value;

                    // Author
                    author = VideoItemHelper.cull(result[ctr].Value, "/user/", "class").Replace('"', ' ').TrimStart().TrimEnd();

                    // Duration
                    duration = VideoItemHelper.cull(VideoItemHelper.cull(result[ctr].Value, "id=\"description-id-", "span"), ": ", "<");

                    // Url
                    url = string.Concat("http://www.youtube.com/watch?v=", VideoItemHelper.cull(result[ctr].Value, "watch?v=", "\""));

                    // Thumbnail
                    thumbnail = "https://i.ytimg.com/vi/" + VideoItemHelper.cull(result[ctr].Value, "watch?v=", "\"") + "/mqdefault.jpg";

                    // Remove playlists
                    if (title != "__title__")
                    {
                        if (duration != "")
                        {
                            // Add item to list
                            items.Add(new VideoInformation() { Title = title, Url = url, Duration = duration, Thumbnail = thumbnail, Author = author });
                        }
                    }
                }
            }

            return items;
        }
    }
}
