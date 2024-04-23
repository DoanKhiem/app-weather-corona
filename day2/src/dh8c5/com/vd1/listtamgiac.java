package dh8c5.com.vd1;
import java.util.List;

public class listtamgiac {
    public List<point> points;

    public List<point> getPoints() {
        return points;
    }

    public void setPoints(List<point> points) {
        this.points = points;
    }


    public void Drawlisttg() {
        for (point p:points) System.out.println("point =(" + p.getX() + ", " + p.getY() + ")");
    }

}
