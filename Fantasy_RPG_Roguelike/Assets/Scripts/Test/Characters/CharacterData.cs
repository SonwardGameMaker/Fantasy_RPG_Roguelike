using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterData : MonoBehaviour
{
    [SerializeField] int baseMaxHP;
    [SerializeField] int realMaxHP;
    [SerializeField] int currentHP;

    [SerializeField] int maxAP;
    [SerializeField] int currentAP;
    [SerializeField] int baseApRegen;
    [SerializeField] int realApRegen;
}
