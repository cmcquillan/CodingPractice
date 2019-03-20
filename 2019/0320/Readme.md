# Arkanoid
A simple Arkanoid clone where there is a platform that can move back and forth on a single y-axis coordinate.  A ball that has consistent momentum, and a set of bricks that will be destroyed whenever the ball impacts with them.

## Things to Remember
* You will need to draw a circle on a canvas :)
* You will have consistent momentum like in snake but it will always be at an angle.

## Outcomes
* After 25 minutes ended up in a debugging loop with a strange browser behavior.  Sometimes this happens so I am going to do another 25-minute sprint after I have figured out the issue.
* It was a setTimeout and not a setInterval...
* Got a substantial amount of movement done in the 2nd 25-minute sprint.  However, I discovered that collisions with unidentical objects are far more complex than I had anticipated.  Since I was not familiar with this math I called it before doing a third sprint.
* Arkanoid is a surprisingly complex game.
* Can probably 'short-circuit' the formal geometry in some way by detecting which plane we're on and only evaluating that 'row' of boxes, but that is an exercise for another day.
