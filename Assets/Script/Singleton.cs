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
    int _coin = 0; //通貨アイテム
    /// <summary>一画面内に許される弾の数</summary>
    [SerializeField] int _bulletsInScene = 4;

    //public int BulletsInScene <-  画面内に連射可能な球数後に書く
    public int BulletsInScene
    {
        get { return _bulletsInScene; }
        set { _bulletsInScene = value; }
    }

    /// <summary>
    /// シーンが切り替わる時のプレイヤーの向き
    /// </summary>
    ///
    public Vector3 PlayerDirection
    {
        get { return _playerDirection; }
        set { _playerDirection = value; }
    }

    /// <summary>
    /// シーンが切り替わった時にプレイヤーの初期位置となる Transform の名前
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
            // インスタンスが既にある場合は、破棄する
            Debug.LogWarning($"SingletonSystem のインスタンスは既に存在するので、{gameObject.name} は破棄します。");
            Destroy(this.gameObject);
        }
        else
        {
            // このクラスのインスタンスが無かった場合は、自分を DontDestroyOnload に置く
            Instance = this;
            SceneManager.sceneLoaded += OnSceneLoaded;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    /// <summary>
    /// シーンがロードされた時に呼ぶ。
    /// シーンが切り替わった時のプレイヤーの場所と向きを制御する。
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
                Debug.LogError("Player が見つかりません。");
            }
        }

        if (player)
        {
            player.transform.up = this.PlayerDirection;
        }
    }
    /// <summary>
    /// 得点を追加し、得点表示を更新する。
    /// </summary>
    /// <param name="score">追加する点数</param>
    public void AddScore(int score)
    {
        _coin += score;
        _coinText.text = _coin.ToString("d2");
    }
}
