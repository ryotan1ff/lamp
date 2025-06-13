using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Achievement : MonoBehaviour
{
    public static string[] achiName;
    string achievementData;
    public static int[] achiNumber;
    public GameObject Content;
    public GameObject achiPrefab;
    public static GameObject[] achiObj;

    // Start is called before the first frame update
    void Awake()
    {
        SetData();
        InstantiateAchi();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SetData()
    {
        achievementData = "はじめての灯-Lamp-(Level 2クリア)," +
            "ニュービー(Level 3クリア)," +
            "ルーキー(Level 4クリア)," +
            "ビギナー(Level 5クリア)," +
            "入門者(Level 6クリア)," +
            "アマチュア(Level 7クリア)," +
            "七転び八起き(Level 8クリア)," +
            "脱初心者(Level 9クリア)," +
            "灯の開拓者(Level 10クリア)," +
            "ポッキー(Level 11クリア)," +
            "ダース(Level 12クリア)," +
            "負けず嫌い(Level 13クリア)," +
            "職人(Level 14クリア)," +
            "ゲーマー(Level 15クリア)," +
            "セミプロ(Level 16クリア)," +
            "プロ(Level 17クリア)," +
            "成人(Level 18クリア)," +
            "暇人(Level 19クリア)," +
            "灯の到達者(Level 20クリア)," +
            "拳で抵抗(Level 21クリア)," +
            "ねこ(Level 22クリア)," +
            "名人(Level 23クリア)," +
            "変人(Level 24クリア)," +
            "マスター(Level 25クリア)," +
            "師匠(Level 26クリア)," +
            "修行僧(Level 27クリア)," +
            "ハンター(Level 28クリア)," +
            "バケモン(Level 29クリア)," +
            "灯の攻略者(Level 30クリア)," +
            "バスキンロビンス(Level 31クリア)," +
            "賞金稼ぎ(Level 32クリア)," +
            "勇者(Level 33クリア)," +
            "モンスター(Level 34クリア)," +
            "疾風怒涛(Level 35クリア)," +
            "賢者(Level 36クリア)," +
            "魔王(Level 37クリア)," +
            "騎士(Level 38クリア)," +
            "狂人(Level 39クリア)," +
            "灯の王者(Level 40クリア)," +
            "英雄(Level 41クリア)," +
            "猛者(Level 42クリア)," +
            "幻(Level 43クリア)," +
            "森羅万象(Level 44クリア)," +
            "覇王(Level 45クリア)," +
            "帝王(Level 46クリア)," +
            "殿堂入り(Level 47クリア)," +
            "レジェンド(Level 48クリア)," +
            "神(Level 49クリア)," +
            "灯の覇者(Level 50クリア)," +

            "まだ始まったばかり(クリック回数10回)," +
            "グロタンディーク素数(クリック回数57回)," +
            "！○○○○ですよね！？(クリック回数89回)," +
            "試行錯誤の天才(クリック回数100回)," +
            "なんでや！(クリック回数334回)," +
            "ラッキーマン(クリック回数777回)," +
            "試行錯誤の鬼才(クリック回数1000回)," +
            "タクシー数(クリック回数1729回)," +
            "いかさまダイス(クリック回数3333回)," +
            "カプレカ数(クリック回数6174回)," +
            "超・ラッキーマン(クリック回数7777回)," +
            "完全数(クリック回数8128回)," +
            "感謝の正拳突き(クリック回数10000回)," +
            "極・ラッキーマン(クリック回数77777回)," +
            "試行錯誤のプロ(クリック回数100000回)," +
            "お前がナンバーワンだ(クリック回数111111回)";
        achiName = achievementData.Split(',');
        achiNumber = new int[] { 10, 57, 89, 100, 334, 777, 1000, 1729, 3333, 6174, 7777, 8128, 10000, 77777, 100000, 111111 };
    }

    void InstantiateAchi()
    {
        achiObj = new GameObject[achiName.Length];
        for (int i = 0; i < achiName.Length; i++)
        {
            int width = Screen.width;
            achiObj[i] = Instantiate(achiPrefab, (Content.transform.position + new Vector3(0f, -i * 50f * width/1920, 0f)), Quaternion.identity, Content.transform);
            //条件だけ見せて他隠す
            achiObj[i].GetComponentsInChildren<Text>()[0].text = "???";// + achiName[i].Substring(achiName[i].IndexOf("("));
            achiObj[i].GetComponentsInChildren<Text>()[1].text = achiName[i].Substring(achiName[i].IndexOf("("));
        }
        RectTransform rect = Content.GetComponent<RectTransform>();
        rect.sizeDelta = new Vector2(rect.sizeDelta.x, 50f * achiName.Length);
    }
}
