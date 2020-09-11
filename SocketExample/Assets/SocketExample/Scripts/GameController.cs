using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController: MonoBehaviour
{
    public static GameController Instance;
    public ConnectorProxy connectorProxy;
    public AsyncSocketListener server;

    void Awake()
    {
        //This is a common approach to handling a class with a reference to itself.
        //If instance variable doesn't exist, assign this object to it
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }

        //Otherwise, if the instance variable does exist, but it isn't this object, destroy this object.
        //This is useful so that we cannot have more than one DebugUtil object in a scene at a time.
        else if (Instance != this)
        {
            Destroy(this.gameObject);
        }

        Application.targetFrameRate = 60; //for Mobile 
    }

    // Start is called before the first frame update
    void Start()
    {
        StartSocketConnection();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void StartSocketConnection()
    {
        server = new AsyncSocketListener();
        connectorProxy = new ConnectorProxy();
    }
}
