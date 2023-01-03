using OnLocationEVMT.Controls;
using OnLocationEVMT.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Xamarin.Forms;
namespace OnLocationEVMT.Views
{
    /// <summary>
    /// yourPic class implementation
    /// </summary>
    public partial class YourPic : ContentPage
    {
        bool Isappering = false;
        bool ParentPage = false;
        AbsoluteLayout overlay = new AbsoluteLayout();
        public YourPic(bool IsPage)
        {

            try
            {
                InitializeComponent();
                ParentPage = IsPage;
               // CreateGrid();
                //Loader objLoader = new Loader();               
                //RelativeLayout relativeLayout = new RelativeLayout();
                //overlay = objLoader.GetLoader(overlay);
                //relativeLayout.Children.Add(
                //           gridMain,
                //           Constraint.Constant(0),
                //           Constraint.Constant(0),
                //           Constraint.RelativeToParent((parent) => { return parent.Width; }),
                //           Constraint.RelativeToParent((parent) => { return parent.Height; }));
                //relativeLayout.Children.Add(
                //   overlay,
                //   Constraint.Constant(0),
                //   Constraint.Constant(0),
                //   Constraint.RelativeToParent((parent) => { return parent.Width; }),
                //   Constraint.RelativeToParent((parent) => { return parent.Height; }));
                //Content = relativeLayout;
                //overlay.SetBinding(AbsoluteLayout.IsVisibleProperty, "IsBusy");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
            }
        }

        /// <summary>
        /// Backbutton Tabgesture events
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackTapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            if (ParentPage)
            {
                if (VM.IsClicked)
                {
                    VM.IsClicked = false;
                    //Navigation.PushModalAsync(new Views.Home());
                    App.Current.MainPage = new NavigationPage(new Home());
                }
            }
            else
            {
                Navigation.PopModalAsync();
            }
        }

