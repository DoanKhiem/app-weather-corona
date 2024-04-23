package spring_demo_05;

public class CricketCoach implements Coach {
    private FortuneService fortuneService;
    public void setFortuneService(FortuneService fortuneService) {
        System.out.println("in setFortune in Cricket");
        this.fortuneService = fortuneService;
    }
    public CricketCoach() {
        System.out.println("in constructor cricket");
    }
    @Override
    public String getDailyWorkout() {
        return "hang ngay CricketCoach";
    }
    @Override
    public String getDailyFortune() {
        return fortuneService.getFortune();
    }
}
