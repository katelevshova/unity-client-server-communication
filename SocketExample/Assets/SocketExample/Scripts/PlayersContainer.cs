using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersContainer : MonoBehaviour
{
    public List<Player> playersList;

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
        Debug.Log("[Player]->SubscribeToEvents");
        CmdClientUpdateAvatar.OnUpdateAvatar += UpdateAvatar;
    }

    private void UpdateAvatar(int playerId)
    {
        Debug.Log("[Player]->UpdateAvatar: playerId="+ playerId);
        Player player = GetPlayerById(playerId);
        player.ReplaceAvatarWithNext();
    }

    public Player GetPlayerById(int id)
    {
        return playersList[id];
    }
}
