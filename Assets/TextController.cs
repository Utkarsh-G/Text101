using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextController : MonoBehaviour {

	public Text text;
	// Use this for initialization
	void Start () {
	text.text = "Press Space To Move Along";
	
	}
	
	// Update is called once per frame
	void Update () {
	if (Input.GetKeyDown(KeyCode.Space))
	{
		text.alignment = TextAnchor.MiddleLeft;
		text.text = "\"I said move along!\"" + "\n" + "The guard prodded me with the baton so hard, I jumped" +
				" halfway into my designated cell. " + "CLANG! The grate slammed shut! " + 
					"I looked around my cell in desperation." + "\n\n" + 
					"Press W to examine the walls. " + "Press L to examine the lock of your cell. " + 
					"Press S to examine the sheets.";
	}
	// I think this is Master Copy now. So mono and unity are versioned separately...?
	}
}
