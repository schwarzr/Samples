@echo off

cd ..


call npm run nswag -- swagger2tsclient /TypeScriptVersion:2 /Template:Angular /HttpClass:HttpClient /PromiseType:Promise /NullValue:undefined /GenerateClientClasses /Output:"src/service/service.ts" /input:"http://localhost:5001/swagger/v1/swagger.json" /InjectionTokenType:InjectionToken /RxJsVersion:6


PAUSE

