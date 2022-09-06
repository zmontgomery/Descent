package descent;

public class Player {
    private static int nextId = 1;

    private String name;
    private int id;

    public Player(String name){
        this.name = name;
        this.id = Player.nextId;
        Player.nextId++;
    }

    public String getName(){
        return this.name;
    }

    public int getId(){
        return this.id;
    }
}
