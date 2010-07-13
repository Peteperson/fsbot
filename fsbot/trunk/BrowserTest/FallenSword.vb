Imports System.Text.RegularExpressions
Imports System.Net
Imports System.IO

Public Class FallenSword
    Private rnd As New Random
    Private alMem As New ArrayList
    Private DocText As String
    Private _Stamina As Integer = -1
    Private _Experience As Integer = -1
    Private InitialStamina, InitialExperience As Integer
    Private PrevExperience As Integer = 0
    Private SumExp As Integer = 0
    Private SumStam As Integer = 0
    Private Progress As Decimal
    Private heads As System.Net.WebHeaderCollection
    Private moves As Int16 = 0

    Private Sub Play()
        _Experience = -1
        _Stamina = -1
        If wbrs.Document Is Nothing Then
            NavigateTo("http://www.fallensword.com/index.php?cmd=login&subcmd=processlogin&passthru_cmd=&passthru_subcmd=&login_username=" & txtUsername.Text & "&login_password=" & txtPassword.Text & "&x=113&y=18")
            If Stamina > CInt(txtStamina.Text) Then
                If cbBuff.Checked Then EnableBuffs()
            End If
        End If
        If cbBuff.Checked Then EnableBuffs()
        NavigateTo("http://www.fallensword.com/index.php?cmd=world")
        alMem.Clear()
        lbLostExp.Items.Clear()
    End Sub

    Private Sub btnGo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGo.Click
        Play()
    End Sub

    Private Sub EnableBuffs()
        Dim item As ListViewItem

        For Each item In ListView1.Items
            If item.Checked Then NavigateHoldingHeaders(item.SubItems(2).Text, False)
        Next
    End Sub

    Private Sub UpdateExp(ByVal searchText As String)
        Dim tmp As String
        Dim mtcs As MatchCollection

        mtcs = Regex.Matches(searchText, "Remaining:.+[0-9,]+</td>")
        If mtcs.Count = 1 Then
            mtcs = Regex.Matches(mtcs(0).Value, ">[0-9,]+<")
            Dim trchars() As Char = {"<", ">"}
            tmp = mtcs(0).Value.Trim(trchars)
            If cbExp.Checked Then
                If Experience <> -1 AndAlso Experience < CInt(tmp.Replace(",", "")) Then
                    lbLostExp.Items.Add(Experience - CInt(tmp.Replace(",", "")))
                    Dim snd As New System.Media.SoundPlayer(My.Resources.Windows_XP_Error)
                    snd.Play()
                End If
            End If
            PrevExperience = Experience
            Experience = CInt(tmp.Replace(",", ""))
            If PrevExperience <> -1 AndAlso Math.Abs(PrevExperience - Experience) > 1000000 Then
                Experience = -1
                Timer1.Enabled = True
                WriteToFile(DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") & ": Changing level ?")
            End If
            Me.Text = "P:" & Progress & " S:" & Stamina & " E:" & tmp
        End If
    End Sub

    Private Function CheckStamina(ByVal searchText As String) As Integer
        Dim tmp As String
        Dim stam As Integer = 100000
        Dim mtcs As MatchCollection

        mtcs = Regex.Matches(searchText, "Stamina:.+[0-9,]+&nbsp;/&nbsp;[0-9,]+")
        If mtcs.Count = 1 Then
            mtcs = Regex.Matches(mtcs(0).Value, "[0-9,]+&nbsp;/&nbsp;[0-9,]+")
        End If
        For i As Int16 = 0 To mtcs.Count - 1
            tmp = mtcs(i).Value.Replace("&nbsp;", "")
            tmp = tmp.Split("/")(0)
            If CInt(tmp) < stam Then stam = CInt(tmp)
        Next

        If stam < 100000 Then
            Return stam
        Else
            Return -1
        End If
    End Function

    Private Property Stamina() As Integer
        Get
            Return _Stamina
        End Get
        Set(ByVal value As Integer)
            If _Stamina = -1 Then
                WriteToFile(DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") & ": Initial stamina= " & value)
                InitialStamina = value
            End If
            _Stamina = value
        End Set
    End Property

    Private Property Experience() As Integer
        Get
            Return _Experience
        End Get
        Set(ByVal value As Integer)
            If _Experience = -1 Then
                WriteToFile(DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") & ": Initial experience= " & value)
                InitialExperience = value
            End If
            _Experience = value
        End Set
    End Property

    Private Sub NavigateTo(ByVal address As String)
        Try
            wbrs.Navigate(address)
            Do
                System.Threading.Thread.Sleep(500)
                lblState.Text = wbrs.ReadyState.ToString
                lblState.BackColor = Color.NavajoWhite
                Application.DoEvents()
            Loop Until wbrs.ReadyState = WebBrowserReadyState.Complete 'Not wbrs.IsBusy
            lblState.BackColor = Color.Empty
            lblState.Text = wbrs.ReadyState.ToString
            DocText = wbrs.Document.Body.InnerHtml.Replace("&amp;", "&")
            Stamina = CheckStamina(DocText)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If Timer1.Interval = CInt(txtWaitTime.Text) * 60 * 60 * 1000 Then
            Timer1.Interval = CInt(txtInterval.Text) * 1000
            SumExp = 0
            SumStam = 0
            btnGo_Click(Nothing, Nothing)
        End If
        MoveCharacter()
    End Sub

    Private Sub Attack()
        Dim mtcs1 As MatchCollection
        Dim mtcs2 As MatchCollection
        DocText = DocText.Replace(Chr(10), "").Replace(Chr(13), "")
        DocText = DocText.Replace("""", "")
        mtcs2 = Regex.Matches(DocText, "cmd=combat&subcmd=[a-zA-Z0-9]+&creature_id=[0-9]+&checksum=[a-zA-Z0-9]+")
        mtcs1 = Regex.Matches(DocText, "Creature[ 0-9a-zA-Z\/\\\:\._\<\>\=%]+align=left>[ a-zA-Z()]+</td>", RegexOptions.IgnoreCase)
        Dim sName As String

        If mtcs1.Count <> mtcs2.Count Then lbLostExp.Items.Add("<error>")

        For i As Int16 = 0 To mtcs2.Count - 1
            Try
                If mtcs1(i) Is Nothing Then
                    sName = "Unknown name"
                Else
                    sName = mtcs1(i).Value.Replace(Chr(34), "")
                    sName = sName.Substring(sName.IndexOf("90% align=left>") + 15).Replace("</td>", "").Replace("</TD>", "")
                End If
                If lbEnemies.FindStringExact(sName) = -1 Then
                    lbEnemies.Items.Add(sName)
                End If

                If Not CheckForChamp(sName, cbChamp.Checked) Then
                    If lbEnemies.SelectedItems.Count = 0 Then
                        WriteStats(sName)
                        UpdateExp(NavigateHoldingHeaders("http://www.fallensword.com/index.php?" & mtcs2(i).Value.Replace(Chr(34), ""), False))
                    Else
                        For j As Int16 = 0 To lbEnemies.SelectedItems.Count - 1
                            If lbEnemies.SelectedItems.Item(j).ToString = sName Then
                                WriteStats(sName)
                                UpdateExp(NavigateHoldingHeaders("http://www.fallensword.com/index.php?" & mtcs2(i).Value.Replace(Chr(34), ""), False))
                                Exit For
                            End If
                        Next
                    End If
                End If
            Catch ex As Exception
                WriteStats("Error: " & ex.Message)
                Exit For
            End Try
        Next
        If (moves Mod CInt(txtSteps.Text)) = 0 Then
            Me.Text = "Repairing..."
            NavigateHoldingHeaders("http://www.fallensword.com/index.php?cmd=blacksmith&subcmd=repairall&fromworld=1", False)
        End If
        If moves >= 240 Then
            Me.Text = "Buffing up..."
            EnableBuffs()
            moves = 0
        End If
    End Sub

    Private Sub btnAttack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAttack.Click
        Attack()
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
            DocText = ret.Replace("&amp;", "&")
            Stamina = CheckStamina(ret)
        Else
            Stamina = CheckStamina(ret)
        End If
        lblState.Text = "Completed"
        response.Close()
        reader.Close()
        Return ret
    End Function

    Private Sub btnMove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMove.Click
        MoveCharacter()
    End Sub

    Private Sub MoveCharacter()
        If Stamina > CInt(txtStamina.Text) Then
            Dim al As New ArrayList
            Dim mtcs As MatchCollection
            Dim s As String = ""
            moves += 1
            DocText = DocText.Replace("""", "")
            mtcs = Regex.Matches(DocText, "cmd=world&subcmd=move&x=[0-9]+&y=[0-9]+><img title=[:\[0-9\)a-z\(A-Z \-]+][a-z=0-9 ]+src=http://72.29.91.222/skin/realm/[A-Z0-9_]+on.gif", RegexOptions.IgnoreCase)
            If mtcs.Count = 0 Then
                mtcs = Regex.Matches(DocText, "cmd=world&subcmd=move&x=[0-9]+&y=[0-9]+><img src=http://72.29.91.222/skin/realm/[A-Z0-9_]+on.gif[a-z=0-9 ]+title=[:\[0-9\)a-z\(A-Z \-]+]", RegexOptions.IgnoreCase)
                If mtcs.Count = 0 Then
                    mtcs = Regex.Matches(DocText, "cmd=world&subcmd=move&x=[0-9]+&y=[0-9]+><img src=http://72.29.91.222/skin/realm/[A-Z0-9_]+on.gif", RegexOptions.IgnoreCase)
                End If
            End If

            For i As Int16 = 0 To mtcs.Count - 1
                s = Regex.Match(mtcs(i).Value, "x=[0-9]+&y=[0-9]+").Value
                If (Not al.Contains(s)) Then al.Add(s)
            Next

            Dim cont As Boolean = True
            While cont And al.Count > 0
                For i As Int16 = 0 To al.Count - 1
                    If alMem.Contains(al(i)) Then
                        If al.Count > 1 Then
                            al.RemoveAt(i)
                            cont = True
                            Exit For
                        Else
                            alMem.Clear()
                            cont = False
                            Exit For
                        End If
                    End If
                    cont = False
                Next
            End While

            Dim pos As Int16
            pos = rnd.Next(0, al.Count)
            s = al(pos)
            If (Not alMem.Contains(s)) Then alMem.Add(s)
            If cbShowResults.Checked Then
                NavigateTo("http://www.fallensword.com/index.php?cmd=world&subcmd=move&" & al(pos))
            Else
                NavigateHoldingHeaders("http://www.fallensword.com/index.php?cmd=world&subcmd=move&" & al(pos), True)
            End If
            ShowPositions()
            UpdateExp(DocText)
            If cbAttack.Checked Then Attack()
        Else
            Me.Text = "Starting at: " & " (" & DateTime.Now.AddHours(CInt(txtWaitTime.Text)).ToString("HH:mm:ss") & ")"
            Timer1.Interval = CInt(txtWaitTime.Text) * 60 * 60 * 1000
        End If
    End Sub

    Private Sub ShowPositions()
        lbPos.Items.Clear()
        For i As Int16 = 0 To alMem.Count - 1
            lbPos.Items.Add(alMem(i).ToString.Replace("&", "   "))
        Next
    End Sub

    Private Sub btnTimer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTimer.Click
        Timer1.Interval = CInt(txtInterval.Text) * 1000
        If Timer1.Enabled Then
            Timer1.Enabled = False
            btnTimer.Text = "Enable timer"
        Else
            Timer1.Enabled = True
            btnTimer.Text = "Disable timer"
        End If
    End Sub

    Private Function CheckForChamp(ByVal input As String, ByVal Check As Boolean) As Boolean
        If input.IndexOf("(Super") > -1 Or input.IndexOf("Legendary") > -1 Then
            Process.Start("C:\WINDOWS\Media\Trumpet1.wav")
            WindowState = FormWindowState.Normal
        End If
        If Check Or cbNotify.Checked Then
            If input.IndexOf(" (") > -1 Then
                If cbNotify.Checked Then
                    Timer1.Enabled = False
                    btnTimer.Text = "Enable timer"
                    WindowState = FormWindowState.Normal
                End If
                Return True
            End If
        End If
        Return False
    End Function

    Private Sub WriteStats(ByVal name As String)
        SumExp = InitialExperience - Experience
        SumStam = InitialStamina - Stamina
        Progress = CInt(IIf(SumStam > 0, SumExp / SumStam, 0))
        If Progress < 0 And Progress > -100000 Then
            Timer1.Enabled = False
            btnTimer.Text = "Enable timer"
            MessageBox.Show("Thn katsame !!")
        Else
        End If
        lblProgress.Text = "Progress = " & Progress
        WriteToFile(DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") & ":" & vbTab & name & vbTab & Experience & vbTab & Stamina & vbTab & Progress)
    End Sub

    Private Sub WriteToFile(ByVal text As String)
        Dim sw As StreamWriter = New StreamWriter("FallenSwordLog.txt", True)
        sw.WriteLine(text)
        sw.Close()
    End Sub

    Private Sub FallenSword_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        My.Settings.UserName = txtUsername.Text
        My.Settings.Password = txtPassword.Text
        My.Settings.Stamina = txtStamina.Text
        My.Settings.WaitFor = txtWaitTime.Text
        My.Settings.Interval = txtInterval.Text
        My.Settings.Steps = txtSteps.Text
        My.Settings.ExperienceCheck = cbExp.Checked
        My.Settings.ShowResults = cbShowResults.Checked
        My.Settings.AvoidChamps = cbChamp.Checked
        My.Settings.NotifyForChamps = cbNotify.Checked
        My.Settings.EnableBuffAfterLogin = cbBuff.Checked
        My.Settings.AttackAfterMove = cbAttack.Checked
    End Sub

    Private Sub FallenSword_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        wbrs.ScriptErrorsSuppressed = True
        btnClrEnemies.Text = "Enemies" & vbCrLf & "(click to clear):"
        ListView1.View = View.Details
        ListView1.LabelEdit = True
        ListView1.AllowColumnReorder = True
        ListView1.CheckBoxes = True
        ListView1.FullRowSelect = True
        ListView1.GridLines = True
        ListView1.Sorting = SortOrder.Ascending

        Dim sr As StreamReader = New StreamReader("Buffs.txt")
        Dim sLine As String
        Dim item As ListViewItem
        Dim i As Int16 = 0

        ListView1.Columns.Add("Name")
        ListView1.Columns.Add("Description")
        ListView1.Columns.Add("Link")

        Do While sr.Peek() >= 0
            sLine = sr.ReadLine
            item = New ListViewItem(sLine.Split("|")(0), i)
            item.SubItems.Add(sLine.Split("|")(1))
            item.SubItems.Add(sLine.Split("|")(2))
            item.Checked = (sLine.Split("|")(3) = 1)
            i += 1
            ListView1.Items.Add(item)
        Loop
        ListView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent)
        ListView1.Columns(2).Width = 0
        sr.Close()
    End Sub

    Private Sub btnSaveBuffs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveBuffs.Click
        Dim item As ListViewItem
        Dim subitem As ListViewItem.ListViewSubItem
        Dim subitems As String

        Dim sw As StreamWriter = New StreamWriter("Buffs.txt", False)
        For Each item In ListView1.Items
            subitems = ""
            For Each subitem In item.SubItems
                subitems += subitem.Text & "|"
            Next
            sw.WriteLine(subitems & IIf(item.Checked, "1", "0"))
        Next
        sw.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        NavigateTo("http://www.fallensword.com/index.php")
    End Sub

    Private Sub btnAddEnemy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddEnemy.Click
        If lbEnemies.FindStringExact(txtEnemy.Text) = -1 Then
            lbEnemies.Items.Add(txtEnemy.Text)
        End If
        txtEnemy.Text = ""
    End Sub

    Private Sub btnClrEnemies_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClrEnemies.Click
        lbEnemies.Items.Clear()
    End Sub

    'Sub ExtendResponse()
    'Dim parent As HtmlElement = Me.wbrs.Document.Body
    'Dim elem As HtmlElement = Me.wbrs.Document.CreateElement("span")
    'elem.InnerHtml = "<input type=text id=""txtData"">"
    'parent.AppendChild(elem)
    'elem = Me.wbrs.Document.CreateElement("span")
    'elem.InnerHtml = "<input type=button onclick=""txtData.value = ajaxLoadItem(2321, 49954025, 3, 1901232, '');"" value=""Click me"">"
    'elem.OuterHtml = "<IMG onmouseover=""ajaxLoadItem(2321, 49954025, 3, 1901232, '');"" border=0 src=""http://72.29.91.222/items/2321.gif"">"
    'AddHandler elem.Click, AddressOf buttonclicked
    'parent.AppendChild(elem)
    'End Sub

    'Sub buttonclicked(ByVal sender As Object, ByVal e As HtmlElementEventArgs)
    '    MsgBox("Here I am")
    'End Sub
End Class
