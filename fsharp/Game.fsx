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
let private scoreWhenOtherPoints (player1Score, player2Score) player =
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

let private scoreWhenForty (fortyPlayer, otherPlayerScore) player =
    match player with
    | player when player = fortyPlayer -> Game player
    | _ ->
        match otherPlayerScore with
        | Love -> Forty (fortyPlayer, Fifteen)
        | Fifteen -> Forty (fortyPlayer, Thirty)
        | Thirty -> Deuce

let private scoreWhenAdvantage advantagePlayer player =
    match player with
    | p when p = advantagePlayer -> Game p
    | _ -> Deuce

let scoreAPoint player previousScore =
    match previousScore with
    | OtherPoints (player1Score, player2Score) -> scoreWhenOtherPoints (player1Score, player2Score) player
    | Forty (p, otherPlayerScore) -> scoreWhenForty (p, otherPlayerScore) player
    | Deuce -> Advantage player
    | Advantage p -> scoreWhenAdvantage p player
    | Game _ -> previousScore

Deuce
|> scoreAPoint Player1