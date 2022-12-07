Imports Microsoft.VisualBasic
Imports DevExpress.Web
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls

Partial Public Class CustomPager
	Inherits System.Web.UI.UserControl
	Implements ITemplate
	Protected Sub cbPage_Init(ByVal sender As Object, ByVal e As EventArgs)
		Dim cb As ASPxComboBox = TryCast(sender, ASPxComboBox)
		Dim grid As ASPxGridView = GetParentGrid(cb)
		For i As Integer = 1 To grid.PageCount
			cb.Items.Add(i.ToString(), i)
		Next i
	End Sub
	Protected Sub cbRecords_Init(ByVal sender As Object, ByVal e As EventArgs)
		Dim values() As Int32 = { 10, 25, 50, 100 }
		Dim cb As ASPxComboBox = TryCast(sender, ASPxComboBox)
		For i As Integer = 0 To values.Length - 1
			cb.Items.Add(values(i).ToString(), values(i))
		Next i
	End Sub
	Protected Function GetParentGrid(ByVal cb As ASPxComboBox) As ASPxGridView
		Dim container As GridViewPagerBarTemplateContainer = CType(cb.NamingContainer.NamingContainer, GridViewPagerBarTemplateContainer)
		Return container.Grid
	End Function
	Public Sub InstantiateIn(ByVal container As Control) Implements ITemplate.InstantiateIn
	End Sub
End Class