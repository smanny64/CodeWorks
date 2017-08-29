package grandChallenge;

public abstract class Martian implements Cloneable, Comparable<Martian> {
	private int id;
	private int volume;
	
	public Martian(int id){
		this.id = id;
		this.volume = 1;
	}
	
	public Object clone() throws CloneNotSupportedException{
		return super.clone();
	}
	
	public int compareTo(Martian m){
		int id = ((Martian) m).getId();
		
		//ascending order
		return this.id - id;
	}
	
	public boolean equals(Object o){
		int id = ((Martian) o).getId();
		if(this.id == id){
			return true;
		}
		else{
			return false;
		}
	}

	public int getId(){
		return this.id;
	}
	
	public int getVolume(){
		return this.volume;
	}
	
	public void setVolume(int level){
		this.volume = level;
	}
	
	abstract String speak();
	
	public String toString(){
		return "Martian id=" + this.id + " vol=" + this.volume;
	}
}
