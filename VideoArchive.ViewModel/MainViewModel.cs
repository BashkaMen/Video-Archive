using DevExpress.Mvvm;
using Microsoft.Win32;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using VideoArchive.Model;

namespace VideoArchive.ViewModel
{
    public class MainViewModel : BaseVM
    {
        public ObservableCollection<VideoInfo> Videos { get; set; }
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
                    if (obj is VideoInfo video)
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

            
            Videos = new ObservableCollection<VideoInfo>
            {
                new VideoInfo
                {
                    Channel = "BashkaMen",
                    Descrition = "Лучшее видео на ютубе",
                    KeyWords = "qweqwe, asdas, asdaf, asfjhgksd",
                    Name = "Смешно до боли",
                    Tematic = "Шутейки",
                    Duration = TimeSpan.FromSeconds(153),
                    Comment = "Супер выдос",
                    Path = @"D:\Video\Templates\INTRO\INTRO.mp4",
                    PublishData = DateTime.Now,
                    Size = 123423423,
                    Url = "https://youtube.com",
                    Images = new string[] { @"C:\Users\megab\Dropbox\картинки\Logo.png" }
                },
                new VideoInfo
                {
                    Channel = "BashkaMen",
                    Descrition = "Лучшее видео на ютубе",
                    KeyWords = "qweqwe, asdas, asdaf, asfjhgksd",
                    Name = "Видео 2",
                    Tematic = "Юмор",
                    Duration = TimeSpan.FromSeconds(153),
                    Comment = "Супер выдос",
                    Path = @"D:\Video\Templates\INTRO\INTRO.mp4",
                    PublishData = DateTime.Now,
                    Size = 123423423,
                    Url = "https://youtube.com"
                },

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

        public DelegateCommand<VideoInfo> DeleteVideo
        {
            get
            {
                return new DelegateCommand<VideoInfo>((video) =>
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

                            //Task.Delay(2000).Wait();


                            foreach (var file in opd.FileNames)
                            {

                                Videos.Add(new VideoInfo
                                {
                                    Path = file,
                                    Name = Path.GetFileNameWithoutExtension(file),
                                    Size = new FileInfo(file).Length,
                                    Duration = new Video(file).Duration,


                                });
                            }

                            OverlayService.GetInstance().Close();
                        });
                    }

                });
            }
        }
        

    }
}
