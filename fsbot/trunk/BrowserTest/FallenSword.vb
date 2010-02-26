Imports System.Text.RegularExpressions
Imports System.Net
Imports System.io

Public Class FallenSword

    Private Sub btnGo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGo.Click
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
        'SumExp = 0
        'SumStam = 0
        alMem.Clear()
        lbEnemies.Items.Clear()
        lbLostExp.Items.Clear()
    End Sub

    Private Sub EnableBuffs()
        Dim item As ListViewItem

        For Each item In ListView1.Items
            If item.Checked Then NavigateHoldingHeaders(item.SubItems(2).Text, False)
        Next

        'NavigateHoldingHeaders("http://www.fallensword.com/index.php?cmd=skills&subcmd=cast&target_username=Peteperson&skill_id=2", False)
        'NavigateHoldingHeaders("http://www.fallensword.com/index.php?cmd=skills&subcmd=cast&target_username=Peteperson&skill_id=3", False)
        'NavigateHoldingHeaders("http://www.fallensword.com/index.php?cmd=skills&subcmd=cast&target_username=Peteperson&skill_id=20", False)
        'NavigateHoldingHeaders("http://www.fallensword.com/index.php?cmd=skills&subcmd=cast&target_username=Peteperson&skill_id=19", False)
        'NavigateHoldingHeaders("http://www.fallensword.com/index.php?cmd=skills&subcmd=cast&target_username=Peteperson&skill_id=11", False)
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
                    'Timer1.Enabled = False
                    lbLostExp.Items.Add(Experience - CInt(tmp.Replace(",", "")))
                    Dim snd As New System.Media.SoundPlayer(My.Resources.Windows_XP_Error)
                    snd.Play()
                End If
            End If
            'PrevExperience = Experience
            Experience = CInt(tmp.Replace(",", ""))
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

    Private DocText As String
    'Private PrevStamina As Integer = -1
    Private _Stamina As Integer = -1
    Private _Experience As Integer = -1
    'Private PrevExperience As Integer = -1
    Private InitialStamina, InitialExperience As Integer

    Private Property Stamina() As Integer
        Get
            Return _Stamina
        End Get
        Set(ByVal value As Integer)
            If _Stamina = -1 Then
                WriteToFile(DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") & ": Initial stamina= " & value)
                InitialStamina = value
            End If
            'PrevStamina = _Stamina
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
            'PrevExperience = _Experience
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
            'PrevStamina = Stamina
            Stamina = CheckStamina(DocText)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If Timer1.Interval = CInt(txtWaitTime.Text) * 60 * 60 * 1000 Then
            'NavigateTo("http://www.fallensword.com/index.php?cmd=world")
            'moves = 240
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
        'mtcs1 = Regex.Matches(DocText, "title=Creature></TD><TD width=90% align=left>[ a-zA-Z()]+</td>", RegexOptions.IgnoreCase)
        mtcs1 = Regex.Matches(DocText, "title=Creature[ 0-9a-zA-Z\/\\\:\._\<\>\=%]+align=left>[ a-zA-Z()]+</td>", RegexOptions.IgnoreCase)
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

                'If cbChamp.Checked Then
                '    If Not CheckForChamp(sName) Then
                '        WriteStats(sName)
                '        UpdateExp(NavigateHoldingHeaders("http://www.fallensword.com/index.php?" & mtcs2(i).Value.Replace(Chr(34), ""), False))
                '    End If
                'Else
                '    WriteStats(sName)
                '    UpdateExp(NavigateHoldingHeaders("http://www.fallensword.com/index.php?" & mtcs2(i).Value.Replace(Chr(34), ""), False))
                'End If

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

    Private heads As System.Net.WebHeaderCollection
    Private moves As Int16 = 0
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
            'PrevStamina = Stamina
            Stamina = CheckStamina(ret)
        Else
            'PrevStamina = Stamina
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

    Private rnd As New Random
    Private alMem As New ArrayList
    Private Sub MoveCharacter()
        If Stamina > CInt(txtStamina.Text) Then
            Dim al As New ArrayList
            Dim mtcs As MatchCollection
            Dim s As String = ""
            moves += 1
            DocText = DocText.Replace("""", "")
            mtcs = Regex.Matches(DocText, "cmd=world&subcmd=move&x=[0-9]+&y=[0-9]+><img title=[:\[0-9\)a-z\(A-Z \-]+][a-z=0-9 ]+src=http://72.29.91.222/skin/realm/[A-Z0-9_]+on.gif", RegexOptions.IgnoreCase)
            '"cmd=world&subcmd=move&x=[0-9]+&y=[0-9]+""><img.+src=""http://72.29.91.222/skin/realm/[A-Z0-9_]+on.gif")
            If mtcs.Count = 0 Then
                mtcs = Regex.Matches(DocText, "cmd=world&subcmd=move&x=[0-9]+&y=[0-9]+><img src=http://72.29.91.222/skin/realm/[A-Z0-9_]+on.gif[a-z=0-9 ]+title=[:\[0-9\)a-z\(A-Z \-]+]", RegexOptions.IgnoreCase)
                If mtcs.Count = 0 Then
                    mtcs = Regex.Matches(DocText, "cmd=world&subcmd=move&x=[0-9]+&y=[0-9]+><img src=http://72.29.91.222/skin/realm/[A-Z0-9_]+on.gif", RegexOptions.IgnoreCase)
                End If
            End If

            For i As Int16 = 0 To mtcs.Count - 1
                's = mtcs(i).Value.Replace("""><", "|").Split("|")(0)
                s = Regex.Match(mtcs(i).Value, "x=[0-9]+&y=[0-9]+").Value
                If (Not al.Contains(s)) Then al.Add(s)
            Next

            Dim cont As Boolean = True
            While cont And al.Count > 0
                For i As Int16 = 0 To al.Count - 1
                    'If alMem.Contains(al(i).ToString.Replace("cmd=world&subcmd=move&", "")) Then
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
            's = al(pos).ToString.Replace("cmd=world&subcmd=move&", "")
            s = al(pos)
            If (Not alMem.Contains(s)) Then alMem.Add(s)
            If cbShowResults.Checked Then
                'NavigateTo("http://www.fallensword.com/index.php?" & al(pos).Replace(Chr(34), "").Replace("&", "&"))
                NavigateTo("http://www.fallensword.com/index.php?cmd=world&subcmd=move&" & al(pos))
            Else
                'NavigateHoldingHeaders("http://www.fallensword.com/index.php?" & al(pos).Replace(Chr(34), "").Replace("&", "&"), True)
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

    Private SumExp As Integer = 0
    Private SumStam As Integer = 0
    Private Progress As Decimal
    Private Sub WriteStats(ByVal name As String)
        'txtResults.Text += name & vbTab & experience & vbTab & stamina & vbCrLf
        'SumExp += IIf(PrevExperience - Experience > -100000, PrevExperience - Experience, 0)
        'SumStam += IIf(PrevStamina - Stamina > 0, PrevStamina - Stamina, 0)
        SumExp = InitialExperience - Experience
        SumStam = InitialStamina - Stamina
        Progress = CInt(IIf(SumStam > 0, SumExp / SumStam, 0))
        If Progress < 0 And Progress > -100000 Then
            Timer1.Enabled = False
            btnTimer.Text = "Enable timer"
            MessageBox.Show("Thn katsame !!")
        Else
            'Timer1.Enabled = True
            'btnTimer.Text = "Disable timer"
        End If
        lblProgress.Text = "Progress = " & Progress
        WriteToFile(DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") & ":" & vbTab & name & vbTab & Experience & vbTab & Stamina & vbTab & Progress)
    End Sub

    Private Sub WriteToFile(ByVal text As String)
        Dim sw As StreamWriter = New StreamWriter("C:\\FallenSwordLog.txt", True)
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
End Class

'Imports System.Text.RegularExpressions
'Imports System.Net
'Imports System.io

'Public Class FallenSword

'    Private Sub btnGo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGo.Click
'        If wbrs.Document Is Nothing Then
'            NavigateTo("http://www.fallensword.com/index.php?cmd=login&subcmd=processlogin&passthru_cmd=&passthru_subcmd=&login_username=Peteperson&login_password=***********&x=113&y=18")
'            If Stamina > CInt(txtStamina.Text) Then
'                If cbBuff.Checked Then EnableBuffs()
'            End If
'        End If
'        If cbBuff.Checked Then EnableBuffs()
'        NavigateTo("http://www.fallensword.com/index.php?cmd=world")
'        alMem.Clear()
'        lbEnemies.Items.Clear()
'        lbLostExp.Items.Clear()
'    End Sub

'    Private Sub EnableBuffs()
'        Dim item As ListViewItem

'        For Each item In ListView1.Items
'            If item.Checked Then NavigateHoldingHeaders(item.SubItems(2).Text, False)
'        Next

'        'NavigateHoldingHeaders("http://www.fallensword.com/index.php?cmd=skills&subcmd=cast&target_username=Peteperson&skill_id=2", False)
'        'NavigateHoldingHeaders("http://www.fallensword.com/index.php?cmd=skills&subcmd=cast&target_username=Peteperson&skill_id=3", False)
'        'NavigateHoldingHeaders("http://www.fallensword.com/index.php?cmd=skills&subcmd=cast&target_username=Peteperson&skill_id=20", False)
'        'NavigateHoldingHeaders("http://www.fallensword.com/index.php?cmd=skills&subcmd=cast&target_username=Peteperson&skill_id=19", False)
'        'NavigateHoldingHeaders("http://www.fallensword.com/index.php?cmd=skills&subcmd=cast&target_username=Peteperson&skill_id=11", False)
'    End Sub

'    Private Sub UpdateExp(ByVal searchText As String)
'        Dim tmp As String
'        Dim mtcs As MatchCollection

'        mtcs = Regex.Matches(searchText, "Remaining:.+[0-9,]+</td>")
'        If mtcs.Count = 1 Then
'            mtcs = Regex.Matches(mtcs(0).Value, ">[0-9,]+<")
'            Dim trchars() As Char = {"<", ">"}
'            tmp = mtcs(0).Value.Trim(trchars)
'            If cbExp.Checked Then
'                If Experience <> -1 AndAlso Experience < CInt(tmp.Replace(",", "")) Then
'                    'Timer1.Enabled = False
'                    lbLostExp.Items.Add(Experience - CInt(tmp.Replace(",", "")))
'                    Dim snd As New System.Media.SoundPlayer(My.Resources.Windows_XP_Error)
'                    snd.Play()
'                End If
'            End If
'            PrevExperience = Experience
'            Experience = CInt(tmp.Replace(",", ""))
'            Me.Text = "P:" & Progress & " S:" & Stamina & " E:" & tmp
'        End If
'    End Sub

'    Private Function CheckStamina(ByVal searchText As String) As Integer
'        Dim tmp As String
'        Dim stam As Integer = 100000
'        Dim mtcs As MatchCollection

'        mtcs = Regex.Matches(searchText, "Stamina:.+[0-9,]+&nbsp;/&nbsp;[0-9,]+")
'        If mtcs.Count = 1 Then
'            mtcs = Regex.Matches(mtcs(0).Value, "[0-9,]+&nbsp;/&nbsp;[0-9,]+")
'        End If
'        For i As Int16 = 0 To mtcs.Count - 1
'            tmp = mtcs(i).Value.Replace("&nbsp;", "")
'            tmp = tmp.Split("/")(0)
'            If CInt(tmp) < stam Then stam = CInt(tmp)
'        Next

'        If stam < 100000 Then
'            Return stam
'        Else
'            Return -1
'        End If
'    End Function

'    Private DocText As String
'    Private PrevStamina As Integer
'    Private Stamina As Integer
'    Private Experience As Integer = -1
'    Private PrevExperience As Integer = -1

'    Private Sub NavigateTo(ByVal address As String)
'        Try
'            wbrs.Navigate(address)
'            Do
'                System.Threading.Thread.Sleep(500)
'                lblState.Text = wbrs.ReadyState.ToString
'                Application.DoEvents()
'            Loop Until wbrs.ReadyState = WebBrowserReadyState.Complete 'Not wbrs.IsBusy
'            lblState.Text = wbrs.ReadyState.ToString
'            DocText = wbrs.DocumentText
'            PrevStamina = Stamina
'            Stamina = CheckStamina(DocText)
'        Catch ex As Exception
'            MessageBox.Show(ex.Message)
'        End Try
'    End Sub

'    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
'        If Timer1.Interval = CInt(txtWaitTime.Text) * 60 * 60 * 1000 Then
'            NavigateTo("http://www.fallensword.com/index.php?cmd=world")
'            moves = 240
'            Timer1.Interval = CInt(txtInterval.Text) * 1000
'            SumExp = 0
'            SumStam = 0
'        End If
'        MoveCharacter()
'    End Sub

'    Private Sub Attack()
'        Dim mtcs1 As MatchCollection
'        Dim mtcs2 As MatchCollection
'        mtcs2 = Regex.Matches(DocText, "cmd=combat&subcmd=[a-z0-9]+&creature_id=[0-9]+""")
'        mtcs1 = Regex.Matches(DocText, "title=""Creature""></td><td width=""90%"" align=""left"">[ a-zA-Z()]+</td>")
'        Dim sName As String

'        If mtcs1.Count <> mtcs2.Count Then lbLostExp.Items.Add("<>")

'        For i As Int16 = 0 To mtcs2.Count - 1
'            Try
'                sName = mtcs1(i).Value.Replace(Chr(34), "").Replace("title=Creature></td><td width=90% align=left>", "").Replace("</td>", "")
'                If lbEnemies.FindStringExact(sName) = -1 Then
'                    lbEnemies.Items.Add(sName)
'                End If

'                'If cbChamp.Checked Then
'                '    If Not CheckForChamp(sName) Then
'                '        WriteStats(sName)
'                '        UpdateExp(NavigateHoldingHeaders("http://www.fallensword.com/index.php?" & mtcs2(i).Value.Replace(Chr(34), ""), False))
'                '    End If
'                'Else
'                '    WriteStats(sName)
'                '    UpdateExp(NavigateHoldingHeaders("http://www.fallensword.com/index.php?" & mtcs2(i).Value.Replace(Chr(34), ""), False))
'                'End If

'                If Not CheckForChamp(sName, cbChamp.Checked) Then
'                    WriteStats(sName)
'                    UpdateExp(NavigateHoldingHeaders("http://www.fallensword.com/index.php?" & mtcs2(i).Value.Replace(Chr(34), ""), False))
'                End If
'            Catch ex As Exception
'                WriteStats("Error: " & ex.Message)
'                Exit For
'            End Try
'        Next
'        If (moves Mod CInt(txtSteps.Text)) = 0 Then
'            Me.Text = "Repairing..."
'            NavigateHoldingHeaders("http://www.fallensword.com/index.php?cmd=blacksmith&subcmd=repairall&fromworld=1", False)
'        End If
'        If moves >= 240 Then
'            Me.Text = "Buffing up..."
'            EnableBuffs()
'            moves = 0
'        End If
'    End Sub

'    Private Sub btnAttack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAttack.Click
'        Attack()
'    End Sub

'    Private heads As System.Net.WebHeaderCollection
'    Private moves As Int16 = 0
'    Private Function NavigateHoldingHeaders(ByVal url As String, ByVal holdText As Boolean) As String
'        Dim request As System.Net.HttpWebRequest
'        Dim response As System.Net.HttpWebResponse
'        Dim ret As String
'        lblState.Text = "Loading..."
'        lblState.Refresh()
'        request = System.Net.HttpWebRequest.Create(url)
'        request.Headers.Add(Net.HttpRequestHeader.Cookie, wbrs.Document.Cookie)
'        response = request.GetResponse()
'        Dim reader As StreamReader = New StreamReader(response.GetResponseStream())
'        ret = reader.ReadToEnd
'        If holdText Then
'            DocText = ret
'            PrevStamina = Stamina
'            Stamina = CheckStamina(ret)
'        Else
'            PrevStamina = Stamina
'            Stamina = CheckStamina(ret)
'        End If
'        lblState.Text = "Completed"
'        response.Close()
'        reader.Close()
'        Return ret
'    End Function

'    Private Sub btnMove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMove.Click
'        MoveCharacter()
'    End Sub

'    Private rnd As New Random
'    Private alMem As New ArrayList
'    Private Sub MoveCharacter()
'        If Stamina > CInt(txtStamina.Text) Then
'            Dim al As New ArrayList
'            Dim mtcs As MatchCollection
'            Dim s As String = ""
'            moves += 1
'            mtcs = Regex.Matches(DocText, "cmd=world&subcmd=move&x=[0-9]+&y=[0-9]+""><img src=""http://66.7.192.165/skin/realm/[A-Z0-9_]+on.gif")

'            For i As Int16 = 0 To mtcs.Count - 1
'                s = mtcs(i).Value.Replace("""><", "|").Split("|")(0)
'                If (Not al.Contains(s)) Then al.Add(s)
'            Next

'            Dim cont As Boolean = True
'            While cont And al.Count > 0
'                For i As Int16 = 0 To al.Count - 1
'                    If alMem.Contains(al(i).ToString.Replace("cmd=world&subcmd=move&", "")) Then
'                        If al.Count > 1 Then
'                            al.RemoveAt(i)
'                            cont = True
'                            Exit For
'                        Else
'                            alMem.Clear()
'                            cont = False
'                            Exit For
'                        End If
'                    End If
'                    cont = False
'                Next
'            End While

'            Dim pos As Int16
'            pos = rnd.Next(0, al.Count)
'            s = al(pos).ToString.Replace("cmd=world&subcmd=move&", "")
'            If (Not alMem.Contains(s)) Then alMem.Add(s)
'            If cbShowResults.Checked Then
'                NavigateTo("http://www.fallensword.com/index.php?" & al(pos).Replace(Chr(34), ""))
'            Else
'                NavigateHoldingHeaders("http://www.fallensword.com/index.php?" & al(pos).Replace(Chr(34), ""), True)
'            End If
'            ShowPositions()
'            UpdateExp(DocText)
'            Attack()
'        Else
'            Me.Text = "Starting at: " & " (" & DateTime.Now.AddHours(CInt(txtWaitTime.Text)).ToString("HH:mm:ss") & ")"
'            Timer1.Interval = CInt(txtWaitTime.Text) * 60 * 60 * 1000
'        End If
'    End Sub

'    Private Sub ShowPositions()
'        lbPos.Items.Clear()
'        For i As Int16 = 0 To alMem.Count - 1
'            lbPos.Items.Add(alMem(i).ToString.Replace("&", "   "))
'        Next
'    End Sub

'    Private Sub btnTimer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTimer.Click
'        Timer1.Interval = CInt(txtInterval.Text) * 1000
'        If Timer1.Enabled Then
'            Timer1.Enabled = False
'            btnTimer.Text = "Enable timer"
'        Else
'            Timer1.Enabled = True
'            btnTimer.Text = "Disable timer"
'        End If
'    End Sub

'    Private Function CheckForChamp(ByVal input As String, ByVal Check As Boolean) As Boolean
'        If input.IndexOf("(Super") > -1 Or input.IndexOf("Legendary") > -1 Then
'            Process.Start("C:\WINDOWS\Media\Trumpet1.wav")
'            WindowState = FormWindowState.Normal
'        End If
'        If Check Or cbNotify.Checked Then
'            If input.IndexOf(" (") > -1 Then
'                If cbNotify.Checked Then
'                    Timer1.Enabled = False
'                    btnTimer.Text = "Enable timer"
'                    WindowState = FormWindowState.Normal
'                End If
'                Return True
'            End If
'        End If
'        Return False
'    End Function

'    Private SumExp As Integer = 0
'    Private SumStam As Integer = 0
'    Private Progress As Decimal
'    Private Sub WriteStats(ByVal name As String)
'        'txtResults.Text += name & vbTab & experience & vbTab & stamina & vbCrLf
'        SumExp += IIf(PrevExperience - Experience > -100000, PrevExperience - Experience, 0)
'        SumStam += IIf(PrevStamina - Stamina > 0, PrevStamina - Stamina, 0)
'        Progress = CInt(IIf(SumStam > 0, SumExp / SumStam, 0))
'        If Progress < 0 Then
'            Timer1.Enabled = False
'            btnTimer.Text = "Enable timer"
'            MessageBox.Show("Thn katsame !!")
'        End If
'        lblProgress.Text = "Progress = " & Progress
'        Dim sw As StreamWriter = New StreamWriter("C:\\FallenSwordLog.txt", True)
'        sw.WriteLine(DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") & ":" & vbTab & name & vbTab & Experience & vbTab & Stamina & vbTab & Progress)
'        sw.Close()
'    End Sub

'    Private Sub FallenSword_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
'        ListView1.View = View.Details
'        ListView1.LabelEdit = True
'        ListView1.AllowColumnReorder = True
'        ListView1.CheckBoxes = True
'        ListView1.FullRowSelect = True
'        ListView1.GridLines = True
'        ListView1.Sorting = SortOrder.Ascending

'        Dim sr As StreamReader = New StreamReader("Buffs.txt")
'        Dim sLine As String
'        Dim item As ListViewItem
'        Dim i As Int16 = 0

'        ListView1.Columns.Add("Name")
'        ListView1.Columns.Add("Description")
'        ListView1.Columns.Add("Link")

'        Do While sr.Peek() >= 0
'            sLine = sr.ReadLine
'            item = New ListViewItem(sLine.Split("|")(0), i)
'            item.SubItems.Add(sLine.Split("|")(1))
'            item.SubItems.Add(sLine.Split("|")(2))
'            item.Checked = (sLine.Split("|")(3) = 1)
'            i += 1
'            ListView1.Items.Add(item)
'        Loop
'        ListView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent)
'        ListView1.Columns(2).Width = 0
'        sr.Close()
'    End Sub

'    Private Sub btnSaveBuffs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveBuffs.Click
'        Dim item As ListViewItem
'        Dim subitem As ListViewItem.ListViewSubItem
'        Dim subitems As String

'        Dim sw As StreamWriter = New StreamWriter("Buffs.txt", False)
'        For Each item In ListView1.Items
'            subitems = ""
'            For Each subitem In item.SubItems
'                subitems += subitem.Text & "|"
'            Next
'            sw.WriteLine(subitems & IIf(item.Checked, "1", "0"))
'        Next
'        sw.Close()
'    End Sub

'    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
'        NavigateTo("http://www.fallensword.com/index.php")
'    End Sub
'End Class