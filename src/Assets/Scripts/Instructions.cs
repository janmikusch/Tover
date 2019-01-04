using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Instructions : MonoBehaviour
{
    public GameObject backButton;
    public GameObject instructionText;

    void Awake()
    {
        instructionText.GetComponent<Text>().text = ToverLanguage.instance.languageTable["InstructionText"];
        backButton.GetComponent<Text>().text = ToverLanguage.instance.languageTable["InstructionBackButton"];

        if (ToverPlayService.instance.usePlayServices)
        {
            ToverPlayService.instance.InstructionArchievment();
        }
    }

    public void backToMainMenu()
    {
        SceneManager.LoadScene("mainmenu");
    }
}
