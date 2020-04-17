#Region "#usingsincommands"
Imports System
Imports System.Drawing
Imports System.IO
Imports System.Reflection
Imports System.Windows.Input
Imports System.Windows.Media
Imports System.Windows.Media.Imaging
Imports DevExpress.XtraRichEdit
Imports DevExpress.XtraRichEdit.API.Native
#End Region ' #usingsincommands

Namespace DXRichEdit_HoverMenu
    Friend Class MySmileyCommand
        Implements ICommand


        Private ReadOnly control_Renamed As IRichEditControl

        Private ReadOnly glyph_Renamed As ImageSource
        Private ReadOnly smile As Image

        Public Sub New(ByVal control As IRichEditControl)
            Me.control_Renamed = control
            Me.glyph_Renamed = CreateImageSourceFromResx("smile.png")
            Me.smile = CreateImageFromResx("smile.png")
        End Sub


        Public ReadOnly Property Glyph() As ImageSource
            Get
                Return glyph_Renamed
            End Get
        End Property


        Private Function CreateImageSourceFromResx(ByVal name As String) As ImageSource
            Dim assembly As System.Reflection.Assembly = System.Reflection.Assembly.GetExecutingAssembly()
            Dim bi As New BitmapImage()
            Using stream As Stream = assembly.GetManifestResourceStream("DXRichEdit_HoverMenu.Images." & name)
                bi.BeginInit()
                bi.StreamSource = stream
                bi.EndInit()
            End Using
            Return CType(bi, ImageSource)
        End Function

        Private Function CreateImageFromResx(ByVal name As String) As Image
            Dim im As Image
            Dim assembly As System.Reflection.Assembly = System.Reflection.Assembly.GetExecutingAssembly()
            Using stream As Stream = assembly.GetManifestResourceStream("DXRichEdit_HoverMenu.Images." & name)
                im = Image.FromStream(stream)
            End Using
            Return im
        End Function

        Protected Friend ReadOnly Property Control() As IRichEditControl
            Get
                Return Me.control_Renamed
            End Get
        End Property


        Public Function CanExecute(ByVal parameter As Object) As Boolean Implements ICommand.CanExecute
            Return True
        End Function

        Public Custom Event CanExecuteChanged As EventHandler Implements ICommand.CanExecuteChanged
            AddHandler(ByVal value As EventHandler)
            End AddHandler
            RemoveHandler(ByVal value As EventHandler)
            End RemoveHandler
            RaiseEvent(ByVal sender As System.Object, ByVal e As System.EventArgs)
            End RaiseEvent
        End Event

        Public Sub Execute(ByVal parameter As Object) Implements ICommand.Execute
'            #Region "#findall"
    Dim doc As Document = Control.Document
    Dim range As DocumentRange = doc.Selection
    Dim smileyRanges() As DocumentRange = doc.FindAll(":-)", SearchOptions.WholeWord, range)
    For Each r As DocumentRange In smileyRanges
        doc.Delete(r)
                doc.Images.Insert(r.Start, smile)
            Next r
'            #End Region ' #findall
        End Sub

    End Class
End Namespace
