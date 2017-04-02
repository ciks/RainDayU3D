using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ServerProperty : MonoBehaviour {
    private string _ip = "127.0.0.1:9080";
    private string _name = "一区 天下盟";
    private int _count = 100;
    public void SetData(string ip,string name,int count)
    {
        _ip = ip;
        _name = name;
        _count = count;
        transform.GetComponentInChildren<Text>().text = name;
    }

    public void OnPress(bool isSelect)
    {
        var con = transform.root.GetComponentInChildren<StartMenuController>();
        con.OnServerSelect(isSelect, gameObject);
    }
    public string GetName()
    {
        return _name;
    }
    public string GetIp()
    {
        return _ip;
    }
    public int GetCount()
    {
        return _count;
    }
}
