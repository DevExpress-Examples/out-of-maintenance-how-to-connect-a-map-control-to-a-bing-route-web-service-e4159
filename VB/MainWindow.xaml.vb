Imports DevExpress.Xpf.Map
Imports System.Collections.Generic
Imports System.Windows
Imports System.Windows.Media

Namespace DXMap_RouteProvider

    Public Partial Class MainWindow
        Inherits Window

        Public Sub New()
            Me.InitializeComponent()
            ' Create three waypoints and add them to a route waypoints list. 
            Dim waypoints As List(Of RouteWaypoint) = New List(Of RouteWaypoint)()
            waypoints.Add(New RouteWaypoint("New York", New GeoPoint(41.145556, -73.995)))
            waypoints.Add(New RouteWaypoint("Oklahoma", New GeoPoint(36.131389, -95.937222)))
            waypoints.Add(New RouteWaypoint("Las Vegas", New GeoPoint(36.175, -115.136389)))
            Me.routeProvider.CalculateRoute(waypoints)
        End Sub

        Private Sub routeProvider_LayerItemsGenerating(ByVal sender As Object, ByVal args As LayerItemsGeneratingEventArgs)
            Dim letter As Char = "A"c
            For Each item As MapItem In args.Items
                Dim pushpin As MapPushpin = TryCast(item, MapPushpin)
                If pushpin IsNot Nothing Then pushpin.Text = System.Math.Min(System.Threading.Interlocked.Increment(letter), letter - 1).ToString()
                Dim line As MapPolyline = TryCast(item, MapPolyline)
                If line IsNot Nothing Then
                    line.Fill = Brushes.Red
                    line.Stroke = Brushes.Red
                End If
            Next

            Me.map.ZoomToFit(args.Items)
        End Sub
    End Class
End Namespace
