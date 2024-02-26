'Rahiel Rodriguez
'RCET 0265
'Spring 2024
'Shuffle The Deck
'https://github.com/rahielrodriguez/ShuffleTheDeck.git
Module ShuffleTheDeck

    Sub Main()
        Dim deckCage(3, 12) As Boolean
        Dim userInput As String
        cardsCount(True)
        SetDefaultPrompt()
        UserMessage("Press Enter to draw a card")
        Do Until userInput = "q"
            DisplayDraws(deckCage)
            userInput = Console.ReadLine()
            Select Case userInput
                Case "q"
                    Exit Sub
                Case "n"
                    ReDim deckCage(3, 12)
                    cardsCount(True)
                Case Else
                    Draw(deckCage)
            End Select
        Loop

    End Sub

    Sub DisplayDraws(ByRef deckCage(,) As Boolean)
        Dim currentCard As String
        Dim columnWidth As Integer = 5
        Dim header = New String() {"spades|", "clubs |", "hearts|", "diamonds|"}
        Dim _number As String
        Console.Clear()
        For i = LBound(header) To UBound(header)
            Console.Write(header(i).PadLeft(columnWidth))
        Next
        Console.WriteLine()
        Console.WriteLine(StrDup(29, "-"))
        For number = deckCage.GetLowerBound(1) To deckCage.GetUpperBound(1)
            For suit = deckCage.GetLowerBound(0) To deckCage.GetUpperBound(0)
                If deckCage(suit, number) Then
                    Select Case number
                        Case Is = 0
                            _number = "A"
                            currentCard = CStr(_number) & "  |"
                        Case Is = 10
                            _number = "J"
                            currentCard = CStr(_number) & "  |"
                        Case Is = 11
                            _number = "Q"
                            currentCard = CStr(_number) & "  |"
                        Case Is = 12
                            _number = "K"
                            currentCard = CStr(_number) & "  |"
                        Case Else
                            currentCard = CStr((suit * 0) + number + 1) & "  |"
                    End Select
                Else
                    currentCard = "  |"
                End If
                Console.Write(currentCard.PadLeft(7))
            Next
            Console.WriteLine()
        Next
        Console.WriteLine(UserMessage())

    End Sub

    Sub Draw(ByRef deckCage(,) As Boolean)
        Dim suits As Integer
        Dim number As Integer
        Dim numberOfTries As Integer
        Dim _letter = New String() {"spades", "clubs", "hearts", "diamonds"}
        Dim _cardCount As Integer

        If _cardCount < 52 Then
            Do
                suits = RandomNumber(3)
                number = RandomNumber(12)
                numberOfTries += 1
            Loop Until deckCage(suits, number) = False
            deckCage(suits, number) = True
            _cardCount = cardsCount()
            SetDefaultPrompt()
            UserMessage(CStr(_cardCount))
        Else
            SetDefaultPrompt()
            UserMessage("All card have been drawn.")
        End If

    End Sub

    Function RandomNumber(max As Integer) As Integer
        Randomize(DateTime.Now.Millisecond * DateTime.Now.Second)
        Return CInt(Rnd() * max)
    End Function

    Function UserMessage(Optional message As String = "", Optional clear As Boolean = False) As String
        Static messages As String
        If clear Then
            messages = ""
        ElseIf message <> "" Then
            messages &= message & vbNewLine
        End If
        Return messages
    End Function

    Sub SetDefaultPrompt()
        UserMessage(, True)
        'UserMessage("Press Enter to draw a ball")
        UserMessage("Enter 'n' to restart game")
        UserMessage("Enter 'q' to quit")
    End Sub

    Function cardsCount(Optional reset As Boolean = False) As Integer
        Static count As Integer
        count += 1
        If reset Then
            count = 0
        End If
        Return count
    End Function

End Module
