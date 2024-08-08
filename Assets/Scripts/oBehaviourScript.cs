using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class oBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator anim;
    private float elapsedTime = 0f;
    public TextMeshProUGUI textO2;
    private float updateTime = 2f;
    private float elapsedTimeNumber = 0f;
    O21Block[] testArray;
    int currentBlockIndex = 0;
    int currentValueIndex = 0;
    void Start()
    {
        anim = GetComponent<Animator>();
        testArray = O21ExperimentSequence.expSeq;
        textO2.enabled = false;
        //StartCoroutine(PlayAnimations());

    }

    private void Update()
    {
        if (currentBlockIndex < testArray.Length)
        {
            O21Block item = testArray[currentBlockIndex];
            float duration = item.duration[currentValueIndex];

            // Check if the current value change has finished
            if (elapsedTime >= duration)
            {
                // Move to the next value change
                currentValueIndex++;
                elapsedTime = 0.0f;

                // Check if all value changes in the current block have finished
                if (currentValueIndex >= item.valueChange.Length)
                {
                    // Move to the next block
                    currentBlockIndex++;
                    currentValueIndex = 0;
                }
            }

            // Play different animations based on conditions
            if (item.valueChange[currentValueIndex].Contains("increase"))
            {
                if (elapsedTimeNumber >= updateTime)
                {
                    O21ExperimentSequence.o21Block1Start++;
                    elapsedTimeNumber = 0.0f;
                }
                anim.Play("o2ReturnLowToNormal");
            }
            else if (item.valueChange[currentValueIndex].Contains("decrease"))
            {
                if (elapsedTimeNumber >= updateTime)
                {
                    O21ExperimentSequence.o21Block1Start--;
                    elapsedTimeNumber = 0.0f;
                }
                anim.Play("o2NormalToLow");
            }
            else if (item.valueChange[currentValueIndex].Contains("static"))
            {
                anim.Play("justMoveO");
            }

            // Update the O2 value text
            textO2.text = "o2: " + O21ExperimentSequence.o21Block1Start.ToString();

            // Increment elapsed time
            elapsedTime += Time.deltaTime;
            elapsedTimeNumber += Time.deltaTime;
        }

        // Reset animation speed
        anim.speed = 1.0f;
    }
    IEnumerator PlayAnimations()
    {
         
        //int numStart = O21ExperimentSequence.o21Block1Start;
        foreach (O21Block item in testArray)
        {
            for (int i = 0; i < item.valueChange.Length; i++)
            {
                float elapsedTime = 0f;
                float elapsedTimeNumber = 0f;
                float duration = item.duration[i];

                while (elapsedTime < duration)
                {
                    anim.speed = 0.3f;
                    elapsedTime += Time.deltaTime;
                    elapsedTimeNumber += Time.deltaTime;
                    //textO2.text = item.valueChange[i] + "\ndur: " +
                    //  duration.ToString() + "\nelapsed: " + elapsedTime.ToString();

                    // Play different animations based on conditions
                    if (item.valueChange[i].Contains("increase"))
                    {
                        if (elapsedTimeNumber >= updateTime)
                        {
                            //numStart++;
                            O21ExperimentSequence.o21Block1Start++;
                            elapsedTimeNumber = 0f;
                        }
                        anim.Play("o2ReturnLowToNormal");
                    }
                    else if (item.valueChange[i].Contains("decrease"))
                    {
                        if (elapsedTimeNumber >= updateTime)
                        {
                            //numStart--;
                            O21ExperimentSequence.o21Block1Start--;
                            elapsedTimeNumber = 0f;
                        }
                        anim.Play("o2NormalToLow");
                    }
                    else if (item.valueChange[i].Contains("static"))
                    {
                        anim.Play("justMoveO");
                    }
                    //textO2.text = "O2: " + numStart;
                    textO2.text = "o2: " + O21ExperimentSequence.o21Block1Start.ToString();
                    yield return null; // Wait for the next frame
                }

                // Reset animation speed
                anim.speed = 1f;
            }
        }
    }
}
