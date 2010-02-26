Imports System.Text.RegularExpressions
Imports System.io

Public Class CapitalMonitor

    Private DocText As String
    Private Sub NavigateTo(ByVal address As String)
        Try
            wbrs.Navigate(address)
            Do
                System.Threading.Thread.Sleep(500)
                lblState.Text = wbrs.ReadyState.ToString
                Application.DoEvents()
            Loop Until wbrs.ReadyState = WebBrowserReadyState.Complete 'Not wbrs.IsBusy
            lblState.Text = wbrs.ReadyState.ToString
            DocText = wbrs.DocumentText
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btnStart_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStart.Click
        'Timer1.Interval = CInt(txtInterval.Text) * 1000
        'Timer1.Enabled = Not Timer1.Enabled
        SearchText(DocText)
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        SearchText(NavigateHoldingHeaders("http://www.capital.gr/xa/quotes_table.asp?sector=8300", False))
    End Sub

    Private Sub SearchText(ByVal input As String)
        Dim mtcs As MatchCollection

        mtcs = Regex.Matches(input, "ÅÕÑÏÂ") '"Remaining:.+[0-9,]+</td>")
    End Sub

    Private Function NavigateHoldingHeaders(ByVal url As String, ByVal holdText As Boolean) As String
        Dim request As System.Net.HttpWebRequest
        Dim response As System.Net.HttpWebResponse
        Dim ret As String
        lblState.Text = "Loading..."
        lblState.Refresh()
        request = System.Net.HttpWebRequest.Create(url)
        request.Headers.Add(Net.HttpRequestHeader.Cookie, wbrs.Document.Cookie)
        response = request.GetResponse()
        Dim reader As StreamReader = New StreamReader(response.GetResponseStream())
        ret = reader.ReadToEnd
        If holdText Then
            DocText = ret
            'stamina = CheckStamina(ret)
        Else
            'stamina = CheckStamina(ret)
        End If
        lblState.Text = "Completed"
        response.Close()
        reader.Close()
        Return ret
    End Function

    Private Sub CapitalMonitor_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        NavigateTo("http://www.capital.gr/xa/quotes_table.asp?sector=8300")
    End Sub
End Class