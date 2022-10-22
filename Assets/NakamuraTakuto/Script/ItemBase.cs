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
    /// <summary>�A�C�e���̎��</summary>
    [SerializeField, Header("�A�C�e���̎��")]
    public Type itemType = Type.Key;
    /// <summary>�A�C�e���̖��O</summary>
    [SerializeField, Header("�A�C�e���̖��O")]
    public string itemName = "";
    /// <summary>�A�C�e���̐���</summary>
    [SerializeField, Header("�A�C�e���̐���")]
    public string itemInformation = "";
}
