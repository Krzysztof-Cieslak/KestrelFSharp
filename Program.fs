﻿// Learn more about F# at http://fsharp.org

open System
open System.IO
open System.Text
open System.Threading.Tasks
open Microsoft.AspNetCore.Builder
open Microsoft.AspNetCore.Http
open Microsoft.AspNetCore.Hosting

type Startup() = 
    
    member this.Configure (app : IApplicationBuilder) = 
        app.Run (fun ctx ->
            printfn "%A - %A - %A - %A" ctx.Request.Method ctx.Request.PathBase ctx.Request.Path ctx.Request.QueryString
            ctx.Response.WriteAsync("Hello world")
        )



[<EntryPoint>]
let main argv = 
    WebHostBuilder()
        .UseKestrel()
        .UseContentRoot(Directory.GetCurrentDirectory())
        .UseDefaultHostingConfiguration(argv)
        .UseStartup<Startup>()
        .Build()
        .Run()
    
    
    0 // return an integer exit code
