#load @".paket/load/net462/main.group.fsx"

open System
open Akka
open Akka.FSharp
open Akka.Actor
open Akka.Pattern

let actor (mailbox:Actor<_>) =
    let rec loop () = 
        actor {
            let! msg = mailbox.Receive()
            return! loop ()
        }
    loop ()

// https://github.com/akkadotnet/akka.net/blob/cd33195b5aad34895f0fb69893bd2074d539201f/src/core/Akka.FSharp/FsApi.fs#L382
let expr = Linq.Expression.ToExpression (fun () -> new FunActor<obj,obj>(actor))

// below is what I intend to do with it later...
let props = Props.Create(expr)
let parentExpr = 
            Linq.Expression.ToExpression <@ fun () -> 
                BackoffSupervisor(
                    props, 
                    "child", 
                    TimeSpan.FromSeconds 3., 
                    TimeSpan.FromSeconds 60., 
                    0.1) @>
let parentProps = Props.Create (parentExpr)
let system = System.create "my-system" (Configuration.load())
system.ActorOf(parentProps, "parent")