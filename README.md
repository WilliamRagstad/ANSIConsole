<div align="center">
    <img src="assets/logo_cropped.png" alt="ANSI Console" width="30%" />
    <h1><code>ANSI Console</code></h1>
    <p style="padding-bottom: 100px;">
        Lightweight and flexible text formatter<br>
        for creating beautifully colored console applications.
    </p>
</div>

## Features
* ANSI initialization for the system console. (Method shown in [Using ANSI colour codes in .NET Core Console applications](https://www.jerriepelser.com/blog/using-ansi-color-codes-in-net-console-apps/))

Learn more about ANSI escape sequences [here](https://stackoverflow.com/a/33206814/5698805).

## Resources

* https://en.wikipedia.org/wiki/ANSI_escape_code
* https://stackoverflow.com/a/33206814/5698805

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
