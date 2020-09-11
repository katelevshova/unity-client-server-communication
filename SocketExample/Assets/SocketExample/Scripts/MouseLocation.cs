using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLocation : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray rayOrigin = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            if(Physics.Raycast(rayOrigin, out hitInfo))
            {
                AvatarHead avatarHead = hitInfo.collider.GetComponent<AvatarHead>();

                if(avatarHead != null)
                {
                    Debug.Log("MouseLocation, clicked!");

                    CmdClientUpdateAvatar cmd = new CmdClientUpdateAvatar();
                    cmd.Execute<Player>(avatarHead.GetComponentInParent<Player>());
                }
            }
        }
    }
}
