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
}
