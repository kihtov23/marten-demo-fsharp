#load "BaseInit.fsx"
open BaseInit

type SimpleUser = {
    Id: string
    Name: string
    Age: int
}

let session = getSession ()
session.Store({Id = "1"; Name= "Test name"; Age = 20})

let _ = session.SaveChangesAsync() |> Async.AwaitTask
let simpleUser = session.LoadAsync<SimpleUser>("1") |> Async.AwaitTask

printfn "simple user = %A" simpleUser
