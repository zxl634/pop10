#r cards.fs
let facesCases = FSharpType.GetUnionCases(typeof<Face>)
let suitCases = FSharpType.GetUnionCases(typeof<Suit>)
