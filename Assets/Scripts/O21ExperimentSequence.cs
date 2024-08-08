using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class O21Block
{
    public string[] valueChange;
    public float[] duration;

    public O21Block(string[] valueChangeArray, float[] durationArray)
    {
        valueChange = valueChangeArray;
        duration = durationArray;
    }
}

public static class O21ExperimentSequence
{
    public static string inc = "increase";
    public static string dec = "decrease";
    public static string stat = "static";
    public static int o21Block1Start = 89;

    public static readonly O21Block[] expSeq = {
        new O21Block(new string[]{stat,inc,stat,dec }, new float[]{4f,6f,4f,6f }),
        new O21Block(new string[]{stat }, new float[]{20f }),
        new O21Block(new string[]{inc, stat,dec,stat}, new float[]{6f,4f,6f,4f }),
        new O21Block(new string[]{ dec, stat}, new float[]{4f,16f }),
        new O21Block(new string[]{stat,inc,stat,dec }, new float[]{4f,6f,3f,6f }),
        new O21Block(new string[]{stat }, new float[]{7f }),
        new O21Block(new string[]{inc, stat,dec,stat}, new float[]{6f,2f,6f,3f }),
        new O21Block(new string[]{ dec, stat}, new float[]{4f,13f }),
        new O21Block(new string[]{stat,inc,stat,dec }, new float[]{4f,6f,4f,6f }),
        new O21Block(new string[]{stat }, new float[]{20f }),
        new O21Block(new string[]{inc, stat,dec,stat}, new float[]{6f,4f,6f,4f }),
        new O21Block(new string[]{ dec, stat}, new float[]{4f,16f })
    };
}
