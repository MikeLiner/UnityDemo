using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Text;

public class WWWDemo : MonoBehaviour {
	public Image m_uploadImage;
	[HideInInspector]
	public Texture m_downloadTexture;
	public GameObject cube;
	public GameObject sphere;
	// Use this for initialization
	void Start () {
		StartCoroutine ("DownloadByFile");
		StartCoroutine ("DownloadFromNet");
		StartCoroutine ("PostTest");
	}

	IEnumerator DownloadByFile(){
//		using (WWW texture = new WWW ("file://" +
//			"/Users/apple/Desktop/Cat.jpg")) {
//			yield return texture;
//			cube.GetComponent<Renderer> ().material.mainTexture = texture.texture;
//		}

		WWW texture = new WWW ("file://" +
						"/Users/apple/Desktop/Cat.jpg");
		yield return texture;
		cube.GetComponent<Renderer> ().material.mainTexture = texture.texture;
		texture.Dispose ();
	}

	IEnumerator DownloadFromNet(){
//		using (WWW data = new WWW ("https://timgsa.baidu.com/timg?" +
//			"image&quality=80&size=b9999_10000&sec=1507886141223&di=" +
//			"20b555838994ddde8e3544b62212680f&imgtype=0&src=" +
//			"http%3A%2F%2Fwww.yuleren.tv%2Fuploads%2F1480076475.jpg")) {
//			yield return data;
//			sphere.GetComponent<Renderer> ().material.mainTexture = data.texture;
//		}

		WWW data = new WWW ("https://timgsa.baidu.com/timg?image&quality=80&size=b9999_10000&sec=1507886141223&di=20b555838994ddde8e3544b62212680f&imgtype=0&src=http%3A%2F%2Fwww.yuleren.tv%2Fuploads%2F1480076475.jpg");
		yield return data;
		sphere.GetComponent<Renderer> ().material.mainTexture = data.texture;
		data.Dispose ();
	}

	IEnumerator PostTest(){
		string m_info = null;
		Dictionary<string, string> hash = new Dictionary<string, string> ();
		hash.Add ("Content-Type","application/json");
		string data = "{'email':'1234@qq.com','password':'123456'," +
			"'phoneIdentity':'32324aasd2312313'}";
		byte[] bs = System.Text.UTF8Encoding.UTF8.GetBytes (data);
		WWW www = new WWW ("http://123.56.50.222:8050/userLogin",bs,hash);
		yield return www;
		if(www.error!=null){
			m_info = www.error;
			yield return null;
		}
		m_info = www.text;
		print (m_info);
	}

	IEnumerator IRequestPNG(){
		string m_info = null;
		byte[] bs = m_uploadImage.sprite.texture.EncodeToPNG ();
		WWWForm form = new WWWForm ();
		form.AddBinaryData ("Picture",bs,"screenshot","image/png");
		form.AddField ("username","zhangsan");
		form.AddField ("pwd","******");
		WWW www = new WWW ("http://127.0.0.1/Test.php",form);
		yield return www;
		if(www.error!=null){
			m_info = www.error;
			yield return null;
		}
		m_downloadTexture = www.texture;
	}

	string GetURL(string mainURL,Dictionary<string,string> dic){
		StringBuilder url = new StringBuilder (mainURL);
//		string web = "http://127.0.0.1/test.php?";
//		dic.Add ("username","get");
//		dic.Add ("password","12345");
		url.Append ("?");
		if(dic.Count!=0){
			foreach (var item in dic) {
				url.Append (item.Key).Append ("=").Append (item.Value).Append ("&");
			}
			url.Remove (url.Length-1,1);
		}
		return url.ToString ();
	}
	
	// Update is called once per frame
	void Update () {
	  
	}
}
