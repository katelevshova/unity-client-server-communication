using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    protected AvatarHead avatarHead;

    // Start is called before the first frame update
    void Start()
    {
        avatarHead = GetComponentInChildren<AvatarHead>();

        if(avatarHead == null)
        {
            throw new Exception("Add AvatarHead GameObject for the player");
        }

        //Debug.Log("type="+avatarHead.type);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
