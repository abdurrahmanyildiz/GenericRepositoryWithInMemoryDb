# GenericRepositoryWithInMemoryDb
How to use generic repository base class with a mock database context

This project is about to use fake in memory database with generic repository base class.

Dependencies: Microsoft.EntityFrameworkCore.InMemory (5.0.5)

To add the db context to services in Startup file add like following:

```
services.AddDbContext<MockDbContext>(ops => ops.UseInMemoryDatabase("TestDb"));
```

And if you get an error like following:

```
No database provider has been configured for this DbContext.
A provider can be configured by overriding the 'DbContext.OnConfiguring' 
method or by using 'AddDbContext' on the application service provider. 
If 'AddDbContext' is used, then also ensure that your 
DbContext type accepts a DbContextOptions<TContext> object in its constructor
and passes it to the base constructor for DbContext.
```

This says you: you need to override `OnConfiguring` method in your DbContext class

```
protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseInMemoryDatabase("TestDb");
                base.OnConfiguring(optionsBuilder);
            }
        }
```

After you run the code you can see the seeded records into the response: 

```
[
    {
        "uid": "b9cb43f1-4dfb-4fa8-a5c3-a8a5fa0bb087",
        "username": "just_a_crazy",
        "name": "Justin",
        "lastname": "Timberlake",
        "birthDate": "2021-05-09T17:38:15.5629882+03:00"
    },
    {
        "uid": "cf78906a-183a-4094-9b64-8423282d3cfe",
        "username": "cool_george",
        "name": "George",
        "lastname": "Clooney",
        "birthDate": "2021-05-09T17:38:15.5649474+03:00"
    }
]
```


