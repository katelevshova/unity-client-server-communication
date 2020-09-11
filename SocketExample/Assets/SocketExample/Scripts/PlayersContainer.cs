using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersContainer : MonoBehaviour
{
    public List<Player> playersList;
    public AvatarsInfo avatarsInfo;

    // Start is called before the first frame update
    void Start()
    {
        InitPlayersList();
        SubscribeToEvents();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void InitPlayersList()
    {
        //Debug.Log("[PlayersContainer]-> CreatePlayersList");
        playersList = new List<Player>(GetComponentsInChildren<Player>(true));
    }

    private void SubscribeToEvents()
    {
        //Debug.Log("[Player]->SubscribeToEvents");
        CmdClientUpdateAvatar.OnUpdateAvatar += UpdateAvatar;
    }

    private void UpdateAvatar(int playerId)
    {
        Debug.Log("[Player]->UpdateAvatar: playerId="+ playerId);
        Player player = GetPlayerById(playerId);

        //Debug.Log("current GetTypeId=" + player.avatarHead.GetTypeId());

        GameObject nextAvatar = GetNextAvatar(player);//(player.avatarHead.type.ToString());
        player.ReplaceAvatarWithNext(nextAvatar);

      
    }

    public Player GetPlayerById(int id)
    {
        return playersList[id];
    }

    private GameObject GetNextAvatar(Player player)
    {
        string _type = player.avatarHead.type.ToString();
        //Debug.Log("->GetNextAvatar: ");
        int avId = (int)Enum.Parse(typeof(EnumAvatarHead), _type);
        int nextId = avId + 1;

        //Debug.Log("nextId=" + nextId);

        if (nextId == avatarsInfo.GetSize())
        {
             nextId = 0;
        }

        InitSendToServerCmd(player.id, nextId);

        return avatarsInfo.GetAvatar(nextId);  
    }

    private void InitSendToServerCmd(int playerId, int avatarHeadId)
    {
        CmdUpdateAvatarRequest cmdSend = new CmdUpdateAvatarRequest();
        cmdSend.name = ProtocolList.PLAYER_UPDATE_AVATAR;
        Dictionary<string, object> paramsDict = new Dictionary<string, object>();
        paramsDict.Add("PlayerId", playerId);
        paramsDict.Add("AvatarHeadTypeId", avatarHeadId);

        cmdSend.Execute(paramsDict);
        //cmdSend.Display<Dictionary<string, object>>("Dictionary", paramsDict);
    }
}

