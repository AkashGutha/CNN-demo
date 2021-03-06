﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MaterialBuilder
{
    public static Material[] GetMaterials()
    {
        Material[] mats = new Material[50];

        // get the strings and make materials for each state
        var states = StatesService.states_names;
        var abbs = StatesService.states_abbrevation;

        for (int i = 0; i < states.Length; i++)
        {
            var mat = new Material(Shader.Find("Standard Outlined"));
            mat.name = "MT_" + abbs[i] + "_" + states[i];
            AssetDatabase.CreateAsset(mat, "Assets/Materials/States/" + mat.name + ".mat");
        }
        return mats;
    }
}
