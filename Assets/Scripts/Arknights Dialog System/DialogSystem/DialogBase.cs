using UnityEngine;

[System.Serializable]
public class DialogBase
{
    public string characterName;
    public Sprite dialogSprite;
    [TextArea(1,3)]public string dialogueContent;
}
