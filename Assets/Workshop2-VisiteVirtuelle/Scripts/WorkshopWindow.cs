using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static DataStructs;

public abstract class WorkshopWindow : MonoBehaviour
{
	public abstract void FillData(PointOfInterestStruct poiData);
}

