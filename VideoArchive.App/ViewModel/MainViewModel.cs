using DevExpress.Mvvm;
using Microsoft.Win32;
using Newtonsoft.Json;
using NReco.VideoInfo;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using VideoArchive.App.Model;
using VideoArchive.App.ViewModel;
using VideoArchive.App.Views;
using VideoArchive.Model;

namespace VideoArchive.ViewModel
{
    public class MainViewModel : BaseVM
    {
        public ObservableCollection<Video> Videos { get; set; }
        public ICollectionView VideosView { get; set; }
        public Page MainContent { get; set; }

        
        private string _SearchText { get; set; }
        public string SearchText
        {
            get => _SearchText;
            set
            {
                _SearchText = value;
                VideosView.Filter = (obj) =>
                {
                    if (obj is Video video)
                    {
                        return video.Name.ToLower().Contains(SearchText.ToLower());
                    }

                    return false;
                };
                VideosView.Refresh();

            }
        }


        public MainViewModel()
        {
            OverlayService.GetInstance().Show = (str) =>
            {
                OverlayService.GetInstance().Text = str;
            };


            Videos = File.Exists("VideosData.json") ? JsonConvert.DeserializeObject<ObservableCollection<Video>>(File.ReadAllText("VideosData.json")) : new ObservableCollection<Video>();
            Videos.CollectionChanged += (s, e) =>
            {
                File.WriteAllText("VideosData.json", JsonConvert.SerializeObject(Videos));
            };
            BindingOperations.EnableCollectionSynchronization(Videos, new object());
            VideosView = CollectionViewSource.GetDefaultView(Videos);
        }

        public DelegateCommand Sort
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    

                    if (VideosView.SortDescriptions.Count > 0)
                    {
                        VideosView.SortDescriptions.Clear();
                    }
                    else
                    {
                        VideosView.SortDescriptions.Add(new SortDescription("Name", ListSortDirection.Ascending));
                    }
                });
            }
        }

        public DelegateCommand<Video> DeleteVideo
        {
            get
            {
                return new DelegateCommand<Video>((video) =>
                {
                    Videos.Remove(video);


                }, (video)=> video != null);
            }
        }

        public DelegateCommand AddItem
        {
            get
            {
                return new DelegateCommand(async() =>
                {
                    var opd = new OpenFileDialog();
                    opd.Multiselect = true;
                    if (opd.ShowDialog() == true)
                    {
                        await Task.Factory.StartNew(() =>
                        {
                            OverlayService.GetInstance().Show("Загрузка информации о видео...");

                            for (int i = 0; i < opd.FileNames.Length; i++)
                            {
                                OverlayService.GetInstance().Show($"Загрузка информации о видео...{Environment.NewLine}{i}/{opd.FileNames.Length}");
                                var file = opd.FileNames[i];

                                var info = new YouTubeAPI().SearchVideo(Path.GetFileNameWithoutExtension(file));

                                Videos.Add(new Video
                                {
                                    Path = file,
                                    Name = Path.GetFileNameWithoutExtension(file),
                                    Size = (new FileInfo(file).Length / 1024.0) / 1024.0,
                                    Duration = new FFProbe().GetMediaInfo(file).Duration,
                                    Channel = info?.Items?.FirstOrDefault()?.Snippet?.ChannelTitle,
                                    Descrition = info?.Items?.FirstOrDefault()?.Snippet?.Description,
                                    PublishData = info?.Items?.FirstOrDefault()?.Snippet?.PublishedAt ?? new DateTime(),
                                    Url = "https://www.youtube.com/watch?v=" + info?.Items?.FirstOrDefault()?.Id?.VideoId,
                                    Images = new ObservableCollection<string>() { "", "", "", "", "", "", "", "" }
                                });

                                Task.Delay(500).Wait();
                            }

                            OverlayService.GetInstance().Close();
                        });
                    }

                });
            }
        }

        public DelegateCommand<string> GoToUrl
        {
            get
            {
                return new DelegateCommand<string>((url) =>
                {
                    if (new Uri(url).IsFile)
                    {
                        Process.Start(new ProcessStartInfo("explorer.exe", " /select, " + url));
                    }
                    else
                    {
                        Process.Start(url);
                    }

                    
                });
            }
        }

        public DelegateCommand<Video> EditVideo
        {
            get
            {
                return new DelegateCommand<Video>((video) =>
                {
                    var w = new EditVideoWindow();
                    var vm = new EditVideoViewModel
                    {
                        VideoInfo = video,
                    };
                    w.DataContext = vm;
                    w.ShowDialog();
                    File.WriteAllText("VideosData.json", JsonConvert.SerializeObject(Videos));

                }, (video) => video != null);
            }
        }

    }
}
