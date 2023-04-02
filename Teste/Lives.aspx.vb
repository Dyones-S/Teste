Imports System.Activities.Statements
Imports System.Data
Imports System.Data.Common
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.Net
Imports System.Threading

Partial Class Lives
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim instrutores = InstrutorDAO.GetAll()

        If Not IsNothing(instrutores) Then
            For Each instrutor As DataRow In instrutores.Rows
                Dim item As New ListItem(instrutor("Nome").ToString(), instrutor("Id").ToString())
                inst.Items.Add(item)
            Next
        End If

        Dim lives = LiveDAO.GetAll()

        Dim html As String = ""

        If Not IsNothing(lives) Then

            For Each live As DataRow In lives.Rows
                html &= "<tr>"
                html &= "<td class='id' >" & live("Id") & "</td>"
                html &= "<td class='nome' >" & live("Nome") & "</td>"
                html &= "<td class='descricao' >" & live("Descricao") & "</td>"
                html &= "<td data-idInstrutor='" & live("instrutorId") & "' class='instrutor' >" & live("Nome1") & "</td>"
                html &= "<td class='data' >" & Convert.ToDateTime(live("DataInicio")).ToString("dd/MM/yyyy hh:mm:ss") & "</td>"
                html &= "<td class='duracaoMinutos' >" & live("DuracaoMinutos") & "</td>"
                html &= "<td class='valorInscricao' >" & live("ValorInscricao") & "</td>"
                html &= "<td class='acoes'>"
                html &= "<a href='#' class='editar' title='Editar'><i class='fa-regular fa-pen-to-square'></i></a>"
                html &= "<a href='#' class='excluir' title='Excluir'><i class='fa-regular fa-x'></i></a>"
                html &= "</td>"
                html &= "</tr>"
            Next
        End If

        ' Adiciona o HTML na tabela
        tabela_lives.InnerHtml = html

    End Sub

    Protected Sub cadastrarE_Click(sender As Object, e As EventArgs) Handles btnAction.Click

        Dim tipo As String = Request.Form("tipo")
        Dim nome As String = Request.Form("nome")
        Dim desc As String = Request.Form("desc")
        Dim instrutorId As String = Request.Form(inst.UniqueID)
        Dim dataInicio As DateTime = Convert.ToDateTime(Request.Form("data"))
        Dim duracao As Integer = Convert.ToInt32(Request.Form("duracao"))
        Dim valor As Double = Convert.ToDouble(Request.Form("valor"))

        Dim live As New Live(nome, desc, instrutorId, dataInicio, duracao, valor)



        If tipo > 0 Then    'Update

            Dim retorno = LiveDAO.Update(live, tipo)

            If retorno Then
                HttpContext.Current.Session("statusUpdate") = True
            End If

            Response.Redirect("Lives.aspx")

            Return
        Else 'Adicionar


            Dim retorno = LiveDAO.Create(live)

            If retorno Then
                HttpContext.Current.Session("statusAdd") = True
            End If

            Response.Redirect("Lives.aspx")

            Return

        End If
    End Sub




End Class
