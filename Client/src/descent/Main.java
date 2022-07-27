package descent;

import java.net.DatagramPacket;
import java.net.DatagramSocket;
import java.net.InetAddress;
import java.net.SocketException;

public class Main {
	public static void main(String[] args) throws Exception {
		DatagramSocket socket = new DatagramSocket();
		DatagramPacket packet = new DatagramPacket(new byte[]{1}, 1, InetAddress.getByAddress(new byte[] { 66,66,83,160 }), 25565);
		socket.send(packet);
	}
}
