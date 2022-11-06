using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[Serializable]
[CreateAssetMenu(fileName = "Item", menuName="CreateItem")]
public class Item : ScriptableObject
{
    //アイテムデータベースに登録するアイテム個々の情報を保持するItemクラスを作成。
    public enum KindOfItem
    {
        PlayerItem,
        PassiveItem,
        KeyItem
    }
	//　アイテムの種類
	[SerializeField]
	private KindOfItem kindOfItem;
	//　アイテムのアイコン
	[SerializeField]
	private Sprite icon;
	//　アイテムの名前
	[SerializeField]
	private string itemName;
	//　アイテムの情報
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
