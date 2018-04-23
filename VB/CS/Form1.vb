Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports DevExpress.Xpo
Imports DevExpress.Xpo.DB
Imports DevExpress.Data.Filtering

Namespace SelfReferenced
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			XpoDefault.DataLayer = XpoDefault.GetDataLayer(AutoCreateOption.DatabaseAndSchema)
			CreateDefaultData()

			InitializeComponent()
		End Sub

		Private Sub CreateDefaultData()
			Using uow As New UnitOfWork()
				If uow.FindObject(Of Employee)(Nothing) IsNot Nothing Then
					Return
				End If

				Dim AndrewFuller As New Employee(uow)
				AndrewFuller.FullName = "Andrew Fuller"
				AndrewFuller.Title = "Vice President, Sales"

				Dim NancyDavolio As New Employee(uow)
				NancyDavolio.FullName = "Nancy Davolio"
				NancyDavolio.Title = "Sales Representative"
				NancyDavolio.Manager = AndrewFuller

				Dim JanetLeverling As New Employee(uow)
				JanetLeverling.FullName = "Janet Leverling"
				JanetLeverling.Title = "Sales Representative"
				JanetLeverling.Manager = AndrewFuller

				Dim MargaretPeacock As New Employee(uow)
				MargaretPeacock.FullName = "Margaret Peacock"
				MargaretPeacock.Title = "Sales Representative"
				MargaretPeacock.Manager = AndrewFuller

				Dim StevenBuchanan As New Employee(uow)
				StevenBuchanan.FullName = "Steven Buchanan"
				StevenBuchanan.Title = "Sales Manager"
				StevenBuchanan.Manager = AndrewFuller

				Dim MichaelSuyama As New Employee(uow)
				MichaelSuyama.FullName = "Michael Suyama"
				MichaelSuyama.Title = "Sales Representative"
				MichaelSuyama.Manager = StevenBuchanan

				Dim RobertKing As New Employee(uow)
				RobertKing.FullName = "Robert King"
				RobertKing.Title = "Sales Representative"
				RobertKing.Manager = StevenBuchanan

				Dim LauraCallahan As New Employee(uow)
				LauraCallahan.FullName = "Laura Callahan"
				LauraCallahan.Title = "Inside Sales Coordinator"
				LauraCallahan.Manager = AndrewFuller

				Dim AnneDodsworth As New Employee(uow)
				AnneDodsworth.FullName = "Anne Dodsworth"
				AnneDodsworth.Title = "Sales Representative"
				AnneDodsworth.Manager = StevenBuchanan

				uow.CommitChanges()
			End Using
		End Sub

		Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
			treeList1.KeyFieldName = "This"
			treeList1.ParentFieldName = "Manager!"
			treeList1.RootValue = Nothing
			treeList1.DataSource = xpCollection1

			treeList1.ExpandAll()
		End Sub

		Private Sub Form1_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing
			If unitOfWork1.InTransaction Then
				unitOfWork1.CommitChanges()
			End If
		End Sub
	End Class
End Namespace