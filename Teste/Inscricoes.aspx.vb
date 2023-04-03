Imports System.Activities.Statements
Imports System.Data
Imports System.Data.Common
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.Drawing
Imports System.Threading

Partial Class Inscricoes
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim lives = LiveDAO.GetAllNotJoin()

        If Not IsNothing(lives) Then
            For Each live As DataRow In lives.Rows
                Dim item As New ListItem(live("Nome").ToString(), live("Id").ToString())
                If DateTime.Parse(live("DataInicio").ToString()) < DateTime.Now Then
                    item.Attributes.Add("class", "Realizada")
                    item.Attributes.Add("hidden", "true")
                End If
                liveId.Items.Add(item)
            Next
        End If

        Dim alunos = InscritoDAO.GetAll()

        If Not IsNothing(alunos) Then
            For Each aluno As DataRow In alunos.Rows
                Dim item As New ListItem(aluno("Nome").ToString(), aluno("Id").ToString())
                inscritoId.Items.Add(item)
            Next
        End If

        Dim inscricaos = InscricaoDAO.GetAll()

        Dim html As String = ""

        If Not IsNothing(inscricaos) Then

            For Each inscricao As DataRow In inscricaos.Rows
                html &= "<tr>"
                html &= "<td class='id' >" & inscricao("id") & "</td>"
                html &= "<td data-liveID='" & inscricao("liveID") & "' class='liveID' >" & inscricao("nomeLive") & "</td>"
                html &= "<td data-inscritoID='" & inscricao("inscritoID") & "' class='inscritoID' >" & inscricao("nomeInscrito") & "</td>"
                html &= "<td class='valor' >" & inscricao("valor") & "</td>"
                html &= "<td class='dataVencimento' >" & Convert.ToDateTime(inscricao("dataVencimento")).ToString("dd/MM/yyyy") & "</td>"
                html &= "<td> <span class='statusPagamento badge badge-pill " & If(inscricao("statusPagamento") = 1, "bg-success", "bg-warning text-dark") & "' >" & If(inscricao("statusPagamento") = 1, "PAGO", "PENDENTE") & "<span> </td>"
                html &= "<td class='acoes'>"
                html &= "<a href='#' class='editar' title='Editar'><i class='fa-regular fa-pen-to-square'></i></a>"
                html &= "<a href='#' class='excluir' title='Excluir'><i class='fa-regular fa-x'></i></a>"
                html &= "</td>"
                html &= "</tr>"
            Next
        End If

        ' Adiciona o HTML na tabela
        tabela_inscricoes.InnerHtml = html

    End Sub

    Protected Sub CriarInscricao_Click(sender As Object, e As EventArgs) Handles btnAction.Click
        Dim tipo As String = Request.Form("tipo")

        Dim liveID_ As Integer = Request.Form(liveId.UniqueID)
        Dim inscritoId_ As Integer = Request.Form(inscritoId.UniqueID)
        Dim valor As String = Request.Form("valor")
        Dim dataVencimento As Date = Request.Form("dataVencimento")
        Dim statusPagamento As Boolean = "0"

        Dim inscricao As New Inscricao(liveID_, inscritoId_, valor, dataVencimento, statusPagamento)

        If tipo > 0 Then    'Update
            Dim retorno = InscricaoDAO.Update(inscricao, tipo)

            If retorno Then
                HttpContext.Current.Session("statusUpdate") = True
            End If

            Response.Redirect("Inscricoes.aspx")

            Return


        Else 'Adicionar
            Dim retorno = InscricaoDAO.Create(inscricao)
            If retorno Then
                HttpContext.Current.Session("statusAdd") = True
            End If

            Response.Redirect("Inscricoes.aspx")

            Return

        End If

    End Sub


End Class
