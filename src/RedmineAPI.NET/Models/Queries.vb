﻿' Generated by Xamasoft JSON Class Generator
' http://www.xamasoft.com/json-class-generator

Imports System
Imports System.Collections.Generic
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Public Class Queries

    <JsonProperty("queries")>
    Public Property Queries As Query()

    <JsonProperty("total_count")>
    Public Property TotalCount As Integer

    <JsonProperty("offset")>
    Public Property Offset As Integer

    <JsonProperty("limit")>
    Public Property Limit As Integer

End Class
