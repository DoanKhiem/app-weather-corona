package com.sandipbhattacharya.weatherupdate;

import androidx.appcompat.app.AppCompatActivity;

import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ImageView;
import android.widget.TextView;
import android.widget.Toast;

import com.android.volley.Request;
import com.android.volley.RequestQueue;
import com.android.volley.Response;
import com.android.volley.VolleyError;
import com.android.volley.toolbox.StringRequest;
import com.android.volley.toolbox.Volley;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import java.text.DecimalFormat;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.Date;

public class WeatherActivity extends AppCompatActivity {
    EditText search;
    Button btSearch, btDays;
    TextView tvCity, tvCountry, tvDay, tvTemp, tvDescription, tvHumidity, tvCloud, tvWind;
    ImageView icon;
    private final String url = "https://api.openweathermap.org/data/2.5/forecast";
    private final String appid = "433949589717ca433ae0129961126942&units=metric&lang=vi";
    DecimalFormat df = new DecimalFormat("#.##");
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_weather);
        anhxa();

    }

    public void getWeatherDetails(View view) {
        String tempUrl = "";
        String city = search.getText().toString().trim();
        if(city.equals("")){
            search.setText("City field can not be empty!");
        }else{
            tempUrl = url + "?q=" + city + "&appid=" + appid;
            StringRequest stringRequest = new StringRequest(Request.Method.POST, tempUrl, new Response.Listener<String>() {
                @Override
                public void onResponse(String response) {
                    try {
                        JSONObject jsonResponse = new JSONObject(response);

                        String day = jsonResponse.getString("dt_txt");


                        JSONArray jsonArray = jsonResponse.getJSONArray("weather");
                        JSONObject jsonObjectWeather = jsonArray.getJSONObject(0);
                        String description = jsonObjectWeather.getString("description");
                        String icon = jsonObjectWeather.getString("icon");

                        JSONObject jsonObjectMain = jsonResponse.getJSONObject("main");
                        double temp = jsonObjectMain.getDouble("temp") - 273.15;
                        int humidity = jsonObjectMain.getInt("humidity");

                        JSONObject jsonObjectWind = jsonResponse.getJSONObject("wind");
                        String wind = jsonObjectWind.getString("speed");

                        JSONObject jsonObjectClouds = jsonResponse.getJSONObject("clouds");
                        String clouds = jsonObjectClouds.getString("all");

                        JSONObject jsonObjectSys = jsonResponse.getJSONObject("sys");
                        String countryName = jsonObjectSys.getString("country");
                        String cityName = jsonResponse.getString("name");



                        tvDescription.setText(description);
                        tvDay.setText(day);
                        tvTemp.setText(df.format(temp));
                        tvHumidity.setText(df.format(humidity));
                        tvWind.setText(wind);
                        tvCloud.setText(clouds);
                        tvCountry.setText(countryName);
                        tvCity.setText(cityName);
                    } catch (JSONException e) {
                        e.printStackTrace();
                    }
                }
            }, new Response.ErrorListener(){

                @Override
                public void onErrorResponse(VolleyError error) {
                    Toast.makeText(getApplicationContext(), error.toString().trim(), Toast.LENGTH_SHORT).show();
                }
            });
            RequestQueue requestQueue = Volley.newRequestQueue(getApplicationContext());
            requestQueue.add(stringRequest);
        }
    }

    private void anhxa(){
        search = findViewById(R.id.search);
        btSearch = findViewById(R.id.btSearch);
        btDays = findViewById(R.id.btDays);
        tvCity = findViewById(R.id.city);
        tvCountry = findViewById(R.id.country);
        tvDay = findViewById(R.id.day);
        tvTemp = findViewById(R.id.temp);
        tvDescription = findViewById(R.id.description);
        tvHumidity = findViewById(R.id.humidity);
        tvCloud = findViewById(R.id.cloud);
        tvWind = findViewById(R.id.wind);
        icon = findViewById(R.id.icon);
    }

}