# gsitool
Tool for adding player seating information to data provided by  CS:GO GSI

This software packages CS:GO GSI data to new object and adds player seating information to go alongside with it.

Data is sent as HTTP POST requests to user-defined endpoints. Data format is described below, gsidata field contains all data coming from the game.
~~~~ 
{
"seating":[
	{"Name":"Dennis","SteamID":"2","SeatNumber":1},
	{"Name":"Irving","SteamID":"76561197960265729","SeatNumber":2},
	{"Name":"Tim","SteamID":"76561197960265730","SeatNumber":3},
	{"Name":"Ron","SteamID":"76561197960265731","SeatNumber":4},
	{"Name":"Jerry","SteamID":"76561197960265732","SeatNumber":5},
	{"Name":"Colin","SteamID":"76561197960265733","SeatNumber":6},
	{"Name":"Nick","SteamID":"76561197960265734","SeatNumber":7},
	{"Name":"Pat","SteamID":"76561197960265735","SeatNumber":8},
	{"Name":"Keith","SteamID":"76561197960265736","SeatNumber":9},
	{"Name":"Wyatt","SteamID":"76561197960265737","SeatNumber":10}
	],
"gsidata":{
	"provider":{},
	...
	}
}
~~~~ 

Example listener config in config.json
~~~~
{
  "bindIP": "localhost",
  "bindPort": 3000,
  "listeners": ["http://localhost:8080"]
}
~~~~
