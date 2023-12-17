using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static DataStructs;

public class EditorWindowManager : MonoBehaviour
{
	public EditorWindow EditorWindow;
	public GameObject Player;

	public void DisplayPOI(PointOfInterestStruct poiInfo)
	{
		EditorWindow.FillData(poiInfo);
		EditorWindow.gameObject.SetActive(true);
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
		Player.SetActive(false);
	}
	public void HidePOI()
	{
		EditorWindow.gameObject.SetActive(false);
		Player.SetActive(true);
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
	}
}
