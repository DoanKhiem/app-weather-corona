package spring_demo_04;

public class HappyFortuneService implements FortuneService {
    @Override
    public String getFortune() {
        return "Hôm nay là thứ sáu ngày 13 :))";
    }
}
