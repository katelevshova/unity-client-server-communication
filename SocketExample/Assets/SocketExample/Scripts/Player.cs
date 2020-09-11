using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    protected AvatarHead avatarHead;
    public int id = 0;

    // Start is called before the first frame update
    void Start()
    {
        avatarHead = GetComponentInChildren<AvatarHead>();

        if(avatarHead == null)
        {
            throw new Exception("Add AvatarHead GameObject for the player");
        }

        int startIndex = gameObject.name.IndexOf("_") + 1;
        id = Int32.Parse(gameObject.name.Substring(startIndex));
        //Debug.Log("type="+avatarHead.type);
        //Debug.Log("id=" + id.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
