Imports Microsoft.VisualBasic

Public Class Inscrito
    Inherits Pessoas

    Public Sub New(nome As String, dataNascimento As Date, email As String, instagram As String)
        MyBase.New(nome, dataNascimento, email, instagram)
    End Sub
End Class
