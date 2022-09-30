Imports System.IO
Imports Newtonsoft.Json
Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim resultFile = Environment.ExpandEnvironmentVariables("%USERPROFILE%") + "\Documents\result.txt"
        If (File.Exists(resultFile)) Then
            Dim json As String = File.ReadAllText(resultFile)
            Dim jsonres = JsonConvert.DeserializeObject(json)
            Try
                Dim decodeBase64 = System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(jsonres("Records")(0)("Text")))
                Dim jsonFromBase64 = JsonConvert.DeserializeObject(decodeBase64)
                Label1.Text = jsonFromBase64("induk")
                Me.WindowState = FormWindowState.Minimized
                Threading.Thread.Sleep(300)
                SendKeys.SendWait(jsonFromBase64("induk"))
                SendKeys.SendWait("{ENTER}")
                Application.Exit()
            Catch ex As Exception
                MessageBox.Show("Bukan format kartu santri")
            Finally
                MessageBox.Show(json)
                Application.Exit()
            End Try
        Else
            MessageBox.Show("Tidak ditemukan file result")
        End If

    End Sub
End Class