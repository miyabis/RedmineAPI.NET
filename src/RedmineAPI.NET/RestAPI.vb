
Imports System.IO
Imports System.Net
Imports System.Text
Imports Newtonsoft.Json

Public Class RestAPI

    Public Sub New(ByVal url As String, ByVal APIKey As String)
        _URL = url
        _APIKey = APIKey
        ' プロキシの設定 IEの設定を使用する
        WebRequest.DefaultWebProxy = WebRequest.GetSystemWebProxy()
    End Sub

    Public ReadOnly Property URL As String

    Public ReadOnly Property APIKey As String

    Public Property Enc As Encoding = Encoding.GetEncoding("UTF-8")

    Public Function [Get](Of T)(ByVal command As String) As T
        Return [Get](Of T)(command, Nothing)
    End Function

    Public Function [Get](Of T)(ByVal command As String, ByVal param As Object) As T
        Dim sbParam As New StringBuilder()

        If param IsNot Nothing Then
            For Each prop As Reflection.PropertyInfo In param.GetType().GetProperties()
                If Not sbParam.ToString().Length.Equals(0) Then
                    sbParam.Append("&")
                End If
                sbParam.AppendFormat("{0}={1}", prop.Name, prop.GetValue(param))
            Next
            If Not sbParam.ToString().Length.Equals(0) Then
                sbParam.Insert(0, "&")
            End If
        End If

        Dim value As String
        value = String.Format("{0}{1}.json?key={2}{3}", URL, command, APIKey, sbParam.ToString())
        Debug.Print(value)
        Try
            Dim req As HttpWebRequest = WebRequest.Create(value)
            'req.AutomaticDecompression = DecompressionMethods.GZip Or DecompressionMethods.Deflate
            'req.Accept = "application/json"
            req.KeepAlive = True
            req.Credentials = CredentialCache.DefaultCredentials
            req.ContentType = "application/json"
            req.CookieContainer = New CookieContainer
            req.Method = WebRequestMethods.Http.Get
            req.UserAgent = ".NET Client"

            ' Upload
            'req.Headers.Add(HttpRequestHeader.ContentType, "application/octet-stream")

            Dim html As String
            Dim res As HttpWebResponse = req.GetResponse()
            If res.StatusCode <> HttpStatusCode.OK Then
                Throw New Exception(String.Format(
                    "Server error (HTTP {0}: {1}).",
                    res.StatusCode,
                    res.StatusDescription))
            End If
            Using st As Stream = res.GetResponseStream()
                Using sr As StreamReader = New StreamReader(st, _Enc)
                    html = sr.ReadToEnd()
                End Using
            End Using

            Dim json As T
            json = JsonConvert.DeserializeObject(Of T)(html)
            Return json
        Catch ex As Exception
            Debug.Print(ex.ToString)
        End Try
    End Function

End Class
