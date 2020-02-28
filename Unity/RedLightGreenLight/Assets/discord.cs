using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using Discord;

public class discord : MonoBehaviour
{
    public Discord.Discord thisDiscord;
    public Discord.UserManager userManager;
    public Discord.ActivityManager activityManager;
    public Discord.ApplicationManager appManager;
    public int loopCounter = 0;
    public int loopUpdateRate = 60 * 1;
    public string accessToken = "";

    public bool running = true;

    public void Start()
    {
        const long ClientID = 682703198330421250;
        thisDiscord = new Discord.Discord(ClientID, (System.UInt64)Discord.CreateFlags.Default);
        userManager = thisDiscord.GetUserManager();
        activityManager = thisDiscord.GetActivityManager();
        appManager = thisDiscord.GetApplicationManager();

        UpdateActivity();
    }

    public void DoOAuth()
    {
        appManager.GetOAuth2Token((Discord.Result result, ref Discord.OAuth2Token oauth2Token) =>
        {
            Debug.Log(result);
            Debug.Log('"' + oauth2Token.AccessToken + '"');
            accessToken = oauth2Token.AccessToken;
        });
    }

    public void Update()
    {
        if (running)
        {
            thisDiscord.RunCallbacks();
            loopCounter++;
            if ((loopCounter - loopUpdateRate) == 0)
            {
                UpdateActivity();
                loopCounter = 0;
            }
        }
    }


    public void UpdateActivity()
    {
        Discord.Activity activity;

        activity = new Discord.Activity
        {
            State = "Prision Escape",
            Details = "Ingame",
            Assets =
                {
                    LargeImage = "",
                    LargeText = "",
                    SmallImage = "",
                    SmallText = "",
                },
            Party = {
                    Id = "ae488379-351d-4a4f-ad32-2b9b01c91657",
                    Size = {
                        CurrentSize = 3,
                        MaxSize = 3,
                    },
                },
            Instance = false,
        };

        activityManager.UpdateActivity(activity, result =>
        {

        });
    }

    public string DoGetToken()
    {
        return accessToken;
    }
}