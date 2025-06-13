using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
//using UnityEditor;

public class GameController : MonoBehaviour
{
    public const int levelMinLimit = 2;
    public const int levelMaxLimit = 50;
    const int clickCountLimit = 9999999;
    public int level;
    public GameObject prefabParent;
    [SerializeField] GameObject lightPrefab;
    public static GameObject[,] lightArray;
    public Canvas canvas;
    bool AllLightsAreOn = false;
    public Dropdown dropdown;
    const string prefabPath = "Assets/Prefabs/light.prefab";
    public Sprite[] sprites;
    public GameObject gameClearUI;

    public void Start()
    {
        LoadSprites();
        //EditPrefab();
        SetLevel();
        SetLight();
        SetUI();
        SetProblem();
    }

    // Update is called once per frame
    void Update()
    {
        if (AllLightsAreOn) return;

        AllLightsAreOn = true;
        for (int j = 0; j < level; j++)
        {
            for (int i = 0; i < level; i++)
            {
                AllLightsAreOn = (AllLightsAreOn && (lightArray[i, j].GetComponent<LightController>().isOn));
            }
        }
        //クリア判定
        if (AllLightsAreOn)
        {
            GameClear();
        }
    }

    void LoadSprites()
    {
        sprites = Resources.LoadAll<Sprite>("Sprites/");
    }

    /*void EditPrefab()
    {
        //仮想シーンにprefabを読み込み
        GameObject prefab = PrefabUtility.LoadPrefabContents(prefabPath);
        //prefabの編集
        prefab.GetComponent<Image>().sprite = sprites[Random.Range(0, sprites.Length)];
        //セーブ、解放
        PrefabUtility.SaveAsPrefabAsset(prefab, prefabPath);
        PrefabUtility.UnloadPrefabContents(prefab);
    }*/

    void SetLevel()
    {
        level = PlayerPrefs.GetInt("LEVEL", levelMinLimit);
        //レベル51～
        if (level > levelMaxLimit)
        {
            level = levelMaxLimit;
            PlayerPrefs.SetInt("LEVEL", levelMaxLimit);
            PlayerPrefs.SetInt("MAXLEVEL", levelMaxLimit + 1);//最終レベルクリア判定
        }
        //～レベル1
        if (level < levelMinLimit)
        {
            level = levelMinLimit;
            PlayerPrefs.SetInt("LEVEL", levelMinLimit);
            PlayerPrefs.SetInt("MAXLEVEL", levelMinLimit);
        }
    }

    void SetLight()
    {
        level = PlayerPrefs.GetInt("LEVEL", levelMinLimit);
        lightArray = new GameObject[level, level];
        var selectedSprite = sprites[Random.Range(0, sprites.Length)];
        for (int j = 0; j < level; j++)
        {
            for (int i = 0; i < level; i++)
            {
                lightArray[i, j] = Instantiate(lightPrefab, prefabParent.transform);
                lightArray[i, j].GetComponent<Image>().sprite = selectedSprite;
                RectTransform rect = lightArray[i, j].GetComponent<RectTransform>();
                rect.localScale = new Vector3(1.0f / level, 1.0f / level, 1.0f);
                //rect.position = prefabParent.transform.position + new Vector3(i * 1000 / level + 460, j * 1000 / level + 40, 0);
                int width = Screen.width;
                int height = Screen.height;
                float pos_x = i * 1000 * width / (1920 * level) - (500 * width / 1920);
                float pos_y = j * 1000 * width / (1920 * level) - (500 * width / 1920);
                rect.position = prefabParent.transform.position + new Vector3(pos_x, pos_y, 0);
                LightController light = lightArray[i, j].GetComponent<LightController>();
                light.id_x = i; light.id_y = j;
            }
        }
        for (int j = 0; j < level; j++)
        {
            for (int i = 0; i < level; i++)
            {
                LightController light = lightArray[i, j].GetComponent<LightController>();
                //上下左右
                if (j != level - 1) light.neighbors[0] = lightArray[i, j + 1];
                if (j != 0) light.neighbors[1] = lightArray[i, j - 1];
                if (i != 0) light.neighbors[2] = lightArray[i - 1, j];
                if (i != level - 1) light.neighbors[3] = lightArray[i + 1, j];
            }
        }
    }

