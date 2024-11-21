
# Video to Minecraft Resource Pack Converter - Desktop App

This is a tool which converts videos to the resources required to watch it in Minecraft 1.20.4. It is multiplayer friendly so you can watch with friends!

## Basic Instructions
 
If you don't have FFmpeg installed, the program will ask you if you want to download and install it automatically. THE PROGRAM WILL NOT WORK WITHOUT IT!

Upload a video.

Change the Pack Name if you desire (this will be how it appears in the Minecraft datapack).

Choose the scale at which the video will be shown in Minecraft. You can use the preview to get it 
just right. (Note the slider in the bottom left to select different freeze-frames).

Press Convert! and wait... This could take a while depending on the length of the video.

Load up your minecraft world, type "/reload" (without quotation marks), and follow the v2mcInstructions.

When you're ready to watch, enable the resource pack by pausing the game, navigating to	options -> resource packs, and activating the pack. 

When you click "Done," Minecraft will load the resource pack into memory. THIS MAY TAKE A LONG TIME DEPENDING ON THE LENGTH OF YOUR VIDEO.

If you see a purple and black square (not a cube) after enabling the pack, it's working! 
 
If you get an error after loading the resource pack, or see a black and purple CUBE, the pack is too big and you will have to lower its size by doing one or more of the following:

1: Lower the resolution (Scale or Image Width/Height)

2: Reduce the time which the program converts (Start/End Time)

3: Reduce the framerate (Ticks per Second)

4: Tick "End Audio on Last Frame" to prevent converting extra audio

## Notes
This project uses FFmpeg, FFprobe and ImageMagick.NET.

https://ffmpeg.org/

https://imagemagick.org/

Tested with FFmpeg 6.1.
