Imports System.Text.RegularExpressions
Imports System.Text
Imports System.io

Public Class TextToSpeach
    Private DocText As String
    Private Sub NavigateTo(ByVal address As String)
        Try
            wbrs.Navigate(address)
            Do
                System.Threading.Thread.Sleep(500)
                'lblState.Text = wbrs.ReadyState.ToString
                Application.DoEvents()
            Loop Until wbrs.ReadyState = WebBrowserReadyState.Complete
            'lblState.Text = wbrs.ReadyState.ToString
            DocText = wbrs.DocumentText
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Dim Character As AgentObjects.IAgentCtlCharacter
    Private Sub TextToSpeach_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        NavigateTo("http://www.pandorabots.com/pandora/talk?botid=f5d922d97e345aa1")
        NavigateTo("http://www.pandorabots.com/pandora/talk?botid=f5d922d97e345aa1&skin=custom_input")
    End Sub

    Private Sub NavigateHoldingHeaders(ByVal url As String, ByVal botcust2 As String, ByVal question As String)
        Dim request As System.Net.HttpWebRequest
        Dim response As System.Net.HttpWebResponse
        'lblState.Text = "Loading..."
        'lblState.Refresh()
        request = System.Net.HttpWebRequest.Create(url)
        request.Method = "POST"

        Dim postData As String = "botcust2" & ChrW(61) & botcust2 & "&input" & ChrW(61) & question
        Dim encoding As New ASCIIEncoding()
        Dim byte1 As Byte() = encoding.GetBytes(postData)
        request.ContentType = "application/x-www-form-urlencoded"
        request.ContentLength = byte1.Length
        Dim newStream As Stream = request.GetRequestStream()
        newStream.Write(byte1, 0, byte1.Length)
        'Debug.WriteLine("The value of 'ContentLength' property after sending the data is " & request.ContentLength)
        newStream.Close()

        'request.Headers.Add(Net.HttpRequestHeader.Cookie, wbrs.Document.Cookie)
        response = request.GetResponse()
        Dim reader As StreamReader = New StreamReader(response.GetResponseStream())
        DocText = reader.ReadToEnd
        'lblState.Text = "Completed"
        response.Close()
        reader.Close()
        Dim tmp = GetAnswer()
        Character.Speak(tmp)
        txtConversation.Text += tmp & vbCrLf
    End Sub

    Private Function GetAnswer() As String
        Dim ret As String
        Dim mtcs As MatchCollection
        Dim tmp As String
        tmp = Regex.Replace(DocText, "[^ a-zA-Z0-9:<>\.\!\?\,\'\""]", "")
        mtcs = Regex.Matches(tmp, "ALICE:<em>[ a-zA-Z0-9\.\!\?\,\'\""]+<em>") '[ a-zA-Z0-9\.\!\?\,\'\""]
        ret = mtcs(mtcs.Count - 1).Value
        Return ret.Replace("ALICE:<em>", "").Replace("<em>", "").Replace("ALICE", "Merlin")
    End Function

    Private Function GetBotID() As String
        Dim ret As String
        Dim mtcs As MatchCollection
        mtcs = Regex.Matches(DocText, "name=""botcust2"" value=""[0-9a-zA-Z]+"">")
        ret = mtcs(mtcs.Count - 1).Value
        Return ret.Replace("name=""botcust2"" value=""", "").Replace(""">", "")
    End Function

    Private Sub txtText_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtText.KeyDown
        If e.KeyValue = 13 Then
            txtConversation.Text += txtText.Text & vbCrLf
            Dim s As String = GetBotID()
            NavigateHoldingHeaders("http://www.pandorabots.com/pandora/talk?botid=f5d922d97e345aa1&skin=custom_input", s, txtText.Text.Replace(" ", "+"))
            txtText.SelectAll()
        End If
    End Sub

    Private Sub btnShowAgn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShowAgn.Click
        AxAgn.Characters.Load("CharacterID", "C:\WINDOWS\msagent\chars\merlin.acs")
        Character = AxAgn.Characters("CharacterID")
        Character.LanguageID = &H409
        Character.Show()
        txtText.Enabled = True
        btnShowAgn.Enabled = False
        lblInstr.Visible = True
        Character.Speak("Hallo there !")
    End Sub
End Class