package spring_demo_05;

import org.springframework.context.support.ClassPathXmlApplicationContext;

public class HelloSpringApp {
	public static void main(String []args) {
		ClassPathXmlApplicationContext context=new
				ClassPathXmlApplicationContext("applicationContext.xml");
		CricketCoach theCoach=context.getBean("myCricketCoach", CricketCoach.class);
		System.out.println(theCoach.getDailyWorkout());
		System.out.println(theCoach.getDailyFortune());
		context.close();
	}
}
