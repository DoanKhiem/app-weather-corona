package dh8c5.com.vd1;

public class tamgiacdiem {
	private point pointA;
	private point pointB;
	private point pointC;

    public point getPointA() {
        return pointA;
    }

    public void setPointA(point pointA) {
        this.pointA = pointA;
    }

    public point getPointB() {
        return pointB;
    }

    public void setPointB(point pointB) {
        this.pointB = pointB;
    }

    public point getPointC() {
        return pointC;
    }

    public void setPointC(point pointC) {
        this.pointC = pointC;
    }

    public void Draw() {
        System.out.println("point A: (" + this.pointA.getY() + " , " + this.pointA.getY()+ ")");
        System.out.println("point B: (" + this.pointB.getY() + " , " + this.pointB.getY()+ ")");
        System.out.println("point C: (" + this.pointC.getY() + " , " + this.pointC.getY()+ ")");
	}
}
