using UnityEngine;
using System.Collections;

public class Networkmanager : MonoBehaviour
{
    private int port;
    private string gameType = "099d1cf0898875394b062f0e35fdcd72"; //MagicKlon md5 hashat
    private string myGameName;
    private bool hosting;
    private bool foundPartner;

	void Start()
    {
        port = 44552;
	}

	void StartServer()
    {
        hosting = true;
        foundPartner = false;
        Network.InitializeServer(1, port, false);
        myGameName = "Random game" + Random.Range(0, 712371231);
        MasterServer.RegisterHost(gameType, myGameName);
        StartCoroutine("WaitForConnection");
    }

    void FindServer()
    {
        foundPartner = false;
        hosting = false;
        myGameName = "FUCKING NOT HOSTING";
        StartCoroutine("LookForServer");
    }

    IEnumerator LookForServer()
    {
        while(!foundPartner)
        {
            HostData[] hostData = MasterServer.PollHostList();
            foreach (var host in hostData)
            {
                if (IsHostAvailable(host))
                    ConnectToHost(host);
            }

            yield return new WaitForSeconds(0.1f);
        }
    }

    IEnumerator WaitForConnection()
    {
        while(!foundPartner)
        {
            HostData[] hostData = MasterServer.PollHostList();
            foreach (var host in hostData)
            {
                if (host.connectedPlayers == 2 && IsHostMe(host))
                    foundPartner = true;
            }

            yield return new WaitForSeconds(0.1f);
        }
    }

    private bool IsHostMe(HostData host)
    {
        return host.gameName == myGameName;
    }

    private void ConnectToHost(HostData host)
    {
        foundPartner = true;
        Network.Connect(host);
    }

    private bool IsHostAvailable(HostData host)
    {
        return host.gameName != myGameName && host.connectedPlayers == 1;
    }

	void OnGUI()
	{
		if (!Network.isClient && !Network.isServer)
		{
			if (GUI.Button(new Rect(100, 100, 250, 100), "Start Server"))
				StartServer();
			
			if (foundPartner != null)
			{
				if (GUI.Button(new Rect(400, 200, 300, 100), "Find Server"))
					FindServer();
			}
		}
	}

}
