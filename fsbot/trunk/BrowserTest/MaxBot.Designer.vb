<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MaxBot
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.wbrs = New System.Windows.Forms.WebBrowser
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.cbMailTo = New System.Windows.Forms.CheckBox
        Me.txtSMTP = New System.Windows.Forms.TextBox
        Me.btnStop = New System.Windows.Forms.Button
        Me.lblState = New System.Windows.Forms.Label
        Me.cbExpression = New System.Windows.Forms.CheckBox
        Me.cbSoundPath = New System.Windows.Forms.CheckBox
        Me.txtSoundPath = New System.Windows.Forms.TextBox
        Me.lblCountDown = New System.Windows.Forms.Label
        Me.btnTimer = New System.Windows.Forms.Button
        Me.txtExpression = New System.Windows.Forms.TextBox
        Me.txtTimer = New System.Windows.Forms.TextBox
        Me.lblTimer = New System.Windows.Forms.Label
        Me.lblAddr = New System.Windows.Forms.Label
        Me.txtLink = New System.Windows.Forms.TextBox
        Me.btnGetPage = New System.Windows.Forms.Button
        Me.btnGo = New System.Windows.Forms.Button
        Me.Timer = New System.Windows.Forms.Timer(Me.components)
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SuspendLayout()
        '
        'wbrs
        '
        Me.wbrs.Dock = System.Windows.Forms.DockStyle.Fill
        Me.wbrs.Location = New System.Drawing.Point(0, 0)
        Me.wbrs.MinimumSize = New System.Drawing.Size(20, 20)
        Me.wbrs.Name = "wbrs"
        Me.wbrs.Size = New System.Drawing.Size(734, 404)
        Me.wbrs.TabIndex = 0
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.cbMailTo)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtSMTP)
        Me.SplitContainer1.Panel1.Controls.Add(Me.btnStop)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lblState)
        Me.SplitContainer1.Panel1.Controls.Add(Me.cbExpression)
        Me.SplitContainer1.Panel1.Controls.Add(Me.cbSoundPath)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtSoundPath)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lblCountDown)
        Me.SplitContainer1.Panel1.Controls.Add(Me.btnTimer)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtExpression)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtTimer)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lblTimer)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lblAddr)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtLink)
        Me.SplitContainer1.Panel1.Controls.Add(Me.btnGetPage)
        Me.SplitContainer1.Panel1.Controls.Add(Me.btnGo)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.wbrs)
        Me.SplitContainer1.Size = New System.Drawing.Size(734, 546)
        Me.SplitContainer1.SplitterDistance = 138
        Me.SplitContainer1.TabIndex = 1
        '
        'cbMailTo
        '
        Me.cbMailTo.AutoSize = True
        Me.cbMailTo.Location = New System.Drawing.Point(12, 77)
        Me.cbMailTo.Name = "cbMailTo"
        Me.cbMailTo.Size = New System.Drawing.Size(59, 17)
        Me.cbMailTo.TabIndex = 13
        Me.cbMailTo.Text = "SMTP "
        Me.cbMailTo.UseVisualStyleBackColor = True
        '
        'txtSMTP
        '
        Me.txtSMTP.Enabled = False
        Me.txtSMTP.Location = New System.Drawing.Point(97, 75)
        Me.txtSMTP.Name = "txtSMTP"
        Me.txtSMTP.Size = New System.Drawing.Size(312, 20)
        Me.txtSMTP.TabIndex = 14
        '
        'btnStop
        '
        Me.btnStop.Location = New System.Drawing.Point(595, 15)
        Me.btnStop.Name = "btnStop"
        Me.btnStop.Size = New System.Drawing.Size(44, 22)
        Me.btnStop.TabIndex = 12
        Me.btnStop.Text = "Stop"
        Me.btnStop.UseVisualStyleBackColor = True
        '
        'lblState
        '
        Me.lblState.AutoSize = True
        Me.lblState.Location = New System.Drawing.Point(657, 105)
        Me.lblState.Name = "lblState"
        Me.lblState.Size = New System.Drawing.Size(32, 13)
        Me.lblState.TabIndex = 11
        Me.lblState.Text = "State"
        Me.lblState.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'cbExpression
        '
        Me.cbExpression.AutoSize = True
        Me.cbExpression.Location = New System.Drawing.Point(332, 48)
        Me.cbExpression.Name = "cbExpression"
        Me.cbExpression.Size = New System.Drawing.Size(77, 17)
        Me.cbExpression.TabIndex = 4
        Me.cbExpression.Text = "Expression"
        Me.cbExpression.UseVisualStyleBackColor = True
        '
        'cbSoundPath
        '
        Me.cbSoundPath.AutoSize = True
        Me.cbSoundPath.Location = New System.Drawing.Point(12, 107)
        Me.cbSoundPath.Name = "cbSoundPath"
        Me.cbSoundPath.Size = New System.Drawing.Size(82, 17)
        Me.cbSoundPath.TabIndex = 7
        Me.cbSoundPath.Text = "Sound Path"
        Me.cbSoundPath.UseVisualStyleBackColor = True
        '
        'txtSoundPath
        '
        Me.txtSoundPath.Location = New System.Drawing.Point(97, 105)
        Me.txtSoundPath.Name = "txtSoundPath"
        Me.txtSoundPath.Size = New System.Drawing.Size(443, 20)
        Me.txtSoundPath.TabIndex = 8
        '
        'lblCountDown
        '
        Me.lblCountDown.AutoSize = True
        Me.lblCountDown.Location = New System.Drawing.Point(215, 48)
        Me.lblCountDown.Name = "lblCountDown"
        Me.lblCountDown.Size = New System.Drawing.Size(16, 13)
        Me.lblCountDown.TabIndex = 10
        Me.lblCountDown.Text = "---"
        '
        'btnTimer
        '
        Me.btnTimer.Location = New System.Drawing.Point(157, 46)
        Me.btnTimer.Name = "btnTimer"
        Me.btnTimer.Size = New System.Drawing.Size(44, 22)
        Me.btnTimer.TabIndex = 3
        Me.btnTimer.Text = "Start"
        Me.btnTimer.UseVisualStyleBackColor = True
        '
        'txtExpression
        '
        Me.txtExpression.Location = New System.Drawing.Point(415, 46)
        Me.txtExpression.Name = "txtExpression"
        Me.txtExpression.Size = New System.Drawing.Size(125, 20)
        Me.txtExpression.TabIndex = 5
        '
        'txtTimer
        '
        Me.txtTimer.Location = New System.Drawing.Point(97, 46)
        Me.txtTimer.Name = "txtTimer"
        Me.txtTimer.Size = New System.Drawing.Size(54, 20)
        Me.txtTimer.TabIndex = 2
        '
        'lblTimer
        '
        Me.lblTimer.AutoSize = True
        Me.lblTimer.Location = New System.Drawing.Point(15, 49)
        Me.lblTimer.Name = "lblTimer"
        Me.lblTimer.Size = New System.Drawing.Size(33, 13)
        Me.lblTimer.TabIndex = 5
        Me.lblTimer.Text = "Timer"
        '
        'lblAddr
        '
        Me.lblAddr.AutoSize = True
        Me.lblAddr.Location = New System.Drawing.Point(15, 20)
        Me.lblAddr.Name = "lblAddr"
        Me.lblAddr.Size = New System.Drawing.Size(45, 13)
        Me.lblAddr.TabIndex = 4
        Me.lblAddr.Text = "Address"
        '
        'txtLink
        '
        Me.txtLink.Location = New System.Drawing.Point(97, 16)
        Me.txtLink.Name = "txtLink"
        Me.txtLink.Size = New System.Drawing.Size(443, 20)
        Me.txtLink.TabIndex = 0
        Me.txtLink.Text = "www.ogame.org"
        '
        'btnGetPage
        '
        Me.btnGetPage.Location = New System.Drawing.Point(546, 45)
        Me.btnGetPage.Name = "btnGetPage"
        Me.btnGetPage.Size = New System.Drawing.Size(59, 21)
        Me.btnGetPage.TabIndex = 6
        Me.btnGetPage.Text = "GetPage"
        Me.btnGetPage.UseVisualStyleBackColor = True
        '
        'btnGo
        '
        Me.btnGo.Location = New System.Drawing.Point(546, 15)
        Me.btnGo.Name = "btnGo"
        Me.btnGo.Size = New System.Drawing.Size(44, 22)
        Me.btnGo.TabIndex = 1
        Me.btnGo.Text = "Go"
        Me.btnGo.UseVisualStyleBackColor = True
        '
        'Timer
        '
        Me.Timer.Interval = 1000
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(734, 546)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "Form1"
        Me.Text = "MaxBot"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents wbrs As System.Windows.Forms.WebBrowser
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents btnGo As System.Windows.Forms.Button
    Friend WithEvents btnGetPage As System.Windows.Forms.Button
    Friend WithEvents txtLink As System.Windows.Forms.TextBox
    Friend WithEvents txtExpression As System.Windows.Forms.TextBox
    Friend WithEvents txtTimer As System.Windows.Forms.TextBox
    Friend WithEvents lblTimer As System.Windows.Forms.Label
    Friend WithEvents lblAddr As System.Windows.Forms.Label
    Friend WithEvents btnTimer As System.Windows.Forms.Button
    Friend WithEvents Timer As System.Windows.Forms.Timer
    Friend WithEvents lblCountDown As System.Windows.Forms.Label
    Friend WithEvents txtSoundPath As System.Windows.Forms.TextBox
    Friend WithEvents cbSoundPath As System.Windows.Forms.CheckBox
    Friend WithEvents cbExpression As System.Windows.Forms.CheckBox
    Friend WithEvents lblState As System.Windows.Forms.Label
    Friend WithEvents btnStop As System.Windows.Forms.Button
    Friend WithEvents cbMailTo As System.Windows.Forms.CheckBox
    Friend WithEvents txtSMTP As System.Windows.Forms.TextBox

End Class
