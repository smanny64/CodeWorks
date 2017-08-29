package grandChallenge;

public class GreenMartian extends Martian implements ITeleporter {
	public GreenMartian(int id){
		super(id);
	}
	
	public String speak(){
		return "id=" + this.getId() + ", Grobldy Grock";
	}
	
	public String teleport(String dest){
		return "id=" + this.getId() + " teleporting to " + dest;
	}
	
	public String toString(){
		return "Green Martian id=" + this.getId() + " vol=" + this.getVolume();
	}
		
}
