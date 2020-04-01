# unity-zombie-game
Funky zombie game implemented with some graphic assets using Unity 

● When starting the application, the user can start the game, watch it
results or change your name.


● During the game, the user controls the character, which is vertically
or horizontally moves through the maze, collecting resources (coins).


● Coins are randomly generated in the maze, 1 piece every 5
seconds. At the same time no more than 10 can be in the maze
coins.


● The opponent of the player is a few zombies and a mummy. In the event of a collision
with the enemy, the character dies and the game ends. If the character
dies in the event of a collision with a mummy - all coins collected in the game
zeroed out.


● At the beginning of the game, along with the character, one zombie appears on the map. is he
operates in random mode. If a player collects 5 coins,
the second zombie enters the maze. If the player collects 10 coins - on the map
a mummy appears maze that moves twice as fast
than zombies. When a player collects 20 coins, opponents switch from
the mode of random movement to the movement mode on the player by
optimal route. Each next coin increases speed
5% enemy movement.


● The user can end the game by pressing the Esc key.


● At the end of the game (in the event of a collision with an opponent or exit
applications) its results are saved in an xml file.


● When viewing the outcome of the game, the table displays the results data
launchers loaded from xml-file: username; quantity
collected coins; time spent in the maze; game launch date;
reason for completion (the death of the character from a meeting with the enemy or
player exit the application). The result table displays all
games sorted by date (the results are displayed at the top of the table
last run, below are the results of the very first run)


● Each time the game starts, a new maze is generated.