        /// <summary>
        /// HomeButton Tabgesture events
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HomeTapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            if (VM.IsClicked)
            {
                VM.IsClicked = false;
                App.Current.MainPage = new NavigationPage(new Home());
            }
        }

        /// <summary>
        /// OnAppering Events
        /// </summary>
        protected override void OnAppearing()
        {
             VM.IsClicked = true;
            try
            {
                if (Isappering)
                {
                    if (Device.RuntimePlatform == Device.iOS)
                    {
                        //Loader objLoader = new Loader();
                        //AbsoluteLayout overlay = new AbsoluteLayout();
                        //RelativeLayout relativeLayout = new RelativeLayout();
                        //overlay = objLoader.GetLoader(overlay);
                        //relativeLayout.Children.Add(
                        //           gridMain,
                        //           Constraint.Constant(0),
                        //           Constraint.Constant(0),
                        //           Constraint.RelativeToParent((parent) => { return parent.Width; }),
                        //           Constraint.RelativeToParent((parent) => { return parent.Height; }));
                        //relativeLayout.Children.Add(
                        //   overlay,
                        //   Constraint.Constant(0),
                        //   Constraint.Constant(0),
                        //   Constraint.RelativeToParent((parent) => { return parent.Width; }),
                        //   Constraint.RelativeToParent((parent) => { return parent.Height; }));
                        //Content = relativeLayout;
                        //overlay.SetBinding(AbsoluteLayout.IsVisibleProperty, "IsBusy");
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
            }
        }

        /// <summary>
        /// Ons the disappearing.
        /// </summary>
        protected override void OnDisappearing()
        {
            Isappering = false;
        }


        //public void CreateGrid()
        //{

         
        //    List<ImageList> obj = new List<ImageList>()
        //    {
        //        new ImageList()
        //        {
        //            ImageID="1",
        //            Image="SearchIcon.png"
        //        },
        //        new ImageList()
        //        {
        //            ImageID="1",
        //            Image="ResetIcon.png"
        //        },
        //        new ImageList()
        //        {
        //            ImageID="1",
        //            Image="SearchIcon.png"
        //        }
        //    };
        //    List<ImageList> obj2 = new List<ImageList>()
        //    {
        //        new ImageList()
        //        {
        //            ImageID="1",
        //            Image="SearchIcon.png"
        //        },
        //        new ImageList()
        //        {
        //            ImageID="1",
        //            Image="SearchIcon.png"
        //        }
        //    };
        //    List<ImageList> obj3 = new List<ImageList>()
        //    {
        //        new ImageList()
        //        {
        //            ImageID="1",
        //            Image="SearchIcon.png"
        //        },
        //        new ImageList()
        //        {
        //            ImageID="1",
        //            Image="SearchIcon.png"
        //        },
        //        new ImageList()
        //        {
        //            ImageID="1",
        //            Image="SearchIcon.png"
        //        },
        //        new ImageList()
        //        {
        //            ImageID="1",
        //            Image="SearchIcon.png"
        //        }
        //    };
        //    List<ImageList> obj4 = new List<ImageList>()
        //    {
        //        new ImageList()
        //        {
        //            ImageID="1",
        //            Image="ResetIcon.png"
        //        },
        //        new ImageList()
        //        {
        //            ImageID="1",
        //            Image="ResetIcon.png"
        //        },
        //        new ImageList()
        //        {
        //            ImageID="1",
        //            Image="SearchIcon.png"
        //        },
        //        new ImageList()
        //        {
        //            ImageID="1",
        //            Image="ResetIcon.png"
        //        },
        //         new ImageList()
        //        {
        //            ImageID="1",
        //            Image="SearchIcon.png"
        //        },
        //        new ImageList()
        //        {
        //            ImageID="1",
        //            Image="ResetIcon.png"
        //        },
        //        new ImageList()
        //        {
        //            ImageID="1",
        //            Image="SearchIcon.png"
        //        },
        //        new ImageList()
        //        {
        //            ImageID="1",
        //            Image="ResetIcon.png"
        //        }
        //    };
        //    List<ProjectPic> ObjImages = new List<ProjectPic>()
        //    {
        //        new ProjectPic()
        //        {
        //            Date="10/12/2018",
        //            Images=obj
        //        },
        //        new ProjectPic()
        //        {
        //            Date="01/09/2018",
        //            Images=obj2
        //        },
        //        new ProjectPic()
        //        {
        //            Date="04/08/2017",
        //            Images=obj3
        //        },
        //          new ProjectPic()
        //        {
        //            Date="04/08/2017",
        //            Images=obj4
        //        }

        //    };



        //    //Row//
        //    RowDefinition row = new RowDefinition();
        //    row.Height = 55;
        //    RowDefinition row1 = new RowDefinition();
        //    row.Height = 200;


        //    //row.Height = GridLength.Auto;
        //    RowDefinitionCollection rowDefinitions = new RowDefinitionCollection();
        //    //Row//
         
        //    for (int i = 0; i < 4; i++)
        //    {
        //        if (ObjImages[i].Date != null)
        //        {
        //            rowDefinitions.Add(row);
        //        }
        //        if (ObjImages[i].Images != null)
        //        {
        //            int imagerows = ObjImages[i].Images.Count / 3;
        //            int addrows = 0;
        //            addrows = ObjImages[i].Images.Count % 3;
        //            if (addrows > 0)
        //            {
        //                imagerows += 1;
        //            }
        //            var v = ObjImages[i].Images;
                    
        //            for (int k = 0; k < imagerows; k++)
        //            {

        //                rowDefinitions.Add(row1);

        //            }

        //        }

        //    }




        //    //Column//
        //    ColumnDefinition col = new ColumnDefinition();
        //    col.Width = (App.Current.MainPage.Width / 3) - 10;
        //    ColumnDefinitionCollection columnDefinitions = new ColumnDefinitionCollection();
        //    //Column//
        //    for (int j = 0; j < 3; j++)
        //    {
        //        columnDefinitions.Add(col);
        //    }
        //    var layout = new Grid();
        //    layout.ColumnDefinitions = columnDefinitions;
        //    layout.RowDefinitions = rowDefinitions;
        //    layout.RowSpacing = 0;
        //    int count = 0;
        //    for (int i = 0; i < 4; i++)
        //    {
        //        if (ObjImages[i].Date != null)
        //        {
        //            StackLayout stlobj = new StackLayout()
        //            {
        //                HorizontalOptions = LayoutOptions.FillAndExpand,
        //                VerticalOptions = LayoutOptions.FillAndExpand,
        //                BackgroundColor = Color.ForestGreen
        //            };
        //            Label lbl = new Label();
        //            lbl.Text = ObjImages[i].Date;
        //            lbl.FontSize = 16;
        //            lbl.FontAttributes = FontAttributes.Bold;
        //            lbl.HorizontalOptions = LayoutOptions.Start;
        //            lbl.VerticalOptions = LayoutOptions.Center;
        //            stlobj.Children.Add(lbl);
        //            layout.Children.Add(lbl, 0, count);
        //            layout.RowDefinitions[count].Height = 55;
        //            Grid.SetColumnSpan(lbl, 3);
        //            count++;
        //        }
        //        if (ObjImages[i].Images != null)
        //        {
        //            int imagerows = ObjImages[i].Images.Count / 3;
        //            int addrows = 0;
        //            addrows = ObjImages[i].Images.Count % 3;
        //            if (addrows > 0)
        //            {
        //                imagerows += 1;
        //            }
        //            var v = ObjImages[i].Images;
        //            int countimage = 0;
        //            for (int k = 0; k < imagerows; k++)
        //            {

        //                for (int j = 0; j < 3; j++)
        //                {
        //                    Image img = new Image()
        //                    {
        //                        Margin = new Thickness(2, 2, 2, 2),
        //                        BackgroundColor = Color.White,
        //                        HeightRequest = 200
        //                    };

        //                    if (v.Count > countimage)
        //                    {
        //                        img.Source = v[countimage].Image;
        //                        countimage++;
        //                    }
        //                    else
        //                    {
        //                        break;
        //                    }
        //                    layout.Children.Add(img, j, count);
        //                }
        //                count++;
        //            }

        //        }

        //    }
        //    sname.Children.Add(layout);
        //}
    }
}