package descent;

public class Main {
	public static void main(String[] args) {
		
		Server server = Server.getServer();

		try {
			server.start();
		} catch(Exception e){
			//squash
		}

	}
}
