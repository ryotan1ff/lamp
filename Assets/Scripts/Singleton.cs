using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//アタッチしたオブジェクトがシーンをまたいで一つだけ存在するようになる

public class Singleton : MonoBehaviour
{
    public static Singleton instance;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        CheckInstance();
    }

    void CheckInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
