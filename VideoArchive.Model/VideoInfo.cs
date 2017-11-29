using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoArchive.Model
{
    public class VideoInfo : BaseVM
    {
        private string _Name;
        public string Name
        {
            get
            {
                return _Name;
            }
            set
            {
                _Name = value;
            }
        }
        public string Channel { get; set; }
        public string Descrition { get; set; }
        public string Tematic { get; set; }
        public string KeyWords { get; set; }
        public TimeSpan Duration { get; set; }
        public double Size { get; set; }
        public DateTime PublishData { get; set; }
        public string Url { get; set; }
        public string Path { get; set; }
        public string Comment { get; set; }
        public string[] Images { get; set; }

    }
}
