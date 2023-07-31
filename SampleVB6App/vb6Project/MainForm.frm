VERSION 5.00
Begin VB.Form Form1 
   Caption         =   "Form1"
   ClientHeight    =   4935
   ClientLeft      =   120
   ClientTop       =   450
   ClientWidth     =   16320
   LinkTopic       =   "Form1"
   ScaleHeight     =   4935
   ScaleWidth      =   16320
   StartUpPosition =   3  'Windows Default
   Begin VB.CommandButton btnShowPlugins 
      Caption         =   "Show Plugins"
      Height          =   1215
      Left            =   12360
      TabIndex        =   13
      Top             =   3600
      Width           =   2655
   End
   Begin VB.CommandButton btnShowLibs 
      Caption         =   "Show Libraries"
      Height          =   1215
      Left            =   9240
      TabIndex        =   12
      Top             =   3600
      Width           =   2655
   End
   Begin VB.CommandButton btnInvokeMethodAsync 
      Caption         =   "Invoke Method Async"
      Height          =   1215
      Left            =   4800
      TabIndex        =   11
      Top             =   3600
      Width           =   3975
   End
   Begin VB.CommandButton btnInvokeMethod 
      Caption         =   "Invoke Method"
      Height          =   1215
      Left            =   480
      TabIndex        =   10
      Top             =   3600
      Width           =   3495
   End
   Begin VB.TextBox txtTargetMethod 
      Height          =   495
      Left            =   2280
      TabIndex        =   9
      Text            =   "ShowMessageBox"
      Top             =   1560
      Width           =   10215
   End
   Begin VB.CommandButton btnAsync 
      Caption         =   "Load .NET Library and Target Plugin Async"
      Height          =   1215
      Left            =   12360
      TabIndex        =   7
      Top             =   2280
      Width           =   3495
   End
   Begin VB.CommandButton BTNShowConfig 
      Caption         =   "Show Configuration Manager"
      Height          =   1215
      Left            =   9240
      TabIndex        =   6
      Top             =   2280
      Width           =   2655
   End
   Begin VB.CommandButton BTNLoadAllPlugin 
      Caption         =   "Load All Plugin in .NET DLL"
      Height          =   1215
      Left            =   4680
      TabIndex        =   5
      Top             =   2280
      Width           =   4095
   End
   Begin VB.TextBox TXTTargetPlugin 
      Height          =   495
      Left            =   2280
      TabIndex        =   3
      Text            =   "TestPlugin.SamplePlugin"
      Top             =   960
      Width           =   10215
   End
   Begin VB.TextBox TXTLibraryPath 
      Height          =   495
      Left            =   2280
      TabIndex        =   1
      Text            =   "TestPlugin\TestPlugin.dll"
      Top             =   240
      Width           =   10215
   End
   Begin VB.CommandButton BTNLoadLibrary 
      Caption         =   "Load .NET Library and Target Plugin"
      Height          =   1215
      Left            =   480
      TabIndex        =   0
      Top             =   2280
      Width           =   3495
   End
   Begin VB.Label Label3 
      Caption         =   "Target Method"
      Height          =   375
      Left            =   360
      TabIndex        =   8
      Top             =   1680
      Width           =   1935
   End
   Begin VB.Label Label2 
      Caption         =   "Target Plugin Name"
      Height          =   375
      Left            =   360
      TabIndex        =   4
      Top             =   1080
      Width           =   1935
   End
   Begin VB.Label Label1 
      Caption         =   "Target DLL or Config"
      Height          =   375
      Left            =   360
      TabIndex        =   2
      Top             =   360
      Width           =   1935
   End
End
Attribute VB_Name = "Form1"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Dim VB6DN As Object
Dim address As Long


Private Sub btnAsync_Click()
    
    address = GetAddressPointer(AddressOf OnAsyncComplete)
    TryAsync VB6DN, TXTLibraryPath.Text, TXTTargetPlugin.Text, address
   
    
End Sub

Private Sub btnInvokeMethod_Click()
    If VB6DN.IsLibraryPluginLoaded(TXTTargetPlugin.Text) Then
        VB6DN.InvokeMethod TXTTargetPlugin.Text, txtTargetMethod.Text, "Message Box Title", "Hello World"
    End If
End Sub

Private Sub btnInvokeMethodAsync_Click()
    VB6DN.InvokeMethodAsync TXTTargetPlugin.Text, txtTargetMethod.Text, GetAddressPointer(AddressOf OnAsyncComplete), "Message Box Title", "Hello World"
End Sub

Private Sub BTNLoadAllPlugin_Click()
    If Not VB6DN.IsLibraryLoaded(TXTLibraryPath.Text) Then
        VB6DN.LoadLibraries TXTLibraryPath.Text
    Else
        MsgBox "Library " & TXTLibraryPath.Text & " already loaded"
    End If
End Sub

Private Sub BTNLoadLib_Click()
    VB6DN.Start TXTTargetPlugin.Text
End Sub

Private Sub BTNLoadLibrary_Click()
    
    '' Sample Call using Normal Start (Stynchronous)
    Dim sampleReturn As Variant
    
    sampleReturn = 0
    
    If Not VB6DN Is Nothing Then
        If VB6DN.IsLibraryLoaded(TXTLibraryPath.Text) Then
            
             sampleReturn = VB6DN.Start(TXTTargetPlugin.Text, "VB6 Debugging Using Sync-Start", 1, 2, 3, 12, 12.3)
                OnAsyncComplete sampleReturn
        Else
            VB6DN.LoadLibraries TXTLibraryPath.Text
            
            sampleReturn = VB6DN.Start(TXTTargetPlugin.Text, "VB6 Debugging Using Sync-Start", 1, 2, 3, 12, 12.3)
            OnAsyncComplete sampleReturn
        End If
        
       
    End If
    
   

End Sub



Private Sub BTNShowConfig_Click()
        VB6DN.ShowLibraryConfigurationManager
End Sub

Private Sub btnShowLibs_Click()
    
    Dim libs() As String
    
    
    libs = VB6DN.GetLoadedLibraries()
    
    For i = LBound(libs) To UBound(libs)
       
        
        Dim infoList() As String
        Dim info As String
        
        infoList = VB6DN.GetLibraryInformation(libs(i))
        
        For x = LBound(infoList) To UBound(infoList)
            info = info & infoList(x) & vbCrLf
        Next x
        
         MsgBox CStr(i) & " - Library " & libs(i) & " info: " & vbCrLf & info
        
    Next i
    
    
End Sub

Private Sub btnShowPlugins_Click()
     
    Dim plugs() As String
    
    
    plugs = VB6DN.GetLoadedLibraryTypes()
    
    For i = LBound(plugs) To UBound(plugs)
        
         Dim infoList() As String
        Dim info As String
        
        infoList = VB6DN.GetLibraryTypeInformation(plugs(i))
        
        For x = LBound(infoList) To UBound(infoList)
            info = info & infoList(x) & vbCrLf
        Next x
        
         MsgBox CStr(i) & " - Plugin " & plugs(i) & " info: " & vbCrLf & info
         info = ""
        
    Next i
End Sub

Private Sub Form_Load()
        Set VB6DN = CreateObject("VB62DotNetLoader.VB62DotNet")
        If Not VB6DN Is Nothing Then

            VB6DN.QuiteMode = True
            VB6DN.AutoUnload = False
            VB6DN.LoadLibrariesByConfig "myconfig.cfg"
        End If
End Sub

Private Sub Form_Unload(Cancel As Integer)
    If Not VB6DN Is Nothing Then
        VB6DN.Dispose
        Set VB6DN = Nothing
    End If
End Sub
