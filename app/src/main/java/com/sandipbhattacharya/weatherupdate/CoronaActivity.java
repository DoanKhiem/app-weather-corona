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

import java.text.DecimalFormat;

public class CoronaActivity extends AppCompatActivity {
    EditText searchCorona;
    Button btSearchCorona;
    TextView tvCountryCorona, tvContinentCorona, tvPopulationCorona, tvTodayCasesCorona, tvCasesCorona, tvTodayDeathsCorona, tvDeathsCorona, tvTodayRecoveredCorona, tvRecoveredCorona;
    ImageView imFlag;
    DecimalFormat df = new DecimalFormat("#,###");

    private final String urlCorona = "https://disease.sh/v3/covid-19/countries";
    private final String countrySearch = "Vietnam";
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_corona);
        anhxa();

        viewData(urlCorona,countrySearch);
    }

    private void viewData(String urlCorona, String countrySearch) {
        StringRequest stringRequest = new StringRequest(Request.Method.GET, urlCorona, new Response.Listener<String>() {
            @Override
            public void onResponse(String response) {
                try {
                    JSONArray jsonArray = new JSONArray(response);

                    for (int j=0; j < jsonArray.length(); j++){
                        JSONObject jsonObjectList = jsonArray.getJSONObject(j);
                        String country = jsonObjectList.getString("country");
                        if (countrySearch.equals(country)){
                            String cases = jsonObjectList.getString("cases");
                            String todayCases = jsonObjectList.getString("todayCases");
                            String deaths = jsonObjectList.getString("deaths");
                            String todayDeaths = jsonObjectList.getString("todayDeaths");
                            String recovered = jsonObjectList.getString("recovered");
                            String todayRecovered = jsonObjectList.getString("todayRecovered");
                            String population = jsonObjectList.getString("population");
                            String continent = jsonObjectList.getString("continent");
                            JSONObject jsoncountryInfo = jsonObjectList.getJSONObject("countryInfo");
                            String flag = jsoncountryInfo.getString("flag");
                            tvCountryCorona.setText(country);
                            tvCasesCorona.setText(cases+" người");
                            tvContinentCorona.setText(continent);
                            tvTodayCasesCorona.setText(todayCases+" người");
                            tvDeathsCorona.setText(deaths+" người");
                            tvTodayDeathsCorona.setText(todayDeaths+" người");
                            tvRecoveredCorona.setText(recovered+" người");
                            tvTodayRecoveredCorona.setText(todayRecovered+" người");
                            tvPopulationCorona.setText(population+" người");
                            Picasso.get().load(flag).into(imFlag);
                            break;

                        }

                    }


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

    private void anhxa() {
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
        imFlag = findViewById(R.id.flag);
    }

    public void getCoronaDetails(View view) {
        String countrySearch = searchCorona.getText().toString();
        if(countrySearch.equals("")){
            searchCorona.setText("Nhập tên đất nước");
        }else{
            viewData(urlCorona,countrySearch);
        }
    }


}