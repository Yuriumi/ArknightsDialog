using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : SingleMono<UIManager>
{
    [Header("∂‘ª∞UI…Ë÷√")]
    public GameObject dialogueUI;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    public Image leftDialoger;
    public Image centerDialoger;
    public Image rightDialoger;
    [SerializeField] Image left;
    [SerializeField] Image center;
    [SerializeField] Image right;

    public void SetDialogueDisplay(bool canDisplay)
    {
        dialogueUI.SetActive(canDisplay);
    }

    public void SetDialogueCharacterName(string name)
    {
        nameText.text = name;
    }

    public void SetSingleCharacter(bool canDisplay)
    {
        leftDialoger.enabled = !canDisplay;
        rightDialoger.enabled = !canDisplay;
        centerDialoger.enabled = canDisplay;
    }
}
