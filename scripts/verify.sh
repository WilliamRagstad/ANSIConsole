#!/usr/bin/env bash
set -euo pipefail
cd "$(dirname "$0")/.."
dotnet restore ConsoleANSI.sln
dotnet build ConsoleANSI.sln -c Release --no-restore
dotnet test ConsoleANSI.sln -c Release --no-build
# A fresh cache ensures the sample consumes this package, not a cached release.
verification_dir=$(mktemp -d)
trap 'rm -rf "$verification_dir"' EXIT
dotnet pack ANSIConsole/ANSIConsole.csproj -c Release --no-build -o "$verification_dir/feed"
dotnet restore ExampleANSIConsole/ExampleANSIConsole.csproj \
  -p:UseLocalPackage=true --source "$verification_dir/feed" --packages "$verification_dir/packages" --force
dotnet run --project ExampleANSIConsole -c Release --no-restore -p:UseLocalPackage=true -- --verify
