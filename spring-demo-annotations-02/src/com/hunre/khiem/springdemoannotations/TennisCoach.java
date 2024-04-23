package com.hunre.khiem.springdemoannotations;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Component;

@Component
public class TennisCoach implements Coach {
	private FortuneService fortuneService;
	@Autowired
	public TennisCoach(FortuneService fortuneService) {
		this.fortuneService = fortuneService;
	}
	@Override
	public String getDailyWorkout() {
		return "Tennis Coach";
	}
	public String getFortune() {
		return fortuneService.getFortune();
	}
}
