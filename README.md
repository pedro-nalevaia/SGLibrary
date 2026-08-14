# Description
This is shared code I use across my C# Godot projects. Feel free to use them yourself.
Currently this project is quite small, but I will increment any functionality that I feel I can be re-used between the games 
I'm working on.

# This Project has:

## Fast Instantiation
For cases you want to rapidly add a node without going through the boiler plate of loading the scene into disk, calling
instantiate, adding child.

## Button Selector
A versatile node that creates and format buttons in a grid with a array of textures. They store the current pressed button
as an ID.

## Clamper
Initially I used this for the camera. The Godot camera limit doesn't actually limits the camera position, it just limits what it shows on the viewport. So I would get to an ankward state where, for example, in a level editor, I would move the camera to the leftmost part of the scene, keep moving it, it would keep going (and the viewport would stay in place), then when I moved it back I had to wait until the position reached the viewport for it to do anything. The clamper is a very reusable object that helps with that. Basically, you add the clamper with a two vectors to determine the clamped rect and the node you want to clamp (as parent), then when you want to move the object considering the clamped position, you call the MoveWithClamp() method of the clamper with a dislocation vector. The main current limitation is that this won't work for nodes that have a more complex movement management like character bodies.

## TileTools
A class that offers fast functions to deal with tilesets. Currently there is only a function to detect if a tile in the tileset
has collision.

## VisualUtils
Automatically calls fade ins and fade outs from a canvas layer, creating and destroying the sprite texture, and interpolating the 
fade ins and outs with a user set time interval.

## Useful Enums
Reading order (left-right or up-down) for uses across the project so things can still be compatible.
