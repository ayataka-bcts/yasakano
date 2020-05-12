using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UniRx.Async;

public class LoadSceneManager : SingletonMonoBehaviour<LoadSceneManager>
{
    private GameObject _fadeInPannle;
    private GameObject _fadeOutPannle;

    int count = 0;

    private bool _isInitFinish = false;
    public bool isInitFinish { get { return _isInitFinish; } }

    public enum SceneName
    {
        main,
    }

    // Start is called before the first frame update
    void Start()
    {
        InitScene();
        count = 0;
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            count++;
            if (count == 2)
            {
                SoundManager.Instance.PlaySe("start");
                LoadScene();
            }
        }
    }

    private async void InitScene()
    {
        _fadeInPannle = GameObject.FindGameObjectWithTag("FadeIn");
        _fadeInPannle.SetActive(false);
        _fadeOutPannle = GameObject.FindGameObjectWithTag("FadeOut");
        _fadeOutPannle.SetActive(true);

        SoundManager.Instance.PlayBgm("lofi");

        await UniTask.Delay(1000);

        _fadeOutPannle.SetActive(false);
        _isInitFinish = true;
    }

    /// <summary>
    /// シーンをロードする
    /// </summary>
    /// <param name="name">シーン名</param>
    /// <param name="type">フェードイン、フェードアウトの指定</param>
    /// <param name="time">シーン遷移に要する時間[s]</param>
    public async void LoadScene()
    {
        _fadeInPannle.SetActive(true);

        await UniTask.Delay(1000);

        SceneManager.LoadScene("main");
    }
}
