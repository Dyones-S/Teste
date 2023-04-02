Imports Microsoft.VisualBasic

Public Class Inscricao

    Public Property liveID As Integer
    Public Property inscritoID As Integer
    Public Property valor As Decimal
    Public Property dataVencimento As Date
    Public Property statusPagamento As Boolean

    Public Sub New(liveID As Integer, inscritoID As Integer, valor As Decimal, dataVencimento As Date, statusPagamento As Boolean)
        Me.liveID = liveID
        Me.inscritoID = inscritoID
        Me.valor = valor
        Me.dataVencimento = dataVencimento
        Me.statusPagamento = statusPagamento
    End Sub

End Class
