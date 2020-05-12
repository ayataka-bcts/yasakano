using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class CSVTest : MonoBehaviour
{
    private TextAsset _csvFile;
    private List<string[]> scenarios = new List<string[]>();

    // Start is called before the first frame update
    void Start()
    {
        _csvFile = Resources.Load("Scenario/csv_test") as TextAsset;
        StringReader reader = new StringReader(_csvFile.text);

        // , で分割しつつ一行ずつ読み込み
        // リストに追加していく
        while (reader.Peek() != -1) // reader.Peaekが-1になるまで
        {
            string line = reader.ReadLine(); // 一行ずつ読み込み
            scenarios.Add(line.Split(',')); // , 区切りでリストに追加
        }

        // csvDatas[行][列]を指定して値を自由に取り出せる
        Debug.Log(scenarios[1][1]);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
