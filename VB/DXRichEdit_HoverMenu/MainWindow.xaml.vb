#Region "#usings"
Imports System.Windows
Imports DevExpress.Xpf.Bars
Imports DevExpress.Xpf.RichEdit
Imports DevExpress.XtraRichEdit
Imports DevExpress.XtraRichEdit.Commands
Imports DevExpress.XtraRichEdit.Menu
Imports DevExpress.Xpf.RichEdit.Menu
#End Region ' #usings


Namespace DXRichEdit_HoverMenu
	''' <summary>
	''' Interaction logic for MainWindow.xaml
	''' </summary>
	Partial Public Class MainWindow
		Inherits Window

		Public Sub New()
			InitializeComponent()
			AddHandler richEditControl1.Loaded, AddressOf richEditControl1_Loaded
			AddHandler richEditControl1.HoverMenuShowing, AddressOf richEditControl1_HoverMenuShowing
		End Sub


		Private Sub richEditControl1_Loaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
			richEditControl1.LoadDocument("sample_document.docx", DocumentFormat.OpenXml)
		End Sub

		#Region "#hovermenushowing"
		Private Sub richEditControl1_HoverMenuShowing(ByVal sender As Object, ByVal e As HoverMenuShowingEventArgs)
			' Remove DecreaseIndent and IncreaseIndent command menu items.
			For i As Integer = 0 To e.Menu.ItemsCount - 1
				Dim bLink As BarItemLink = CType(e.Menu.ItemLinks(i), BarItemLink)
				Dim cmd As RichEditUICommand = CType(bLink.Item.Command, RichEditUICommand)
				If cmd.CommandId = RichEditCommandId.DecreaseIndent OrElse cmd.CommandId = RichEditCommandId.IncreaseIndent Then
					e.Menu.ItemLinks.Remove(bLink)
				End If
			Next i
			' Add a separator.
			Dim itemSep As New BarItemLinkSeparator()
			e.Menu.ItemLinks.Add(itemSep)
			' Create a new menu item and add it to the hover menu.
			Dim item1 As New RichEditMenuItem()
			item1.Content = "Replace Emoticon with Smiley"
			Dim cmd_toAdd As New MySmileyCommand(richEditControl1)
			item1.Command = cmd_toAdd
			item1.Glyph = cmd_toAdd.Glyph
			e.Menu.ItemLinks.Add(item1)
		End Sub
		#End Region ' #hovermenushowing
	End Class
End Namespace
