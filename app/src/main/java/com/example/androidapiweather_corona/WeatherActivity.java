package com.example.androidapiweather_corona;

import androidx.appcompat.app.AppCompatActivity;

import android.os.Bundle;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ImageView;
import android.widget.TextView;

public class WeatherActivity extends AppCompatActivity {

    EditText search;
    Button btSearch, btDays;
    TextView city, country, day, temp, description, humidity, cloud, wind;
    ImageView icon;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_weather);

        anhxa();
    }

    private void anhxa(){
        search = findViewById(R.id.search);
        btSearch = findViewById(R.id.btSearch);
        btDays = findViewById(R.id.btDays);
        city = findViewById(R.id.city);
        country = findViewById(R.id.country);
        day = findViewById(R.id.day);
        temp = findViewById(R.id.temp);
        description = findViewById(R.id.description);
        humidity = findViewById(R.id.humidity);
        cloud = findViewById(R.id.cloud);
        wind = findViewById(R.id.wind);
        icon = findViewById(R.id.icon);
    }
}