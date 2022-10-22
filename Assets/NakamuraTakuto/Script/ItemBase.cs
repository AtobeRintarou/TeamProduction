using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemBase : MonoBehaviour
{
    public enum Type
    {
        Heal,
        Weapon,
        Buffed,
        DeBuffed,
        Key
    }
    /// <summary>アイテムの種類</summary>
    [SerializeField, Header("アイテムの種類")]
    public Type itemType = Type.Key;
    /// <summary>アイテムの名前</summary>
    [SerializeField, Header("アイテムの名前")]
    public string itemName = "";
    /// <summary>アイテムの説明</summary>
    [SerializeField, Header("アイテムの説明")]
    public string itemInformation = "";
}
