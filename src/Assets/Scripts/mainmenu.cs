using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.Advertisements;
using UnityEngine.UI;
using GooglePlayGames;
using GooglePlayGames.BasicApi;

public class mainmenu : MonoBehaviour
{
    public int lifes = 5;
    public bool noads = false;
    public bool usePlayService;
    private Text lifeText;
    public bool debug;
    public AudioClip startSound;

    private AudioSource source;

    public bool isLoading;


    public GameObject playButton;
    public GameObject instructionButton;

    public void Start()
    {
        playButton.GetComponent<Text>().text = ToverLanguage.instance.languageTable["PlayButton"];
        instructionButton.GetComponent<Text>().text = ToverLanguage.instance.languageTable["InstructionButton"];

        isLoading = false;
        noads = false;
        usePlayService = false;
        lifes = 5;
        Load();
        Debug.Log("persistentDataPath: " + Application.persistentDataPath);


        lifeText = GameObject.FindGameObjectWithTag("LifeText").GetComponent<Text>();
        if (noads == true)
        {
            lifeText.text = "∞";
        }
        else
        {
            lifeText.text = lifes.ToString();
        }

        if (usePlayService)
        {
            ToverPlayService.instance.LogIn();
        }

        Save();
    }

    public void ShowScoreboard()
    {
        if (usePlayService == false)
        {
            //Use Google Play Games?
            MobileNativeDialog dialog = new MobileNativeDialog(ToverLanguage.instance.languageTable["useGPGHead"],
            ToverLanguage.instance.languageTable["useGPGBody"],
            ToverLanguage.instance.languageTable["Yes"], ToverLanguage.instance.languageTable["No"]);

            dialog.OnComplete += OnDialogClosePlayService;
        }
        else
        {
            // authenticate user:
            Social.localUser.Authenticate((bool success) =>
            {
                if (success)
                {
                    PlayGamesPlatform.Instance.ShowLeaderboardUI("CgkInpCW8v4eEAIQAQ");
                }
                else
                {
                    //Authentification Error
                    MobileNativeMessage msg = new MobileNativeMessage(ToverLanguage.instance.languageTable["AuthErrorHead"], ToverLanguage.instance.languageTable["AuthErrorBody"]);
                    Debug.Log("Authentification Error");

                }
            });
        }
    }

    public void ShowRewardedAd()
    {
        if (debug)
        {
            addLifes(1);
            return;
        }
        if (Advertisement.IsReady("rewardedVideo"))
        {
            var options = new ShowOptions { resultCallback = HandleShowResult };
            Advertisement.Show("rewardedVideo", options);
        }
    }

    private void HandleShowResult(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                Debug.Log("The ad was successfully shown.");
                addLifes(3);
                break;
            case ShowResult.Skipped:
                Debug.Log("The ad was skipped before reaching the end.");
                break;
            case ShowResult.Failed:
                Debug.LogError("The ad failed to be shown.");
                break;
        }
    }

    public void startGame()
    {
        if (isLoading)
            return;

        if (noads == false)
        {
            if (lifes > 0)
            {
                useLife();
                source = GameObject.FindGameObjectWithTag("MusicManager").GetComponent<AudioSource>();
                source.clip = startSound;
                source.loop = false;
                source.Play();
                isLoading = true;
                StartCoroutine(start());
            }
            else
            {
                //no lifes left
                MobileNativeDialog dialog = new MobileNativeDialog(ToverLanguage.instance.languageTable["NoLifesHead"],
                    ToverLanguage.instance.languageTable["NoLifesBody"],
                    ToverLanguage.instance.languageTable["Buy"], ToverLanguage.instance.languageTable["Watch"]);

                dialog.OnComplete += OnDialogClose;


            }
        }
        else
        {
            source = GameObject.FindGameObjectWithTag("MusicManager").GetComponent<AudioSource>();
            source.clip = startSound;
            source.loop = false;
            source.Play();
            isLoading = true;
            StartCoroutine(start());
        }
    }

    public void HeartButton()
    {
        if (Application.platform == RuntimePlatform.WindowsEditor ||
            Application.platform == RuntimePlatform.WindowsPlayer ||
            Application.platform == RuntimePlatform.WebGLPlayer)
        {
            //ShowRewardedAd();
            Buy();
            return;
        }
        if (noads == true)
        {
            MobileNativeMessage msg = new MobileNativeMessage(ToverLanguage.instance.languageTable["HeadBottonPremiumHead"],
                ToverLanguage.instance.languageTable["HeadBottonPremiumBody"]);
        }
        else
        {
            MobileNativeDialog dialog = new MobileNativeDialog(ToverLanguage.instance.languageTable["HeadBottonHead"],
            ToverLanguage.instance.languageTable["HeadBottonBody"],
            ToverLanguage.instance.languageTable["Buy"], ToverLanguage.instance.languageTable["Watch"]);

            dialog.OnComplete += OnDialogClose;
        }
    }

    private void OnDialogClose(MNDialogResult result)
    {
        //parsing result
        switch (result)
        {
            case MNDialogResult.YES:
                Debug.Log("Wanna buy the good stuff");
                Buy();
                break;
            case MNDialogResult.NO:
                Debug.Log("Thinks it's free, haaaahaaaahaaa");
                ShowRewardedAd();
                break;
        }
    }

    private void Buy()
    {
        IAPManager.instance.BuyNoAds();
    }

    IEnumerator start()
    {
        yield return new WaitForSeconds(startSound.length);
        LoadingScreenManager.LoadScene(3);
        //LoadingScreenManager.LoadScene(SceneManager.GetSceneByName("tover00").buildIndex);
        //SceneManager.LoadScene("tover00");
        //GameObject mm = GameObject.FindGameObjectWithTag("MusicManager");
    }


    public void loadInstructions()
    {
        if (isLoading)
            return;

        isLoading = true;
        SceneManager.LoadScene("instructions");
    }

    public void backToMainMenu()
    {
        if (isLoading)
            return;

        isLoading = true;
        SceneManager.LoadScene("mainmenu");
    }

    public void addLifes(int l)
    {
        lifes = lifes + l;
        if (lifes > 99)
        {
            lifes = 99;
        }
        Save();
        lifeText.text = lifes.ToString();
    }

    public void useLife()
    {
        lifes--;
        Save();
        lifeText.text = lifes.ToString();
    }

    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/savefile01.dat");

        GameData data = new GameData();
        data.lifes = lifes;
        data.noads = noads;
        data.usePlayService = usePlayService;


        bf.Serialize(file, data);
        file.Close();
    }

    public void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/savefile01.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/savefile01.dat", FileMode.Open);
            GameData data = (GameData)bf.Deserialize(file);
            file.Close();
            lifes = data.lifes;
            noads = data.noads;
            usePlayService = data.usePlayService;
        }
    }

    private void OnDialogClosePlayService(MNDialogResult result)
    {
        //parsing result
        switch (result)
        {
            case MNDialogResult.YES:
                Debug.Log("Connect");
                usePlayService = true;
                ToverPlayService.instance.LogIn();
                Save();
                break;
            case MNDialogResult.NO:
                Debug.Log("Dont use");
                usePlayService = false;
                Save();
                break;
        }
    }

    public void SetNoAds()
    {
        noads = true;
        Save();

        lifeText.text = "∞";
        Debug.Log("NoAds activated");
    }
}

[Serializable]
class GameData
{
    public int lifes;
    public bool noads;
    public bool usePlayService;

}
