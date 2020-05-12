using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NovelSoundManager : MonoBehaviour
{
    private ScenarioManager _scenarioManager;
    

    // Start is called before the first frame update
    void Start()
    {
        _scenarioManager = this.GetComponent<ScenarioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
