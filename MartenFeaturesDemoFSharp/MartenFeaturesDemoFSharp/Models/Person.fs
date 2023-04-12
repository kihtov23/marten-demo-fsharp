module Person

open System

type PersonCreated = {
    Id: Guid
    PersonName: string
}

type PersonUpdated = {
    Age: int
}

type PersonEvents =
    | PersonCreated of PersonCreated
    | PersonUpdated of PersonUpdated

[<CLIMutableAttribute>]
type Person = 
    {Id: Guid
     PersonName: string
     Age: int option}

    member this.Apply(event: PersonEvents) : Person =
        match event with 
            | PersonCreated e -> 
                {
                    Id = e.Id
                    PersonName = e.PersonName
                    Age = None
                }
            | PersonUpdated e -> 
                {
                    this with
                    Age = Some(e.Age)
            
                }
            
       