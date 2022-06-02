using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuUIManager : MonoBehaviour
{
    public TextMeshProUGUI PlayerNameText;

    public void StartGame()
    {
        SceneManager.LoadScene("main");
        MainManager.Instance.ActivePlayerName = PlayerNameText.text;
    }
}
