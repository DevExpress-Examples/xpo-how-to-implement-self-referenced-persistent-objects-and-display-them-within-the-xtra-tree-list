Imports Microsoft.VisualBasic
Imports System
Namespace SelfReferenced
	Partial Public Class Form1
		''' <summary>
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.IContainer = Nothing

		''' <summary>
		''' Clean up any resources being used.
		''' </summary>
		''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing AndAlso (components IsNot Nothing) Then
				components.Dispose()
			End If
			MyBase.Dispose(disposing)
		End Sub

		#Region "Windows Form Designer generated code"

		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.treeList1 = New DevExpress.XtraTreeList.TreeList()
			Me.colFullName = New DevExpress.XtraTreeList.Columns.TreeListColumn()
			Me.colTitle = New DevExpress.XtraTreeList.Columns.TreeListColumn()
			Me.xpCollection1 = New DevExpress.Xpo.XPCollection()
			Me.unitOfWork1 = New DevExpress.Xpo.UnitOfWork()
			CType(Me.treeList1, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.xpCollection1, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.unitOfWork1, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' treeList1
			' 
			Me.treeList1.Columns.AddRange(New DevExpress.XtraTreeList.Columns.TreeListColumn() { Me.colFullName, Me.colTitle})
			Me.treeList1.Dock = System.Windows.Forms.DockStyle.Fill
			Me.treeList1.Location = New System.Drawing.Point(0, 0)
			Me.treeList1.Name = "treeList1"
			Me.treeList1.OptionsBehavior.DragNodes = True
			Me.treeList1.Size = New System.Drawing.Size(462, 332)
			Me.treeList1.TabIndex = 0
			' 
			' colFullName
			' 
			Me.colFullName.Caption = "FullName"
			Me.colFullName.FieldName = "FullName"
			Me.colFullName.Name = "colFullName"
			Me.colFullName.Visible = True
			Me.colFullName.VisibleIndex = 0
			Me.colFullName.Width = 162
			' 
			' colTitle
			' 
			Me.colTitle.Caption = "Title"
			Me.colTitle.FieldName = "Title"
			Me.colTitle.Name = "colTitle"
			Me.colTitle.Visible = True
			Me.colTitle.VisibleIndex = 1
			Me.colTitle.Width = 279
			' 
			' xpCollection1
			' 
			Me.xpCollection1.ObjectType = GetType(SelfReferenced.Employee)
			Me.xpCollection1.Session = Me.unitOfWork1
			' 
			' Form1
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(462, 332)
			Me.Controls.Add(Me.treeList1)
			Me.Name = "Form1"
			Me.Text = "Form1"
'			Me.Load += New System.EventHandler(Me.Form1_Load);
'			Me.FormClosing += New System.Windows.Forms.FormClosingEventHandler(Me.Form1_FormClosing);
			CType(Me.treeList1, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.xpCollection1, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.unitOfWork1, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub

		#End Region

		Private treeList1 As DevExpress.XtraTreeList.TreeList
		Private unitOfWork1 As DevExpress.Xpo.UnitOfWork
		Private xpCollection1 As DevExpress.Xpo.XPCollection
		Private colFullName As DevExpress.XtraTreeList.Columns.TreeListColumn
		Private colTitle As DevExpress.XtraTreeList.Columns.TreeListColumn
	End Class
End Namespace

