Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic

Public Class InscricaoDAO
    Private Shared ReadOnly connectionString As String = ConfigurationManager.ConnectionStrings("CRUDLives").ConnectionString

    Public Shared Function GetAll() As DataTable
        Dim query As String = "SELECT Inscricao.*, Live.Nome as nomeLive, Inscrito.Nome as nomeInscrito FROM Inscricao JOIN Live ON Inscricao.LiveId = Live.Id JOIN Inscrito ON Inscrito.Id = Inscricao.InscritoId where Inscricao.deleted_at IS NULL AND Live.deleted_at IS NULL AND Inscrito.deleted_at IS NULL"
        Using connection As New SqlConnection(connectionString)
            Using command As New SqlCommand(query, connection)
                Try
                    connection.Open()
                    Dim adapter As New SqlDataAdapter(command)
                    Dim table As New DataTable()
                    adapter.Fill(table)
                    Return table
                Catch ex As Exception
                    Return Nothing
                End Try
            End Using
        End Using
    End Function

    Public Shared Function Create(inscricao As Inscricao) As Boolean
        Dim query As String = "INSERT INTO Inscricao(liveID, inscritoID, valor, dataVencimento, statusPagamento) VALUES (@liveID, @inscritoID, @valor, @dataVencimento, @statusPagamento)"
        Using connection As New SqlConnection(connectionString)
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@liveID", inscricao.liveID)
                command.Parameters.AddWithValue("@inscritoID", inscricao.inscritoID)
                command.Parameters.AddWithValue("@valor", inscricao.valor)
                command.Parameters.AddWithValue("@dataVencimento", inscricao.dataVencimento)
                command.Parameters.AddWithValue("@statusPagamento", inscricao.statusPagamento)

                Try
                    connection.Open()
                    Dim rowsAffected As Integer = command.ExecuteNonQuery()
                    Return rowsAffected > 0
                Catch ex As Exception
                    Return False
                End Try
            End Using
        End Using
    End Function

    Public Shared Function Update(inscricao As Inscricao, id As Integer) As Boolean
        Dim query As String = "UPDATE Inscricao SET liveID = @liveID, inscritoID = @inscritoID, valor = @valor, dataVencimento = @dataVencimento, statusPagamento = @statusPagamento WHERE id = @id;"
        Using connection As New SqlConnection(connectionString)
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@liveID", inscricao.liveID)
                command.Parameters.AddWithValue("@inscritoID", inscricao.inscritoID)
                command.Parameters.AddWithValue("@valor", inscricao.valor)
                command.Parameters.AddWithValue("@dataVencimento", inscricao.dataVencimento)
                command.Parameters.AddWithValue("@statusPagamento", inscricao.statusPagamento)
                command.Parameters.AddWithValue("@id", id)
                connection.Open()
                Dim rowsAffected As Integer = command.ExecuteNonQuery()
                Try

                    Return rowsAffected > 0
                Catch ex As Exception
                    Return False
                End Try
            End Using
        End Using
    End Function

    Public Shared Function Delete(id As Integer) As Boolean
        Dim query As String = "UPDATE Inscricao SET Deleted_at = GETDATE() WHERE id = @id;"
        Using connection As New SqlConnection(connectionString)
            Using command As New SqlCommand(query, connection)

                command.Parameters.AddWithValue("@id", id)

                Try
                    connection.Open()
                    Dim rowsAffected As Integer = command.ExecuteNonQuery()
                    Return rowsAffected > 0
                Catch ex As Exception
                    Return False
                End Try
            End Using
        End Using
    End Function

    Public Shared Function Pagamento(id As Integer, statusPagamento As Boolean) As Boolean
        Dim query As String = "UPDATE Inscricao SET statusPagamento = @statusPagamento WHERE id = @id;"
        Using connection As New SqlConnection(connectionString)
            Using command As New SqlCommand(query, connection)

                command.Parameters.AddWithValue("@id", id)
                command.Parameters.AddWithValue("@statusPagamento", statusPagamento)

                Try
                    connection.Open()
                    Dim rowsAffected As Integer = command.ExecuteNonQuery()
                    Return rowsAffected > 0
                Catch ex As Exception
                    Return False
                End Try
            End Using
        End Using
    End Function

End Class
