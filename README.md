# Translation application

This implements the Topcoder practice challenge called [Build a Language Translation App](https://www.topcoder.com/challenges/dd729770-164e-4c51-b5d3-c9f335f3e90c).

```
$ translation.exe 'Jak se dnes máte?' 'Ziemlich gut. Danke!' 'So glad to hear that...'
¿Cómo estás hoy?
Bastante bueno.
Me alegro mucho de oír eso...
```

As shown above, the utility translates sentences provided on the command-line into Spanish. The input sequences can be any language.

## Usage

Build:
```
dotnet build .
```

Run:
```
./bin/Debug/netcoreapp3.1/translation.exe 'My first sentence.'
```