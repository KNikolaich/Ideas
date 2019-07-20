
  // set your channel id here
  var channel_id = 815578;
  // set your channel's read api key here if necessary
  var api_key = 'TLUXMOXC1LP26BB7';
  
  // name of the gauge
  var gauge_name = 'U АКБ';
  var gauge_nameSun = 'Sun';

  // global variables
  var chart, charts;//, data;
  
google.charts.load('current', {'packages':['corechart']});
      google.charts.setOnLoadCallback(initChart);

  // display the data
  function displayData(point) {
  
  var data = new google.visualization.DataTable();
      data.addColumn('date', 'created_at');
      data.addColumn('number', gauge_name);
      data.addColumn('number', gauge_nameSun);
	var field4 = 0.0;
	var field3 = 0.0;

	for(var key in point){
		if(point[key])
		{
			if(Number(point[key].field4)> 2)
			{
				  field4 = Number(point[key].field4);
				
			}
			if(point[key] && Number(point[key].field3) > 0 )
			{
				var valueF3 = Number(point[key].field3);
				field3=10/valueF3 + 12.5;
			}
			if(field3 != 0.0 && field4 != 0.0)
				data.addRow([ new Date(point[key].created_at), field4, field3 ]	);
		}
			
	  }
      
var options = {
  title: 'График напряжения на аккуме, в зависимости от освещенности',
          curveType: 'function',
          legend: { position: 'bottom' },
        height: 450,
        timeline: {
          groupByRowLabel: true
        }
      };
    chart.draw(data, options);
  }
  
  // load the data
  function loadData() {
    // variable for the data point
    var p;
    var d = new Date();
    d.setDate(d.getDate() - 1);
    
    // get the data from thingspeak
    //$.getJSON('https://api.thingspeak.com/channels/' + channel_id + '/fields/4.json?api_key=' + api_key , function(data) {
$.getJSON('https://api.thingspeak.com/channels/' + channel_id + '/feeds.json?api_key=' + api_key  + '&start='+d.toLocaleDateString(), function(data) {
      // get the data point
      p = data.feeds;

      // if there is a data point display it
      if (p) {
        displayData(p);
      }

    });
  }
  
    // initialize the chart
function initChart() {


	chart = new google.visualization.LineChart(document.getElementById('curve_chart'));
      
	loadData();

    // load new data every 15 seconds
    setInterval('loadData()', 15000);
}
