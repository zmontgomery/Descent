package descent;

import java.net.DatagramPacket;
import java.net.DatagramSocket;
import java.util.Arrays;
import java.util.HashSet;
import java.util.Set;

import javax.xml.crypto.Data;

/**
 * PROTOCOL
 * 
 * packetdata[0]
 * 
 * 0 - Connection
 * 1 - Chat
 * 
 */

public class Server {
	
	private static Server server = new Server();
	private static DatagramSocket socket;
	
	private String name;
	private Set<Player> onlinePlayers;
	
	
	private Server() {
		this.name = "Descent Server";
		this.onlinePlayers = new HashSet<>();
		try{
			Server.socket = new DatagramSocket(24569);
		} catch(Exception e) {
			//exit
		}
	}
	
	public static Server getServer() {
		return server;
	}

	public void start() throws Exception{
		byte[] clientData = new byte[16];
		DatagramPacket clientPacket = new DatagramPacket(clientData, clientData.length);
		int n = 0;
		infoLog("Listening for Clients...");
		while(n < 10){
			socket.receive(clientPacket);
			handleRequest(clientPacket);
			n++;
		}
		socket.close();
	}

	private void handleRequest(DatagramPacket packet) throws Exception{
		byte[] data = packet.getData();
		int code = data[0];
		if(code == 0){
			//Connection protocol
			String playerName = new String(Arrays.copyOfRange(data, 1, data.length));
			infoLog("Connecting to client '" + playerName + "'");
			Player newPlayer = new Player(playerName);
			onlinePlayers.add(newPlayer);
			data[1] = (byte) newPlayer.getId();
			socket.send(packet);
		} else if(code == 1){
			//Chat protocol
			String message = new String(Arrays.copyOfRange(data, 2, data.length));
			broadcast(message);
		}

	}

	private void broadcast(String message){

	}

	private void infoLog(String message){
		System.out.println("[Server-INFO]: " + message);
	}
	
	public String getName() {
		return this.name;
	}
}
