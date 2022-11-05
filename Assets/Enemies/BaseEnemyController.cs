using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemyController : MonoBehaviour
{
    Rigidbody2D _rb;
    [SerializeField] float _moveSpeed = -0.05f;
    SpriteRenderer _sprite = default;
    float _f;
    public int _hp = default;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _sprite = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        enemydeath();   
    }
    //エネミーデータベース    
    void enemydeath()
    {
      Destroy(this);
    }
    private void LateUpdate()
    {
        if (_f != 0)
        {
            _sprite.flipX = (_f < 0);
        }
    }
}
