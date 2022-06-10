# NaviNovel
> Simple Novel Reader using ASP.NET WebForm

This is a toy project written in C# using ASP.NET WebForm as term project (2022 Spring).

Please notice that this is a very simple demo project and is **not suitable for production** and is not optimized for performance.

In addition, to build a modern website, WebForm is **NOT recommended**. I recommend using ASP.NET Core and ASP.NET Core MVC. I used WebForm for this project only **because it is required by the term project**.


## Features
* Bookshelf
* Table of Contents
* Continue reading
* File-based storage


## Book Format
[Markdown](https://en.wikipedia.org/wiki/Markdown) is used to store the novel.

Example:

```
# Book Title

## Table of Contents
* Chapter 1
* Chapter 2


## Chapter 1
Chapter 1 content.


## Chapter 2
Chapter 2 content.
```

Books are stored in the `books` folder.