<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128586024/13.1.4%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E744)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
[![](https://img.shields.io/badge/💬_Leave_Feedback-feecdd?style=flat-square)](#does-this-example-address-your-development-requirementsobjectives)
<!-- default badges end -->

# XPO - How to implement self-referenced persistent objects and display them within the XtraTreeList

This example demostrates how to implement self-referenced persistent objects and display them within the XtraTreeList. A simple example of a self-referenced object is an Employee. An employee reports to a Manager, but at the same time, this employee might also be a manager for other employers, referred to as Subordinates.

A self-referenced object has a parent object property and a child collection. Here is the persistent Employee class. It has a Manager property of type Employee and Subordinates of type `XPCollection<Employee>`. Both properties are decorated with the `Association` attribute. As such, the Employee type appears on both sides of a one-to-many association.  

**C#**
```cs  
using DevExpress.Xpo;  

public class Employee : XPObject {  
    public Employee(Session session) : base(session) { }  

    string _FullName;  
    public string FullName {  
        get { return _FullName; }  
        set { SetPropertyValue("FullName", ref _FullName, value); }  
    }  

    private string _Title;  
    public string Title {  
        get { return _Title; }  
        set { SetPropertyValue("Title", ref _Title, value); }  
    }  

    Employee _Manager;  
    [Association("ManagerSubordinates")]  
    public Employee Manager {  
        get { return _Manager; }  
        set { SetPropertyValue("Manager", ref _Manager, value); }  
    }  

    [Association("ManagerSubordinates")]  
    public XPCollection<Employee> Subordinates {  
        get { return GetCollection<Employee>("Subordinates"); }  
    }  
}  
```  
**VB**  
```vb  
Imports DevExpress.Xpo  

Public Class Employee  
    Inherits XPObject  
    Public Sub New(ByVal session As Session)  
        MyBase.New(session)  
    End Sub  

    Private _FullName As String  
    Public Property FullName() As String  
        Get  
            Return _FullName  
        End Get  
        Set(ByVal value As String)  
            SetPropertyValue("FullName", _FullName, value)  
        End Set  
    End Property  

    Private _Title As String  
    Public Property Title() As String  
        Get  
            Return _Title  
        End Get  
        Set(ByVal value As String)  
            SetPropertyValue("Title", _Title, value)  
        End Set  
    End Property  

    Private _Manager As Employee  
    <Association("ManagerSubordinates")> _  
    Public Property Manager() As Employee  
        Get  
            Return _Manager  
        End Get  
        Set(ByVal value As Employee)  
            SetPropertyValue("Manager", _Manager, value)  
        End Set  
    End Property  

    <Association("ManagerSubordinates")> _  
    Public ReadOnly Property Subordinates() As XPCollection(Of Employee)  
        Get  
            Return GetCollection(Of Employee)("Subordinates")  
        End Get  
    End Property  
End Class  
```  
  
A collection of self-referenced objects can be displayed in the XtraTreeList. TreeList properties must be set as shown below.  
**C#**  
```cs  
treeList1.KeyFieldName = "This";  
treeList1.ParentFieldName = "Manager!";  
treeList1.RootValue = null;  
treeList1.DataSource = xpCollection1;  
```  
**VB**    
```vb  
treeList1.KeyFieldName = "This"  
treeList1.ParentFieldName = "Manager!"  treeList1.RootValue = Nothing  
treeList1.DataSource = xpCollection1  
```  
## Files to Review
* [Employee.cs](./CS/CS/Employee.cs) (VB: [Employee.vb](./VB/CS/Employee.vb))
* [Form1.cs](./CS/CS/Form1.cs) (VB: [Form1.vb](./VB/CS/Form1.vb))
  
## Documentation
* [One to Many Relations](https://docs.devexpress.com/XPO/2257/getting-started/tutorial-2-relations-one-to-many?v=19.2) 
* [Tree Generation Algorithm in the XtraTreeList](https://docs.devexpress.com/WindowsForms/198/controls-and-libraries/tree-list/feature-center/data-binding/tree-generation-algorithm-in-the-tree-list)
## More Examples
* [Specifics of binding to properties of type persistent object](https://supportcenter.devexpress.com/ticket/details/a2783/specifics-of-binding-to-properties-of-type-persistent-object)  


<!-- feedback -->
## Does this example address your development requirements/objectives?

[<img src="https://www.devexpress.com/support/examples/i/yes-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=xpo-how-to-implement-self-referenced-persistent-objects-and-display-them-within-the-xtra-tree-list&~~~was_helpful=yes) [<img src="https://www.devexpress.com/support/examples/i/no-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=xpo-how-to-implement-self-referenced-persistent-objects-and-display-them-within-the-xtra-tree-list&~~~was_helpful=no)

(you will be redirected to DevExpress.com to submit your response)
<!-- feedback end -->
