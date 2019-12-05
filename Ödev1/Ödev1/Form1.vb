Public Class Form1
    Function findPrime(ByVal number As Integer, ByVal direction As Integer) As String
        Dim primeFlag As Boolean
        Dim primeI As Integer

        While True
            number += direction
            primeFlag = True
            For primeI = 2 To number / 2
                If number Mod primeI = 0 Then
                    primeFlag = False
                End If
            Next
            If primeFlag Then
                Exit While
            End If
        End While
        Return number.ToString()
    End Function

    Function processNum(ByVal strData As String, ByVal process As Boolean) As String
        Dim sum As Integer
        For Each ch As Char In strData
            Dim i As Integer
            If process And Integer.TryParse(ch, i) Then
                sum += i
            ElseIf Integer.TryParse(ch, i) Then
                sum -= i
                sum = Math.Abs(sum)
            End If
        Next
        If sum < 10 And process Then
            Return ("0" + sum.ToString())
        Else
            Return sum.ToString()
        End If
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        ListBox1.Items.Clear()

        Dim charD As Char
        Dim textData() As Char = TextBox1.Text.ToString()
        Dim charToInt As Integer
        Dim actualData(12) As Char

        For i = 0 To textData.Length - 1
            charD = textData(i)
            charToInt = Asc(charD)
            Dim lowPrime As String = findPrime(charToInt, -1)
            Dim highPrime As String = findPrime(charToInt, 1)
            ListBox1.Items.Add(processNum(charToInt.ToString(), True) + processNum(lowPrime, False) + processNum(lowPrime, True) + lowPrime + processNum(highPrime, False) + processNum(highPrime, True) + highPrime)
        Next
    End Sub
End Class
