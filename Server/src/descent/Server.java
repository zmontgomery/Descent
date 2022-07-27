package descent;

public class Server {
	
	private static Server server = new Server();
	
	private String name;
	
	private Server() {
		this.name = "Descent Server";
	}
	
	public static Server getServer() {
		return server;
	}
	
	public String getName() {
		return this.name;
	}
}
