Imports System
Imports System.IO
Imports Microsoft.Win32
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.ServiceProcess

Namespace DefenderUtilities

  Public Class CleaningHelper

    Public Shared Instance As New CleaningHelper

    Private Sub New()
    End Sub

    Private Function CI_StrEqual(ByVal A As String, ByVal B As String) As Boolean
      Return System.Globalization.CultureInfo.InvariantCulture.CompareInfo.Compare(A, B, Globalization.CompareOptions.IgnoreCase) = 0
    End Function

    Public Function DeleteKeyOrValue(ByVal Path As String, ByVal SubKey As String) As Boolean
      Dim Result As Boolean
      ' First try to find root by analyzing path
      Dim parts() As String = Path.Split("\")
      ' Case insensitive compare
      If parts.Length > 0 Then
        If CI_StrEqual(parts(0), "HKEY_LOCAL_MACHINE") Then
          Result = DeleteByRoot(Registry.LocalMachine, String.Join("\", parts, 1, parts.Length - 2), SubKey)
        ElseIf CI_StrEqual(parts(0), "HKEY_CURRENT_USER") Then
          Result = DeleteByRoot(Registry.CurrentUser, Path, SubKey)
        ElseIf CI_StrEqual(parts(0), "HKEY_CLASSES_ROOT") Then
          Result = DeleteByRoot(Registry.ClassesRoot, Path, SubKey)
        ElseIf CI_StrEqual(parts(0), "HKEY_USERS") Then
          Result = DeleteByRoot(Registry.Users, Path, SubKey)
        ElseIf CI_StrEqual(parts(0), "HKEY_CURRENT_CONFIG") Then
          Result = DeleteByRoot(Registry.CurrentConfig, Path, SubKey)
        End If
      End If
      Return Result
    End Function

    Public Function CheckKeyOrValue(ByVal Path As String, ByVal SubKey As String) As Boolean
      Dim Result As Boolean
      ' First try to find root by analyzing path
      Dim parts() As String = Path.Split("\")
      ' Case insensitive compare
      If parts.Length > 0 Then
        If CI_StrEqual(parts(0), "HKEY_LOCAL_MACHINE") Then
          Result = CheckByRoot(Registry.LocalMachine, String.Join("\", parts, 1, parts.Length - 2), SubKey)
        ElseIf CI_StrEqual(parts(0), "HKEY_CURRENT_USER") Then
          Result = CheckByRoot(Registry.CurrentUser, Path, SubKey)
        ElseIf CI_StrEqual(parts(0), "HKEY_CLASSES_ROOT") Then
          Result = CheckByRoot(Registry.ClassesRoot, Path, SubKey)
        ElseIf CI_StrEqual(parts(0), "HKEY_USERS") Then
          Result = CheckByRoot(Registry.Users, Path, SubKey)
        ElseIf CI_StrEqual(parts(0), "HKEY_CURRENT_CONFIG") Then
          Result = CheckByRoot(Registry.CurrentConfig, Path, SubKey)
        End If
      End If
      Return Result
    End Function

    Private Function DeleteByRoot(ByVal Root As RegistryKey, ByVal Path As String, ByVal SubKey As String) As Boolean
      Dim Result As Boolean
      Dim reg As RegistryKey
      reg = Root.OpenSubKey(Path, True)
      If Not reg Is Nothing Then
        Try
          ' If given SubKey is not a key but value delete the value elde delete subkey
          If reg.GetValue(SubKey) Is Nothing Then
            ' If subkey is present, delete, else do nothing
            Dim sk As RegistryKey = reg.OpenSubKey(SubKey)
            If Not sk Is Nothing Then
              sk.Close()
              reg.DeleteSubKeyTree(SubKey)
              Result = True
            End If
          Else
            reg.DeleteValue(SubKey)
            Result = True
          End If
        Finally
          reg.Close()
        End Try
      End If
    End Function

    Private Function CheckByRoot(ByVal Root As RegistryKey, ByVal Path As String, ByVal SubKey As String) As Boolean
      Dim Result As Boolean
      Dim reg As RegistryKey
      reg = Root.OpenSubKey(Path, True)
      If Not reg Is Nothing Then
        Try
          ' If given SubKey is not a key but value delete the value elde delete subkey
          If reg.GetValue(SubKey) Is Nothing Then
            ' If subkey is present, delete, else do nothing
            Dim sk As RegistryKey = reg.OpenSubKey(SubKey)
            If Not sk Is Nothing Then
              sk.Close()
              Result = True
            End If
          Else
            Result = True
          End If
        Finally
          reg.Close()
        End Try
      End If
      Return Result
    End Function

    Public Function KillProcessTree(ByVal Name As String) As Boolean
      Dim Processes() As Process
      Processes = Process.GetProcessesByName("Notepad")
      For Each p As Process In Processes
        p.WaitForExit(3000)
        If Not p.CloseMainWindow Then
          p.Kill()
        End If
      Next
    End Function

    Public Function CheckProcessTree(ByVal Name As String) As Boolean
      Dim Processes() As Process
      Processes = Process.GetProcessesByName("Notepad")
      Return Processes.Length > 0
    End Function

    Public Function StopService(ByVal Name As String) As Boolean
      Dim scm As System.ServiceProcess.ServiceController
      Try
        scm = New System.ServiceProcess.ServiceController(Name)
        If scm.Status <> ServiceProcess.ServiceControllerStatus.Running Then
          Throw New Exception("Servis zaten çalýþmýyor...")
        Else
          scm.Stop()
        End If
      Finally
        If Not scm Is Nothing Then
          scm.Close()
        End If
      End Try
    End Function

    Public Function CheckService(ByVal Name As String) As Boolean
      Dim Result As Boolean
      Dim scm As System.ServiceProcess.ServiceController
      Try
        scm = New System.ServiceProcess.ServiceController(Name)
        Result = (scm.Status = ServiceProcess.ServiceControllerStatus.Running)
      Finally
        If Not scm Is Nothing Then
          scm.Close()
        End If
      End Try
      Return Result
    End Function

  End Class

  Public Class Utils
    ' Registry access
    Shared Sub RegWrite(ByVal Path As String, ByVal Key As String, ByVal Value As Object)
      Dim reg As RegistryKey
      reg = Registry.LocalMachine.OpenSubKey(Path, True)
      If reg Is Nothing Then
        ' Key doesn't exist; create it.
        reg = Registry.LocalMachine.CreateSubKey(Path)
      End If
      If (Not reg Is Nothing) Then
        reg.SetValue(Key, Value)
        reg.Close()
      End If
    End Sub

    ' Returns Ci or Nothing
    Shared Function RegRead(ByVal Path As String, ByVal Key As String) As Object
      Dim reg As RegistryKey
      reg = Registry.LocalMachine.OpenSubKey(Path, False)
      If reg Is Nothing Then
        Return Nothing
      Else
        Dim Value As Object = reg.GetValue(Key)
        Return Value
      End If
    End Function

    Private Sub RegWritePlain(ByVal Key As String, ByVal Value As String, ByVal Path As String)
      Dim reg As RegistryKey
      reg = Registry.LocalMachine.OpenSubKey(Path, True)
      If reg Is Nothing Then
        ' Key doesn't exist; create it.
        reg = Registry.LocalMachine.CreateSubKey(Path)
      End If
      If (Not reg Is Nothing) Then
        reg.SetValue(Key, Value)
        reg.Close()
      End If
    End Sub

    ' Returns Ci or Nothing
    Private Function RegReadPlain(ByVal Key As String, ByVal Path As String) As String
      Dim reg As RegistryKey
      reg = Registry.LocalMachine.OpenSubKey(Path, False)
      If reg Is Nothing Then
        Return Nothing
      Else
        Return reg.GetValue(Key)
      End If
    End Function

    Shared Function ToBase64String(ByVal V As Object) As String
      Dim ts As New MemoryStream
      Dim formatter As New BinaryFormatter
      formatter.Serialize(ts, V)

      Return Convert.ToBase64String(ts.ToArray)
    End Function

    Shared Function FromBase64String(ByVal S As Object) As Object
      If S Is Nothing Then
        Return Nothing
      Else
        Dim ts As New MemoryStream
        Dim b() As Byte = Convert.FromBase64String(S)
        ts.Write(b, 0, b.Length)
        ts.Seek(0, SeekOrigin.Begin)
        Dim formatter As New BinaryFormatter
        Return formatter.Deserialize(ts)
      End If
    End Function

    Shared Function ObjectToByteArray(ByVal V As Object) As Byte()
      Dim ts As New MemoryStream
      Dim formatter As New BinaryFormatter
      formatter.Serialize(ts, V)
      Return ts.ToArray
    End Function

    Shared Function ObjectFromByteArray(ByVal V() As Byte) As Object
      Dim ts As New MemoryStream
      ts.Write(V, 0, V.Length)
      ts.Seek(0, SeekOrigin.Begin)
      Dim formatter As New BinaryFormatter
      Return formatter.Deserialize(ts)
    End Function

    ' Returns true if intersection of two lists contains at least one item.
    ' Assumes dst is sorted!
    Shared Function CompareArrays(ByRef src() As Int64, ByRef dst() As Int64) As Boolean
      For Each s As Int64 In src
        If Array.BinarySearch(dst, s) >= -1 Then
          Return True
        End If
      Next
      Return False
    End Function
  End Class

End Namespace
