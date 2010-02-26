<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Main
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
        Me.btnMax = New System.Windows.Forms.Button
        Me.btnFallen = New System.Windows.Forms.Button
        Me.btnMerlin = New System.Windows.Forms.Button
        Me.btnCapital = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'btnMax
        '
        Me.btnMax.Location = New System.Drawing.Point(55, 24)
        Me.btnMax.Name = "btnMax"
        Me.btnMax.Size = New System.Drawing.Size(172, 36)
        Me.btnMax.TabIndex = 0
        Me.btnMax.Text = "Max"
        Me.btnMax.UseVisualStyleBackColor = True
        '
        'btnFallen
        '
        Me.btnFallen.Location = New System.Drawing.Point(55, 81)
        Me.btnFallen.Name = "btnFallen"
        Me.btnFallen.Size = New System.Drawing.Size(172, 36)
        Me.btnFallen.TabIndex = 1
        Me.btnFallen.Text = "Fallen"
        Me.btnFallen.UseVisualStyleBackColor = True
        '
        'btnMerlin
        '
        Me.btnMerlin.Location = New System.Drawing.Point(55, 138)
        Me.btnMerlin.Name = "btnMerlin"
        Me.btnMerlin.Size = New System.Drawing.Size(172, 36)
        Me.btnMerlin.TabIndex = 2
        Me.btnMerlin.Text = "Merlin"
        Me.btnMerlin.UseVisualStyleBackColor = True
        '
        'btnCapital
        '
        Me.btnCapital.Location = New System.Drawing.Point(55, 195)
        Me.btnCapital.Name = "btnCapital"
        Me.btnCapital.Size = New System.Drawing.Size(172, 36)
        Me.btnCapital.TabIndex = 3
        Me.btnCapital.Text = "Capital"
        Me.btnCapital.UseVisualStyleBackColor = True
        '
        'Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(292, 273)
        Me.Controls.Add(Me.btnCapital)
        Me.Controls.Add(Me.btnMerlin)
        Me.Controls.Add(Me.btnFallen)
        Me.Controls.Add(Me.btnMax)
        Me.Name = "Main"
        Me.Text = "Main"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnMax As System.Windows.Forms.Button
    Friend WithEvents btnFallen As System.Windows.Forms.Button
    Friend WithEvents btnMerlin As System.Windows.Forms.Button
    Friend WithEvents btnCapital As System.Windows.Forms.Button
End Class
