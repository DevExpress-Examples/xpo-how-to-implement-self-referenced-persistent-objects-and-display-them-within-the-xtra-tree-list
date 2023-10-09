Imports DevExpress.Xpo

Namespace SelfReferenced

    Public Class Employee
        Inherits XPObject

        Public Sub New(ByVal session As Session)
            MyBase.New(session)
        End Sub

        Private _FullName As String

        Public Property FullName As String
            Get
                Return _FullName
            End Get

            Set(ByVal value As String)
                SetPropertyValue("FullName", _FullName, value)
            End Set
        End Property

        Private _Title As String

        Public Property Title As String
            Get
                Return _Title
            End Get

            Set(ByVal value As String)
                SetPropertyValue("Title", _Title, value)
            End Set
        End Property

        Private _Manager As Employee

        <Association("ManagerSubordinates")>
        Public Property Manager As Employee
            Get
                Return _Manager
            End Get

            Set(ByVal value As Employee)
                SetPropertyValue("Manager", _Manager, value)
            End Set
        End Property

        <Association("ManagerSubordinates")>
        Public ReadOnly Property Subordinates As XPCollection(Of Employee)
            Get
                Return GetCollection(Of Employee)("Subordinates")
            End Get
        End Property
    End Class
End Namespace
