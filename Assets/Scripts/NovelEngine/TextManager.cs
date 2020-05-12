using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    private ScenarioManager _scenarioManager;

    [SerializeField]
    private Text textBox;
    [SerializeField]
    private Text speakerText;

    private bool _isReadable = true;

    // Start is called before the first frame update
    void Start()
    {
        if(!textBox)
        {
            // テキストボックスを探す処理
        }

        _scenarioManager = this.GetComponent<ScenarioManager>();

    }

    // Update is called once per frame
    void Update()
    {
        ShowText();
    }

    private void ShowText()
    {
        // 取ってきたテキスト群からインデック指定で表示する
        textBox.text = _scenarioManager.GetText();

        speakerText.text = _scenarioManager.GetSpeaker();
    }
}
