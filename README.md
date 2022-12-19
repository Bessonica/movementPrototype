# prototype of horror tower defence game

if you are interested in trying prototype, here is the link: https://yopizzahere.itch.io/horror-prototype

<br />

Player can:
1. interact with environment 
   - open/close letter
   - activate generator
   - open PC to control turrets
2. Choose and place turrets 
3. Change mouse sensitivity

<br />

There is simple wave system, that spawns enemies in groups.
Developer can:
1. Configure enemy settings:
   - Health 
   - Speed
   - Their path (waypoint system)
2. Configure groups settings:
   - Amount enemies to spawn in group
   - How many times to spawn group
   - Time between spawning group after each other 
3. Order all groups of enemy stop/resume movement

<br />

Game starts with simple intro with images and text that appears in real time (examples in screenshots)


## Waypoint system

Enemies move by using waypoint objects, that are placed in game world (screenshot below). 

file - EnemyMovement.cs
<br />
<br />

## Screenshots
<br />

### Game intro
![alt text](https://github.com/Bessonica/movementPrototype/blob/master/Assets/Screenshots/gamePhoto08.png "Game intro screenshot")

### Level
![alt text](https://github.com/Bessonica/movementPrototype/blob/master/Assets/Screenshots/gamePhoto02.png "level screenshot")

### Waypoints
![alt text](https://github.com/Bessonica/movementPrototype/blob/master/Assets/Screenshots/gamePhoto05.png "WayPoints screenshot")

### Letter that player can open
![alt text](https://github.com/Bessonica/movementPrototype/blob/master/Assets/Screenshots/gamePhoto01.png "Letter screenshot")

### Turret Control (view inside PC)
![alt text](https://github.com/Bessonica/movementPrototype/blob/master/Assets/Screenshots/gamePhoto06.png "Turret Control screenshot")

### Player Menu 
![alt text](https://github.com/Bessonica/movementPrototype/blob/master/Assets/Screenshots/gamePhoto03.png "Player Menu screenshot")

### Main Menu
![alt text](https://github.com/Bessonica/movementPrototype/blob/master/Assets/Screenshots/gamePhoto07.png "Main Menu screenshot")
