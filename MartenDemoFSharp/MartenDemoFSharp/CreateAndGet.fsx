#load "Base.fsx"
open Base

type SimpleUser = {
    Id: string
    Name: string
    Age: int
}

use sesssion = getSession

//sesssion.Store({Id = "1"; Name= "Test name"; Age = 20})
//let! _ = session.SaveChangesAsync()
//let! simpleUser = sesssion.LoadAsync<SampleType>("1")
//printfn "simple user = %A" simpleUser
