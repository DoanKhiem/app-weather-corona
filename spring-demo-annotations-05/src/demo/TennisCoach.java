package demo;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.beans.factory.annotation.Qualifier;
import org.springframework.stereotype.Component;

@Component
public class TennisCoach implements Coach {
	@Autowired
	@Qualifier("randomFortuneService")
	private FortuneService fortuneService;

	@Override
	public String getDailyWorkout() {
		return "Tennis Coach";
	}
	
	public TennisCoach() {
		System.out.println("Chay ham khoi tao tennis Coach");
	}
	public String getFortune() {
		return fortuneService.getFortune();
	}
}
