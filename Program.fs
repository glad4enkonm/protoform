open System
open FParsec

type Info = { syntax: string }
let str s = pstring s
let betweenStrings s1 s2 p = str s1 >>. p .>> str s2

[<EntryPoint>]
let main argv =
    printfn "Hello World from F#!"

    let test p str =
        match run p str with
        | Success(result, _, _)   -> printfn "Success: %A" result
        | Failure(errorMsg, _, _) -> printfn "Failure: %s" errorMsg
    
    test pfloat "1.25"
    test pfloat "1.25E 2"
    
    //test pcomment "// Interface exported by the server."
    test pcomment "syntax = \"proto3\";"

    0 // return an integer exit code
