using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    PhotonView PV;
    PlayerManager playerMananger;
    private void Awake()
    {
        PV = GetComponent<PhotonView>();
        playerMananger = PhotonView.Find((int)PV.InstantiationData[0]).GetComponent<PlayerManager>();
    }

    private void Start()
    {
        if (!PV.IsMine)
        {
            Destroy(GetComponentInChildren<Camera>().gameObject);
        }
    }
    void Update()
    {
        if (!PV.IsMine)
        {
            return;
        }
        Status();
    }

    public void Status()
    {
        PV.RPC(nameof(RPC_status),PV.Owner);
    }

    [PunRPC]
    public void RPC_status(PhotonMessageInfo info)
    {
        //Debug.Log("RPC_STATUS");
        PlayerManager.Find(info.Sender).GetMoney();
        PlayerManager.Find(info.Sender).GetHealth();
        PlayerManager.Find(info.Sender).GetScore();
    }
}
