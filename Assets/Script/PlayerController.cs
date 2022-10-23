using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    /// <summary>�ړ����鎞�ɂ������</summary>
    [SerializeField] float m_movePower = 3f;
    /// <summary>�W�����v���x</summary>
    [SerializeField] float m_jumpSpeed = 5f;
    /// <summary>�W�����v���ɃW�����v�{�^���𗣂������̏㏸���x������</summary>
    [SerializeField] float m_gravityDrag = .4f;
    Rigidbody2D m_rb = default;
    /// <summary>�ڒn�t���O</summary>
    bool m_isGrounded = false;
    Vector3 m_initialPosition = default;
    Animator m_anim = default;
    SpriteRenderer m_sprite = default;
    float m_h = 0;
    public static bool dead = false;
    [SerializeField] Transform _muzzle = default;
    [SerializeField] BulletController _bullet = default;
    bool isRight;
   
    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
        m_anim = GetComponent<Animator>();
        m_sprite = GetComponent<SpriteRenderer>();
        m_initialPosition = this.transform.position;
    }

   
    void Update()
    {
        m_h = Input.GetAxis("Horizontal");
        Vector2 velocity = m_rb.velocity;

        // �W�����v����
        if (Input.GetButtonDown("Jump") && m_isGrounded)
        {
            m_isGrounded = false;
            velocity.y = m_jumpSpeed;
        }
        else if (!Input.GetButton("Jump") && velocity.y > 0)
        {
            // �㏸���ɃW�����v�{�^���𗣂�����㏸����������
            velocity.y *= m_gravityDrag;
        }

        m_rb.velocity = velocity;

        // ��ʊO�ɗ������珉���ʒu�ɖ߂�
        if (this.transform.position.y < -15)
        {
            this.transform.position = m_initialPosition;
        }
        if(Input.GetButtonDown("Fire1"))
        {
            Instantiate(_bullet, _muzzle.position, transform.rotation);
        }
        if (Input.GetButton("Horizontal"))
        {
            if (isRight && m_h < 0)
            {
                this.transform.Rotate(0f, 180f, 0f);
                isRight = false;
            }
            if (!isRight && m_h > 0)
            {
                this.transform.Rotate(0f, 180f, 0f);
                isRight = true;
            }
        }
    }
    void FixedUpdate()
    {
        m_rb.AddForce(m_h * m_movePower * Vector2.right);
        if (Input.GetButtonDown("Jump"))
        {
            m_rb.AddForce(Vector2.up * m_jumpSpeed, ForceMode2D.Impulse);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        m_isGrounded = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        m_isGrounded = false;
    }
    private void LateUpdate()
    {
        // �L�����N�^�[�̍��E�̌����𐧌䂷��
        if (m_h != 0)
        {
            m_sprite.flipX = (m_h < 0);
        }

        // �A�j���[�V�����𐧌䂷��
        //if (m_anim)
        //{
        //    m_anim.SetFloat("SpeedX", Mathf.Abs(m_rb.velocity.x));
        //    m_anim.SetFloat("SpeedY", m_rb.velocity.y);
        //    m_anim.SetBool("IsGrounded", m_isGrounded);
        //}
    }
    public void Dead()
    {
        dead = true;
    }
}
