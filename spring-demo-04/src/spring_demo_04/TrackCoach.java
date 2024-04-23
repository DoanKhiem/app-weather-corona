package spring_demo_04;

public class TrackCoach implements Coach {
	private FortuneService fortuneService;
	public TrackCoach(FortuneService theFortuneService) {
		fortuneService=theFortuneService;
	}
	@Override
	public String getDailyWorkout() {
		return "chay thu track coach";
	}
	@Override
	public String getDailyFortune() {
		return fortuneService.getFortune();
	}
}

