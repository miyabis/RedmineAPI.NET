
Public Class RedmineAPI

    Private _api As RestAPI

    Public Sub New(ByVal url As String, ByVal APIKey As String)
        _api = New RestAPI(url, APIKey)
    End Sub

    Public Function Projects() As Projects
        Return _api.Get(Of Projects)("projects")
    End Function

    Public Overloads Function Versions(ByVal proj As Project) As Versions
        Return Versions(proj.Identifier)
    End Function

    Public Overloads Function Versions(ByVal identifier As String) As Versions
        Return _api.Get(Of Versions)(String.Format("projects/{0}/versions", identifier))
    End Function

    Public Overloads Function Issues(ByVal proj As Project) As Issues
        Return Issues(proj.Identifier)
    End Function

    Public Overloads Function Issues(ByVal identifier As String) As Issues
        Return _api.Get(Of Issues)(String.Format("projects/{0}/issues", identifier))
    End Function

    Public Overloads Function Query(ByVal identifier As String, ByVal queryId As Integer) As Issues
        Return _api.Get(Of Issues)(String.Format("projects/{0}/issues", identifier), New With {.query_id = queryId})
    End Function

    Public Function IssueStatuses() As IssueStatuses
        Return _api.Get(Of IssueStatuses)("issue_statuses")
    End Function

    Public Overloads Function IssueCategories(ByVal proj As Project) As IssueCategories
        Return IssueCategories(proj.Identifier)
    End Function

    Public Overloads Function IssueCategories(ByVal identifier As String) As IssueCategories
        Return _api.Get(Of IssueCategories)(String.Format("projects/{0}/issue_categories", identifier))
    End Function

    Public Function Queries() As Queries
        Return _api.Get(Of Queries)("queries")
    End Function

    Public Function Trackers() As Trackers
        Return _api.Get(Of Trackers)("trackers")
    End Function

    Public Function Roles() As Roles
        Return _api.Get(Of Roles)("roles")
    End Function

    Public Overloads Function Memberships(ByVal proj As Project) As Memberships
        Return Memberships(proj.Identifier)
    End Function

    Public Overloads Function Memberships(ByVal identifier As String) As Memberships
        Return _api.Get(Of Memberships)(String.Format("projects/{0}/memberships", identifier))
    End Function

#Region " enumerations "

    Public Function IssuePriorities() As IssuePriorities
        Return _api.Get(Of IssuePriorities)("enumerations/issue_priorities")
    End Function

    Public Function TimeEntryActivities() As TimeEntryActivities
        Return _api.Get(Of TimeEntryActivities)("enumerations/time_entry_activities")
    End Function

    Public Function DocumentCategories() As DocumentCategories
        Return _api.Get(Of DocumentCategories)("enumerations/document_categories")
    End Function

#End Region

End Class
