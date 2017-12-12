using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoArchive.Model;

namespace VideoArchive.App.Model
{
    public class HostVideoInfo : BaseVM
    {
        public string Channel { get; set; }
        public string Description { get; set; }
        public DateTime PublicDate { get; set; }
        public string Url { get; set; }

    }
}
