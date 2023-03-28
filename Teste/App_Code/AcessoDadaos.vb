
Imports System

Imports System.Data

Imports System.Data.Common


Public NotInheritable Class AcessoDados


    Private Sub New()

    End Sub


    Shared Sub New()

    End Sub


    Public Shared Function ExecuteReader(ByVal command As DbCommand) As DataTable

        Dim table As DataTable

        Try

            command.Connection.Open()

            Dim reader As DbDataReader = command.ExecuteReader()

            table = New DataTable()

            table.Load(reader)

        Catch ex As Exception

            Throw ex

        Finally

            command.Connection.Close()

        End Try

        Return table

    End Function



    'Cria um commando

    Public Shared Function CreateCommand() As DbCommand

        Try

            Dim dbProviderName As String = Configuracao.DbProviderName

            Dim dbConnectionString As String = Configuracao.DbConnectionString

            Dim factory As DbProviderFactory = DbProviderFactories.GetFactory(dbProviderName)

            Dim connection As DbConnection = factory.CreateConnection()

            connection.ConnectionString = dbConnectionString

            Dim command As DbCommand = connection.CreateCommand()

            command.CommandType = CommandType.StoredProcedure

            Return command

        Catch ex As Exception

            Throw ex

        End Try

    End Function



    Public Shared Function ExecuteNoneQuery(ByVal command As DbCommand) As Integer

        Dim linhasAfetadas As Integer = -1

        Try

            command.Connection.Open()

            linhasAfetadas = command.ExecuteNonQuery()

        Catch ex As Exception

            Throw ex

        Finally

            command.Connection.Close()

        End Try

        Return linhasAfetadas

    End Function



    Public Shared Function ExecuteScalar(ByVal command As DbCommand) As String

        Dim valor As String = ""

        Try

            command.Connection.Open()

            valor = command.ExecuteScalar().ToString()

        Catch ex As Exception

            Throw ex

        Finally

            command.Connection.Close()

        End Try

        Return valor

    End Function


End Class