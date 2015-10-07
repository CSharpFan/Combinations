module Engine.Functions

let Calculate columns = 
    let rec CalculateCombinations columns = 
        match columns with
        | h::[] -> [ [ h ] ]
        | h::t -> 
            let x = CalculateCombinations t
            List.fold (fun acc elem -> (h::elem)::acc) ([h]::x) x
        | [] -> []

    columns 
    |> CalculateCombinations
    |> List.map set 