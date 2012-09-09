# This is the HDHomeRun Stream Builder #

**HDHR Stream Builder** is a tool written in C#.Net for Windows to assist in managing the integration of the [HDHomeRun](http://www.silicondust.com/products/hdhomerun/atsc/) network streaming device with various aspects of XBMC including the [TVGuide Addon](http://forum.xbmc.org/showthread.php?tid=120377).

## Why in the world do you want a **.strm* file? ##

To be able to tune and play content from my shiney new HDHomeRun Prime on my XBMC clients of course!

XBMC has had support for the HDHomeRun for some time now. Using the following format XBMC will change the channel on the specfied tuner to the channel and program specfied un the url. The easiest way to get this setup is to generate **.strm* files for each channel. Each **.strm* file contains a url like the one below.

> hdhomerun://99999999-0/tuner0?channel=auto:135&program=646

## Isn't there a Perl script that does this? ##

Yes there is a [Perl script](http://code.google.com/p/hdhr-mkchan/) written by JWater7. I had some trouble with the Fios channel scans producing consistent **.strm* files for each channel. I monkeyed with it for a while, but since I'm a complete novice when it comes to Perl, it was just easier for me to port it over to C# real quick. The challenge turned out not to be Perl, but the regular expression for parsing the output of the scan. I found that many channels were being skipped because the regex didn't cover all scenarios in the output data.

## Doesn't the HDHomeRun Config GUI tool do this? ##

The HDHomeRun Config GUI tool has support for generating **.strm* files too, but unortunately has not been updated to work on Windows 7.

I threw together a quick program one night based mostly on the Perl code I found that generated the files. That was the basis of the HDHomeRun Stream Builder as it has since been added to with other utility functions to make my life easier.

# How to Use the HDHomeRun Stream Builder #

Considering this thing has become a bit of a hodgepodge of features related to HDHR and XBMC, and the fact that this is written hastily in my spare time focusing more on results than user experience and code prettiness, I'd bet the following information is required.

## Configuration ##

Choose *Tools > Options* to configure the tool

1. Choose the location of your hdhomerun_config.exe file.

	1. This is located in the install directory for your silicondust HDHomeRun


2. Choose the location of your mc2xml.exe file.

3. Choose the location of your TVGuide Source.db file.

	1. This is located in the addon_data directory of your XBMC install under the TVGuide folder. If you do not see a folder there for the TVGuide Addon, then make sure it is installed first.

4. Set your prefered behavior of the scanner. You can choose to have it ignore any channel that is marked as encrypted and any zero program numbers.

	1. For Fios setup on my Prime, I leave "Ignore All Encrypted" unchecked, but I check the "Ignore Zero Program Number" option.

	2. For QAM channels, Dilligaf from the XBMC forums reported having channels that were not named, but did in fact contain a stream *(these are channels that have not been encrypted by the provider and therefor can be obtained without a cablecard or set top box directly over the cable line like in the old days of cable)*

## Scanning for Channels ##

1. Choose the *tuner* to use from the top right of the screen

	1. The selected tuner is the value used when writing the **.strm* files
	2. The selected tuner is the value used when configuring the TVGuide Addon

2. Choose *Tools > Scan Channels* (a few minutes with the Pime)

3. Enhancing channel names with XMLTV data

	1. This will be done automatically by building an XMLTV file using mc2xml.exe during the channel scan.
	2. If you have not yet configured mc2xml, you will be prompted to enter your zipcode during the first channel scan.
	3. Once a zip code is entered, a list of content providers for your area will be presented for you to select the one that represents your cable service.
	4. mc2xml will now download the tv listings and channels for your cable service specifically
	5. HDHR Stream Builder will use the channels portion of that generated XMLTV to merge with the content from the initial HDHR channel scan. This provides for a higher quality channel name, the callsign, and the XMLTV channel ID for any channels matched by the virtual channel number.

## Setting Favorite Channels ##

1. Check the boxes for the channels you want (favorites). There are a couple of convenient ways to do this.

	1. Click the "Select HD Only" button from the UI to automatically check channels that contain the capital letters "HD" in the name. This will overright any previous checks as it does a clear of all checks as it's first step.

	2. Click the "Select Channel Range" button from the UI to select a range of channels in a popup. This popup has a checkbox to give the option over overriding all prior checks first or to add to what is already checked.

	3. The last option is the simplest and the one I end up using the most. Holding down CTRL or SHIFT to select multiple channels at once, then right click and choose check or uncheck.

2. Choose *File > Save* to save all of the channels.

## Building the STRM Files ##

1. First complete a channel scan and select your favorite channels as the only **.strm* files generated will be for the selected channels.
2. Choose File > Export > Stream Files (*.strm)

	1. This will generate a folder named for the selected tuner under the configured strm file directory like `/<strm_dir>/tuner<tuner_number>/<strm_filename>.strm`

7. Choose Tools > XMLTV > Write Favorite Channels File (*.chl)
8. Choose Tools > XMLTV > Build XMLTV File For Favorites Only
9. Choose Tools > Configure Using Favorite Channels

	- This will publish each favorite channel to TVGuide and associate the stream files with each
