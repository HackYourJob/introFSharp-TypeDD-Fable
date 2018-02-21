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
    let addPoint = function
        | Love -> Fifteen
        | Fifteen -> Thirty
        | Thirty -> failwith "impossible state!!"
    match previousScore, player with
    | Game _, _ -> previousScore
    | Deuce, _ -> Advantage player
    | Advantage p, _ when p = player -> Game p
    | Advantage _, _ -> Deuce
    | Forty (p, _), _ when p = player -> Game p
    | Forty (p, Thirty), _ -> Deuce
    | Forty (p, point), _ -> Forty (p, addPoint point)
    | OtherPoints (Thirty, p2), Player1 -> Forty (player, p2)
    | OtherPoints (p1, Thirty), Player2 -> Forty (player, p1)
    | OtherPoints (p1, p2), Player1 -> OtherPoints (addPoint p1, p2)
    | OtherPoints (p1, p2), Player2 -> OtherPoints (p1, addPoint p2)

Deuce
|> scoreAPoint Player1