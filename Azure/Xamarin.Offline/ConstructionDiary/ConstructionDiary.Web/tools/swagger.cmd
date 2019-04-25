@echo off

cd ..

dotnet publish ..\ConstructionDiary.Api\ConstructionDiary.Api.csproj -o ../temp/publish

call npm run nswag -- webapi2swagger /Assembly:"../temp/publish/ConstructionDiary.Api.dll" /AspNetCore:true /DefaultPropertyNameHandling:CamelCase /output:"../temp/swagger.json"

call npm run nswag -- swagger2tsclient /TypeScriptVersion:2 /Template:Angular /HttpClass:HttpClient /PromiseType:Promise /NullValue:undefined /GenerateClientClasses /Output:"src/service/service.ts" /input:"../temp/swagger.json" /InjectionTokenType:InjectionToken /RxJsVersion:6


PAUSE

