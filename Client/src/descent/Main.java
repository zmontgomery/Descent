package descent;

import java.net.DatagramPacket;
import java.net.DatagramSocket;
import java.net.InetAddress;
import java.util.Scanner;

public class Main {
	public static void main(String[] args) throws Exception {
		Client client = Client.getClient();
		DatagramSocket socket = new DatagramSocket();
		Scanner scanner = new Scanner(System.in);
		byte[] request = new byte[16];
		request[0] = 0;
		System.out.print("Enter a name(15 characters max): ");
		String name = scanner.nextLine();
		scanner.close();

		byte[] nameData = name.getBytes();
		System.arraycopy(nameData, 0, request, 1, nameData.length);
		System.out.println("Requesting connection to host...");
		DatagramPacket packet = new DatagramPacket(request, request.length, InetAddress.getByName("129.21.87.52"), 24569);
		socket.send(packet);
		
		socket.receive(packet);
		byte[] data = packet.getData();
		byte code = data[0];
		if(code == 0){
			System.out.println("Connection success! Assigned id: " + data[1]);
			client.setPlayerId(data[1]);
			//send test message
			data[0] = 1;
			data[1] = (byte) client.getPlayerId();
			String message = "Wadup";
			byte[] messageData = message.getBytes();
			System.arraycopy(messageData, 0, data, 2, messageData.length);
			socket.send(packet);
		} else {
			System.out.println("Connection denied! Exiting in 5 seconds...");
		}
		Thread.sleep(5000);
		
		socket.close();
	}
}
