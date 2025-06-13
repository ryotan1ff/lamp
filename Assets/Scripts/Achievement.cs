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
        achievementData = "�͂��߂Ă̓�-Lamp-(Level 2�N���A)," +
            "�j���[�r�[(Level 3�N���A)," +
            "���[�L�[(Level 4�N���A)," +
            "�r�M�i�[(Level 5�N���A)," +
            "�����(Level 6�N���A)," +
            "�A�}�`���A(Level 7�N���A)," +
            "���]�є��N��(Level 8�N���A)," +
            "�E���S��(Level 9�N���A)," +
            "���̊J���(Level 10�N���A)," +
            "�|�b�L�[(Level 11�N���A)," +
            "�_�[�X(Level 12�N���A)," +
            "����������(Level 13�N���A)," +
            "�E�l(Level 14�N���A)," +
            "�Q�[�}�[(Level 15�N���A)," +
            "�Z�~�v��(Level 16�N���A)," +
            "�v��(Level 17�N���A)," +
            "���l(Level 18�N���A)," +
            "�ɐl(Level 19�N���A)," +
            "���̓��B��(Level 20�N���A)," +
            "���Œ�R(Level 21�N���A)," +
            "�˂�(Level 22�N���A)," +
            "���l(Level 23�N���A)," +
            "�ϐl(Level 24�N���A)," +
            "�}�X�^�[(Level 25�N���A)," +
            "�t��(Level 26�N���A)," +
            "�C�s�m(Level 27�N���A)," +
            "�n���^�[(Level 28�N���A)," +
            "�o�P����(Level 29�N���A)," +
            "���̍U����(Level 30�N���A)," +
            "�o�X�L�����r���X(Level 31�N���A)," +
            "�܋��҂�(Level 32�N���A)," +
            "�E��(Level 33�N���A)," +
            "�����X�^�[(Level 34�N���A)," +
            "�����{��(Level 35�N���A)," +
            "����(Level 36�N���A)," +
            "����(Level 37�N���A)," +
            "�R�m(Level 38�N���A)," +
            "���l(Level 39�N���A)," +
            "���̉���(Level 40�N���A)," +
            "�p�Y(Level 41�N���A)," +
            "�Ҏ�(Level 42�N���A)," +
            "��(Level 43�N���A)," +
            "�X������(Level 44�N���A)," +
            "�e��(Level 45�N���A)," +
            "�鉤(Level 46�N���A)," +
            "�a������(Level 47�N���A)," +
            "���W�F���h(Level 48�N���A)," +
            "�_(Level 49�N���A)," +
            "���̔e��(Level 50�N���A)," +

            "�܂��n�܂����΂���(�N���b�N��10��)," +
            "�O���^���f�B�[�N�f��(�N���b�N��57��)," +
            "�I���������ł���ˁI�H(�N���b�N��89��)," +
            "���s����̓V��(�N���b�N��100��)," +
            "�Ȃ�ł�I(�N���b�N��334��)," +
            "���b�L�[�}��(�N���b�N��777��)," +
            "���s����̋S��(�N���b�N��1000��)," +
            "�^�N�V�[��(�N���b�N��1729��)," +
            "�������܃_�C�X(�N���b�N��3333��)," +
            "�J�v���J��(�N���b�N��6174��)," +
            "���E���b�L�[�}��(�N���b�N��7777��)," +
            "���S��(�N���b�N��8128��)," +
            "���ӂ̐����˂�(�N���b�N��10000��)," +
            "�ɁE���b�L�[�}��(�N���b�N��77777��)," +
            "���s����̃v��(�N���b�N��100000��)," +
            "���O���i���o�[������(�N���b�N��111111��)";
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
            //�������������đ��B��
            achiObj[i].GetComponentsInChildren<Text>()[0].text = "???";// + achiName[i].Substring(achiName[i].IndexOf("("));
            achiObj[i].GetComponentsInChildren<Text>()[1].text = achiName[i].Substring(achiName[i].IndexOf("("));
        }
        RectTransform rect = Content.GetComponent<RectTransform>();
        rect.sizeDelta = new Vector2(rect.sizeDelta.x, 50f * achiName.Length);
    }
}
