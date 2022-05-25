Imports DevExpress.Xpf.Map
Imports System.Collections.Generic
Imports System.Collections.ObjectModel
Imports System.Windows
Imports System.Windows.Input

Namespace DXMap_RouteProvider

	Partial Public Class MainWindow
		Inherits Window

        Public Sub New()
			InitializeComponent()

			' Create three waypoints and add them to a route waypoints list. 
			Dim waypoints As New List(Of RouteWaypoint)()
			waypoints.Add(New RouteWaypoint("New York", New GeoPoint(41.145556, -73.995)))
			waypoints.Add(New RouteWaypoint("Oklahoma", New GeoPoint(36.131389, -95.937222)))
			waypoints.Add(New RouteWaypoint("Las Vegas", New GeoPoint(36.175, -115.136389)))

			routeProvider.CalculateRoute(waypoints)
		End Sub

		Private Sub routeProvider_LayerItemsGenerating(ByVal sender As Object, ByVal args As LayerItemsGeneratingEventArgs)
			Dim letter As Char = "A"c

			For Each item As MapItem In args.Items
				Dim pushpin As MapPushpin = TryCast(item, MapPushpin)
				If pushpin IsNot Nothing Then
					pushpin.Text = letter.ToString()
					letter = ChrW(AscW(letter) + 1)
				End If
				Dim line As MapPolyline = TryCast(item, MapPolyline)
				If line IsNot Nothing Then
                    line.Fill = System.Windows.Media.Brushes.Red
                    line.Stroke = System.Windows.Media.Brushes.Red
                End If
			Next item
            map.ZoomToFit(args.Items)
        End Sub
	End Class
End Namespace
