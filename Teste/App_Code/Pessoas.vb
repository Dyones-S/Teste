Imports Microsoft.VisualBasic

Public Class Pessoas

    Public Property Nome As String
    Public Property DataNascimento As Date
    Public Property Email As String
    Public Property Instagram As String

    'Construtor
    Public Sub New(nome As String, dataNascimento As Date, email As String, Instagram As String)
        Me.Nome = nome
        Me.DataNascimento = dataNascimento
        Me.Email = email
        Me.Instagram = Instagram
    End Sub

End Class
