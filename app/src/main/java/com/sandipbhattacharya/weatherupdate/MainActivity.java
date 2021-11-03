package com.sandipbhattacharya.weatherupdate;


import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ImageView;
import android.widget.TextView;
import android.widget.Toast;

import androidx.appcompat.app.AppCompatActivity;

import com.android.volley.Request;
import com.android.volley.RequestQueue;
import com.android.volley.Response;
import com.android.volley.VolleyError;
import com.android.volley.toolbox.StringRequest;
import com.android.volley.toolbox.Volley;
import com.google.android.gms.ads.AdRequest;
import com.google.android.gms.ads.AdView;
import com.google.android.gms.ads.MobileAds;
import com.google.android.gms.ads.initialization.InitializationStatus;
import com.google.android.gms.ads.initialization.OnInitializationCompleteListener;
import com.squareup.picasso.Picasso;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import java.text.DecimalFormat;

public class MainActivity extends AppCompatActivity {

    EditText searchCorona;
    Button btSearchCorona;
    TextView tvCountryCorona, tvContinentCorona, tvPopulationCorona, tvTodayCasesCorona, tvCasesCorona, tvTodayDeathsCorona, tvDeathsCorona, tvTodayRecoveredCorona, tvRecoveredCorona;
    ImageView flag;


    EditText search;
    Button btSearch, btDays;
    TextView tvCity, tvCountry, tvDay, tvTemp, tvDescription, tvHumidity, tvCloud, tvWind;
    ImageView imIcon;

    private final String urlCorona = "https://disease.sh/v3/covid-19/countries";
//    private final String appidCorona = "433949589717ca433ae0129961126942&units=metric&lang=vi";

    private final String url = "https://api.openweathermap.org/data/2.5/forecast";
    private final String appid = "433949589717ca433ae0129961126942&units=metric&lang=vi";
    DecimalFormat df = new DecimalFormat("#.#");



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
//
                tempUrl = url + "?q=" + city + "&appid=" + appid;
            StringRequest stringRequest = new StringRequest(Request.Method.POST, tempUrl, new Response.Listener<String>() {
                @Override
                public void onResponse(String response) {
                    try {
                        JSONObject jsonResponse = new JSONObject(response);

                        JSONArray jsonArrayList = jsonResponse.getJSONArray("list");
                        JSONObject jsonObjectList = jsonArrayList.getJSONObject(0);

                        JSONArray jsonArray = jsonObjectList.getJSONArray("weather");
                        JSONObject jsonObjectWeather = jsonArray.getJSONObject(0);

                        String description = jsonObjectWeather.getString("description");
                        String icon = jsonObjectWeather.getString("icon");

                        JSONObject jsonObjectMain = jsonObjectList.getJSONObject("main");
                        double temp = jsonObjectMain.getDouble("temp");
                        int humidity = jsonObjectMain.getInt("humidity");

                        JSONObject jsonObjectWind = jsonObjectList.getJSONObject("wind");
                        String wind = jsonObjectWind.getString("speed");

                        JSONObject jsonObjectClouds = jsonObjectList.getJSONObject("clouds");
                        String clouds = jsonObjectClouds.getString("all");

                        JSONObject jsonArrayCity = jsonResponse.getJSONObject("city");
                        String countryName = jsonArrayCity.getString("country");
                        String cityName = jsonArrayCity.getString("name");



                        tvDescription.setText(description);
                        tvDay.setText(icon);
                        Picasso.get().load("http://openweathermap.org/img/wn/"+icon+"@2x.png").into(imIcon);
//
                        tvTemp.setText(df.format(temp));
                        tvHumidity.setText(df.format(humidity)+"%");
                        tvWind.setText(wind+"Km/h");
                        tvCloud.setText(clouds+"%");
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


    public void getCoronaDetails(View view) {
        String url = "";
        String country1 = searchCorona.getText().toString().trim();
        if(country1.equals("")){
            searchCorona.setText("Nhập tên đất nước");
        }else{
//
            url = urlCorona;
            StringRequest stringRequest = new StringRequest(Request.Method.POST, url, new Response.Listener<String>() {
                @Override
                public void onResponse(String response) {
                    try {
                        JSONArray arrayResponse = new JSONArray(response);
                        JSONObject jsonObjectList = arrayResponse.getJSONObject(0);
                        String country = jsonObjectList.getString("country");
                        tvCountryCorona.setText(country);

//                        JSONArray jsonArray = jsonObjectList.getJSONArray("weather");
//                        JSONObject jsonObjectWeather = jsonArray.getJSONObject(0);
//
//                        String description = jsonObjectWeather.getString("description");
//                        String icon = jsonObjectWeather.getString("icon");
//
//                        JSONObject jsonObjectMain = jsonObjectList.getJSONObject("main");
//                        double temp = jsonObjectMain.getDouble("temp");
//                        int humidity = jsonObjectMain.getInt("humidity");
//
//                        JSONObject jsonObjectWind = jsonObjectList.getJSONObject("wind");
//                        String wind = jsonObjectWind.getString("speed");
//
//                        JSONObject jsonObjectClouds = jsonObjectList.getJSONObject("clouds");
//                        String clouds = jsonObjectClouds.getString("all");
//
//                        JSONObject jsonArrayCity = jsonResponse.getJSONObject("city");
//                        String countryName = jsonArrayCity.getString("country");
//                        String cityName = jsonArrayCity.getString("name");




//                        tvDay.setText(icon);
//                        Picasso.get().load("http://openweathermap.org/img/wn/"+icon+"@2x.png").into(imIcon);
////
//                        tvTemp.setText(df.format(temp));
//                        tvHumidity.setText(df.format(humidity)+"%");
//                        tvWind.setText(wind+"Km/h");
//                        tvCloud.setText(clouds+"%");
//                        tvCountry.setText(countryName);
//                        tvCity.setText(cityName);
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
        searchCorona = findViewById(R.id.searchCorona);
        btSearchCorona = findViewById(R.id.btSearchCorona);
        tvCountryCorona = findViewById(R.id.countryCorona);
        tvContinentCorona = findViewById(R.id.continent);
        tvPopulationCorona = findViewById(R.id.population);
        tvTodayCasesCorona = findViewById(R.id.todayCases);
        tvCasesCorona = findViewById(R.id.cases);
        tvTodayDeathsCorona = findViewById(R.id.todayDeaths);
        tvDeathsCorona = findViewById(R.id.deaths);
        tvTodayRecoveredCorona = findViewById(R.id.todayRecovered);
        tvRecoveredCorona = findViewById(R.id.recovered);
        flag = findViewById(R.id.flag);



        search = findViewById(R.id.search);
//        btSearch = findViewById(R.id.btSearch);
//        btDays = findViewById(R.id.btDays);
        tvCity = findViewById(R.id.city);
        tvCountry = findViewById(R.id.country);
        tvDay = findViewById(R.id.day);
        tvTemp = findViewById(R.id.temp);
        tvDescription = findViewById(R.id.description);
        tvHumidity = findViewById(R.id.humidity);
        tvCloud = findViewById(R.id.cloud);
        tvWind = findViewById(R.id.wind);
        imIcon = findViewById(R.id.icon);
    }
}