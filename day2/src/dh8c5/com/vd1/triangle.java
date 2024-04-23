package dh8c5.com.vd1;

public class triangle {
	private String type;
	private int height;

	public int getHeight() {
		return height;
	}
	public String getType() {
		return type;
	}
	public triangle(String type, int height) {
		this.type = type;
		this.height = height;
	}

	public triangle(int height) {
		this.height = height;
	}

	public triangle(String type) {
		this.type = type;
	}

	public void Draw() {
        System.out.println(" chieu cao cua tam giac "+ getType() +  " la: "+ getHeight());
    }
}
