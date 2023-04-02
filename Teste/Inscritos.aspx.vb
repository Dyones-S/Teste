Imports System.Activities.Statements
Imports System.Data
Imports System.Data.Common
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.Threading

Partial Class Inscritos
    Inherits System.Web.UI.Page

    Dim InscritoDAO As New InscritoDAO()

    Protected Sub CriarInscrito_Click(sender As Object, e As EventArgs) Handles btnAction.Click
        Dim tipo As String = Request.Form("tipo")
        Dim nome As String = Request.Form("nome")
        Dim nasc As String = Request.Form("nasc")
        Dim email As String = Request.Form("email")
        Dim instagram As String = Request.Form("instagram")

        If tipo > 0 Then    'Update
            Dim inscrito As New Inscrito(nome, nasc, email, instagram)

            Dim retorno = InscritoDAO.Update(inscrito, tipo)

            If retorno Then
                HttpContext.Current.Session("statusUpdate") = True
            End If

            Response.Redirect("Inscritos.aspx")

                Return


            Else 'Adicionar
                Dim inscrito As New Inscrito(nome, nasc, email, instagram)

            Dim retorno = InscritoDAO.Create(inscrito)
            If retorno Then
                HttpContext.Current.Session("statusAdd") = True
            End If

            Response.Redirect("Inscritos.aspx")

            Return

        End If

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim inscritos = InscritoDAO.GetAll()

        Dim html As String = ""

        If Not IsNothing(inscritos) Then

            For Each inscrito As DataRow In inscritos.Rows
                html &= "<tr>"
                html &= "<td class='id' >" & inscrito("Id") & "</td>"
                html &= "<td class='nome' >" & inscrito("Nome") & "</td>"
                html &= "<td class='data' >" & Convert.ToDateTime(inscrito("DataNascimento")).ToString("dd/MM/yyyy") & "</td>"
                html &= "<td class='email' >" & inscrito("Email") & "</td>"
                html &= "<td class='instagram' >" & inscrito("Instagram") & "</td>"
                html &= "<td class='acoes'>"
                html &= "<a href='#' class='editar' title='Editar'><i class='fa-regular fa-pen-to-square'></i></a>"
                html &= "<a href='#' class='excluir' title='Excluir'><i class='fa-regular fa-x'></i></a>"
                html &= "</td>"
                html &= "</tr>"
            Next
        End If

        ' Adiciona o HTML na tabela
        tabela_inscritos.InnerHtml = html

    End Sub



End Class
