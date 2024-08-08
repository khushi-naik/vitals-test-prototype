using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bp1Block
{
    public string[] valueChange;
    public float[] duration;

    public Bp1Block(string[] valueChangeArray, float[] durationArray)
    {
        valueChange = valueChangeArray;
        duration = durationArray;
    }
}

public class Bp1ExperimentSequence
{
    // Start is called before the first frame update
    public static string inc = "increase";
    public static string dec = "decrease";
    public static string stat = "static";
    private string bp1NormalToHigh = "normalToHigh";
    private string bp1HighToVeryHigh = "highToVeryHigh";
    private string bp1NormalToLow = "normalToLow";
    private string bp1LowToVeryLow = "lowToVeryLow";
    public static int bp1Block1Start = 75;

    public static readonly Bp1Block[] expSeq = {
        new Bp1Block(new string[]{stat,inc,stat,dec }, new float[]{4f,6f,4f,6f }),
        new Bp1Block(new string[]{stat }, new float[]{20f }),
        new Bp1Block(new string[]{inc, stat,dec,stat}, new float[]{6f,4f,6f,4f }),
        new Bp1Block(new string[]{ dec, stat}, new float[]{4f,16f }),
        new Bp1Block(new string[]{stat,inc,stat,dec }, new float[]{4f,6f,3f,6f }),
        new Bp1Block(new string[]{stat }, new float[]{7f }),
        new Bp1Block(new string[]{inc, stat,dec,stat}, new float[]{6f,2f,6f,3f }),
        new Bp1Block(new string[]{ dec, stat}, new float[]{4f,13f }),
        new Bp1Block(new string[]{stat,inc,stat,dec }, new float[]{4f,6f,4f,6f }),
        new Bp1Block(new string[]{stat }, new float[]{20f }),
        new Bp1Block(new string[]{inc, stat,dec,stat}, new float[]{6f,4f,6f,4f }),
        new Bp1Block(new string[]{ dec, stat}, new float[]{4f,16f })
    };
}
