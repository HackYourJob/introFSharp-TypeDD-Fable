module App.Domain

type Score = 
    | OtherPoints of ScorePoint * ScorePoint
    | Forty of Player * ScorePoint
    | Deuce
    | Advantage of Player
    | Game of Player
and ScorePoint =
    | Love
    | Fifteen
    | Thirty
and Player = Player1 | Player2

let private scoreWithOtherPoint player (player1Score, player2Score) =
    match player with
    | Player1 ->
        match player1Score with
        | Love -> OtherPoints (Fifteen, player2Score)
        | Fifteen -> OtherPoints (Thirty, player2Score)
        | Thirty -> Forty (player, player2Score)
    | Player2 ->
        match player2Score with
        | Love -> OtherPoints (player1Score, Fifteen)
        | Fifteen -> OtherPoints (player1Score, Thirty)
        | Thirty -> Forty (player, player1Score)

let scoreAPoint player previousScore = 
    match previousScore with
    | OtherPoints (player1Score, player2Score) -> scoreWithOtherPoint player (player1Score, player2Score)
    | Forty (fortyPlayer, _) when fortyPlayer = player -> Game player
    | Forty (fortyPlayer, otherScore) -> 
        match otherScore with
        | Love -> Forty(fortyPlayer, Fifteen)
        | Fifteen -> Forty(fortyPlayer, Thirty)
        | Thirty -> Deuce
    | Deuce -> Advantage player
    | Advantage p when p = player -> Game player
    | Advantage _ -> Deuce
    | Game _ -> previousScore

