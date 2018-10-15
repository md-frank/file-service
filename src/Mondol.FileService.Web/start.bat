@echo off

title FileService

set ASPNETCORE_ENVIRONMENT=Development
cd /d %~dp0
dotnet watch run -c Debug --urls http://*:5001