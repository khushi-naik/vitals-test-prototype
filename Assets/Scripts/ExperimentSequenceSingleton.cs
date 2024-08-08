using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block
{
    public string[] valueChange;
    public float[] duration;

    public Block(string[] valueChangeArray, float[] durationArray)
    {
        valueChange = valueChangeArray;
        duration = durationArray;
    }
}
public static class ExperimentSequenceSingleton
{
    public static string inc = "increase";
    public static string dec = "decrease";
    public static string stat = "static";

    public static readonly Block[] expSeq = {
        new Block(new string[]{stat,inc,stat,dec }, new float[]{4f,6f,4f,6f }),
        new Block(new string[]{stat }, new float[]{20f }),
        new Block(new string[]{inc, stat,dec,stat}, new float[]{6f,4f,6f,4f }),
        new Block(new string[]{ dec, stat}, new float[]{4f,16f }),
        new Block(new string[]{stat,inc,stat,dec }, new float[]{4f,6f,3f,6f }),
        new Block(new string[]{stat }, new float[]{7f }),
        new Block(new string[]{inc, stat,dec,stat}, new float[]{6f,2f,6f,3f }),
        new Block(new string[]{ dec, stat}, new float[]{4f,13f }),
        new Block(new string[]{stat,inc,stat,dec }, new float[]{4f,6f,4f,6f }),
        new Block(new string[]{stat }, new float[]{20f }),
        new Block(new string[]{inc, stat,dec,stat}, new float[]{6f,4f,6f,4f }),
        new Block(new string[]{ dec, stat}, new float[]{4f,16f })
    };
}
