# URL Shortener
Basic webserver to consistently expand URLs.  Persistence is a maybe.

## Requirements
* Store mapping of short URL to large URL
* Allow generating new URL mappings

## Outcome
Took longer than expected.  Had to take a break to do errands before resuming.  Coming back to the project and finishing out the basic URL shortener probably was about 40 minutes.

The parts that were unexpected were:
1. Getting the final URL to send back down to the client.  ASP.NET Core generally does not like providing absolute URIs.  
2. Working with VS Code without the assistance of some Visual Studio comforts.  I think it would be beneficial to work in VS Code more to reduce dependence on the Visual Studio tooling.
3. The amount of 'factoring' I was attempting to do.  At the end of the day I probably should have just tried to write the entire app in Startup.cs and index.html.  Attempting to do a URL Shortener again with that constraint might make for a good future self-challenge.
