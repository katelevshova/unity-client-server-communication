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
        // Add more here
    }

    private void UnsubscribeFromEvents()
    {
        //Debug.Log("[Player]->UnsubscribeFromEvents");
        CmdClientUpdateAvatar.OnUpdateAvatar -= UpdateAvatar;
        // Remove more here
    }

    private void UpdateAvatar(int playerId)
    {
        Debug.Log("[Player]->UpdateAvatar: playerId="+ playerId);
        Player player = GetPlayerById(playerId);

        GameObject nextAvatar = GetNextAvatar(player);
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

        return avatarsInfo.GetAvatar(nextId);  
    }

    private void OnDisable()
    {
        UnsubscribeFromEvents();
    }
}

