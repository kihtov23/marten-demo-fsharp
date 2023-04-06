#r "nuget:Marten"
open Marten
open Weasel.Core

let getSession () = 
    let store =
        DocumentStore.For(fun options ->
          options.Connection("host=127.0.0.1;database=marten-demo;user id=postgres;password=MyPass@word")
          options.AutoCreateSchemaObjects <- AutoCreate.None
        )
   
    store.OpenSession()
