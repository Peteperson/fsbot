Imports System.Text.RegularExpressions
Public Class MaxBot

    Private Sub btnGo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGo.Click

        Try
            wbrs.Navigate(txtLink.Text)
            SplitContainer1.Panel1.Enabled = False
            btnStop.Enabled = True
            Do
                System.Threading.Thread.Sleep(500)
                lblState.Text = wbrs.ReadyState.ToString
                Application.DoEvents()
            Loop Until wbrs.ReadyState = WebBrowserReadyState.Complete 'Not wbrs.IsBusy
            lblState.Text = wbrs.ReadyState.ToString
            SplitContainer1.Panel1.Enabled = True
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btnGetPage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetPage.Click
        Dim str As String = ""
        'Dim sr As System.IO.StreamReader
        'Dim req As System.Net.HttpWebRequest
        'Dim rsp As System.Net.HttpWebResponse

        btnGo_Click(Nothing, Nothing)
        Try
            'txtLink.Text = wbrs.Document.DomDocument.documentElement.document.frames(0).src
            If cbExpression.Checked Then
                'Try
                '    'str = wbrs.DocumentText
                '    req = System.Net.WebRequest.Create(txtLink.Text)
                '    rsp = req.GetResponse()
                '    sr = New System.IO.StreamReader(rsp.GetResponseStream())
                '    Do While sr.Peek() >= 0
                '        str &= sr.ReadLine()
                '    Loop
                '    sr.Close()
                'Catch ex As Exception
                '    MessageBox.Show("1: " & ex.Message & vbCrLf & ex.StackTrace)
                'End Try
                str = wbrs.DocumentText

                If Regex.IsMatch(str, txtExpression.Text, RegexOptions.IgnoreCase) Then
                    'System.Media.SystemSounds.Exclamation.Play()
                    If cbSoundPath.Checked Then
                        Try
                            Dim snd As New System.Media.SoundPlayer(My.Resources.Windows_XP_Error)
                            snd.Play()
                        Catch ex As Exception
                        End Try
                        Process.Start(txtSoundPath.Text)
                    End If
                    If cbMailTo.Checked Then
                        Dim mail As New System.Net.Mail.SmtpClient(txtSMTP.Text)
                        Try
                            mail.Send("gladsto1@otenet.gr", "gladsto1@otenet.gr", "ogame", "Heeeeeeeeeeeeelp !!!")
                        Catch ex As Exception
                            MessageBox.Show("3: " & ex.Message & vbCrLf & ex.StackTrace)
                        End Try
                    End If
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("4: " & ex.Message & vbCrLf & ex.StackTrace)
        End Try
    End Sub

    Private Sub Timer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer.Tick
        interval -= 1
        lblCountDown.Text = interval
        If interval = 0 Then
            btnGetPage_Click(Nothing, Nothing)
            interval = GetInteger(txtTimer) + rnd.Next(-5, 5)
        End If
    End Sub

    Private interval As Integer
    Private rnd As New Random()
    Private Sub btnTimer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTimer.Click
        Timer.Enabled = Not Timer.Enabled
        interval = GetInteger(txtTimer)
        lblCountDown.Text = interval
        If Timer.Enabled Then
            btnTimer.Text = "Stop"
        Else
            btnTimer.Text = "Start"
        End If
    End Sub

    Private Function GetInteger(ByVal ctrl As System.Windows.Forms.TextBox) As Integer
        If IsNumeric(ctrl.Text) Then
            Return Integer.Parse(ctrl.Text)
        Else
            Return 1
        End If
    End Function

    Private Sub wbrs_Navigating(ByVal sender As System.Object, ByVal e As System.Windows.Forms.WebBrowserNavigatingEventArgs) Handles wbrs.Navigating
        'MessageBox.Show("wbrs_Navigating")
    End Sub

    Private Sub wbrs_DocumentCompleted(ByVal sender As System.Object, ByVal e As System.Windows.Forms.WebBrowserDocumentCompletedEventArgs) Handles wbrs.DocumentCompleted
        'MessageBox.Show("wbrs_DocumentCompleted")
    End Sub

    Private Sub btnStop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStop.Click
        wbrs.Stop()
    End Sub

    Private Sub txtTimer_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTimer.Leave
        Try
            If Integer.Parse(txtTimer.Text) < 10 Then txtTimer.Text = 10
        Catch ex As Exception
            txtTimer.Text = 10
        End Try
    End Sub

    Private Sub cbMailTo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbMailTo.CheckedChanged
        txtSMTP.Enabled = cbMailTo.Checked
        If cbMailTo.Checked Then txtSMTP.Focus()
    End Sub

    Private Sub txtSMTP_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSMTP.Leave
        If txtSMTP.Text = "" Then
            MessageBox.Show("You must specify the SMTP server")
            cbMailTo.Checked = False
        End If
    End Sub
End Class
