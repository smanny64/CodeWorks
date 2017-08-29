package grandChallenge;

import java.util.ArrayList;
import java.util.Collections;

public class MartianManager implements Cloneable {
	private ArrayList<Martian> martians = new ArrayList<Martian>();
	private ArrayList<Martian> teleporters = new ArrayList<Martian>();
	
	public MartianManager(){
		
	}
	
	public boolean addMartian(Martian m){
		for(Martian n : martians){
			if(n.equals(m)){
				return false;
			}
		}
		
		martians.add(m);
		
		if(m instanceof ITeleporter){
			boolean exists = false;
			for(Martian n : teleporters){
				if(n.equals(m)){
					exists = true;
				}
			}
			if(!exists){
				teleporters.add(m);
			}
		}
		
		return true;
	}
	
	public Object clone() throws CloneNotSupportedException{
		MartianManager mm = (MartianManager)super.clone();
		mm.martians = (ArrayList<Martian>)this.martians.clone();
		mm.teleporters = (ArrayList<Martian>)this.teleporters.clone();
		return mm;
	}
	
	public Martian getMartianClosestToId(int id) {		
		ArrayList<Martian> sm = sortedMartians();
		int index = 0;
		int dif = Math.abs(id - sm.get(0).getId());
		for(int i = 0; i < sm.size(); i++){			
			if(dif > Math.abs(id - sm.get(i).getId())){
				index = i;
				dif = Math.abs(id - sm.get(i).getId());
			}
		}
		
		return sm.get(index);
	}
	
	public String groupSpeak(){
		StringBuilder sb = new StringBuilder();
		for(Martian m : martians){
			sb.append(m.speak() + "\n");
		}
		return sb.toString();
	}
	
	public String groupTeleport(String dest){
		StringBuilder sb = new StringBuilder();
		for(Martian m : teleporters){
			if(m instanceof ITeleporter){
				sb.append(((ITeleporter) m).teleport(dest) + "\n");
			}
		}
		return sb.toString();
	}
	
	public void obliterateTeleporters(){		
		martians.removeAll(teleporters);
		teleporters.clear();
	}
	
	public boolean removeMartian(int id){
		for(Martian m : martians){			
			if(m.getId() == id){
				if(m instanceof GreenMartian){
					teleporters.remove(m);
				}
				martians.remove(m);
				return true;
			}
		}
		return false;
	}
	
	public ArrayList<Martian> sortedMartians(){
		ArrayList<Martian> sm = (ArrayList<Martian>)this.martians.clone();
		Collections.sort(sm);
		return sm;
	}
}
