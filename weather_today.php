<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Weather App</title>
    
    <link rel="preconnect" href="https://fonts.gstatic.com">
    <link href="https://fonts.googleapis.com/css2?family=Open+Sans:wght@300;400;700&display=swap" rel="stylesheet">
    <link rel="stylesheet" href="main.css">
</head>
<body>
<div class="container">
    <div class="main-section">
        <div class="search-bar">
            <i class="fas fa-search search-icon"></i>
            <form method="POST">
                <input type="text" name="search_city" id="search-input" placeholder="Tìm kiếm thành phố...">
            </form>
        </div>
        <div class="info-wrapper">
            <p class="city-name">--</p>
            <p class="weather-state">--</p>
            <img src="http://openweathermap.org/img/wn/10d@2x.png" alt="weather icon" class="weather-icon">
            <p class="temperature">--</p>
        </div>
    </div>
    <div class="additional-section">
        <div class="row">
            <div class="item">
                <div class="label">MT Mọc</div>
                <div class="value sunrise">--</div>
            </div>
            <div class="item">
                <div class="label">MT Lặn</div>
                <div class="value sunset">--</div>
            </div>
        </div>
        <div class="row">
            <div class="item">
                <div class="label">Độ ẩm</div>
                <div class="value"><span class="humidity">--</span>%</div>
            </div>
            <div class="item">
                <div class="label">Gió</div>
                <div class="value"><span class="wind-speed">--</span> km/h</div>
            </div>
        </div>
    </div>
</div>
<?php
if(isset($_POST['search_city']) && $_POST['search_city']!=''){
    $data = $_POST['search_city'];
    $jsondata = file_get_contents('https://api.openweathermap.org/data/2.5/weather?q='.$data.'&appid=eb2857e0c14fa00aea9ac15f5e320f71&units=metric&lang=vi');
}else{
    $jsondata = file_get_contents('https://api.openweathermap.org/data/2.5/weather?q=Hanoi&appid=eb2857e0c14fa00aea9ac15f5e320f71&units=metric&lang=vi');
}
?>
<script src="all.min.js"></script>
<script src="moment.js"></script>
<script type="text/javascript">
    const DEFAULT_VALUE = '--';
    const cityName = document.querySelector('.city-name');
    const weatherState = document.querySelector('.weather-state');
    const weatherIcon = document.querySelector('.weather-icon');
    const temperature = document.querySelector('.temperature');
    const sunrise = document.querySelector('.sunrise');
    const sunset = document.querySelector('.sunset');
    const humidity = document.querySelector('.humidity');
    const windSpeed = document.querySelector('.wind-speed');
    const data = <?php echo $jsondata;?>;

    cityName.innerHTML = data.name || DEFAULT_VALUE;
    weatherState.innerHTML = data.weather[0].description || DEFAULT_VALUE;
    weatherIcon.setAttribute('src', `http://openweathermap.org/img/wn/${data.weather[0].icon}@2x.png`);
    temperature.innerHTML = Math.round(data.main.temp) || DEFAULT_VALUE;

    sunrise.innerHTML = moment.unix(data.sys.sunrise).format('H:mm') || DEFAULT_VALUE;
    sunset.innerHTML = moment.unix(data.sys.sunset).format('H:mm') || DEFAULT_VALUE;

    humidity.innerHTML = data.main.humidity || DEFAULT_VALUE;
    windSpeed.innerHTML = (data.wind.speed * 3.6).toFixed(2) || DEFAULT_VALUE;
</script>
</body>
</html>