using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    BaseEnemyController _enemy;
    Rigidbody2D _rb;
    [SerializeField] float _movespeed;
    bool _h;
    SpriteRenderer _sprite = default;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = -1 *  transform.right * _movespeed;
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Wall" || collision.gameObject.tag == "Ground")
        {
            Destroy(this.gameObject);
            PlayerController._shoot -= 1;
        }
        if(collision.gameObject.tag == "enemy")
        {
            _enemy._hp -= 1;
            PlayerController._shoot -= 1;
            Destroy(this.gameObject);
        }
    }
}
