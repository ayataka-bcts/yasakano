using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UniRx.Async;

public class ImageManager : MonoBehaviour
{
    private ScenarioManager _scenarioManager;

    [SerializeField]
    private Image currentImage;

    [SerializeField]
    private List<Sprite> charaSprites;

    // Start is called before the first frame update
    void Start()
    {
        _scenarioManager = this.GetComponent<ScenarioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        ShowImage();
    }

    private async void ShowImage()
    {
        string imageName = _scenarioManager.GetImage();
        
        if(currentImage.name != imageName)
        {
            currentImage.gameObject.GetComponent<Animator>().SetTrigger("isShow");
            // 一致するものに変更
            Sprite img = charaSprites.FirstOrDefault(x => x.name == imageName);
            if(img)
            {
                //currentImage.gameObject.GetComponent<Animator>().SetTrigger("isChange");
                //await UniTask.Delay(100);
                currentImage.sprite = img;
                //currentImage.gameObject.GetComponent<Animator>().SetTrigger("isReset");
            }
            
        }
    }
}
