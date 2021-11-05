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
import com.squareup.picasso.Picasso;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import java.text.DateFormat;
import java.text.DecimalFormat;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.Date;

public class WeatherActivity extends AppCompatActivity {
    EditText search;
    TextView tvCity, tvCountry, tvDay, tvTemp, tvDescription, tvHumidity, tvCloud, tvWind;
    TextView tvTemp1, tvTemp2, tvTemp3, tvTemp4, tvDay1, tvDay2, tvDay3, tvDay4, tvWind1, tvWind2, tvWind3, tvWind4;
    ImageView imIcon, img1, img2, img3, img4;

    private final String url = "https://api.openweathermap.org/data/2.5/forecast";
    private final String appid = "433949589717ca433ae0129961126942&units=metric&lang=vi";
    DecimalFormat df = new DecimalFormat("#.#");
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_weather);
        anhxa();

        String tempUrl = "";

        tempUrl = url + "?q=hanoi&appid=" + appid;
        viewData(tempUrl);



    }

    private void viewData(String tempUrl) {
        StringRequest stringRequest = new StringRequest(Request.Method.POST, tempUrl, new Response.Listener<String>() {
            @Override
            public void onResponse(String response) {
                try {
                    JSONObject jsonResponse = new JSONObject(response);

                    JSONArray jsonArrayList = jsonResponse.getJSONArray("list");
                    JSONObject jsonObjectList = jsonArrayList.getJSONObject(0);

                    String day = jsonObjectList.getString("dt_txt");

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
                    SimpleDateFormat formatStringToDate = new SimpleDateFormat("yyyy-MM-dd");
                    SimpleDateFormat newFormatMain = new SimpleDateFormat("dd/MM/yyyy");
                    SimpleDateFormat newFormatItem = new SimpleDateFormat("dd/MM");


                    JSONObject jsonObjectList1 = jsonArrayList.getJSONObject(8);
                    String day1 = jsonObjectList1.getString("dt_txt");
                    JSONArray jsonArray1 = jsonObjectList1.getJSONArray("weather");
                    JSONObject jsonObjectWeather1 = jsonArray1.getJSONObject(0);
                    String icon1 = jsonObjectWeather1.getString("icon");
                    JSONObject jsonObjectMain1 = jsonObjectList1.getJSONObject("main");
                    double temp1 = jsonObjectMain1.getDouble("temp");
                    JSONObject jsonObjectWind1 = jsonObjectList1.getJSONObject("wind");
                    String wind1 = jsonObjectWind1.getString("speed");

                    JSONObject jsonObjectList2 = jsonArrayList.getJSONObject(16);
                    String day2 = jsonObjectList2.getString("dt_txt");
                    JSONArray jsonArray2 = jsonObjectList2.getJSONArray("weather");
                    JSONObject jsonObjectWeather2 = jsonArray2.getJSONObject(0);
                    String icon2 = jsonObjectWeather2.getString("icon");
                    JSONObject jsonObjectMain2 = jsonObjectList2.getJSONObject("main");
                    double temp2 = jsonObjectMain2.getDouble("temp");
                    JSONObject jsonObjectWind2 = jsonObjectList2.getJSONObject("wind");
                    String wind2 = jsonObjectWind2.getString("speed");

                    JSONObject jsonObjectList3 = jsonArrayList.getJSONObject(24);
                    String day3 = jsonObjectList3.getString("dt_txt");
                    JSONArray jsonArray3 = jsonObjectList3.getJSONArray("weather");
                    JSONObject jsonObjectWeather3 = jsonArray3.getJSONObject(0);
                    String icon3 = jsonObjectWeather3.getString("icon");
                    JSONObject jsonObjectMain3 = jsonObjectList3.getJSONObject("main");
                    double temp3 = jsonObjectMain3.getDouble("temp");
                    JSONObject jsonObjectWind3 = jsonObjectList3.getJSONObject("wind");
                    String wind3 = jsonObjectWind3.getString("speed");

                    JSONObject jsonObjectList4 = jsonArrayList.getJSONObject(32);
                    String day4 = jsonObjectList4.getString("dt_txt");
                    JSONArray jsonArray4 = jsonObjectList4.getJSONArray("weather");
                    JSONObject jsonObjectWeather4 = jsonArray4.getJSONObject(0);
                    String icon4 = jsonObjectWeather4.getString("icon");
                    JSONObject jsonObjectMain4 = jsonObjectList4.getJSONObject("main");
                    double temp4 = jsonObjectMain4.getDouble("temp");
                    JSONObject jsonObjectWind4 = jsonObjectList4.getJSONObject("wind");
                    String wind4 = jsonObjectWind4.getString("speed");



                    try {
                        Date dateMain = formatStringToDate.parse(day);
                        Date dateItem1 = formatStringToDate.parse(day1);
                        Date dateItem2 = formatStringToDate.parse(day2);
                        Date dateItem3 = formatStringToDate.parse(day3);
                        Date dateItem4 = formatStringToDate.parse(day4);
                        tvDay.setText(newFormatMain.format(dateMain));
                        tvDay1.setText(newFormatItem.format(dateItem1));
                        tvDay2.setText(newFormatItem.format(dateItem2));
                        tvDay3.setText(newFormatItem.format(dateItem3));
                        tvDay4.setText(newFormatItem.format(dateItem4));
                    } catch (ParseException e) {
                        e.printStackTrace();
                    }

                    tvDescription.setText(description);

                    Picasso.get().load("http://openweathermap.org/img/wn/"+icon+"@2x.png").into(imIcon);
                    Picasso.get().load("http://openweathermap.org/img/wn/"+icon1+"@2x.png").into(img1);
                    Picasso.get().load("http://openweathermap.org/img/wn/"+icon2+"@2x.png").into(img2);
                    Picasso.get().load("http://openweathermap.org/img/wn/"+icon3+"@2x.png").into(img3);
                    Picasso.get().load("http://openweathermap.org/img/wn/"+icon4+"@2x.png").into(img4);

                    tvTemp.setText(df.format(temp));
                    tvTemp1.setText(df.format(temp1));
                    tvTemp2.setText(df.format(temp2));
                    tvTemp3.setText(df.format(temp3));
                    tvTemp4.setText(df.format(temp4));

                    tvHumidity.setText(df.format(humidity)+"%");
                    tvWind.setText(wind+"km/h");
                    tvWind1.setText(wind1+"km/h");
                    tvWind2.setText(wind2+"km/h");
                    tvWind3.setText(wind3+"km/h");
                    tvWind4.setText(wind4+"km/h");

                    tvCloud.setText(clouds+"%");
                    tvCountry.setText(countryName);
                    tvCity.setText(cityName);
                } catch (JSONException e) {
                    e.printStackTrace();
                }
            }

            private void day1(JSONArray jsonArrayList) {


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


    public void getWeatherDetails(View view) {
        String tempUrl = "";
        String city = search.getText().toString().trim();
        if(city.equals("")){
            search.setText("City field can not be empty!");
        }else{
            tempUrl = url + "?q=" + city + "&appid=" + appid;
            viewData(tempUrl);
        }
    }

    private void anhxa(){
        search = findViewById(R.id.search);
        tvCity = findViewById(R.id.city);
        tvCountry = findViewById(R.id.country);
        tvDay = findViewById(R.id.day);
        tvTemp = findViewById(R.id.temp);
        tvDescription = findViewById(R.id.description);
        tvHumidity = findViewById(R.id.humidity);
        tvCloud = findViewById(R.id.cloud);
        tvWind = findViewById(R.id.wind);
        imIcon = findViewById(R.id.icon);

        tvDay1 = findViewById(R.id.day1);
        tvDay2 = findViewById(R.id.day2);
        tvDay3 = findViewById(R.id.day3);
        tvDay4 = findViewById(R.id.day4);
        tvWind1 = findViewById(R.id.wind1);
        tvWind2 = findViewById(R.id.wind2);
        tvWind3 = findViewById(R.id.wind3);
        tvWind4 = findViewById(R.id.wind4);
        tvTemp1 = findViewById(R.id.temp1);
        tvTemp2 = findViewById(R.id.temp2);
        tvTemp3 = findViewById(R.id.temp3);
        tvTemp4 = findViewById(R.id.temp4);

        img1 = findViewById(R.id.img1);
        img2 = findViewById(R.id.img2);
        img3 = findViewById(R.id.img3);
        img4 = findViewById(R.id.img4);
    }

}