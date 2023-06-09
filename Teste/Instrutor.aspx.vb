﻿
Imports System.Activities.Statements
Imports System.Data
Imports System.Data.Common
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.Threading

Partial Class _Default
    Inherits System.Web.UI.Page

    Dim instrutorDAO As New InstrutorDAO()

    Protected Sub CriarInstrutor_Click(sender As Object, e As EventArgs) Handles btnAction.Click
        Dim tipo As String = Request.Form("tipo")
        Dim nome As String = Request.Form("nome")
        Dim nasc As String = Request.Form("nasc")
        Dim email As String = Request.Form("email")
        Dim instagram As String = Request.Form("instagram")

        If tipo > 0 Then    'Update
            Dim instrutor As New Instrutor(nome, nasc, email, instagram)

            Dim retorno = InstrutorDAO.Update(instrutor, tipo)
            If retorno Then
                HttpContext.Current.Session("statusUpdate") = True
            End If

            Response.Redirect("Instrutor.aspx")

            Return


        Else 'Adicionar
            Dim instrutor As New Instrutor(nome, nasc, email, instagram)

            Dim retorno = InstrutorDAO.Create(instrutor)
            If retorno Then
                HttpContext.Current.Session("statusAdd") = True
            End If

            Response.Redirect("Instrutor.aspx")

            Return

        End If

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim instrutores = InstrutorDAO.GetAll()

        Dim html As String = ""

        If Not IsNothing(instrutores) Then

            For Each instrutor As DataRow In instrutores.Rows
                html &= "<tr>"
                html &= "<td class='id' >" & instrutor("Id") & "</td>"
                html &= "<td class='nome' >" & instrutor("Nome") & "</td>"
                html &= "<td class='data' >" & Convert.ToDateTime(instrutor("DataNascimento")).ToString("dd/MM/yyyy") & "</td>"
                html &= "<td class='email' >" & instrutor("Email") & "</td>"
                html &= "<td class='instagram' >" & instrutor("Instagram") & "</td>"
                html &= "<td class='acoes'>"
                html &= "<a href='#' class='editar' title='Editar'><i class='fa-regular fa-pen-to-square'></i></a>"
                html &= "<a href='#' class='excluir' title='Excluir'><i class='fa-regular fa-x'></i></a>"
                html &= "</td>"
                html &= "</tr>"
            Next
        End If

        ' Adiciona o HTML na tabela
        tabela_instrutores.InnerHtml = html

    End Sub



End Class
