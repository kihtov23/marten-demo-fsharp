module Base

open Marten
open Person
open Marten.Events.Projections
open Weasel.Core
open System.Text.Json.Serialization

let getDocumentStore () = 
    let store =
        DocumentStore.For(fun options ->
          options.Connection("host=localhost;database=marten-demo;user id=postgres;password=MyPass@word")
          //options.AutoCreateSchemaObjects <- AutoCreate.All
          //options.GeneratedCodeMode <- LamarCodeGeneration.TypeLoadMode.Auto
          //options.Projections.SelfAggregate<Person> (ProjectionLifecycle.Inline) |> ignore
          //let serializer = Marten.Services.SystemTextJsonSerializer()
          //serializer.Customize (fun v -> v.Converters.Add(JsonFSharpConverter ()))
          //options.Serializer(serializer)
          //options.Events.AddEventType(typeof<PersonCreated>)
          //options.Projections.Snapshot<Person>(SnapshotLifecycle.Inline)
        )
    store


