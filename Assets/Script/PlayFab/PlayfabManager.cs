using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using System.Linq;

public class PlayfabManager : MonoBehaviourPunCallbacks
{
    [Header("INPUT")]
    [SerializeField] InputField emailInput;
    [SerializeField] InputField passwordInput;
    [SerializeField] InputField displayNameInput;
    [Header("Text")]
    [SerializeField] Text massageText;
    [SerializeField] Text playerNameText;
    [Header("Window")]
    [SerializeField] GameObject displayNameWindow;
    [SerializeField] GameObject mainMenuWindow;
    [SerializeField] GameObject loginWindow;
    [SerializeField] GameObject playerInfoWindow;
    [SerializeField] GameObject towerElementNameWindow;
    [SerializeField] GameObject leaderBoardWindow;
    [Header("Prefab")]
    public GameObject playerinfoPrefab;
    [Header("TransForm")]
    [SerializeField] Transform leaderBoardTable;

    public static string SessionTicket;
    public static string EntityID;
    string loggedInPlayfabID;
    public List<InputField> inputField;
    private int inputFieldIndex;
    private void Start()
    {
        inputField = new List<InputField> { emailInput, passwordInput };
        Debug.Log("Is Login? :"+PlayFabClientAPI.IsClientLoggedIn().ToString());
        Debug.Log("Is connect to photon? :" + PhotonNetwork.IsConnectedAndReady.ToString());
        Debug.Log("In Lobby? :" + PhotonNetwork.InLobby.ToString());
        Debug.Log("In room? :" + PhotonNetwork.InRoom.ToString());
        if (PlayFabClientAPI.IsClientLoggedIn())
        {
            mainMenuWindow.SetActive(true);
            loginWindow.SetActive(false);
            playerInfoWindow.SetActive(true);
            string playername = PlayerPrefs.GetString("PlayerName");
            playerNameText.text = playername;
            ConnectToPhoton(playername);
        }
        else
        {
            return;
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            LoginButton();
        }
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            //Debug.Log("input field index : " + inputFieldIndex.ToString());
            inputFieldIndex++;
            if (inputField.Count <= inputFieldIndex)
            {
                inputFieldIndex = 0;
            }
            inputField[inputFieldIndex].Select();
        }
    }

    public void RegisterButton()
    {
        if (passwordInput.text.Length < 6)
        {
            massageText.text = "Password too short";
        }
        var request = new RegisterPlayFabUserRequest
        {
            Email = emailInput.text,
            Password = passwordInput.text,
            RequireBothUsernameAndEmail = false
        };
        PlayFabClientAPI.RegisterPlayFabUser(request, OnRegisterSuccess, OnError);
    }
    public void OnRegisterSuccess(RegisterPlayFabUserResult result)
    {
        SessionTicket = result.SessionTicket;
        massageText.text = "Registered";
    }
    public void OnError(PlayFabError error)
    {
        Debug.Log(error.GenerateErrorReport());
        massageText.text = error.ErrorMessage;
    }
    public void LoginButton()
    {
        var request = new LoginWithEmailAddressRequest
        {
            Email = emailInput.text,
            Password = passwordInput.text,
            InfoRequestParameters = new GetPlayerCombinedInfoRequestParams
            {
                GetPlayerProfile = true
            }
        };
        PlayFabClientAPI.LoginWithEmailAddress(request, OnLoginSuccess, OnError);
    }
    public void OnLoginSuccess(LoginResult result)
    {
        loggedInPlayfabID = result.PlayFabId;
        loginWindow.SetActive(false);
        massageText.text = "Logged in success";
        EntityID = result.EntityToken.Entity.Id;
        string name = null;
        name = result.InfoResultPayload.PlayerProfile.DisplayName;
        if (result.InfoResultPayload.PlayerProfile != null)
        {
            name = result.InfoResultPayload.PlayerProfile.DisplayName;
            PlayerPrefs.SetString("PlayerName", name);
            playerNameText.text = name;
            ConnectToPhoton(name);
        }
        if (name == null)
        {
            displayNameWindow.SetActive(true);
        }
        else
        {
            mainMenuWindow.SetActive(true);
            playerInfoWindow.SetActive(true);
        }
        Debug.Log(PlayFabClientAPI.IsClientLoggedIn().ToString());
    }
    public void ResetPasswordButton()
    {
        var request = new SendAccountRecoveryEmailRequest
        {
            Email = emailInput.text,
            TitleId = "E398A"
        };
        PlayFabClientAPI.SendAccountRecoveryEmail(request, OnPasswordReset, OnError);
    }
    public void OnPasswordReset(SendAccountRecoveryEmailResult result)
    {
        massageText.text = "Password reset mail sent!";
    }
    public void DisplaynameButton()
    {
        var request = new UpdateUserTitleDisplayNameRequest
        {
            DisplayName = displayNameInput.text
        };
        playerNameText.text = displayNameInput.text;
        PlayFabClientAPI.UpdateUserTitleDisplayName(request, UpdateDisplayNameSuccess, OnError);
    }
    public void UpdateDisplayNameSuccess(UpdateUserTitleDisplayNameResult result)
    {
        Debug.Log("Update Display Name");
        playerNameText.text = (result.DisplayName);
        mainMenuWindow.SetActive(true);
        playerInfoWindow.SetActive(true);
        displayNameWindow.SetActive(false);
    }
    public void SendLeaderBoard(int score)
    {
        var request = new UpdatePlayerStatisticsRequest
        {
            Statistics = new List<StatisticUpdate> {
                new StatisticUpdate
                {
                    StatisticName = "GameScore",
                    Value = score
                }
            }
        };
        PlayFabClientAPI.UpdatePlayerStatistics(request, OnLeaderBoardUpdate, OnError);
    }
    public void OnLeaderBoardUpdate(UpdatePlayerStatisticsResult result)
    {
        Debug.Log("Successfully leader board sent");
    }
    public void OnGetLeaderBoard()
    {
        var request = new GetLeaderboardRequest
        {
            StatisticName = "GameScore",
            StartPosition = 0,
            MaxResultsCount = 10
        };
        PlayFabClientAPI.GetLeaderboard(request, OnLeaderBoardGet, OnError);
    }
    public void OnLeaderBoardGet(GetLeaderboardResult result)
    {
        foreach (Transform item in leaderBoardTable)
        {
            Destroy(item.gameObject);
        }
        foreach (var item in result.Leaderboard)
        {
            GameObject playerInfo = Instantiate(playerinfoPrefab, leaderBoardTable);
            Text[] texts = playerInfo.GetComponentsInChildren<Text>();
            texts[0].text = (item.Position + 1).ToString();
            texts[1].text = item.DisplayName.ToString();
            texts[2].text = item.StatValue.ToString();
            Debug.Log(item.Position + " " + item.PlayFabId + " " + item.StatValue);
        }
    }
    public void GetLeaderBoardAroundPlayer()
    {

        var request = new GetLeaderboardAroundPlayerRequest {
            StatisticName = "GameScore",
            PlayFabId = loggedInPlayfabID,
            MaxResultsCount = 9
        };
        PlayFabClientAPI.GetLeaderboardAroundPlayer(request, OnLeaderBoardAroundPlayerGet, OnError);
    }
    public void OnLeaderBoardAroundPlayerGet(GetLeaderboardAroundPlayerResult result)
    {
        foreach (Transform item in leaderBoardTable)
        {
            Destroy(item.gameObject);
        }
        foreach (var item in result.Leaderboard)
        {
            GameObject playerInfo = Instantiate(playerinfoPrefab, leaderBoardTable);
            Text[] texts = playerInfo.GetComponentsInChildren<Text>();
            texts[0].text = (item.Position + 1).ToString();
            texts[1].text = item.DisplayName.ToString();
            texts[2].text = item.StatValue.ToString();
            if (item.PlayFabId == loggedInPlayfabID)
            {
                texts[0].color = Color.red;
                texts[1].color = Color.red;
                texts[2].color = Color.red;
            }
        }
    }
    public void TestSendScore()
    {
        SendLeaderBoard(Random.Range(0,100));
    }
    //photon
    public void ConnectToPhoton(string nickName)
    {
        Debug.Log($"Connect to Photon as {nickName}");
        PhotonNetwork.AuthValues = new AuthenticationValues(nickName);
        Debug.Log(PhotonNetwork.AuthValues.ToString());
        PhotonNetwork.AutomaticallySyncScene = false;
        PhotonNetwork.NickName = nickName;
        Debug.Log("is connected to master" + PhotonNetwork.IsConnectedAndReady.ToString());
        PhotonNetwork.ConnectUsingSettings();
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
    }

    public override void OnMasterClientSwitched(Player newMasterClient)
    {
        Debug.Log($"New Master client is {newMasterClient.UserId}");
    }
}
