<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FallenSword
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
        Me.btnGo = New System.Windows.Forms.Button
        Me.lblState = New System.Windows.Forms.Label
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.btnAttack = New System.Windows.Forms.Button
        Me.btnMove = New System.Windows.Forms.Button
        Me.btnTimer = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.lbPos = New System.Windows.Forms.ListBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.lbLostExp = New System.Windows.Forms.ListBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.lbEnemies = New System.Windows.Forms.ListBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.lblProgress = New System.Windows.Forms.Label
        Me.ListView1 = New System.Windows.Forms.ListView
        Me.btnSaveBuffs = New System.Windows.Forms.Button
        Me.Label10 = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.txtEnemy = New System.Windows.Forms.TextBox
        Me.btnAddEnemy = New System.Windows.Forms.Button
        Me.btnClrEnemies = New System.Windows.Forms.Button
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.txtPassword = New System.Windows.Forms.TextBox
        Me.txtUsername = New System.Windows.Forms.TextBox
        Me.cbAttack = New System.Windows.Forms.CheckBox
        Me.txtSteps = New System.Windows.Forms.TextBox
        Me.cbNotify = New System.Windows.Forms.CheckBox
        Me.cbBuff = New System.Windows.Forms.CheckBox
        Me.txtStamina = New System.Windows.Forms.TextBox
        Me.cbChamp = New System.Windows.Forms.CheckBox
        Me.cbExp = New System.Windows.Forms.CheckBox
        Me.txtWaitTime = New System.Windows.Forms.TextBox
        Me.txtInterval = New System.Windows.Forms.TextBox
        Me.cbShowResults = New System.Windows.Forms.CheckBox
        Me.SuspendLayout()
        '
        'wbrs
        '
        Me.wbrs.Location = New System.Drawing.Point(0, 113)
        Me.wbrs.MinimumSize = New System.Drawing.Size(20, 20)
        Me.wbrs.Name = "wbrs"
        Me.wbrs.Size = New System.Drawing.Size(836, 472)
        Me.wbrs.TabIndex = 26
        '
        'btnGo
        '
        Me.btnGo.Location = New System.Drawing.Point(61, 18)
        Me.btnGo.Name = "btnGo"
        Me.btnGo.Size = New System.Drawing.Size(77, 34)
        Me.btnGo.TabIndex = 14
        Me.btnGo.Text = "Login"
        Me.btnGo.UseVisualStyleBackColor = True
        '
        'lblState
        '
        Me.lblState.AutoSize = True
        Me.lblState.Location = New System.Drawing.Point(737, 93)
        Me.lblState.Name = "lblState"
        Me.lblState.Size = New System.Drawing.Size(32, 13)
        Me.lblState.TabIndex = 3
        Me.lblState.Text = "State"
        Me.lblState.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Timer1
        '
        Me.Timer1.Interval = 15000
        '
        'btnAttack
        '
        Me.btnAttack.Location = New System.Drawing.Point(202, 33)
        Me.btnAttack.Name = "btnAttack"
        Me.btnAttack.Size = New System.Drawing.Size(62, 21)
        Me.btnAttack.TabIndex = 16
        Me.btnAttack.Text = "Attack"
        Me.btnAttack.UseVisualStyleBackColor = True
        '
        'btnMove
        '
        Me.btnMove.Location = New System.Drawing.Point(202, 12)
        Me.btnMove.Name = "btnMove"
        Me.btnMove.Size = New System.Drawing.Size(62, 21)
        Me.btnMove.TabIndex = 15
        Me.btnMove.Text = "Move"
        Me.btnMove.UseVisualStyleBackColor = True
        '
        'btnTimer
        '
        Me.btnTimer.Location = New System.Drawing.Point(270, 12)
        Me.btnTimer.Name = "btnTimer"
        Me.btnTimer.Size = New System.Drawing.Size(62, 40)
        Me.btnTimer.TabIndex = 17
        Me.btnTimer.Text = "Timer"
        Me.btnTimer.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(853, 95)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(52, 13)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Positions:"
        '
        'lbPos
        '
        Me.lbPos.FormattingEnabled = True
        Me.lbPos.Location = New System.Drawing.Point(843, 113)
        Me.lbPos.Name = "lbPos"
        Me.lbPos.Size = New System.Drawing.Size(87, 225)
        Me.lbPos.TabIndex = 19
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(548, 18)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 13)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "Interval: "
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(644, 18)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(24, 13)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "sec"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(477, 41)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(33, 13)
        Me.Label4.TabIndex = 18
        Me.Label4.Text = "hours"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(381, 41)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(53, 13)
        Me.Label5.TabIndex = 17
        Me.Label5.Text = "Wait for : "
        '
        'lbLostExp
        '
        Me.lbLostExp.FormattingEnabled = True
        Me.lbLostExp.Location = New System.Drawing.Point(843, 369)
        Me.lbLostExp.Name = "lbLostExp"
        Me.lbLostExp.Size = New System.Drawing.Size(87, 134)
        Me.lbLostExp.TabIndex = 20
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(845, 353)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(86, 13)
        Me.Label6.TabIndex = 21
        Me.Label6.Text = "Lost Experience:"
        '
        'lbEnemies
        '
        Me.lbEnemies.FormattingEnabled = True
        Me.lbEnemies.Location = New System.Drawing.Point(842, 542)
        Me.lbEnemies.Name = "lbEnemies"
        Me.lbEnemies.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple
        Me.lbEnemies.Size = New System.Drawing.Size(115, 108)
        Me.lbEnemies.TabIndex = 23
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(477, 18)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(36, 13)
        Me.Label8.TabIndex = 27
        Me.Label8.Text = "= stop"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(381, 18)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(57, 13)
        Me.Label9.TabIndex = 26
        Me.Label9.Text = "Stamina < "
        '
        'lblProgress
        '
        Me.lblProgress.AutoSize = True
        Me.lblProgress.Location = New System.Drawing.Point(548, 62)
        Me.lblProgress.Name = "lblProgress"
        Me.lblProgress.Size = New System.Drawing.Size(51, 13)
        Me.lblProgress.TabIndex = 30
        Me.lblProgress.Text = "Progress:"
        '
        'ListView1
        '
        Me.ListView1.Location = New System.Drawing.Point(0, 591)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(836, 126)
        Me.ListView1.TabIndex = 24
        Me.ListView1.UseCompatibleStateImageBehavior = False
        '
        'btnSaveBuffs
        '
        Me.btnSaveBuffs.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.btnSaveBuffs.Location = New System.Drawing.Point(842, 682)
        Me.btnSaveBuffs.Name = "btnSaveBuffs"
        Me.btnSaveBuffs.Size = New System.Drawing.Size(115, 30)
        Me.btnSaveBuffs.TabIndex = 25
        Me.btnSaveBuffs.Text = "Save Buffs"
        Me.btnSaveBuffs.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(548, 44)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(37, 13)
        Me.Label10.TabIndex = 35
        Me.Label10.Text = "Steps:"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(15, 18)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(40, 33)
        Me.Button1.TabIndex = 13
        Me.Button1.Text = "Go"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'txtEnemy
        '
        Me.txtEnemy.Location = New System.Drawing.Point(842, 656)
        Me.txtEnemy.Name = "txtEnemy"
        Me.txtEnemy.Size = New System.Drawing.Size(66, 20)
        Me.txtEnemy.TabIndex = 22
        '
        'btnAddEnemy
        '
        Me.btnAddEnemy.Location = New System.Drawing.Point(914, 655)
        Me.btnAddEnemy.Name = "btnAddEnemy"
        Me.btnAddEnemy.Size = New System.Drawing.Size(43, 21)
        Me.btnAddEnemy.TabIndex = 23
        Me.btnAddEnemy.Text = "Add"
        Me.btnAddEnemy.UseVisualStyleBackColor = True
        '
        'btnClrEnemies
        '
        Me.btnClrEnemies.Location = New System.Drawing.Point(842, 507)
        Me.btnClrEnemies.Name = "btnClrEnemies"
        Me.btnClrEnemies.Size = New System.Drawing.Size(115, 34)
        Me.btnClrEnemies.TabIndex = 21
        Me.btnClrEnemies.Text = "Enemies (click to clear):"
        Me.btnClrEnemies.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(9, 68)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(58, 13)
        Me.Label7.TabIndex = 43
        Me.Label7.Text = "Username:"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(199, 68)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(56, 13)
        Me.Label11.TabIndex = 44
        Me.Label11.Text = "Password:"
        '
        'txtPassword
        '
        Me.txtPassword.Location = New System.Drawing.Point(258, 65)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Size = New System.Drawing.Size(100, 20)
        Me.txtPassword.TabIndex = 2
        Me.txtPassword.Text = Global.BrowserTest.My.MySettings.Default.Password
        '
        'txtUsername
        '
        Me.txtUsername.Location = New System.Drawing.Point(70, 65)
        Me.txtUsername.Name = "txtUsername"
        Me.txtUsername.Size = New System.Drawing.Size(100, 20)
        Me.txtUsername.TabIndex = 1
        Me.txtUsername.Text = Global.BrowserTest.My.MySettings.Default.UserName
        '
        'cbAttack
        '
        Me.cbAttack.AutoSize = True
        Me.cbAttack.Checked = Global.BrowserTest.My.MySettings.Default.AttackAfterMove
        Me.cbAttack.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbAttack.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.BrowserTest.My.MySettings.Default, "AttackAfterMove", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.cbAttack.Location = New System.Drawing.Point(600, 90)
        Me.cbAttack.Name = "cbAttack"
        Me.cbAttack.Size = New System.Drawing.Size(119, 17)
        Me.cbAttack.TabIndex = 8
        Me.cbAttack.Text = "Attack after move ?"
        Me.cbAttack.UseVisualStyleBackColor = True
        '
        'txtSteps
        '
        Me.txtSteps.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.BrowserTest.My.MySettings.Default, "Steps", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.txtSteps.Location = New System.Drawing.Point(605, 41)
        Me.txtSteps.Name = "txtSteps"
        Me.txtSteps.Size = New System.Drawing.Size(33, 20)
        Me.txtSteps.TabIndex = 12
        Me.txtSteps.Text = Global.BrowserTest.My.MySettings.Default.Steps
        Me.txtSteps.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'cbNotify
        '
        Me.cbNotify.AutoSize = True
        Me.cbNotify.Checked = Global.BrowserTest.My.MySettings.Default.NotifyForChamps
        Me.cbNotify.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.BrowserTest.My.MySettings.Default, "NotifyForChamps", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.cbNotify.Location = New System.Drawing.Point(340, 90)
        Me.cbNotify.Name = "cbNotify"
        Me.cbNotify.Size = New System.Drawing.Size(115, 17)
        Me.cbNotify.TabIndex = 6
        Me.cbNotify.Text = "Notify for Champs?"
        Me.cbNotify.UseVisualStyleBackColor = True
        '
        'cbBuff
        '
        Me.cbBuff.AutoSize = True
        Me.cbBuff.Checked = Global.BrowserTest.My.MySettings.Default.EnableBuffAfterLogin
        Me.cbBuff.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbBuff.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.BrowserTest.My.MySettings.Default, "EnableBuffAfterLogin", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.cbBuff.Location = New System.Drawing.Point(460, 90)
        Me.cbBuff.Name = "cbBuff"
        Me.cbBuff.Size = New System.Drawing.Size(135, 17)
        Me.cbBuff.TabIndex = 7
        Me.cbBuff.Text = "Enable buff after login?"
        Me.cbBuff.UseVisualStyleBackColor = True
        '
        'txtStamina
        '
        Me.txtStamina.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.BrowserTest.My.MySettings.Default, "Stamina", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.txtStamina.Location = New System.Drawing.Point(438, 15)
        Me.txtStamina.Name = "txtStamina"
        Me.txtStamina.Size = New System.Drawing.Size(33, 20)
        Me.txtStamina.TabIndex = 9
        Me.txtStamina.Text = Global.BrowserTest.My.MySettings.Default.Stamina
        Me.txtStamina.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'cbChamp
        '
        Me.cbChamp.AutoSize = True
        Me.cbChamp.Checked = Global.BrowserTest.My.MySettings.Default.AvoidChamps
        Me.cbChamp.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbChamp.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.BrowserTest.My.MySettings.Default, "AvoidChamps", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.cbChamp.Location = New System.Drawing.Point(235, 90)
        Me.cbChamp.Name = "cbChamp"
        Me.cbChamp.Size = New System.Drawing.Size(100, 17)
        Me.cbChamp.TabIndex = 5
        Me.cbChamp.Text = "Avoid Champs?"
        Me.cbChamp.UseVisualStyleBackColor = True
        '
        'cbExp
        '
        Me.cbExp.AutoSize = True
        Me.cbExp.Checked = Global.BrowserTest.My.MySettings.Default.ExperienceCheck
        Me.cbExp.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbExp.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.BrowserTest.My.MySettings.Default, "ExperienceCheck", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.cbExp.Location = New System.Drawing.Point(12, 90)
        Me.cbExp.Name = "cbExp"
        Me.cbExp.Size = New System.Drawing.Size(121, 17)
        Me.cbExp.TabIndex = 3
        Me.cbExp.Text = "Experience check ?"
        Me.cbExp.UseVisualStyleBackColor = True
        '
        'txtWaitTime
        '
        Me.txtWaitTime.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.BrowserTest.My.MySettings.Default, "WaitFor", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.txtWaitTime.Location = New System.Drawing.Point(438, 38)
        Me.txtWaitTime.Name = "txtWaitTime"
        Me.txtWaitTime.Size = New System.Drawing.Size(33, 20)
        Me.txtWaitTime.TabIndex = 11
        Me.txtWaitTime.Text = Global.BrowserTest.My.MySettings.Default.WaitFor
        Me.txtWaitTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtInterval
        '
        Me.txtInterval.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.BrowserTest.My.MySettings.Default, "Interval", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.txtInterval.Location = New System.Drawing.Point(605, 15)
        Me.txtInterval.Name = "txtInterval"
        Me.txtInterval.Size = New System.Drawing.Size(33, 20)
        Me.txtInterval.TabIndex = 10
        Me.txtInterval.Text = Global.BrowserTest.My.MySettings.Default.Interval
        Me.txtInterval.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'cbShowResults
        '
        Me.cbShowResults.AutoSize = True
        Me.cbShowResults.Checked = Global.BrowserTest.My.MySettings.Default.ShowResults
        Me.cbShowResults.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.BrowserTest.My.MySettings.Default, "ShowResults", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.cbShowResults.Location = New System.Drawing.Point(138, 90)
        Me.cbShowResults.Name = "cbShowResults"
        Me.cbShowResults.Size = New System.Drawing.Size(92, 17)
        Me.cbShowResults.TabIndex = 4
        Me.cbShowResults.Text = "Show results?"
        Me.cbShowResults.UseVisualStyleBackColor = True
        '
        'FallenSword
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(963, 717)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtPassword)
        Me.Controls.Add(Me.txtUsername)
        Me.Controls.Add(Me.btnClrEnemies)
        Me.Controls.Add(Me.btnAddEnemy)
        Me.Controls.Add(Me.txtEnemy)
        Me.Controls.Add(Me.cbAttack)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txtSteps)
        Me.Controls.Add(Me.cbNotify)
        Me.Controls.Add(Me.btnSaveBuffs)
        Me.Controls.Add(Me.ListView1)
        Me.Controls.Add(Me.lblProgress)
        Me.Controls.Add(Me.cbBuff)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtStamina)
        Me.Controls.Add(Me.lbEnemies)
        Me.Controls.Add(Me.cbChamp)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.lbLostExp)
        Me.Controls.Add(Me.cbExp)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtWaitTime)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtInterval)
        Me.Controls.Add(Me.cbShowResults)
        Me.Controls.Add(Me.lbPos)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnTimer)
        Me.Controls.Add(Me.btnMove)
        Me.Controls.Add(Me.btnAttack)
        Me.Controls.Add(Me.lblState)
        Me.Controls.Add(Me.btnGo)
        Me.Controls.Add(Me.wbrs)
        Me.Name = "FallenSword"
        Me.Text = "FallenSword"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents wbrs As System.Windows.Forms.WebBrowser
    Friend WithEvents btnGo As System.Windows.Forms.Button
    Friend WithEvents lblState As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents btnAttack As System.Windows.Forms.Button
    Friend WithEvents btnMove As System.Windows.Forms.Button
    Friend WithEvents btnTimer As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lbPos As System.Windows.Forms.ListBox
    Friend WithEvents cbShowResults As System.Windows.Forms.CheckBox
    Friend WithEvents txtInterval As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtWaitTime As System.Windows.Forms.TextBox
    Friend WithEvents cbExp As System.Windows.Forms.CheckBox
    Friend WithEvents lbLostExp As System.Windows.Forms.ListBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cbChamp As System.Windows.Forms.CheckBox
    Friend WithEvents lbEnemies As System.Windows.Forms.ListBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtStamina As System.Windows.Forms.TextBox
    Friend WithEvents cbBuff As System.Windows.Forms.CheckBox
    Friend WithEvents lblProgress As System.Windows.Forms.Label
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents btnSaveBuffs As System.Windows.Forms.Button
    Friend WithEvents cbNotify As System.Windows.Forms.CheckBox
    Friend WithEvents txtSteps As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents cbAttack As System.Windows.Forms.CheckBox
    Friend WithEvents txtEnemy As System.Windows.Forms.TextBox
    Friend WithEvents btnAddEnemy As System.Windows.Forms.Button
    Friend WithEvents btnClrEnemies As System.Windows.Forms.Button
    Friend WithEvents txtUsername As System.Windows.Forms.TextBox
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
End Class
