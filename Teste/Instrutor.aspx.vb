
Imports System.Data
Imports System.Data.Common

Partial Class _Default
    Inherits System.Web.UI.Page
    Public Shared Function CreateInstrutor(ByVal nome As String, ByVal dataNascimento As DateTime, ByVal email As String, ByVal enderecoInstagram As String) As Integer
        Dim command As DbCommand = CreateCommand()

        command.CommandText = "INSERT INTO Instrutor (Nome, DataNascimento, Email, EnderecoInstagram) VALUES (@Nome, @DataNascimento, @Email, @EnderecoInstagram)"
        command.Parameters.Add(CreateParameter("@Nome", DbType.String, nome))
        command.Parameters.Add(CreateParameter("@DataNascimento", DbType.DateTime, dataNascimento))
        command.Parameters.Add(CreateParameter("@Email", DbType.String, email))
        command.Parameters.Add(CreateParameter("@EnderecoInstagram", DbType.String, enderecoInstagram))

        Return ExecuteNoneQuery(command)
    End Function

End Class
