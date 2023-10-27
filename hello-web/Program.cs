var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// LAMBDA Expression
// ()  =  List of parameters
// =>  =  Arrow operator, function follows
var myfunc = () => {
    Console.WriteLine("Hello Func");
};

app.MapGet("/", // endpoint
    () => "<!DOCTYPE html><html><body><h1>Hello World!</h1></body></html>"
);
app.MapGet("/about",
    () => "You are seeing the about"
);
app.MapGet("/hello",
    () => "Hello!!!! (not world)"
);
app.MapGet("/hello/world",
    () => "Hello!!!!! (including the world)"
);

myfunc();

app.Run();
