#!/bin/bash

[ -d bin ] && rm -rf bin

dotnet build  ./src/Luban/Luban.csproj -c Release -o bin