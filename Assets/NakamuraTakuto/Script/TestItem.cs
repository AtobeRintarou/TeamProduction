using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestItem : ItemBase
{
    [SerializeField] GameObject textObj;
    Text getText;
    private void Start()
    {
        getText = textObj.GetComponent<Text>();
    }
    public void log()
    {
        getText.text = "çÏìÆÇµÇΩ";
    }
}
