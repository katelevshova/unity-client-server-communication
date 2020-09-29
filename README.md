# General example 

PURPOSE: 

To showcase the implementation of the communication between the client and server side (Still working on it)

DESCRIPTION:

There are 3 players on the scene and each can has one of the 3 types of head avatar - AvatarCapsuleHead, AvatarCubeHead or AvatarRoundHead.

User can change the avatar head by clicking on the current head.

In this case the client side needs to send a notification to the server about the change by sending a message.

Example of the message:
-c:PLAYER_UPDATE_AVATAR -p:PlayerId:1,AvatarHeadTypeId:1,*

The server side will store the data and then send the update message to all clients.

In this case the client needs to process the response message.

**Click on the image below to see the demo video.**

<div align="center">
      <a href="https://www.youtube.com/embed/orySY8czMbc">
     <img src="https://user-images.githubusercontent.com/11220246/94610306-f1abab00-0254-11eb-8d87-0964195ebce5.png" 
      alt="Demo video" 
      style="width:100%;">
      </a>
    </div>
