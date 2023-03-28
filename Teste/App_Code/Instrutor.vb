Imports System.Data
Imports System.Data.Common
Imports Microsoft.VisualBasic

Public Class Instrutor
    Public Shared Function Create(ByVal nome As String, ByVal dataNascimento As DateTime, ByVal email As String, ByVal enderecoInstagram As String) As Integer
        Dim command As DbCommand = AcessoDados.CreateCommand()

        command.CommandText = "INSERT INTO Instrutor (Nome, DataNascimento, Email, EnderecoInstagram) VALUES (@Nome, @DataNascimento, @Email, @EnderecoInstagram)"
        command.Parameters.Add(AcessoDados.CreateParameter("@Nome", DbType.String, nome))
        command.Parameters.Add(AcessoDados.CreateParameter("@DataNascimento", DbType.DateTime, dataNascimento))
        command.Parameters.Add(AcessoDados.CreateParameter("@Email", DbType.String, email))
        command.Parameters.Add(AcessoDados.CreateParameter("@EnderecoInstagram", DbType.String, enderecoInstagram))

        Return AcessoDados.ExecuteNonQuery(command)
    End Function

    Public Shared Function ReadAll() As DataTable
        Dim command As DbCommand = AcessoDados.CreateCommand()

        command.CommandText = "SELECT * FROM Instrutor"

        Return AcessoDados.ExecuteReader(command)
    End Function

    Public Shared Function ReadById(ByVal id As Integer) As DataTable
        Dim command As DbCommand = AcessoDados.CreateCommand()

        command.CommandText = "SELECT * FROM Instrutor WHERE Id = @Id"
        command.Parameters.Add(AcessoDados.CreateParameter("@Id", DbType.Int32, id))

        Return AcessoDados.ExecuteReader(command)
    End Function

    Public Shared Function Update(ByVal id As Integer, ByVal nome As String, ByVal dataNascimento As DateTime, ByVal email As String, ByVal enderecoInstagram As String) As Integer
        Dim command As DbCommand = AcessoDados.CreateCommand()

        command.CommandText = "UPDATE Instrutor SET Nome = @Nome, DataNascimento = @DataNascimento, Email = @Email, EnderecoInstagram = @EnderecoInstagram WHERE Id = @Id"
        command.Parameters.Add(AcessoDados.CreateParameter("@Nome", DbType.String, nome))
        command.Parameters.Add(AcessoDados.CreateParameter("@DataNascimento", DbType.DateTime, dataNascimento))
        command.Parameters.Add(AcessoDados.CreateParameter("@Email", DbType.String, email))
        command.Parameters.Add(AcessoDados.CreateParameter("@EnderecoInstagram", DbType.String, enderecoInstagram))
        command.Parameters.Add(AcessoDados.CreateParameter("@Id", DbType.Int32, id))

        Return AcessoDados.ExecuteNonQuery(command)
    End Function

    Public Shared Function Delete(ByVal id As Integer) As Integer
        Dim command As DbCommand = AcessoDados.CreateCommand()

        command.CommandText = "DELETE FROM Instrutor WHERE Id = @Id"
        command.Parameters.Add(AcessoDados.CreateParameter("@Id", DbType.Int32, id))

        Return AcessoDados.ExecuteNonQuery(command)
    End Function
End Class
