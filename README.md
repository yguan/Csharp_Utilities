# What is it?

This repository contains useful utility classes.

## How to run the tests?

To build the test project, you need to follow the instructions on this [post](http://docs.nuget.org/docs/workflows/using-nuget-without-committing-packages) to set up Nuget correctly on your Visual Studio. Then you need to install [Gallio](http://gallio.org/Downloads.aspx) (version 3.3.x.x), and use it to run the tests.
## ObjectMapper

This is inspired by [AutoMapper](https://github.com/AutoMapper/AutoMapper). It is a really simple mapper, and it provides simple way to define mapping function. Now you can centralize where to define the mapping and use the mapping by calling `.MapTo`.