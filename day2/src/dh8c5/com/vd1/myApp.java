package dh8c5.com.vd1;
import org.springframework.beans.factory.BeanFactory;
import org.springframework.beans.factory.xml.XmlBeanFactory;
import org.springframework.context.support.ClassPathXmlApplicationContext;
import org.springframework.core.io.FileSystemResource;

public class myApp {

	public static void main(String[] args) {
		// TODO Auto-generated method stub
		tamgiac tg=new tamgiac();
		tg.Draw();

		BeanFactory factory=new XmlBeanFactory(new FileSystemResource("beans.xml"));
		tamgiac mytg=(tamgiac) factory.getBean("tamgiac");
		mytg.Draw();

		System.out.println("==========List==========");

		msgHello loichao= (msgHello) factory.getBean("msgHello");
		loichao.Draw();

		System.out.println("==========List==========");

		ClassPathXmlApplicationContext context= new ClassPathXmlApplicationContext("spring.xml");
		tamgiac tg1=context.getBean("tamgiac",tamgiac.class);
		tg1.Draw();

		System.out.println("==========List==========");

		msgHello lc=context.getBean("msgHello",msgHello.class);
		lc.Draw();

		System.out.println("==========List==========");

		triangle mytgg=context.getBean("triangle",triangle.class);
		mytgg.Draw();

		System.out.println("==========List==========");

		tamgiacdiem tg2=context.getBean("tamgiacdiem",tamgiacdiem.class);
		tg2.Draw();

		System.out.println("==========List==========");

		listtamgiac listtamgiac1=context.getBean("listtamgiac", listtamgiac.class);
		listtamgiac1.Drawlisttg();
	}

}
