using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class VisualNovel : MonoBehaviour
{
    public List<string> introTextLines;
    public List<string> oneTextLines;
    public List<string> twoTextLines;
    public List<string> threeTextLines;
    public List<string> fourTextLines;
    string displayText = "";
    string refText = "";
    float charTime = 0;
    public float charSpeed = 1;
    int numChar;

    public bool isChoice = true;

    bool choosing = false;
    bool typing = true;

    int choice = 0;

    int index = 0;
    int index2 = -1;

    public bool complete = false;

    GameData data;

    [Header("Portraits")]
    public Texture playerTex;
    public Texture CharacterTex;

    TMP_Text text;
    GameObject textBox;
    Slider stressBar;
    GameObject playerPortrait;
    GameObject characterPortrait;
    GameObject buttons;
    // Start is called before the first frame update
    void Start()
    {
        text = GameObject.FindGameObjectWithTag("Text").GetComponent<TMP_Text>();
        textBox = text.gameObject.transform.parent.gameObject;
        stressBar = GameObject.FindGameObjectWithTag("StressBar").GetComponent<Slider>();
        playerPortrait = GameObject.FindGameObjectWithTag("PlayerPortrait");
        if(playerTex != null)
        {
            playerPortrait.GetComponent<RawImage>().texture = playerTex;
        }
        characterPortrait = GameObject.FindGameObjectWithTag("CharacterPortrait");
        if (CharacterTex != null)
        {
            characterPortrait.GetComponent<RawImage>().texture = CharacterTex;
        }
        buttons = GameObject.FindGameObjectWithTag("Buttons");
        refText = introTextLines[index];
        //text.text = introTextLines[index];
        buttons.SetActive(false);
        data = GameObject.FindGameObjectWithTag("Data").GetComponent<DataManager>().data;
    }

    // Update is called once per frame
    void Update()
    {
        charTime += Time.deltaTime * charSpeed;
        text.text = displayText;

        if(charTime >= 1f && typing == true)
        {
            numChar++;
            charTime = 0;

            if (numChar > refText.Length)
            {
                numChar = 0;
                typing = false;
            }
            else
            {
                displayText = "";
                for (int i = 0; i < numChar; i++)
                {
                    displayText += refText[i];
                }
            }
        }

        if (Input.GetMouseButtonDown(0) && !choosing && !typing)
        {
            index++;
            typing = true;
            if (index < introTextLines.Count)
            {
                refText = introTextLines[index];
                //text.text = introTextLines[index];
            }
            else
            {
                index2++;
                if (isChoice && choice == 0)
                {
                    choosing = true;
                    textBox.SetActive(false);
                    buttons.SetActive(true);
                }
                else
                {
                    switch (choice)
                    {
                        case 1:
                            if(index2 < oneTextLines.Count)
                            {
                                refText = oneTextLines[index2];
                                //text.text = oneTextLines[index2];
                            }
                            else
                            {
                                complete = true;
                                text.text = "";
                            }

                            break;
                        case 2:
                            if (index2 < twoTextLines.Count)
                            {
                                refText = twoTextLines[index2];
                                //text.text = twoTextLines[index2];
                            }
                            else
                            {
                                complete = true;
                                text.text = "";
                            }
                            
                            break;
                        case 3:
                            if (index2 < threeTextLines.Count)
                            {
                                refText = threeTextLines[index2];
                                //text.text = threeTextLines[index2];
                            }
                            else
                            {
                                complete = true;
                                text.text = "";
                            }
                            
                            break;
                        case 4:
                            if (index2 < fourTextLines.Count)
                            {
                                refText = fourTextLines[index2];
                                //text.text = fourTextLines[index2];
                            }
                            else
                            {
                                complete = true;
                                text.text = "";
                            }
                            
                            break;
                        default:
                            break;
                    }
                }
            }
        }
        else if(choosing)
        {
            if(choice != 0)
            {
                choosing = false;
                textBox.SetActive(true);
                buttons.SetActive(false);
                
                displayText = "";
                switch (choice)
                {
                    case 1:
                        refText = oneTextLines[index2];
                        //text.text = oneTextLines[index2];
                        break;
                    case 2:
                        refText = twoTextLines[index2];
                        //text.text = twoTextLines[index2];
                        break;
                    case 3:
                        refText = threeTextLines[index2];
                        //text.text = threeTextLines[index2];
                        break;
                    case 4:
                        refText = fourTextLines[index2];
                        //text.text = fourTextLines[index2];
                        break;
                    default:
                        break;
                }
            }
        }
        else if(Input.GetMouseButtonDown(0) && typing)
        {
            numChar = refText.Length-1;
        }



    }


    public void ButtonOne()
    {
        choice = 1;
        numChar = 0;
        typing = true;
    }
    public void ButtonTwo()
    {
        choice = 2;
        numChar = 0;
        typing = true;
    }
    public void ButtonThree()
    {
        choice = 3;
        numChar = 0;
        typing = true;
    }
    public void ButtonFour()
    {
        choice = 4;
        numChar = 0;
        typing = true;
    }
}