    public void SetUI()
    {
        //Level選択dropdown
        List<string> optionlist = new List<string>();
        for (int i = levelMinLimit; i <= Mathf.Min(levelMaxLimit, PlayerPrefs.GetInt("MAXLEVEL", levelMinLimit)); i++)
        {
            optionlist.Add("level " + i.ToString());
        }
        dropdown.ClearOptions();
        dropdown.AddOptions(optionlist);
        dropdown.value = level - levelMinLimit;

        //gameclear表示用UI
        gameClearUI.SetActive(false);

        SetAchi();
    }

    public void SetAchi()
    {
        //実績
        for (int i = 0; i < Achievement.achiName.Length; i++)
        {
            //条件だけ見せて他隠す
            Achievement.achiObj[i].GetComponentsInChildren<Text>()[0].text = "???";//; + Achievement.achiName[i].Substring(Achievement.achiName[i].IndexOf("("));
            Achievement.achiObj[i].GetComponentsInChildren<Text>()[1].text = Achievement.achiName[i].Substring(Achievement.achiName[i].IndexOf("("));
        }
        //レベル実績
        for (int i = 0; i <= (PlayerPrefs.GetInt("MAXLEVEL", levelMinLimit) - levelMinLimit - 1); i++)
        {
            string achi = Achievement.achiName[i];
            //レベルに応じて実績解除
            Achievement.achiObj[i].GetComponentsInChildren<Text>()[0].text = achi.Substring(0, achi.IndexOf("("));
        }
        //クリック実績
        int clickCount = PlayerPrefs.GetInt("CLICKCOUNT", 0);
        if(clickCount > clickCountLimit)
        {
            clickCount = clickCountLimit;
            PlayerPrefs.SetInt("CLICKCOUNT", clickCount);
        }
        if(clickCount < 0)
        {
            clickCount = 0;
            PlayerPrefs.SetInt("CLICKCOUNT", clickCount);
        }
        for (int i = (levelMaxLimit - levelMinLimit + 1); i < Achievement.achiName.Length; i++)
        {
            int index = i - (levelMaxLimit - levelMinLimit + 1);
            if (clickCount < Achievement.achiNumber[index]) break;
            string achi = Achievement.achiName[i];
            Achievement.achiObj[i].GetComponentsInChildren<Text>()[0].text = achi.Substring(0, achi.IndexOf("("));
        }
    }

    void SetProblem()
    {
        for (int i = 0; i < (2 * (level * level) + 1); i++)
        {
            lightArray[Random.Range(0, level), Random.Range(0, level)].GetComponent<LightController>().OnLightClick(false);
        }
        AllLightsAreOn = false;
    }

    void GameClear()
    {
        gameClearUI.SetActive(true);
        gameClearUI.transform.GetChild(1).GetComponent<Text>().text = $"Level {level} Clear!";
        if (level >= PlayerPrefs.GetInt("MAXLEVEL", levelMinLimit))
        {
            Notification.Send(Achievement.achiName[level - levelMinLimit]);
        }
    }

    public void GoToNextLevel() //buttonにアタッチ
    {
        level++;
        PlayerPrefs.SetInt("LEVEL", level);
        PlayerPrefs.SetInt("MAXLEVEL", Mathf.Max(level, PlayerPrefs.GetInt("MAXLEVEL", levelMinLimit)));
        ResetScene();
    }

    public void DestroyLights()
    {
        foreach (GameObject light in lightArray)
        {
            Destroy(light);
        }
    }

    public void ResetScene()
    {
        DestroyLights();
        Start();
        //SceneManager.LoadScene("main");
        //Invoke("ResetScene", 1.5f);
    }

    public void OnDropDownClicked()
    {
        if ((dropdown.value + levelMinLimit) == level) return;
        PlayerPrefs.SetInt("LEVEL", dropdown.value + levelMinLimit);
        ResetScene();
    }
}
