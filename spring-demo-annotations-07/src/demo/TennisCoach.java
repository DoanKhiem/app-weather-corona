package demo;

import org.springframework.stereotype.Component;

@Component
public class TennisCoach implements Coach {
	@PostCo
	public void doMyStartupStuff() {
		System.out.println("bat dau");
	}

	@PreDestroy
	public void doMyCleanupStuff() {
		System.out.println("ket thuc");
	}

	@Override
	public String getDailyWorkout() {
		return "Tennis Coach";
	}

	public TennisCoach() {
		System.out.println("Chay ham khoi tao tennis Coach");
	}
}
