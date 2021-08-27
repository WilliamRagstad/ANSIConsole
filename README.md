<div align="center">
    <img src="assets/logo_cropped.png" alt="ANSI Console" width="30%" />
    <h1><code>ANSI Console</code></h1>
    <p style="padding-bottom: 100px;">
        Lightweight and flexible text formatter<br>
        for creating <em>beautiful</em> console applications.
    </p>
</div>


## Features
* Color formatting using: `System.ConsoleColor`, `System.Drawing.Color`, **RGB**, **HEX**, **Named/known colors** ([list](https://docs.microsoft.com/en-us/dotnet/api/system.windows.media.brushes?view=net-5.0)) and **True color** (24-bit format with over 16.7 million colors, [Wikipedia](https://en.wikipedia.org/wiki/Color_depth#True_color_(24-bit)))
* Styles: Bold, Italic, Underlined, Overlined, Strike-through, Inverted, Faint, Opacity, Blink, Uppercase and Lowercase.
* Hyperlinks
* Chainable formatting methods.
* ANSI initialization for the system console (If not enabled already). *(Method shown in [Using ANSI color codes in .NET Core Console applications](https://www.jerriepelser.com/blog/using-ansi-color-codes-in-net-console-apps/))*
* Builds on-top of the default `Console` using `string` extension methods.

Learn more about ANSI escape sequences [here](https://stackoverflow.com/a/33206814/5698805).

## Related projects

* [Spectre.Console](https://github.com/spectreconsole/spectre.console)
* [Colorful.Console](https://github.com/tomakita/Colorful.Console)
* [Pastel](https://github.com/silkfire/Pastel)
* [rich](https://github.com/willmcgugan/rich)
* [Spectre.Terminals](https://github.com/spectreconsole/terminal)
* [System.Terminal](https://github.com/alexrp/system-terminal)

## NO_COLOR

No formatting will be applied for systems where console color output has explicitly been requested to be turned off using the environment variable `NO_COLOR`. See more information about this initiative at [https://no-color.org](https://no-color.org/).

This can be overwritten by setting the `ANSIInitializer.Enabled = true`.

## Resources

* [ANSI escape code](https://en.wikipedia.org/wiki/ANSI_escape_code)
* [List of ANSI color escape sequences](https://stackoverflow.com/a/33206814/5698805)
* [Hyperlinks (a.k.a. HTML-like anchors) in terminal emulators](https://gist.github.com/egmontkob/eb114294efbcd5adb1944c9f3cb5feda#the-escape-sequence), [Support hyperlink ansi escapes in the integrated terminal](https://github.com/microsoft/vscode/issues/39278)
* [Operating System Command (OSC)](https://chromium.googlesource.com/apps/libapps/+/a5fb83c190aa9d74f4a9bca233dac6be2664e9e9/hterm/doc/ControlSequences.md#OSC)

## Blogs

* [Build your own Command Line with ANSI escape codes](https://www.lihaoyi.com/post/BuildyourownCommandLinewithANSIescapecodes.html)
* [Using ANSI color codes in .NET Core Console applications](https://www.jerriepelser.com/blog/using-ansi-color-codes-in-net-console-apps/)
* [Spectre.Console lets you make beautiful console apps with .NET Core](https://www.hanselman.com/blog/spectreconsole-lets-you-make-beautiful-console-apps-with-net-core)

