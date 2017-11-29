using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using VideoArchive.Model;

namespace VideoArchive.App.Model
{
    public class YouTubeAPI
    {
        const string apiKey = "AIzaSyD3aKlUn9FPp7Qcl0pbd-iqYuRYQy76lBg";



        public SearchVideoResponse SearchVideo(string name)
        {
            var wb = new WebClient();
            wb.Encoding = Encoding.UTF8;

            try
            {
                return JsonConvert.DeserializeObject<SearchVideoResponse>(wb.DownloadString($"https://www.googleapis.com/youtube/v3/search?part=snippet&type=video&q={name}&key={apiKey}"));
            }
            catch
            {
                return null;
            }
        }
    }
}
