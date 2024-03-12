# Features

We try to make different features as *horizontal slices*.

![image](vertical_development.png)

**A feature should represent end-to-end functionality.** This functionality is a
slice of the whole, but it should be complete on its own!

Try to assemble your work in a way that you move from one working state to another
quickly. Don't leave not working states for long! Ideally, all commits contain a
working set of functionality (it compiles, it doesn't crash, etc.).

Our feature set can be summarized as the following.

## Target 0
Setup a working environment! We should also create a working agreement.

## Target 1
Create a representation for the planetary system at all levels of the application,
and show it!

At this point the planetary system should be contained in the simplest form possible.
This can a file of any format (I recommend text format so you can edit it easily).
At this point this is our database layer (a heavily lacking database layer).

In C# you should create classes that can be filled based on the data from the
descriptor files.

In the frontend you should be able to query for the planetary system, and print its
data out into the page (or even to the console).

**The slice is complete when the planetary system can reach the front-end from the
file system.**

*Notes:*

Most important data of a planet:

```
position: x,y
velocity: x,y
radius: number
name: string
```