using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScenarioManager : MonoBehaviour
{
    public oneweek scenarios;
    public choice choice;

    private int _pageIndex = 0;
    private int _choiceIndex = 0;

    private bool _isReadable = true;
    public bool isReadable { set { _isReadable = value; } }

    private int endingPoint = 0;

    private TextManager _textManager;
    private ImageManager _imageManager;

    // Start is called before the first frame update
    void Start()
    {
        _textManager = this.GetComponent<TextManager>();
        _imageManager = this.GetComponent<ImageManager>();

        _pageIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // シナリオを読んでいる状態
        if(_isReadable)
        {
            // 指を離したときに次のテキストにいくとうれしい気がする
            if (Input.GetMouseButtonUp(0))
            {
                SoundManager.Instance.volume.se = 0.5f;
                SoundManager.Instance.PlaySe("read");
                SoundManager.Instance.volume.se = 1.0f;


                if(scenarios.main[_pageIndex].jumpId != 0)
                {
                    JumpId(scenarios.main[_pageIndex].jumpId);
                }
                else
                {
                    NextId();
                }
            }
        }
        // 選択肢を選んでいる状態
        else
        {

        }

        Debug.Log(endingPoint);
    }

    public void NextId()
    {
        _pageIndex++;
    }

    public void JumpId(int id)
    {
        _pageIndex = id;
    }

    public string GetText()
    {
        return scenarios.main[_pageIndex].text;
    }

    public string GetSpeaker()
    {
        return scenarios.main[_pageIndex].speaker;
    }

    public string GetBGM()
    {
        return scenarios.main[_pageIndex].bgm;
    }

    public string GetSE()
    {
        return scenarios.main[_pageIndex].se;
    }

    public string GetItem()
    {
        return scenarios.main[_pageIndex].item.ToString();
    }

    public string GetImage()
    {
        return scenarios.main[_pageIndex].image;
    }

    public Command GetCommand()
    {
        return scenarios.main[_pageIndex].command;
    }

    public Fade GetFadeType()
    {
        return scenarios.main[_pageIndex].fade;
    }

    public string GetChoiceText(int num)
    {
        int index = 0;
        switch (num)
        {
            case 0:
                index = scenarios.main[_pageIndex].choice_1;
                return scenarios.main[index].text;
            case 1:
                index = scenarios.main[_pageIndex].choice_2;
                return scenarios.main[index].text;
            case 2:
                index = scenarios.main[_pageIndex].choice_3;
                return scenarios.main[index].text;
            case 3:
                index = scenarios.main[_pageIndex].choice_4;
                return scenarios.main[index].text;
            case 4:
                index = scenarios.main[_pageIndex].choice_5;
                return scenarios.main[index].text;
            default:
                return "";
        }
    }

    public void SelectChoice(int num)
    {
        int index = 0;
        switch (num)
        {
            case 0:
                index = scenarios.main[_pageIndex].choice_1;
                endingPoint += choice.Sheet1[_choiceIndex].choice_1;
                break;
            case 1:
                index = scenarios.main[_pageIndex].choice_2;
                endingPoint += choice.Sheet1[_choiceIndex].choice_2;
                break;
            case 2:
                index = scenarios.main[_pageIndex].choice_3;
                endingPoint += choice.Sheet1[_choiceIndex].choice_3;
                break;
            case 3:
                index = scenarios.main[_pageIndex].choice_4;
                endingPoint += choice.Sheet1[_choiceIndex].choice_4;
                break;
            case 4:
                index = scenarios.main[_pageIndex].choice_5;
                endingPoint += choice.Sheet1[_choiceIndex].choice_5;
                break;
            default:
                break;
        }

        _choiceIndex++;
        JumpId(index);
    }

    public void JudgeEnd()
    {
        int index = -1;

        if(_choiceIndex > choice.Sheet1.Count - 1)
        {
            _choiceIndex = choice.Sheet1.Count - 1;
        }

        int bad = choice.Sheet1[_choiceIndex].choice_1;
        int normal = choice.Sheet1[_choiceIndex].choice_2;
        int good = choice.Sheet1[_choiceIndex].choice_3;

        if(endingPoint <= bad)
        {
            index = scenarios.main[_pageIndex].choice_3;
        }
        else if(bad < endingPoint && endingPoint <= normal)
        {
            index = scenarios.main[_pageIndex].choice_2;
        }
        else if(normal < endingPoint)
        {
            index = scenarios.main[_pageIndex].choice_1;
        }

        JumpId(index);
    }
    
}
