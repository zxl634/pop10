module Cards 
open System
open Microsoft.FSharp.Reflection

/// <summary> Converts to a type based on a string</summary>
/// <remarks>Taken from http://www.fssnip.net/9l/title/toString-and-fromString-for-discriminated-unions</remarks>
/// <param name="s">A string with the name of the type</param>
/// <returns>An option type</returns>
let fromString<'a> (s:string) =
    match FSharpType.GetUnionCases typeof<'a> |> Array.filter (fun case -> case.Name = s) with
    |[|case|] -> Some(FSharpValue.MakeUnion(case,[||]) :?> 'a)
    |_ -> None

/// Define basic types used for the game
type Suit = | Spades | Clubs | Diamonds | Hearts
            with
              static member fromString s = fromString<Suit> s
type Face = | Two  | Three | Four | Five 
            | Six | Seven | Eight | Nine | Ten
            | Jack | Queen | King | Ace
            with
              static member fromString s = fromString<Face> s
type Card = {Face:Face option; Suit:Suit option}
type Deck = Card list
type Hand = Card list

/// <summary>Constructs a card from a face and a suit</summary>
/// <param name="face">A face of type Face option, e.g. Some Two</param>
/// <param name="suit">A suit of type Suit option, e.g. Some Clubs</param>
/// <returns>A card of type Card</returns>
let constructCard (face:Face option) (suit:Suit option) : Card =
  {Face = face; Suit = suit}

/// <summary>Prints a card where Some is removed</summary>
/// <param name="card">The card to print</param>
/// <returns>Prints the card, e.g. Two of Clubs</returns>
let printCard (card : Card) =
  printfn "%A of %A" card.Face.Value card.Suit.Value

/// <summary>Convert a card to a string</summary>
/// <param name="card">The card of type Card to convert</param>
/// <returns>Returns a string, e.g. "Two of Clubs"</returns>
let cardString (card : Card) : string =
  sprintf "%A of %A" card.Face.Value card.Suit.Value

/// <summary>Creates a deck from all the possible types of Faces and Suits (52)</summary>
/// <returns>Returns a deck of 52 cards of all the combinations of cards and suits</returns>
let createDeck : Deck =
  let facesCases = FSharpType.GetUnionCases(typeof<Face>)
  let suitCases = FSharpType.GetUnionCases(typeof<Suit>)
  [for f in facesCases do 
      for s in suitCases do
        yield constructCard (Face.fromString f.Name) (Suit.fromString s.Name)]


/// <summary>Shuffle deck</summary>
/// <param name="deck">The deck to shuffle</param>
/// <returns>Returns a shuffled deck</returns>
let shuffleDeck (deck:Deck) : Deck =
  let gen = new System.Random ()
  deck
    |> List.map (fun c -> (gen.Next (), c))
    |> List.sortBy fst |> List.map snd

/// <summary>Draws a card from a (shuffled) deck</summary>
/// <param name="deck">Deck to draw a card from</param>
/// <returns>Returns a card from the deck</returns>
let drawCardFromDeck (deck:Deck) : Card =
  let shuffledDeck = shuffleDeck deck
  shuffledDeck.[0]

/// <summary>Draws a card and prints it</summary>
/// <param name="deck">The deck to draw the printed card from</param>
/// <returns>Prints a random card from the deck</returns>
let drawAndPrint (deck:Deck) =
  deck
    |> drawCardFromDeck
    |> printCard

/// <summary>Calculate the value of a card</summary>
/// <param name="card">The card to calculate the value of</param>
/// <returns>Returns an integer with the value of the card</returns>
let getCardValue (card:Card) : int =
  match card.Face with 
  | Some Ace -> 11 // Tester senere, om det bør være 1
  | Some Two -> 2
  | Some Three -> 3
  | Some Four -> 4
  | Some Five -> 5
  | Some Six -> 6
  | Some Seven -> 7
  | Some Eight -> 8
  | Some Nine -> 9
  | Some Ten | Some Jack | Some Queen | Some King -> 10 
  | _ -> 0

/// <summary>Tests, whether a hand contains an ace</summary>
/// <param name="hand">The hand to check whether an ace is within</param>
/// <returns>Returns true or false depending on whether there is an ace present in the hand</returns>
let handContainsAce (hand:Hand) : bool =
  List.exists (fun card -> 
    match card.Face with
    | Some Ace -> true
    | _ -> false
    ) hand

/// <summary>Defines the deck class</summary>
/// <remarks>Cannot handle an empty deck</remarks>
type DeckCls () =
  let mutable deck : Deck = createDeck
  member this.drawCardFromDeck () : Card =
    let shuffledDeck = shuffleDeck deck
    let n = shuffledDeck.Length - 1
    deck <- shuffledDeck.[1 .. n]
    shuffledDeck.[0]
  member this.getDeck () : Deck = deck
  member this.getDeckSize () : int = deck.Length
  member this.printDeck () =
    for c in deck do printCard c
