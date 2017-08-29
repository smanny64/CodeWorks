package grandChallenge;

public class RedMartian extends Martian {
	public RedMartian(int id){
		super(id);
	}
	
	public String speak(){
		return "id=" + this.getId() + ", Rubldy Rock";		
	}
	
	public String toString(){
		return "Red Martian id=" + this.getId() + " vol=" + this.getVolume();
	}
}
