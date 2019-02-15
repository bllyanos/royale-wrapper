'AUTHOR : Billy Editiano Saputra - 2016130012 STMIK LIKMI
'YEAR   : 2019

'========================================================

Imports System.Web.Script.Serialization
Imports System.Net
Imports System.IO
Imports System.Text

''' <summary>
''' Wrapper for Royale API Request.
''' </summary>
Public Class RoyaleRequest
    ''' <summary>
    ''' Url Endpoint for Request
    ''' </summary>
    ''' <returns></returns>
    Public Property BASE_URL As String

    ''' <summary>
    ''' API KEY for Get Request
    ''' </summary>
    ''' <returns></returns>
    Public Property API_KEY As String

    ''' <summary>
    ''' JavaScriptSerializer for serialize and deserialize
    ''' </summary>
    Private serializer As JavaScriptSerializer

    ''' <summary>
    ''' Init RoyaleRequest
    ''' </summary>
    ''' <param name="BASE_URL"></param>
    ''' <param name="API_KEY"></param>
    Public Sub New(ByVal API_KEY As String, Optional ByVal BASE_URL As String = "https://api.royaleapi.com/")
        Me.BASE_URL = BASE_URL
        Me.API_KEY = API_KEY

        'init serializer
        serializer = New JavaScriptSerializer()
    End Sub


    ''' <summary>
    ''' Request Player data to server 
    ''' </summary>
    ''' <param name="tag"></param>
    ''' <returns>Player</returns>
    Public Function GetPlayerByTag(ByVal tag As String) As Player
        Dim player As Player
        Dim request As HttpWebRequest = CreateNewRequest(BASE_URL + "player/")
        Dim response As WebResponse = request.GetResponse()
        Dim reader As StreamReader = New StreamReader(response.GetResponseStream(), Encoding.UTF8)
        Dim jsonString As String = reader.ReadToEnd()
        reader.Close()
        response.Close()
        player = DeserializePlayer(jsonString)
        Return player
    End Function

    ''' <summary>
    ''' Player's JSON string -> Player Object
    ''' </summary>
    ''' <param name="jsonString"></param>
    ''' <returns></returns>
    Public Function DeserializePlayer(ByVal jsonString As String) As Player
        Dim player As Player = serializer.Deserialize(Of Player)(jsonString)
        Return player
    End Function

    Public Function SerializePlayer(ByVal player As Player) As String

    End Function

    ''' <summary>
    ''' Create New HttpRequest
    ''' </summary>
    ''' <param name="URL"></param>
    ''' <param name="Method"></param>
    ''' <returns></returns>
    Private Function CreateNewRequest(ByVal URL As String, Optional ByVal Method As String = "GET") As HttpWebRequest
        Dim headers As New WebHeaderCollection()
        headers.Add("auth: Bearer " + API_KEY)
        Dim request As HttpWebRequest = WebRequest.Create(URL)
        request.Method = Method
        Return request
    End Function

End Class
