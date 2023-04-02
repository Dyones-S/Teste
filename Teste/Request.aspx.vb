
Partial Class Request
    Inherits System.Web.UI.Page

    Dim instrutorDAO As New InstrutorDAO()
    Dim inscritoDAO As New InscritoDAO()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim acao As String = Request.Form("acao")
        Dim result As String = ""

        Select Case acao
            Case "deletarInstrutor"

                If InstrutorDAO.Delete(Request.Form("id")) Then
                    result = "{""status"": ""success"", ""message"": ""Instrutor deletado com sucesso!""}"
                Else
                    result = "{""status"": ""error"", ""message"": ""Não foi possível deletar o instrutor.""}"
                End If

            Case "deletarInscrito"
                If InscritoDAO.Delete(Request.Form("id")) Then
                    result = "{""status"": ""success"", ""message"": ""Instrutor deletado com sucesso!""}"
                Else
                    result = "{""status"": ""error"", ""message"": ""Não foi possível deletar o instrutor.""}"
                End If

            Case "deletarLive"
                If LiveDAO.Delete(Request.Form("id")) Then
                    result = "{""status"": ""success"", ""message"": ""Live deletada com sucesso!""}"
                Else
                    result = "{""status"": ""error"", ""message"": ""Não foi possível deletar a live.""}"
                End If

            Case Else
                result = "{""status"": ""error"", ""message"": ""Ação desconhecida""}"
        End Select

        Response.ContentType = "application/json"
        Response.Write(result)

    End Sub

End Class
