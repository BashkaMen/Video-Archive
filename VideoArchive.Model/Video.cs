using NReco.VideoInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace VideoArchive.Model
{
    public class Video
    {
       

        public TimeSpan Duration { get; private set; }



       

        public Video(string filePath)
        {
            Duration = new FFProbe().GetMediaInfo(filePath).Duration;

        }

    }
}
