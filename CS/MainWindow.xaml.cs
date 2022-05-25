using DevExpress.Xpf.Map;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;

namespace DXMap_RouteProvider {

    public partial class MainWindow : Window {
   
        public MainWindow() {
            InitializeComponent();

            // Create three waypoints and add them to a route waypoints list. 
            List<RouteWaypoint> waypoints = new List<RouteWaypoint>();
            waypoints.Add(new RouteWaypoint("New York", new GeoPoint(41.145556, -73.995)));
            waypoints.Add(new RouteWaypoint("Oklahoma", new GeoPoint(36.131389, -95.937222)));
            waypoints.Add(new RouteWaypoint("Las Vegas", new GeoPoint(36.175, -115.136389)));

            routeProvider.CalculateRoute(waypoints);
        }

        private void routeProvider_LayerItemsGenerating(object sender, LayerItemsGeneratingEventArgs args) {
            char letter = 'A';
            foreach (MapItem item in args.Items) {
                MapPushpin pushpin = item as MapPushpin;
                if (pushpin != null)
                    pushpin.Text = letter++.ToString();
                MapPolyline line = item as MapPolyline;
                if (line != null) {
                    line.Fill = Brushes.Red;
                    line.Stroke = Brushes.Red;
                }
            }

            map.ZoomToFit(args.Items);
        }
    }
}
