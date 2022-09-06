package descent;

import java.net.InetAddress;
import java.net.UnknownHostException;

public class Client {
    private static Client client;

    private String name;
    private int playerId;

    private Client(){
        try {
            this.name = InetAddress.getLocalHost().getHostName();
        } catch (UnknownHostException e) {
            this.name = "";
        }
    }

    public void setPlayerId(int id){
        this.playerId = id;
    }

    public int getPlayerId(){
        return this.playerId;
    }

    public static Client getClient(){
        if(Client.client == null){
            Client.client = new Client();
        }
        return Client.client;
    }
}
