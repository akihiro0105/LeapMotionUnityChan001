using UnityEngine;
using System.Collections;
using System.IO;
using System.Text;

public class Stage_Control : MonoBehaviour {

    public GameObject StartBlock;
    public GameObject GoalBlock;
    public GameObject NormalBlock;
    public GameObject ExtraBlock1;//隠れたブロック
    public GameObject ExtraBlock2;//ぶつからないブロック
    public GameObject ExtraBlock3;//重い
    public GameObject ExtraBlock4;//軽い
    public GameObject ExtraBlock5;//動く
    public GameObject ExtraBlock6;//アウト

    private float up = 7.5f;
	// Use this for initialization
	void Start () {
        string line = "";
        ArrayList al = new ArrayList();
        //TextAsset text = Resources.Load("Stage/Stage00") as TextAsset;
        //StringReader sr = new StringReader(text.text);
        FileInfo fi = new FileInfo(Application.dataPath + "/" + "Stage/Stage00.txt");
        StreamReader sr = new StreamReader(fi.OpenRead(), Encoding.UTF8);
        while ((line = sr.ReadLine()) != null)
        {
            al.Add(line);
        }
        int row = 0;
        for (int i = 0; i < al.Count; i++)
        {
            string[] st = al[i].ToString().Split(',');
            if (st[0].IndexOf("//") >= 0)
            {

            }
            else
            {
                int j = 0;
                foreach (string item in st)
                {
                    int b = int.Parse(item);
                    Vector3 v;
                    v.x = j;
                    v.y = up - row;
                    v.z = 0;
                    switch (b)
                    {
                        case 1:
                            Instantiate(StartBlock, v, Quaternion.identity);
                            break;
                        case 2:
                            Instantiate(GoalBlock, v, Quaternion.identity);
                            break;
                        case 3:
                            Instantiate(NormalBlock, v, Quaternion.identity);
                            break;
                        case 4:
                            Instantiate(ExtraBlock1, v, Quaternion.identity);
                            break;
                        case 5:
                            Instantiate(ExtraBlock2, v, Quaternion.identity);
                            break;
                        case 6:
                            Instantiate(ExtraBlock3, v, Quaternion.identity);
                            break;
                        case 7:
                            Instantiate(ExtraBlock4, v, Quaternion.identity);
                            break;
                        case 8:
                            Instantiate(ExtraBlock5, v, Quaternion.identity);
                            break;
                        case 9:
                            Instantiate(ExtraBlock6, v, Quaternion.identity);
                            break;
                        default:
                            break;
                    }
                    j++;
                }
                row++;
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
