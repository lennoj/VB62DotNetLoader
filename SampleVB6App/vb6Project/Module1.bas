Attribute VB_Name = "Module1"
Public Static Sub OnAsyncComplete(ByVal returnValue As Variant)
    MsgBox "Return Value " + CStr(returnValue), vbOKOnly + vbInformation, "Finish"
    
End Sub

Public Static Sub TryAsync(ByVal VB6DN As Variant, ByVal libPath As String, ByVal libPlugin As String, ByVal address As Long)
    
     address = GetAddressPointer(AddressOf OnAsyncComplete)
    
    ''MsgBox "Taget Address: " + CStr(address)

    '' Sample Call using Async Start (Asynchronous) -- New Thread
    VB6DN.LoadLibrary libPath, libPlugin
    VB6DN.StartAsync libPlugin, address, "VB6 Debugging Using Async-Start", 1, 2, 3, 5, "asdas"
    
End Sub


Public Static Function GetAddressPointer(ByVal method As Long)
    GetAddressPointer = method
End Function
