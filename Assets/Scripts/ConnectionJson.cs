using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Newtonsoft.Json.Linq;
using UnityEngine.Networking;
using System.IO;
using System.Linq;

public class ConnectionJson : MonoBehaviour
{
    public string URL;
    public RectTransform[] parentPanels;
    public string[] columnHeaders;
    public string[] ids; // variable para los ids
    public string[] names; // variable para la columna de nombres
    public string[] roles; // vaariables para la columna de roles
    public string[] nickNames; // variables para la columna de apodos

    public Text[] txtIds, txtNames, txtRoles, txtNickNames, txtSubTitle;
    public Text txt_titleJson;


    // Start is called before the first frame update
    public void ShowList()
    {
        URL = File.ReadAllText(Application.dataPath + "/StreamingAssets/JsonChallenge.json");

        JObject jo = JObject.Parse(URL);
        Debug.Log("JO: " + jo.Count);

        List<string> allofthemVar = new List<string>(); // Creo una lista y saco los valores del json guiandome de la estructura enviada
        foreach (var values in jo)
        {
            allofthemVar.Add(values.Value.ToString()); //almaceno cada una de las propiedades
            Debug.Log("Values from Json: " + values.Value); //verifico
        }

        txt_titleJson.text = allofthemVar[0]; //saco el titulo por aparte, es decir, la primera parte del json

        JArray ja = JArray.Parse(allofthemVar[2]); //saco la cantidad de informacion almacenada en data
        Debug.Log("JA: " + ja.Count);

        columnHeaders = new string[ja.Count];
        txtSubTitle = new Text[ja.Count];
        for (int i = 0; i < ja.Count; i++)
        {
            columnHeaders[i] = (string)jo["ColumnHeaders"][i].Value<string>();

            //-- subtitles
            txtSubTitle[i] = Instantiate(Resources.Load("TextBold", typeof(Text))) as Text;
            txtSubTitle[i].transform.SetParent(parentPanels[i]);
            txtSubTitle[i].transform.localPosition = new Vector2(i, 180);
            txtSubTitle[i].text = columnHeaders[i];

        } 

        //-- Saco toda la información de DATA de la tercera parte del JSON
        ids = new string[ja.Count];
        names = new string[ja.Count];
        roles = new string[ja.Count];
        nickNames = new string[ja.Count];

        //-- creo el tamaño de los textos que necesito para mostrar en la UI
        txtIds = new Text[ja.Count];
        txtNames = new Text[ja.Count];
        txtRoles = new Text[ja.Count];
        txtNickNames = new Text[ja.Count];

        for (int i = 0; i < ja.Count; i++)
        {
            //almaceno informacion del json en variables locales
            ids[i] = (string)jo["Data"][i]["ID"].Value<string>();
            names[i] = (string)jo["Data"][i]["Name"].Value<string>();
            roles[i] = (string)jo["Data"][i]["Role"].Value<string>();
            nickNames[i] = (string)jo["Data"][i]["Nickname"].Value<string>();

            //empiezo a instnciar, ubicar y convertir los string que almacenan la informacion en formato text
            //-- txts
            txtIds[i] = Instantiate(Resources.Load("TextNormal", typeof(Text))) as Text;
            txtIds[i].transform.SetParent(parentPanels[0]);
            txtIds[i].transform.localPosition = new Vector2(0, i * -150);
            txtIds[i].text = ids[i];

            //-- names
            txtNames[i] = Instantiate(Resources.Load("TextNormal", typeof(Text))) as Text;
            txtNames[i].transform.SetParent(parentPanels[1]);
            txtNames[i].transform.localPosition = new Vector2(0, i * -150);
            txtNames[i].text = names[i];

            //-- roles
            txtRoles[i] = Instantiate(Resources.Load("TextNormal", typeof(Text))) as Text;
            txtRoles[i].transform.SetParent(parentPanels[2]);
            txtRoles[i].transform.localPosition = new Vector2(0, i * -150);
            txtRoles[i].text = roles[i];

            //-- nicknames
            txtNickNames[i] = Instantiate(Resources.Load("TextNormal", typeof(Text))) as Text;
            txtNickNames[i].transform.SetParent(parentPanels[3]);
            txtNickNames[i].transform.localPosition = new Vector2(0, i * -150);
            txtNickNames[i].text = nickNames[i];
   
        }

        
    }

   
}
