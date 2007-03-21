@echo off
%SYSTEMROOT%\Microsoft.NET\Framework\v2.0.50727\MSBuild.exe /p:Configuration=Release km.hl\km.hl.csproj

if %errorlevel% NEQ 0 (
	echo "Build failed"
	goto exit
)
set arch=wince
if ""%1 NEQ "" (set arch=win32)

echo Build for: %arch%
set file=hl.%arch%.jar
if exist %file% rm %file%

if %arch% EQU win32 (
	goto xmlPack
)

cd km.hl\bin\Release
if %errorlevel% NEQ 0 (
	echo "Build failed"
	goto exit
)
zip ..\..\..\%file% *.dll *.exe km.hl.exe.xml
cd ..\..\..

:xmlPack

cd oraLite\%arch%
if %errorlevel% NEQ 0 (
	echo "Build failed"
	goto exit
)
zip ..\..\%file% web.xml 
cd ..\..

echo -= Build success =-
:exit