## Handed rules
- The ball must be operated by physics, i.e. by adding impulse force to a RigidBody.
- The player may move the ball by pushing it (colliding with) and/or kicking it (Keypress).
- The player must be operated by a character controller, and can move freely in all directions using arrow keys.
- Player variables (e.g. speed, traction etc) is configurable through the editor, and may vary on the individual levels
- The main camera should follow the ball at all times, not the player
- You should play a sound when each level starts (e.g. the referees whistle)
- You should play a sound when the ball reach the goal (e.g. a cheering crowd)
- In the top of the screen, you must display the time since game start, i.e. a running timer.
- At any time, you can press ESC and abandon the current level and return to main menu
- Make sure the pitch is bound, so the player cannot run outside the pitch

### Scripts
- [ ] Player
- [ ] Ball
- [ ] Camera
- [ ] "Game" (Pause, tid, UI)
- [ ] Opponents
- [ ] Goalie

### UI
- [ ] Main menu
    - [ ] Start game button (With functionality)
    - [ ] Quit game button (With functionality)
    - [ ] Tutorial (With functionality)
- [ ] Level Selector
    - [ ] Level 1 button (With functionality)
    - [ ] Level 2 button (With functionality)
    - [ ] Level 3 button (With functionality)
    - [ ] Level 4 button (With functionality)
    - [ ] Level 5 button (With functionality)
    - [ ] Level 6 button (With functionality)
    - [ ] Level 7 button (With functionality)
    - [ ] Level 8 button (With functionality)
    - [ ] Level 9 button (With functionality)
    - [ ] Level 10 button (With functionality)
    - [ ] Back button (With functionality)
- [ ] Pause menu
    - [ ] Quit level
    - [ ] Restart level
    - [ ] Continue level


### Sounds
- [ ] Main menu background sound/music
- [ ] Level ambient crowd sound
- [ ] Death sound (Thinking using the "Yep, thats me, you prob wondering how i ended up in this situation")
- [ ] Level complete sound

### Mandatory levels
- [ ] level 1
- [ ] level 2
- [ ] level 3

### Known features (See discriptions for each features furter down)

- [ ] The Story line
- [ ] The Streaker
- [ ] The Multiplayer game (multiple controlled characters for singleplayer)
- [ ] Multiple camera angles
- [ ] Time limits and scoreboard


### Levels we added
- [ ] Level 4
- [ ] Level 5
- [ ] Level 6
- [ ] Level 7
- [ ] Level 8
- [ ] Level 9
- [ ] Level 10

### Features we added
- [ ] The Multiplayer game (2 players can play at the same time (not networking))
- [ ] The Multiplayer game (2 players can play at the same time (networking))

# Feature descriptions
## The Story line
As is common in many games, you cannot enter a level without having completed the previous level. Initially only the first level is available, once that is completed, the next level is made available. You should update the main menu, so only the available levels can be played (e.g. disable the play buttons on levels that are not completed yet). You do not need to store the state, but rather keep it in memory and let it reset each time you restart the game.

## The Streaker
In some leagues, you have the occasional streaker, i.e. a person that enters the pitch and run across it, usually to provoke or promote a political statement. Very random, a streaker can appear and run across the centre line and then disappear again.

## The Multiplayer game
Instead of having just a single player, you can add multiple players to your team on advancing levels. You would then have an ‘active’ player, that operates by the key presses, and having a key to switch between your players (use F as the trigger key). The active player should be visibly unique on the pitch (e.g. have a marker over his head or something). 

## The multi-camera angle

Place more than one camera near the ball so it can be seen from different angles. Only one camera should be active at any time (which is the way to switch between them). Implement a key trigger (Use C as the trigger key) to toggle between the active cameras. At least one of the cameras should follow the player/active player

## The Time-Limit and record tables
You should introduce a standard time to complete the level, and then present a count-down instead of a running clock. Before expiring, the clock should provide visible and audible clues, i.e. changing font colours, playing a warning sound. Do this when a configurable percentage of the time is left, e.g. 10%. The time taken to complete a level should be stored in memory together with the current time, and this information will be presented on the main menu, so you can see when someone broke the fastest record. If a level has not been completed, no information should be shown

