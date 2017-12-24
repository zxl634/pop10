module simpleJack

open Cards

(*
type Participant() =
  abstract member numberOfCards : int 
  abstract member valueOfCards : int
  abstract member addCard : int -> int
  //abstract member removeCard : int -> int
  //abstract member addCardValue : int -> int
  // defaults
  default this.numberOfCards = 2
  default this.valueOfCards = 0
  default this.addCard = numberOfCards + 1
  //default this.removeCard = numberOfCards - 1
  //default this.addCardValue value = valueOfCards + value
*)

type Player () =
  let mutable hand : Hand = [drawCard; drawCard]
  let privateGetValueOfHand hand =
    List.fold (fun acc x -> acc + (getCardValue x)) 0 hand 
  member this.addCard () =
    hand <- drawCard :: hand
  member this.getHand () = hand
  member this.getValueOfHand () : int =
    privateGetValueOfHand hand
  member this.getPlayerStatus () =
    let score = privateGetValueOfHand hand
    match score with
    | s when s < 21 -> "Still in the game!"
    | s when s > 21 -> "Bust!"
    | s when s = 21 -> "SimpleJack!"

 // inherit Participant()

//type Dealer () =
//  inherit Participant()

type Table (numberOfPlayers : int) =
  /// Define number of players
  let numberOfPlayers = numberOfPlayers
  /// Print welcome at construction time
  let printWelcome() =
    do printfn "Welcome to this game of Simple Jack with %i players including the dealer." numberOfPlayers
  do printWelcome()

  /// Instantiate participants
  let player = new Player()
  let dealer = new Player()

  let hitOrStand (player : Player) =
  //member this.hitOrStand (player : Player) =
    System.Console.Write "Hit [h] or stand [s]? "
    let answer = System.Console.ReadLine ()
    if answer = "h" then
      player.addCard ()
      printfn "Hånd efter nyt kort er tilføjet: %A" (player.getHand ())
      printfn "Status: %A" (player.getPlayerStatus ())
  /// Print table
  override this.ToString() = 
    let mutable str = "\nThe players have the following cards:\n\n"
    (*
    for i in 1 .. numberOfPlayers do
      let mutable participant = ""
      match i with
      | 1 ->
          participant <- "dealer"
      | _ -> 
          participant <- "player " + string (i-1)
      str <- str + sprintf "\n  Cards of " + participant + ":"
      /// Insert cards here
      str <- "Strhing"
      //str <- str + string player.getNumberOfCards
      *)
    str <- str + sprintf "Cards of dealer:\n %A\n" (dealer.getHand ())
    str <- str + sprintf "Cards of player:\n %A\n" (player.getHand ())
    str
  member this.turn (player : Player) =
    System.Console.Write ("Press enter to start turn")
    let key = System.Console.ReadKey true
    if string key.KeyChar = "\010" then
      hitOrStand player
      printfn "Everyone is happy!"
    /// In a turn all players that are AI should be ...

let table = Table (3)
printfn "%A" table


 
