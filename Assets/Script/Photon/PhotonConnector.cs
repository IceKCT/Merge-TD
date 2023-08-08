using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Photon.Pun;
using Photon.Realtime;

public class PhotonConnector : MonoBehaviourPunCallbacks
{
    private void Start()
    {
        string randomName = $"Tester{Guid.NewGuid().ToString()}";
        ConnectToPhoton(randomName);
    }
    private void ConnectToPhoton(string nickName)
    {
        Debug.Log($"Connect to Photon as {nickName}");
        PhotonNetwork.AuthValues = new AuthenticationValues(nickName);
        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.NickName = nickName;
        PhotonNetwork.ConnectUsingSettings();

    }
    private void CreatePhotonRoom(string roomName)
    {
        RoomOptions ro = new RoomOptions();
        ro.IsOpen = true;
        ro.IsVisible = true;
        ro.MaxPlayers = 4;
        PhotonNetwork.JoinOrCreateRoom(roomName, ro, TypedLobby.Default);
    }
    public override void OnConnectedToMaster()
    {
        Debug.Log($"You have connect to Photon Master server");
        if (!PhotonNetwork.InLobby)
        {
            PhotonNetwork.JoinLobby();
        }
    }
    public override void OnJoinedLobby()
    {
        Debug.Log("You have join the lobby");
        CreatePhotonRoom("TestRoom");
    }
    public override void OnCreatedRoom()
    {
        Debug.Log($"You have created a Photon Room named{PhotonNetwork.CurrentRoom.Name}");
    }
    public override void OnJoinedRoom()
    {
        Debug.Log($"You have joined a Photon Room named{PhotonNetwork.CurrentRoom.Name}");
    }
    public override void OnLeftRoom()
    {
        Debug.Log("You have left a Photon room");
    }
    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        Debug.Log($"You faild to join a room {message}");
    }
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.Log($"Another player has joined the room {newPlayer.UserId}");
    }
    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        Debug.Log($"Player has left the room{otherPlayer.UserId}");
    }
    public override void OnMasterClientSwitched(Player newMasterClient)
    {
        Debug.Log($"New Master client is {newMasterClient.UserId}");
    }
}