using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[Serializable]
[CreateAssetMenu(fileName = "Item", menuName="CreateItem")]
public class Item : ScriptableObject
{
    //�A�C�e���f�[�^�x�[�X�ɓo�^����A�C�e���X�̏���ێ�����Item�N���X���쐬�B
    public enum KindOfItem
    {
        PlayerItem,
        PassiveItem,
        KeyItem
    }
	//�@�A�C�e���̎��
	[SerializeField]
	private KindOfItem kindOfItem;
	//�@�A�C�e���̃A�C�R��
	[SerializeField]
	private Sprite icon;
	//�@�A�C�e���̖��O
	[SerializeField]
	private string itemName;
	//�@�A�C�e���̏��
	[SerializeField]
	private string information;
	[SerializeField]
	private GameObject gameObject;

	public KindOfItem GetKindOfItem()
	{
		return kindOfItem;
	}

	public Sprite GetIcon()
	{
		return icon;
	}

	public string GetItemName()
	{
		return itemName;
	}

	public string GetInformation()
	{
		return information;
	}

	public GameObject GetItemPrefab()
    {
		return gameObject;
    }

}
