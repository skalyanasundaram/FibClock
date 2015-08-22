# FibClock
Fibonacci Clock 

Initial version. While starting the app, it generates all possible combination for every hour and every 5 minutes and 
picks up a random solution for everytime it has to change the time.


How to calculate time? 
Each tile represents a number based on its size. The values of the tiles are 1,1,2,3,5.
It may have three different color tiles. Red, Green, Blue. 
To calculate hour, simply count the Red tiles. To calculate minute, count the Green tiles and multiple my 5.
If you see blue tile, add it to both red and green.
In essence,
 Hour = Red + Blue 
 Minute = (Green + Blue) * 5 

Google/Bing for fibonacci clock for more details.