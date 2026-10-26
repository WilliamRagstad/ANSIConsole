# RGB regression evidence

Issue [#3](https://github.com/WilliamRagstad/ANSIConsole/issues/3) describes the
old background signature `(r, b, g)`. Main already contains the correction in
`c45aa59`; this change protects that correction rather than reapplying it.

For `"x".Background(17, 83, 241)`, the old implementation emits
`ESC[48;2;17;241;83mxESC[0m`; the expected output is
`ESC[48;2;17;83;241mxESC[0m`. Foreground uses RGB throughout.
The regression suite covers string and ANSIString receivers, alpha overloads,
named arguments, and the GradientBackground call site with distinct channels.

To reproduce on the parent of the original fix, temporarily replace only
`ANSIConsole/StringExtensions.cs` with `git show c45aa59^:ANSIConsole/StringExtensions.cs`
and run the RGB and background-gradient tests. Restore the current file afterward.

The tests also cover exact style ordering, reset emission and suppression,
links, inline formatting, and disabled output. A separate reset defect was found:
`Color(...).NoClear()` and `Background(...).NoClear()` returned plain text because
no style flags remained. Removing that early return preserves the requested
color while suppressing only the trailing reset.

Verified on Linux with SDK 10.0.402: the historical source fails all four selected
RGB/gradient cases. Current source plus the NoClear fix passes all 17 tests.
Until the framework update, run with
`dotnet test ANSIConsole.Tests -c Release -p:GeneratePackageOnBuild=false`.
