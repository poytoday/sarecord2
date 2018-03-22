﻿
Partial Class Report_name_work_wait
    Inherits System.Web.UI.Page
    Protected Sub GridView1_RowCommand(ByVal source As Object, ByVal e As GridViewCommandEventArgs)
        Me.GridView2.Visible = True
        Me.Label2.Visible = True
        If e.CommandName = "Page" OrElse e.CommandName = "Sort" Then Exit Sub

        Dim index As Integer = Convert.ToInt32(e.CommandArgument)
        Dim dkKeys As DataKey
        'If Me.GridView1.Visible = True Then

        dkKeys = GridView1.DataKeys(index)
        'Else
        '    'dkKeys = dbGrid_upload.DataKeys(index)
        'End If


        Dim sKeysArg As String = ""
        For Each s As String In dkKeys.Values.Keys
            sKeysArg += s + "='" + Convert.ToString(dkKeys(s)) & "'"
        Next s
        If sKeysArg = String.Empty Then
            Exit Sub
        End If

        If e.CommandName = "cmd_name" Then

            Me.SqlDataSource3.SelectCommand = func.SqlBuilder(SqlDataSource3.SelectCommand, "2=2 and " & sKeysArg)
            Me.SqlDataSource3.DataBind()
            Me.GridView2.DataBind()

            'Response.Redirect("Edit_Bu.aspx?" + sKeysArg)
        End If
    End Sub
    Protected Sub GridView2_RowCommand(ByVal source As Object, ByVal e As GridViewCommandEventArgs)
        If e.CommandName = "Page" OrElse e.CommandName = "Sort" Then Exit Sub

        Dim index As Integer = Convert.ToInt32(e.CommandArgument)
        Dim dkKeys As DataKey
        'If Me.GridView1.Visible = True Then

        dkKeys = GridView2.DataKeys(index)
        'Else
        '    'dkKeys = dbGrid_upload.DataKeys(index)
        'End If


        Dim sKeysArg As String = ""
        For Each s As String In dkKeys.Values.Keys
            sKeysArg += s + "='" + Convert.ToString(dkKeys(s)) & "'"
        Next s
        If sKeysArg = String.Empty Then
            Exit Sub
        End If

        If e.CommandName = "cmdEdit" Then
            Dim sStartPageURL As String = ""
            sStartPageURL = "Edit_work.aspx?pmcm_id=" & Convert.ToString(dkKeys(0)) & "&id_team=" & Convert.ToString(dkKeys(1))
            Response.Redirect(sStartPageURL)
        End If
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        UserClass.CheckLogin(Page)
        If Not func.CheckUserPermissions_access("Report_name_work_wait.aspx", Session("User_access")) Then
            Response.Write("<p>" + "You don't have permissions to access this page" + "<a href=""login.aspx"">&nbsp;" + "Back to login page" + "</a></p>")
            Response.End()
        Else
            Dim UserLogin As UserClass = CType(Session("User"), UserClass)
        End If



        'UserClass.CheckLogin(Page)
        'If Not func.CheckUserPermissions("Report_name_work_wait.aspx", "S") Then
        '    Response.Write("<p>" + "You don't have permissions to access this page" + "<a href=""login.aspx"">&nbsp;" + "Back to login page" + "</a></p>")
        '    Response.End()
        'Else
        '    Dim UserLogin As UserClass = CType(Session("User"), UserClass)
        '    'UserClass.login_page(UserLogin.UserName, "Damage.aspx", "View")

        'End If
    End Sub
End Class