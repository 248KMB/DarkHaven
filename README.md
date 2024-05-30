# Project Title

## Introduction
*Welcome to my project page for **DarkHaven**. Dark Haven is a 3D RPG(role-playing game) that has been creatively put together by Unity assets and consists of a warrior who needs to kill all the mobs in a dungeon. I joined a team of 5 for a class project to push our game design careers with our first-ever game.*

## Detailed Description
*Our project is inspired by popular video games like Diablo, Monster Hunter, and Dark Souls. We aim to capture the engaging world and combat mechanics of Monster Hunter, where you can use various weapons and experience dynamic gameplay. We aim to recreate the excitement we felt when first playing these games, from the detailed world-building to the enjoyable gameplay. To achieve this, we've added unique elements, including a fluid combat system, a carefully crafted world viewed from a top-down perspective, and a dark atmosphere that enhances the overall experience.*
*As you step into the role of the Hunter, your mission is clear: you're a Bounty Hunter from the respected Hunters Guild, tasked with eliminating the monstrous threat in Dark Haven. Along your journey, you'll encounter the enemy. Your valued skills and growth as a Hunter will determine whether or not you’ll be able to succeed in conquering the dungeon of Dark Haven.* 

**Key Objectives:**
- *Objective 1: Enter the dungeon*
- *Objective 2: Slaughter all mobs* 
- *Objective 3: Reach the final boss* 

## Role and Contributions
*I served as the lead game designer, level designer, and narrative designer in this project. My primary responsibilities included:*
- *Task 1: Creating the storyline*
- *Task 2: Designing the levels*
- *Task 3: Mob implementation*

## Key Features
***Dark Haven** boasts several unique features:*
- ***Unique Combat Mechanics:** The game boasts a sophisticated combat system with detailed health and damage tracking for players and mobs. This system ensures dynamic interactions and challenges, allowing for a varied and engaging combat experience.*

- ***Aggression System:** Utilizing an advanced radius sensor, the game features an aggression mechanism where mobs react to the player's proximity. If a player ventures too close, the mobs will actively pursue, adding an element of strategy and tension to the gameplay.*
   
- ***Unity Asset Support for Fighting Animation:** Leveraging the rich library of Unity assets, the game incorporates high-quality fighting animations. This enhances combat's visual appeal and fluidity, providing a visually compelling and satisfying experience for players and mobs.*

## Technologies Used
*The development of this game utilized the following technologies:*
- ***Game Engine:** Unity* 
- ***Programming Languages:** C#*
- ***Other Tools:** Github*

## Media {IN PROGRESS]
### Screenshots
Here are some screenshots from the game:

- ![Screenshot 1](link-to-screenshot1.jpg)
- ![Screenshot 2](link-to-screenshot2.jpg)
- ![Screenshot 3](link-to-screenshot3.jpg)

### Videos
Watch gameplay videos or trailers:

- [Gameplay Video 1](link-to-video1)
- [Gameplay Video 2](link-to-video2)

## Development Process
### Planning
*The planning phase first involved the story. As the team leader, I gathered input from all team members to shape the game's narrative. We devised an engaging plot centered around a warrior desperate for money. This warrior approaches a guild and learns of a mission to clear out a dangerous dungeon, setting the primary goal for the player. This led me to make two distinct scenes: the home and the levels scenes. We then ensured there were barriers for the player not to pass through and ensured the user was in the right areas of the game. The main components we planned for the game were ensuring we had all RPG-related mechanics like third-party vision, mob/ player animations, and health and damage systems. Regarding damage, regular mobs are two attack points and incrementally rise for higher-ranked mobs like mini-bosses and the boss.*

### Design
#### Scene Design
***Dungeon layout**: Each level in the scene will be unique in terms of shapes.* 
***Home layout**: will be wide enough to explore the scene and have a gateway.* 

#### Environmental Design  
***Terrain**: Use the grass, rocks, and tree assets to create varied landscapes. Use Unity's Terrain tools to sculpt hills, valleys, and other natural features.*
***Structures**: Cabins, camps, and gates strategically ensure these structures have logical placements relative to the terrain (e.g., nearby woods). There will be a gate for entering the cave and teleportation gates for going through levels.* 
***Flags**: flags to illustrate controlled areas.*
***Barrels and Crates**: Use for environmental storytelling elements.*
***Torches**: Torches will further improve the dungeon experience.*

