using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[ExecuteAlways]
public class CoordinateLaberer : MonoBehaviour
{
    [SerializeField] Color defaultColor = Color.white;
    [SerializeField] Color blockedColor = Color.yellow;
    TextMeshPro label;
    private Waypoint waypoint;
    Vector2Int coordinates = new Vector2Int();
    
    void Awake()
    {
        label = GetComponent<TextMeshPro>();
        label.enabled = false;
        waypoint = GetComponentInParent<Waypoint>();
        DisplayCoordinates();
    }

    void Update()
    {
        if (!Application.isPlaying)
        {
            DisplayCoordinates();
            UpdateObjectName();
        }
        ColorCoordinates();
        ToggleLabels();
    }

    void DisplayCoordinates()
    {
        coordinates.x = Mathf.RoundToInt(transform.parent.position.x / UnityEditor.EditorSnapSettings.move.x);
        coordinates.y = Mathf.RoundToInt(transform.parent.position.z / UnityEditor.EditorSnapSettings.move.z);
        label.text = coordinates.x + "," + coordinates.y;
    }

    void UpdateObjectName()
    {
        transform.parent.name = coordinates.ToString();
    }

    void ColorCoordinates()
    {
        if (waypoint.IsPlaceable) label.color = defaultColor;
        else label.color = blockedColor;
    }

    void ToggleLabels()
    {
        if (Input.GetKeyDown(KeyCode.C)) label.enabled = !label.IsActive();
    }
}