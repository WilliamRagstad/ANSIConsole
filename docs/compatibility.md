# Framework and package compatibility

Decision date: 2026-10-25. Reference:
[Microsoft .NET support policy](https://dotnet.microsoft.com/en-us/platform/support/policy/dotnet-core).

| Target | Decision | Microsoft support ends |
| --- | --- | --- |
| .NET 10 LTS | Preferred; example and development SDK | November 14, 2028 |
| .NET 8 LTS | Transitional library target; tested on its own runtime | November 10, 2026 |
| .NET 9 STS | Can consume the net8.0 asset; no dedicated target or runtime test claim | November 10, 2026 |
| .NET 5 | Removed; unsupported since May 10, 2022 | May 10, 2022 |

.NET 8 is retained for migration only. Upgrade to .NET 10 before its support ends;
continued availability of an asset does not extend Microsoft's runtime support.
No .NET Standard or .NET Framework support is promised. Adding those targets would
expand the compatibility and dependency surface without a demonstrated need.
The package has no NuGet runtime dependencies. `System.Drawing.Color` and
`ColorTranslator` are framework types; no System.Drawing.Common/GDI+ dependency
is introduced.

## Version 3 migration

The minimum framework change warrants version **3.0.0**. Package ID `ANSI.Console`,
namespace `ANSIConsole`, and the lightweight string/ANSIString extension API are
preserved. Retarget .NET 5–7 applications to a supported runtime before upgrading;
otherwise remain on 2.x (which does not make those runtimes supported).

All foreground and background integer overloads now consistently use `(r, g, b)`
or `(r, g, b, alpha)`. Main already contains this correction in `c45aa59`.
If you compensated for the old background bug with `Background(r, b, g)`, remove
the compensation. Named arguments `r:`, `g:`, `b:` retain their meaning when
recompiled; already compiled named calls use positional arguments and must be
rebuilt. Binary parameter types are unchanged, but the positional behavior changes.
Alpha is still accepted and validated by Color.FromArgb but is not encoded in
24-bit ANSI output; use `Opacity` for the existing RGB blending behavior.

RGB channels must be 0–255. The old README example using `256` was invalid and is
corrected to `255`. Other documented formatting calls keep their signatures.
`NoClear()` now retains color-only formatting, matching its documented purpose.
It suppresses the trailing reset; use `Clear()` afterward to stop formatting from
spilling into later output. Normal formatting still ends in `ESC[0m`.

`Init(false)` retains its Windows console behavior. On Unix it is a successful
no-op, preventing a kernel32 load failure. This does not guarantee true-color,
hyperlink or style support in a particular terminal. When the console reports an unknown default color (`-1`), opacity uses gray
foreground and black background; explicit colors are unchanged. The gradient
example now uses an explicit black background so it also runs with redirected
output.

`NO_COLOR` and the explicit
`ANSIInitializer.Enabled` switch keep their existing behavior.

## Build and verify

Install the .NET 10 SDK and .NET 8 runtime (or SDK). `global.json` accepts stable
.NET 10 feature-band updates. From a clean checkout:

```sh
dotnet restore ConsoleANSI.sln
dotnet build ConsoleANSI.sln -c Release --no-restore
dotnet test ConsoleANSI.sln -c Release --no-build
bash scripts/verify.sh
```

The script builds both library targets, tests on both runtimes, packs version
3.0.0, restores the example using **only** the temporary local feed and an empty
package cache, and runs it using a PackageReference instead of a ProjectReference.
It removes its temporary feed/cache on exit. Run normal `dotnet restore` afterward
to return the example's assets to project-reference mode. No package is published.
CI runs the same script on Linux and Windows; Windows execution requires CI or a
Windows machine and is not implied by a local Linux pass.

For a package to keep:

```sh
dotnet pack ANSIConsole/ANSIConsole.csproj -c Release -o artifacts/packages
```

## Review sequence

1. `fix/rgb-formatting-regressions`: historical RGB reproduction, exact output tests,
   and color-only NoClear fix. See [regression evidence](rgb-regression.md).
2. `modernize/framework-package` (based on step 1): supported targets, version 3
   metadata, portable initialization, sample, documentation, and package/CI checks.

The branches are local review units; they have not been pushed or opened as PRs.
