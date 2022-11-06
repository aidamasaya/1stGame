using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemDataBase", menuName = "CreateItemDataBase")]
public class ItemDataBase : ScriptableObject
{
	//�X�̃A�C�e���f�[�^�̏����ꊇ�ŊǗ�����f�[�^�t�@�C�����쐬�B
	[SerializeField]
	private List<Item> itemLists = new List<Item>();
	//�@�A�C�e�����X�g��Ԃ�
	public List<Item> GetItemLists()
	{
    	return itemLists;
	}
	
}
