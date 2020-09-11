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
                    CmdClientUpdateAvatar cmd = new CmdClientUpdateAvatar();
                    cmd.name = cmd.ToString();
                    Dictionary<string, object> paramsDict = new Dictionary<string, object>();

                    int playerId = avatarHead.GetComponentInParent<Player>().id;
                    paramsDict.Add("PlayerId", playerId);
                    paramsDict.Add("AvatarHeadType", avatarHead.GetTypeId(avatarHead.type.ToString()));

                    cmd.Execute(paramsDict);
                }
            }
        }
    }
}
