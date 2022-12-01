using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogMachine : MonoBehaviour
{
    [Header("»ù´¡ÉèÖÃ")]
    [SerializeField] PlayerInput input;
    [SerializeField] private bool interact;
    [SerializeField] private DialogData dialogData;
    [SerializeField] private float intercharacterTime;
    [SerializeField] Color backColor;
    [SerializeField] Color frontColor;

    private Sprite currentSprite;

    private bool canNext;

    private WaitForSeconds CharTime;

    private void Awake()
    {
        CharTime = new WaitForSeconds(intercharacterTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Player") return;

        if (interact)
        {
            return;
        }
        else
        {
            if (!UIManager.Instance.dialogueUI.activeInHierarchy)
            {
                UIManager.Instance.SetDialogueDisplay(true);

                DisplayStartCharacterSprite();
                UpdateDialogue(0);
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag != "Player") return;

        if (interact && input.Interact && !UIManager.Instance.dialogueUI.activeInHierarchy)
        {
            UIManager.Instance.SetDialogueDisplay(true);

            DisplayStartCharacterSprite();
            UpdateDialogue(0);
        }
    }

    private void Update()
    {
        if (UIManager.Instance.dialogueUI.activeInHierarchy)
        {
            NextDialog();
        }
    }

    private void UpdateDialogue(int index)
    {
        SwitchCharacterName(index);

        StartCoroutine(PopupDisplay(dialogData.dialogBases[index].dialogueContent));

        if (dialogData.multiplyDialog)
        {
            UpdateMultiplyDialogSprite(index);
        }
        else
        {
            UpdateSingleDialogSprite(index);
        }
    }

    private void SwitchCharacterName(int index)
    {
        UIManager.Instance.nameText.text = dialogData.dialogBases[index].characterName;
    }

    private void UpdateMultiplyDialogSprite(int index)
    {
        currentSprite = dialogData.dialogBases[index].dialogSprite;
        if (currentSprite == UIManager.Instance.leftDialoger.sprite)
        {
            UIManager.Instance.leftDialoger.color = frontColor;
            UIManager.Instance.rightDialoger.color = backColor;
        }
        else
        {
            UIManager.Instance.rightDialoger.color = frontColor;
            UIManager.Instance.leftDialoger.color = backColor;
        }
    }

    private void DisplayStartCharacterSprite()
    {
        if (dialogData.multiplyDialog)
        {
            UIManager.Instance.SetSingleCharacter(false);
            UIManager.Instance.leftDialoger.sprite = dialogData.startCharacter;
            UIManager.Instance.rightDialoger.sprite = dialogData.nextCharacter;
        }
        else
        {
            UIManager.Instance.SetSingleCharacter(true);
            UIManager.Instance.centerDialoger.sprite = dialogData.startCharacter;
        }
    }

    private void UpdateSingleDialogSprite(int index)
    {
        UIManager.Instance.centerDialoger.sprite = dialogData.dialogBases[index].dialogSprite;
    }

    private void NextDialog()
    {
        if (canNext && input.MouseLeftClick)
        {
            dialogData.dialogIndex++;
            if (dialogData.dialogIndex >= dialogData.dialogBases.Length)
            {
                UIManager.Instance.SetDialogueDisplay(false);
                dialogData.dialogIndex = 0;
                return;
            }
            UpdateDialogue(dialogData.dialogIndex);
        }
    }

    IEnumerator PopupDisplay(string dialogText)
    {
        canNext = false;
        UIManager.Instance.dialogueText.text = "";

        foreach (char world in dialogText.ToCharArray())
        {
            UIManager.Instance.dialogueText.text += world;
            yield return CharTime;
        }

        canNext = true;
    }
}
