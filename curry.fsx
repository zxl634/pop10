let addTwoParameters x =
  let subFunction y =
    x + y
  subFunction

printfn "%i" (addTwoParameters 1 2)
