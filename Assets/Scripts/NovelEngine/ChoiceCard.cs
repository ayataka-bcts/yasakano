using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChoiceCard : MonoBehaviour
{
    [SerializeField]
    private Text[] choiceCards;

    private bool _isChoiced = false;
    public bool isChoiced { get { return _isChoiced; } }

    private int _selectedNum = 0;
    public int selectedNum { get { return _selectedNum; } }

    void OnEnable()
    {
        _isChoiced = false;
    }

    public void OnChoice(int num)
    {
        _isChoiced = true;

        _selectedNum = num;

        SoundManager.Instance.PlaySe("choice_select");
    }

    public void SetChoiceText(ScenarioManager scenarioMng)
    {
        for(int i = 0; i < choiceCards.Length; i++)
        {
            choiceCards[i].text = scenarioMng.GetChoiceText(i);
        }
    }
}
