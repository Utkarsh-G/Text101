using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextController : MonoBehaviour {

	public Text text;
	
	private enum State {start, start2, cell, sheets, lock0, walls, cell_wand, light, recaptured, wall_broken, freedom};
	State currentState;
	State nextState;
	// Use this for initialization
	void Start () {
	currentState = State.start;
	nextState = State.start;
	state_start();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	check_input();
	check_state();
	
	
	}
	
	void check_state()
	{
		if (nextState != currentState)
		{
			currentState = nextState;
			switch(currentState)
			{
				case State.cell:
				state_cell();
				break;
				case State.start2:
				state_start2();
				break;
				case State.lock0:
				state_lock();
				break;
				case State.sheets:
				state_sheets();
				break;
				case State.walls:
				state_walls();
				break;
				case State.cell_wand:
				state_cell_wand();
				break;
				case State.light:
				state_light();
				break;
				case State.recaptured:
				state_recaptured();
				break;
				case State.wall_broken:
				state_wall_broken();
				break;
				case State.freedom:
				state_freedom();
				break;
				case State.start:
				state_start ();
				break;
					
			}
		}
	}
	
	void check_input()
	{
		switch(currentState)
		{
			case State.start:
			if (Input.GetKeyDown(KeyCode.Space))
			{
				nextState = State.start2;
			}
			break;
			
			case State.start2:
			if (Input.GetKeyDown(KeyCode.Space))
			{
				nextState = State.cell;
			}
			break;
			
			case State.cell:
			if (Input.GetKeyDown(KeyCode.S)) nextState = State.sheets;
			if (Input.GetKeyDown(KeyCode.L)) nextState = State.lock0;
			if (Input.GetKeyDown(KeyCode.W)) nextState = State.walls;
			break;
			
			case State.sheets:
			if (Input.GetKeyDown(KeyCode.Space)) nextState = State.cell;
			break;
			
			case State.lock0:
			if (Input.GetKeyDown(KeyCode.Space)) nextState = State.cell;
			break;
			
			case State.walls:
			if (Input.GetKeyDown(KeyCode.Space)) nextState = State.cell_wand;
			break;
			
			case State.cell_wand:
			if (Input.GetKeyDown(KeyCode.S)) nextState = State.sheets;
			if (Input.GetKeyDown(KeyCode.L)) nextState = State.light;
			if (Input.GetKeyDown(KeyCode.U)) nextState = State.recaptured;
			if (Input.GetKeyDown(KeyCode.W)) nextState = State.wall_broken;
			break;
			
			case State.light:
			if (Input.GetKeyDown(KeyCode.Space)) nextState = State.cell_wand;
			break;
			
			case State.recaptured:
			if (Input.GetKeyDown(KeyCode.Space)) nextState = State.cell_wand;
			break;
			
			case State.wall_broken:
			if (Input.GetKeyDown(KeyCode.Space)) nextState = State.freedom;
			break;
			
			case State.freedom:
			if (Input.GetKeyDown(KeyCode.R)) nextState = State.start;
			break;
			
		}
	}
	
	void state_start()
	{
		text.text = "Start of Game \n\nPress Space To Move Along";
	}
	
	void state_start2()
	{
		text.text = "\"I said move along!\"" + "\n" + "The guard prodded me with the baton so hard, I jumped" +
			" halfway into my designated cell. " + "CLANG! The grate slammed shut! \n\n Press Space to move along";
	}
	
	void state_cell()
	{
		text.text = "I looked around my cell in desperation." + "\n\n" + 
				"Press W to examine the walls. " + "Press L to examine the lock of your cell. " + 
				"Press S to examine the sheets.";								
	}
	
	void state_sheets()
	{
		text.text = "Sheets have nothing *sadface* \n\n Press Space to move along";
	}
	
	void state_lock()
	{
		text.text = "Lock is rusty but holds solid. \n\n Press Space to move along";
	}
	
	void state_walls()
	{
		text.text = "The bricks are exposed and the wall is cracked in places." + 
			" I search it desperately with my eyes and fingers. Lots gaps with nothing but air." +
			" Until my finger hits something that moves. Feels like wood, and it rolls around. " +
			" I carefully draw out a piece of thin, carved, wood... Is this a magic wand?!! \n\n Press Space to move along";
	}
	
	void state_cell_wand()
	{
		text.text = "Hmmm... a magic wand. Let's see what it can do!" +
		"\n\n Press L to light up your cell. Press U to unlock cell door. Press S to search the sheets. Press W to break the back wall.";
	}
	
	void state_light()
	{
		text.text = "\"Lumos!\" The whole cell lit up with bright light. " +
		" \n\n Press Space to move along";
	}
	
	void state_recaptured()
	{
		text.text = "\"Alohomora!\" The lock opened without a fuss, and the door squealed ajar. "+
		 "The moment I stepped outside though, the guard caught site of me and came running to shove me"
		 + " back in my cell. \"Gotta do something about that rusty lock...\" he said " +	" \n\n Press Space to move along";	}
	
	void state_wall_broken()
	{
		text.text = "\"Reducto!\" The lower half of the back wall exploded out! I heard the guard cry out from a distance" +
		"\"Hey! What was that?!\" Well, it was now or never." + "\n\n Press Space to move along through the wall";
	}
	
	void state_freedom()
	{
		text.text = "I crawled under the wall and to the outside. The sun was just setting. That game me enough" + 
		" light to run to town and find a empty shed to hide in. My freedom was now in my hands. And it was all thanks" +
		" to the wand. Bless the soul of the poor mage who lost it in that cell, or perhaps left it for next hopeless soul" +
		" to inhabit that prison. It was mine now, and I was ready to make good use of it." + 
		"\n Press R to restart game";
	}
}
