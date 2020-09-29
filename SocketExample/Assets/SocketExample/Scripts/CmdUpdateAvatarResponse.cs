using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CmdUpdateAvatarResponse : Command
{
    public delegate void ActionUpdateAvatar(int playerId);
    public static event ActionUpdateAvatar OnUpdateAvatar;

    public override void Execute<T>(T value)
    {
        OnUpdateAvatar?.Invoke((int)paramsDict["PlayerId"]);
    }
}
