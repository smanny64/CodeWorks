package grandChallenge;

import java.util.ArrayList;

public class MartianTester {

	public static void main(String[] args) throws CloneNotSupportedException {
		// TODO Auto-generated method stub
		MartianManager mm = new MartianManager();

		RedMartian r1 = new RedMartian(8);

		RedMartian r2 = new RedMartian(18);

		RedMartian r3 = new RedMartian(2);

		GreenMartian g1 = new GreenMartian(11);

		GreenMartian g2 = new GreenMartian(4);

		GreenMartian g3 = new GreenMartian(10);

		GreenMartian g4 = new GreenMartian(2);

		// Test 1 - Martian.toString()

		System.out.println("***Test 1 - Martian.toString()");

		System.out.print(r1 + ", ");

		System.out.println(g1 + "\n");

		// Test 2 - Martian.equals()

		System.out.println("***Test 2 - Martian.equals()");

		System.out.println("r3.equals(g1)= " + (r3.equals(g1)));

		System.out.println("r3.equals(g4)= " + (r3.equals(g4)) + "\n");

		// Test 3 - Martian.compareTo()

		System.out.println("***Test 3 - Martian.compareTo()");

		System.out.println("r3.compareTo(g1)= " + (r3.compareTo(g1)));

		System.out.println("r3.compareTo(g4)= " + (r3.compareTo(g4)));

		System.out.println("r2.compareTo(g3)= " + (r2.compareTo(g3)) + "\n");

		// Test 4 - Martian.clone()

		System.out.println("***Test 4 - Martian.clone()"); Martian m = new RedMartian(83); m.setVolume(44);

		Martian mClone = (Martian)m.clone();

		mClone.setVolume(77);

		System.out.print("m.getVolume()= " + m.getVolume() + ", ");

		System.out.print("mClone.getVolume()= " + mClone.getVolume() + "\n\n");

		// Test 5 - MartianManager.addMartian()

		System.out.println("***Test 5 - MartianManager.addMartian()");

		System.out.print(mm.addMartian(r1) + ", ");

		System.out.print(mm.addMartian(r2) + ", ");

		System.out.print(mm.addMartian(r3) + ", ");

		System.out.print(mm.addMartian(g1) + ", ");

		System.out.print(mm.addMartian(g2) + ", ");

		System.out.print(mm.addMartian(g3) + ", ");

		System.out.println(mm.addMartian(g4) + "\n");

		// Test 6 - MartianManager.groupSpeak()

		System.out.println("***Test 6 - MartianManager.groupSpeak()");

//		5

		System.out.println( mm.groupSpeak() );

		// Test 7 - MartianManager.groupTeleport()

		System.out.println("***Test 7 - MartianManager.groupTeleport()");

		System.out.println( mm.groupTeleport( "Orck") );

		// Test 8 - MartianManager.getMartianClosestToID()

		System.out.println("***Test 8 - MartianManager.getMartianClosestToID()");

		System.out.println( "closest to 7 is: " + mm.getMartianClosestToId(7) );

		System.out.println( "closest to 12 is: " + mm.getMartianClosestToId(12) + "\n" );

		// Test 9 - MartianManager.removeMartian()

		System.out.println("***Test 9 - MartianManager.removeMartian()");

		System.out.print( mm.removeMartian(4) + ", " );

		System.out.print( mm.removeMartian(18) + ", " );

		System.out.println( mm.removeMartian(99) );

		System.out.println( mm.groupSpeak() );

		System.out.println( mm.groupTeleport( "Orck") );

		// Test 10 - MartianManager.sortedMartians()

		System.out.println("***Test 10 - MartianManager.sortedMartians()");

		ArrayList<Martian> sortedMartians = mm.sortedMartians();

		System.out.println("sorted:");

		System.out.println( sortedMartians );

		System.out.println("original order:");

		System.out.println( mm.groupSpeak() );

		// Test 11 - MartianManager.obliterateTeleporters()

		System.out.println("***Test 11 - MartianManager.obliterateTeleporters()"); mm.obliterateTeleporters();

		System.out.println( mm.groupSpeak() );

		System.out.println( mm.groupTeleport( "Orck") );

		// Test 12 - MartianManager.clone()

		System.out.println("***Test 12 - MartianManager.clone()");

		g1 = new GreenMartian(51);

		System.out.print(mm.addMartian(g1) + "\n");

		MartianManager mmClone = (MartianManager)mm.clone();

		System.out.print( mmClone.removeMartian(8) + "\n" );

		System.out.println( "Cloned MartianManager-with id=8 removed" );

		System.out.println( mmClone.groupSpeak() );

		System.out.println( "Original MartianManager" );

		System.out.println( mm.groupSpeak() );

		System.out.println( "Get id=51 from mm, change vol to 999" );

		Martian m2 = mm.getMartianClosestToId(51); m2.setVolume(999);

		System.out.println( "mm, should see 999" );

		System.out.println( mm.sortedMartians());

		System.out.println( "mmClone, should not see 999" );

		System.out.println( mmClone.sortedMartians());
	}

}
