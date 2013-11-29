Imports System.IO

Public Class Form1
  Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

  Public Sub New()
    MyBase.New()

    'This call is required by the Windows Form Designer.
    InitializeComponent()

    'Add any initialization after the InitializeComponent() call

  End Sub

  'Form overrides dispose to clean up the component list.
  Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
    If disposing Then
      If Not (components Is Nothing) Then
        components.Dispose()
      End If
    End If
    MyBase.Dispose(disposing)
  End Sub

  'Required by the Windows Form Designer
  Private components As System.ComponentModel.IContainer

  'NOTE: The following procedure is required by the Windows Form Designer
  'It can be modified using the Windows Form Designer.  
  'Do not modify it using the code editor.
  Friend WithEvents sc As System.ServiceProcess.ServiceController
  Friend WithEvents Panel1 As System.Windows.Forms.Panel
  Friend WithEvents Panel2 As System.Windows.Forms.Panel
  Friend WithEvents tcMain As System.Windows.Forms.TabControl
  Friend WithEvents rtbLog As System.Windows.Forms.RichTextBox
  Friend WithEvents Splitter1 As System.Windows.Forms.Splitter
  Friend WithEvents tpProcess As System.Windows.Forms.TabPage
  Friend WithEvents tpServices As System.Windows.Forms.TabPage
  Friend WithEvents tpRegistry As System.Windows.Forms.TabPage
  Friend WithEvents tpDosyalar As System.Windows.Forms.TabPage
  Friend WithEvents btnAnalyze As System.Windows.Forms.Button
  Friend WithEvents btnClean As System.Windows.Forms.Button
  Friend WithEvents rtbProcesses As System.Windows.Forms.RichTextBox
  Friend WithEvents rtbServices As System.Windows.Forms.RichTextBox
  Friend WithEvents rtbRegistry As System.Windows.Forms.RichTextBox
  Friend WithEvents rtbFiles As System.Windows.Forms.RichTextBox
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(Form1))
    Me.sc = New System.ServiceProcess.ServiceController
    Me.Panel1 = New System.Windows.Forms.Panel
    Me.btnClean = New System.Windows.Forms.Button
    Me.btnAnalyze = New System.Windows.Forms.Button
    Me.Panel2 = New System.Windows.Forms.Panel
    Me.Splitter1 = New System.Windows.Forms.Splitter
    Me.rtbLog = New System.Windows.Forms.RichTextBox
    Me.tcMain = New System.Windows.Forms.TabControl
    Me.tpProcess = New System.Windows.Forms.TabPage
    Me.rtbProcesses = New System.Windows.Forms.RichTextBox
    Me.tpServices = New System.Windows.Forms.TabPage
    Me.rtbServices = New System.Windows.Forms.RichTextBox
    Me.tpRegistry = New System.Windows.Forms.TabPage
    Me.rtbRegistry = New System.Windows.Forms.RichTextBox
    Me.tpDosyalar = New System.Windows.Forms.TabPage
    Me.rtbFiles = New System.Windows.Forms.RichTextBox
    Me.Panel1.SuspendLayout()
    Me.Panel2.SuspendLayout()
    Me.tcMain.SuspendLayout()
    Me.tpProcess.SuspendLayout()
    Me.tpServices.SuspendLayout()
    Me.tpRegistry.SuspendLayout()
    Me.tpDosyalar.SuspendLayout()
    Me.SuspendLayout()
    '
    'Panel1
    '
    Me.Panel1.Controls.Add(Me.btnClean)
    Me.Panel1.Controls.Add(Me.btnAnalyze)
    Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
    Me.Panel1.Location = New System.Drawing.Point(0, 0)
    Me.Panel1.Name = "Panel1"
    Me.Panel1.Size = New System.Drawing.Size(512, 32)
    Me.Panel1.TabIndex = 0
    '
    'btnClean
    '
    Me.btnClean.Enabled = False
    Me.btnClean.FlatStyle = System.Windows.Forms.FlatStyle.Popup
    Me.btnClean.Location = New System.Drawing.Point(96, 5)
    Me.btnClean.Name = "btnClean"
    Me.btnClean.TabIndex = 1
    Me.btnClean.Text = "Temizle"
    '
    'btnAnalyze
    '
    Me.btnAnalyze.FlatStyle = System.Windows.Forms.FlatStyle.Popup
    Me.btnAnalyze.Location = New System.Drawing.Point(8, 5)
    Me.btnAnalyze.Name = "btnAnalyze"
    Me.btnAnalyze.TabIndex = 0
    Me.btnAnalyze.Text = "Analiz Et"
    '
    'Panel2
    '
    Me.Panel2.Controls.Add(Me.Splitter1)
    Me.Panel2.Controls.Add(Me.rtbLog)
    Me.Panel2.Controls.Add(Me.tcMain)
    Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
    Me.Panel2.Location = New System.Drawing.Point(0, 32)
    Me.Panel2.Name = "Panel2"
    Me.Panel2.Size = New System.Drawing.Size(512, 381)
    Me.Panel2.TabIndex = 1
    '
    'Splitter1
    '
    Me.Splitter1.Dock = System.Windows.Forms.DockStyle.Bottom
    Me.Splitter1.Location = New System.Drawing.Point(0, 146)
    Me.Splitter1.Name = "Splitter1"
    Me.Splitter1.Size = New System.Drawing.Size(512, 3)
    Me.Splitter1.TabIndex = 2
    Me.Splitter1.TabStop = False
    '
    'rtbLog
    '
    Me.rtbLog.Dock = System.Windows.Forms.DockStyle.Bottom
    Me.rtbLog.Location = New System.Drawing.Point(0, 149)
    Me.rtbLog.Name = "rtbLog"
    Me.rtbLog.Size = New System.Drawing.Size(512, 232)
    Me.rtbLog.TabIndex = 1
    Me.rtbLog.Text = ""
    Me.rtbLog.WordWrap = False
    '
    'tcMain
    '
    Me.tcMain.Controls.Add(Me.tpProcess)
    Me.tcMain.Controls.Add(Me.tpServices)
    Me.tcMain.Controls.Add(Me.tpRegistry)
    Me.tcMain.Controls.Add(Me.tpDosyalar)
    Me.tcMain.Dock = System.Windows.Forms.DockStyle.Fill
    Me.tcMain.Location = New System.Drawing.Point(0, 0)
    Me.tcMain.Name = "tcMain"
    Me.tcMain.SelectedIndex = 0
    Me.tcMain.Size = New System.Drawing.Size(512, 381)
    Me.tcMain.TabIndex = 0
    '
    'tpProcess
    '
    Me.tpProcess.Controls.Add(Me.rtbProcesses)
    Me.tpProcess.Location = New System.Drawing.Point(4, 22)
    Me.tpProcess.Name = "tpProcess"
    Me.tpProcess.Size = New System.Drawing.Size(504, 355)
    Me.tpProcess.TabIndex = 0
    Me.tpProcess.Text = "Programlar"
    '
    'rtbProcesses
    '
    Me.rtbProcesses.Dock = System.Windows.Forms.DockStyle.Fill
    Me.rtbProcesses.Location = New System.Drawing.Point(0, 0)
    Me.rtbProcesses.Name = "rtbProcesses"
    Me.rtbProcesses.Size = New System.Drawing.Size(504, 355)
    Me.rtbProcesses.TabIndex = 0
    Me.rtbProcesses.Text = "Avsynmgr.exe" & Microsoft.VisualBasic.ChrW(10) & "Mgtmgr.exe"
    '
    'tpServices
    '
    Me.tpServices.Controls.Add(Me.rtbServices)
    Me.tpServices.Location = New System.Drawing.Point(4, 22)
    Me.tpServices.Name = "tpServices"
    Me.tpServices.Size = New System.Drawing.Size(504, 355)
    Me.tpServices.TabIndex = 1
    Me.tpServices.Text = "Servisler"
    '
    'rtbServices
    '
    Me.rtbServices.Dock = System.Windows.Forms.DockStyle.Fill
    Me.rtbServices.Location = New System.Drawing.Point(0, 0)
    Me.rtbServices.Name = "rtbServices"
    Me.rtbServices.Size = New System.Drawing.Size(504, 355)
    Me.rtbServices.TabIndex = 1
    Me.rtbServices.Text = "-- Bunlar Test için yazýldý --" & Microsoft.VisualBasic.ChrW(10) & "Olay Günlüðü" & Microsoft.VisualBasic.ChrW(10) & "Telnet"
    '
    'tpRegistry
    '
    Me.tpRegistry.Controls.Add(Me.rtbRegistry)
    Me.tpRegistry.Location = New System.Drawing.Point(4, 22)
    Me.tpRegistry.Name = "tpRegistry"
    Me.tpRegistry.Size = New System.Drawing.Size(504, 355)
    Me.tpRegistry.TabIndex = 2
    Me.tpRegistry.Text = "Kayýt Defteri"
    '
    'rtbRegistry
    '
    Me.rtbRegistry.Dock = System.Windows.Forms.DockStyle.Fill
    Me.rtbRegistry.Location = New System.Drawing.Point(0, 0)
    Me.rtbRegistry.Name = "rtbRegistry"
    Me.rtbRegistry.Size = New System.Drawing.Size(504, 355)
    Me.rtbRegistry.TabIndex = 1
    Me.rtbRegistry.Text = "HKEY_CURRENT_USER\Software\Microsoft\Windows\ShellNoRoam\MUICache|C:\WINDOWS\Avsy" & _
    "nmgr.exe" & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(10) & "HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion\Winlog" & _
    "on|shell " & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(10) & "HKEY_LOCAL_MACHINE\SYSTEM\ControlSet001\Services|McAfee Internet secu" & _
    "rity suite " & Microsoft.VisualBasic.ChrW(10) & Microsoft.VisualBasic.ChrW(10) & "HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services|McAfee Interne" & _
    "t security suite "
    Me.rtbRegistry.WordWrap = False
    '
    'tpDosyalar
    '
    Me.tpDosyalar.Controls.Add(Me.rtbFiles)
    Me.tpDosyalar.Location = New System.Drawing.Point(4, 22)
    Me.tpDosyalar.Name = "tpDosyalar"
    Me.tpDosyalar.Size = New System.Drawing.Size(504, 355)
    Me.tpDosyalar.TabIndex = 3
    Me.tpDosyalar.Text = "Dosyalar"
    '
    'rtbFiles
    '
    Me.rtbFiles.Dock = System.Windows.Forms.DockStyle.Fill
    Me.rtbFiles.Location = New System.Drawing.Point(0, 0)
    Me.rtbFiles.Name = "rtbFiles"
    Me.rtbFiles.Size = New System.Drawing.Size(504, 355)
    Me.rtbFiles.TabIndex = 1
    Me.rtbFiles.Text = "%WINDOWS%\Avsynmgr.exe" & Microsoft.VisualBasic.ChrW(10) & "%SystemRoot%\Mgtmgr.exe"
    '
    'Form1
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(512, 413)
    Me.Controls.Add(Me.Panel2)
    Me.Controls.Add(Me.Panel1)
    Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
    Me.Name = "Form1"
    Me.Text = "HemDefender  (HemOnline (TM) Kaka Yazýlým Tartaklama Sistemi)"
    Me.Panel1.ResumeLayout(False)
    Me.Panel2.ResumeLayout(False)
    Me.tcMain.ResumeLayout(False)
    Me.tpProcess.ResumeLayout(False)
    Me.tpServices.ResumeLayout(False)
    Me.tpRegistry.ResumeLayout(False)
    Me.tpDosyalar.ResumeLayout(False)
    Me.ResumeLayout(False)

  End Sub

