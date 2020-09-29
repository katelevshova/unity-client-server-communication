using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarsInfo: MonoBehaviour 
{
    //Initialize them in Editor
    public GameObject AvatarCapsuleHead;
    public GameObject AvatarCubeHead;
    public GameObject AvatarRoundHead;
    //TODO: use AssetBundles to load the avatar heads by URL

    public List<GameObject> _avatarsList = new List<GameObject>();

    public void Start()
    {
        Debug.Log("[AvatarsInfo]->Start: " );
        _avatarsList.Add(AvatarCapsuleHead);
        _avatarsList.Add(AvatarCubeHead);
        _avatarsList.Add(AvatarRoundHead);
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
