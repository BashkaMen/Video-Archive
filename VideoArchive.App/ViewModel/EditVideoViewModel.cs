using DevExpress.Mvvm;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
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
                    foreach (var key in VideoInfo.KeyWords)
                    {
                        if (DataBase.GetInstance().KeyWords.FirstOrDefault(s=> key.Value == s) == null)
                        {
                            DataBase.GetInstance().KeyWords.Add(key.Value);
                        }
                    }
                    w?.Close();
                });
            }
        }

        public ICommand AddImage
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    var opd = new OpenFileDialog();
                    opd.Multiselect = true;
                    opd.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
                    if (opd.ShowDialog() == true)
                    {
                        foreach (var item in opd.FileNames)
                        {
                            VideoInfo.Images.Add(item);
                        }
                    }
                });
            }
        }

        public ICommand RemoveImage
        {
            get
            {
                return new DelegateCommand<string>((image) =>
                {
                    if (image != null)
                    {
                        VideoInfo.Images.Remove(image);
                    }
                });
            }
        }

        public ICommand UpdateVideoInfo
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    var info = new YouTubeAPI().SearchVideo(VideoInfo.Name);

                    if (info != null)
                    {
                        var video = info?.Items?.FirstOrDefault();

                        if (video != null)
                        {
                            VideoInfo.Channel = video?.Snippet?.ChannelTitle;
                            VideoInfo.Descrition = video?.Snippet?.Description;
                            VideoInfo.PublishData = video?.Snippet?.PublishedAt ?? new DateTime();
                            VideoInfo.Url = "https://youtu.be/" + video?.Id?.VideoId ?? "";
                        }
                    }

                });
            }
        }

    }
}
