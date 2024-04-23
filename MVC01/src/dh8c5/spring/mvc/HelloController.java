package dh8c5.spring.mvc;

import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import org.springframework.web.servlet.ModelAndView;
import org.springframework.web.servlet.mvc.AbstractController;

public class HelloController extends AbstractController {
    @Override
    protected ModelAndView handleRequestInternal(HttpServletRequest arg0, HttpServletResponse arg1) throws Exception {
    	// TODO Auto-generated method stub
    	ModelAndView modelandview=new ModelAndView("HelloPage");
    	modelandview.addObject("hellomsg", "Chao cac ban DH8C5");
    	return modelandview;
    }
}
