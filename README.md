# Introduction

-------

1. Requirement

   You need Unity3d 2020.1.9 version (or higher) to run this code.
   Download the source, directly run MGD_Game/Above The Ashes/Assets/Scenes/
   Above the ashes.unity

2. Introduction to the scene

   This scene (Above the ashes) includes multiple elements which are expected to implement to this game.
   It also includes a short part of playable events which is not so hard for a novice player to explore and figure out the solution.
   The environment of this scene shows multiple elements including NPC, main character, obstacle, triggers, music and so on, which will be introduced in next part.
   
3. Introduction to elements in the scene

   **Players:** in this game, player can move, jump and interact with other elements in this scene. Also can aiming and firing to take damage to others.
   **NPC:** Most of NPCs, which is an important part in our game, are mostly zombies, so in this simple prototype, zombies are established and expected to interact with players. Zombies can kill player and play also can kill zombies.
   **Obstacle:** Obstacles in this scene are mainly the buildings
   **Triggers:** triggers in this scene includes death trigger, destroy trigger, openable trigger and so on, which show the interaction with player and make the prototype playable
   **Music:** music aims to create tension and contribute to the topic Above the ashe, after disaster.

4. How to player the game

   **Control the main character:** the main character can be controlled by keyboard wasd to move and space key to jump, the camorra will also be controlled by mouse which seem to show the reality of a human being,
   **Avoid death:** some death trigger or NPC (zombie) can lead to failure of the game. Player should control the main character to avoid them. Once the character contact with death trigger or NPCs who will cause the death, the character will be transfer to the Born Point to restart the game.
   **Enjoy the world:** this is a simple demo of the virtual world of Above the ashe, so it is not difficult for a novice player to survive in this world. What you should do is avoid death, find the reward, and enjoy this virtual world.

# Prototype

------

The game prototype describes the game experience to a certain extent.

1. Solve puzzles simply

   A simple puzzle (avoid zombie, get chest) is designed in the prototype, and players are required to find a way to complete the goal. The puzzles will be more complicated in the official version.

2. Simple mechanism

   Simple automatic doors, obstacles that can be destroyed, switches that can be activated, etc. The official version will have more interesting mechanisms.

3. Simple action

   Simple four-way walking based on free asset animation, including sprinting and jumping. The official version will abandon free asset and add more actions, such as squatting.

4. Simple interaction

   Interaction with terrain (jump to pass), interaction with NPC (to avoid being attacked by zombie), interaction with mechanism(finding way). The official version will have more interactive methods.



# Final version

------

It includes

1. Main menu and Pause menu
2. Start room: Get first clue and know what should player to do. Puzzle problem.
3. Level 1: Operate trigger to next area. Get more clues about story.
4. Level 2: Collecting keys, find a way to scape the garden which protect player.
5. Level 3: Run and fight with Zombies. No way to back, so go forward.
6. Level 4: Find what the truth is, and solve the puzzle to get final story and escape this city.
7. End of the game: Fly away this city. And truth will be display to our.



# Development team

------

They are arranged in alphabetical order, regardless of priority.

- Boyi Yang
- Wanjing Chen
- Xiaowei Liang

# Reference

------

1. Zombie: Animation and Model

   [Zombie | 3D 人形角色 | Unity Asset Store](https://assetstore.unity.com/packages/3d/characters/humanoids/zombie-30232)

2. Invector-3rd free asset: Animation and Model. Jump codes.

   [Third Person Controller - Basic Locomotion FREE | 实用工具 工具 | Unity Asset Store](https://assetstore.unity.com/packages/tools/utilities/third-person-controller-basic-locomotion-free-82048)

3. A Thief's End-Henry Jackman: Background music

4. Audio Effects: Open source in network
