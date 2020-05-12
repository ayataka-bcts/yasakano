using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx.Async;
using System.Linq;

public class AssetManager : MonoBehaviour
{
    private ScenarioManager _scenarioManager;

    [SerializeField]
    private GameObject currentItem;

    [SerializeField]
    private GameObject textBox;
    [SerializeField]
    private GameObject chara;
    [SerializeField]
    private Transform assetCharaPos;

    [SerializeField]
    private List<Sprite> assetSprites;


    // Start is called before the first frame update
    void Start()
    {
        _scenarioManager = this.GetComponent<ScenarioManager>();

        currentItem.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        string itemName = _scenarioManager.GetItem();

        if (itemName != "")
        {
            ShowItem(itemName);
        }
        else
        {
            currentItem.SetActive(false);
            var pos = chara.transform.position;
            pos.x = 0.0f;
            chara.transform.position = pos;
        }
    }

    private void ShowItem(string itemName)
    {
        currentItem.SetActive(true);

        chara.transform.position = assetCharaPos.position;

        Sprite img = assetSprites.FirstOrDefault(x => x.name == itemName);
        if (img)
        {
            currentItem.GetComponent<Image>().sprite = img;
        }

    }
}
