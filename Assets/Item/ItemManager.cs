using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�A�C�e���f�[�^�x�[�X����������o���B
public class ItemManager : MonoBehaviour
{
	//�@�A�C�e���f�[�^�x�[�X
	[SerializeField]
	private ItemDataBase itemDataBase;
	//�@�A�C�e�����Ǘ�
	private Dictionary<Item, int> numOfItem = new Dictionary<Item, int>();

	// Use this for initialization
	void Start()
	{

		for (int i = 0; i < itemDataBase.GetItemLists().Count; i++)
		{
			//�@�A�C�e������K���ɐݒ�
			numOfItem.Add(itemDataBase.GetItemLists()[i], i);
			//�@�m�F�̈׃f�[�^�o��
			Debug.Log(itemDataBase.GetItemLists()[i].GetItemName() + ": " + itemDataBase.GetItemLists()[i].GetInformation());
		}

		Debug.Log(GetItem("��").GetInformation());
		Debug.Log(numOfItem[GetItem("�A�^�b�N�A�b�p�[")]);
		Debug.Log(numOfItem[GetItem("���̃J�M")]);
	}

	//�@���O�ŃA�C�e�����擾
	public Item GetItem(string searchName)
	{
		return itemDataBase.GetItemLists().Find(itemName => itemName.GetItemName() == searchName);
	}
}