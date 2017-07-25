# expressions-repro

Works with F# 4.0. Breaks with F# 4.1 with:

```
System.ArgumentException: Expression of type 'Microsoft.FSharp.Core.FSharpFunc`2[Microsoft.FSharp.Core.Unit,Akka.FSharp.Actors+FunActor`2[System.Object,System.Object]]' cannot be used for retu
rn type 'Akka.FSharp.Actors+FunActor`2[System.Object,System.Object]'
   at System.Linq.Expressions.Expression.ValidateLambdaArgs(Type delegateType, Expression& body, ReadOnlyCollection`1 parameters)
   at System.Linq.Expressions.Expression.Lambda(Type delegateType, Expression body, String name, Boolean tailCall, IEnumerable`1 parameters)
   at System.Linq.Expressions.Expression.Lambda(Type delegateType, Expression body, IEnumerable`1 parameters)
   at Microsoft.FSharp.Linq.RuntimeHelpers.LeafExpressionConverter.ConvExprToLinqInContext(ConvEnv env, FSharpExpr inp)
   at Microsoft.FSharp.Linq.RuntimeHelpers.LeafExpressionConverter.QuotationToLambdaExpression[T](FSharpExpr`1 e)
   at <StartupCode$FSI_0003>.$FSI_0003.main@() in c:\repos\expressions-repro\a.fsx:line 19
Stopped due to error
```
