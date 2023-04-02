Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient

Public Class InstrutorDAO
    Private Shared ReadOnly connectionString As String = ConfigurationManager.ConnectionStrings("CRUDLives").ConnectionString

    Public Shared Function Create(instrutor As Instrutor) As Boolean
        Dim query As String = "INSERT INTO Instrutor(Nome, DataNascimento, Email, Instagram) VALUES (@Nome, @DataNascimento, @Email, @Instagram)"
        Using connection As New SqlConnection(connectionString)
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@Nome", instrutor.Nome)
                command.Parameters.AddWithValue("@DataNascimento", instrutor.DataNascimento)
                command.Parameters.AddWithValue("@Email", instrutor.Email)
                command.Parameters.AddWithValue("@Instagram", instrutor.Instagram)
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

    Public Shared Function GetAll() As DataTable
        Dim query As String = "SELECT * FROM Instrutor where deleted_at IS NULL"
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

    Public Shared Function Update(instrutor As Instrutor, id As Integer) As Boolean
        Dim query As String = "UPDATE Instrutor SET Nome = @Nome, DataNascimento = @DataNascimento, Email = @Email, Instagram = @Instagram WHERE id = @id;"
        Using connection As New SqlConnection(connectionString)
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@Nome", instrutor.Nome)
                command.Parameters.AddWithValue("@DataNascimento", instrutor.DataNascimento)
                command.Parameters.AddWithValue("@Email", instrutor.Email)
                command.Parameters.AddWithValue("@Instagram", instrutor.Instagram)
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
        Dim query As String = "UPDATE Instrutor SET Deleted_at = GETDATE() WHERE id = @id;"
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

