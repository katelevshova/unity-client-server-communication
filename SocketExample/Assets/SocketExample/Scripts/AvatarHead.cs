﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarHead : MonoBehaviour
{
    public EnumAvatarHead type;

    private void Awake()
    {
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int GetTypeId(string _type)
    {
        return (int)Enum.Parse(typeof(EnumAvatarHead), _type);
    }

    public int GetTypeId()
    {
        return (int)Enum.Parse(typeof(EnumAvatarHead), type.ToString());
    }
}
