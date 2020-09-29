using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataParser
{
    public void ParseResponseMsg(string message)
    {
        // parse message here based on Header and footer 
        // create the list of messages
        // for all items in the  messages_list do ProcessResponse


    }


    public void ProcessResponse(Command cmd)
    {
        switch (cmd.name)
        {
            case ProtocolList.PLAYER_UPDATE_AVATAR:
                {
                    CmdUpdateAvatarResponse cmdUpdateAvatarResponse = new CmdUpdateAvatarResponse();
                    cmdUpdateAvatarResponse.Execute(cmd.paramsDict);
                    break;
                }
            //TODO: add more responses here
        }
    }



}
