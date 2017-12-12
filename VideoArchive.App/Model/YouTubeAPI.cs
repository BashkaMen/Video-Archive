using HtmlAgilityPack;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using VideoArchive.App.Model.YouTubeModel;
using VideoArchive.Model;

namespace VideoArchive.App.Model
{
    public class YouTubeAPI : IVideoHostApi
    {
        const string apiKey = "AIzaSyAtZSVLUybUq-S3dtxIVCjwGgKIhlVuhK0";

        public HostVideoInfo getVideoInfo(string name)
        {
            var video = new HostVideoInfo();

            var wb = new WebClient();
            wb.Encoding = Encoding.UTF8;

            try
            {
                var data = wb.DownloadString($"https://www.youtube.com/results?search_query={name}");
                if (data != null)
                {
                    var doc = new HtmlDocument();
                    doc.LoadHtml(data);

                    var href = doc.DocumentNode.Descendants("h3").FirstOrDefault(s => s.GetAttributeValue("class", "").Contains("yt-lockup-title"))?.FirstChild?.GetAttributeValue("href", "");
                    if (href != null)
                    {
                        data = wb.DownloadString($"https://www.googleapis.com/youtube/v3/videos?part=snippet,contentDetails,statistics&id={href.Replace("/watch?v=", "")}&key={apiKey}");

                        var info = JsonConvert.DeserializeObject<SearchVideoResponse>(data);
                        if (info != null)
                        {
                            video.Channel = info?.Items?.FirstOrDefault()?.Snippet?.ChannelTitle;
                            video.Description = info?.Items?.FirstOrDefault()?.Snippet?.Description;
                            video.PublicDate = info?.Items?.FirstOrDefault()?.Snippet?.PublishedAt ?? new DateTime();
                            video.Url = $"https://youtu.be/{info?.Items?.FirstOrDefault()?.Id}";

                            return video;
                        }
                    }
                }

            }
            catch (Exception ex)
            {

            }

            return null;
        }
        
    }
}
