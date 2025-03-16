// See https://aka.ms/new-console-template for more information
using CSharpFunctionalExtensions;

Console.WriteLine("Hello, World!");


public record Person(string Name, int Age);

partial struct Error<T> { }
partial struct ErrorOr<T> { }
partial struct Value<T> { }
partial struct Valid<T> { }
partial struct Ref<T> { }
partial struct Res<T> { }
partial struct Let<T> { }
partial struct Val<T> { }
partial struct Ok<T> { }
public partial struct Try<T> { }
partial struct R<T> 
{

}
public partial struct Try 
{
    public static Try<T> Success<T>(T value)
    {
        return new Try<T>();
    }
}



public class Funcs
{
    //public async Task<ErrorOr<Person>> Work() { }
    //public async Task<Error<Person>> Work() { }
    //public async Task<Valid<Person>> Work() { }
    //public async Task<Value<Person>> Work() { }
    //public async Task<Ref<Person>> Work() { }
    //public async Task<Let<Person>> Work() { }
    //public async Task<Val<Person>> Work() { }
    //public async Task<Ok<Person>> Work() { }
    //public async Task<R<Person>> Work() { }
    //public async Task<Return<Person>> Work() { }
    //public async Task<Res<Person>> Work() { }
    //public async Task<Result<Person,Exception>> Work() { }
    //public Return<Person> Work() { }
    //public Res<Person> Work() { }
    //public Let<Person> Work() { }
    //public Valid<Person> Work() { }
    //public Ok<Person> Work() { }
    //public R<Person> Work() { }
    //public Try<Person> Work() { }



    public async Task<Return<Person>> Work( bool isOk )
    {
        await Task.CompletedTask;
        if ( isOk )
        {
            return new Exception("Ok");
        }
        return new Person("John", 30);
    }

    public async Task<Return<Person>> Work9( bool isOk )
    {
        await Task.CompletedTask;
        if ( isOk )
        {
            return new Exception("Ok");
        }
        return Return.Success(new Person("John", 30));
    }




    public Return<Person> Work5(bool isOk) => Return
        .Of(new Person("John", 30))
        .Map(x => x with { Age = 20 })
        .Bind(p => Return.Of(new Person("John", 30)));





    public Return<Person> Work2(bool isOk) => isOk
        ? Return.Success<Person>( new Person("John", 30) )
        : Return.Failure<Person>( new Exception("Ok") );

    public async Task<Return<Person>> Work3(bool isOk) => Return
        .Success<Person?>(new Person("John", 30))
        .EnsureNotNull( () => new Exception("Person is null") )
        .Bind( p => Return.Of(new Person("John", 30)) )
        .Map( x => x with { Age = 20 } )
        ;

    
    public Return<Person,Exception> Work6(bool isOk) => Return
        .Success<Person?, Exception>( new Person("John", 30) )
        .EnsureNotNull( () => new Exception("Person is null") )
        .Bind( p => Return.Success<Person, Exception>(new Person("John", 30)) )
        .Map( x => x with { Age = 20 } )
        ;


    public Try<Person> Work4(bool isOk) => Try
        .Success(new Person("John", 30));



    //public Try<Person> Work2(bool isOk) => isOk
    //    ? new Person("John", 30)
    //    : new Exception("Ok");

}

