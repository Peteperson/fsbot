<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CapitalMonitor
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.wbrs = New System.Windows.Forms.WebBrowser
        Me.btnGoTo = New System.Windows.Forms.Button
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.txtInterval = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.lblState = New System.Windows.Forms.Label
        Me.lblResult = New System.Windows.Forms.Label
        Me.btnStart = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'wbrs
        '
        Me.wbrs.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.wbrs.Location = New System.Drawing.Point(0, 125)
        Me.wbrs.MinimumSize = New System.Drawing.Size(20, 20)
        Me.wbrs.Name = "wbrs"
        Me.wbrs.ScrollBarsEnabled = False
        Me.wbrs.Size = New System.Drawing.Size(477, 272)
        Me.wbrs.TabIndex = 0
        '
        'btnGoTo
        '
        Me.btnGoTo.Location = New System.Drawing.Point(22, 19)
        Me.btnGoTo.Name = "btnGoTo"
        Me.btnGoTo.Size = New System.Drawing.Size(80, 35)
        Me.btnGoTo.TabIndex = 1
        Me.btnGoTo.Text = "Go To"
        Me.btnGoTo.UseVisualStyleBackColor = True
        '
        'Timer1
        '
        '
        'txtInterval
        '
        Me.txtInterval.Location = New System.Drawing.Point(187, 32)
        Me.txtInterval.Name = "txtInterval"
        Me.txtInterval.Size = New System.Drawing.Size(26, 20)
        Me.txtInterval.TabIndex = 2
        Me.txtInterval.Text = "30"
        Me.txtInterval.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(138, 35)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Interval:"
        '
        'lblState
        '
        Me.lblState.AutoSize = True
        Me.lblState.Location = New System.Drawing.Point(398, 109)
        Me.lblState.Name = "lblState"
        Me.lblState.Size = New System.Drawing.Size(32, 13)
        Me.lblState.TabIndex = 4
        Me.lblState.Text = "State"
        '
        'lblResult
        '
        Me.lblResult.AutoSize = True
        Me.lblResult.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.lblResult.Location = New System.Drawing.Point(240, 22)
        Me.lblResult.Name = "lblResult"
        Me.lblResult.Size = New System.Drawing.Size(43, 24)
        Me.lblResult.TabIndex = 5
        Me.lblResult.Text = "Res"
        '
        'btnStart
        '
        Me.btnStart.Location = New System.Drawing.Point(326, 35)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Size = New System.Drawing.Size(51, 23)
        Me.btnStart.TabIndex = 6
        Me.btnStart.Text = "Start"
        Me.btnStart.UseVisualStyleBackColor = True
        '
        'CapitalMonitor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(477, 397)
        Me.Controls.Add(Me.btnStart)
        Me.Controls.Add(Me.lblResult)
        Me.Controls.Add(Me.lblState)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtInterval)
        Me.Controls.Add(Me.btnGoTo)
        Me.Controls.Add(Me.wbrs)
        Me.Name = "CapitalMonitor"
        Me.Text = "CapitalMonitor"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents wbrs As System.Windows.Forms.WebBrowser
    Friend WithEvents btnGoTo As System.Windows.Forms.Button
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents txtInterval As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblState As System.Windows.Forms.Label
    Friend WithEvents lblResult As System.Windows.Forms.Label
    Friend WithEvents btnStart As System.Windows.Forms.Button
End Class
