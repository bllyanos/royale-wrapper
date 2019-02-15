'AUTHOR : Billy Editiano Saputra - 2016130012 STMIK LIKMI
'YEAR   : 2019

'========================================================

''' <summary>
''' Player Wrapper
''' </summary>
Public Class Player
    Public Property tag As String
    Public Property name As String
    Public Property trophies As Integer
    Public Property rank As Nullable(Of Integer)
    Public Property arena As Arena
    Public Property stats As Stats
End Class

Public Class Arena
    Public Property name As String
    Public Property arena As String
    Public Property arenaID As Integer
    Public Property trophyLimit As Integer
End Class

Public Class Stats
    Public Property maxTrophies As Integer
    Public Property threeCrownWins As Integer
    Public Property favoriteCard As Card
End Class

Public Class Card
    Public Property name As String
    Public Property id As Integer
    Public Property icon As String
End Class