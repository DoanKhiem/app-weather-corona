package demo;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Component;

@Component
@Scope("prototype")
public class TennisCoach implements Coach {
	@Override
	public String getDailyWorkout() {
// TODO Auto-generated method stub
		return "Tennis Coach";
	}
}
