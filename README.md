# WCUnity
Bare-bones remake of Wc1 in Unity

## 🎮 Gameplay / Changes to original Demo

To simplify gameplay state transitions and provide a clean loop for testing or in-game logic, a \`RollingUpdate()\` method was introduced. This method replaces the deprecated \`Killallships()\` functionality. From the main menu if you wait it moves into rolling demo, you can exit that with 'ESC' key. Clicking on the first item in the menu is the playable rolling demo (also exitable with 'ESC' key).

<br/>It performs the following:  
\- Clears all AI-controlled ships from the scene  
\- Cycles the player to the next available ship  
\- Spawns a fresh batch of AI ships (randomly from different factions)  
\- Triggers radar and HUD refresh flags  
<br/>The system is bound to the \*\*\`K\`\*\* key by default.

**Input Overview (Keyboard-based):**

| **Action** | **Key** |
| --- | --- |
| Fire | L-Click/Space |
| --- | --- |
| Full Stop | S   |
| Full Speed Ahead | W   |
| Accelerate | Q   |
| Decelerate | E   |
| Afterburner On | Left Shift |
| Afterburner Off | Release LShift |
| Cycle Player Ships | \[  |
| Spawn AI Ship | \]  |
| Toggle AI Ships | K   |
| Exit Demo | Esc |
