using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using static System.String;

public class Sorting : MonoBehaviour
{
    public List<string> names = new List<string>
    {
        "Maddison Albert",
        "Hester Blankenship",
        "Saara Browne",
        "Libbie Case",
        "Dominick Howells",
        "Abida Hayden",
        "Giorgia Cotton",
        "Rita Smyth",
        "Rania Wolf",
        "Zainab Sheldon"
    };

    private string GetFirstName(string fullName)
    {
        return fullName.Split(' ')[0];
    }

    private string GetLastName(string fullName)
    {
        return fullName.Split(' ')[1];
    }

    public void LastNameDescending()
    {
        names.Sort((a, b) => Compare(GetLastName(b), GetLastName(a)));
        PrintNames(names);
    }
    public void FirstNameDescending()
    {
        names.Sort((a, b) => Compare(GetFirstName(b), GetFirstName(a)));
        PrintNames(names);
    }
    public void LastNameAscending()
    {
        names.Sort((a, b) => Compare(GetLastName(a), GetLastName(b)));
        PrintNames(names);
    }
    public void FirstNameAscending()
    {
        names.Sort((a, b) => Compare(GetFirstName(a), GetFirstName(b)));
        PrintNames(names);
    }

    private void PrintNames(List<string> nameList)
    {
        foreach (var namesToPrint in nameList)
        {
            Debug.Log(namesToPrint);
        }
    }
    
}
