using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class StroyEntity
{
    public int id;
    public string speaker;
    public string text;
    public string bgm;
    public string se;
    public string image;
    public string item;
    public int jumpId;
    public Fade fade;
    public Command command;
    public int choice_1;
    public int choice_2;
    public int choice_3;
    public int choice_4;
    public int choice_5;
}

public enum Command
{
    None,
    Choice,
    Last,
    Judge,
    End,
    Caption,
    Change,
}

public enum Fade
{
    None,
    FadeIn,
    FadeOut,
}
