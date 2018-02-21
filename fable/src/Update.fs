module App.Update

open Elmish

open App.Domain

let init () =
  OtherPoints (Love, Love), Cmd.Empty

type Msg =
  | ScoreAPoint of Player

let update msg model =
  match msg with
  | ScoreAPoint player -> scoreAPoint player model, Cmd.Empty
