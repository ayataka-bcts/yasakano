using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx.Async;


public class FadeManager : MonoBehaviour
{
    private ScenarioManager _scenarioManager;

    [SerializeField]
    private GameObject _fadeInPannel;
    [SerializeField]
    private GameObject _fadeOutPannel;
    [SerializeField]
    private GameObject _blackPannel;

    private Fade preFade;

    // Start is called before the first frame update
    void Start()
    {
        _scenarioManager = this.GetComponent<ScenarioManager>();
        _fadeInPannel.SetActive(false);
        _fadeOutPannel.SetActive(false);
        _blackPannel.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        FadeCheck();
    }

    private void FadeCheck()
    {
        var type = _scenarioManager.GetFadeType();

        if(type != Fade.None)
        {
            if(preFade != type)
            {
                OnlyFade(type);
            }
        }

        preFade = type;
    }

    async void OnlyFade(Fade type)
    {
        switch (type)
        {
            case Fade.FadeIn:
                _fadeInPannel.SetActive(true);
                _scenarioManager.isReadable = false;

                await UniTask.Delay(1000);

                _fadeInPannel.SetActive(false);
                _blackPannel.SetActive(true);
                _scenarioManager.isReadable = true;

                break;
            case Fade.FadeOut:
                _blackPannel.SetActive(false);
                _fadeOutPannel.SetActive(true);
                _scenarioManager.isReadable = false;

                await UniTask.Delay(1000);

                _fadeOutPannel.SetActive(false);
                _scenarioManager.isReadable = true;

                break;
        }
    }
}
