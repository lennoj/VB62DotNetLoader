@echo off
cls
title VB6 TO DotNET Loader [UNREGISTER]

path = "C:\Windows\Microsoft.NET\Framework\v4.0.30319"
regasm /unregister "C:\Users\VMJPMENDOZA\Desktop\VB62DotNetLoader\SampleVB6App\VB62DotNetLoader.dll" /codebase
regasm /unregister "C:\Users\VMJPMENDOZA\Desktop\VB62DotNetLoader\SampleVB6App\VB62DotNetLoader.dll" /codebase /tlb: VB62DotNetLoader.tlb

pause