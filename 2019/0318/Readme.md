# Paint Clone
Make a simple paint clone with the following specs.
* 600 x 600 canvas
* Color choices of Red, Green, Blue, White, Black
* Brush Sizes of 1, 5, 10, 25 diameter
  * Circle on screen to mark brush (mouse) location 
* Optional: Erase Brush
* Optional: Save as .png (?)
* Optional: Additional brush type (square)

## Outcome
Managed to get the basic requirements together in about 28 minutes.  The only requirement I missed at the time was the guide circle.  This probably would have been the most challenging piece since it would require saving and repainting the state of the canvas underneath an otherwise "floating" circle.  This would have been difficult to complete in any short amount of time.  Perhaps another challenge later to implement this feature within 30 minutes?

Other items that I found interesting while working:
* I did not have any idea how to paint a circle on a canvas.  The context.beginPath(); context.arc(); context.fill() sequence was something I had to look up.
* I should work on a better understanding of the other parameters of arc().
* I needed to remember the basic javascript method of getting form values.  Remembering this for the future would be handy.
* I figured out very quickly that I would need the mouse movement to handle the painting while mouse down and up would have to just toggle some state.  Going into this exercise I had the misconception that mousedown was the only event handler I would need.
* Getting the current cursor position within the canvas required some frustrated googling.
