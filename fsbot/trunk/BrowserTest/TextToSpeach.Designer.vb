<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TextToSpeach
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
        Me.wbrs = New System.Windows.Forms.WebBrowser
        Me.txtText = New System.Windows.Forms.TextBox
        Me.txtConversation = New System.Windows.Forms.RichTextBox
        Me.btnShowAgn = New System.Windows.Forms.Button
        Me.lblInstr = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtPrxUsername = New System.Windows.Forms.TextBox
        Me.txtPrxPassword = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'wbrs
        '
        Me.wbrs.Location = New System.Drawing.Point(294, 69)
        Me.wbrs.MinimumSize = New System.Drawing.Size(20, 20)
        Me.wbrs.Name = "wbrs"
        Me.wbrs.Size = New System.Drawing.Size(125, 30)
        Me.wbrs.TabIndex = 0
        Me.wbrs.Visible = False
        '
        'txtText
        '
        Me.txtText.Enabled = False
        Me.txtText.Location = New System.Drawing.Point(57, 44)
        Me.txtText.Name = "txtText"
        Me.txtText.Size = New System.Drawing.Size(345, 20)
        Me.txtText.TabIndex = 3
        '
        'txtConversation
        '
        Me.txtConversation.Location = New System.Drawing.Point(21, 99)
        Me.txtConversation.Name = "txtConversation"
        Me.txtConversation.Size = New System.Drawing.Size(416, 160)
        Me.txtConversation.TabIndex = 4
        Me.txtConversation.Text = ""
        '
        'btnShowAgn
        '
        Me.btnShowAgn.Location = New System.Drawing.Point(156, 69)
        Me.btnShowAgn.Name = "btnShowAgn"
        Me.btnShowAgn.Size = New System.Drawing.Size(64, 23)
        Me.btnShowAgn.TabIndex = 6
        Me.btnShowAgn.Text = "Show"
        Me.btnShowAgn.UseVisualStyleBackColor = True
        '
        'lblInstr
        '
        Me.lblInstr.AutoSize = True
        Me.lblInstr.Location = New System.Drawing.Point(59, 28)
        Me.lblInstr.Name = "lblInstr"
        Me.lblInstr.Size = New System.Drawing.Size(326, 13)
        Me.lblInstr.TabIndex = 7
        Me.lblInstr.Text = "Talk to me by putting text in the textbox below and then press enter:"
        Me.lblInstr.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(21, 263)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(82, 13)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Proxy username"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtPrxUsername
        '
        Me.txtPrxUsername.Location = New System.Drawing.Point(114, 261)
        Me.txtPrxUsername.Name = "txtPrxUsername"
        Me.txtPrxUsername.Size = New System.Drawing.Size(105, 20)
        Me.txtPrxUsername.TabIndex = 9
        Me.txtPrxUsername.Text = "eurobank\pargoudelis"
        '
        'txtPrxPassword
        '
        Me.txtPrxPassword.Location = New System.Drawing.Point(332, 261)
        Me.txtPrxPassword.Name = "txtPrxPassword"
        Me.txtPrxPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPrxPassword.Size = New System.Drawing.Size(105, 20)
        Me.txtPrxPassword.TabIndex = 11
        Me.txtPrxPassword.Text = "Petexp5bul"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(239, 263)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(81, 13)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Proxy password"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TextToSpeach
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(465, 282)
        Me.Controls.Add(Me.txtPrxPassword)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtPrxUsername)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblInstr)
        Me.Controls.Add(Me.btnShowAgn)
        Me.Controls.Add(Me.txtConversation)
        Me.Controls.Add(Me.txtText)
        Me.Controls.Add(Me.wbrs)
        Me.Name = "TextToSpeach"
        Me.Text = "TextToSpeach"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents wbrs As System.Windows.Forms.WebBrowser
    Friend WithEvents txtText As System.Windows.Forms.TextBox
    Friend WithEvents txtConversation As System.Windows.Forms.RichTextBox
    Friend WithEvents btnShowAgn As System.Windows.Forms.Button
    Friend WithEvents lblInstr As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtPrxUsername As System.Windows.Forms.TextBox
    Friend WithEvents txtPrxPassword As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
