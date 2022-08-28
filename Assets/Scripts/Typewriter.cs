// Script for having a typewriter effect for UI
// Prepared by Nick Hwang (https://www.youtube.com/nickhwang)
// Want to get creative? Try a Unicode leading character(https://unicode-table.com/en/blocks/block-elements/)
// Copy Paste from page into Inpector

using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Typewriter : MonoBehaviour
{
    [SerializeField]
	TMP_Text _tmpProText;
	string writer;

	[SerializeField] float delayBeforeStart = 0f;
	[SerializeField] float timeBtwChars = 0.1f;
	[SerializeField] string leadingChar = "";
	[SerializeField] bool leadingCharBeforeDelay = false;

	// Use this for initialization
	public void Initialize(string sceneText)
	{
		writer = sceneText;
		_tmpProText.text = "";
        StopCoroutine(TypeWriterTMP());
		StartCoroutine(TypeWriterTMP());
	}


	IEnumerator TypeWriterTMP()
	{
		foreach (char c in writer)
		{
			_tmpProText.text += c;
			yield return new WaitForSeconds(timeBtwChars);
		}
	}
}