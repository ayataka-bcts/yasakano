using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenarioSound : MonoBehaviour
{
    private ScenarioManager _scenarioManager;

    private string preSE;

    // Start is called before the first frame update
    void Start()
    {
        _scenarioManager = this.GetComponent<ScenarioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        ManageSound();
    }

    private void ManageSound()
    {
        string se = _scenarioManager.GetSE();
        string bgm = _scenarioManager.GetBGM();

        if (se != "" && preSE != se)
        {
            SoundManager.Instance.PlaySe(se);
        }

        if (bgm != "")
        {
            if (bgm == "Stop")
            {
                SoundManager.Instance.StopBgm();
            }
            else
            {
                SoundManager.Instance.PlayBgm(bgm);
            }
        }

        preSE = se;
    }
}
