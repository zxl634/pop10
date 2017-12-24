open System
open Microsoft.FSharp.Reflection

//http://www.fssnip.net/9l/title/toString-and-fromString-for-discriminated-unions
let toString (x:'a) = 
    match FSharpValue.GetUnionFields(x, typeof<'a>) with
    | case, _ -> case.Name

let fromString<'a> (s:string) =
    match FSharpType.GetUnionCases typeof<'a> |> Array.filter (fun case -> case.Name = s) with
    |[|case|] -> Some(FSharpValue.MakeUnion(case,[||]) :?> 'a)
    |_ -> None

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
type Score = Score of int

let generateRandomNumber l =
  let gen = System.Random()
  gen.Next(1,l)

let drawCase (cases:UnionCaseInfo []) =
  let randomNumber = generateRandomNumber cases.Length
  cases.[randomNumber - 1]

let drawCard : Card =
  let facesCases = FSharpType.GetUnionCases(typeof<Face>)
  let suitCases = FSharpType.GetUnionCases(typeof<Suit>)
  let randomFace = drawCase facesCases
  let randomSuit = drawCase suitCases
  let randomFaceString = randomFace.Name 
  let randomSuitString = randomSuit.Name
  let randomFaceOptionType = Face.fromString randomFaceString
  let randomSuitOptionType = Suit.fromString randomSuitString
  {Face = randomFaceOptionType; Suit = randomSuitOptionType}

//printfn "Random Card: %A" (drawCard)

// Udviklingsmuligheder:
  // 1) Træk kun fra eksisterende dæk, fx kan der ikke trækkes et kort, der allerede er blevet trukket 

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
  | Some Jack | Some Queen | Some King -> 10 
  | _ -> 0

//printfn "Value of random card: %A" (getCardValue drawCard)