#End Region

  Private Sub Log(ByVal S As String)
    rtbLog.AppendText(S)
    rtbLog.AppendText(Environment.NewLine)
    Application.DoEvents()
  End Sub

  Private SystemFolder As String = DecodeFolderVariables()
  Private WindowsFolder As String

  Private Sub KillProcesses(ByVal lines() As String)
    Log("*** Programlar ***")
    For Each s As String In lines
      If s.Trim <> "" Then
        Log(String.Format("{0} Hafýzadan atýlýyor...", s))
        DefenderUtilities.CleaningHelper.Instance.KillProcessTree(s)
      End If
    Next
    Log("---")
  End Sub

  Private Sub CheckProcesses(ByVal lines() As String)
    Log("*** Programlar ***")
    For Each s As String In lines
      If s.Trim <> "" Then
        Log(String.Format("{0} hafýzada aranýyor...", s))
        If DefenderUtilities.CleaningHelper.Instance.CheckProcessTree(s) Then
          Log("  bulundu!!!...")
        Else
          Log("  bulunamadý...")
        End If
      End If
    Next
    Log("---")
  End Sub

  Private Sub StopServices(ByVal lines() As String)
    Log("*** Servisler ***")
    For Each s As String In lines
      If s.Trim <> "" Then
        Log(String.Format("{0} Durduruluyor...", s))
        Try
          DefenderUtilities.CleaningHelper.Instance.StopService(s)
        Catch ex As Exception
          Log(ex.Message)
        End Try
      End If
    Next
    Log("---")
  End Sub

  Private Sub CheckServices(ByVal lines() As String)
    Log("*** Servisler ***")
    For Each s As String In lines
      If s.Trim <> "" Then
        Log(String.Format("{0} servisi aranýyor...", s))
        Try
          If DefenderUtilities.CleaningHelper.Instance.CheckService(s) Then
            Log("  çalýþýyor!!!...")
          Else
            Log("  çalýþmýyor...")
          End If
        Catch ex As Exception
          Log(ex.Message)
        End Try
      End If
    Next
    Log("---")
  End Sub

  Private Sub CleanRegistry(ByVal lines() As String)
    Log("*** Kayýt Defteri ***")
    For Each s As String In lines
      If s.Trim <> "" Then
        Log(String.Format("{0} Siliniyor...", s))
        Dim parts() As String = s.Split("|")
        If parts.Length <> 2 Then
          Log("  Anahtar adý ya da deðerde bir sorun var...")
        Else
          If Not DefenderUtilities.CleaningHelper.Instance.DeleteKeyOrValue(parts(0), parts(1)) Then
            Log("  bulunamadý...")
          End If
        End If
      End If
    Next
    Log("---")
  End Sub

  Private Sub CheckRegistry(ByVal lines() As String)
    Log("*** Kayýt Defteri ***")
    For Each s As String In lines
      If s.Trim <> "" Then
        Log(String.Format("{0} aranýyor...", s))
        Dim parts() As String = s.Split("|")
        If parts.Length <> 2 Then
          Log("  Anahtar adý ya da deðerde bir sorun var...")
        Else
          If DefenderUtilities.CleaningHelper.Instance.CheckKeyOrValue(parts(0), parts(1)) Then
            Log("  bulundu!!!...")
          Else
            Log("  bulunamadý...")
          End If
        End If
      End If
    Next
    Log("---")
  End Sub

  Private Function DecodeFolderVariables() As String
    Dim Result As String = Environment.GetFolderPath(Environment.SpecialFolder.System)
    WindowsFolder = Path.GetDirectoryName(Result)
    Return Result
  End Function

  Private Function ExpandPaths(ByVal S As String) As String
    Return Environment.ExpandEnvironmentVariables(S.Replace("%WINDOWS%", WindowsFolder).Replace("%SYSTEM%", SystemFolder))
  End Function

  Private Sub DeleteFiles(ByVal lines() As String)
    Log("*** Dosyalar ***")
    For Each s As String In lines
      s = ExpandPaths(s.Trim)
      If s <> "" Then
        Log(String.Format("{0} Siliniyor...", s))
        If Directory.Exists(s) Then
          Directory.Delete(s, True)
        ElseIf File.Exists(s) Then
          File.Delete(s)
        Else
          Log("    bulunamadý...")
        End If
      End If
    Next
    Log("---")
  End Sub

  Private Sub CheckFiles(ByVal lines() As String)
    Log("*** Dosyalar ***")
    For Each s As String In lines
      s = ExpandPaths(s.Trim)
      If s <> "" Then
        Log(String.Format("{0} dosya aranýyor...", s))
        If Directory.Exists(s) Then
          Log("    dizin bulundu!!!...")
        ElseIf File.Exists(s) Then
          Log("    dosya bulundu!!!...")
        Else
          Log("    bulunamadý...")
        End If
      End If
    Next
    Log("---")
  End Sub

  Private Sub btnAnalyze_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAnalyze.Click
    Try
      Me.CheckProcesses(rtbProcesses.Lines)
      Me.CheckServices(rtbServices.Lines)
      Me.CheckRegistry(rtbRegistry.Lines)
      Me.CheckFiles(rtbFiles.Lines)
    Finally
      btnClean.Enabled = True
    End Try
  End Sub

  Private Sub btnClean_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClean.Click
    Try
      Me.KillProcesses(rtbProcesses.Lines)
      Me.StopServices(rtbServices.Lines)
      Me.CleanRegistry(rtbRegistry.Lines)
      Me.DeleteFiles(rtbFiles.Lines)
    Finally
      btnClean.Enabled = False
    End Try
  End Sub

End Class
