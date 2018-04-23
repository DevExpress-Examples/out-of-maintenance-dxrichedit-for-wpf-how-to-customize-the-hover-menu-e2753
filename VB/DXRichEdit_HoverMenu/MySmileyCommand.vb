Imports Microsoft.VisualBasic
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
        Private ReadOnly _control As IRichEditControl
        Private ReadOnly _glyph As ImageSource
        Private ReadOnly smile As Image

        Public Sub New(ByVal control As IRichEditControl)
            Me._control = control
            Me._glyph = CreateImageSourceFromResx("smile.png")
            Me.smile = CreateImageFromResx("smile.png")
        End Sub


        Public ReadOnly Property Glyph() As ImageSource
            Get
                Return _glyph
            End Get
        End Property


        Private Function CreateImageSourceFromResx(ByVal name As String) As ImageSource
            Dim _assembly As System.Reflection.Assembly = System.Reflection.Assembly.GetExecutingAssembly()
            Dim bi As BitmapImage = New BitmapImage()
            Using stream As Stream = _assembly.GetManifestResourceStream(name)
                bi.BeginInit()
                bi.StreamSource = stream
                bi.EndInit()
            End Using
            Return CType(bi, ImageSource)
        End Function

        Private Function CreateImageFromResx(ByVal name As String) As Image
            Dim im As Image
            Dim _assembly As System.Reflection.Assembly = System.Reflection.Assembly.GetExecutingAssembly()
            Using stream As Stream = _assembly.GetManifestResourceStream(name)
                im = Image.FromStream(stream)
            End Using
            Return im
        End Function

        Protected Friend ReadOnly Property Control() As IRichEditControl
            Get
                Return Me._control
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
    Dim smileyRanges As DocumentRange() = doc.FindAll(":-)", SearchOptions.WholeWord, range)
    For Each r As DocumentRange In smileyRanges
        doc.Delete(r)
        doc.InsertImage(r.Start, smile)
    Next r
'            #End Region ' #findall
        End Sub

    End Class
End Namespace
