package com.hunre.khiem.springdemoannotations;

import org.springframework.stereotype.Component;

@Component
public class HappyFortuneService implements FortuneService {
	@Override
	public String getFortune() {
		return "Happy Forune Service class";
	}
}