#### Character Design 
- ***Knight Design**: Ensure the knight's armor and weapons are period-appropriate.*
- ***Animations**: Leverage the animation package for smooth combat, idle, walking, and running animations.*

### Implementation
#### Implementation of Scene Design
##### Home Scene
- ***Home Scene Layout**: To make the layout of the home scene, I first position where the blockage of rocks(so that the player can't have access to non-game places) near the middle of the plane.*
- ***Levels Scene**: I used a generator asset to generate unique dungeon layouts and customized the structures of each layout in terms of size and height.*

#### Implementation of Environmental Design 
##### Home Scene
- ***Terrain**: I used Unity terrain brush to create flatted terrain, which later I imported the texture of grass and overlapped the terrain with grass texture and color. Furthermore, I import grass objects in the terrain brush to span grass objects throughout the terrain. I manually imported and then duplicated rocks surrounding the home level to limit the player from passing through to unwanted spaces. Cabins and trees have been put selectively throughout the home level by manually duplicating and moving them to other sections of the level.*
- ***Structures**: I implemented the cabins and camps by dragging and duplicating the necessary assets to selective positions throughout the home level. To enter the dungeon, I implemented an asset gate resembling the entrance.*
  
##### Levels Scene
- ***Terrain**: For the levels scene, I used a generated dungeon asset that made unique shapes for each level of the dungeon; I later used colorful textures to customize each layer of walls of each dungeon, color coding them.*
- ***Structures**: I strategically implemented and duplicated flags, barrels, and torches to give each level a unique look.*

##### Implementation of Character Design 
***Knight Design**: I used the selective package to implement the character and its weaponry(the shield and mace). After implementing the character, the animations were added in and connected via the animation manager system in Unity. Animations consist of idle, walking, attacks, and running. 
**Mob Design**: Similar to the character, I used a Unity Asset for the mobs with their own animations and character design. Animations involve idle, attack, and walking.* 

#### Implementation within Scripts
- ***Damage and Health**: I did a simple damage and health system tracking the health of players and mobs using colliders that trigger the boxes of the players and mobs.*

### Testing
#### Testing Damage and System 
*We extensively tested the damage and health system by starting combats with the mobs and used string printouts to keep track of each attack and the amount of health the player has. For example, each time the player is taking damage, the terminal will print out the health and damage taken*
#### Testing Animations 
*During the testing for the player and mob animations, we made sure to strategically set up the animation manager in Unity to match the field names in the scripts. To make sure that the character is moving, field names within the script of the character controller and their respective animation manager are put side by side as the character is moving*
#### Teleportation gates
*To test the teleportation gates, I ensured frequent entry and that the user was smoothly transferred to the level scene. I changed the gateway's box collider to ensure it is not too small or too big to have unrealistic interactions with the gateways. A simple walk-in and transfer*
#### Testing Combat
*To test the combat, I kept track of the box collider of the mace and the mobs to see if they successfully interacted with each hit from the player and mob.*

## Challenges Faced
*Throughout the development of **Darkhaven**, we encountered several challenges:*
- ***Animations:** The First challenge was getting the animations to work correctly since it was our first time using the animation manager in Unity. We encountered numerous errors with scripts incorrectly setting up the animation manager to connect all the animations, like idle, attacks, and running together. However, we solved this by doing extensive research on how to work with animations and figured out how to start the animation and get it to trigger when the user presses the necessary button for the action to occur.*
- ***Time constraint:** One challenge we faced was the time scope and the ability to add more in the given time. We eventually just focused on the fundamentals of the game, putting those first, and finished the game with great assets.*
- ***PathFinding** For mobs to track down the user once it enters the mob's 'field of vision,' we needed to make sure the pathfinding was correct; however, that needed knowledge of Artificial Intelligence. We extensively tested as much AI pathfinding as possible to ensure the mob precisely chased the character; we concluded that A* was the best.*

## Conclusion
***Dark Haven** was an incredible learning experience that allowed me to grow as a game designer. Through this project, I gained valuable Game Design, Level Design, and Leadership skills. I am proud of the final product. Thank you for taking the time to learn about my project!*

## Play the Game
*You can play <a href="https://simmer.io/@oreowaffle/darkhaven">**DarkHaven**</a> now!*

## Contact
*If you have any questions or feedback, feel free to reach out to me at kobemartinez98@yahoo.com*

---

<a href="#"> *back to my portfolio* </a>

---
