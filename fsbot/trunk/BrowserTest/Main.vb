Public Class Main

    Private Sub btnMax_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMax.Click
        Dim frm As New MaxBot
        frm.Show()
    End Sub

    Private Sub btnFallen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFallen.Click
        Dim frm As New FallenSword
        frm.Show()
    End Sub

    Private Sub btnMerlin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMerlin.Click
        Dim frm As New TextToSpeach
        frm.Show()
    End Sub

    Private Sub btnCapital_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCapital.Click
        Dim frm As New CapitalMonitor
        frm.Show()
    End Sub
End Class