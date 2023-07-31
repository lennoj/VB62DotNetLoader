@echo off
cls
title VB6 TO DotNET Loader [REGISTER]


path = "C:\Windows\Microsoft.NET\Framework\v2.0.50727"
regasm "C:\Users\VMJPMENDOZA\Desktop\VB62DotNetLoader\SampleVB6App\VB62DotNetLoader.dll" /codebase
regasm "C:\Users\VMJPMENDOZA\Desktop\VB62DotNetLoader\SampleVB6App\VB62DotNetLoader.dll" /codebase /tlb: VB62DotNetLoader.tlb

pause	