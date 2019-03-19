# Procedural Generation Hero Graphic
Write a hero graphic (width: 100%, height: 600px) that randomly generates characters which 'fly' across the screen. They should have the following characteristics:
* Font-awesome icons.  Use at least 4.
* Start on right side of screen and slowly float to left.
* Vary in size
* Vary in speed
* Vary in 'Z' axis
  * This should relate the size, as the bigger ones would be 'closer' to the screen.

## Outcomes
The project was mostly complete in 30 minutes.  The exceptions are that two of the font awesome glyphs were not rendering properly within the canvas (though they did render on the test list, would require debugging).  The other items s that they did not appear 'sorted' on the Z-axis.  Overall though, the appearance of the glyphs was dynamic, fluid, and visually interesting.

Things that interested me while doing this project:
* I decided that finding the glyphs I wanted to use was part of my 'time'.  This proved to be interesting since some glyphs did not work on the canvas.
* Visually, the speed should probably line up somewhat with the 'closeness' to the screen.  This would be a better '3D' effect.
* Overall it was a pretty straightforward challenge.  I have enjoyed working on these small JS canvas projects as they get me better used to plotting coordinates and making small animations.