using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public PlayerController _player;
    public static GameManager Instance { get; private set; } //�C���X�^���X
    [SerializeField] bool _hideCursor = true;
    [SerializeField] Text _HPber;
    [SerializeField] Text _coinText; 
    [SerializeField] float _restartWaitTime = 1f;
    [SerializeField] UnityEngine.Events.UnityEvent _GameStart = null; //�Q�[���J�n�ɌĂяo������
    [SerializeField] UnityEngine.Events.UnityEvent _GameOver = null; //�Q�[���I�[�o�[���ɌĂяo������
    [SerializeField] UnityEngine.Events.UnityEvent _GameClear = null; //�Q�[���N���A���ɌĂяo������
    //public HPbar�@hpbar; 
    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
           CursorCheck();
           GameStart();
    }

    
    void Update()
    {
        if (PlayerController.dead)
        {
            PlayerController.dead = false;
            GameOver();
        }
    }
    void CursorCheck()
    {
        if(_hideCursor)
        {
            Cursor.visible = false;
        }
    }
    public void GameStart() //�Q�[���J�n�E���X�^�[�g���ɌĂ΂��֐�
    {
        _GameStart.Invoke();
    }
    public void GameOver()
    {
        SceneManager.LoadScene(6);
    }
    //public void GameClear()
    //{
    //    SceneManager.LoadScene(3);
    //}
    //void LoadScene()
    //{
    //    SceneManager.LoadScene(1);
    //}
}
