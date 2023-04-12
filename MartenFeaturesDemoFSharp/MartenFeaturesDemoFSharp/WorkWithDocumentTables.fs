module WorkWithDocumentTables

open System
open Xunit
open Base

type SimpleUser = {

    Id: Guid
    Name: string
    Age: int
}

///This will store new data only in document specific table. No updates on Events table
[<Fact>]
let ``Store document and get it by id`` () = 
    task {
        let store = getDocumentStore ()
        use session = store.LightweightSession ()

        let guid = Guid.NewGuid()
        let newUser =  {Id = guid; Name = "test name 2"; Age= 20}

        // Store is upsert (create or update)
        session.Store(newUser) 
        do! session.SaveChangesAsync()
        let! simpleUser = session.LoadAsync<SimpleUser>(newUser.Id)
        Assert.Equal("test name 2", simpleUser.Name)
        return()
    }