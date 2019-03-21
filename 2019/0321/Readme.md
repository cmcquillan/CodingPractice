# Quick-Learn Task Parallel Library (TPL) Paradigms
The goal is to learn some items from TPL quickly and efficiently.  The current hope is that TPL is available on .NET Core as that is the easier way to iterate in a VS Code window.

## Goals
* Tasks
* Running Tasks
* Different ways of running tasks.

## Outcomes
* My primary purpose here was not to 'create' something in 25 minutes but to do an exploratory dive into a concept and see if I had any new insight.
* Doing other exploratory dives like this in the future, but for specific frameworks might be interesting.
* Most of this was information that I previously knew.  
* I have previously not previously utilized continuations. They do seem to provide a useful tool for separating functions/methods which need to be called together, which is not something I had utilized before, preferring a more naive pattern.
* I took some of the time out to experiment with the 'order' in which items were being scheduled and executed.  From this I learned that creating a task via Task.Run() will immediately start the execution despite not being awaited.  This is different from similar Observables in RxJS which tend not to execute until subscribed.
