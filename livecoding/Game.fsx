// cardinality : 36 -> 27 -> 20
type Score = 
    | OtherPoints of ScorePoint * ScorePoint // 9
    | Forty of Player * ScorePoint // 6
    | Deuce // 1
    | Advantage of Player // 2
    | Game of Player // 2
and ScorePoint = // 3
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

type ScoreAPoint = Player -> Score -> Score
let scoreAPoint (player: Player) (previousScore: Score) : Score = 
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

OtherPoints (Love, Love)
|> scoreAPoint Player1
|> scoreAPoint Player1
|> scoreAPoint Player2
|> scoreAPoint Player1

