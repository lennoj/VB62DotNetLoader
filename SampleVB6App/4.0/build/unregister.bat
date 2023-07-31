@echo off
cls
title VB6 TO DotNET Loader [UNREGISTER]

echo Use to Un-Register "VB62DotNetLoader.dll" 
echo Created by JPMENDOZA

path = "C:\Windows\Microsoft.NET\Framework\v4.0.30319"
regasm /unregister VB62DotNetLoader.dll /codebase
regasm /unregister VB62DotNetLoader.dll /codebase /tlb: VB62DotNetLoader.tlb

pause