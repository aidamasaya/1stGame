using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    /// <summary>�ړ���̃V�[����</summary>
    [SerializeField] string _sceneName = "";
    /// <summary>�ړ���� Transform �̃I�u�W�F�N�g��</summary>
    [SerializeField] string _pointName = "";
    /// <summary>
    /// �V�[����؂�ւ���
    /// </summary>
    /// <param name="sceneName">���[�h����V�[����</param>
    /// <param name="pointName">�V�[�������[�h�������ɁA�v���C���[�͂��̖��O�� Transform �Ɉړ�����</param>
    /// <param name="direction">�v���C���[�̌����Ă�������B�V�[�����؂�ւ�������ɂ��̕������ێ�����</param>
    void SwitchScene(string sceneName, string pointName, Vector2 direction)
    {
        // �����ƈړ����ۑ�����
        Singleton.Instance.PlayerDirection = direction;
        Singleton.Instance.PointNameOnSceneLoaded = pointName;
        // �V�[����ǂݍ���Ő؂�ւ���
        SceneManager.LoadScene(sceneName);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SwitchScene(_sceneName, _pointName, collision.gameObject.transform.up);
        }
    }
}
