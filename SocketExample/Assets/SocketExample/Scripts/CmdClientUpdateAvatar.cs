using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CmdClientUpdateAvatar: Command
{
    public delegate void ActionUpdateAvatar(int playerId);
    public static event ActionUpdateAvatar OnUpdateAvatar;

    public override void Execute<TypeOfValue>(TypeOfValue value)
    {
        name = ProtocolList.PLAYER_UPDATE_AVATAR;
        // Update UI
        Player player = value as Player;
        Debug.Log("player= " + player.name);
        OnUpdateAvatar?.Invoke(player.id);

        //Prepare message and Send it to the server
        InitSendToServerCmd(player.id, player.avatarHead.GetTypeId());
    }


    private void InitSendToServerCmd(int playerId, int avatarHeadId)
    {
        Debug.Log("->InitSendToServerCmd: playerId=" + playerId + ", avatarHeadId=" + avatarHeadId);
       
        paramsDict.Add("PlayerId", playerId);
        paramsDict.Add("AvatarHeadTypeId", avatarHeadId);

        PrintParameters();
        string message = BuildMessageToServer();
        Debug.Log("message= " + message);
        
        //TODO: uncomment this line when the connection starts working
        
        //GameController.Instance.connectorProxy.Send(message);
    }
}
