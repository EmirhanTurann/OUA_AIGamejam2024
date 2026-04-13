# Temple of Reversal

A 2D auto-run side-scroller set inside an ancient temple, where the player must escape a giant rolling boulder while using time-based magic and transformation abilities to survive.

## Overview

**Temple of Reversal** is a 2D side-scroller prototype built around constant forward pressure.  
The character runs automatically from the start of the level, while the player must react to obstacles, enemies, and level challenges using carefully timed abilities.

The main goal is to reach the end of the level without being crushed by the massive boulder chasing from behind.

## Core Gameplay Loop

The player is constantly pushed forward by the game's auto-run structure and must make quick decisions under pressure:

- Jump over environmental hazards and obstacles
- Cast time magic on mummy enemies
- Collect hourglasses to restore mana
- Switch between large and small form depending on the situation
- Pass through narrow spaces while small
- Return to normal size when platforming or jump clearance is needed
- Manage mana carefully, since magical abilities consume it
- Keep moving before the rolling boulder catches up

## Main Mechanics

### Auto-Run Movement
The character runs automatically throughout the level, making the gameplay focused on timing, reaction, and ability usage rather than manual horizontal movement.

### Jump-Based Traversal
Since the player does not control horizontal movement directly, jumping becomes the main traversal input for avoiding hazards and navigating the temple.

### Rolling Boulder Pressure
A giant boulder constantly chases the player from behind, creating tension and forcing quick decisions.

### Time Magic
The player can cast a spell on mummy enemies to reverse them back to their former state.  
This ability consumes mana and must be used strategically.

### Transformation Mechanic
The player can switch between large and small form depending on environmental needs.  
Small form allows passage through narrow areas, but limits movement options in some platforming situations.  
Returning to large form is necessary for handling jumps and traversal sections more effectively.

### Mana System
Mana is a limited resource shared across the player's magical abilities.  
It can be restored by collecting hourglasses placed throughout the level.

## Controls

- **Jump:** Space
- **Cast Time Magic:** Left Click
- **Toggle Size (Grow / Shrink):** Right Click

## My Contribution

I developed the core gameplay systems of the prototype, including:

- auto-run gameplay flow

- jump-based obstacle traversal
- rolling boulder pressure system
- mana collection and mana consumption logic
- enemy interaction through time-based magic
- size transformation mechanic for traversal
- gameplay balancing between pressure, platforming, and resource usage

## Tools & Tech

- **Engine:** Unity
- **Language:** C#
- **Genre:** 2D Auto-Run Action Platformer

## Gameplay

![download (4)](https://github.com/user-attachments/assets/cf6b3320-a1aa-48b8-951d-5d0881c6bf01)
![download (2) (1)](https://github.com/user-attachments/assets/0622c0a2-1d5e-4e04-b64d-586ac1073042)
![download (5) (1)](https://github.com/user-attachments/assets/1ed23f26-d956-4295-b05a-80d01499019f)
![download (2) (2)](https://github.com/user-attachments/assets/9e6d9666-d399-496b-b0cb-802a06c698f0)

## What I Learned

This project helped me practice designing gameplay around constant pressure and limited player control, especially by combining:

- auto-run pacing
- timing-based platforming
- resource management
- enemy interaction mechanics
- transformation-based traversal
