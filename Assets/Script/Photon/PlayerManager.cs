using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using System.IO;
using System.Linq;
using Hashtable = ExitGames.Client.Photon.Hashtable;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    PhotonView PV;
    string money;
    string health;
    private void Awake()
    {
        PV = GetComponent<PhotonView>();
    }
    private void Start()
    {
        if (PV.IsMine)
        {
            CreateController();
        }
    }

    void CreateController()
    {
        Debug.Log("Instantiate player controller");
        //Vector3 campos = new Vector3(455, 266, 180);
        //Transform spawnPoint = SpawnManager.instance.GetSpawnPoint();
        PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "PlayerController"), Vector3.zero, Quaternion.identity,0,new object[] { PV.ViewID});
    }
    public void GetMoney()
    {
        PV.RPC(nameof(RPC_GetMoney), PV.Owner);
    }
    public void GetHealth()
    {
        PV.RPC(nameof(RPC_GetHealth), PV.Owner);
    }
    [PunRPC]
    void RPC_GetMoney()
    {
        money = PlayerPrefs.GetString("MONEY");
        Hashtable hash = new Hashtable();
        //Debug.Log("GET MONEY");
        hash.Add("money", money);
        PhotonNetwork.LocalPlayer.SetCustomProperties(hash);
    }
    [PunRPC]
    void RPC_GetHealth()
    {
        health = PlayerPrefs.GetString("HEALTH");
        Hashtable hash = new Hashtable();
        //Debug.Log("GET HEALTH");
        hash.Add("health", health);
        PhotonNetwork.LocalPlayer.SetCustomProperties(hash);
    }
    public static PlayerManager Find(Player player)
    {
        return FindObjectsOfType<PlayerManager>().SingleOrDefault(x => x.PV.Owner == player);
    }
}
