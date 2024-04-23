package com.example.androidapiweather_corona;

import androidx.appcompat.app.AppCompatActivity;

import android.os.Bundle;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ImageView;
import android.widget.TextView;

public class CoronaActivity extends AppCompatActivity {
    EditText search;
    Button btSearch;
    TextView country, continent, population, todayCases, cases, todayDeaths, deaths, todayRecovered, recovered;
    ImageView flag;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_corona);
        anhxa();
    }

    private void anhxa() {
        search = findViewById(R.id.search);
        btSearch = findViewById(R.id.btSearch);
        country = findViewById(R.id.country);
        continent = findViewById(R.id.continent);
        population = findViewById(R.id.population);
        todayCases = findViewById(R.id.todayCases);
        cases = findViewById(R.id.cases);
        todayDeaths = findViewById(R.id.todayDeaths);
        deaths = findViewById(R.id.deaths);
        todayRecovered = findViewById(R.id.todayRecovered);
        recovered = findViewById(R.id.recovered);
        flag = findViewById(R.id.flag);
    }
}