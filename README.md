# Functional Return for C&#35;

```csharp
var r = Return
    .Of( new Person( "John", 42 ) )
    .Map( p => p.Name )
    .Ensure( x => x.Length > 0, new Exception( "Name cannot be empty!" ) )
    .BindTry( x => Return.Failure<Person>( new Exception( "Fail!" ) ) )
    .Compensate( ex => new Person( "Jane", 42 ) )
    .Map( p => p.Name )
    .Match(
        success => success,
        failure => failure.Message
    );

public record Person( string Name, int Age );
```