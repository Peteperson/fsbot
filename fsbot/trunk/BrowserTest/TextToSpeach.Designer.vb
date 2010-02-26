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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TextToSpeach))
        Me.wbrs = New System.Windows.Forms.WebBrowser
        Me.txtText = New System.Windows.Forms.TextBox
        Me.txtConversation = New System.Windows.Forms.RichTextBox
        Me.AxAgn = New AxAgentObjects.AxAgent
        Me.btnShowAgn = New System.Windows.Forms.Button
        Me.lblInstr = New System.Windows.Forms.Label
        CType(Me.AxAgn, System.ComponentModel.ISupportInitialize).BeginInit()
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
        'AxAgn
        '
        Me.AxAgn.Enabled = True
        Me.AxAgn.Location = New System.Drawing.Point(411, 13)
        Me.AxAgn.Name = "AxAgn"
        Me.AxAgn.OcxState = CType(resources.GetObject("AxAgn.OcxState"), System.Windows.Forms.AxHost.State)
        Me.AxAgn.Size = New System.Drawing.Size(32, 32)
        Me.AxAgn.TabIndex = 5
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
        'TextToSpeach
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(465, 282)
        Me.Controls.Add(Me.lblInstr)
        Me.Controls.Add(Me.btnShowAgn)
        Me.Controls.Add(Me.AxAgn)
        Me.Controls.Add(Me.txtConversation)
        Me.Controls.Add(Me.txtText)
        Me.Controls.Add(Me.wbrs)
        Me.Name = "TextToSpeach"
        Me.Text = "TextToSpeach"
        CType(Me.AxAgn, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents wbrs As System.Windows.Forms.WebBrowser
    Friend WithEvents txtText As System.Windows.Forms.TextBox
    Friend WithEvents txtConversation As System.Windows.Forms.RichTextBox
    Friend WithEvents AxAgn As AxAgentObjects.AxAgent
    Friend WithEvents btnShowAgn As System.Windows.Forms.Button
    Friend WithEvents lblInstr As System.Windows.Forms.Label
End Class
