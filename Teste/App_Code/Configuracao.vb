
Imports System.Configuration

Public NotInheritable Class Configuracao



    Private Sub New()

    End Sub


    Private Shared m_dbConnectionString As String

    Private Shared m_dbProviderName As String


    Shared Sub New()

        m_dbConnectionString = ConfigurationManager.ConnectionStrings("SQLConnectionString").ConnectionString

        m_dbProviderName = ConfigurationManager.ConnectionStrings("SQLConnectionString").ProviderName

    End Sub


    Public Shared ReadOnly Property DbConnectionString() As String

        Get

            Return m_dbConnectionString

        End Get

    End Property


    Public Shared ReadOnly Property DbProviderName() As String

        Get

            Return m_dbProviderName

        End Get

    End Property


End Class