Imports Microsoft.VisualBasic

Public Class Live
    Public Property nome As String
    Public Property Descricao As String
    Public Property Instrutor As Integer
    Public Property DataHora As DateTime
    Public Property DuracaoMin As Integer
    Public Property ValorInscricao As Decimal

    Public Sub New(nome As String, descricao As String, instrutor As Integer, dataHora As DateTime, duracaoMin As Integer, valorInscricao As Decimal)
        Me.nome = nome
        Me.Descricao = descricao
        Me.Instrutor = instrutor
        Me.DataHora = dataHora
        Me.DuracaoMin = duracaoMin
        Me.ValorInscricao = valorInscricao

    End Sub

End Class
