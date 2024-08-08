using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class hrBehavior : MonoBehaviour
{
    private Animator anim;
    private float elapsedTime = 0f;
    public TextMeshProUGUI textHr;
    Block[] testArray;
    int currentBlockIndex = 0;
    int currentValueIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        testArray = ExperimentSequenceSingleton.expSeq;
        textHr.enabled = false;
        //StartCoroutine(PlayAnimations());
    }

    // Update is called once per frame
    void Update()
    {
        // Check if there are blocks left
        if (currentBlockIndex < testArray.Length)
        {
            Block item = testArray[currentBlockIndex];
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
                anim.Play("hrHighToVeryHigh");
            }
            else if (item.valueChange[currentValueIndex].Contains("decrease"))
            {
                anim.Play("hrNormalToLow");
            }
            else if (item.valueChange[currentValueIndex].Contains("static"))
            {
                anim.Play("justMove");
            }

            // Update the HR value text
            textHr.text = item.valueChange[currentValueIndex] + "\ndur: " + duration.ToString();

            // Increment elapsed time
            elapsedTime += Time.deltaTime;
        }

        // Reset animation speed
        anim.speed = 1.0f;
    }

    IEnumerator PlayAnimations()
    {
        Block[] testArray = ExperimentSequenceSingleton.expSeq;
        foreach (Block item in testArray)
        {
            for (int i = 0; i < item.valueChange.Length; i++)
            {
                float elapsedTime = 0f;
                float duration = item.duration[i];

                while (elapsedTime < duration)
                {
                    anim.speed = 0.3f;
                    elapsedTime += Time.deltaTime;
                    textHr.text = item.valueChange[i] + "\ndur: " +
                        duration.ToString();

                    // Play different animations based on conditions
                    if (item.valueChange[i].Contains("increase"))
                    {
                        anim.Play("hrHighToVeryHigh");
                    }
                    else if (item.valueChange[i].Contains("decrease"))
                    {
                        anim.Play("hrNormalToLow");
                    }
                    else if (item.valueChange[i].Contains("static"))
                    {
                        anim.Play("justMove");
                    }

                    yield return null; // Wait for the next frame
                }

                // Reset animation speed
                anim.speed = 1f;
            }
        }
    }
    /*void Update()
    {
        Block[] testArray = ExperimentSequenceSingleton.expSeq;
        
        foreach (Block item in testArray)
        {
            elapsedTime = 0f;
            for (int i = 0; i < item.valueChange.Length; i++)
            {
                Debug.Log("val: dur " + item.valueChange[i] + " "+ item.duration[i]);
                while (elapsedTime < item.duration[i])
                {
                    anim.speed = 0.3f;
                    elapsedTime = elapsedTime + Time.deltaTime;
                    textHr.text = item.valueChange[i] + " \nd" +
                        item.duration[i].ToString()+"\nel"+elapsedTime.ToString();

                    if (item.valueChange[i].Contains("increase"))
                    {
                        anim.Play("hrNormalToHigh");
                    }
                    else if (item.valueChange[i].Contains("decrease"))
                    {
                        anim.Play("hrNormalToLow");
                    }
                    else if (item.valueChange[i].Contains("static"))
                    {
                        anim.Play("justMove");
                    }
                }
               
                elapsedTime = 0f;

             

            }
            
        }
    }*/
}
