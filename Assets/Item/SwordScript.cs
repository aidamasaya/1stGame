using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordScript : MonoBehaviour
{
    Animator _anim;
    BaseEnemyController _enemy;
    Rigidbody2D _rb;
    PlayerController _player;
    GameObject _child;
    void Start()
    {
        _anim = GetComponent<Animator>();
        _player = GetComponent<PlayerController>();
        _rb = GetComponent<Rigidbody2D>();
        _child.transform.SetParent(_player.transform);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton("s"))
        {
            //_anim.SetFloat("Attack",)
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
       if(collision.gameObject.tag == "enemy")
        {
            _enemy._hp -= 1;
        }
    }
}
