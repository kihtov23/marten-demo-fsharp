#r "nuget:Marten"
open Marten
open Weasel.Core

let getSession = 
    let store =
        DocumentStore.For(fun options ->
          options.Connection("xxx")
          options.AutoCreateSchemaObjects <- AutoCreate.None
        )

    // Finally, use the `IDocumentSession` to start
    // working with documents and queries.
    store.OpenSession()
