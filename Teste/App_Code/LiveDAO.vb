Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic

Public Class LiveDAO
    Private Shared ReadOnly connectionString As String = ConfigurationManager.ConnectionStrings("CRUDLives").ConnectionString

    Public Shared Function GetAll() As DataTable
        Dim query As String = "SELECT * FROM Live LEFT JOIN Instrutor on Instrutor.Id = Live.InstrutorId WHERE Instrutor.deleted_at IS NULL AND Live.deleted_at IS NULL"
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

    Public Shared Function GetAllNotJoin() As DataTable
        Dim query As String = "SELECT * FROM Live WHERE Live.deleted_at IS NULL"
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

    Public Shared Function Create(live As Live) As Boolean
        Dim query As String = "INSERT INTO Live(Nome, Descricao, InstrutorId, DataInicio, DuracaoMinutos, ValorInscricao) VALUES (@Nome, @desc, @inst, @data, @duracao, @valor)"
        Using connection As New SqlConnection(connectionString)

            Using command As New SqlCommand(query, connection)
                Dim dataHora As DateTime = live.DataHora
                command.Parameters.AddWithValue("@Nome", live.nome)
                command.Parameters.AddWithValue("@desc", live.Descricao)
                command.Parameters.AddWithValue("@inst", live.Instrutor)
                command.Parameters.AddWithValue("@data", dataHora)
                command.Parameters.AddWithValue("@duracao", live.DuracaoMin)
                command.Parameters.AddWithValue("@valor", live.ValorInscricao)
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

    Public Shared Function Update(live As Live, id As Integer) As Boolean
        Dim query As String = "UPDATE Live SET Nome = @Nome, Descricao = @desc, InstrutorId = @inst, DataInicio = @data, DuracaoMinutos = @duracao, ValorInscricao = @valor WHERE id = @id;"
        Using connection As New SqlConnection(connectionString)
            Using command As New SqlCommand(query, connection)
                Dim dataHora As DateTime = live.DataHora
                command.Parameters.AddWithValue("@Nome", live.nome)
                command.Parameters.AddWithValue("@desc", live.Descricao)
                command.Parameters.AddWithValue("@inst", live.Instrutor)
                command.Parameters.AddWithValue("@data", dataHora)
                command.Parameters.AddWithValue("@duracao", live.DuracaoMin)
                command.Parameters.AddWithValue("@valor", live.ValorInscricao)
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


    Public Shared Function Delete(id As Integer) As Boolean
        Dim query As String = "UPDATE Live SET Deleted_at = GETDATE() WHERE id = @id;"
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

End Class
