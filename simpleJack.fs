module simpleJack

open Cards

type Player (hand:Hand,AI:bool) =
  //let AI = AI // Bestemmer, om det er AI eller ej
  let mutable hand : Hand = hand 
  let privateGetValueOfHand (hand:Hand) : int =
    let value = List.fold (fun acc x -> acc + (getCardValue x)) 0 hand 
    if value > 21 then
      if (handContainsAce hand) then
        // Test, hvor mange esser der er er
        value - 10
      else
        value
    else
      value

  let privateAddCard (card:Card) =
    hand <- card :: hand
  member this.AI () = AI
  member this.AIstring () =
    match AI with
    | true -> " (AI)"
    | false -> " (human)"
  member this.addCard (card:Card) =
    printfn "\nHit!"
    hand <- card :: hand
  member this.getHand () = hand
  member this.printHand () =
    for c in hand do printCard c
  member this.stringHand () =
    let mutable str = ""
    for c in hand do
      str <- str + sprintf "    %s\n" (cardString c)
    str + sprintf "    (value of %s)\n" (string (privateGetValueOfHand hand))
  member this.getValueOfHand () : int =
    privateGetValueOfHand hand
  member this.hit (card:Card) =
        privateAddCard card
  member this.getPlayerStatus () =
    let score = privateGetValueOfHand hand
    match score with
    | s when s < 21 -> "Still in the game!" 
    | s when s > 21 -> "Bust!"
    | s when s = 21 -> "SimpleJack!"
    | _ -> "Nothing..." // To prevent compiler complaint about incomplete pattern

type Table (numberOfPlayers : int) =
  /// Define number of players
  let numberOfPlayers = numberOfPlayers
  /// Print welcome at construction time
  let printWelcome() =
    do printfn "Welcome to this game of Simple Jack with %i players including the dealer." numberOfPlayers
  do printWelcome()

  /// Create deck
  let deck = new DeckCls ()

  /// Instantiate participants
  let mutable AI = true
  let players = [
    for p in 1 .. numberOfPlayers do
      let mutable hand = [deck.drawCardFromDeck();
                          deck.drawCardFromDeck()]
      // First player is human
      if p = 1 then
        AI <- false
      else
        AI <- true
      yield new Player(hand, AI)
  ]

  let hitOrStand (player : Player) =
    // Undersøg, om spilleren er AI eller ej
    match player.AI() with
    | true -> 
      let score = player.getValueOfHand()
      if  score >= 17 then do
        // Stand
        printfn "\nStand!" 
      else
        // Hit
        player.addCard (deck.drawCardFromDeck())
    | false ->
        printfn "\nHand:\n%s" (player.stringHand())
        System.Console.Write "Hit [h] or stand [s]? "
        let answer = System.Console.ReadLine ()
        if answer = "h" then
          player.addCard (deck.drawCardFromDeck())
    // Viser hånden uanset hvad
    printfn "Hand:\n%s" (player.stringHand())

  let getParticipant i n =
    if i = n then
      "dealer"
    else
      "player " + string i

  /// Print table
  override this.ToString() = 
    let mutable str = "\nThe players have the following cards:"
    for i in 1 .. numberOfPlayers do
      let mutable participant : string = getParticipant i numberOfPlayers
      str <- str + sprintf "\n  Cards of " + participant
      let mutable player = players.[i-1]
      str <- str + player.AIstring() + ":\n" + player.stringHand()
    str

  member this.turn () =
    System.Console.Write ("Press enter to start turn")
    let key = System.Console.ReadKey true
    if string key.KeyChar = "\010" then
      for i in 1 .. numberOfPlayers do
        System.Console.Write("\nTurn for " + (getParticipant i numberOfPlayers))
        let mutable player = players.[i-1]
        hitOrStand player
      printfn "\nEnd of turn!"
      // Tjek, hvem der har vundet
      let dealer = players.[numberOfPlayers-1]
      let dealerScore = dealer.getValueOfHand()
      for i in 1 .. (numberOfPlayers - 1) do
        let mutable player = players.[i-1]
        let mutable playerScore = player.getValueOfHand()
        let mutable participant = getParticipant i numberOfPlayers
        if playerScore > 21 then
          printfn "%s" (participant + " is bust, so dealer wins!") 
        elif dealerScore > 21 then
          printfn "%s" ("Dealer is bust, so " + participant + " wins over dealer!") 
        elif playerScore <= dealerScore then
          printfn "%s" ("Dealer wins over " + participant)
        else
          printfn "%s" (participant + " wins over dealer")

