using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoArchive.App.Model;

namespace VideoArchive.Model
{
    public class Video : BaseVM
    {
        public string Name { get; set; }
        public string Channel { get; set; }
        public string Descrition { get; set; }
        public string Tematic { get; set; }
        public ObservableCollection<KeyWordItem> KeyWords { get; set; } = new ObservableCollection<KeyWordItem>();
        public TimeSpan Duration { get; set; }
        public double Size { get; set; }
        public DateTime PublishData { get; set; }
        public string Url { get; set; }
        public string Path { get; set; }
        public string Comment { get; set; }
        public ObservableCollection<string> Images { get; set; } = new ObservableCollection<string>();

    }
}
