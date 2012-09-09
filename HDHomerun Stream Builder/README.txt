HDHomerun Stream Builder
v0.1
AngryCamel

I wrote this quick utility after a bit of frustration getting my
HDHomerun Prime to play in XBMC. The Perl scripts I found would
work for some channels but not others and the experience setting
it up seemed just too complex, so here ya go. This utility will
help in discovering the channels from your HDHR, caching them,
then allow you to select your favorites for use in the TV Guide
addon or just to create the strm files if you want. It can reach
out to the TVGuide Addon and configure it with the favorite
channels that you have selected.

Quick Start
========================
1. Choose Tools > Options to configure the tool
2. Choose the tuner to use from the top right of the screen
	2.a. This tuner will become the tuner used when published
		to TVGuide settings too, so make sure you think about
		it ahead of time if you use multiples for multiple
		XBMC front ends.
3. Choose Tools > Scan Channels (a few minutes with the Pime)
4. Check the boxes for the channels you want (favorites)
5. Choose File > Save to save all of the favorite channels
6. Choose File > Export > Stream Files (*.strm)
	6.a. This will create a directory under the app called "strm"
7. Choose Tools > XMLTV > Write Favorite Channels File (*.chl)
8. Choose Tools > XMLTV > Build XMLTV File For Favorites Only
9. Choose Tools > Configure Using Favorite Channels
	9.a. This will publish each favorite channel to TVGuide and 
		associate the stream files with each


Requirements
------------------------
hdhomerun_config.exe

This is needed to run the channel scan on your HDHR. Stream Builder
will parse the scan data for shows and present them on screen. You
will only need to scan once as it will cache for you.
------------------------
mc2xml.exe

This is needed if you want to generate a custom xmltv file for the
TVGuide Addon. The app can generate a *.chl file with all of the 
favorite channels you have selected then execute mc2xml to build
the xmltv file.
------------------------

------------------------
mc2xml.dat

If you don't already have one of these, durign the scan it will prompt 
to configure it, then it will save those configurations in the dat
file. As long as the dat file is in the same directory with the exe
it will use those settings when it runs and not prompt.
------------------------

------------------------
TVGuide Addon's Source.db file

This file is used to store information about the channels in the 
TVGuide Addon. The app accesses it to load paths to each of the 
generated strm files for the corresponding channel.
------------------------