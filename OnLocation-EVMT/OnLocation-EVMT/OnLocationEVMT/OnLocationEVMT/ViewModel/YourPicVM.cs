using OnLocationEVMT.Helpers;
using OnLocationEVMT.Models;
using OnLocationEVMT.Views;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace OnLocationEVMT.ViewModel
{
    /// <summary>
    /// This Class Not Used
    /// </summary>
    class YourPicVM : ObservableObject
    {
        List<ProjectPic> ObjImages { get; set; }
        public ObservableRangeCollection<GroupPostImage> Images { get; set; }
        private ContentView _ProjectImageBind;

        public ContentView ProjectImageBind
        {
            get { return _ProjectImageBind; }
            set { _ProjectImageBind = value;
                OnPropertyChanged(nameof(ProjectImageBind));
            }
        }

        bool _isBusy;
        /// <summary>
        /// Gets or sets the isBusy.
        /// </summary>
        /// <value>The _isBusy.</value>
        public bool isBusy
        {
            get { return _isBusy; }
            set
            {
                _isBusy = value;
                OnPropertyChanged(nameof(isBusy));
            }
        }

        private bool _isClicked;
        /// <summary>
        /// Get or Set isClicked
        /// </summary>
        public bool IsClicked
        {
            get { return _isClicked; }
            set
            {
                _isClicked = value;
                OnPropertyChanged(nameof(IsClicked));
            }
        }
        private Grid gridimages;

        public Grid GridImages
        {
            get { return gridimages; }
            set { gridimages = value;
                OnPropertyChanged(nameof(GridImages));
            }
        }

        private List<PicImage> picimagelist;

        public List<PicImage> PicImageList
        {
            get { return picimagelist; }
            set { picimagelist = value; }
        }

        public YourPicVM()
        {
            PicImageList = new List<PicImage>();
            Images = new ObservableRangeCollection<GroupPostImage>();           
            GroupSeed.AllowedImageSize = 10;
            GroupSeed.AllowedImages = 1;            
        }


        private ICommand takePhotoCommand;
        /// <summary>
        /// Take Photo Command for User ID
        /// </summary>
        public ICommand TakePhotoCommand
        {
            get
            {
                try
                {
                    if (takePhotoCommand == null)
                        takePhotoCommand = new Command(async () =>
                        {
                            if (Images.Count >= GroupSeed.AllowedImages)
                            {
                                // if (ImageCountExceededEvent != null)
                                // {
                                //if (isClicked)
                                // {
                                //isClicked = false;
                                await App.Current.MainPage.DisplayAlert("Image Restrication", "Resterication", Resource.OK);
                                return;
                                // }
                                //  }
                                //ImageCountExceededEvent(GroupSeed.AllowedImages);
                            }

                            GroupPostImage img = await TakePhoto();
                            if (img == null)
                                return;
                            //await App.Current.MainPage.Navigation.PushModalAsync(new ImageExample(img.Image));
                            // await PhotoUpload(img, "ID", "STID");
                            //img.ImageId = await PhotoHelper.UploadPhoto(img);
                        });
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.StackTrace);
                }

                return takePhotoCommand;
            }
        }


        /// <summary>
        /// Method for Choose Photo
        /// </summary>
        /// <returns></returns>
        private async Task<GroupPostImage> ChoosePhoto()
        {
            PhotoCapture photo = await PhotoHelper.ChoosePhoto();
            GroupPostImage newImg = photo.CapturedImage;
            try
            {
                if (newImg != null)
                {
                    Images.Insert(0, newImg);
                }
                else if (photo.SizeExceeded)
                {
                    // await App.Current.MainPage.DisplayAlert("Size", "Document size less than 2 MB", Resource.Ok);
                    ///if (ImageSizeExceededEvent != null)
                    /// ImageSizeExceededEvent(GroupSeed.AllowedImageSize);
                }
                else if (photo.DeviceError)
                {
                    await App.Current.MainPage.DisplayAlert("Device", "Not Allow", Resource.OK);
                    // if (DeviceErrorEvent != null)
                    //  DeviceErrorEvent();
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
            }
            return newImg;

        }



        /// <summary>
        /// Method for take Photo
        /// </summary>
        /// <returns></returns>
        private async Task<GroupPostImage> TakePhoto()
        {
            PhotoCapture photo = await PhotoHelper.TakePhoto();
            GroupPostImage newImg = photo.CapturedImage;
            try
            {
                if (newImg != null)
                {
                    Images.Insert(0, newImg);
                }
                else if (photo.SizeExceeded)
                {
                    //if (ImageSizeExceededEvent != null)
                    //    ImageSizeExceededEvent(GroupSeed.AllowedImageSize);
                }
                else if (photo.DeviceError)
                {
                    await App.Current.MainPage.DisplayAlert("Device", "Not Allow", Resource.OK);
                    //if (DeviceErrorEvent != null)
                    //    DeviceErrorEvent();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
            }

            return newImg;
        }


        //public void GetDummyData()
        //{
        //    byte[] ProfileImage = null;
        //    ProfileImage = System.Convert.FromBase64String("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");
        //    Stream stream = new MemoryStream(ProfileImage);
        //    byte[] m_Bytes = StreamHelper.ReadToEnd(stream);
        //    ProfileImage = m_Bytes;
        //    List<ImageList> obj = new List<ImageList>()
        //    {
        //        new ImageList()
        //        {
        //            ImageID="1",
        //            Image="SearchIcon.png",
        //            Img= ImageSource.FromStream(() => new MemoryStream(ProfileImage))

        //        },
        //        new ImageList()
        //        {
        //            ImageID="1",
        //            Image="SearchIcon.png",
        //            Img= ImageSource.FromStream(() => new MemoryStream(ProfileImage))
        //        },
        //        new ImageList()
        //        {
        //            ImageID="1",
        //            Image="SearchIcon.png",
        //            Img= ImageSource.FromStream(() => new MemoryStream(ProfileImage))
        //        }
        //    };
        //   ObjImages = new List<ProjectPic>()
        //    {
        //        new ProjectPic()
        //        {
        //            Date="10/12/2018",
        //            Images=obj
        //        },
        //        new ProjectPic()
        //        {
        //            Date="01/09/2018",
        //            Images=obj
        //        },
        //        new ProjectPic()
        //        {
        //            Date="04/08/2017",
        //            Images=obj
        //        },

        //    };



        //}
        private Command picimagetapcommand;
        /// <summary>
        /// Command for spot icon tapped
        /// </summary>
        public Command PicImageTapCommand
        {
            get
            {
                if (picimagetapcommand == null)
                    picimagetapcommand = new Command((req) =>
                    {
                        try
                        {                           
                                    PicImage icon = req as PicImage;
                                    int index = PicImageList.IndexOf(icon);
                                    foreach (Element g in GridImages.Children)
                                    {
                                        if (g.Id == PicImageList[index].picimage.Id)
                                        {
                                            Image image = g as Image;
                                            image.IsEnabled = false;
                                        }
                                        if (g.Id == PicImageList[index].tickimage.Id)
                                        {
                                            Image image = g as Image;
                                            image.IsVisible = true;
                                        }
                                    }                            

                        }
                        catch (Exception ex)
                        {
                            Debug.WriteLine(ex.StackTrace);
                        }

                    });

                return picimagetapcommand;
            }
        }

        public void CreateGrid()
        {
            try
            {
                byte[] ProfileImage = null;
                ProfileImage = System.Convert.FromBase64String("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");
                Stream stream = new MemoryStream(ProfileImage);
                byte[] m_Bytes = StreamHelper.ReadToEnd(stream);
                ProfileImage = m_Bytes;

                List<ImageList> obj = new List<ImageList>()
            {
                new ImageList()
                {
                    ImageID="1",
                    Image="SearchIcon.png",
                    Img= ImageSource.FromStream(() => new MemoryStream(ProfileImage))
                },
                new ImageList()
                {
                    ImageID="1",
                    Image="ResetIcon.png",
                    Img= ImageSource.FromStream(() => new MemoryStream(ProfileImage))
                },
                new ImageList()
                {
                    ImageID="1",
                    Image="SearchIcon.png",
                    Img= ImageSource.FromStream(() => new MemoryStream(ProfileImage))
                }
            };
                List<ImageList> obj2 = new List<ImageList>()
            {
                new ImageList()
                {
                    ImageID="1",
                    Image="SearchIcon.png",
                    Img= ImageSource.FromStream(() => new MemoryStream(ProfileImage))
                },
                new ImageList()
                {
                    ImageID="1",
                    Image="SearchIcon.png",
                    Img= ImageSource.FromStream(() => new MemoryStream(ProfileImage))
                }
            };
                List<ImageList> obj3 = new List<ImageList>()
            {
                new ImageList()
                {
                    ImageID="1",
                    Image="SearchIcon.png",
                    Img= ImageSource.FromStream(() => new MemoryStream(ProfileImage))
                },
                new ImageList()
                {
                    ImageID="1",
                    Image="SearchIcon.png",
                    Img= ImageSource.FromStream(() => new MemoryStream(ProfileImage))
                },
                new ImageList()
                {
                    ImageID="1",
                    Image="SearchIcon.png",
                    Img= ImageSource.FromStream(() => new MemoryStream(ProfileImage))
                },
                new ImageList()
                {
                    ImageID="1",
                    Image="SearchIcon.png",
                    Img= ImageSource.FromStream(() => new MemoryStream(ProfileImage))
                }
            };
                List<ImageList> obj4 = new List<ImageList>()
            {
                new ImageList()
                {
                    ImageID="1",
                    Image="ResetIcon.png",
                    Img = ImageSource.FromStream(() => new MemoryStream(ProfileImage))
                },
                new ImageList()
                {
                    ImageID="1",
                    Image="ResetIcon.png",
                    Img= ImageSource.FromStream(() => new MemoryStream(ProfileImage))
                },
                new ImageList()
                {
                    ImageID="1",
                    Image="SearchIcon.png",
                    Img= ImageSource.FromStream(() => new MemoryStream(ProfileImage))
                },
                new ImageList()
                {
                    ImageID="1",
                    Image="ResetIcon.png",
                    Img= ImageSource.FromStream(() => new MemoryStream(ProfileImage))
                },
                 new ImageList()
                {
                    ImageID="1",
                    Image="SearchIcon.png"
                },
                new ImageList()
                {
                    ImageID="1",
                    Image="ResetIcon.png",
                    Img= ImageSource.FromStream(() => new MemoryStream(ProfileImage))
                },
                new ImageList()
                {
                    ImageID="1",
                    Image="SearchIcon.png",
                    Img= ImageSource.FromStream(() => new MemoryStream(ProfileImage))
                },
                new ImageList()
                {
                    ImageID="1",
                    Image="ResetIcon.png",
                    Img= ImageSource.FromStream(() => new MemoryStream(ProfileImage))

                }
            };
                ObjImages = new List<ProjectPic>()
            {
                new ProjectPic()
                {
                    Date="10/12/2014",
                    Images=obj,
                    DateWithTime=Convert.ToDateTime("10/12/2014")
                },
                new ProjectPic()
                {
                    Date="01/09/2018",
                    Images=obj2,
                    DateWithTime=Convert.ToDateTime("01/09/2018")
                },
                new ProjectPic()
                {
                    Date="04/08/2017",
                    Images=obj3,
                    DateWithTime=Convert.ToDateTime("04/08/2017")
                },
                  new ProjectPic()
                {
                    Date="04/08/2013",
                    Images=obj4,
                    DateWithTime=Convert.ToDateTime("04/08/2013")
                }

            };



                //Row//
                RowDefinition row = new RowDefinition();
                row.Height = 55;
                RowDefinition row1 = new RowDefinition();
                row.Height = 180;


                //row.Height = GridLength.Auto;
                RowDefinitionCollection rowDefinitions = new RowDefinitionCollection();
                //Row//


                for (int i = 0; i < ObjImages.Count; i++)
                {
                    if (ObjImages[i].Date != null)
                    {
                        rowDefinitions.Add(row);
                    }
                    if (ObjImages[i].Images != null)
                    {
                        int imagerows = ObjImages[i].Images.Count / 3;
                        int addrows = 0;
                        addrows = ObjImages[i].Images.Count % 3;
                        if (addrows > 0)
                        {
                            imagerows += 1;
                        }
                        var v = ObjImages[i].Images;

                        for (int k = 0; k < imagerows; k++)
                        {

                            rowDefinitions.Add(row1);

                        }

                    }

                }




                //Column//
                ColumnDefinition col = new ColumnDefinition();
                col.Width = (App.Current.MainPage.Width / 3) - 10;
                ColumnDefinitionCollection columnDefinitions = new ColumnDefinitionCollection();
                //Column//
                for (int j = 0; j < 3; j++)
                {
                    columnDefinitions.Add(col);
                }
                var layout = new Grid();
                layout.ColumnDefinitions = columnDefinitions;
                layout.RowDefinitions = rowDefinitions;
                layout.RowSpacing = 0;
                int count = 0;
                for (int i = 0; i < 4; i++)
                {
                    if (ObjImages[i].Date != null)
                    {
                        StackLayout stlobj = new StackLayout()
                        {
                            HorizontalOptions = LayoutOptions.FillAndExpand,
                            VerticalOptions = LayoutOptions.FillAndExpand,
                            BackgroundColor = Color.ForestGreen
                        };
                        Label lbl = new Label();
                        lbl.Text = ObjImages[i].Date;
                        lbl.FontSize = 16;
                        lbl.FontAttributes = FontAttributes.Bold;
                        lbl.HorizontalOptions = LayoutOptions.Start;
                        lbl.VerticalOptions = LayoutOptions.Center;
                        lbl.Margin = new Thickness(10, 0, 0, 0);
                        stlobj.Children.Add(lbl);
                        layout.Children.Add(lbl, 0, count);
                        layout.RowDefinitions[count].Height = 55;
                        Grid.SetColumnSpan(lbl, 3);
                        count++;
                    }
                    if (ObjImages[i].Images != null)
                    {
                        int imagerows = ObjImages[i].Images.Count / 3;
                        int addrows = 0;
                        addrows = ObjImages[i].Images.Count % 3;
                        if (addrows > 0)
                        {
                            imagerows += 1;
                        }
                        var v = ObjImages[i].Images;
                        int countimage = 0;
                        for (int k = 0; k < imagerows; k++)
                        {

                            for (int j = 0; j < 3; j++)
                            {
                                PicImage picimage = new PicImage();
                                Image img = new Image()
                                {
                                    Margin = new Thickness(2, 2, 2, 2),
                                    BackgroundColor = Color.White,
                                    HeightRequest = 200
                                };

                                if (v.Count > countimage)
                                {
                                    img.Source = v[countimage].Img;
                                    countimage++;
                                }
                                else
                                {
                                    break;
                                }
                                TapGestureRecognizer tapgesture = new TapGestureRecognizer();
                                tapgesture.Command = PicImageTapCommand;
                                tapgesture.CommandParameter = picimage;
                                //TapGestureRecognizer ticktapgesture = new TapGestureRecognizer();
                                //ticktapgesture.Command = PicImageTapCommand;
                                //ticktapgesture.CommandParameter = picimage;
                                //ticktapgesture.NumberOfTapsRequired = 2;
                                Image tickimage = new Image();
                                tickimage.Source = "tickicon.png";
                                tickimage.IsVisible = false;
                                //tickimage.GestureRecognizers.Add(ticktapgesture);
                                img.GestureRecognizers.Add(tapgesture);
                                picimage.picimage = img;
                                picimage.tickimage = tickimage;
                                PicImageList.Add(picimage);
                                layout.Children.Add(img, j, count);
                                layout.Children.Add(tickimage, j, count);
                            }
                            count++;
                        }

                    }

                }
                GridImages = new Grid();
                GridImages = layout;
                ProjectImageBind = new ProjectImage(layout);
                //sname.Children.Add(layout);
                var asc = ObjImages.OrderBy(item => item.DateWithTime);
                var desc = ObjImages.OrderByDescending(item => item.DateWithTime);// OrderByDecending(item => item.Body);
            }
            catch (Exception ex)
            {

                
            }
           
        }
    }
}
