using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoArchive.Model
{
    public class OverlayService : BaseVM
    {
        private static OverlayService _Instance = new OverlayService();
        public static OverlayService GetInstance() => _Instance;

        private OverlayService() { }

        public Action<string> Show { get; set; }

        public string Text { get; set; } = "";

        public void Close()
        {
            Text = "";
        }

    }
}
