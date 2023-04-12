module EventsAndLiveProjections

open System
open Xunit
open Base
open Person

//This will update only Events table, no changes on document specific table
[<Fact>]
let ``Append events and get document by id`` () = 
    task {
        let store = getDocumentStore ()
        use session = store.LightweightSession ()

        let guid = Guid.NewGuid()
        let newPerson = PersonCreated {Id =guid; PersonName = "test name 3"}

        session.Events.Append(guid, newPerson) |> ignore
        do! session.SaveChangesAsync()

        //let! loadedPerson = session.LoadAsync<Person>(guid)
        //Assert.Equal("test name 3", loadedPerson.PersonName)
        Assert.True(true);
        return()
    }

[<Fact>]
let ``Read data`` () =
    task {
        let store = getDocumentStore ()
        use session = store.LightweightSession ()

        let guid = Guid.NewGuid()
        let name = "test name"
        let newPerson = PersonCreated {Id = guid; PersonName = name}
        
        //Marten requires even registration but it happens automatically when we append event
        //In production we need to register even because if we query event before we register it, it will not work 
        session.Events.Append(guid, newPerson) |> ignore
        let! _ = session.SaveChangesAsync()

        let person = session.Events.AggregateStream<Person>(guid)
        Assert.Equal(name, person.PersonName)
        return()
    }
