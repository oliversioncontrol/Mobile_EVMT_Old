using System;
using System.Diagnostics;
using Xamarin.Forms;

namespace OnLocationEVMT.Controls
{
    /// <summary>
    /// Loader Class implementation
    /// </summary>
    public class Loader
    {

        /// <summary>
        /// Used for Activity Indicator mapping
        /// </summary>
        /// <param name="overlay"></param>
        /// <returns></returns>
        public AbsoluteLayout GetLoader(AbsoluteLayout overlay)
        {
            try
            {
                ActivityIndicator indicator = new ActivityIndicator();
                indicator.IsRunning = true;
                indicator.IsVisible = true;
                indicator.Color = Color.FromHex("#71D64A"); // #d3d3d3 - Gray Indicator OR  #883C96- Purple Indicator(header color)
                if (Device.RuntimePlatform == Device.iOS)
                {
                    if (Device.Idiom == TargetIdiom.Phone)
                    {
                        if (Device.RuntimePlatform == Device.iOS)
                        {
                            indicator.Scale = 2;
                        }
                        else
                        {
                            indicator.Scale = 1;
                        }

                    }
                    else if (Device.Idiom == TargetIdiom.Tablet)
                    {
                        indicator.Scale = 3;
                    }
                }

                AbsoluteLayout.SetLayoutFlags(overlay, AbsoluteLayoutFlags.PositionProportional);
                AbsoluteLayout.SetLayoutBounds(overlay, new Rectangle(.5, .5, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));
                AbsoluteLayout.SetLayoutFlags(indicator, AbsoluteLayoutFlags.PositionProportional);
                AbsoluteLayout.SetLayoutBounds(indicator, new Rectangle(0.5, 0.5, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));
                overlay.Children.Add(indicator);
                overlay.IsVisible = false;
                overlay.WidthRequest = ScreenHeightWidth.ScreenWidth;
                overlay.HeightRequest = ScreenHeightWidth.ScreenHeight;
                overlay.BackgroundColor = Color.Gray;
                overlay.Opacity = .5;
                return overlay;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.StackTrace.ToString());
                return null;
            }
        }
    }
}
