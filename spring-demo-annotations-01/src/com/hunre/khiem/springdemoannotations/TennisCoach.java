package com.hunre.khiem.springdemoannotations;

import org.springframework.stereotype.Component;

@Component("thatSillyCoach")
public class TennisCoach implements Coach {
	@Override
	public String getDailyWorkout() {
		return "Tennis Coach";
	}

}
