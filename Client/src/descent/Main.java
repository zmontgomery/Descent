package descent;

import java.net.DatagramPacket;
import java.net.DatagramSocket;
import java.net.InetAddress;

public class Main {
	public static void main(String[] args) throws Exception {
		DatagramSocket socket = new DatagramSocket();
		byte[] message = new String("You smell").getBytes();
		DatagramPacket packet = new DatagramPacket(message, message.length, InetAddress.getByName("129.21.87.52"), 24569);
		socket.send(packet);
		socket.close();
	}
}
