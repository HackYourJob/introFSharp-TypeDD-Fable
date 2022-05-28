module App.View

open Fable.React
open Fable.React.Props

open App.Domain
open App.Update

let formatScore = function
    | Game player -> $"%A{player} win 🎉"
    | Forty (Player1, playerScore) -> $"Forty - %A{playerScore}"
    | Forty (Player2, playerScore) -> $"%A{playerScore} - Forty"
    | OtherPoints (player1Score, player2Score) -> $"%A{player1Score} - %A{player2Score}"
    | model -> $"%A{model}"

let view (model, _) dispatch =
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
