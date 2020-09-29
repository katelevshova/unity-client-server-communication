# General example of the interraction between the client and server side
Still working on it.

There are 3 players on the scene and each of them can have one of the 3 types of avatar head - cube, capsule, sphere.
User can change the avatar head by left mouse-click.
In this case the client needs to send the update notification to the server side
-c:PLAYER_UPDATE_AVATAR -p:PlayerId:1,AvatarHeadTypeId:1,*

