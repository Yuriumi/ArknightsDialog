using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/DialogData", fileName = "DialogData")]
public class DialogData : ScriptableObject
{
    public Sprite startCharacter;
    public Sprite nextCharacter;
    public bool multiplyDialog;
    public DialogBase[] dialogBases;
    public int dialogIndex;
}
