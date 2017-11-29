using DevExpress.Mvvm;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using VideoArchive.App.Model;
using VideoArchive.Model;

namespace VideoArchive.App.ViewModel
{
    class EditVideoViewModel : BaseVM
    {
        public Video VideoInfo { get; set; }

        public DelegateCommand AddKeyWord
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    VideoInfo.KeyWords.Add(new KeyWordItem(""));
                });
            }
        }

        public DelegateCommand<KeyWordItem> DeleteKeyWord
        {
            get
            {
                return new DelegateCommand<KeyWordItem>((keyword) =>
                {
                    if (keyword != null)
                    {
                        VideoInfo.KeyWords.Remove(keyword);
                    }
                });
            }
        }

        public DelegateCommand<Window> Save
        {
            get
            {
                return new DelegateCommand<Window>((w) =>
                {
                    w?.Close();
                });
            }
        }

        public DelegateCommand<int> ImageClick
        {
            get
            {
                return new DelegateCommand<int>((index) =>
                {
                    var opd = new OpenFileDialog();
                    opd.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
                    if (opd.ShowDialog() == true)
                    {
                        VideoInfo.Images[index] = opd.FileName;
                    }
                });
            }
        }


    }
}
