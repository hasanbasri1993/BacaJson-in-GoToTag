Imports System.IO
Imports Newtonsoft.Json

Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim json As String = File.ReadAllText("C:\result.txt")
        Dim jsonres = JsonConvert.DeserializeObject(json)
        Dim decodeBase64 = System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(jsonres(0)("Text")))
        Dim jsonFromBase64 = JsonConvert.DeserializeObject(decodeBase64)
        SendKeys.SendWait("%{TAB}")
        Threading.Thread.Sleep(300)
        SendKeys.SendWait(jsonFromBase64("induk"))
        SendKeys.SendWait("{ENTER}")
        Application.Exit()
    End Sub
End Class
