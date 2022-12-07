Imports Microsoft.VisualBasic
Imports DevExpress.Web
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls

Partial Public Class _Default
	Inherits System.Web.UI.Page
	Protected Sub Page_Init(ByVal sender As Object, ByVal e As EventArgs)
		CreateGridView()
	End Sub

	Private Sub CreateGridView()
		Dim grid As ASPxGridView = New ASPxGridView With {.ID = "grid", .DataSource = sds, .KeyFieldName = "ProductID", .ClientInstanceName = "grid", .EnableRowsCache = False}
		grid.SettingsPager.AlwaysShowPager = True
		AddHandler grid.Load, AddressOf grid_Load
		AddHandler grid.CustomCallback, AddressOf grid_CustomCallback
		AddHandler grid.CustomJSProperties, AddressOf grid_CustomJSProperties
		grid.Templates.PagerBar = LoadTemplate("CustomPager.ascx")
		Page.Form.Controls.Add(grid)
		grid.DataBind()
	End Sub
	Protected Sub grid_Load(ByVal sender As Object, ByVal e As EventArgs)
		Dim grid As ASPxGridView = TryCast(sender, ASPxGridView)
		Dim position As String = String.Empty
		If cbPagerPosition.Value IsNot Nothing Then
			position = cbPagerPosition.Value.ToString()
		End If
		Select Case position
			Case "PosTop"
				grid.SettingsPager.Position = PagerPosition.Top
			Case "PosBoth"
				grid.SettingsPager.Position = PagerPosition.TopAndBottom
			Case Else
				grid.SettingsPager.Position = PagerPosition.Bottom
		End Select
	End Sub

	Protected Sub grid_CustomCallback(ByVal sender As Object, ByVal e As ASPxGridViewCustomCallbackEventArgs)
		Dim grid As ASPxGridView = TryCast(sender, ASPxGridView)
		Dim newPageSize As Integer
		If e IsNot Nothing Then
			If (Not Integer.TryParse(e.Parameters, newPageSize)) Then
				Return
			End If
			grid.SettingsPager.PageSize = newPageSize
		End If
	End Sub
	Protected Sub grid_CustomJSProperties(ByVal sender As Object, ByVal e As ASPxGridViewClientJSPropertiesEventArgs)
		Dim grid As ASPxGridView = TryCast(sender, ASPxGridView)
		e.Properties("cpPageSize") = grid.SettingsPager.PageSize
	End Sub
End Class