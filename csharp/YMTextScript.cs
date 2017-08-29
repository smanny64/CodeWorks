using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class YMTextScript : MonoBehaviour {

	private enum States{
		//main
		init, start_a, corridor_1a, corridor_2a, corridor_3a, corridor_4, bell_0, bell_1, end, bonus, jump, end_special, results, restart,
		jacqueline_a, hana_a, rias_a, aki_a, joyce_a, yoko_a,
		//aki tangent
			aki_1a, corridor_3e,
		//joyce tangent
			joyce_b, jacqueline_b, hana_b, rias_b, yoko_b, aki_b, corridor_1b, corridor_2b, corridor_3b, corridor_4b, start_b,
		//rias tangent
			joyce_c, jacqueline_0c, jacqueline_1c, hana_0c, hana_1c, rias_c, yoko_c, aki_c, corridor_1c, corridor_2c, corridor_3c,
		//hana tangent
			joyce_d, jacqueline_d, hana_d, rias_d, yoko_d, aki_d, corridor_1d, corridor_2d, corridor_3d, corridor_4d, start_d
		
	};
	private enum Endings{alone, hana, joyce, aki, murdered, grand};
	private Endings myEnding;
	private States myState;
	private int numGirlsCollected;	
	private bool bellRung;
	private bool murdered;
	private bool jumped;
	private bool extra;	
	public Text text;
	
	
	// Use this for initialization
	void Start () {
		bellRung = false;
		murdered = false;
		jumped = false;
		extra = false;		
		numGirlsCollected = 0;
		myState = States.init;
		myEnding = Endings.alone;
		text.text = "";
	}
	
	// Update is called once per frame
	void Update () {
		#region Main Story Line States
		print (myState);
		if(myState == States.init)							{init();}	
		else if(myState == States.start_a)					{start_a();}
		else if(myState == States.corridor_1a)				{corridor_1a();}
		else if(myState == States.corridor_2a)				{corridor_2a();}
		else if(myState == States.corridor_3a)				{corridor_3a();}
		else if(myState == States.corridor_4)				{corridor_4();}
		else if(myState == States.rias_a)					{rias_a();}
		else if(myState == States.joyce_a)					{joyce_a();}
		else if(myState == States.yoko_a)					{yoko_a();}
		else if(myState == States.hana_a)					{hana_a();}			
		else if(myState == States.jacqueline_a)				{jacqueline_a();}
		else if(myState == States.aki_a)					{aki_a();}		
		else if(myState == States.bell_0)					{bell_0();}
		else if(myState == States.bell_1)					{bell_1();}
		else if(myState == States.end)						{end();}
		else if(myState == States.jump)						{jump();}
		else if(myState == States.end_special)				{end_special();}
		else if(myState == States.bonus)					{bonus();}
		else if(myState == States.results)					{results();}			
		#endregion
		
		#region Aki Tangent States
		else if(myState == States.aki_1a)					{aki_1a();}
		else if(myState == States.corridor_3e)				{corridor_3e();}
		#endregion
		
		#region Joyce Tangent States
		else if(myState == States.joyce_b)					{joyce_b();}
		else if(myState == States.rias_b)					{rias_b();}
		else if(myState == States.yoko_b)					{yoko_b();}
		else if(myState == States.hana_b)					{hana_b();}			
		else if(myState == States.jacqueline_b)				{jacqueline_b();}
		else if(myState == States.aki_b)					{aki_b();}
		else if(myState == States.start_b)					{start_b();}
		else if(myState == States.corridor_1b)				{corridor_1b();}
		else if(myState == States.corridor_2b)				{corridor_2b();}
		else if(myState == States.corridor_3b)				{corridor_3b();}
		else if(myState == States.corridor_4b)				{corridor_4b();}		
		#endregion
		
		#region Hana Tangent States
		else if(myState == States.hana_d)					{hana_d();}	
		else if(myState == States.joyce_d)					{joyce_d();}
		else if(myState == States.rias_d)					{rias_d();}
		else if(myState == States.yoko_d)					{yoko_d();}
		else if(myState == States.jacqueline_d)				{jacqueline_d();}
		else if(myState == States.aki_d)					{aki_d();}
		else if(myState == States.start_d)					{start_d();}
		else if(myState == States.corridor_1d)				{corridor_1d();}
		else if(myState == States.corridor_2d)				{corridor_2d();}
		else if(myState == States.corridor_3d)				{corridor_3d();}
		else if(myState == States.corridor_4d)				{corridor_4d();}		
		#endregion
		
		#region Rias Tangent States
		else if(myState == States.joyce_c)					{joyce_c();}
		else if(myState == States.hana_0c)					{hana_0c();}
		else if(myState == States.hana_1c)					{hana_1c();}
		else if(myState == States.yoko_c)					{yoko_c();}
		else if(myState == States.jacqueline_0c)			{jacqueline_0c();}
		else if(myState == States.jacqueline_1c)			{jacqueline_1c();}
		else if(myState == States.aki_c)					{aki_c();}	
		else if(myState == States.corridor_1c)				{corridor_1c();}
		else if(myState == States.corridor_2c)				{corridor_2c();}
		else if(myState == States.corridor_3c)				{corridor_3c();}	
		#endregion
		
		
		
	}
	
	
	void init(){
		text.text = "Welcome to Young Adult Maiden's: Mature Audience Dating Entertainment!\n\n" +
					"Press Space Bar to begin...";
		if(Input.GetKeyDown(KeyCode.Space)){
			myState = States.start_a;
			myEnding = Endings.alone;			
			bellRung = false;
			numGirlsCollected = 0;
			murdered = false;
			jumped = false;
			extra = false;				
		}
	}
	
	void start_a(){
		text.text = "You are in an elegant suite regretting your life choices. You long for someone to be by your side for the duration of the cruise. " +
					"Heading to the back of the yacht crosses your mind as a you turn facing towards the door leading out.\n\n" +
					"Press E to exit";
		if(Input.GetKeyDown(KeyCode.E))									{myState = States.corridor_1a;}
	}
	
	void corridor_1a(){
		text.text = "Standing in the first part of the corridor you are surprised to see the names of old flames across from each other.\n\n" +					
					"Press B to go back \t\t\t\t\tF to go forward \nL to enter Joyce room \t\t\t\tR for Jacqueline room";
		if(Input.GetKeyDown(KeyCode.B))									{myState = States.start_a;}
		else if(Input.GetKeyDown(KeyCode.L))							{myState = States.joyce_a;}
		else if(Input.GetKeyDown(KeyCode.R))							{myState = States.jacqueline_a;}
		else if(Input.GetKeyDown(KeyCode.F))							{myState = States.corridor_2a;}
	}
	
	void joyce_a(){
		text.text = "Joyce is reluctant to see your face around of all places. You feel there is a chance you can rekindle the flame, but " + 
					"only at a miniscule possibility.\n\n" +
					"Press B to go back or C to convince her";
		if(Input.GetKeyDown(KeyCode.B))									{myState = States.corridor_1a;}
		else if(Input.GetKeyDown(KeyCode.C))							{myState = States.joyce_b; myEnding = Endings.joyce; numGirlsCollected++;}		
	}
	
	#region Joyce Tangent Methods
	void joyce_b(){
		text.text = "With a great cheerful smile, you are hugged deeply and thanked for the opportunity to be by your side once more. Joyce " +
					"is preparing herself to meet you at the stern of the ship.\n\n" + 
					"Press B to go back";
		if(Input.GetKeyDown(KeyCode.B))									{myState = States.corridor_1b;}
	}
	void corridor_1b(){
		text.text = "Standing in the first part of the corridor you wonder if rekindling the other flame would be wise a wise decision or to just press on to the stern.\n\n" +					
					"Press B to go back \t\t\t\tF to go forward \nL to enter Joyce room \t\t\tR for Jacqueline room";
		if(Input.GetKeyDown(KeyCode.B))									{myState = States.start_b;}
		else if(Input.GetKeyDown(KeyCode.L))							{myState = States.joyce_b;}
		else if(Input.GetKeyDown(KeyCode.R))							{myState = States.jacqueline_b;}
		else if(Input.GetKeyDown(KeyCode.F))							{myState = States.corridor_2b;}
	}
	void start_b(){
		text.text = "You feel a bit better about yourself inside your luxurious suite. Staring into the mirror causes your greedy need for more attention to manifest itself. " +					
					"Joyce's intentions to meet you at the stern races through your mind as you turn back towards the exit.\n\n" +
					"Press E to exit";
		if(Input.GetKeyDown(KeyCode.E))									{myState = States.corridor_1b;}
	}
	void jacqueline_b(){
		text.text = "Jacqueline is furious and greets you with a punch to the shoulder along with a plethora of verbal abuse. What could you have done " + 
					"to deserve such treatment you ask yourself?!\n\n" +
					"Press B to go back or C to convince her";
		if(Input.GetKeyDown(KeyCode.B))									{myState = States.corridor_1b;}			
		else if(Input.GetKeyDown(KeyCode.C))							{myState = States.corridor_4b; myEnding = Endings.murdered;}		
	}
	void corridor_4b(){
		text.text = "Jacqueline thrashes about in a fit of rage for catching you coming out of Joyce's room with a big smile! " +					
					"Grabbed by your hair, you are dragged out of Jacqueline's room proceeded by a grand display of domestic violence " +
					"placing you at the last part of the corridor. Joyce abandons her plans due to Jacqueline's intervention.\n\n" +
					"Press G to gain composure and move on";
		if(Input.GetKeyDown(KeyCode.G))									{myState = States.corridor_4;}
	}
	void corridor_2b(){
		text.text = "Catching another pair of familiar names up ahead in the second part of the corridor. Hesitation sets is as you do not want to mess up what you already have. " +
					"Temptations are becoming stronger.\n\n" +
					"Press B to go back \t\t\t\tF to go forward \nL to enter Rias room \t\t\t\tR for Hana room";
		if(Input.GetKeyDown(KeyCode.B))									{myState = States.corridor_1b;}
		else if(Input.GetKeyDown(KeyCode.L))							{myState = States.rias_b;}
		else if(Input.GetKeyDown(KeyCode.R))							{myState = States.hana_b;}
		else if(Input.GetKeyDown(KeyCode.F))							{myState = States.corridor_3b;}
	}
	void rias_b(){
		text.text = "Rias does not want your company, or for you to be present before her. Leave now! you are not permitted she glaringly scolds!\n\n"+										
					"Press B to go back";
		if(Input.GetKeyDown(KeyCode.B))									{myState = States.corridor_2b;}	
	}
	
	void hana_b(){
		text.text = "The door creeks open. All you she is a statuesque lifeless figure in the corner amongst the darkness. It is best to exit her room, " +
					"you feel nothing further can be done here.\n\n" +
					"Press B to go back";
		if(Input.GetKeyDown(KeyCode.B))									{myState = States.corridor_2b;}		
	}
	
	void corridor_3b(){
		text.text = "You made your way to the third part of the corridor, you glimpse at the last two passenger rooms onboard the yacht. Discouraged " +
					"at this point...you feel as though you should not bother with them " +
					"and resume your stroll to the stern of the ship.\n\n" +					
					"Press B to go back \t\t\t\tF to go forward \nL to enter Yoko room \t\t\t\tR for Aki room";
		if(Input.GetKeyDown(KeyCode.B))									{myState = States.corridor_2b;}
		else if(Input.GetKeyDown(KeyCode.L))							{myState = States.yoko_b;}
		else if(Input.GetKeyDown(KeyCode.R))							{myState = States.aki_b;}
		else if(Input.GetKeyDown(KeyCode.F))							{myState = States.corridor_4;}
	}
	
	void yoko_b(){
		text.text = "Yoko pushes you back demanding that you leave peacefully or DIE! "+ 
					"Just WHO THE HELL YOU THINK I AM!?...Yoko begins to cry...\n\n" +
					"Press B to go back";
		if(Input.GetKeyDown(KeyCode.B))									{myState = States.corridor_3b;}		
	}
	
	void aki_b(){
		text.text = "You enter Aki's room while overhearing her scream and viciously poke the screen of her phone. Being tech savvy, you begin to extend " +
					"a helping hand only to hear lethal threats of erasing and purging you from existence. Cautiously you back " +
					"away towards the door.\n\n" +
					"Press B to go back";
		if(Input.GetKeyDown(KeyCode.B))									{myState = States.corridor_3b;}		
	}
	#endregion
	
	void jacqueline_a(){
		text.text = "Shocked and dismayed to had even opened the door to you, Jacqueline harshly insists you visit some other tramp trash on the yacht.\n\n" +
					"Press B to go back";
		if(Input.GetKeyDown(KeyCode.B))									{myState = States.corridor_1a;}			
	}
	
	void corridor_2a(){
		text.text = "In the second part of the corridor, you notice another pair of familiar names you feel is too coincidental to be here on this very cruise.\n\n" +					
					"Press B to go back \t\t\t\tF to go forward \nL to enter Rias room \t\t\t\tR for Hana room";
		if(Input.GetKeyDown(KeyCode.B))									{myState = States.corridor_1a;}
		else if(Input.GetKeyDown(KeyCode.L))							{myState = States.rias_a;}
		else if(Input.GetKeyDown(KeyCode.R))							{myState = States.hana_a;}
		else if(Input.GetKeyDown(KeyCode.F))							{myState = States.corridor_3a;}
	}
	
	void rias_a(){
		text.text = "Pulled into the room effortlessly, you see a very lewd figure before you. Being the gentlemen you claim yourself to be, your eyes are averted. "+
					"But, you can barely resist the urge to try your luck despite your shyness.\n\n" +					
					"Press B to go back or C to convince her";
		if(Input.GetKeyDown(KeyCode.B))									{myState = States.corridor_1a;}
		else if(Input.GetKeyDown(KeyCode.C))							{myState = States.yoko_c; myEnding = Endings.grand; numGirlsCollected++;}		
	}	
	
	#region Rias Tangent Methods
	void joyce_c(){
		text.text = "Joyce apologizes for her prior misdeeds. She appears to be lost in feelings of how to go about making it up to you.\n\n" + 
					"Press B to go back or C to convince her";
		if(Input.GetKeyDown(KeyCode.B))									{myState = States.corridor_1c;}
		else if(Input.GetKeyDown(KeyCode.C))							{myState = States.hana_1c; numGirlsCollected++;}
	}
	void corridor_1c(){
		text.text = "Discouraged to be back where you started since your exit from solitude, you shed all doubt to chance your luck with your next decision.\n\n" +
					"Press F to go forward \nL to enter Joyce room \t\t\t\tR for Jacqueline room";
		if(Input.GetKeyDown(KeyCode.L))									{myState = States.joyce_c;}
		else if(Input.GetKeyDown(KeyCode.R))							{myState = States.jacqueline_0c;}
		else if(Input.GetKeyDown(KeyCode.F))							{myState = States.corridor_2c;}
	}
	void jacqueline_0c(){
		text.text = "Jacqueline only wants to hear an excuse from you. There is no reasoning with her at this time...\n\n" +
					"Press W to walk out";
		if(Input.GetKeyDown(KeyCode.W))									{myState = States.corridor_1c;}			
	}
	void jacqueline_1c(){
		text.text = "Hana joined the party! Too easy you say under your breath...You notice Jacqueline is Hana's cabin neighbor. Having no remorse for what happens next, " +
					"you decide to knock on her door\n\n" +
					"Press C to convince her";
		if(Input.GetKeyDown(KeyCode.C))									{myState = States.corridor_4; numGirlsCollected++;}		
	}
	void corridor_2c(){
		text.text = "Standing at the half way point of the corridor, your only option is to head towards the bow...You begin to ponder if this is destiny at work.\n\n" +					
					"Press B to go back";
		if(Input.GetKeyDown(KeyCode.B))									{myState = States.corridor_1c;}
	}	
	
	void hana_0c(){
		text.text = "Ayyyyyeeeee! goes Aki as she forces you into her cabin buddy's room. See you at the stern kawaii! To your dismay...Hana seems to be afk...\n\n" +
					"Press W to walk out";
		if(Input.GetKeyDown(KeyCode.W))									{myState = States.corridor_2c;}	
	}
	
	void hana_1c(){
		text.text = "Joyce thanks you for your kindness and warmly accepted your invitation to accompany you at the stern. Joyce walks you over to Hana's room insisting you to include " +
					"as she shoves you inside closing the door.\n\n" +
					"Press C to convince her";
		if(Input.GetKeyDown(KeyCode.C))									{myState = States.jacqueline_1c; numGirlsCollected++;}	
	}
	
	void corridor_3c(){
		text.text = "Yoko didn't hesitate to say YES although you have been shoved out her room to the 3rd dection of the corridor. Your options are limited...is this Rias's doing?\n\n" +					
					"Press R to enter Aki's room";
		if(Input.GetKeyDown(KeyCode.R))									{myState = States.aki_c;}
	}
	
	void yoko_c(){
		text.text = "Rias agrees to your propopsal with fiendish intentions. Good or bad you don't really care as she leads you to her cabin neighbor who hugs you upon sight. " +
					"Just WHO THE HELL YOU THINK I AM!?...Yoko shouts out!\n\n" +
					"Press C to convince her";
		if(Input.GetKeyDown(KeyCode.C))									{myState = States.corridor_3c; numGirlsCollected++;}		
	}
	
	void aki_c(){
		text.text = "Aki invites you in with sparkly eyes fixated on your blank expressionless face...Welllll?! uttered Aki.\n\n" +
					"Press B to go back or C to convince her";
		if(Input.GetKeyDown(KeyCode.B))									{myState = States.corridor_3c;}
		else if(Input.GetKeyDown(KeyCode.C))							{myState = States.hana_0c; numGirlsCollected++;}		
	}
	#endregion 
	
	void hana_a(){
		text.text = "Greeted by the most broken use of English vocabulary...you cannot help yourself to the slight amusement brought on by her efforts to communicate with you.\n\n" +
					"Press B to go back or C to convince her";
		if(Input.GetKeyDown(KeyCode.B))									{myState = States.corridor_1a;}
		else if(Input.GetKeyDown(KeyCode.C))							{myState = States.hana_d; numGirlsCollected++;}			
	}
	
	#region Hana Tangent Methods
	void joyce_d(){
		text.text = "You feel the atmosphere drop to a chill. In the distance you see the coldest stare possible from Joyce.\n\n" + 
					"Press B to go back or C to convince her";
		if(Input.GetKeyDown(KeyCode.B))									{myState = States.corridor_1d;}
		else if(Input.GetKeyDown(KeyCode.C))							{myState = States.corridor_4d; myEnding = Endings.alone; numGirlsCollected++;}
	}
	void corridor_1d(){
		text.text = "You walked out to the first section of the corridor and can see Joyce's room on the other side. You say to yourself one should be enough but you feel you shouldn't " +
					"press it any further with Jacqueline\n\n" +
					"Press B to go back to your room \t\t\t\tF to go forward \nL to enter Joyce room";
		if(Input.GetKeyDown(KeyCode.B))									{myState = States.start_d;}
		else if(Input.GetKeyDown(KeyCode.L))							{myState = States.joyce_d;}
		else if(Input.GetKeyDown(KeyCode.F))							{myState = States.corridor_2d;}
	}
	void start_d(){
		text.text = "You're back in the Deluxe Man Suite deciding whether to satiate your attention deficit with more company or to press on to the stern for a guaranteed party with Hana. " +
					"Heading towards the door you smile upon lady luck to bring you more affection.\n\n" +
					"Press E to exit";
		if(Input.GetKeyDown(KeyCode.E))									{myState = States.corridor_1d;}
	}
	void jacqueline_d(){
		text.text = "Jacqueline mistakenly invited you in and had punched your chest for tricking her.\n\n" +
					"Press W to walk out or C to convince her";
		if(Input.GetKeyDown(KeyCode.W))									{myState = States.corridor_1d;}			
		else if(Input.GetKeyDown(KeyCode.C))							{myState = States.corridor_4d; myEnding = Endings.murdered;}		
	}
	void corridor_4d(){
		if(myEnding == Endings.murdered){
			text.text = "Jacqueline viper grips your nipple placing you at her mercy as she leads you down the corridor with a mouthful profanities. " +					
						"She brings you to your knees letting go of her grip leaving you at the last part of the corridor. Hana abandons her plans due to Jacqueline's intervention.\n\n" +
						"Press G to gain composure and move on";
		}
		else{
			text.text = "You feel faint and lightheaded as your vision fades to black...Am I dying you ask yourself?! Feeling a thud you awaken on the floor at the last part of the corridor. " +					
						"You recieved a notice stating that Hana had left the Party...\n\n" +
						"Press G to gain composure and move on";
		}
		if(Input.GetKeyDown(KeyCode.G))									{myState = States.corridor_4;}
	}
	void corridor_2d(){
		text.text = "Striding through to the second part of the corridor. A guest name on the wall catches your eye but you feel you ought to keep moving onwards.\n\n" +					
					"Press B to go back \t\t\t\tF to go forward \nL to enter Rias room \t\t\t\tR for Hana room";
		if(Input.GetKeyDown(KeyCode.B))									{myState = States.corridor_1d;}
		else if(Input.GetKeyDown(KeyCode.L))							{myState = States.rias_d;}
		else if(Input.GetKeyDown(KeyCode.R))							{myState = States.hana_d;}
		else if(Input.GetKeyDown(KeyCode.F))							{myState = States.corridor_3d;}
	}
	void rias_d(){
		text.text = "YOU DON'T HAVE MY PERMISSION!\n\n" +
					"Press B to go back";
		if(Input.GetKeyDown(KeyCode.B))									{myState = States.corridor_2d;}	
	}
	
	void hana_d(){
		text.text = "Hana has accepted your party invite and awaits your signal to meet at the stern of the ship. You got a glimpse of Hana's room neighbor, Jacqueline, while turning away.\n\n" +
					"Press B to go back or K to knock on Jacqueline's door";
		if(Input.GetKeyDown(KeyCode.B))									{myState = States.corridor_2d;}	
		else if(Input.GetKeyDown(KeyCode.K))							{myState = States.jacqueline_d;}	
	}
	
	void corridor_3d(){
		text.text = "With a carefree attitude you continue through the third section of the corridor while sighting the last passenger names onboard. Confident with just one, " +
					"you try to resist temptations to complicate what you already have.\n\n" +					
					"Press B to go back \t\t\t\tF to go forward \nL to enter Yoko room \t\t\t\tR for Aki room";
		if(Input.GetKeyDown(KeyCode.B))									{myState = States.corridor_2d;}
		else if(Input.GetKeyDown(KeyCode.L))							{myState = States.yoko_d;}
		else if(Input.GetKeyDown(KeyCode.R))							{myState = States.aki_d;}
		else if(Input.GetKeyDown(KeyCode.F))							{myState = States.corridor_4;}
	}
	
	void yoko_d(){
		text.text = "YOU'RE NOT HIM!!!\n" + 
					"Just WHO THE HELL YOU THINK I AM!?...Yoko begins to cry...\n\n" +
					"Press B to go back";
		if(Input.GetKeyDown(KeyCode.B))									{myState = States.corridor_3d;}		
	}
	
	void aki_d(){
		text.text = "Hearing your name being chanted in the distance by a deranged techie girl disrupts your confidence to proceed any further.\n\n" +
					"Press B to go back";
		if(Input.GetKeyDown(KeyCode.B))									{myState = States.corridor_3d;}		
	}
	#endregion
	
	void corridor_3a(){
		text.text = "On through the third part of the corridor, the two names of the final passengers aboard catches you by surprise. You start to question the plausibility " +
					"of this cruise being a fantasy dream or your prayers finally answered.\n\n" + 
					"Press B to go back \t\t\t\tF to go forward \nL to enter Yoko room \t\t\t\tR for Aki room";
		if(Input.GetKeyDown(KeyCode.B))									{myState = States.corridor_2a;}
		else if(Input.GetKeyDown(KeyCode.L))							{myState = States.yoko_a;}
		else if(Input.GetKeyDown(KeyCode.R))							{myState = States.aki_a;}
		else if(Input.GetKeyDown(KeyCode.F))							{myState = States.corridor_4;}
	}
	
	void yoko_a(){
		text.text = "Yoko is very disappointed and saddened to have let you in her room with a false hug to add. Clearly she mistaken you as someone else and asks you to please leave..."+ 
					"Just WHO THE HELL YOU THINK I AM!?...Yoko begins to cry...\n\n" +
					"Press B to go back";
		if(Input.GetKeyDown(KeyCode.B))									{myState = States.corridor_3a;}		
	}
	
	void aki_a(){
		text.text = "Overseeing what looks like a dating simulator being played on her phone when she leads into her quarters. You go into a minor daze upon her calling your name erotically. " + 
					"The feeling becomes short-lived when you realize she is speaking to her cyber boyfriend with no focus on you what so ever.\n\n" +
					"Press B to go back or C to convince her";
		if(Input.GetKeyDown(KeyCode.B))									{myState = States.corridor_3a;}
		else if(Input.GetKeyDown(KeyCode.C))							{myState = States.aki_1a; myEnding=Endings.aki; numGirlsCollected++;}			
	}
	
	#region Aki Tangent Methods
	void aki_1a(){
		text.text = "Aki is dumbfounded for not noticing your resemblance to her cherished cyber boyfriend and learning of your name made her blush. " +
					"Aki instructs you to go to the stern of the yacht to meet her there. You notice she picks up her phone again as you turn towards her door.\n\n" +
					"Press B to go back";
		if(Input.GetKeyDown(KeyCode.B))									{myState = States.corridor_3e;}		
	}
	
	void corridor_3e(){
		text.text = "Not to disobey Aki's instuctions, you decide to do nothing else but move on forward.\n\n" +					
					"Press F to go forward";
		if(Input.GetKeyDown(KeyCode.F))									{myState = States.corridor_4;}		
	}
	#endregion
	
	void corridor_4(){
		text.text = "Arriving at the end of the corridor with the exit in sight, you see the bell room on your left.\n\n" +					
					"L to enter Bell room or F to go forward";
		if(Input.GetKeyDown(KeyCode.L) && !bellRung)					{myState = States.bell_0;}
		else if(Input.GetKeyDown(KeyCode.L) && bellRung)				{myState = States.bell_1;}		
		else if(Input.GetKeyDown(KeyCode.F))							{myState = States.end;}
	}
	
	void bell_0(){
		text.text = "You find the bell room very mediocre and unsatisfying...\n\n" +
					"Press B to go back or R to ring the bell";
		if(Input.GetKeyDown(KeyCode.B))									{myState = States.corridor_4;}
		else if(Input.GetKeyDown(KeyCode.R))							{myState = States.bell_1; bellRung = true;}
	}
	
	void bell_1(){
		text.text = "The bell rang with a hypnotic tone. Nothing else worth noting has happened.\n\n" +
					"Press B to go back";
		if(Input.GetKeyDown(KeyCode.B))									{myState = States.corridor_4;}		
	}
	
	void end(){
		if(myEnding == Endings.alone || !bellRung || myEnding == Endings.murdered){
			text.text = "You reached the stern of the yacht! You observe the most wonderful sunset as you wait for someone to walk through those doors to be " +
						"by your side for this eXtensively long voyage. The dark skies become filled with the light of the moon and stars fills as you ponder to yourself why nobody " +
						"wants to be with you. Greeted by the rays of the rising sunset you contemplate Jumping after coming to the realization you will indeed be forever alone...";						
		}
		else{
			if(myEnding == Endings.aki){
				text.text = "Greeted by the wonderous warmth of sunset, you see Aki come through the corridor doors with her eyes focused on the phone screen. Thankful to have someone " +
							"by your side omits any negative feelings...or so you wanted to believe. Aki informs you her life and companionship has been pledged to her cyber boyfriend. You turn your " +
							"gaze to the horizon....am I still happy you ask?";
			}else if(myEnding == Endings.hana){
				text.text = "Exiting out to the stern of the ship, Hana is there by the guard rail staring out into the distance. You try to conversate without much luck but a couple of stares. " +
							"Albeit such dull company, you succeeded at not being alone for the most part.";
			}else if(myEnding == Endings.joyce){
				text.text = "Upon exiting onto the stern, Joyce sneaks up and hugs you tightly! You become teary-eyed as you return the favor and hug her back. Was this the feeling you longed for?";
			}else if(myEnding == Endings.grand){
				text.text = "You open the doors to a surprise party comprised of everyone you convinced. Happiness is an understatement as you think to yourself how this day could get even better!?";
			}										
		}	
		text.text = text.text + "\n\nPress Space Bar to continue...";	
		if(Input.GetKeyDown(KeyCode.J))													{myState = States.jump; }
		else if(Input.GetKeyDown(KeyCode.X) && !bellRung)								{myState = States.bonus; myEnding=Endings.alone;}
		else if(Input.GetKeyDown(KeyCode.X))											{myState = States.bonus;}
		else if(Input.GetKeyDown(KeyCode.Space) && !bellRung)							{myState = States.results; myEnding=Endings.alone;}		
		else if(Input.GetKeyDown(KeyCode.Space))										{myState = States.results;}
	}
	
	void jump(){
		text.text = "You fearlessly climb over the guard rail without a shred of remorse or regret.\n\n" +
					"Press J to jump or A to abort and end the day";
		if(Input.GetKeyDown(KeyCode.J) && myEnding == Endings.murdered)			{myState = States.end_special; murdered=true;}
		else if(Input.GetKeyDown(KeyCode.J))									{myState = States.end_special; jumped =true;}	
		else if(Input.GetKeyDown(KeyCode.A) && myEnding == Endings.murdered)	{myState = States.end_special; murdered=true;}
		else if(Input.GetKeyDown(KeyCode.A))									{myState = States.results; myEnding=Endings.alone;}
	}
	
	void end_special(){
		if(myEnding == Endings.alone){
			text.text = "Even upon death...Forever alone...\n\n";
		}else if(myEnding == Endings.aki){
			text.text = "No0o0o0o!! Aki screams out as you free fall to the waters below. You nearly regretted your decision until you noticed last second Aki was yelling at her phone...\n\n";
		}else if(myEnding == Endings.hana){
			text.text = "Hana watches you plummet to your demise without a word...\n\n";
		}else if(myEnding == Endings.joyce){
			text.text = "After you jumped, Joyce quickly followed you down for one hug while screaming proudly: TOGETHER!!!\n\n";
		}else if(myEnding == Endings.murdered){
			text.text = "Before you even moved a muscle, you felt a great force from behind. YOU MURDERER!!! was your final words to Jacqueline!\n\n";
		}else if(myEnding == Endings.grand){
			text.text = "Taking a leap off the rail, you felt yourself pause in midair as if you never jumped. Looking back you see that everyone has a hold on you except for 1 go figure...You say to yourself, " +
						"They really care for me! :')\n\n";
		}		
		text.text = text.text + "Press Space Bar to continue...";
		if(Input.GetKeyDown(KeyCode.Space))										{myState = States.results;}			
	}
	
	void bonus(){
		string t = "";
		if(myEnding == Endings.alone){
			t = "Displeased with yourself, you decided to head back to your suite of solitude to do what has got you by countless times without fail. FAP!\n\n";
		}else if(myEnding == Endings.aki){
			t = "You over heard Aki's dream of making her cyber boyfriend come alive realisticly. You pounced on the opportunity to offer your services. Taking her phone and holding it over " +
				"your face caused Aki to rip your clothes off in a crazed lustful frenzy. Fearing what happens should you remove the phone from your face...you focused on being Aki's cyber boy toy "+
				"best you could handle.\n\n";
		}else if(myEnding == Endings.hana){
			t = "Noticing Hana has gone into another afk state of consciousness you drop all morality and shame to satisfy your urges. Frisking her body you feel an appendage you've always " +
				"wondered about its existence. To your delight and amusement it did indeed as you explored every inch of her tight body.\n\n";
		}else if(myEnding == Endings.joyce){
			t = "Joyce insists to head back to her cabin room with you as her escort. Upon arrival she hugs and kisses you for such a great time! How about that?!\n\n";
		}else if(myEnding == Endings.grand){
			t = "Rias snaps her fingers teleporting everyone to her secret cabin within a cabin room. Immediately you feel free of clothing and whats more is the absence of clothing from everyone else! " +
				"Rias confidently proclaims your stamina to be sufficient to have a go with them all including herself. Each apprehended a body part for themselves and began their fornications.\n\n";
		}		
		text.text = t + "\n\nPress Space Bar to continue...";
		if(Input.GetKeyDown(KeyCode.Space))										{myState = States.results; extra=true;}			
	}
	
	void results(){		
		text.text = "RESULTS OF YOUR EFFORTS: \n\n" +
					"You Convinced: ";		
		if(numGirlsCollected >= 6){			
			text.text = text.text + "EVERYONE!";
		}else if(numGirlsCollected > 0 && numGirlsCollected < 6){ 
			text.text = text.text + numGirlsCollected + " out of 6";
		}else if(myEnding == Endings.murdered){
			text.text = text.text + "NO BODY! Your efforts thwarted by Jacqueline...";
		}else{
			text.text = text.text + "NO ONE!";
		}		
		text.text = text.text + "\n\n";
		if(myEnding == Endings.grand && extra && numGirlsCollected >= 6){
			text.text = text.text + "Grand Erotic Ending DISCOVERED!";
		}else if(myEnding == Endings.grand && jumped){
			text.text = text.text + "Ultimate Caring Ending DISCOVERED!";
		}else if(myEnding == Endings.grand){
			text.text = text.text + "Grand Ending DISCOVERED!";
		}else if(myEnding == Endings.aki && jumped){
			text.text = text.text + "Oblivious Aki Ending DISCOVERED!";
		}else if(myEnding == Endings.aki && extra){
			text.text = text.text + "Aki Erotic Ending DISCOVERED!";
		}else if(myEnding == Endings.aki){
			text.text = text.text + "Cyber x Aki Ending DISCOVERED!";
		}else if(myEnding == Endings.hana && jumped){
			text.text = text.text + "Cold Hearted Hana Ending DISCOVERED!";
		}else if(myEnding == Endings.hana && extra){
			text.text = text.text + "Hana Mishandled Ending DISCOVERED!";
		}else if(myEnding == Endings.hana){
			text.text = text.text + "Bland Hana Ending DISCOVERED!";
		}else if(myEnding == Endings.joyce && jumped){
			text.text = text.text + "Rommeo Joycelet Ending DISCOVERED!";
		}else if(myEnding == Endings.joyce && extra){
			text.text = text.text + "Joyce Romantic Ending DISCOVERED!";
		}else if(myEnding == Endings.joyce){
			text.text = text.text + "Happy Joyce Ending DISCOVERED!";
		}else if(murdered){
			text.text = text.text + "Grimm Ending DISCOVERED!";
		}else{
			text.text = text.text + "Lonely Tragic Ending DISCOVERED!";
		}
		text.text = text.text + "\n\n" +
					"Press P to play again";
		if(Input.GetKeyDown(KeyCode.P))											{myState = States.init;}
		
	}
	
}
