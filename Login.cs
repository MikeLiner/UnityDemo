using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using LitJson;
using System;
using System.Collections.Generic;

public class MessageInfo{
	public string User{
		get;
		set;
	}
	public string Password{
		get;
		set;
	}
}

public class Login : MonoBehaviour {

	public InputField userField;
	public InputField passwordField;
	public Button button;
	// Use this for initialization
	void Start () {
		StartCoroutine ("Register");
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void LoginClick(){
		button.onClick.AddListener (LoginButton);
	}

	void LoginButton(){
		StartCoroutine ("Loginer");
	}

	IEnumerator Loginer(){
		string m_info = null;
		Dictionary<string, string> hash = new Dictionary<string, string> ();
		hash.Add ("Content-Type","application/json");
		string data = "{'email':'1234@qq.com','password':'123456'}";
		byte[] bs = System.Text.UTF8Encoding.UTF8.GetBytes (data);
		MessageInfo messageInfo = new MessageInfo ();
		messageInfo.User = userField.text;
		messageInfo.Password = passwordField.text;
		string str = JsonMapper.ToJson (messageInfo);
		WWW www = new WWW ("http://123.56.50.222:8050/userLogin",bs,hash);
		yield return www;
		if (www.error != null) {
			m_info = www.error;
			print (m_info);
			yield return null;
		} else {
			m_info = www.text;
			print (m_info);
		}
	}

	public void RegisterClick(){
		button.onClick.AddListener (RegisterButton);
	}

	void RegisterButton(){
		StartCoroutine ("Register");
	}

	IEnumerator Register(){
		string m_info = null;
		Dictionary<string, string> hash = new Dictionary<string, string> ();
		hash.Add ("Content-Type","application/json");
		string data = "{'email':'1234@qq.com','password':'123456'}";
		byte[] bs = System.Text.UTF8Encoding.UTF8.GetBytes (data);
		MessageInfo messageInfo = new MessageInfo ();
		messageInfo.User = userField.text;
		messageInfo.Password = passwordField.text;
		string str = JsonMapper.ToJson (messageInfo);
		WWW www = new WWW ("http://123.56.50.222:8050/userRegister",bs,hash);
		yield return www;
		if (www.error != null) {
			m_info = www.error;
			print (m_info);
			yield return null;
		} else {
			m_info = www.text;
			print (m_info);
		}
	}

}
