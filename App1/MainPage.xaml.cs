using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Controls.Maps;
using Windows.Devices.Geolocation;


// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=391641

namespace App1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    /// public sealed class MapControl : Control
    public sealed partial class MainPage : Page
    {
        Geolocator geo = null;
        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void button1_Click(object sender, RoutedEventArgs e)
        {
            if (geo == null)
            {
                geo = new Geolocator();
            }

            Geoposition pos = await geo.GetGeopositionAsync();
            textLatitude.Text = "Latitude: " + pos.Coordinate.Point.Position.Latitude.ToString();
            textLongitude.Text = "Longitude: " + pos.Coordinate.Point.Position.Longitude.ToString();
            textAccuracy.Text = "Accuracy: " + pos.Coordinate.Accuracy.ToString();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            MapControl1.Center =
                new Geopoint(new BasicGeoposition()
                {
                    Latitude = 47.604,
                    Longitude = -122.329
                });
            MapControl1.ZoomLevel = 12;
            MapControl1.LandmarksVisible = true;
        }
 
/*        private void AddMapIcon()
        {
            MapIcon MapIcon1 = new MapIcon();
            MapIcon1.Location = new Geopoint(new BasicGeoposition()
            {
                Latitude = 47.620,
                Longitude = -122.349
            });
            MapIcon1.NormalizedAnchorPoint = new Point(0.5, 1.0);
            MapIcon1.Title = "Space Needle";
            MapControl1.MapElements.Add(MapIcon1);
        }
        */

    }
}
