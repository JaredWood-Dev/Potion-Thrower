# Potion Thrower: Game Design Document

## 1. Introduction
### 1.1 Purpose
The purpose of this software or "game" is to both entertain its users or "players" with a fun and engaging interactive experience. It is also to provide as a suitable project to implement and learn new software development techniques and build experience.

### 1.2 Intended Audience
The intended audience of this document is for Jared Wood, as the main developer to document the features of the game, and for students of computer science to learn computer science concepts.

### 1.3 Intended Use
The intended use of this document is to document gameplay features and development notes for future reference and sharing development ideas with others.

### 1.4 Definitions and Acronyms
This document uses the following definitions and acronyms.

- "Game" refers to the software that this document is a reference for.
- "Syruyar" refers to the main character of the game, that the player controls. Also referred to as the "thrower" or "player".
- "Potions" refer to the main object that is thrown by Syruyar, and the object that interacts with many other objects within the game.
- "FPS" is an acronym for Frames Per Second, a metric for measuring game performance.

# 2. Game Features and Requirements
### 2.1 Functional Requirements
#### 2.1.1 Potion Throwing
The player will be able to use the arrow keys to aim which direction to throw a potion. The player will be able to hold the space bar and upon release a potion will be thrown at the current angle with a power based on how long the space bar was held.
#### 2.1.2 Targets
There will be targets within the game for the player to throw potions at in order to "win" a level. When a potion collides with a target it will reduce the target's hit points, and if those hit points are reduced to zero, the target is destroyed. When the player destroyed all the targets in a level, the level will be completed.
#### 2.1.3 Potion Queue
When the player attempts to throw a potion, the next potion thrown will be decided by a queue of varying potion types. Once a potion is thrown it will be removed from the queue.
#### 2.1.4 Potion Types
There will be a varying amount of different potion types that have different effects when a hit a target or object with a health component.
##### 2.1.4.1 Damage Potion
Damage Potions reduce the amount of hit points an object with the health component has. A specific variation of the Damage Potion is the _Acid Vial_.
##### 2.1.4.2 Health Potion
Health Potions increase the amount of hit points an object with a health component has, if the "isObject" boolean on the object is false.
##### 2.1.4.3 Water Bottle
Water Bottles will be another type of damage potion, but will be thrown if the player has no other potions in the potion queue.
### 2.2 Non Functional Requirements
#### 2.2.1 Performance
The game will run at a minimum of 60 fps on moderately powerful hardware.
#### 2.2.2 Control Accessibility
The game will be playable with a mouse and keyboard.