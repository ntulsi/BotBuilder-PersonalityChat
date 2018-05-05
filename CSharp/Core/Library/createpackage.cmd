@echo off
setlocal
setlocal enabledelayedexpansion
setlocal enableextensions
set errorlevel=0
mkdir ..\nuget
erase /s ..\nuget\*.nupkg
..\packages\NuGet.CommandLine.4.6.2\tools\NuGet.exe pack Microsoft.Bot.Builder.PersonalityChat.Core.nuspec -symbols -properties version=%version%;builder=%builder% -OutputDirectory ..\nuget