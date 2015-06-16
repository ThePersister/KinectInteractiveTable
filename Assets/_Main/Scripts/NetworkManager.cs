using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PhotonView))]
public class NetworkManager : Singleton<NetworkManager> {

    private PhotonView pView;

	void Start () {
        pView = GetComponent<PhotonView>();
	}

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
            SM_PlayGame();

    }

    public void SM_PlayGame()
    {
        Debug.Log("Sent Message");
        pView.RPC("RM_PlayGame", PhotonTargets.OthersBuffered);
    }

    [RPC]
    public void RM_PlayGame()
    {
        Debug.Log("Received Message");
        //GameManager.Instance.Start();
    }
}
