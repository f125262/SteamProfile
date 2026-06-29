# SteamProfile

Utility for converting MP4 videos into GIFs for Steam Artwork Showcase and Steam Workshop displays.

## Features

* MP4 → GIF conversion
* Adjustable FPS (1–30)
* Adjustable output width (100–1444 px)
* Steam Workshop Mode
* Automatic frame extraction
* Automatic split into 5 separate GIF files
* GIF patching for Steam Workshop compatibility
* Steam instruction generator
* Cyberpunk-inspired UI
* Local processing (no browser, no upload required)

## Steam Workshop Mode

Workshop Mode is designed for Steam Artwork Showcase projects.

The selected video is:

1. Converted into PNG frames
2. Split into 5 vertical sections
3. Reassembled into 5 separate GIF files
4. Patched for improved Steam Workshop compatibility

This allows creating multi-panel Steam artwork showcases similar to those commonly used on Steam profiles.

## Requirements

* Windows
* ffmpeg.exe must be located next to SteamProfile.exe

FFmpeg download:

https://drive.google.com/file/d/1Exi9l33NA6KybkfgMbhhcmInb2rmw19n/view?usp=sharing

## Usage

1. Select an MP4 file
2. Choose FPS
3. Choose output width
4. Enable Workshop Mode if needed
5. Click CONVERT
6. Upload the generated GIF files to Steam

## Changelog

### v3.0.0
* New Features
* Drag & Drop support
* Advanced settings menu
* Automatic unique output file naming
* Automatic unique project folder naming
* Delete temporary files
* Open output folder after conversion
* Improvements
* Better project structure
* Code split into multiple source files
* Improved conversion workflow
* Improved file management
* UI
* Expanded Cyberpunk-inspired interface
* Improved overall usability

### v2.0.0

* Complete UI redesign
* Cyberpunk-inspired interface
* Custom animated controls
* Steam instruction generator
* Improved Workshop workflow
* Output width range changed to 100–1440 px
* General code cleanup and improvements

### v1.0.0

* Initial release
* MP4 → GIF conversion
* Steam Workshop Mode
* Automatic split into 5 GIF files

## Version

Current version: v2.0.0
