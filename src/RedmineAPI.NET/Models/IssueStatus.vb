﻿' Generated by Xamasoft JSON Class Generator
' http://www.xamasoft.com/json-class-generator

Imports System
Imports System.Collections.Generic
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Public Class IssueStatus

    <JsonProperty("id")>
    Public Property Id As Integer

    <JsonProperty("name")>
    Public Property Name As String

    <JsonProperty("is_default")>
    Public Property IsDefault As Boolean

    <JsonProperty("is_closed")>
    Public Property IsClosed As Boolean?

End Class
