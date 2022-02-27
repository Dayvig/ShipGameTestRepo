using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Model_Narrative : MonoBehaviour
{
    public Image[] portraits;
    public Text dialogueDisplay;

    public int[] portraitSequence;
    public string[] dialogue;
    public float[] intervals;
    public string[] options;

    public Text[] optionDisplay;
    public Image selector;
    public int selectorOptionActive;
    public List<int> optionsSelected = new List<int>();

    public float textInterval = .04f;
}
