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
    public string[] ids; // variable para los ids
    public string[] names; // variable para la columna de nombres
    public string[] roles; // vaariables para la columna de roles
    public string[] nickNames; // variables para la columna de apodos
    public Text[] txtIds, txtNames, txtRoles, txtNickNames;


    // Start is called before the first frame update
    void Start()
    {
        URL = File.ReadAllText(Application.dataPath + "/StreamingAssets/JsonChallenge.json");

        JObject jo = JObject.Parse(URL);
        Debug.Log("JO: " + jo.Count);

        ids = new string[jo.Count];
        names = new string[jo.Count];
        roles = new string[jo.Count];
        nickNames = new string[jo.Count];

        for (int i = 0; i < jo.Count; i++)
        {
            ids[i] = (string)jo["Data"][i]["ID"].Value<string>();
            names[i] = (string)jo["Data"][i]["Name"].Value<string>();
            roles[i] = (string)jo["Data"][i]["Role"].Value<string>();
            nickNames[i] = (string)jo["Data"][i]["Nickname"].Value<string>();

            Debug.Log("Imprimir: " + ids[i] + " - " + names[i] + " - " + roles[i] + " - " + nickNames[i]);
        }

        
    }

   
}
