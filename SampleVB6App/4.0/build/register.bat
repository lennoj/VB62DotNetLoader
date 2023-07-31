@echo off
cls
title VB6 TO DotNET Loader [REGISTER] 

echo Use to Register "VB62DotNetLoader.dll" 
echo Created by JPMENDOZA


path = "C:\Windows\Microsoft.NET\Framework\v4.0.30319"
regasm VB62DotNetLoader.dll /codebase
regasm VB62DotNetLoader.dll /codebase /tlb: VB62DotNetLoader.tlb

pause	