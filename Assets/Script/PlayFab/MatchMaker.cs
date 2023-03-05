using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using PlayFab;
using PlayFab.MultiplayerModels;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;
using Hashtable = ExitGames.Client.Photon.Hashtable;

public class MatchMaker : MonoBehaviourPunCallbacks
{
    [Header("Window")]
    [SerializeField] GameObject mainMenuWindow;
    [SerializeField] GameObject matchMakingWindow;
    [SerializeField] GameObject LoadingCanvas;
    [Header("Text")]
    [SerializeField] Text statusText;
    private const string QueueName = "DefaultQueue";
    public const string FirstPlayer = "FirstPlayerInScene";
    public string ticketId;
    private Coroutine pollTicktedCoroutine;
    public void StartMatchmaking()
    {
        mainMenuWindow.SetActive(false);
        matchMakingWindow.SetActive(true);
        PlayFabMultiplayerAPI.CreateMatchmakingTicket(
            new CreateMatchmakingTicketRequest
            {
                Creator = new MatchmakingPlayer
                {
                    Entity = new EntityKey
                    {
                        Id = PlayfabManager.EntityID,
                        Type = "title_player_account"
                    },
                    Attributes = new MatchmakingPlayerAttributes
                    {
                        DataObject = new { }
                    }
                },
                GiveUpAfterSeconds = 3599,
                QueueName = QueueName
            },
            OnCreateMatchmakingTicktedCreated,
            OnError
        );
    }
    public void OnCreateMatchmakingTicktedCreated(CreateMatchmakingTicketResult result)
    {
        ticketId = result.TicketId;
        pollTicktedCoroutine = StartCoroutine(PollTickted());
        Debug.Log("Ticktedd_Created");
    }
    public void OnError(PlayFabError error)
    {
        Debug.Log(error.GenerateErrorReport());
    }
    public IEnumerator PollTickted()
    {
        while (true)
        {
            PlayFabMultiplayerAPI.GetMatchmakingTicket(
                new GetMatchmakingTicketRequest
                {
                    TicketId = ticketId,
                    QueueName = QueueName
                },
                OnGetMatchmakingTicket,
                OnError
            );

            yield return new WaitForSeconds(6);
        }
    }
    public void OnGetMatchmakingTicket(GetMatchmakingTicketResult result)
    {
        statusText.text = $"Status : {result.Status}";
        switch (result.Status)
        {
            case "Matched":
                StopCoroutine(pollTicktedCoroutine);
                StartMatch(result.MatchId);
                break;
            case "Canceled":
                break;
        }
    }
    public void StartMatch(string matchId)
    {
        statusText.text = "Starting Match";
        PlayFabMultiplayerAPI.GetMatch(
            new GetMatchRequest
            {
                MatchId = matchId,
                QueueName = QueueName
            },
            OnGetMatch,
            OnError
        );
    }
    public void OnGetMatch(GetMatchResult result)
    {
        CreatePhotonRoom(result.MatchId);
        LoadingCanvas.SetActive(true);

    }
    public void OnCancelMatchamkingTtecket()
    {
        var request = new CancelMatchmakingTicketRequest
        {
            TicketId = ticketId,
            QueueName = QueueName
        };
        PlayFabMultiplayerAPI.CancelMatchmakingTicket(request, OnCancelMatchmaking, OnError);
    }
    public void OnCancelMatchmaking(CancelMatchmakingTicketResult result)
    {
        mainMenuWindow.SetActive(true);
        matchMakingWindow.SetActive(false);
        Debug.Log("cancel ticket");
    }
    //photon
    public void CreatePhotonRoom(string roomName)
    {
        RoomOptions ro = new RoomOptions();
        ro.IsOpen = true;
        ro.IsVisible = true;
        ro.MaxPlayers = 4;
        PhotonNetwork.JoinOrCreateRoom(roomName, ro, TypedLobby.Default);
    }
    public override void OnCreatedRoom()
    {
        Debug.Log($"You have created a Photon Room named{PhotonNetwork.CurrentRoom.Name}");
    }
    public override void OnJoinedRoom()
    {
        Debug.Log($"You have joined a Photon Room named{PhotonNetwork.CurrentRoom.Name}");
        if (PhotonNetwork.IsMasterClient)
        {
            OnLoadScene();
        }
        else
        {
            Invoke("OnLoadScene", 5f);
        }
        
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

    public void OnLoadScene()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
