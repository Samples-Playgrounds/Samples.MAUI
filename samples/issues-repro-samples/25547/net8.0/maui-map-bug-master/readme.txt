
==== Problem ===========================================================================================================

Some polygons aren't being cleared from the map when the map's MapElement.Clear method is called. 

This only appears to happen when there are more than one polygon on the map simulataneously.

Specifically, it appears that all but the last polygon that was added to the map (in the 'DrawAll' method of 
MainPage.xaml.cs) are drawn twice, yet the map's MapElements property only records one instance of them. This is easy to 
see if the polygons have a translucent fill colour.

This only seems to happen when multiple polygons are added to the map via the MapElements.Add method within the same 
method call (e.g. in the DrawAll method of MainPage.xaml.cs).


==== How To Replicate ==================================================================================================

To replicate the problem, follow these steps:
    1. Click the "Add Polygon A/B/C/D" buttons any number of times and in any order.
    2. Click the "Clear All Polygons" button.
    3. Notice that all of the polygons are removed from the map.
    4. Click the "Add All Polygons" button.
    5. Notice that all four polygons were added to the map.
    6. Click the "Clear All Polygons" button.
    7. Notice that all but polygon D remain on the map.

To set up the map control on Android, follow Microsoft's tutorial: https://learn.microsoft.com/en-us/dotnet/maui/user-interface/controls/map?view=net-maui-8.0


==== Workaround ========================================================================================================

I've found that adding a delay between each MapElement.Add call (see the 'DrawAll' method of MainPage.xaml.cs) helps 
to prevent the polygons from being drawn twice. However, if this delay is too low, such as 5ms, the first polygon
that's rendered (polygon A) still seems to be drawn twice. I've also found in one of my projects that as the number of 
polygons increases the delay has to be longer to avoid the bug.

To activate the workaround go to the definition of the AddAll command in MainPage.xaml.cs and set the pAddDelayBetween
parameter of the DrawAll method call to true.