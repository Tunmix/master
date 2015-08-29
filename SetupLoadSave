//29.8.2015 Jakub Ivanič C#
using UnityEngine;
using System.Text.RegularExpressions;
using System.IO;

[ExecuteInEditMode]
public class SetupLoadSave : MonoBehaviour {
	
	string setupFileText="";
	//Component yourComponent;
	[HideInInspector]
	public bool	loadingSetup=false;
	[HideInInspector]
	public bool	savingSetup=false;
	public string filePath=""; // ="" mandatory to avoid null reference error (string variables are instantiated as null, not empty string)
	public bool usePersistentDataPath=false;
	string value;
	string message;
	StreamWriter writer;
	StreamReader reader;
	int index0, index1, index2, index3, index4, index5, i;
	
	void Awake(){
		SetComponent();
		if (filePath!=""){
			LoadSetup();
		}	
	}
	
	void SetComponent(){
		//yourComponent = GetComponent<Component>();
	}
	
	void OnApplicationQuit(){
		loadingSetup=false;
	}
	
	public void SaveValue(string parameter,string value,string section){
		index1=setupFileText.IndexOf("["+section+"]");
		if (index1!=-1){ // section found
			index2=setupFileText.IndexOf('[',index1+1);
			if (index2!=-1) // next section found
				index2-=2;
			else // next section not found
				index2=setupFileText.Length;
			
			string pattern=string.Format(@"\b{0}\b", parameter);
			Regex reg = new Regex(@pattern);
			string txt=setupFileText.Substring(index1,index2-index1);
			index5=reg.Match(txt).Index;
			if (index5!=0){ // parameter found
				index2=setupFileText.IndexOf("=",index5+index1) + 1;
				index3=setupFileText.IndexOf('\n',index5+index1);
				index4=setupFileText.IndexOf('#',index5+index1);
				if (index4!=-1) index3=Mathf.Min(index3,index4);
				if (index3==-1) index3=txt.Length + index1; // end of the section
				setupFileText=setupFileText.Remove(index2 ,index3-index2);
				setupFileText=setupFileText.Insert(index2 ,value);
			}
			else{ // parameter not found
				setupFileText=setupFileText.Insert(index2,'\n'+parameter+"="+value);
			}
		}
		else{ // section not found
			string txt="";
			if (setupFileText.Length!=0) txt="\n\n";
			setupFileText=setupFileText.Insert(setupFileText.Length,txt+"["+section+"]");
			index2=setupFileText.Length;
			setupFileText=setupFileText.Insert(index2,'\n'+parameter+"="+value);
		}
	}
	
	public string LoadValue(string parameter,string section){
		string retValue="";
		index0=setupFileText.IndexOf("["+section+"]");
		if (index0!=-1){ // section found	
			string subString=setupFileText.Substring(index0);
			string pattern=string.Format(@"\b{0}\b", parameter);
			Regex reg = new Regex(@pattern);
			index1=reg.Match(subString).Index;
			if (index1!=0){ // parameter found
				index2=subString.Substring(index1).IndexOf('\n');
				if (index2==-1) index2=subString.Length - index1; // no "\n" found, we are at the end of the file
				index3=subString.Substring(index1,index2).IndexOf('#');
				if (index3!=-1) index2=index3; // ending "#" character found
				string txt=subString.Substring(index1-2,index2+2); //+-2 to be sure to include beginning "#" character
				index3=txt.IndexOf("#");
				if (index3==-1){ // beginning "#" character not found, we can load the value
					index3=txt.IndexOf("=");
					retValue=txt.Substring(index3 + 1);
				}
			}
		}
		return retValue;
	}
	
	bool LoadFromFile(string filePath, bool checkIfNotExist){
		try{
			if (File.Exists(filePath)){
				reader = new StreamReader(filePath);
				setupFileText=reader.ReadToEnd();
				reader.Close();
				return true;
			}
			else if (checkIfNotExist==true || filePath==""){			
				message="(file '" + filePath +"' couldn't be found)";
				return false;
			}
			else
				return true;
		}
		catch {
			return false;
		}
	}
	
	bool SaveToFile(string filePath){
		try{
			if (!File.Exists(filePath)) Debug.Log("file '" + filePath +"' not found, creating it");
			writer = new StreamWriter(filePath);
			writer.Write(setupFileText);
			writer.Close();
			return true;
		}
		catch{
			return false;
		}
	}
	
	public bool SaveSetup(){
		bool saved=false;
		message="";
		SetComponent();
		string mfilePath=filePath;
		if (usePersistentDataPath==true) mfilePath=Application.persistentDataPath + "\\" + filePath;
		if (filePath!=""){
			if (LoadFromFile(mfilePath,false)==true){
				savingSetup=true;
				//SaveComponentData();
				saved=SaveToFile(mfilePath);
				if (saved==true) Debug.Log(": setup saved succesfully in the file '"+ mfilePath+"'");
			}
		}
		else{
			message="(file path empty)";
		}
		
		if (message!="") Debug.LogError(": error during setup saving "+ message);
		
		savingSetup=false;
		return saved;
	}
	
	void SaveComponentData(){
		//SaveValue("weight",rigidbody.mass+"","body"); // Your things
	}

	public void LoadSetup(){
		loadingSetup=true;
		message="";
		SetComponent();
		string mfilePath=filePath;
		if (usePersistentDataPath==true) mfilePath=Application.persistentDataPath + "\\" + filePath;
		if (filePath!=""){
			if (LoadFromFile(mfilePath,true)==true){
				//if (setupFileText.Contains("[component]")) LoadComponentData();
				Debug.Log(": setup loaded succesfully from the file '"+ mfilePath+"'");
			}
		}
		else{
			message="(file path empty)";
		}
		
		if (message!="") Debug.LogError(": error during setup loading "+ message);
		
		loadingSetup=false;
	}
	
	void LoadComponentData(){
		//value=LoadValue("weight","body");//your things
	}	
}
