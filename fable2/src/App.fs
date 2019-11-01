module App.Bootstrap

open Elmish
open Elmish.React
open App.Update
open App.View

Program.mkSimple init update view
|> Program.withReact "elmish-app"
|> Program.withConsoleTrace
|> Program.run
