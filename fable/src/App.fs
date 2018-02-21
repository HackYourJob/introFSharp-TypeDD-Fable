module App.Bootstrap

open Elmish

open Elmish.React
open Elmish.Debug
open Elmish.HMR

Program.mkProgram App.Update.init App.Update.update App.View.view
#if DEBUG
|> Program.withDebugger
|> Program.withHMR
#endif
|> Program.withReact "tennis-game-app"
|> Program.run
