using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemDataBase", menuName = "CreateItemDataBase")]
public class ItemDataBase : ScriptableObject
{
	//個々のアイテムデータの情報を一括で管理するデータファイルを作成。
	[SerializeField]
	private List<Item> itemLists = new List<Item>();
	//　アイテムリストを返す
	public List<Item> GetItemLists()
	{
    	return itemLists;
	}
	
}
