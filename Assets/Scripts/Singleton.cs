using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//�A�^�b�`�����I�u�W�F�N�g���V�[�����܂����ň�������݂���悤�ɂȂ�

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
