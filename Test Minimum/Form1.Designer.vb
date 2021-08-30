<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.cmbMidiOutPorts = New System.Windows.Forms.ComboBox()
        Me.btnNote = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'cmbMidiOutPorts
        '
        Me.cmbMidiOutPorts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMidiOutPorts.FormattingEnabled = True
        Me.cmbMidiOutPorts.Location = New System.Drawing.Point(52, 53)
        Me.cmbMidiOutPorts.Name = "cmbMidiOutPorts"
        Me.cmbMidiOutPorts.Size = New System.Drawing.Size(250, 21)
        Me.cmbMidiOutPorts.TabIndex = 0
        '
        'btnNote
        '
        Me.btnNote.Location = New System.Drawing.Point(52, 117)
        Me.btnNote.Name = "btnNote"
        Me.btnNote.Size = New System.Drawing.Size(102, 23)
        Me.btnNote.TabIndex = 1
        Me.btnNote.Text = "Play Note"
        Me.btnNote.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(55, 38)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Output Port:"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(354, 191)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnNote)
        Me.Controls.Add(Me.cmbMidiOutPorts)
        Me.Name = "Form1"
        Me.Text = "Test Minimum Midi_IO"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cmbMidiOutPorts As ComboBox
    Friend WithEvents btnNote As Button
    Friend WithEvents Label1 As Label
End Class
