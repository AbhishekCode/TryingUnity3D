using UnityEngine;
using UnityEditor;
using System.Collections;
using LitJson;
using System.IO;

public class SaveSceneEditorScript : Editor {

	//TODO:: To format Generated JSON file use https://jsonformatter.curiousconcept.com/

    [MenuItem ("SaveAsJSON/Save Scene")]
	public static void saveSceneData () {
		JsonData gjson;
		GameObject[] objs =  FindObjectsOfType(typeof(GameObject)) as GameObject[]; 
		ObjectProps[] elms = new ObjectProps[objs.Length];
		for (int i=0; i<objs.Length; i++) {
			
			Vector3 rotation = new Vector3 (  objs[i].transform.localRotation.x , objs[i].transform.localRotation.y,objs[i].transform.localRotation.z);
			elms[i] = new ObjectProps(objs[i].name ,objs[i].transform.position, 
			                          rotation ,objs[i].transform.localScale);
			
		}
		
		gjson = JsonMapper.ToJson(elms);
		Debug.Log("object json "+ gjson);
		File.WriteAllText(Application.dataPath+"/Resources/Data/SceneData.json", gjson.ToString());
	}

	[MenuItem ("SaveAsJSON/Save Environment")]
	public static void saveEnvironmentData () {
		JsonData gjson;

		GameObject[] objs =  GameObject.FindGameObjectsWithTag("Environment") as GameObject[];
		ObjectProps[] elms = new ObjectProps[objs.Length];
		for (int i=0; i<objs.Length; i++) {
			
			Vector3 rotation = new Vector3 (  objs[i].transform.localRotation.x , objs[i].transform.localRotation.y,objs[i].transform.localRotation.z);
			elms[i] = new ObjectProps(objs[i].name ,objs[i].transform.position, 
			                          rotation ,objs[i].transform.localScale);
			
		}
		
		gjson = JsonMapper.ToJson(elms);
		Debug.Log("object json "+ gjson);
		File.WriteAllText(Application.dataPath+"/Resources/Data/SceneEnvironmentData.json", gjson.ToString());
	}

}

public class ObjectProps {
	public string name; 
	public Vector3Value postion;
	public Vector3Value rotation; 
	public Vector3Value scale; 
	
	public ObjectProps(string name , Vector3 pos , Vector3 rotation , Vector3 scale ) {
		this.name = name;
		this.postion = new Vector3Value(pos);
		this.rotation = new Vector3Value(rotation);
		this.scale = new Vector3Value(scale);
	}
}

public class  Vector3Value {
	public int x ; 
	public int y ;
	public int z ;
	
	public Vector3Value (Vector3 pos) {
		this.x = (int)pos.x;
		this.y = (int)pos.y;
		this.z = (int)pos.z;
	}
}