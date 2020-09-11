using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarsInfo: MonoBehaviour 
{
    public GameObject AvatarCapsuleHead;
    public GameObject AvatarCubeHead;
    public GameObject AvatarRoundHead;

    public List<GameObject> _avatarsList = new List<GameObject>();

    public void Start()
    {
        Debug.Log("[AvatarsInfo]->Start: " );
        _avatarsList.Add(AvatarCapsuleHead);
        _avatarsList.Add(AvatarCubeHead);
        _avatarsList.Add(AvatarRoundHead);

        //GetAvatar(0);
        //GetAvatar(1);
        //GetAvatar(2);
    }

    public List<GameObject> GetAvatarsList()
    {
        return _avatarsList;
    }

    public GameObject GetAvatar(int id)
    {
        //Debug.Log("->GetAvatar: " + _avatarsList[id]);
        return _avatarsList[id];
    }

    public int GetSize()
    {
        //Debug.Log("->GetSize: " + _avatarsList.Count);
        return _avatarsList.Count;
    }
}
