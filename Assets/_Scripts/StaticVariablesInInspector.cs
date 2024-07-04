using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(GameManager))]
public class StaticVariablesInInspector : Editor
{
    public static int totalResidents;
    public static float averageHappinessIndex;

    public static int totalApartments_50cap;
    public static int totalApartments_30cap;
    public static int totalApartments_5cap;

    public static int totalApartments;
    public static int totalApartmentCapacity;

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        // Access and display static members
        EditorGUILayout.LabelField("Total Residents", "--> " + GameManager.totalResidents.ToString());
        EditorGUILayout.LabelField("Average Happiness Index", "--> " + GameManager.averageHappinessIndex.ToString());


        EditorGUILayout.LabelField("", "----");
        EditorGUILayout.LabelField("TotalApartments_50cap", "--> " + GameManager.totalApartments_50cap.ToString());
        EditorGUILayout.LabelField("TotalApartments_30cap", "--> " + GameManager.totalApartments_30cap.ToString());
        EditorGUILayout.LabelField("TotalApartments_5cap", "--> " + GameManager.totalApartments_5cap.ToString());

        EditorGUILayout.LabelField("", "----");
        EditorGUILayout.LabelField("TotalApartments", "--> " + GameManager.totalApartments.ToString());
        EditorGUILayout.LabelField("TotalApartmentCapacity", "--> " + GameManager.totalApartmentCapacity.ToString());

    }
}
