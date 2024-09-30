using UnityEngine;
using System.IO;
using Unity.VisualScripting;
using System.Runtime.Remoting.Messaging;
public class DataHandler : MonoBehaviour
{

    private const string SAVE_SEPARATOR = ";";
    [HideInInspector]
    public float moveSp;
    [HideInInspector]
    public float strength;
    [HideInInspector]
    public float inCome;
    [HideInInspector]
    public float dollar;
    [HideInInspector]
    public int moveSpLv;
    [HideInInspector]
    public int strengthLv;
    [HideInInspector]
    public int inComeLv;
    [HideInInspector]
    public int mapLv;

    private void Awake()
    {

    }

    public void Save()
    {
        string[] contents = new string[] {
            "" + moveSp,
            "" + strength,
            "" + inCome,
            "" + moveSpLv,
            "" + strengthLv,
            "" + inComeLv,
            "" + dollar,
            "" + mapLv
        };
        string saveString = string.Join(SAVE_SEPARATOR, contents);
        File.WriteAllText(Application.dataPath + "/save.txt", saveString);
        Debug.Log(saveString);
    }

    public void Load()
    {
        // Load
        if (File.Exists(Application.dataPath + "/save.txt"))
        {
            string saveString = File.ReadAllText(Application.dataPath + "/save.txt");

            string[] contents = saveString.Split(new[] { SAVE_SEPARATOR }, System.StringSplitOptions.None);

            moveSp = float.Parse(contents[0]);
            strength = float.Parse(contents[1]);
            inCome = float.Parse(contents[2]);
            moveSpLv = int.Parse(contents[3]);
            strengthLv = int.Parse(contents[4]);
            inComeLv = int.Parse(contents[5]);
            dollar = float.Parse(contents[6]);
            mapLv = int.Parse(contents[7]);
        }
    }

}

