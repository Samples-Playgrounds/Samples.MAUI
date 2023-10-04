# SVG Font-family does not apply after convert to png(Splash screen) #16399

16399

https://github.com/dotnet/maui/issues/16399

https://github.com/denhaandrei/BadSvgConverter.App


This is not directly maui issue. namely managed libraries used by `resizetizer` 
have issues converting some (complex) SVG images to PNG.

Workaround would be to convert SVG to PNG using reliable converters.

*   original

    `splash.svg`

    
*   `resizetizer`

    `resizetizer-splash.png`

    ! OK

## Online Converters

*   https://svgtopng.com/

    OK

    `svgtopng.com-splash.png`

*   https://cloudconvert.com/

    `cloudconvert.com-splash.png`

    ! OK

*   https://convertio.co/svg-png/

    `convertio.co-splash.png`

    ! OK

*   https://ezgif.com/svg-to-png

    ! OK

    `ezgif.com-splash.png`

    
I work on collecting reported issues, so I can open issues on GitHub.