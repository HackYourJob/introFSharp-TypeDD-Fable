// cardinality 4*4 + 2 + 2 = 20
type Score = 
    | OtherPoints of PlayerScore * PlayerScore // 3*3 = 9
    | Forty of Player * PlayerScore // 3 * 2 = 6
    | Deuce // 1
    | Advantage of Player // 2
    | Game of Player // 2
and PlayerScore =
    | Love
    | Fifteen
    | Thirty
and Player = Player1 | Player2

let scoreWithOtherPoints player (player1Score, player2Score) =
    match player with
    | Player1 ->
        match player1Score with
        | Love -> OtherPoints (Fifteen, player2Score)
        | Fifteen -> OtherPoints (Thirty, player2Score)
        | Thirty -> Forty (Player1, player2Score)
    | Player2 ->
        match player2Score with
        | Love -> OtherPoints (player1Score, Fifteen)
        | Fifteen -> OtherPoints (player1Score, Thirty)
        | Thirty -> Forty (Player2, player1Score)

let scoreAPoint player previousScore =
    match previousScore with
    | OtherPoints (player1Score, player2Score) -> scoreWithOtherPoints player (player1Score, player2Score)
    | Forty (fortyPlayer, _) when fortyPlayer = player -> Game player
    | Forty (fortyPlayer, otherScore) -> 
        match otherScore with
        | Love -> Forty (fortyPlayer, Fifteen)
        | Fifteen -> Forty (fortyPlayer, Thirty)
        | Thirty -> Deuce
    | Deuce -> Advantage player
    | Advantage p when p = player -> Game player
    | Advantage _ -> Deuce
    | Game _ -> previousScore

Deuce 
|> scoreAPoint Player1





