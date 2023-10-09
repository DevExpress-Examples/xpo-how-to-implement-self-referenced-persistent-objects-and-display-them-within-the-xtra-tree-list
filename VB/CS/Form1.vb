Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports DevExpress.Xpo
Imports DevExpress.Xpo.DB

Namespace SelfReferenced

    Public Partial Class Form1
        Inherits Form

        Public Sub New()
            XpoDefault.DataLayer = XpoDefault.GetDataLayer(AutoCreateOption.DatabaseAndSchema)
            CreateDefaultData()
            InitializeComponent()
        End Sub

        Private Sub CreateDefaultData()
            Using uow As UnitOfWork = New UnitOfWork()
                If uow.FindObject(Of Employee)(Nothing) IsNot Nothing Then Return
                Dim AndrewFuller As Employee = New Employee(uow)
                AndrewFuller.FullName = "Andrew Fuller"
                AndrewFuller.Title = "Vice President, Sales"
                Dim NancyDavolio As Employee = New Employee(uow)
                NancyDavolio.FullName = "Nancy Davolio"
                NancyDavolio.Title = "Sales Representative"
                NancyDavolio.Manager = AndrewFuller
                Dim JanetLeverling As Employee = New Employee(uow)
                JanetLeverling.FullName = "Janet Leverling"
                JanetLeverling.Title = "Sales Representative"
                JanetLeverling.Manager = AndrewFuller
                Dim MargaretPeacock As Employee = New Employee(uow)
                MargaretPeacock.FullName = "Margaret Peacock"
                MargaretPeacock.Title = "Sales Representative"
                MargaretPeacock.Manager = AndrewFuller
                Dim StevenBuchanan As Employee = New Employee(uow)
                StevenBuchanan.FullName = "Steven Buchanan"
                StevenBuchanan.Title = "Sales Manager"
                StevenBuchanan.Manager = AndrewFuller
                Dim MichaelSuyama As Employee = New Employee(uow)
                MichaelSuyama.FullName = "Michael Suyama"
                MichaelSuyama.Title = "Sales Representative"
                MichaelSuyama.Manager = StevenBuchanan
                Dim RobertKing As Employee = New Employee(uow)
                RobertKing.FullName = "Robert King"
                RobertKing.Title = "Sales Representative"
                RobertKing.Manager = StevenBuchanan
                Dim LauraCallahan As Employee = New Employee(uow)
                LauraCallahan.FullName = "Laura Callahan"
                LauraCallahan.Title = "Inside Sales Coordinator"
                LauraCallahan.Manager = AndrewFuller
                Dim AnneDodsworth As Employee = New Employee(uow)
                AnneDodsworth.FullName = "Anne Dodsworth"
                AnneDodsworth.Title = "Sales Representative"
                AnneDodsworth.Manager = StevenBuchanan
                uow.CommitChanges()
            End Using
        End Sub

        Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs)
            treeList1.KeyFieldName = "This"
            treeList1.ParentFieldName = "Manager!"
            treeList1.RootValue = Nothing
            treeList1.DataSource = xpCollection1
            treeList1.ExpandAll()
        End Sub

        Private Sub Form1_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs)
            If unitOfWork1.InTransaction Then unitOfWork1.CommitChanges()
        End Sub
    End Class
End Namespace
