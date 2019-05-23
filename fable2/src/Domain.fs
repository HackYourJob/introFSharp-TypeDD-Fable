module App.Domain

type PlayerScore =
    | Love
    | Fifteen
    | Thirty
type Player = Player1 | Player2

type Score =
    | Game of Player
    | Advantage of Player
    | Deuce
    | Forty of Player * PlayerScore
    | OtherPoints of PlayerScore * PlayerScore

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
