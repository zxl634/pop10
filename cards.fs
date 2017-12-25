module Cards 
open System
open Microsoft.FSharp.Reflection
//http://www.fssnip.net/9l/title/toString-and-fromString-for-discriminated-unions
let fromString<'a> (s:string) =
    match FSharpType.GetUnionCases typeof<'a> |> Array.filter (fun case -> case.Name = s) with
    |[|case|] -> Some(FSharpValue.MakeUnion(case,[||]) :?> 'a)
    |_ -> None

let toString (x:'a) = 
    match FSharpValue.GetUnionFields(x, typeof<'a>) with
    | case, _ -> case.Name

type Suit = | Spades | Clubs | Diamonds | Hearts
            with
              static member fromString s = fromString<Suit> s
              member this.toString = toString this

type Face = | Two  | Three | Four | Five 
            | Six | Seven | Eight | Nine | Ten
            | Jack | Queen | King | Ace
            with
              static member fromString s = fromString<Face> s
              member this.toString = toString this

type Card = {Face:Face option; Suit:Suit option}
type Deck = Card list
type Hand = Card list
type Score = Score of int

let generateRandomNumber l =
  let gen = System.Random()
  let num = gen.Next(1,l)
  num

let drawCase (cases:UnionCaseInfo []) : UnionCaseInfo =
  let randomNumber = generateRandomNumber cases.Length
  //printfn "I drew %d" randomNumber
  cases.[randomNumber - 1]

let drawCard : Card =
  let facesCases = FSharpType.GetUnionCases(typeof<Face>)
  let suitCases = FSharpType.GetUnionCases(typeof<Suit>)
  let randomFace = drawCase facesCases
  //printfn "I drew %A" randomFace
  let randomSuit = drawCase suitCases
  let randomFaceString = randomFace.Name 
  let randomSuitString = randomSuit.Name
  let randomFaceOptionType = Face.fromString randomFaceString
  let randomSuitOptionType = Suit.fromString randomSuitString
  {Face = randomFaceOptionType; Suit = randomSuitOptionType}

/// Herunder kommer en anden (bedre?) udgave af drawCard-funktionen, der anvender piping
let getName (x:UnionCaseInfo) : string =
  x.Name

let constructCard (face:Face option) (suit:Suit option) : Card =
  {Face = face; Suit = suit}

let printCard (card : Card) =
  printfn "%A of %A" card.Face.Value card.Suit.Value

// Kan nedenstående funktioner slås sammen i én?
let drawFace : Face option =
  FSharpType.GetUnionCases(typeof<Face>)
  |> drawCase
  |> getName
  |> Face.fromString

let drawSuit : Suit option =
  FSharpType.GetUnionCases(typeof<Suit>)
  |> drawCase
  |> getName
  |> Suit.fromString

let drawCard2 : Card =
  constructCard drawFace drawSuit

let createDeck : Deck =
  let facesCases = FSharpType.GetUnionCases(typeof<Face>)
  let suitCases = FSharpType.GetUnionCases(typeof<Suit>)
  [for f in facesCases do 
      for s in suitCases do
        yield constructCard (Face.fromString f.Name) (Suit.fromString s.Name)]

let shuffleDeck (deck:Deck) : Deck =
  let gen = new System.Random ()
  deck
    |> List.map (fun c -> (gen.Next (), c))
    |> List.sortBy fst |> List.map snd


let drawCardFromDeck (deck:Deck) : Card =
  let shuffledDeck = shuffleDeck deck
  shuffledDeck.[0]

let drawAndPrint (deck:Deck) =
  deck
    |> drawCardFromDeck
    |> printCard

// Calculate value of card
let getCardValue card : int =
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

//printfn "Value of random card: %A" (getCardValue drawCard)
