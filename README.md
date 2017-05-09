This is a draft for an open-source, non-commerical implementation of 2D game engine targeted at AD&D-like rule set.
We expect that it will be cross-platform and not without Infinity Engine spirit.
It is in no way cross-path GemRB project as we do not intend to rebuild original game expirience.

Currently we use:
* C# .NET Core 1.0
* OpenTK as our OpenGL layer (https://github.com/opentk/opentk)
* ImageProcessor as a replace for System.Drawing (https://github.com/JimBobSquarePants/ImageProcessor)
* SharpFont for handling fonts (https://github.com/Robmaister/SharpFont)

**Assets and binary dependencies**

* freetype6.dll is required for SharpFont library ('main' and 'tests' folders should contain this file) (https://github.com/Robmaister/SharpFont.Dependencies/tree/master/freetype2)
* SharpFont itself currently has no NuGet package for .NET Core 1.0, so we hosting a wrapped version at www.myget.org 
* At the moment we not hosting any assets (i.e. fonts, area backgrounds etc) so they are required for launching demo
