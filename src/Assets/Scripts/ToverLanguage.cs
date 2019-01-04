using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ToverLanguage : MonoBehaviour {

    public static ToverLanguage instance { set; get; }
    public Dictionary<string, string> languageTable;
    // Use this for initialization
    void Awake()
    {
        if (GameObject.FindGameObjectsWithTag("ToverLanguage").Length > 1)
        {
            GameObject.Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);

        setLanguageTable();
    }

    public void setLanguageTable()
    {
        SystemLanguage lang = Application.systemLanguage;
        languageTable = new Dictionary<string, string>();

        switch (lang)
        {
            case SystemLanguage.German:
                languageTable.Add("PlayButton", "Start");
                languageTable.Add("InstructionButton", "Anleitung");
                languageTable.Add("InstructionBackButton", "Zurück");

                languageTable.Add("Yes", "Ja");
                languageTable.Add("No", "Nein");
                languageTable.Add("Buy", "Kaufen");
                languageTable.Add("Watch", "Video ansehen");



                languageTable.Add("InstructionText",
                    "Hey, du willst also wissen wie das Spiel funktionert?\n" +
                    "\n" +
                    "- Wische nach links oder rechts um die Welt zu drehen\n" +
                    "\n" +
                    "- Wische nach unten um die würfel ganz nach unten fallen zu lassen\n" +
                    "\n" +
                    "- Tippe kurz auf den Bildschirm um die Würfel zu drehen\n" +
                    "\n" +
                    "- Wenn du die Fallgeschwindigkeit erhöhen möchtest, halte deinen Finger auf den Bildschirm gedrückt\n" +
                    "\n" +
                    "Viel Spaß!"
                    );

                languageTable.Add("useGPGHead", "Google Play Games benutzen?");
                languageTable.Add("useGPGBody", "Wenn du Google Play Games benutzt hast du zugriff auf die Bestenliste und dein Ergebniss wird gespeichert");

                languageTable.Add("AuthErrorHead", "Nicht angemeldet");
                languageTable.Add("AuthErrorBody", "Etwas ist schief gelaufen, bitte versuche es erneut");

                languageTable.Add("NoLifesHead", "Keine Leben übrig");
                languageTable.Add("NoLifesBody", "Tut mir leid, aber du hast keine Leben mehr übrig. Bitte sieh dir ein Video an oder kaufe dir unendlich viele Leben");

                languageTable.Add("HeadBottonPremiumHead", "Share the love");
                languageTable.Add("HeadBottonPremiumBody", "Danke, dass du mich unterstützt <3");

                languageTable.Add("HeadBottonHead", "Share the love");
                languageTable.Add("HeadBottonBody", "Kaufe unendlich viele Leben oder sieh dir ein Video an, um welche zu bekommen.");

                languageTable.Add("GameOverHead", "Game Over");
                languageTable.Add("GameOverBody", "Du hast die Spitze berührt");
                break;
            default:
                languageTable.Add("PlayButton", "Play");
                languageTable.Add("InstructionButton", "Instructions");
                languageTable.Add("InstructionBackButton", "Back");

                languageTable.Add("Yes", "Yes");
                languageTable.Add("No", "No");
                languageTable.Add("Buy", "Buy");
                languageTable.Add("Watch", "Watch");



                languageTable.Add("InstructionText",
                    "Hey, you wanna know how to play, huh? Well here we go:\n"+
                    "\n" +
                    "- You can swipe left or right to turn the world around\n" +
                    "\n" +
                    "- Swipe down to place the cube very fast\n" +
                    "\n" +
                    "- Tab short to rotate the cubes.\n" +
                    "\n" +
                    "- If you want to speed up, hold pressed.\n" +
                    "\n" +
                    "Good Luck!"
                    );

                languageTable.Add("useGPGHead", "Use Google Play Games?");
                languageTable.Add("useGPGBody", "When you use your Google Play Games Account, you have access to the Leaderboard.");

                languageTable.Add("AuthErrorHead", "Not signed in");
                languageTable.Add("AuthErrorBody", "Please try again.");

                languageTable.Add("NoLifesHead", "No Lifes left");
                languageTable.Add("NoLifesBody", "Sorry mate, but you don't have any lifes left. Please watch a video to get some or buy unlimeted Lifes.");

                languageTable.Add("HeadBottonPremiumHead", "Share the love");
                languageTable.Add("HeadBottonPremiumBody", "Thanks for supporting me <3");

                languageTable.Add("HeadBottonHead", "Share the love");
                languageTable.Add("HeadBottonBody", "Click buy to get unlimeted lifes. Or watch a video to get some lifes for free.");

                languageTable.Add("GameOverHead", "Game Over");
                languageTable.Add("GameOverBody", "You reached the top");

                break;
        }
    }

}
