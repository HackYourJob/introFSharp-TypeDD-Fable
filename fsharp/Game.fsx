// STEP 1
// cardinality = 36 
// type PlayerScore =
//     | Love
//     | Fifteen
//     | Thirty
//     | Forty
//     | Game
//     | Advantage

// type Score = PlayerScore * PlayerScore

// STEP 2
// Remove Advantage combinations
// type PlayerScore =
//     | Love
//     | Fifteen
//     | Thirty
//     | Forty
//     | Game
// type Player = Player1 | Player2
// // cardinality = 27
// type Score =
//     | Advantage of Player // cardinality 2
//     | OtherPoints of PlayerScore * PlayerScore // cardinality 25

// STEP 3
// // Remove Game
// type PlayerScore =
//     | Love
//     | Fifteen
//     | Thirty
//     | Forty
// type Player = Player1 | Player2
// // cardinality = 20
// type Score =
//     | Game of Player // cardinality 2
//     | Advantage of Player // cardinality 2
//     | OtherPoints of PlayerScore * PlayerScore // cardinality 16

// STEP 4
// Remove Forty to let emerge Deuce (used in Ubiquituous language)
type PlayerScore =
    | Love
    | Fifteen
    | Thirty
type Player = Player1 | Player2
// cardinality = 20
type Score =
    | Game of Player // cardinality 2
    | Advantage of Player // cardinality 2
    | Deuce // cardinality 1
    | Forty of Player * PlayerScore // cardinality 2 * 3 = 6
    | OtherPoints of PlayerScore * PlayerScore // cardinality 9

// STEP 5 : start implementation
let scoreAPoint player previousScore =
    let scoreWhenAdvantage player = function
        | p when p = player -> Game p
        | _ -> Deuce
    let scoreWhenForty (player, otherPlayerScore) = function
        | p when p = player -> Game p
        | _ ->
            match otherPlayerScore with
            | Thirty -> Deuce
            | Fifteen -> Forty (player, Thirty)
            | Love -> Forty (player, Fifteen)
    let scoreWhenOtherPoints (p1Score, p2Score) = function
        | Player1 ->
            match p1Score with
            | Thirty -> Forty (Player1, p2Score)
            | Fifteen -> OtherPoints (Thirty, p2Score)
            | Love -> OtherPoints (Fifteen, p2Score)
        | Player2 ->
            match p2Score with
            | Thirty -> Forty (Player2, p1Score)
            | Fifteen -> OtherPoints (p1Score, Thirty)
            | Love -> OtherPoints (p1Score, Fifteen)            
    match previousScore with
    | Game _ -> previousScore
    | Deuce -> Advantage player
    | Advantage p -> player |> scoreWhenAdvantage p
    | Forty (p, otherPlayerScore) -> player |> scoreWhenForty (p, otherPlayerScore)
    | OtherPoints (p1, p2) -> player |> scoreWhenOtherPoints (p1, p2)

Deuce
|> scoreAPoint Player1