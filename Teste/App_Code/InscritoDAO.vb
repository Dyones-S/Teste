Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic

Public Class InscritoDAO
    Private Shared ReadOnly connectionString As String = ConfigurationManager.ConnectionStrings("CRUDLives").ConnectionString

    Public Shared Function Create(inscrito As Inscrito) As Boolean
        Dim query As String = "INSERT INTO Inscrito(Nome, DataNascimento, Email, Instagram) VALUES (@Nome, @DataNascimento, @Email, @Instagram)"
        Using connection As New SqlConnection(connectionString)
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@Nome", inscrito.Nome)
                command.Parameters.AddWithValue("@DataNascimento", inscrito.DataNascimento)
                command.Parameters.AddWithValue("@Email", inscrito.Email)
                command.Parameters.AddWithValue("@Instagram", inscrito.Instagram)
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
        Dim query As String = "SELECT * FROM Inscrito WHERE deleted_at IS NULL"
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

    Public Shared Function Update(Inscrito As Inscrito, id As Integer) As Boolean
        Dim query As String = "UPDATE Inscrito SET Nome = @Nome, DataNascimento = @DataNascimento, Email = @Email, Instagram = @Instagram WHERE id = @id;"
        Using connection As New SqlConnection(connectionString)
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@Nome", Inscrito.Nome)
                command.Parameters.AddWithValue("@DataNascimento", Inscrito.DataNascimento)
                command.Parameters.AddWithValue("@Email", Inscrito.Email)
                command.Parameters.AddWithValue("@Instagram", Inscrito.Instagram)
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
        Dim query As String = "UPDATE Inscrito SET Deleted_at = GETDATE() WHERE id = @id;"
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
