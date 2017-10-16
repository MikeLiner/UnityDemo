using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using LitJson;
using System.Xml;

public class XMLParse : MonoBehaviour {

	// Use this for initialization
	void Start () {
		//CreateXML ();
		//LoadXML ();
		UpdateXML ();
	}

	void CreateXML(){
		Debug.Log (Application.persistentDataPath);
		string path = Application.persistentDataPath+"/data2.xml";
		if(!File.Exists(path)){
			XmlDocument xml = new XmlDocument ();
			XmlElement root = xml.CreateElement ("objects");
			XmlElement element = xml.CreateElement ("message");
			element.SetAttribute ("id","1");

			XmlElement elementChild1 = xml.CreateElement ("contents");
			elementChild1.SetAttribute ("name","a");
			elementChild1.InnerText = "Find a people";
			XmlElement elementChild2 = xml.CreateElement ("mission");
			elementChild2.SetAttribute ("map","abc");
			elementChild2.InnerText = "去吧，少年，去实现你的梦想吧";

			element.AppendChild (elementChild1);
			element.AppendChild (elementChild2);
			root.AppendChild (element);
			xml.AppendChild (root);
			xml.Save (path);
			print (xml.OuterXml);
		}
	}

	void LoadXML(){
		XmlDocument xml = new XmlDocument ();
		xml.Load (Application.persistentDataPath+"/data2.xml");
		XmlNodeList xmlNodeList = xml.SelectSingleNode ("objects").ChildNodes;
		foreach (XmlElement xml1 in xmlNodeList) {
			if(xml1.GetAttribute("id")=="1"){
				foreach (XmlElement xml2 in xml1.ChildNodes) {
					if(xml2.GetAttribute("name")=="a"){
						print ("*******"+xml2.GetAttribute("name")+":"+xml2.InnerText);
					}else if(xml2.GetAttribute("map")=="abc"){
						print ("*******"+xml2.GetAttribute("name")+":"+xml2.InnerText);
					}
				}
			}

		}
	}

	void UpdateXML(){
		string path = Application.persistentDataPath+"/data2.xml";
		if(File.Exists(path)){
			XmlDocument xml = new XmlDocument ();
			xml.Load (path);
			XmlNodeList xmlNodeList = xml.SelectSingleNode ("objects").ChildNodes;
			foreach (XmlElement xml1 in xmlNodeList) {
				if(xml1.GetAttribute("id")=="1"){
					xml1.SetAttribute ("id","3");
				}
				if(xml1.GetAttribute("id")=="3"){
					foreach (XmlElement xml2 in xml1.ChildNodes) {
						if(xml2.GetAttribute("name")=="a"){
							xml2.SetAttribute ("name","b");
							xml2.InnerText = "Success";
						}
					}
				}
			}
			xml.Save (path);
		}

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
