<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.lblHelp_InputPort = New System.Windows.Forms.Label()
        Me.lblHelp_OutputPort = New System.Windows.Forms.Label()
        Me.lblHelp_VoiceNote = New System.Windows.Forms.Label()
        Me.lblHelp_DrumNote = New System.Windows.Forms.Label()
        Me.lblHelp_IdRequest = New System.Windows.Forms.Label()
        Me.lblHelp_GmOn = New System.Windows.Forms.Label()
        Me.lblHelp_SysxInput = New System.Windows.Forms.Label()
        Me.lblHelp_OutputTextBox = New System.Windows.Forms.Label()
        Me.lblHelp_InputTextbox = New System.Windows.Forms.Label()
        Me.lblHelp_MessageTextbox = New System.Windows.Forms.Label()
        Me.lblHelp_InputPort2 = New System.Windows.Forms.Label()
        Me.lblHelp_NotesOnKeyboard = New System.Windows.Forms.Label()
        Me.lblHelp_DrumOnKeyboard = New System.Windows.Forms.Label()
        Me.lblHelp_DrumTrackbar = New System.Windows.Forms.Label()
        Me.lblHelp_FilterInputMsg = New System.Windows.Forms.Label()
        Me.lblHelp_NoteTrackbar = New System.Windows.Forms.Label()
        Me.lblHelp_VoiceSelect = New System.Windows.Forms.Label()
        Me.lblHelp_MainVolume = New System.Windows.Forms.Label()
        Me.cbShowTooltipHelp = New System.Windows.Forms.CheckBox()
        Me.lblHelp_BulkDumpRequest = New System.Windows.Forms.Label()
        Me.lblHelp_RefreshportList = New System.Windows.Forms.Label()
        Me.lblHelp_InfoAbout = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbMidiInPorts = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbMidiOutPorts = New System.Windows.Forms.ComboBox()
        Me.tbOutput = New System.Windows.Forms.TextBox()
        Me.ContextMenuStripTbOut = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ctxMenuTbOut_clear = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnEsBulkReqDrum = New System.Windows.Forms.Button()
        Me.btnEsBulkReqVc0 = New System.Windows.Forms.Button()
        Me.lblVoiceNoteValue = New System.Windows.Forms.Label()
        Me.trkbVoiceNote = New System.Windows.Forms.TrackBar()
        Me.lblDrumNoteValue = New System.Windows.Forms.Label()
        Me.trkbDrumNote = New System.Windows.Forms.TrackBar()
        Me.lblVolumeValue = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.trkbVolume = New System.Windows.Forms.TrackBar()
        Me.cmbVoiceName = New System.Windows.Forms.ComboBox()
        Me.btnGmON = New System.Windows.Forms.Button()
        Me.btn_ID_Request = New System.Windows.Forms.Button()
        Me.btnDrumNote = New System.Windows.Forms.Button()
        Me.btnNote = New System.Windows.Forms.Button()
        Me.tbMessage = New System.Windows.Forms.TextBox()
        Me.ContextMenuStripTbMsg = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ctxMenuTbMsg_clear = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbMidiInPorts2 = New System.Windows.Forms.ComboBox()
        Me.tbInput = New System.Windows.Forms.TextBox()
        Me.ContextMenuStripTbIn = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ctxMenuTbIn_clear = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnCloseOutput = New System.Windows.Forms.Button()
        Me.btnCloseInput = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.tbSysxInput = New System.Windows.Forms.TextBox()
        Me.btnSendSysx = New System.Windows.Forms.Button()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.btnCloseInput2 = New System.Windows.Forms.Button()
        Me.btnPlayOnKeyboard = New System.Windows.Forms.Button()
        Me.btnDrumOnKeyboard = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblVoiceNumberValue = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.lblDrumNoteName = New System.Windows.Forms.Label()
        Me.btnRefreshPortList = New System.Windows.Forms.Button()
        Me.lblAuxScroll = New System.Windows.Forms.Label()
        Me.cbFilterTimingClock = New System.Windows.Forms.CheckBox()
        Me.cbFilterActiveSensing = New System.Windows.Forms.CheckBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ContextMenuStripTbOut.SuspendLayout()
        CType(Me.trkbVoiceNote, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.trkbDrumNote, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.trkbVolume, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStripTbMsg.SuspendLayout()
        Me.ContextMenuStripTbIn.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolTip1
        '
        Me.ToolTip1.AutoPopDelay = 30000
        Me.ToolTip1.InitialDelay = 500
        Me.ToolTip1.IsBalloon = True
        Me.ToolTip1.ReshowDelay = 100
        '
        'lblHelp_InputPort
        '
        Me.lblHelp_InputPort.AutoSize = True
        Me.lblHelp_InputPort.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.lblHelp_InputPort.Location = New System.Drawing.Point(460, 28)
        Me.lblHelp_InputPort.Name = "lblHelp_InputPort"
        Me.lblHelp_InputPort.Size = New System.Drawing.Size(13, 13)
        Me.lblHelp_InputPort.TabIndex = 65
        Me.lblHelp_InputPort.Text = "?"
        Me.ToolTip1.SetToolTip(Me.lblHelp_InputPort, "Select the MIDI-Port for Input" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "If no port is available, then the comboBox is emp" &
        "ty" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10))
        '
        'lblHelp_OutputPort
        '
        Me.lblHelp_OutputPort.AutoSize = True
        Me.lblHelp_OutputPort.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.lblHelp_OutputPort.Location = New System.Drawing.Point(25, 28)
        Me.lblHelp_OutputPort.Name = "lblHelp_OutputPort"
        Me.lblHelp_OutputPort.Size = New System.Drawing.Size(13, 13)
        Me.lblHelp_OutputPort.TabIndex = 64
        Me.lblHelp_OutputPort.Text = "?"
        Me.ToolTip1.SetToolTip(Me.lblHelp_OutputPort, "Select the MIDI-Port for Output")
        '
        'lblHelp_VoiceNote
        '
        Me.lblHelp_VoiceNote.AutoSize = True
        Me.lblHelp_VoiceNote.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.lblHelp_VoiceNote.Location = New System.Drawing.Point(10, 19)
        Me.lblHelp_VoiceNote.Name = "lblHelp_VoiceNote"
        Me.lblHelp_VoiceNote.Size = New System.Drawing.Size(13, 13)
        Me.lblHelp_VoiceNote.TabIndex = 80
        Me.lblHelp_VoiceNote.Text = "?"
        Me.ToolTip1.SetToolTip(Me.lblHelp_VoiceNote, resources.GetString("lblHelp_VoiceNote.ToolTip"))
        '
        'lblHelp_DrumNote
        '
        Me.lblHelp_DrumNote.AutoSize = True
        Me.lblHelp_DrumNote.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.lblHelp_DrumNote.Location = New System.Drawing.Point(10, 19)
        Me.lblHelp_DrumNote.Name = "lblHelp_DrumNote"
        Me.lblHelp_DrumNote.Size = New System.Drawing.Size(13, 13)
        Me.lblHelp_DrumNote.TabIndex = 94
        Me.lblHelp_DrumNote.Text = "?"
        Me.ToolTip1.SetToolTip(Me.lblHelp_DrumNote, "Use the left mouse-button to play a drum note" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "When focused, the space-bar wil al" &
        "so play a note" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Hold spacebar pressed to play repeated drum sound." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10))
        '
        'lblHelp_IdRequest
        '
        Me.lblHelp_IdRequest.AutoSize = True
        Me.lblHelp_IdRequest.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.lblHelp_IdRequest.Location = New System.Drawing.Point(25, 235)
        Me.lblHelp_IdRequest.Name = "lblHelp_IdRequest"
        Me.lblHelp_IdRequest.Size = New System.Drawing.Size(13, 13)
        Me.lblHelp_IdRequest.TabIndex = 95
        Me.lblHelp_IdRequest.Text = "?"
        Me.ToolTip1.SetToolTip(Me.lblHelp_IdRequest, "Send ID-Request to the selected Output Port." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "If the device is capable to respond" &
        ", ID-Reply is sent back. " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "To receive this message, the corresponding Input Port" &
        "" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "has to be selected." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10))
        '
        'lblHelp_GmOn
        '
        Me.lblHelp_GmOn.AutoSize = True
        Me.lblHelp_GmOn.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.lblHelp_GmOn.Location = New System.Drawing.Point(25, 271)
        Me.lblHelp_GmOn.Name = "lblHelp_GmOn"
        Me.lblHelp_GmOn.Size = New System.Drawing.Size(13, 13)
        Me.lblHelp_GmOn.TabIndex = 96
        Me.lblHelp_GmOn.Text = "?"
        Me.ToolTip1.SetToolTip(Me.lblHelp_GmOn, "Send GM ON to the selected Output Port." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "If the device is capable, the Geneeral M" &
        "IDI System is turned on." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "The third byte contains the device ID . The value 7F h" &
        "as the" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "meaning 'all devices'.")
        '
        'lblHelp_SysxInput
        '
        Me.lblHelp_SysxInput.AutoSize = True
        Me.lblHelp_SysxInput.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.lblHelp_SysxInput.Location = New System.Drawing.Point(25, 322)
        Me.lblHelp_SysxInput.Name = "lblHelp_SysxInput"
        Me.lblHelp_SysxInput.Size = New System.Drawing.Size(13, 13)
        Me.lblHelp_SysxInput.TabIndex = 97
        Me.lblHelp_SysxInput.Text = "?"
        Me.ToolTip1.SetToolTip(Me.lblHelp_SysxInput, resources.GetString("lblHelp_SysxInput.ToolTip"))
        '
        'lblHelp_OutputTextBox
        '
        Me.lblHelp_OutputTextBox.AutoSize = True
        Me.lblHelp_OutputTextBox.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.lblHelp_OutputTextBox.Location = New System.Drawing.Point(25, 366)
        Me.lblHelp_OutputTextBox.Name = "lblHelp_OutputTextBox"
        Me.lblHelp_OutputTextBox.Size = New System.Drawing.Size(13, 13)
        Me.lblHelp_OutputTextBox.TabIndex = 98
        Me.lblHelp_OutputTextBox.Text = "?"
        Me.ToolTip1.SetToolTip(Me.lblHelp_OutputTextBox, resources.GetString("lblHelp_OutputTextBox.ToolTip"))
        '
        'lblHelp_InputTextbox
        '
        Me.lblHelp_InputTextbox.AutoSize = True
        Me.lblHelp_InputTextbox.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.lblHelp_InputTextbox.Location = New System.Drawing.Point(460, 109)
        Me.lblHelp_InputTextbox.Name = "lblHelp_InputTextbox"
        Me.lblHelp_InputTextbox.Size = New System.Drawing.Size(13, 13)
        Me.lblHelp_InputTextbox.TabIndex = 99
        Me.lblHelp_InputTextbox.Text = "?"
        Me.ToolTip1.SetToolTip(Me.lblHelp_InputTextbox, "Bytes received from the selected Input" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "1....   The message number" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "XX XX XX .. ." &
        ". ..   Received bytes in hexadecimal format" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Right-click to clear the textbox.")
        '
        'lblHelp_MessageTextbox
        '
        Me.lblHelp_MessageTextbox.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblHelp_MessageTextbox.AutoSize = True
        Me.lblHelp_MessageTextbox.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.lblHelp_MessageTextbox.Location = New System.Drawing.Point(460, 374)
        Me.lblHelp_MessageTextbox.Name = "lblHelp_MessageTextbox"
        Me.lblHelp_MessageTextbox.Size = New System.Drawing.Size(13, 13)
        Me.lblHelp_MessageTextbox.TabIndex = 100
        Me.lblHelp_MessageTextbox.Text = "?"
        Me.ToolTip1.SetToolTip(Me.lblHelp_MessageTextbox, resources.GetString("lblHelp_MessageTextbox.ToolTip"))
        '
        'lblHelp_InputPort2
        '
        Me.lblHelp_InputPort2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblHelp_InputPort2.AutoSize = True
        Me.lblHelp_InputPort2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.lblHelp_InputPort2.Location = New System.Drawing.Point(460, 322)
        Me.lblHelp_InputPort2.Name = "lblHelp_InputPort2"
        Me.lblHelp_InputPort2.Size = New System.Drawing.Size(13, 13)
        Me.lblHelp_InputPort2.TabIndex = 101
        Me.lblHelp_InputPort2.Text = "?"
        Me.ToolTip1.SetToolTip(Me.lblHelp_InputPort2, resources.GetString("lblHelp_InputPort2.ToolTip"))
        '
        'lblHelp_NotesOnKeyboard
        '
        Me.lblHelp_NotesOnKeyboard.AutoSize = True
        Me.lblHelp_NotesOnKeyboard.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.lblHelp_NotesOnKeyboard.Location = New System.Drawing.Point(10, 53)
        Me.lblHelp_NotesOnKeyboard.Name = "lblHelp_NotesOnKeyboard"
        Me.lblHelp_NotesOnKeyboard.Size = New System.Drawing.Size(13, 13)
        Me.lblHelp_NotesOnKeyboard.TabIndex = 211
        Me.lblHelp_NotesOnKeyboard.Text = "?"
        Me.ToolTip1.SetToolTip(Me.lblHelp_NotesOnKeyboard, resources.GetString("lblHelp_NotesOnKeyboard.ToolTip"))
        '
        'lblHelp_DrumOnKeyboard
        '
        Me.lblHelp_DrumOnKeyboard.AutoSize = True
        Me.lblHelp_DrumOnKeyboard.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.lblHelp_DrumOnKeyboard.Location = New System.Drawing.Point(10, 56)
        Me.lblHelp_DrumOnKeyboard.Name = "lblHelp_DrumOnKeyboard"
        Me.lblHelp_DrumOnKeyboard.Size = New System.Drawing.Size(13, 13)
        Me.lblHelp_DrumOnKeyboard.TabIndex = 212
        Me.lblHelp_DrumOnKeyboard.Text = "?"
        Me.ToolTip1.SetToolTip(Me.lblHelp_DrumOnKeyboard, "Alphanumeric keys on the keyboard can be used to play drum notes" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Drum maps can b" &
        "e different from one device to another" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10))
        '
        'lblHelp_DrumTrackbar
        '
        Me.lblHelp_DrumTrackbar.AutoSize = True
        Me.lblHelp_DrumTrackbar.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.lblHelp_DrumTrackbar.Location = New System.Drawing.Point(171, 53)
        Me.lblHelp_DrumTrackbar.Name = "lblHelp_DrumTrackbar"
        Me.lblHelp_DrumTrackbar.Size = New System.Drawing.Size(13, 13)
        Me.lblHelp_DrumTrackbar.TabIndex = 213
        Me.lblHelp_DrumTrackbar.Text = "?"
        Me.ToolTip1.SetToolTip(Me.lblHelp_DrumTrackbar, resources.GetString("lblHelp_DrumTrackbar.ToolTip"))
        '
        'lblHelp_FilterInputMsg
        '
        Me.lblHelp_FilterInputMsg.AutoSize = True
        Me.lblHelp_FilterInputMsg.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.lblHelp_FilterInputMsg.Location = New System.Drawing.Point(460, 63)
        Me.lblHelp_FilterInputMsg.Name = "lblHelp_FilterInputMsg"
        Me.lblHelp_FilterInputMsg.Size = New System.Drawing.Size(13, 13)
        Me.lblHelp_FilterInputMsg.TabIndex = 216
        Me.lblHelp_FilterInputMsg.Text = "?"
        Me.ToolTip1.SetToolTip(Me.lblHelp_FilterInputMsg, "Uncheck the box if you want to receive " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "timing-clock (F8) or active-sensing (FE)" &
        " messages." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Seems thet not every device sends active-sensing." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10))
        '
        'lblHelp_NoteTrackbar
        '
        Me.lblHelp_NoteTrackbar.AutoSize = True
        Me.lblHelp_NoteTrackbar.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.lblHelp_NoteTrackbar.Location = New System.Drawing.Point(169, 53)
        Me.lblHelp_NoteTrackbar.Name = "lblHelp_NoteTrackbar"
        Me.lblHelp_NoteTrackbar.Size = New System.Drawing.Size(13, 13)
        Me.lblHelp_NoteTrackbar.TabIndex = 217
        Me.lblHelp_NoteTrackbar.Text = "?"
        Me.ToolTip1.SetToolTip(Me.lblHelp_NoteTrackbar, resources.GetString("lblHelp_NoteTrackbar.ToolTip"))
        '
        'lblHelp_VoiceSelect
        '
        Me.lblHelp_VoiceSelect.AutoSize = True
        Me.lblHelp_VoiceSelect.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.lblHelp_VoiceSelect.Location = New System.Drawing.Point(169, 18)
        Me.lblHelp_VoiceSelect.Name = "lblHelp_VoiceSelect"
        Me.lblHelp_VoiceSelect.Size = New System.Drawing.Size(13, 13)
        Me.lblHelp_VoiceSelect.TabIndex = 217
        Me.lblHelp_VoiceSelect.Text = "?"
        Me.ToolTip1.SetToolTip(Me.lblHelp_VoiceSelect, resources.GetString("lblHelp_VoiceSelect.ToolTip"))
        '
        'lblHelp_MainVolume
        '
        Me.lblHelp_MainVolume.AutoSize = True
        Me.lblHelp_MainVolume.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.lblHelp_MainVolume.Location = New System.Drawing.Point(184, 234)
        Me.lblHelp_MainVolume.Name = "lblHelp_MainVolume"
        Me.lblHelp_MainVolume.Size = New System.Drawing.Size(13, 13)
        Me.lblHelp_MainVolume.TabIndex = 217
        Me.lblHelp_MainVolume.Text = "?"
        Me.ToolTip1.SetToolTip(Me.lblHelp_MainVolume, "Set the Main Volume on the selected Output Port." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "A volume of '0' means silence." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "The application resets the volume to 127" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "after changin the Output Port and aft" &
        "er GM ON." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10))
        '
        'cbShowTooltipHelp
        '
        Me.cbShowTooltipHelp.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cbShowTooltipHelp.AutoSize = True
        Me.cbShowTooltipHelp.Checked = True
        Me.cbShowTooltipHelp.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbShowTooltipHelp.Location = New System.Drawing.Point(745, 453)
        Me.cbShowTooltipHelp.Name = "cbShowTooltipHelp"
        Me.cbShowTooltipHelp.Size = New System.Drawing.Size(78, 17)
        Me.cbShowTooltipHelp.TabIndex = 230
        Me.cbShowTooltipHelp.Text = "Show Help"
        Me.cbShowTooltipHelp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.ToolTip1.SetToolTip(Me.cbShowTooltipHelp, "Show or hide ToolTip Balloons" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "on the question marks ( ? )")
        Me.cbShowTooltipHelp.UseVisualStyleBackColor = True
        '
        'lblHelp_BulkDumpRequest
        '
        Me.lblHelp_BulkDumpRequest.AutoSize = True
        Me.lblHelp_BulkDumpRequest.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.lblHelp_BulkDumpRequest.Location = New System.Drawing.Point(305, 277)
        Me.lblHelp_BulkDumpRequest.Name = "lblHelp_BulkDumpRequest"
        Me.lblHelp_BulkDumpRequest.Size = New System.Drawing.Size(13, 13)
        Me.lblHelp_BulkDumpRequest.TabIndex = 231
        Me.lblHelp_BulkDumpRequest.Text = "?"
        Me.ToolTip1.SetToolTip(Me.lblHelp_BulkDumpRequest, "Two different Bulk Dump Requests" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "for a certain device (for debugging)")
        '
        'lblHelp_RefreshportList
        '
        Me.lblHelp_RefreshportList.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblHelp_RefreshportList.AutoSize = True
        Me.lblHelp_RefreshportList.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.lblHelp_RefreshportList.Location = New System.Drawing.Point(746, 375)
        Me.lblHelp_RefreshportList.Name = "lblHelp_RefreshportList"
        Me.lblHelp_RefreshportList.Size = New System.Drawing.Size(13, 13)
        Me.lblHelp_RefreshportList.TabIndex = 232
        Me.lblHelp_RefreshportList.Text = "?"
        Me.ToolTip1.SetToolTip(Me.lblHelp_RefreshportList, "Updates the List of Output- and Input Ports" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Is useful after a device was connect" &
        "ed or" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "disconnected. ")
        '
        'lblHelp_InfoAbout
        '
        Me.lblHelp_InfoAbout.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblHelp_InfoAbout.AutoSize = True
        Me.lblHelp_InfoAbout.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.lblHelp_InfoAbout.Location = New System.Drawing.Point(746, 424)
        Me.lblHelp_InfoAbout.Name = "lblHelp_InfoAbout"
        Me.lblHelp_InfoAbout.Size = New System.Drawing.Size(16, 13)
        Me.lblHelp_InfoAbout.TabIndex = 234
        Me.lblHelp_InfoAbout.Text = "? "
        Me.ToolTip1.SetToolTip(Me.lblHelp_InfoAbout, "This application was written to test the Midi_IO Library" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "The repository can be f" &
        "ound at:" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "github.com/operatortwo" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10))
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(482, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 13)
        Me.Label1.TabIndex = 63
        Me.Label1.Text = "Input Port:"
        '
        'cmbMidiInPorts
        '
        Me.cmbMidiInPorts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMidiInPorts.FormattingEnabled = True
        Me.cmbMidiInPorts.Location = New System.Drawing.Point(479, 25)
        Me.cmbMidiInPorts.Name = "cmbMidiInPorts"
        Me.cmbMidiInPorts.Size = New System.Drawing.Size(250, 21)
        Me.cmbMidiInPorts.TabIndex = 160
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(47, 11)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 13)
        Me.Label2.TabIndex = 61
        Me.Label2.Text = "Output Port:"
        '
        'cmbMidiOutPorts
        '
        Me.cmbMidiOutPorts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMidiOutPorts.FormattingEnabled = True
        Me.cmbMidiOutPorts.Location = New System.Drawing.Point(44, 27)
        Me.cmbMidiOutPorts.Name = "cmbMidiOutPorts"
        Me.cmbMidiOutPorts.Size = New System.Drawing.Size(250, 21)
        Me.cmbMidiOutPorts.TabIndex = 10
        '
        'tbOutput
        '
        Me.tbOutput.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.tbOutput.ContextMenuStrip = Me.ContextMenuStripTbOut
        Me.tbOutput.Location = New System.Drawing.Point(44, 363)
        Me.tbOutput.Multiline = True
        Me.tbOutput.Name = "tbOutput"
        Me.tbOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.tbOutput.Size = New System.Drawing.Size(385, 107)
        Me.tbOutput.TabIndex = 150
        '
        'ContextMenuStripTbOut
        '
        Me.ContextMenuStripTbOut.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ctxMenuTbOut_clear})
        Me.ContextMenuStripTbOut.Name = "ContextMenuStrip1"
        Me.ContextMenuStripTbOut.Size = New System.Drawing.Size(100, 26)
        '
        'ctxMenuTbOut_clear
        '
        Me.ctxMenuTbOut_clear.Name = "ctxMenuTbOut_clear"
        Me.ctxMenuTbOut_clear.Size = New System.Drawing.Size(99, 22)
        Me.ctxMenuTbOut_clear.Text = "clear"
        '
        'btnEsBulkReqDrum
        '
        Me.btnEsBulkReqDrum.Location = New System.Drawing.Point(326, 272)
        Me.btnEsBulkReqDrum.Name = "btnEsBulkReqDrum"
        Me.btnEsBulkReqDrum.Size = New System.Drawing.Size(109, 23)
        Me.btnEsBulkReqDrum.TabIndex = 120
        Me.btnEsBulkReqDrum.Text = "ES Bulk Req Drum"
        Me.btnEsBulkReqDrum.UseVisualStyleBackColor = True
        '
        'btnEsBulkReqVc0
        '
        Me.btnEsBulkReqVc0.Location = New System.Drawing.Point(189, 272)
        Me.btnEsBulkReqVc0.Name = "btnEsBulkReqVc0"
        Me.btnEsBulkReqVc0.Size = New System.Drawing.Size(109, 23)
        Me.btnEsBulkReqVc0.TabIndex = 110
        Me.btnEsBulkReqVc0.Text = "ES Bulk Req Vc 0"
        Me.btnEsBulkReqVc0.UseVisualStyleBackColor = True
        '
        'lblVoiceNoteValue
        '
        Me.lblVoiceNoteValue.AutoSize = True
        Me.lblVoiceNoteValue.Location = New System.Drawing.Point(392, 53)
        Me.lblVoiceNoteValue.Name = "lblVoiceNoteValue"
        Me.lblVoiceNoteValue.Size = New System.Drawing.Size(22, 13)
        Me.lblVoiceNoteValue.TabIndex = 77
        Me.lblVoiceNoteValue.Text = "xxx"
        '
        'trkbVoiceNote
        '
        Me.trkbVoiceNote.AutoSize = False
        Me.trkbVoiceNote.BackColor = System.Drawing.Color.AliceBlue
        Me.trkbVoiceNote.LargeChange = 1
        Me.trkbVoiceNote.Location = New System.Drawing.Point(190, 48)
        Me.trkbVoiceNote.Maximum = 120
        Me.trkbVoiceNote.Minimum = 24
        Me.trkbVoiceNote.Name = "trkbVoiceNote"
        Me.trkbVoiceNote.Size = New System.Drawing.Size(190, 21)
        Me.trkbVoiceNote.TabIndex = 50
        Me.trkbVoiceNote.TickStyle = System.Windows.Forms.TickStyle.None
        Me.trkbVoiceNote.Value = 24
        '
        'lblDrumNoteValue
        '
        Me.lblDrumNoteValue.AutoSize = True
        Me.lblDrumNoteValue.Location = New System.Drawing.Point(392, 53)
        Me.lblDrumNoteValue.Name = "lblDrumNoteValue"
        Me.lblDrumNoteValue.Size = New System.Drawing.Size(22, 13)
        Me.lblDrumNoteValue.TabIndex = 75
        Me.lblDrumNoteValue.Text = "xxx"
        '
        'trkbDrumNote
        '
        Me.trkbDrumNote.AutoSize = False
        Me.trkbDrumNote.BackColor = System.Drawing.Color.AliceBlue
        Me.trkbDrumNote.LargeChange = 1
        Me.trkbDrumNote.Location = New System.Drawing.Point(190, 48)
        Me.trkbDrumNote.Maximum = 96
        Me.trkbDrumNote.Minimum = 24
        Me.trkbDrumNote.Name = "trkbDrumNote"
        Me.trkbDrumNote.Size = New System.Drawing.Size(190, 21)
        Me.trkbDrumNote.TabIndex = 75
        Me.trkbDrumNote.TickStyle = System.Windows.Forms.TickStyle.None
        Me.trkbDrumNote.Value = 24
        '
        'lblVolumeValue
        '
        Me.lblVolumeValue.AutoSize = True
        Me.lblVolumeValue.Location = New System.Drawing.Point(407, 235)
        Me.lblVolumeValue.Name = "lblVolumeValue"
        Me.lblVolumeValue.Size = New System.Drawing.Size(22, 13)
        Me.lblVolumeValue.TabIndex = 73
        Me.lblVolumeValue.Text = "xxx"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label6.Location = New System.Drawing.Point(203, 233)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(73, 15)
        Me.Label6.TabIndex = 72
        Me.Label6.Text = "Main Volume:"
        '
        'trkbVolume
        '
        Me.trkbVolume.AutoSize = False
        Me.trkbVolume.BackColor = System.Drawing.Color.AliceBlue
        Me.trkbVolume.LargeChange = 4
        Me.trkbVolume.Location = New System.Drawing.Point(281, 229)
        Me.trkbVolume.Maximum = 127
        Me.trkbVolume.Name = "trkbVolume"
        Me.trkbVolume.Size = New System.Drawing.Size(115, 21)
        Me.trkbVolume.TabIndex = 90
        Me.trkbVolume.TickFrequency = 16
        Me.trkbVolume.Value = 100
        '
        'cmbVoiceName
        '
        Me.cmbVoiceName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbVoiceName.FormattingEnabled = True
        Me.cmbVoiceName.Location = New System.Drawing.Point(190, 14)
        Me.cmbVoiceName.Name = "cmbVoiceName"
        Me.cmbVoiceName.Size = New System.Drawing.Size(190, 21)
        Me.cmbVoiceName.TabIndex = 40
        '
        'btnGmON
        '
        Me.btnGmON.Location = New System.Drawing.Point(44, 266)
        Me.btnGmON.Name = "btnGmON"
        Me.btnGmON.Size = New System.Drawing.Size(75, 23)
        Me.btnGmON.TabIndex = 100
        Me.btnGmON.Text = "GM On"
        Me.btnGmON.UseVisualStyleBackColor = True
        '
        'btn_ID_Request
        '
        Me.btn_ID_Request.Location = New System.Drawing.Point(44, 230)
        Me.btn_ID_Request.Name = "btn_ID_Request"
        Me.btn_ID_Request.Size = New System.Drawing.Size(122, 23)
        Me.btn_ID_Request.TabIndex = 80
        Me.btn_ID_Request.Text = "ID Request"
        Me.btn_ID_Request.UseVisualStyleBackColor = True
        '
        'btnDrumNote
        '
        Me.btnDrumNote.Location = New System.Drawing.Point(29, 14)
        Me.btnDrumNote.Name = "btnDrumNote"
        Me.btnDrumNote.Size = New System.Drawing.Size(122, 23)
        Me.btnDrumNote.TabIndex = 60
        Me.btnDrumNote.Text = "Drum Note"
        Me.btnDrumNote.UseVisualStyleBackColor = True
        '
        'btnNote
        '
        Me.btnNote.Location = New System.Drawing.Point(29, 14)
        Me.btnNote.Name = "btnNote"
        Me.btnNote.Size = New System.Drawing.Size(122, 23)
        Me.btnNote.TabIndex = 30
        Me.btnNote.Text = "Voice Note"
        Me.btnNote.UseVisualStyleBackColor = True
        '
        'tbMessage
        '
        Me.tbMessage.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.tbMessage.ContextMenuStrip = Me.ContextMenuStripTbMsg
        Me.tbMessage.Location = New System.Drawing.Point(479, 371)
        Me.tbMessage.Multiline = True
        Me.tbMessage.Name = "tbMessage"
        Me.tbMessage.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.tbMessage.Size = New System.Drawing.Size(250, 99)
        Me.tbMessage.TabIndex = 220
        '
        'ContextMenuStripTbMsg
        '
        Me.ContextMenuStripTbMsg.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ctxMenuTbMsg_clear})
        Me.ContextMenuStripTbMsg.Name = "ContextMenuStripTbMsg"
        Me.ContextMenuStripTbMsg.Size = New System.Drawing.Size(100, 26)
        '
        'ctxMenuTbMsg_clear
        '
        Me.ctxMenuTbMsg_clear.Name = "ctxMenuTbMsg_clear"
        Me.ctxMenuTbMsg_clear.Size = New System.Drawing.Size(99, 22)
        Me.ctxMenuTbMsg_clear.Text = "clear"
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(482, 304)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(181, 13)
        Me.Label3.TabIndex = 84
        Me.Label3.Text = "Input Port 2:  -->  send to Output Port"
        '
        'cmbMidiInPorts2
        '
        Me.cmbMidiInPorts2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmbMidiInPorts2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMidiInPorts2.FormattingEnabled = True
        Me.cmbMidiInPorts2.Location = New System.Drawing.Point(479, 319)
        Me.cmbMidiInPorts2.Name = "cmbMidiInPorts2"
        Me.cmbMidiInPorts2.Size = New System.Drawing.Size(250, 21)
        Me.cmbMidiInPorts2.TabIndex = 190
        '
        'tbInput
        '
        Me.tbInput.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbInput.ContextMenuStrip = Me.ContextMenuStripTbIn
        Me.tbInput.Location = New System.Drawing.Point(479, 106)
        Me.tbInput.Multiline = True
        Me.tbInput.Name = "tbInput"
        Me.tbInput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.tbInput.Size = New System.Drawing.Size(336, 182)
        Me.tbInput.TabIndex = 180
        '
        'ContextMenuStripTbIn
        '
        Me.ContextMenuStripTbIn.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ctxMenuTbIn_clear})
        Me.ContextMenuStripTbIn.Name = "ContextMenuStripTbIn"
        Me.ContextMenuStripTbIn.Size = New System.Drawing.Size(100, 26)
        '
        'ctxMenuTbIn_clear
        '
        Me.ctxMenuTbIn_clear.Name = "ctxMenuTbIn_clear"
        Me.ctxMenuTbIn_clear.Size = New System.Drawing.Size(99, 22)
        Me.ctxMenuTbIn_clear.Text = "clear"
        '
        'btnCloseOutput
        '
        Me.btnCloseOutput.Location = New System.Drawing.Point(327, 25)
        Me.btnCloseOutput.Name = "btnCloseOutput"
        Me.btnCloseOutput.Size = New System.Drawing.Size(43, 23)
        Me.btnCloseOutput.TabIndex = 20
        Me.btnCloseOutput.Text = "close"
        Me.btnCloseOutput.UseVisualStyleBackColor = True
        '
        'btnCloseInput
        '
        Me.btnCloseInput.Location = New System.Drawing.Point(772, 23)
        Me.btnCloseInput.Name = "btnCloseInput"
        Me.btnCloseInput.Size = New System.Drawing.Size(43, 23)
        Me.btnCloseInput.TabIndex = 170
        Me.btnCloseInput.Text = "close"
        Me.btnCloseInput.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(47, 347)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(42, 13)
        Me.Label7.TabIndex = 88
        Me.Label7.Text = "Output:"
        '
        'Label8
        '
        Me.Label8.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(482, 356)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(53, 13)
        Me.Label8.TabIndex = 89
        Me.Label8.Text = "Message:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(482, 91)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(34, 13)
        Me.Label9.TabIndex = 90
        Me.Label9.Text = "Input:"
        '
        'tbSysxInput
        '
        Me.tbSysxInput.Location = New System.Drawing.Point(44, 319)
        Me.tbSysxInput.MaxLength = 256
        Me.tbSysxInput.Name = "tbSysxInput"
        Me.tbSysxInput.Size = New System.Drawing.Size(272, 20)
        Me.tbSysxInput.TabIndex = 130
        '
        'btnSendSysx
        '
        Me.btnSendSysx.Enabled = False
        Me.btnSendSysx.Location = New System.Drawing.Point(333, 317)
        Me.btnSendSysx.Name = "btnSendSysx"
        Me.btnSendSysx.Size = New System.Drawing.Size(75, 23)
        Me.btnSendSysx.TabIndex = 140
        Me.btnSendSysx.Text = "sendSysx"
        Me.btnSendSysx.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(48, 304)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(135, 13)
        Me.Label10.TabIndex = 93
        Me.Label10.Text = "user sysx: F0 xx xx xx xx F7"
        '
        'btnCloseInput2
        '
        Me.btnCloseInput2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnCloseInput2.Location = New System.Drawing.Point(772, 319)
        Me.btnCloseInput2.Name = "btnCloseInput2"
        Me.btnCloseInput2.Size = New System.Drawing.Size(43, 23)
        Me.btnCloseInput2.TabIndex = 200
        Me.btnCloseInput2.Text = "close"
        Me.btnCloseInput2.UseVisualStyleBackColor = True
        '
        'btnPlayOnKeyboard
        '
        Me.btnPlayOnKeyboard.Location = New System.Drawing.Point(29, 48)
        Me.btnPlayOnKeyboard.Name = "btnPlayOnKeyboard"
        Me.btnPlayOnKeyboard.Size = New System.Drawing.Size(122, 23)
        Me.btnPlayOnKeyboard.TabIndex = 45
        Me.btnPlayOnKeyboard.Text = "Notes on Keyboard"
        Me.btnPlayOnKeyboard.UseVisualStyleBackColor = True
        '
        'btnDrumOnKeyboard
        '
        Me.btnDrumOnKeyboard.Location = New System.Drawing.Point(29, 48)
        Me.btnDrumOnKeyboard.Name = "btnDrumOnKeyboard"
        Me.btnDrumOnKeyboard.Size = New System.Drawing.Size(122, 23)
        Me.btnDrumOnKeyboard.TabIndex = 70
        Me.btnDrumOnKeyboard.Text = "Drum on Keyboard"
        Me.btnDrumOnKeyboard.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(223, Byte), Integer))
        Me.GroupBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.GroupBox1.Controls.Add(Me.lblHelp_VoiceSelect)
        Me.GroupBox1.Controls.Add(Me.lblHelp_NoteTrackbar)
        Me.GroupBox1.Controls.Add(Me.lblVoiceNumberValue)
        Me.GroupBox1.Controls.Add(Me.btnNote)
        Me.GroupBox1.Controls.Add(Me.lblHelp_VoiceNote)
        Me.GroupBox1.Controls.Add(Me.btnPlayOnKeyboard)
        Me.GroupBox1.Controls.Add(Me.lblHelp_NotesOnKeyboard)
        Me.GroupBox1.Controls.Add(Me.cmbVoiceName)
        Me.GroupBox1.Controls.Add(Me.trkbVoiceNote)
        Me.GroupBox1.Controls.Add(Me.lblVoiceNoteValue)
        Me.GroupBox1.Location = New System.Drawing.Point(15, 58)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(420, 80)
        Me.GroupBox1.TabIndex = 29
        Me.GroupBox1.TabStop = False
        '
        'lblVoiceNumberValue
        '
        Me.lblVoiceNumberValue.AutoSize = True
        Me.lblVoiceNumberValue.Location = New System.Drawing.Point(392, 19)
        Me.lblVoiceNumberValue.Name = "lblVoiceNumberValue"
        Me.lblVoiceNumberValue.Size = New System.Drawing.Size(22, 13)
        Me.lblVoiceNumberValue.TabIndex = 212
        Me.lblVoiceNumberValue.Text = "xxx"
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(223, Byte), Integer), CType(CType(223, Byte), Integer))
        Me.GroupBox2.Controls.Add(Me.lblDrumNoteName)
        Me.GroupBox2.Controls.Add(Me.btnDrumNote)
        Me.GroupBox2.Controls.Add(Me.btnDrumOnKeyboard)
        Me.GroupBox2.Controls.Add(Me.trkbDrumNote)
        Me.GroupBox2.Controls.Add(Me.lblDrumNoteValue)
        Me.GroupBox2.Controls.Add(Me.lblHelp_DrumTrackbar)
        Me.GroupBox2.Controls.Add(Me.lblHelp_DrumOnKeyboard)
        Me.GroupBox2.Controls.Add(Me.lblHelp_DrumNote)
        Me.GroupBox2.Location = New System.Drawing.Point(15, 142)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(420, 80)
        Me.GroupBox2.TabIndex = 59
        Me.GroupBox2.TabStop = False
        '
        'lblDrumNoteName
        '
        Me.lblDrumNoteName.AutoSize = True
        Me.lblDrumNoteName.Location = New System.Drawing.Point(229, 19)
        Me.lblDrumNoteName.Name = "lblDrumNoteName"
        Me.lblDrumNoteName.Size = New System.Drawing.Size(25, 13)
        Me.lblDrumNoteName.TabIndex = 214
        Me.lblDrumNoteName.Text = "nnn"
        '
        'btnRefreshPortList
        '
        Me.btnRefreshPortList.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnRefreshPortList.Location = New System.Drawing.Point(765, 371)
        Me.btnRefreshPortList.Name = "btnRefreshPortList"
        Me.btnRefreshPortList.Size = New System.Drawing.Size(64, 38)
        Me.btnRefreshPortList.TabIndex = 210
        Me.btnRefreshPortList.Text = "Refresh" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & " Port List" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.btnRefreshPortList.UseVisualStyleBackColor = True
        '
        'lblAuxScroll
        '
        Me.lblAuxScroll.AutoSize = True
        Me.lblAuxScroll.Location = New System.Drawing.Point(12, 470)
        Me.lblAuxScroll.Name = "lblAuxScroll"
        Me.lblAuxScroll.Size = New System.Drawing.Size(16, 13)
        Me.lblAuxScroll.TabIndex = 213
        Me.lblAuxScroll.Text = "   "
        '
        'cbFilterTimingClock
        '
        Me.cbFilterTimingClock.AutoSize = True
        Me.cbFilterTimingClock.Checked = True
        Me.cbFilterTimingClock.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbFilterTimingClock.Location = New System.Drawing.Point(500, 63)
        Me.cbFilterTimingClock.Name = "cbFilterTimingClock"
        Me.cbFilterTimingClock.Size = New System.Drawing.Size(107, 17)
        Me.cbFilterTimingClock.TabIndex = 175
        Me.cbFilterTimingClock.Text = "Filter timing-clock"
        Me.cbFilterTimingClock.UseVisualStyleBackColor = True
        '
        'cbFilterActiveSensing
        '
        Me.cbFilterActiveSensing.AutoSize = True
        Me.cbFilterActiveSensing.Checked = True
        Me.cbFilterActiveSensing.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbFilterActiveSensing.Location = New System.Drawing.Point(629, 63)
        Me.cbFilterActiveSensing.Name = "cbFilterActiveSensing"
        Me.cbFilterActiveSensing.Size = New System.Drawing.Size(119, 17)
        Me.cbFilterActiveSensing.TabIndex = 176
        Me.cbFilterActiveSensing.Text = "Filter active sensing"
        Me.cbFilterActiveSensing.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.Label4.Location = New System.Drawing.Point(767, 424)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(56, 13)
        Me.Label4.TabIndex = 233
        Me.Label4.Text = "Info About"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(841, 492)
        Me.Controls.Add(Me.lblHelp_InfoAbout)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.lblHelp_RefreshportList)
        Me.Controls.Add(Me.lblHelp_BulkDumpRequest)
        Me.Controls.Add(Me.cbShowTooltipHelp)
        Me.Controls.Add(Me.lblHelp_MainVolume)
        Me.Controls.Add(Me.lblHelp_FilterInputMsg)
        Me.Controls.Add(Me.cbFilterActiveSensing)
        Me.Controls.Add(Me.cbFilterTimingClock)
        Me.Controls.Add(Me.lblAuxScroll)
        Me.Controls.Add(Me.btnRefreshPortList)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnCloseInput2)
        Me.Controls.Add(Me.lblVolumeValue)
        Me.Controls.Add(Me.lblHelp_InputPort2)
        Me.Controls.Add(Me.lblHelp_MessageTextbox)
        Me.Controls.Add(Me.lblHelp_InputTextbox)
        Me.Controls.Add(Me.lblHelp_OutputTextBox)
        Me.Controls.Add(Me.lblHelp_SysxInput)
        Me.Controls.Add(Me.lblHelp_GmOn)
        Me.Controls.Add(Me.lblHelp_IdRequest)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.btnSendSysx)
        Me.Controls.Add(Me.tbSysxInput)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.btnCloseInput)
        Me.Controls.Add(Me.btnCloseOutput)
        Me.Controls.Add(Me.tbMessage)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cmbMidiInPorts2)
        Me.Controls.Add(Me.tbInput)
        Me.Controls.Add(Me.tbOutput)
        Me.Controls.Add(Me.btnEsBulkReqDrum)
        Me.Controls.Add(Me.btnEsBulkReqVc0)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.trkbVolume)
        Me.Controls.Add(Me.btnGmON)
        Me.Controls.Add(Me.btn_ID_Request)
        Me.Controls.Add(Me.lblHelp_InputPort)
        Me.Controls.Add(Me.lblHelp_OutputPort)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmbMidiInPorts)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cmbMidiOutPorts)
        Me.HelpButton = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form1"
        Me.Text = "Test Midi_IO      V 1.0.2"
        Me.ContextMenuStripTbOut.ResumeLayout(False)
        CType(Me.trkbVoiceNote, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.trkbDrumNote, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.trkbVolume, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStripTbMsg.ResumeLayout(False)
        Me.ContextMenuStripTbIn.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents lblHelp_InputPort As Label
    Friend WithEvents lblHelp_OutputPort As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents cmbMidiInPorts As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents cmbMidiOutPorts As ComboBox
    Friend WithEvents tbOutput As TextBox
    Friend WithEvents lblHelp_VoiceNote As Label
    Friend WithEvents btnEsBulkReqDrum As Button
    Friend WithEvents btnEsBulkReqVc0 As Button
    Friend WithEvents lblVoiceNoteValue As Label
    Friend WithEvents trkbVoiceNote As TrackBar
    Friend WithEvents lblDrumNoteValue As Label
    Friend WithEvents trkbDrumNote As TrackBar
    Friend WithEvents lblVolumeValue As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents trkbVolume As TrackBar
    Friend WithEvents cmbVoiceName As ComboBox
    Friend WithEvents btnGmON As Button
    Friend WithEvents btn_ID_Request As Button
    Friend WithEvents btnDrumNote As Button
    Friend WithEvents btnNote As Button
    Friend WithEvents tbMessage As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents cmbMidiInPorts2 As ComboBox
    Friend WithEvents tbInput As TextBox
    Friend WithEvents ContextMenuStripTbOut As ContextMenuStrip
    Friend WithEvents ctxMenuTbOut_clear As ToolStripMenuItem
    Friend WithEvents ContextMenuStripTbIn As ContextMenuStrip
    Friend WithEvents ctxMenuTbIn_clear As ToolStripMenuItem
    Friend WithEvents ContextMenuStripTbMsg As ContextMenuStrip
    Friend WithEvents ctxMenuTbMsg_clear As ToolStripMenuItem
    Friend WithEvents btnCloseOutput As Button
    Friend WithEvents btnCloseInput As Button
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents tbSysxInput As TextBox
    Friend WithEvents btnSendSysx As Button
    Friend WithEvents Label10 As Label
    Friend WithEvents lblHelp_DrumNote As Label
    Friend WithEvents lblHelp_IdRequest As Label
    Friend WithEvents lblHelp_GmOn As Label
    Friend WithEvents lblHelp_SysxInput As Label
    Friend WithEvents lblHelp_OutputTextBox As Label
    Friend WithEvents lblHelp_InputTextbox As Label
    Friend WithEvents lblHelp_MessageTextbox As Label
    Friend WithEvents lblHelp_InputPort2 As Label
    Friend WithEvents btnCloseInput2 As Button
    Friend WithEvents btnPlayOnKeyboard As Button
    Friend WithEvents btnDrumOnKeyboard As Button
    Friend WithEvents lblHelp_NotesOnKeyboard As Label
    Friend WithEvents lblHelp_DrumOnKeyboard As Label
    Friend WithEvents lblHelp_DrumTrackbar As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents btnRefreshPortList As Button
    Friend WithEvents lblAuxScroll As Label
    Friend WithEvents cbFilterTimingClock As CheckBox
    Friend WithEvents cbFilterActiveSensing As CheckBox
    Friend WithEvents lblVoiceNumberValue As Label
    Friend WithEvents lblHelp_FilterInputMsg As Label
    Friend WithEvents lblHelp_VoiceSelect As Label
    Friend WithEvents lblHelp_NoteTrackbar As Label
    Friend WithEvents lblHelp_MainVolume As Label
    Friend WithEvents cbShowTooltipHelp As CheckBox
    Friend WithEvents lblHelp_BulkDumpRequest As Label
    Friend WithEvents lblHelp_RefreshportList As Label
    Friend WithEvents lblDrumNoteName As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents lblHelp_InfoAbout As Label
End Class
