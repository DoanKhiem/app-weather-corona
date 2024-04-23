package spring_demo_05;

public class HappyFortuneService implements FortuneService {
    @Override
    public String getFortune() {
        return "Hom nay la ngay may man";
    }
}
