using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.UI;

public class PlayFabLogin : MonoBehaviour
{
    [Header("INPUT")]
    [SerializeField] InputField emailInput;
    [SerializeField] InputField passwordInput;
    [Header("Text")]
    public Text massageText;
    
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
        massageText.text = "Registered and logged in";
    }
    public void OnError(PlayFabError error)
    {
        Debug.Log(error.GenerateErrorReport());
    }
    public void LoginButton()
    {
        var request = new LoginWithEmailAddressRequest
        {
            Email = emailInput.text,
            Password = passwordInput.text
        };
        PlayFabClientAPI.LoginWithEmailAddress(request, OnLoginSuccess, OnError);
    }
    public void OnLoginSuccess(LoginResult result)
    {
        massageText.text = "Logged in success";
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
}
