using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class bpBehavior : MonoBehaviour
{
    private Animator anim;
    private float elapsedTime = 0f;
    public TextMeshProUGUI textBp;
    private float updateTime = 1f;
    private float elapsedTimeNumber = 0f;
    Bp1Block[] testArray;
    int currentBlockIndex = 0;
    int currentValueIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        testArray = Bp1ExperimentSequence.expSeq;
        textBp.enabled = false;
        //StartCoroutine(PlayAnimations());
    }

    void Update()
    {
        // Check if there are blocks left
        if (currentBlockIndex < testArray.Length)
        {
            Bp1Block item = testArray[currentBlockIndex];
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
                    Bp1ExperimentSequence.bp1Block1Start++;
                    elapsedTimeNumber = 0.0f;
                }
                anim.Play("veryHighAnim");
            }
            else if (item.valueChange[currentValueIndex].Contains("decrease"))
            {
                if (elapsedTimeNumber >= updateTime)
                {
                    Bp1ExperimentSequence.bp1Block1Start--;
                    elapsedTimeNumber = 0.0f;
                }
                anim.Play("highAnim");
            }
            else if (item.valueChange[currentValueIndex].Contains("static"))
            {
                anim.Play("justMoveBp");
            }

            // Update the BP value text
            textBp.text = "bp: " + Bp1ExperimentSequence.bp1Block1Start.ToString();

            // Increment elapsed time
            elapsedTime += Time.deltaTime;
            elapsedTimeNumber += Time.deltaTime;
        }

        // Reset animation speed
        anim.speed = 1.0f;
    }

    IEnumerator PlayAnimations()
    {
        Bp1Block[] testArray = Bp1ExperimentSequence.expSeq;
        //int numStart = Bp1ExperimentSequence.bp1Block1Start;

        foreach (Bp1Block item in testArray)
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
                    //textBp.text = item.valueChange[i] + "\ndur: " +
                    //duration.ToString() + "\nelapsed: " + elapsedTime.ToString();

                    // Play different animations based on conditions
                    if (item.valueChange[i].Contains("increase"))
                    {
                        if (elapsedTimeNumber >= updateTime)
                        {
                            //numStart++;
                            Bp1ExperimentSequence.bp1Block1Start++;
                            elapsedTimeNumber = 0f;
                        }
                        anim.Play("veryHighAnim");
                    }
                    else if (item.valueChange[i].Contains("decrease"))
                    {
                        if (elapsedTimeNumber >= updateTime)
                        {
                            //numStart--;
                            Bp1ExperimentSequence.bp1Block1Start--;
                            elapsedTimeNumber = 0f;
                        }
                        
                        anim.Play("highAnim");
                    }
                    else if (item.valueChange[i].Contains("static"))
                    {
                        anim.Play("justMoveBp");
                    }
                    //textBp.text = "BP: " + numStart;
                    textBp.text = "bp: " + Bp1ExperimentSequence.bp1Block1Start.ToString();
                    yield return null; // Wait for the next frame
                }

                // Reset animation speed
                anim.speed = 1f;
            }
        }
    }
}
