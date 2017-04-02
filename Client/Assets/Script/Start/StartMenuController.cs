using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartMenuController : MonoBehaviour {
    [SerializeField]
    private GameObject _startPanel;
    [SerializeField]
    private GameObject _loginPanel;
    [SerializeField]
    private GameObject _registerPanel;
    [SerializeField]
    private GameObject _serverPanel;
    [SerializeField]
    private GameObject _selectCharacter;

    [SerializeField]
    private InputField _userNameInputLogin;
    [SerializeField]
    private InputField _passworkInputLogin;
    [SerializeField]
    private Text _userNameInputStart;
    [SerializeField]
    private Text _serverNameStart;
    [SerializeField]
    private InputField _userNameInputRegister;
    [SerializeField]
    private InputField _passwordInputRegister;
    [SerializeField]
    private InputField _rePasswordInputRegister;

    [SerializeField]
    private GridLayoutGroup _serverList;
    [SerializeField]
    private GameObject _serverItemRed;
    [SerializeField]
    private GameObject _serverItemGreen;
    [SerializeField]
    private GameObject _serverSelect;

    public static string UserName;
    public static string Password;
    public static ServerProperty ServerSceletInfo; 

    void Start()
    {
        InitServerList();
    }

    //start event
    public void OnUserNameClick()
    {
        _startPanel.SetActive(false);
        _loginPanel.SetActive(true);
    }
	public void OnServerClick()
    {
        _startPanel.SetActive(false);
        _serverPanel.SetActive(true);
        
    }
    public void OnEnterGameClick()
    {
        _startPanel.SetActive(false);
        _selectCharacter.SetActive(true);
    }
    //login event
    public void OnLoginClick()
    {
        UserName = _userNameInputLogin.text;
        Password = _passworkInputLogin.text;

        _userNameInputStart.text = UserName;

        _startPanel.SetActive(true);
        _loginPanel.SetActive(false);
    }
    public void OnRegisterShowClick()
    {
        _loginPanel.SetActive(false);
        _registerPanel.SetActive(true);
    }
    public void OnLoginCloseClick()
    {
        _startPanel.SetActive(true);
        _loginPanel.SetActive(false);
    }
    //register panel
    public void OnCancelClick()
    {
        _registerPanel.SetActive(false);
        _loginPanel.SetActive(true);
    }
    public void OnRegisterCloseClick()
    {
        OnCancelClick();
    }
    public void OnRegisterAndLoginClick()
    {
        UserName = _userNameInputRegister.text;
        Password = _passwordInputRegister.text;

        _userNameInputStart.text = UserName;

        _registerPanel.SetActive(false);
        _startPanel.SetActive(true);
    }
    private void InitServerList()
    {
        for(int i = 0; i < 20; i++)
        {
            string ip = "127.0.0.1:9080";
            string name = (i + 1) + "区 勇者无敌";
            int count = Random.Range(1, 100);
            GameObject go = null;
            if (count > 50)
            {
                go = Instantiate(_serverItemRed);
            }
            else
            {
                go = Instantiate(_serverItemGreen);
            }
            go.transform.SetParent( _serverList.transform);
            ServerProperty sp = go.GetComponent<ServerProperty>();
            sp.SetData(ip, name, count);
        }
     
    }
    public void OnServerSelect(bool isSelect,GameObject go)
    {
        ServerSceletInfo = go.GetComponent<ServerProperty>();
        if (isSelect)
        {
            _serverNameStart.text = ServerSceletInfo.GetName();
            _serverPanel.SetActive(false);
            _startPanel.SetActive(true);
        }
        else
        {
            var sp = go.GetComponent<ServerProperty>();
            _serverSelect.GetComponent<ServerProperty>().SetData(sp.GetIp(), sp.GetName(), sp.GetCount());
            _serverSelect.GetComponent<Image>().sprite = go.GetComponent<Image>().sprite;
            _serverSelect.GetComponentInChildren<Text>().text = ServerSceletInfo.GetName();
            _serverSelect.GetComponentInChildren<Text>().color = go.GetComponentInChildren<Text>().color;
        }
    }
    //select Character
    
}
