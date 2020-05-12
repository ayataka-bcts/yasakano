using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExcelAsset(AssetPath = "Resources/Scenario")]
public class oneweek : ScriptableObject
{
	public List<StroyEntity> main; // Replace 'EntityType' to an actual type that is serializable.
}
