using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using UnityEditor;
using System.IO;

public class MenuUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI InputName;
    public TextMeshProUGUI ratingText;
    public int coolestScore;
    public string coolestPlayer;


    // Start is called before the first frame update

    private void Awake()
    {
        string path = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            MainManager.SaveData data = JsonUtility.FromJson<MainManager.SaveData>(json);

            coolestPlayer = data.TheBestPlayer;
            coolestScore = data.HighiestScore;
        }
    }

    private void Start()
    {

        if (coolestPlayer == null && coolestScore == 0)
        {
            ratingText.text = "";
        }
        else
        {
            ratingText.text = $"Best score : {coolestPlayer} - {coolestScore}";
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void SetPlayerName()
    {
            SaveInfo.Instance.playerName = InputName.text;
    }
    
    public void QuitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
