using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController: MonoBehaviour
{
    ConnectorProxy _connectorProxy;
    AsyncSocketListener _server;

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
        _server = new AsyncSocketListener();
        _connectorProxy = new ConnectorProxy();
    }
}
