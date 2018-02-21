module App.View

open Fable.Helpers.React
open Fable.Helpers.React.Props

open App.Domain
open App.Update

let formatScore = function
    | Game player -> sprintf "%A win" player
    | Forty (Player1, playerScore) -> sprintf "Forty - %A" playerScore
    | Forty (Player2, playerScore) -> sprintf "%A - Forty" playerScore
    | OtherPoints (player1Score, player2Score) -> sprintf "%A - %A" player1Score player2Score 
    | model -> sprintf "%A" model

let view model dispatch =
    div [] [
        div [] [
            str "Which player scores?"
            button [ OnClick (fun _ -> dispatch <| ScoreAPoint Player1 ) ] [ str "Player 1" ]
            button [ OnClick (fun _ -> dispatch <| ScoreAPoint Player2 ) ] [ str "Player 2" ]
        ]
        div [] [
            formatScore model |> str 
        ]
    ]