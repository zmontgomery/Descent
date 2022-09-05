package descent;

import java.net.DatagramPacket;
import java.net.DatagramSocket;

public class Server {
	
	private static Server server = new Server();
	
	private String name;
	
	private Server() {
		this.name = "Descent Server";
	}
	
	public static Server getServer() {
		return server;
	}

	public void start() throws Exception{
		DatagramSocket socket = new DatagramSocket(24569);
		DatagramPacket packet = new DatagramPacket(new byte[10], 10);
		int n = 0;
		while(n < 10){
			System.out.println("listening...");
			socket.receive(packet);
			System.out.println("MESSAGE RECIEVED!!");
			System.out.println("Message: " + new String(packet.getData()));
			n++;
		}
		socket.close();
	}
	
	public String getName() {
		return this.name;
	}
}
