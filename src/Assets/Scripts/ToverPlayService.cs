using UnityEngine;
using System.Collections;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;

public class ToverPlayService : MonoBehaviour
{
    public static ToverPlayService instance { set; get; }
    public bool usePlayServices { set; get; }

    // Use this for initialization
    void Awake()
    {
        instance = this;
        usePlayServices = false;

        if (GameObject.FindGameObjectsWithTag("ToverPlayService").Length > 1)
        {
            GameObject.Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }

    public void LogIn()
    {
        PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder().Build();

        PlayGamesPlatform.InitializeInstance(config);
        // recommended for debugging:
        PlayGamesPlatform.DebugLogEnabled = true;
        // Activate the Google Play Games platform
        PlayGamesPlatform.Activate();


        Social.localUser.Authenticate((bool success) =>
        {
            if (success)
            {
                Debug.Log("Authenticated");
                usePlayServices = true;
            }
            else
            {
                usePlayServices = false;
            }
        });
    }

    public void CheckAchievements(float score, float archievmentScore)
    {
        if (score >= 65535 && archievmentScore < 65535)
        {
            Social.ReportProgress("CgkInpCW8v4eEAIQBw", 100.0f, (bool success) =>
            {
                // handle success or failure
                if (success)
                {
                    archievmentScore = 65535;
                }
            });
        }
        else if (score > 9000 && archievmentScore < 9000)
        {
            Social.ReportProgress("CgkInpCW8v4eEAIQBg", 100.0f, (bool success) =>
            {
                // handle success or failure
                if (success)
                {
                    archievmentScore = 9000;
                }
            });
        }
        else if (score >= 7000 && archievmentScore < 7000)
        {
            Social.ReportProgress("CgkInpCW8v4eEAIQBQ", 100.0f, (bool success) =>
            {
                // handle success or failure
                if (success)
                {
                    archievmentScore = 7000;
                }
            });
        }
        else if (score >= 3000 && archievmentScore < 3000)
        {
            Social.ReportProgress("CgkInpCW8v4eEAIQBA", 100.0f, (bool success) =>
            {
                // handle success or failure
                if (success)
                {
                    archievmentScore = 3000;
                }
            });
        }
        else if (score >= 750 && archievmentScore < 750)
        {
            Social.ReportProgress("CgkInpCW8v4eEAIQAw", 100.0f, (bool success) =>
            {
                // handle success or failure
                if (success)
                {
                    archievmentScore = 750;
                }
            });
        }

    }

    public void FirstBrickArchievment()
    {
        Social.ReportProgress("CgkInpCW8v4eEAIQAg", 100.0f, (bool success) =>
        {
            // handle success or failure
            if (success)
            {
            }
        });
    }

    public void InstructionArchievment()
    {
        Social.ReportProgress("CgkInpCW8v4eEAIQCA", 100.0f, (bool success) =>
        {
            // handle success or failure
            if (success)
            {
            }
        });
    }

    public void postScoreToLeaderboard(float score)
    {
        Social.localUser.Authenticate((bool success) =>
        {
            if (success)
            {
                Social.ReportScore((long)score, "CgkInpCW8v4eEAIQAQ", (bool success2) =>
                {
                    if (success2)
                    {
                        Debug.Log("Score: (" + score + ") was published");
                    }
                    else
                    {
                        Debug.Log("Score couldn't be published");
                    }
                });
            }
            else
            {
                Debug.Log("Score couldn't be published");
            }
        });


    }

}
