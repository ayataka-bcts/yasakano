using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExcelAsset(AssetPath = "Resources/Scenario")]
public class choice : ScriptableObject
{
	public List<ChoiceEntity> Sheet1; // Replace 'EntityType' to an actual type that is serializable.
}
