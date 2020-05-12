using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UniRx.Async;

public class CommandManager : MonoBehaviour
{
    private ScenarioManager _scenarioManager;

    [SerializeField]
    private GameObject choiceCards;
    [SerializeField]
    private GameObject choiceCardsLast;
    [SerializeField]
    private GameObject captionText;
    [SerializeField]
    private GameObject textBox;
    [SerializeField]
    private Image backGround;
    [SerializeField]
    private Sprite afternoon;

    private Command _preCommand;

    // Start is called before the first frame update
    void Start()
    {
        _scenarioManager = this.GetComponent<ScenarioManager>();

        choiceCards.SetActive(false);
        choiceCardsLast.SetActive(false);
        captionText.SetActive(false);

        _preCommand = Command.None;
    }

    // Update is called once per frame
    void Update()
    {
        ReadCommand();
    }

    private void ReadCommand()
    {
        var command = _scenarioManager.GetCommand();

        // 次のページに行くまでずっと入り続けてしまうので
        if(command != _preCommand)
        {
            switch (command)
            {
                case Command.Caption:
                    CaptionCommand();
                    break;
                case Command.Choice:
                    ChoiceCommand(choiceCards);
                    break;
                case Command.Last:
                    ChoiceCommand(choiceCardsLast);
                    break;
                case Command.Judge:
                    JudgeEnding();
                    break;
                case Command.End:
                    Ending();
                    break;
                case Command.Change:
                    ChangeBackGround();
                    break;
            }
        }

        _preCommand = command;
    }

    async void CaptionCommand()
    {
        _scenarioManager.isReadable = false;
        captionText.SetActive(true);
        captionText.GetComponent<Text>().text = _scenarioManager.GetText();

        captionText.GetComponent<Animator>().SetTrigger("isPlay");
        await UniTask.Delay(3000);

        captionText.SetActive(false);
        _scenarioManager.isReadable = true;

    }

    async void ChoiceCommand(GameObject cardPrefab)
    {
        _scenarioManager.isReadable = false;
        cardPrefab.SetActive(true);
        textBox.SetActive(false);

        var _choiceCard = cardPrefab.GetComponent<ChoiceCard>();
        _choiceCard.SetChoiceText(_scenarioManager);

        await UniTask.WaitUntilValueChanged(
                target: _choiceCard,
                monitorFunction: x => x.isChoiced);

        _scenarioManager.isReadable = true;
        cardPrefab.SetActive(false);
        textBox.SetActive(true);

        _scenarioManager.SelectChoice(_choiceCard.selectedNum);
    }

    private void Ending()
    {
        _scenarioManager.isReadable = false;
        SceneManager.LoadScene("Title");
    }

    private void JudgeEnding()
    {
        _scenarioManager.JudgeEnd();
    }

    private void ChangeBackGround()
    {
        backGround.sprite = afternoon;
    }
}

