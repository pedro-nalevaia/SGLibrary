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

## TileTools
A class that offers fast functions to deal with tilesets. Currently there is only a function to detect if a tile in the tileset
has collision.

## VisualUtils
Automatically calls fade ins and fade outs from a canvas layer, creating and destroying the sprite texture, and interpolating the 
fade ins and outs with a user set time interval.

## Useful Enums
Reading order (left-right or up-down) for uses across the project so things can still be compatible.
