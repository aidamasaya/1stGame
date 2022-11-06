using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Singleton : MonoBehaviour
{
    public static Singleton Instance = default;
    [SerializeField] Text _coinText = default;
    Vector3 _playerDirection = Vector2.up;
    string _pointNameOnSceneLoaded = "";
    GameObject _player = default;
    int _coin = 0; //�ʉ݃A�C�e��
    /// <summary>���ʓ��ɋ������e�̐�</summary>
    [SerializeField] int _bulletsInScene = 4;

    //public int BulletsInScene <-  ��ʓ��ɘA�ˉ\�ȋ�����ɏ���
    public int BulletsInScene
    {
        get { return _bulletsInScene; }
        set { _bulletsInScene = value; }
    }

    /// <summary>
    /// �V�[�����؂�ւ�鎞�̃v���C���[�̌���
    /// </summary>
    ///
    public Vector3 PlayerDirection
    {
        get { return _playerDirection; }
        set { _playerDirection = value; }
    }

    /// <summary>
    /// �V�[�����؂�ւ�������Ƀv���C���[�̏����ʒu�ƂȂ� Transform �̖��O
    /// </summary>
    public string PointNameOnSceneLoaded
    {
        get { return _pointNameOnSceneLoaded; }
        set { _pointNameOnSceneLoaded = value; }
    }
    void Awake()
    {
        if (Instance)
        {
            // �C���X�^���X�����ɂ���ꍇ�́A�j������
            Debug.LogWarning($"SingletonSystem �̃C���X�^���X�͊��ɑ��݂���̂ŁA{gameObject.name} �͔j�����܂��B");
            Destroy(this.gameObject);
        }
        else
        {
            // ���̃N���X�̃C���X�^���X�����������ꍇ�́A������ DontDestroyOnload �ɒu��
            Instance = this;
            SceneManager.sceneLoaded += OnSceneLoaded;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    /// <summary>
    /// �V�[�������[�h���ꂽ���ɌĂԁB
    /// �V�[�����؂�ւ�������̃v���C���[�̏ꏊ�ƌ����𐧌䂷��B
    /// </summary>
    /// <param name="scene"></param>
    /// <param name="mode"></param>
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        var player = GameObject.FindGameObjectWithTag("Player");

        if (this.PointNameOnSceneLoaded != "")
        {
            var point = GameObject.Find(this.PointNameOnSceneLoaded);

            if (player)
            {
                player.transform.position = point.transform.position;
            }
            else
            {
                Debug.LogError("Player ��������܂���B");
            }
        }

        if (player)
        {
            player.transform.up = this.PlayerDirection;
        }
    }
    /// <summary>
    /// ���_��ǉ����A���_�\�����X�V����B
    /// </summary>
    /// <param name="score">�ǉ�����_��</param>
    public void AddScore(int score)
    {
        _coin += score;
        _coinText.text = _coin.ToString("d2");
    }
}
